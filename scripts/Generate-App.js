#!/usr/bin/env node
/**
 * Generate-App.js
 * 
 * Tizen .NET UI 앱 자동 생성 CLI
 * 자연어 요구사항 → LLM API → C# 코드 → 프로젝트 조립 → 빌드 → Self-Healing
 * 
 * 사용법:
 *   node scripts/Generate-App.js "계산기 앱 생성" [옵션]
 * 
 * 옵션:
 *   --provider <gemini|openai|claude>  LLM 프로바이더 (기본: gemini)
 *   --name <AppName>                   앱 이름 (미지정 시 LLM이 자동 결정)
 *   --output <path>                    출력 경로 (기본: output/<AppName>)
 *   --no-build                         빌드 건너뛰기
 *   --max-retries <N>                  Self-Healing 최대 재시도 (기본: 10)
 */

const fs = require('fs');
const path = require('path');
const { execSync } = require('child_process');
const { createProvider, providers } = require('./llm-providers');

const ROOT = path.resolve(__dirname, '..');

// ─── CLI 인수 파싱 ───
function parseArgs() {
    const args = process.argv.slice(2);
    const opts = {
        prompt: '',
        provider: 'gemini',
        name: '',
        output: '',
        build: true,
        maxRetries: 10,
    };

    const positional = [];
    for (let i = 0; i < args.length; i++) {
        switch (args[i]) {
            case '--provider': opts.provider = args[++i]; break;
            case '--name': opts.name = args[++i]; break;
            case '--output': opts.output = args[++i]; break;
            case '--no-build': opts.build = false; break;
            case '--max-retries': opts.maxRetries = parseInt(args[++i], 10); break;
            case '--help': case '-h': printHelp(); process.exit(0);
            default: positional.push(args[i]);
        }
    }
    opts.prompt = positional.join(' ');
    return opts;
}

function printHelp() {
    console.log(`
🚀 Generate-App.js — Tizen .NET UI 앱 자동 생성 CLI

사용법:
  node scripts/Generate-App.js "앱 설명" [옵션]

옵션:
  --provider <name>     LLM 프로바이더: ${providers.join(', ')} (기본: gemini)
  --name <AppName>      앱 이름 (PascalCase, 미지정 시 자동 결정)
  --output <path>       출력 경로 (기본: output/<AppName>)
  --no-build            빌드 건너뛰기
  --max-retries <N>     Self-Healing 최대 재시도 (기본: 10)
  -h, --help            도움말

환경변수:
  GEMINI_API_KEY        Gemini API 키
  OPENAI_API_KEY        OpenAI API 키
  ANTHROPIC_API_KEY     Anthropic (Claude) API 키

예시:
  node scripts/Generate-App.js "간단한 계산기 앱" --provider gemini
  node scripts/Generate-App.js "할일 목록 앱" --provider openai --name TodoApp
`);
}

// ─── 시스템 프롬프트 빌드 ───
function buildSystemPrompt() {
    const promptTemplate = fs.readFileSync(
        path.join(ROOT, 'prompts', 'system-prompt.md'), 'utf-8'
    );
    const catalog = fs.readFileSync(
        path.join(ROOT, 'ApiInfo', 'TizenUI_ControlCatalog.md'), 'utf-8'
    );
    return promptTemplate.replace('{{CONTROL_CATALOG}}', catalog);
}

// ─── LLM 응답에서 C# 코드 추출 ───
function extractCode(response) {
    // 마크다운 코드 블록이 있으면 추출
    const csharpBlock = response.match(/```(?:csharp|cs)?\s*\n([\s\S]*?)```/);
    if (csharpBlock) return csharpBlock[1].trim();

    // 코드 블록이 없으면 전체가 코드라고 간주
    // 단, 앞뒤 설명 텍스트가 있을 수 있으므로 using부터 시작하는 부분을 찾음
    const usingStart = response.indexOf('using ');
    if (usingStart >= 0) return response.substring(usingStart).trim();

    return response.trim();
}

// ─── 앱 이름 추출/결정 ───
function resolveAppName(code, userProvided) {
    if (userProvided) return userProvided;

    // 코드에서 namespace 추출
    const nsMatch = code.match(/namespace\s+(\w+)/);
    if (nsMatch) return nsMatch[1];

    return 'TizenApp';
}

// ─── 프로젝트 생성 (Create-TizenProject.js 호출) ───
function createProject(appName, outputDir) {
    const script = path.join(ROOT, 'scripts', 'Create-TizenProject.js');
    execSync(`node "${script}" "${appName}" "${outputDir}"`, { stdio: 'inherit' });
}

