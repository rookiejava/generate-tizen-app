# 🚀 generate-tizen-app

AI를 활용하여 자연어 요구사항을 바탕으로 Tizen .NET UI 애플리케이션 코드를 자동 생성하고 빌드하는 지능형 에이전트 및 CLI 환경 지원 프로젝트입니다.

## 📂 프로젝트 구조

```
generate-tizen-app/
│
├── docs/                          # 📄 문서
│   ├── implementation_plan.md     #    구현 계획서 (마스터 플랜)
│   └── how_it_works.md            #    에이전트 동작 원리 (How it works)
│
├── scripts/                       # ⚙️ 유틸리티 스크립트
│   ├── TizenPackageList.txt       #    다운로드 대상 패키지 목록
│   ├── Download-TizenPackages.ps1 #    NuGet 패키지 다운로드 (Windows)
│   └── Download-TizenPackages.sh  #    NuGet 패키지 다운로드 (Linux/macOS)
│
├── Packages/                      # 📦 다운로드된 NuGet 패키지 (12개)
│   ├── Tizen.UI.1.0.0-rc.5/
│   ├── Tizen.UI.Components.1.0.0-rc.5/
│   ├── ... (총 12개 패키지)
│   └── nuget.exe
│
├── ApiInfo/                       # 🔍 DLL에서 추출한 API 메타데이터
│   ├── Tizen.UI/
│   │   ├── api-index.json         #    컴팩트 JSON (LLM용)
│   │   └── api-summary.md         #    마크다운 요약 (사람용)
│   ├── Tizen.UI.Components/
│   ├── ... (총 12개 패키지)
│   └── Tizen.UI.WindowBorder/
│
├── templates/                     # 🧱 Tizen 프로젝트 템플릿 (Phase 2에서 구축)
│
└── README.md                      # 이 파일
```

## ✅ 사전 요구 사항 (Prerequisites)

이 프로젝트를 실행하고 Tizen 앱을 빌드하기 위해 다음 환경이 사전에 구비되어야 합니다.

1. **Node.js** 설치 (v18 이상 권장)
2. **.NET SDK 8.0 이상** 설치
3. **Tizen .NET Workload** 설치
   - 시스템에 Tizen workload가 없다면, 터미널(또는 관리자 권한 PowerShell)을 열고 운영체제에 맞는 아래 명령어를 실행하여 설치할 수 있습니다:
   ```bash
   # Windows (PowerShell)
   powershell -ExecutionPolicy Bypass -File scripts\workload-install.ps1
   
   # Linux / macOS (Bash)
   curl -sSL https://raw.githubusercontent.com/Samsung/Tizen.NET/main/workload/scripts/workload-install.sh | sudo bash
   ```

## 🚀 주요 사용 방식 (Usage)

이 프로젝트는 사용자의 목적과 환경에 맞춰 **두 가지 강력한 방식**으로 Tizen 앱을 생성할 수 있도록 지원합니다.

### 1. 🤖 대화형 통합 에이전트 루프 (Interactive Agent Loop)
AI 에이전트(Gemini 등)와 대화하며 점진적으로 앱을 설계하고 완성해 나가는 방식입니다.

#### 아키텍처 및 동작 원리
이 작업 방식은 단순한 코드 생성을 넘어, 환각(Hallucination) 없는 코드를 작성하기 위해 다양한 도구와 상호작용합니다.

```mermaid
graph TD
    User([👨‍💻 사용자]) --> |1. 자연어 명령<br/>(예: '메신저 UI 만들어줘')| Agent[🤖 AI 에이전트<br/>(Gemini/Claude)]
    
    subgraph Agentic_Dev_Loop [🔄 에이전틱 개발 루프]
        Agent --> |2. API 문서/샘플 검색| MCP_Learn[[📚 MCP 서버<br/>(Microsoft Learn)]]
        MCP_Learn -.-> |공식 레퍼런스 반환| Agent
        
        Agent --> |3. Tizen 클래스, 속성 검색| Local_Skill[[🛠️ 로컬 스킬<br/>(tizen-api-search)]]
        Local_Skill -.-> |정확한 속성/이벤트 반환| Agent
        
        Agent --> |4. 코드 작성/수정| FileSystem[(📁 로컬 파일 시스템)]
        
        Agent --> |5. Tizen 앱 빌드/테스트| Terminal[▶️ 터미널<br/>(dotnet build)]
        Terminal -.-> |6. 에러 발생 시 로그 분석<br/>(Self-Healing)| Agent
    end
    
    FileSystem -.-> |7. 최종 결과물 제공| User
```

