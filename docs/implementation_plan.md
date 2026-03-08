# 🚀 Tizen .NET UI 앱 자동 생성 에이전트 - 구현 계획서

[English](implementation_plan-en.md) | [한국어](implementation_plan.md) | [日本語](implementation_plan-ja.md) | [简体中文](implementation_plan-zh.md)
> **프로젝트 코드명**: generate-tizen-app
> **작성**: Tizen UI Generation Agent
> **작성일**: 2026-03-07
> **요구사항**: "자연어로 설명하면 해당하는 .NET UI 앱을 자동으로 생성하는 에이전트 개발 루프 구축"

---

## 📊 현재 확보된 자산

| 자산 | 경로 | 설명 |
|------|------|------|
| 패키지 목록 | `TizenPackageList.txt` | 12개 Tizen.UI 패키지 이름 |
| 다운로드 스크립트 | `Download-TizenPackages.ps1` | NuGet에서 패키지만 깔끔하게 다운로드 |
| 패키지 파일 | `Packages/` | 12개 `.nupkg` + DLL 원본 |
| API 메타데이터 | `ApiInfo/` | 12개 패키지의 `api-index.json` + `api-summary.md` |
| 어셈블리 인스펙터 | `dotnet-assembly-inspector` | DLL → JSON/MD 변환 도구 (MCP 서버) |

---

## 🏗️ 전체 아키텍처 (Agentic Dev Loop)

```mermaid
flowchart TD
    A["👤 사용자: 자연어 요구사항"] --> B["🧠 Step 1: 요구사항 분석"]
    B --> C["📋 Step 2: API 메타데이터 조회"]
    C --> D["💻 Step 3: C# 코드 생성 (LLM)"]
    D --> E["📁 Step 4: 프로젝트 파일 생성"]
    E --> F["🔨 Step 5: dotnet build"]
    F --> G{빌드 성공?}
    G -->|✅ 성공| H["🚀 완성! 프로젝트 전달"]
    G -->|❌ 실패| I["🏥 Step 6: 에러 피드백 → LLM"]
    I --> D
```

---

## 📝 단계별 상세 구현 계획

### Phase 1: API 지식 베이스 구축 (Knowledge Base) ✅ 완료
> **목표**: LLM이 Tizen.UI를 "아는 척"할 수 있게 만들기

#### 1-1. API 요약본 정리
- [x] 12개 패키지 DLL 다운로드 완료
- [x] `dotnet-assembly-inspector`로 `api-index.json` + `api-summary.md` 추출 완료
- [x] **핵심 컨트롤 카탈로그** 생성 (LLM 프롬프트에 주입할 경량 버전)
  - 전체 `api-summary.md`는 너무 거대 (Tizen.UI만 6600줄, Tizen.UI.Components 4200줄)
  - UI 컨트롤별 "이름 / 주요 속성 / 주요 이벤트"만 뽑은 **경량 카탈로그** 필요
  - 예: `Button → Text, TextColor, BackgroundColor, Clicked 이벤트`

#### 1-2. 컨트롤 카탈로그 자동 생성 스크립트
- [x] `api-index.json`을 파싱해서 `View`를 상속하는 클래스만 필터링
- [x] 각 클래스의 public 프로퍼티와 이벤트만 추출
- [x] 결과를 `TizenUI_ControlCatalog.json` (또는 `.md`)로 저장
- [x] 이 파일이 LLM 프롬프트의 **시스템 컨텍스트**로 들어감

---

### Phase 2: 프로젝트 템플릿 준비 ✅ 완료
> **목표**: AI가 생성한 코드를 바로 빌드할 수 있는 Tizen 프로젝트 뼈대

#### 2-1. Tizen .NET 프로젝트 템플릿 생성
- [x] `.csproj` 파일 (net8.0-tizen10.0 타겟)
- [x] `tizen-manifest.xml` (앱 매니페스트)
- [x] `MainView.cs` (AI 코드를 삽입할 Scaffold 구조의 핵심 View)
- [x] `App.cs` (엔트리 포인트 - MainView를 호출하는 MaterialApplication)
- [x] NuGet 패키지 참조 (필요한 핵심 패키지로 최적화)
- [x] 이 템플릿은 `templates/` 폴더에 보관

#### 2-2. 템플릿 변수 시스템
- [x] `{{APP_NAME}}`, `{{MAIN_VIEW_CONTENT}}` 등 플레이스홀더 정의
- [x] 플레이스홀더를 치환하여 프로젝트를 조립하는 `Create-TizenProject.js` 생성

---

### Phase 3~5: 자동 통합 에이전트 루프 (AI Workflow) ✅ 완료
> **목표**: 자연어 → C# 코드 변환 → 프로젝트 빌드 → 에러 자가 치유(Self-Healing)의 전 과정을 **Agent 워크플로우 하나로 통합 수행**

