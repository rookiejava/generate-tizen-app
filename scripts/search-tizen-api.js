const fs = require('fs');
const path = require('path');

const query = process.argv[2];
if (!query) {
    console.error('사용법: node search-tizen-api.js <클래스명>');
    console.error('예시: node search-tizen-api.js Button');
    process.exit(1);
}

const apiInfoDir = path.join(__dirname, '..', 'ApiInfo');
const searchTarget = query.toLowerCase();
let found = false;

// Search all api-index.json files
const dirs = fs.readdirSync(apiInfoDir, { withFileTypes: true })
    .filter(dirent => dirent.isDirectory())
    .map(dirent => dirent.name);

console.log(`🔍 '${query}' 검색 결과:\n`);

for (const dir of dirs) {
    const indexPath = path.join(apiInfoDir, dir, 'api-index.json');
    if (!fs.existsSync(indexPath)) continue;

    const data = JSON.parse(fs.readFileSync(indexPath, 'utf-8'));
    const namespaces = data.n || [];

    for (const ns of namespaces) {
        const types = ns.t || [];
        for (const cls of types) {
            if (cls.n.toLowerCase().includes(searchTarget)) {
                found = true;
                console.log(`========================================================`);
                console.log(`🧩 클래스: ${ns.n}.${cls.n}`);
                if (cls.b) console.log(`🔄 상속: ${cls.b}`);
                console.log(`========================================================`);

                const properties = (cls.m || []).filter(member => member.k === 'property');
                const events = (cls.m || []).filter(member => member.k === 'event');

                if (properties.length > 0) {
                    console.log(`\n[속성 (Properties)]`);
                    properties.forEach(p => console.log(`  - ${p.s}`));
                } else {
                    console.log(`\n[속성 (Properties)] 없음`);
                }

                if (events.length > 0) {
                    console.log(`\n[이벤트 (Events)]`);
                    events.forEach(e => console.log(`  - ${e.s}`));
                } else {
                    console.log(`\n[이벤트 (Events)] 없음`);
                }
                console.log('\n');
            }
        }
    }
}

if (!found) {
    console.log(`❌ '${query}'에 해당하는 클래스를 찾을 수 없습니다.`);
}
