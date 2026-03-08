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
const defaultIconBase64 = 'iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNkYAAAAAYAAjCB0C8AAAAASUVORK5CYII=';
fs.writeFileSync(path.join(resDir, 'icon.png'), Buffer.from(defaultIconBase64, 'base64'));
console.log(`   ✅ shared/res/icon.png (기본 1x1 투명 아이콘)`);

console.log(`\n🚀 프로젝트 생성 완료!`);
console.log(`\n📋 빌드하려면:`);
console.log(`   cd ${outputDir}`);
console.log(`   dotnet build`);
