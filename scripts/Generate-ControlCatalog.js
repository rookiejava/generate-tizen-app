/**
 * Generate-ControlCatalog.js
 * 
 * api-index.json 파일들을 파싱하여 UI 컨트롤 경량 카탈로그를 생성합니다.
 * - View를 직간접적으로 상속하는 클래스만 필터링
 * - public 프로퍼티, 이벤트, 주요 생성자만 추출
 * - 결과: TizenUI_ControlCatalog.json + TizenUI_ControlCatalog.md
 * 
 * 사용법: node Generate-ControlCatalog.js <ApiInfo폴더> <출력폴더>
 */

const fs = require('fs');
const path = require('path');

const apiInfoDir = process.argv[2] || path.join(__dirname, '..', 'ApiInfo');
const outputDir = process.argv[3] || path.join(__dirname, '..', 'ApiInfo');

// View를 직간접 상속하는 기본 타입들 (시드)
const viewBaseTypes = new Set([
    'Tizen.UI.View',
    'Tizen.UI.ViewGroup',
    'Tizen.UI.ContentView',
    'Tizen.UI.NObject',
]);

// 1단계: 모든 api-index.json 로드
function loadAllApiIndexes(dir) {
    const allTypes = [];
    const packages = fs.readdirSync(dir).filter(f =>
        fs.statSync(path.join(dir, f)).isDirectory()
    );

    for (const pkg of packages) {
        const indexPath = path.join(dir, pkg, 'api-index.json');
        if (!fs.existsSync(indexPath)) continue;

        const data = JSON.parse(fs.readFileSync(indexPath, 'utf-8'));
        for (const ns of (data.n || [])) {
            for (const type of (ns.t || [])) {
                allTypes.push({
                    ...type,
                    namespace: ns.n,
                    package: pkg,
                });
            }
        }
    }
    return allTypes;
}

// 2단계: View 상속 체인 추적
function findViewDescendants(allTypes) {
    // fullName → type 매핑
    const typeMap = new Map();
    for (const t of allTypes) {
        typeMap.set(t.f, t);
    }

    // View 하위 타입인지 재귀 확인
    const cache = new Map();
    function isViewDescendant(fullName) {
        if (cache.has(fullName)) return cache.get(fullName);
        if (viewBaseTypes.has(fullName)) { cache.set(fullName, true); return true; }

        const type = typeMap.get(fullName);
        if (!type || !type.b) { cache.set(fullName, false); return false; }

        const result = isViewDescendant(type.b);
        cache.set(fullName, result);
        return result;
    }

    return allTypes.filter(t => t.k === 'class' && isViewDescendant(t.f));
}

// 3단계: 공개 프로퍼티/이벤트/생성자만 추출
function extractPublicApi(type) {
    const members = type.m || [];

    const properties = members
        .filter(m => m.k === 'property' && m.s.startsWith('public'))
        .map(m => m.s);

    const events = members
        .filter(m => m.k === 'event' && m.s.startsWith('public'))
        .map(m => m.s);

    const constructors = members
        .filter(m => m.k === 'constructor' && m.n === '.ctor' && !m.s.includes('IntPtr'))
        .map(m => m.s);

    return {
        name: type.n,
        fullName: type.f,
        namespace: type.namespace,
        package: type.package,
        base: type.b,
        interfaces: type.i.filter(i => !i.includes('Internal')),
        constructors,
        properties,
        events,
    };
}

// 4단계: 마크다운 생성
function generateMarkdown(catalog) {
    let md = '# Tizen.UI Control Catalog (Lightweight)\n\n';
    md += `> 자동 생성됨: ${new Date().toISOString()}\n`;
    md += `> 총 ${catalog.length}개 UI 컨트롤\n\n`;
    md += '---\n\n';

    // 패키지별 그룹핑
    const byPackage = {};
    for (const c of catalog) {
        if (!byPackage[c.package]) byPackage[c.package] = [];
        byPackage[c.package].push(c);
    }

    for (const [pkg, controls] of Object.entries(byPackage)) {
        md += `## 📦 ${pkg}\n\n`;
        for (const ctrl of controls) {
            md += `### \`${ctrl.fullName}\`\n`;
            md += `- **상속**: \`${ctrl.base}\`\n`;
            if (ctrl.interfaces.length > 0) {
                md += `- **인터페이스**: ${ctrl.interfaces.map(i => '`' + i + '`').join(', ')}\n`;
            }

            if (ctrl.constructors.length > 0) {
                md += `- **생성자**:\n`;
                for (const c of ctrl.constructors) {
                    md += `  - \`${c}\`\n`;
                }
            }

            if (ctrl.properties.length > 0) {
                md += `- **프로퍼티** (${ctrl.properties.length}개):\n`;
                for (const p of ctrl.properties) {
                    md += `  - \`${p}\`\n`;
                }
            }

            if (ctrl.events.length > 0) {
                md += `- **이벤트** (${ctrl.events.length}개):\n`;
                for (const e of ctrl.events) {
                    md += `  - \`${e}\`\n`;
                }
            }
            md += '\n';
        }
    }

    return md;
}

// 실행
console.log('🔍 API 메타데이터 로드 중...');
const allTypes = loadAllApiIndexes(apiInfoDir);
console.log(`   전체 타입 수: ${allTypes.length}`);

console.log('🧬 View 상속 체인 추적 중...');
const viewDescendants = findViewDescendants(allTypes);
console.log(`   View 하위 타입 수: ${viewDescendants.length}`);

console.log('✂️  공개 API만 추출 중...');
const catalog = viewDescendants.map(extractPublicApi);

// 프로퍼티나 이벤트가 하나도 없는 내부용 클래스 제거
const filtered = catalog.filter(c =>
    c.properties.length > 0 || c.events.length > 0
);
console.log(`   실사용 가능한 컨트롤 수: ${filtered.length}`);

// JSON 저장
const jsonPath = path.join(outputDir, 'TizenUI_ControlCatalog.json');
fs.writeFileSync(jsonPath, JSON.stringify(filtered, null, 2), 'utf-8');
console.log(`✅ JSON 저장: ${jsonPath}`);

// MD 저장
const mdPath = path.join(outputDir, 'TizenUI_ControlCatalog.md');
fs.writeFileSync(mdPath, generateMarkdown(filtered), 'utf-8');
console.log(`✅ MD 저장: ${mdPath}`);

console.log('\n🚀 컨트롤 카탈로그 생성 완료!');
