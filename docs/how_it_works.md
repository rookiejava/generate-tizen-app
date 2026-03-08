# 🧠 How It Works: Tizen UI 앱 자동 생성 에이전트 동작 원리

본 문서는 `Generate_TizenApp` 프로젝트에서 대형 언어 모델(LLM) 기반의 에이전트가 어떻게 자연어 요구사항을 실제 Tizen C#앱으로 완벽하게 컴파일되는 코드로 변환해 내는지에 대한 원리를 설명합니다.

---

## 🏗️ 1. 에이전트의 지식 구조 (지식의 하이브리드 결합)

앱 코드를 생성할 때, 에이전트(LLM)는 크게 두 가지 서로 다른 지식 출처를 결합하여 코드를 작성합니다.

### A. Tizen.UI 전용 지식 (주입된 최신 지식)
- **대상**: Tizen의 최신 오픈소스 UI 프레임워크 (`Tizen.UI`, `Tizen.UI.Components.Material` 등)
- **출처**: `ApiInfo/TizenUI_ControlCatalog.json` (Phase 1에서 DLL로부터 자동 추출된 메타데이터)
- **동작 방식**: LLM은 내장된 사전 지식 중에 흩어져 있거나 부정확할 수 있는 "최신 객체 체계/이벤트/속성"을, 프롬프트의 **컨텍스트**로 주입받은 `TizenUI_ControlCatalog.json`(경량화된 카탈로그)을 통해 실시간으로 파악합니다.
- **효과**: 프레임워크가 업데이트되더라도, 스크립트(`Generate-ControlCatalog.js`)를 통해 메타데이터를 다시 추출하고 LLM에 먹여주면 **항상 최신의 UI 컴포넌트 (`View`, `Button`, `VideoOverlayView` 등)를 한 치의 오차(Hallucination) 없이 정확한 이름과 프로퍼티로 생성**합니다.

### B. Tizen.FX 및 C# 일반 지식 (사전 학습된 내장 지식)
- **대상**: 비디오 재생(`Tizen.Multimedia`), 센서, 네트워크, Bluetooth 등 **시스템 코어 기능 (Tizen.FX)** 및 C# 언어 문법.
- **출처**: 대형 언어 모델(LLM) 자체가 이미 세상의 방대한 코드 베이스를 통해 학습 완료한 "사전 학습 데이터(Pre-trained Knowledge)".
- **동작 방식**: LLM은 "비디오를 재생해라"라는 주문을 받으면, 자신이 예전부터 알고 있던 `Tizen.Multimedia.Player` 클래스와 동영상 로드/재생 시퀀스(`PrepareAsync()`, `Start()`)를 꺼내옵니다. 카탈로그에 해당 내용이 없더라도 LLM의 추론 능력으로 이를 결합해냅니다.
- **효과**: 카탈로그에 모든 Tizen 시스템 API를 담지 않아도(모두 담으면 문맥 길이가 너무 길어져 비용/속도/정확도 면에서 심각한 손해 발생), **UI 외의 기능들은 LLM의 강력한 배경 지식이 자동으로 채워줍니다.**

---

## 🛠️ 2. 전체 코드 생성 파이프라인

명령어: "동영상 플레이어 앱 만들어줘"

1. **지식 결합**:
   LLM은 입력받은 `TizenUI_ControlCatalog`에서 화면 배치용 UI 요소(`Scaffold`, `VStack`, `VideoOverlayView`, `Material.Button`)를 선택한 뒤, 내부 지식으로 Media API(`Tizen.Multimedia.Player`)를 호출하는 C# 코드를 통합 설계합니다.
2. **코드 생성 (`MainView.cs` 교체)**:
   기본 프로젝트 뼈대인 템플릿의 진입점(`App.cs`)은 고정해 둔 채, 메인 화면과 로직을 담당하는 `MainView.cs` 클래스의 `CreateContent()` 메서드 내부만 동적으로 생성/교체합니다. (Fluent API 기반 UI)
3. **프로젝트 조립 (`Create-TizenProject.js`)**:
   생성된 `MainView.cs`와 기타 Tizen 프로젝트 파일 구조(`.csproj`, `tizen-manifest.xml`)를 `output/앱이름` 경로로 조립해 줍니다.
4. **빌드 (`dotnet build`)**:
   해당 폴더에서 빌드 명령을 내려서 실행 가능한 Tizen 애플리케이션(`.tpk` 또는 .NET 라이브러리)으로 추출합니다.

---

## 🛡️ 3. 발생 가능한 위험과 Self-Healing (Phase 5)

하지만, LLM의 내장 지식(Tizen.FX 등)을 100% 신뢰할 수는 없습니다. 플랫폼 버전이 업데이트되어 이전 메서드(`Start()` -> `Play()`)가 Deprecated 되거나 파라미터가 변했을 수 있습니다. 이를 극복하는 것이 차후 도입될 **Self-Healing 루프**입니다.

1. `dotnet build` 수행 단계에서 **컴파일 에러**가 검출됨.
2. 에러 로그(`CS1061: 'Player' does not contain a definition for...`)를 파싱.
3. 이 로그를 원본 생성된 `MainView.cs` 코드와 함께 **다시 LLM에게 피드백** 처리.
4. LLM이 "과거 지식이 틀렸구나, 다른 방식(또는 Microsoft Learn MCP를 활용한 최신 공식 문서 실시간 서치)으로 우회하자"라고 판단하여 코드를 **스스로 수정 및 재빌드**합니다. (최대 3회 반복)

이러한 **[최신 UI 카탈로그(프롬프트)] + [기본 엔진(내장지식)] + [빌드/에러 피드백(Self-Healing)]** 의 3박자가 맞물려, 자연어 한 줄로 완전하게 동작하는 Tizen 앱이 탄생하게 됩니다.
