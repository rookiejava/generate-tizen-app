/**
 * Create-TizenProject.js
 * 
 * 템플릿 파일들의 플레이스홀더를 치환하여 빌드 가능한 Tizen .NET 프로젝트를 생성합니다.
 * 
 * 사용법: node Create-TizenProject.js <앱이름> [출력폴더]
 * 예시:   node Create-TizenProject.js MyLoginApp ../output/MyLoginApp
 */

const fs = require('fs');
const path = require('path');

const appName = process.argv[2];
if (!appName) {
    console.error('사용법: node Create-TizenProject.js <앱이름> [출력폴더]');
    process.exit(1);
}

const templateDir = path.join(__dirname, '..', 'templates');
const outputDir = process.argv[3] || path.join(__dirname, '..', 'output', appName);

// 플레이스홀더 값 정의
const placeholders = {
    '{{APP_NAME}}': appName,
    '{{APP_NAMESPACE}}': appName.replace(/[^a-zA-Z0-9]/g, ''),
    '{{APP_ID}}': appName.toLowerCase().replace(/[^a-z0-9]/g, ''),
    '{{APP_LABEL}}': appName,
    '{{MAIN_VIEW_CONTENT}}': '// TODO: AI가 생성한 코드로 교체',
};

// 파일 복사 및 플레이스홀더 치환
function processTemplate(srcFile, destFile) {
    let content = fs.readFileSync(srcFile, 'utf-8');
    for (const [key, value] of Object.entries(placeholders)) {
        content = content.replaceAll(key, value);
    }
    fs.writeFileSync(destFile, content, 'utf-8');
}

// 출력 폴더 생성
fs.mkdirSync(outputDir, { recursive: true });

// 템플릿 매핑 (소스 → 대상 파일명)
const fileMap = {
    'Template.csproj': `${appName}.csproj`,
    'tizen-manifest.xml': 'tizen-manifest.xml',
    'App.cs': 'App.cs',
    'MainView.cs': 'MainView.cs',
};

console.log(`🏗️  Tizen .NET 프로젝트 생성 중: ${appName}`);
console.log(`📂 출력 경로: ${outputDir}\n`);

for (const [src, dest] of Object.entries(fileMap)) {
    const srcPath = path.join(templateDir, src);
    const destPath = path.join(outputDir, dest);
    processTemplate(srcPath, destPath);
    console.log(`   ✅ ${dest}`);
}

// shared/res 폴더 및 기본 아이콘 생성
const resDir = path.join(outputDir, 'shared', 'res');
fs.mkdirSync(resDir, { recursive: true });
const defaultIconBase64 = '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';
fs.writeFileSync(path.join(resDir, 'icon.png'), Buffer.from(defaultIconBase64, 'base64'));
console.log(`   ✅ shared/res/icon.png (기본 1x1 투명 아이콘)`);

console.log(`\n🚀 프로젝트 생성 완료!`);
console.log(`\n📋 빌드하려면:`);
console.log(`   cd ${outputDir}`);
console.log(`   dotnet build`);
