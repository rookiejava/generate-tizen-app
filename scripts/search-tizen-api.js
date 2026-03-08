const fs = require('fs');
const path = require('path');

const args = process.argv.slice(2);
let searchByMember = false;
let query = '';

if (args.length === 0) {
    console.error('사용법:');
    console.error('  클래스명 검색: node search-tizen-api.js <클래스명|네임스페이스.클래스명>');
    console.error('  예시: node search-tizen-api.js Button');
    console.error('  예시: node search-tizen-api.js Material.Button');
    console.error('  멤버(속성/메서드) 검색: node search-tizen-api.js -m <멤버명>');
    console.error('  예시: node search-tizen-api.js -m TextColor');
    process.exit(1);
}

if (args[0] === '-m' && args.length > 1) {
    searchByMember = true;
    query = args[1];
} else {
    query = args[0];
}

const apiInfoDir = path.join(__dirname, '..', 'ApiInfo');
const searchTarget = query.toLowerCase();
let foundCount = 0;

// Search all api-index.json files
const dirs = fs.readdirSync(apiInfoDir, { withFileTypes: true })
    .filter(dirent => dirent.isDirectory())
    .map(dirent => dirent.name);

console.log(`🔍 '${query}' 검색 결과 (${searchByMember ? '멤버 검색' : '클래스 검색'}):\n`);

for (const dir of dirs) {
    const indexPath = path.join(apiInfoDir, dir, 'api-index.json');
    if (!fs.existsSync(indexPath)) continue;

    const data = JSON.parse(fs.readFileSync(indexPath, 'utf-8'));
    const namespaces = data.n || [];

    for (const ns of namespaces) {
        const types = ns.t || [];
        for (const cls of types) {
            const fullName = `${ns.n}.${cls.n}`;
            let isMatch = false;
            let matchedMembers = [];

            if (searchByMember) {
                // 멤버 검색 모드
                const members = cls.m || [];
                matchedMembers = members.filter(mem => (mem.n || '').toLowerCase().includes(searchTarget));
                if (matchedMembers.length > 0) {
                    isMatch = true;
                }
            } else {
                // 클래스 검색 모드
                isMatch = cls.n.toLowerCase().includes(searchTarget) || fullName.toLowerCase().includes(searchTarget);
            }

            if (isMatch) {
                foundCount++;
                console.log(`========================================================`);
                console.log(`🧩 클래스: ${fullName}`);
                if (cls.k === 'enum') console.log(`📌 종류: Enum (세부 상수값은 metadata에 제공되지 않음)`);
                if (cls.b) console.log(`🔄 상속: ${cls.b}`);
                console.log(`========================================================`);

                const properties = (cls.m || []).filter(member => member.k === 'property');
                const events = (cls.m || []).filter(member => member.k === 'event');
                const methods = (cls.m || []).filter(member => member.k === 'method');

                if (searchByMember) {
                    console.log(`\n[🔍 일치하는 멤버]`);
                    matchedMembers.forEach(m => console.log(`  - (${m.k}) ${m.s}`));
                } else {
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
                }
                console.log('\n');
            }
        }
    }
}

if (foundCount === 0) {
    console.log(`❌ '${query}'에 해당하는 결과를 찾을 수 없습니다.`);
} else {
    console.log(`✅ 총 ${foundCount}개의 클래스가 검색되었습니다.`);
}