// ─── MainView.cs 주입 ───
function injectMainView(outputDir, code, appName) {
    // namespace를 앱 이름에 맞게 교체
    const fixedCode = code.replace(
        /namespace\s+\w+;/,
        `namespace ${appName};`
    );
    const mainViewPath = path.join(outputDir, 'MainView.cs');
    fs.writeFileSync(mainViewPath, fixedCode, 'utf-8');
    console.log(`   ✅ MainView.cs 코드 주입 완료 (${fixedCode.split('\n').length}줄)`);
}

// ─── dotnet build ───
function runBuild(outputDir) {
    try {
        const result = execSync(
            'dotnet build 2>&1',
            { cwd: outputDir, encoding: 'utf-8', env: { ...process.env, DOTNET_CLI_UI_LANGUAGE: 'en' } }
        );
        console.log(result);

        if (result.includes('0 Error(s)') || result.includes('Build succeeded')) {
            return { success: true, output: result };
        }
        return { success: false, output: result };
    } catch (e) {
        return { success: false, output: e.stdout || e.message };
    }
}

// ─── 빌드 에러 파싱 ───
function parseBuildErrors(output) {
    const errors = [];
    const lines = output.split('\n');
    for (const line of lines) {
        const match = line.match(/^(.+?)\((\d+),(\d+)\):\s*error\s+(CS\d+):\s*(.+)/);
        if (match) {
            errors.push({
                file: match[1].trim(),
                line: parseInt(match[2]),
                col: parseInt(match[3]),
                code: match[4],
                message: match[5].trim(),
            });
        }
    }
    return errors;
}

// ─── API 정보 동적 조회 (Self-Healing용) ───
function lookupTizenApiForHealing(errors) {
    const hints = [];
    const searchQueries = new Set();
    const memberQueries = new Set();

    for (const e of errors) {
        if (e.code === 'CS0117' || e.code === 'CS1061') {
            // CS0117: 'Tizen.UI.Components.TextField' does not contain a definition for 'Weight'
            // CS1061: 'Button' does not contain a definition for 'SetColumn' and no accessible extension method
            const match = e.message.match(/'(.+?)'\s+does not contain a definition for\s+'(.+?)'/);
            if (match) {
                const className = match[1].split('.').pop();
                const propertyName = match[2];
                searchQueries.add(className);
                memberQueries.add(propertyName);
            }
        } else if (e.code === 'CS0246' || e.code === 'CS0103') {
            // CS0246: The type or namespace name 'RowDefinition' could not be found
            // CS0103: The name 'GridLength' does not exist in the current context
            const match = e.message.match(/name '(.+?)'/);
            if (match) {
                // Remove generic parts if any
                const typeName = match[1].split('<')[0];
                searchQueries.add(typeName);
            }
        }
    }

    const scriptPath = path.join(ROOT, 'scripts', 'search-tizen-api.js');

    // 1. 단일 클래스 검색
    for (const q of searchQueries) {
        try {
            const out = execSync(`node "${scriptPath}" ${q}`, { encoding: 'utf-8' });
            if (!out.includes("결과를 찾을 수 없습니다")) {
                hints.push(out.trim());
            }
        } catch (err) { }
    }

    // 2. 멤버명으로 역검색
    for (const mq of memberQueries) {
        try {
            const out = execSync(`node "${scriptPath}" -m ${mq}`, { encoding: 'utf-8' });
            if (!out.includes("결과를 찾을 수 없습니다")) {
                hints.push(out.trim());
            }
        } catch (err) { }
    }

    return hints.join('\n\n');
}

// ─── Self-Healing 프롬프트 ───
function buildHealingPrompt(code, errors, apiHints) {
    const errorText = errors.map(e =>
        `  ${e.code} at line ${e.line}: ${e.message}`
    ).join('\n');

    let prompt = `The following C# code failed to compile with these errors:

Build Errors:
${errorText}

Original Code:
\`\`\`csharp
${code}
\`\`\`

`;

    if (apiHints && apiHints.trim() !== '') {
        prompt += `Below are some extracted API Documentation from Tizen UI that might relate to the build errors. Use this to use correct properties/classes:

=== API HINTS ===
${apiHints}
=================

`;
    }

    prompt += `Fix ALL the build errors and return the complete, corrected MainView.cs file.
Do NOT change the overall structure or functionality, only fix the compilation errors.
Output ONLY the complete corrected C# code, no explanations.`;

    return prompt;
}

