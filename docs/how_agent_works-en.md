# 🔄 How It Works: Interactive Agent Loop

[English](how_agent_works-en.md) | [한국어](how_agent_works.md) | [日本語](how_agent_works-ja.md) | [简体中文](how_agent_works-zh.md)

This document explains the working principles and architecture of the **Interactive Agent Loop**, where an AI agent (e.g., Gemini, Claude) collaborates with the user to gradually build Tizen apps within the `generate-tizen-app` project.

Unlike the CLI mode (`how_cli_works.md`), which outputs code in a single script execution, the agent loop is a "Pair Programming" method that continuously maintains context, flexibly accommodates user requirements, and fixes errors on the fly.

---

## 🏗️ 1. Agentic Development Loop Cycle

Open this repository as a workspace in an interactive integrated agent environment (e.g., Cursor, VS Code AI Extension, Antigravity) and repeat the following cycle:

### Step 1: Natural Language Requirement Intake (Intent & Reasoning)
- The user issues a command, like "Create a UI with a messenger input field."
- The agent analyzes the prompt and **pre-infers** which components (Scaffold, Grid, TextField, etc.) are needed within the Tizen framework.

### Step 2: Tool and Knowledge Invocation (Context Gathering)
The agent does not simply generate code based on its internal knowledge; it immediately procures necessary specifications from external sources.
- **MCP Server Integration (`microsoft-learn`)**: Retrieves official documentation directly when the latest .NET 8.0 syntax or external .NET libraries are needed.
- **Local Skill Invocation (`tizen-api-search`)**: If it's unclear whether the Tizen UI `TextField` component has a padding property, it runs the `scripts/search-tizen-api.js` script in the background to **check the actual `api-index.json` specification**, extracting accurate property values without hallucination.

### Step 3: Code Writing and Modification (Execution)
- Based on the acquired context and knowledge, it writes or modifies core code such as `MainView.cs`.
- Even when multi-file modifications are needed (e.g., modifying `App.cs` or adding resources), the agent directly accesses and edits the file system.

### Step 4: Verification and Self-Healing
- The agent proactively runs terminal commands (`dotnet build`) to test if the code actually compiles in the Tizen 10.0 / .NET 8.0 environment.
- If an error (`CS1061`, `CS0246`, etc.) occurs:
  1. The agent reads the error log from the terminal and identifies the cause.
  2. "Ah, `Button` didn't have `SetColumn`. Let me search the Tizen API skill again." It dynamically fills in the missing knowledge.
  3. It applies a **Self-Healing Loop**—patching the code and rebuilding—repeating this until the error is resolved, then reports completion to the user.

---

## ⚙️ 2. Why the Agent Loop? (Differences from CLI)

| Comparison Item | Interactive Agent Loop | Standalone CLI Tool (`Generate-App.js`) |
| --- | --- | --- |
| **Code Generation** | Utilizes Multi-Tool and gradual improvements | One-Shot based full code block generation |
| **API Knowledge Use** | Agent actively runs skills & chooses search terms | Tool parses errors and mechanically injects hints |
| **File Modification** | Flexible (can modify UI, logic, resources, settings simultaneously) | Limited (mainly replaces `MainView.cs`) |
| **Use Cases** | Complex app dev, refactoring existing code, error debugging | Pipeline automation, fast template/boilerplate extraction |

## 🛡️ 3. Extensibility

The greatest advantage of the agent loop is that the **Workspace itself becomes the agent's toolbox**.
- **Adding Skills**: Simply adding documentation or search skills for other Tizen APIs (like `Tizen.Multimedia`, `Tizen.NUI`) to the `docs/` or `.agent/skills/` directories allows the agent to read them and absorb new development capabilities instantly.
- **MCP Integration**: In the future, with a custom MCP (like `dotnet-assembly-inspector`) directly analyzing Tizen assembly DLLs, it will support extreme automation where the agent directly inspects DLL binaries and codes without needing JSON catalogs.