- **특징**:
  - `MCP 서버` (Tizen 어셈블리 검사, Microsoft Learn 문서 연동) 및 `로컬 스킬` 등을 에이전트가 직접 호출하며 코드를 깎아냅니다.
  - 빌드 에러가 발생하면 에이전트 스스로 원인을 분석하고 코드를 수정하는 **자가 치유(Self-Healing)** 과정을 거칩니다.
  - 복잡한 UI/UX 설계나 단계적인 기능 추가 등 딥워크(Deep Work)에 적합합니다.
- **사용법**: AI 에이전트 환경(예: Cursor, VS Code AI 확장, Antigravity 등)에서 이 작업 공간을 열고 자연어로 지시를 내리면 즉시 동작합니다.

### 2. 💻 독립형 CLI 도구 (Standalone CLI Generator)
에이전트 환경 없이 터미널에서 스크립트를 단 한 줄 실행하여 초기 상용구(Boilerplate) 코드를 즉시 뽑아내는 원샷(One-Shot) 방식입니다.
- **특징**:
  - 자동화 스크립트나 CI/CD 파이프라인에 부품처럼 끼워 넣어 사용하기 좋습니다.
  - LLM 공급자(Gemini, OpenAI, Claude)를 상황에 맞게 자유롭게 교체할 수 있어 범용성이 뛰어납니다.
  - 세밀한 디버깅보다는, 빠르게 초기 프로젝트 외형을 만들거나 템플릿을 생성할 때 가장 효과적입니다.
- **사용법**:
  ```bash
  # 환경변수에 API 키 설정 (택 1)
  export GEMINI_API_KEY="your-key"       # Gemini (기본)
  export OPENAI_API_KEY="your-key"       # OpenAI
  export ANTHROPIC_API_KEY="your-key"    # Claude

  # 앱 생성
  node scripts/Generate-App.js "계산기 앱 생성"
  node scripts/Generate-App.js "동영상 플레이어 초기 설정 화면" --provider openai
  node scripts/Generate-App.js "할일 목록 앱" --provider claude --name TodoApp
  ```

## 🛠️ 기타 사용법

### 패키지 다운로드

**Windows (PowerShell)**
```powershell
.\scripts\Download-TizenPackages.ps1 -DestinationPath ".\Packages"
```

**Linux / macOS (Bash)**
```bash
chmod +x ./scripts/Download-TizenPackages.sh
./scripts/Download-TizenPackages.sh ./Packages
```

## 📋 Tizen.UI 패키지 목록 (12개)

| # | 패키지 | 설명 |
|---|--------|------|
| 1 | Tizen.UI | 코어 UI 프레임워크 (View, Window, Color 등) |
| 2 | Tizen.UI.Layouts | 레이아웃 시스템 (HStack, VStack, Grid, FlexBox 등) |
| 3 | Tizen.UI.Components | UI 컴포넌트 (Button, Slider, Navigation 등) |
| 4 | Tizen.UI.Components.Material | Material Design 컴포넌트 |
| 5 | Tizen.UI.Primitives2D | 2D 기본 도형 |
| 6 | Tizen.UI.Scene3D | 3D 씬 렌더링 |
| 7 | Tizen.UI.Visuals | 비주얼 이펙트 |
| 8 | Tizen.UI.Skia | SkiaSharp 기반 렌더링 |
| 9 | Tizen.UI.Tools | 개발 도구 |
| 10 | Tizen.UI.Widget | 위젯 지원 |
| 11 | Tizen.UI.WindowBorder | 윈도우 보더 커스터마이징 |
| 12 | Tizen.UI.Markdown | 마크다운 렌더링 |