#### 3~5 통합: `.agent/workflows/generate-tizen-app.md` 작성 완료
- 에이전트 단일 파이프라인 처리를 목표로, 스크립트 기반을 넘어 AI 에이전트의 내부 워크플로우 파일로 승화
- 명령어 단일 실행(`/generate-tizen-app` 또는 프롬프트 요청)을 통해 전체 과정을 무인 환경에서 자동 수행:
  1. `ApiInfo/TizenUI_ControlCatalog.md` 내용과 내장 C# 지식 결합
  2. `Create-TizenProject.js`로 프로젝트 뼈대 생성
  3. `MainView.cs` 교체 생성 (`write_to_file`)
  4. `dotnet build` 돌려서 에러 검출시 최대 3회 재도전 (Self-Healing)

---

### Phase 6: 독립 CLI 도구 (누구나 사용 가능) ✅ 완료
> **목표**: 에이전트 인스턴스 없이도 사용자가 CLI 환경에서 Tizen 앱을 자동 생성할 수 있는 도구 구현

#### 6-1. LLM 프로바이더 추상화 (`scripts/llm-providers.js`)
- [x] 멀티 프로바이더 지원: **Gemini**(기본), OpenAI, Claude
- [x] 환경변수로 API 키 관리 (`GEMINI_API_KEY`, `OPENAI_API_KEY`, `ANTHROPIC_API_KEY`)
- [x] 공통 인터페이스: `generateCode(systemPrompt, userPrompt) → string`

#### 6-2. 시스템 프롬프트 템플릿 (`prompts/system-prompt.md`)
- [x] Tizen.UI 전문 개발자 역할 정의
- [x] 컨트롤 카탈로그 자동 삽입 (`{{CONTROL_CATALOG}}`)
- [x] 코드 출력 규칙 (Scaffold 루트, Fluent API, MaterialApplication 등)

#### 6-3. 앱 생성 CLI (`scripts/Generate-App.js`)
- [x] 사용법: `node scripts/Generate-App.js "계산기 앱" --provider gemini`
- [x] 자연어 → LLM API 호출 → C# 코드 추출 → 프로젝트 조립 → 자동 빌드
- [x] Self-Healing 내장 (빌드 에러 시 최대 3회 LLM 재호출)

---

## 🗓️ 구현 우선순위 (추천 순서)

| 순서 | Phase | 핵심 산출물 | 상태 |
|------|-------|------------|------|
| 1️⃣ | Phase 1 | 컨트롤 카탈로그 경량 JSON | ✅ 완료 |
| 2️⃣ | Phase 2 | 프로젝트 템플릿 | ✅ 완료 |
| 3️⃣ | Phase 3~5 | 에이전트 워크플로우 | ✅ 완료 |
| 4️⃣ | Phase 6 | 독립 CLI 도구 (멀티 LLM) | ✅ 완료 |

---

## ✅ 주요 아키텍처 결정사항 (2026-03-07 확정)

| 항목 | 결정 사항 |
|------|------|
| **LLM 실행 주체** | AI 에이전트 단일 파이프라인 기반 처리 |
| **운영 방식** | 워크플로우 통합 (외부 스크립트 최소화 및 CLI 병렬 운영) |
| **빌드 환경** | Tizen workload 설치 (`workload-install.ps1` 사용) |
| **코드 스타일** | C# Fluent API 기반 UI |

### Tizen Workload 설치 방법
- 참고: https://github.com/Samsung/Tizen.NET/wiki/Installing-Tizen-.NET-Workload#install-tizen-net-workload-2

**Windows:**
```powershell
Invoke-WebRequest 'https://raw.githubusercontent.com/Samsung/Tizen.NET/main/workload/scripts/workload-install.ps1' -OutFile 'workload-install.ps1';
./workload-install.ps1 [-v <version>] [-d <directory>]
```

**Linux / macOS:**
```bash
curl -sSL https://raw.githubusercontent.com/Samsung/Tizen.NET/main/workload/scripts/workload-install.sh | sudo bash
```

---

## 🔧 활용 도구 및 MCP 서버

| 도구 | 용도 | 상태 |
|------|------|------|
| `dotnet-assembly-inspector` (MCP) | DLL → API 메타데이터 추출 | ✅ 활용 완료 |
| **Microsoft Learn MCP** | .NET/C# 공식 문서 실시간 검색 (hallucination 방지) | 📌 등록 예정 |

> **Microsoft Learn MCP Server** (`https://learn.microsoft.com/api/mcp`)
> - 인증 불필요 (무료)
> - 제공 도구: `microsoft_docs_search`, `microsoft_docs_fetch`, `microsoft_code_sample_search`
> - Tizen.UI는 커버 안 되지만, C# 표준 라이브러리/패턴 질문 시 hallucination 방지에 도움

---
