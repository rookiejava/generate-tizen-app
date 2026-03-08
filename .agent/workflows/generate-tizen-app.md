---
description: Tizen .NET UI 앱 자동 생성 및 빌드 루프
---

# 🚀 Generate Tizen App Workflow

사용자가 Tizen UI 앱 구현을 요청하면, 에이전트(호딱이)는 반드시 이 워크플로우에 따라 앱을 자동 생성하고 검증해야 합니다.

## Step 1: 요구사항 분석 및 카탈로그 조회
1. 사용자의 자연어 요구사항을 분석합니다 (예: "계산기 만들어줘", "설정 화면 만들어줘").
2. 앱의 `AppName`을 PascalCase로 결정합니다 (예: `Calculator`, `SettingsApp`).
3. 내장 지식 및 `ApiInfo/TizenUI_ControlCatalog.md`를 참고하여 어떤 `Tizen.UI` 및 `Tizen.UI.Components.Material` 컨트롤을 조합할지 설계합니다.
4. 필요한 경우 `microsoft-learn` MCP 서버나 코드 탐색 기법을 활용하여 추가 정보를 확인합니다.

## Step 2: 프로젝트 템플릿 조립
1. `Create-TizenProject.js` 스크립트를 실행하여 프로젝트 뼈대를 생성합니다.
// turbo
```powershell
node scripts/Create-TizenProject.js {AppName} output/{AppName}
```

## Step 3: `MainView.cs` 코드 생성 및 주입
1. `write_to_file` (또는 `replace_file_content`) 도구를 사용하여 `output/{AppName}/MainView.cs` 파일에 코드를 작성합니다.
2. **주의사항**:
   - `CreateContent()` 메서드가 UI 구조를 반환해야 합니다.
   - 항상 `Scaffold`를 최상위 루트로 사용합니다.
   - `ResizePolicy.FillToParent`를 적절히 활용하여 화면에 꽉 차도록 배치합니다.
   - `Window.Default.CurrentSize`는 오류를 유발할 수 있으므로 사용하지 않습니다.

## Step 4: 자동 빌드 및 검증 (Self-Healing Loop)
1. 생성된 프로젝트 폴더로 이동하여 `dotnet build`를 실행하고 결과를 확인합니다. 영문 에러를 확인하기 위해 언어를 강제합니다.
```powershell
cd output/{AppName}
$env:DOTNET_CLI_UI_LANGUAGE="en"; dotnet build 2>&1 | tee build_log.txt
```
2. **Self-Healing**:
   - 만약 에러(`error CS...`)가 발생했다면, 에러 메시지와 소스코드를 대조하여 `MainView.cs`를 수정합니다.
   - 수정 후 **다시 Step 4.1을 반복 실행**합니다. (최대 3회 재도전)
   - 3회 연속 실패 시 사용자에게 원인을 보고하고 도움을 요청합니다.

## Step 5: 완료 보고
1. 빌드가 에러 없이(`0 Error(s)`) 성공하면, 사용자에게 완료되었음을 알리고 주요 로직과 컨트롤 구조를 브리핑합니다.