// ─── 메인 실행 ───
async function main() {
    const opts = parseArgs();

    if (!opts.prompt) {
        console.error('❌ 앱 설명을 입력해 주세요.');
        console.error('   예: node scripts/Generate-App.js "계산기 앱 생성"');
        process.exit(1);
    }

    console.log('');
    console.log('╔══════════════════════════════════════════════════╗');
    console.log('║   🚀 Tizen .NET UI 앱 자동 생성기                ║');
    console.log('╚══════════════════════════════════════════════════╝');
    console.log('');
    console.log(`📝 요구사항: "${opts.prompt}"`);
    console.log(`🤖 LLM 프로바이더: ${opts.provider}`);
    console.log('');

    // 1. LLM 프로바이더 초기화
    console.log('🔧 Step 1: LLM 프로바이더 초기화...');
    const llm = createProvider(opts.provider);
    console.log(`   ✅ ${opts.provider} 프로바이더 준비 완료`);

    // 2. 시스템 프롬프트 빌드
    console.log('📋 Step 2: 시스템 프롬프트 빌드...');
    const systemPrompt = buildSystemPrompt();
    console.log(`   ✅ 프롬프트 준비 완료 (${(systemPrompt.length / 1024).toFixed(1)}KB)`);

    // 3. LLM 호출하여 코드 생성
    console.log('🧠 Step 3: LLM에 코드 생성 요청 중...');
    let code;
    try {
        const userPrompt = `Create a Tizen .NET UI app for the following request:\n\n${opts.prompt}`;
        const response = await llm.generateCode(systemPrompt, userPrompt);
        code = extractCode(response);
        console.log(`   ✅ C# 코드 수신 완료 (${code.split('\n').length}줄)`);
    } catch (e) {
        console.error(`   ❌ LLM 호출 실패: ${e.message}`);
        process.exit(1);
    }

    // 4. 앱 이름 결정 & 프로젝트 생성
    const appName = resolveAppName(code, opts.name);
    const outputDir = opts.output || path.join(ROOT, 'output', appName);
    console.log(`🏗️  Step 4: 프로젝트 생성 (${appName})...`);
    createProject(appName, outputDir);

    // 5. MainView.cs 주입
    console.log('💉 Step 5: 생성된 코드 주입...');
    injectMainView(outputDir, code, appName);

    // 6. 빌드 (+ Self-Healing)
    if (!opts.build) {
        console.log('\n⏩ 빌드 건너뜀 (--no-build)');
        console.log(`\n✅ 프로젝트 생성 완료: ${outputDir}`);
        return;
    }

    console.log('🔨 Step 6: dotnet build...');
    let buildResult = runBuild(outputDir);

    let attempt = 0;
    while (!buildResult.success && attempt < opts.maxRetries) {
        attempt++;
        console.log(`\n🏥 Self-Healing 시도 ${attempt}/${opts.maxRetries}...`);

        const errors = parseBuildErrors(buildResult.output);
        if (errors.length === 0) {
            console.log('   ⚠️  에러를 파싱할 수 없습니다. 빌드 로그를 확인하세요.');
            break;
        }

        console.log(`   📋 발견된 에러: ${errors.length}개`);
        errors.forEach(e => console.log(`      ${e.code}: ${e.message}`));

        // 6-1. 로컬 API 스킬 호출로 힌트 수집
        console.log('   🔍 Tizen API 메타데이터 검색 중...');
        const apiHints = lookupTizenApiForHealing(errors);
        if (apiHints) {
            console.log(`   💡 API 힌트 발견! (문맥 프롬프트에 추가됨)`);
        }

        // LLM에 수정 요청
        console.log('   🧠 LLM에 코드 수정 요청 중...');
        try {
            const healPrompt = buildHealingPrompt(code, errors, apiHints);
            const response = await llm.generateCode(systemPrompt, healPrompt);
            code = extractCode(response);
            console.log(`   ✅ 수정된 코드 수신 (${code.split('\n').length}줄)`);
        } catch (e) {
            console.error(`   ❌ LLM 호출 실패: ${e.message}`);
            break;
        }

        // 수정된 코드 재주입 & 재빌드
        injectMainView(outputDir, code, appName);
        console.log('   🔨 재빌드 중...');
        buildResult = runBuild(outputDir);
    }

    // 7. 최종 결과
    console.log('\n' + '═'.repeat(50));
    if (buildResult.success) {
        console.log('🎉 빌드 성공! 앱이 생성되었습니다!');
        console.log(`📂 경로: ${outputDir}`);
        if (attempt > 0) console.log(`🏥 Self-Healing: ${attempt}회 수정 후 성공`);
    } else {
        console.log('❌ 빌드 실패. 수동 확인이 필요합니다.');
        console.log(`📂 경로: ${outputDir}`);
        console.log(`📋 빌드 로그를 확인해 주세요.`);
        process.exit(1);
    }
}

main().catch(e => {
    console.error('예기치 않은 오류:', e);
    process.exit(1);
});
