# 🧠 How It Works: Standalone CLI Generator

[English](how_cli_works-en.md) | [한국어](how_cli_works.md) | [日本語](how_cli_works-ja.md) | [简体中文](how_cli_works-zh.md)

This document explains the principles of the **Standalone CLI Tool (`scripts/Generate-App.js`)** provided in the `generate-tizen-app` project, which utilizes a Large Language Model (LLM) to convert natural language requirements into fully compilable Tizen C# app code.

*(For the principles of interaction in the agent environment, see `how_agent_works.md`.)*

---

## 🏗️ 1. Knowledge Structure of the Agent (Hybrid Knowledge Integration)

When generating app code, the agent (LLM) primarily integrates two distinct knowledge sources.

### A. Tizen.UI Specific Knowledge (Injected Up-to-Date Knowledge)
- **Target**: Tizen's latest open-source UI framework (e.g., `Tizen.UI`, `Tizen.UI.Components.Material`)
- **Source**: `ApiInfo/TizenUI_ControlCatalog.json` (Metadata automatically extracted from DLLs in Phase 1)
- **Mechanism**: The CLI injects the markdown-converted catalog (`TizenUI_ControlCatalog.md`) as the **context** during prompt generation all at once.
- **Effect**: Even if the framework is updated, by re-extracting the metadata via the script (`Generate-ControlCatalog.js`) and feeding it to the LLM, the tool **always generates the latest UI components (`View`, `Button`, `VideoOverlayView`, etc.) with accurate names and properties without hallucination**.

### B. Tizen.FX and General C# Knowledge (Pre-trained Internal Knowledge)
- **Target**: **System core functionalities (Tizen.FX)** such as video playback (`Tizen.Multimedia`), sensors, network, Bluetooth, and C# syntax.
- **Source**: The "Pre-trained Knowledge" that the LLM has already learned from vast codebases across the world.
- **Mechanism**: When the LLM receives a request like "Create a video player app," it preferentially constructs the previously learned `Tizen.Multimedia.Player` class and the video load/play sequence (`PrepareAsync()`, `Start()`). Even if this content is not in the catalog, the LLM integrates it using its advanced reasoning capabilities.
- **Effect**: You don't need to put all Tizen system APIs into the catalog. **The LLM's powerful background knowledge automatically compensates for non-UI functionalities.**

---

## 🛠️ 2. Overall Code Generation Pipeline

Example Input: "Create a video player app"

1. **Knowledge Integration**:
   The LLM selects UI elements for screen layout (`Scaffold`, `VStack`, `VideoOverlayView`, `Material.Button`) from the provided `TizenUI_ControlCatalog`, and integrates C# code that calls Media APIs (`Tizen.Multimedia.Player`) using its internal knowledge.
2. **Code Generation (Replacing `MainView.cs`)**:
   Keeping the entry point (`App.cs`) of the base project template fixed, the tool dynamically generates and replaces only the inside of the `CreateContent()` method of the `MainView.cs` class, which handles the main screen and logic.
3. **Project Assembly (`Create-TizenProject.js`)**:
   Assembles the generated `MainView.cs` and other Tizen project file structures (`.csproj`, `tizen-manifest.xml`) into the `output/{AppName}` path.
4. **Build (`dotnet build`)**:
   Issues the build command in the folder to extract it into an executable Tizen application (`.tpk` or .NET library).

---

## 🛡️ 3. Potential Risks and the Self-Healing Mechanism

The LLM's internal knowledge (like Tizen.FX) cannot be 100% trusted. Platform versions may have been updated, old parameters may have changed, or the LLM might have gotten confused by the injected catalog and used incorrect properties. The **Self-Healing Loop** is utilized to overcome this.

1. A **compilation error** is detected during the `dotnet build` phase.
2. Parsing the error log (`CS0117: Missing property`, `CS1061: Missing method`, `CS0246: Missing class/namespace`, etc.).
3. **Automatic invocation of local API skill (Dynamic injection of API hints)**
   - Extracts the problematic component name (e.g., `Button`) or property name (e.g., `SetColumn`) from the parsed error.
   - The CLI tool runs the `scripts/search-tizen-api.js` script in the background, searching the actual API specification from the raw `api-index.json` data to prepare hints.
4. Feeding this log and the **"Dynamically extracted API hints"** back to the LLM along with the original generated `MainView.cs` code.
5. The LLM recognizes the part that caused the error based on its previous version knowledge and **self-corrects and rebuilds** the code based on the accurate API hints provided (Repetitive retries up to a maximum).

This synergy of **[Latest UI Catalog (Prompt)] + [Base Engine (Internal Knowledge)] + [Build/Error Analysis (API Skill Healing)]** results in a perfectly functioning Tizen app born from a single line of natural language, all without manual intervention in the terminal.
