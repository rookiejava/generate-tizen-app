# 🔄 How It Works: 대화형 통합 에이전트 루프 (Interactive Agent Loop)

[English](how_agent_works-en.md) | [한국어](how_agent_works.md) | [日本語](how_agent_works-ja.md) | [简体中文](how_agent_works-zh.md)
본 문서는 `generate-tizen-app` 프로젝트에서 **AI 에이전트(Gemini, Claude 등)와 협업하며 점진적으로 Tizen 앱을 만들어가는 대화형 루프**의 동작 원리와 아키텍처를 설명합니다.

단일 스크립트 실행으로 코드를 쏟아내는 CLI 모드(`how_cli_works.md`)와 달리, 에이전트 루프는 끊임없이 문맥을 유지하며 사용자의 요구사항을 유연하게 수용하고 즉각적으로 오류를 고쳐내는 "개발자 페어링(Pair Programming)" 방식입니다.

---

## 🏗️ 1. 에이전틱 개발 루프 사이클

대화형 통합 에이전트 환경(예: Cursor, VS Code AI 확장, Antigravity 등)에서 이 저장소를 작업 공간으로 열고 다음과 같은 사이클을 반복합니다.

### Step 1: 자연어 요구사항 접수 (Intent & Reasoning)
- 사용자가 "메신저 입력창이 있는 UI 만들어줘" 라고 지시합니다.
- 에이전트는 프롬프트를 분석하여 Tizen 프레임워크 내에서 어떤 구성 요소(Scaffold, Grid, TextField 등)가 필요한지 **사전 추론**합니다.

### Step 2: 도구(Tools) 및 지식 호출 (Context Gathering)
에이전트는 단순히 내장 지식으로 코드를 찍어내지 않고, 필요한 스펙을 즉시 외부로부터 조달합니다.
- **MCP 서버 연동 (`microsoft-learn`)**: Tizen 뿐 아니라 C#의 최신 .NET 8.0 구문, 혹은 외부 닷넷 라이브러리가 필요할 때 공식 레퍼런스를 직접 검색합니다.
- **로컬 스킬 호출 (`tizen-api-search`)**: Tizen UI의 `TextField` 컴포넌트가 패딩 속성을 가지는지 불분명할 경우, 작업 공간에 포함된 `scripts/search-tizen-api.js` 스크립트를 백그라운드에서 직접 실행하여 **실제 `api-index.json` 명세서를 확인**하고 환각(Hallucination) 없이 정확한 속성값을 꺼내옵니다.

### Step 3: 코드 작성 및 수정 (Execution)
- 획득한 문맥과 지식을 바탕으로 `MainView.cs` 등 핵심 코드를 작성하거나 수정합니다.
- 멀티 파일(Multi-file) 수정이 필요한 경우(예: App.cs 수정, 리소스 추가 등)에도 에이전트가 직접 파일 시스템에 접근하여 편집합니다.

### Step 4: 검증 및 자가 치유 (Verification & Self-Healing)
- 에이전트가 주도적으로 터미널 명령(`dotnet build`)을 실행하여 코드가 Tizen 10.0 / .NET 8.0 환경에서 실제 컴파일되는지 테스트합니다.
- 만약 에러(`CS1061`, `CS0246` 등)가 터지면:
  1. 에이전트가 터미널의 에러 로그를 읽고 원인을 스스로 파악합니다.
  2. "아, `Button`에는 `SetColumn`이 없었지. 다시 Tizen API 스킬을 검색해볼까?" 하고 동적으로 부족한 지식을 다시 메웁니다.
  3. 코드를 패치하고 다시 빌드하는 **Self-Healing 루프**를 에러가 없어질 때까지 반복한 후 사용자에게 완료를 보고합니다.

---

## ⚙️ 2. 왜 에이전트 루프인가? (CLI와의 차이점)

| 비교 항목 | 대화형 통합 에이전트 루프 | 독립형 CLI 도구 (`Generate-App.js`) |
| --- | --- | --- |
| **코드 생성 방식** | 다중 도구(Multi-Tool) 활용 및 점진적 개선 | 원샷(One-Shot) 기반 전체 코드 블록 생성 |
| **API 지식 활용** | 에이전트가 능동적으로 스킬 구동 & 검색어 판단 | 툴이 에러를 파싱하여 기계적으로 힌트 텍스트 주입 |
| **파일 수정 단위** | 자유로움 (UI, 로직, 리소스, 설정 파일 동시 수정 가능) | 제한적 (`MainView.cs` 교체 위주) |
| **사용 사례** | 복잡한 앱 개발, 기존 코드 리팩토링, 오류 디버깅 | 파이프라인 자동화, 빠른 템플릿/Boilerplate 추출 |

## 🛡️ 3. 확장 가능성 (Extensibility)

에이전트 루프의 가장 큰 장점은 **작업 공간(Workspace) 자체가 에이전트의 도구함**이 된다는 점입니다.
- **스킬 추가**: Tizen.UI 뿐만 아니라 `Tizen.Multimedia`, `Tizen.NUI` 등의 다른 Tizen API를 위한 검색 스킬이나 문서를 `docs/`나 `.agent/skills/` 디렉터리에 추가하기만 하면 에이전트가 즉각 이를 읽고 새로운 개발 능력을 흡수합니다.
- **MCP 연동**: 향후 Tizen 어셈블리 DLL을 직접 분석하는 커스텀 MCP(`dotnet-assembly-inspector` 등)가 붙으면 JSON 카탈로그조차 필요 없이 DLL 바이너리를 에이전트가 직접 뜯어보며 코딩하는 극한의 자동화도 지원합니다.
