# 🚀 Generate_TizenApp

AI를 활용하여 자연어 요구사항을 바탕으로 Tizen .NET UI 애플리케이션 코드를 자동 생성하고 빌드하는 지능형 에이전트 및 CLI 환경 지원 프로젝트입니다.

## 📂 프로젝트 구조

```
Generate_TizenApp/
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

1. **.NET SDK 8.0 이상** 설치
2. **Tizen .NET Workload** 설치
   - 시스템에 Tizen workload가 없다면, 터미널(또는 관리자 권한 PowerShell)을 열고 아래 명령어를 실행하여 설치할 수 있습니다:
   ```bash
   # Windows (PowerShell)
   powershell -ExecutionPolicy Bypass -File scripts\workload-install.ps1
   
   # Linux / macOS (또는 일반 커맨드라인)
   dotnet workload install tizen
   ```

## � 앱 자동 생성 (CLI)

자연어 명령어를 입력하면 에이전트가 Tizen .NET UI 애플리케이션 코드를 자동으로 생성하고 빌드합니다.

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

## �🛠️ 기타 사용법

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
