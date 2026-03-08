# 🔄 How It Works: 交互式集成代理循环 (Interactive Agent Loop)

[English](how_agent_works-en.md) | [한국어](how_agent_works.md) | [日本語](how_agent_works-ja.md) | [简体中文](how_agent_works-zh.md)

本文档说明在 `generate-tizen-app` 项目中，**与AI代理（Gemini、Claude等）协同合作、逐步构建Tizen应用的交互式循环**的工作原理和架构。

与通过执行单个脚本生成代码的CLI模式（`how_cli_works.md`）不同，代理循环是一种“结对编程（Pair Programming）”方式，它不断维持上下文，灵活满足用户需求，并能即时修复错误。

---

## 🏗️ 1. 代理开发循环周期

在交互式的集成代理环境（如 Cursor、VS Code AI扩展、Antigravity 等）中将此仓库作为工作区打开，并重复以下循环：

### Step 1: 接收自然语言需求 (Intent & Reasoning)
- 用户下达指令，例如“制作一个带有聊天输入框的UI”。
- 代理会分析提示词，并**预先推断**在Tizen框架中需要哪些组件（Scaffold, Grid, TextField等）。

### Step 2: 调用工具和知识 (Context Gathering)
代理不会仅仅依靠内置知识直接生成代码，它会立即从外部获取必需的规格说明。
- **MCP服务器联动 (`microsoft-learn`)**: 当除了Tizen以外，还需要C#的最新 .NET 8.0 语法或外部 .NET 库时，代理直接检索官方参考。
- **调用本地技能 (`tizen-api-search`)**: 若不确定Tizen UI的 `TextField` 组件是否具有内边距（Padding）属性，代理会在后台直接执行工作区中的 `scripts/search-tizen-api.js`，确认**真实的 `api-index.json` 规格**，准确无误地提取属性值，避免出现幻觉（Hallucination）。

### Step 3: 代码编写与修改 (Execution)
- 基于获取的上下文和知识，编写或修改核心代码，如 `MainView.cs`。
- 即使需要跨文件修改（例如修改 `App.cs` 或添加资源），代理也能直接访问并编辑文件系统。

### Step 4: 验证与自我修复 (Verification & Self-Healing)
- 代理主动执行终端命令（`dotnet build`），测试代码是否能在 Tizen 10.0 / .NET 8.0 环境中实际编译通过。
- 若发生错误（如 `CS1061`, `CS0246` 等）：
  1. 代理读取终端的错误日志，自行找出原因。
  2. 代理会推演：“啊，`Button` 并没有 `SetColumn`。再搜一下 Tizen API 技能吧。” 从而动态弥补知识空缺。
  3. 代理修复代码并再次构建，如此反复执行 **Self-Healing 循环** 直至消灭所有错误，最后向用户报告完成。

---

## ⚙️ 2. 为什么选择代理循环？ (与CLI的区别)

| 比较项目 | 交互式集成代理循环 | 独立CLI工具 (`Generate-App.js`) |
| --- | --- | --- |
| **代码生成方式** | 利用多种工具逐步改进 | 基于One-Shot生成整个代码块 |
| **API知识的利用** | 代理主动驱动技能与决定搜索词 | 工具通过解析错误机械地注入提示 |
| **文件修改粒度** | 自由度高（可同时修改UI、逻辑与资源） | 受到限制（主要集中在替换 `MainView.cs`） |
| **应用场景** | 复杂应用开发、代码重构、排错调试 | 自动化流水线、快速提取样板(Boilerplate) |

## 🛡️ 3. 扩展性 (Extensibility)

代理循环最大的优势在于：**工作区(Workspace)本身就是代理的工具箱**。
- **添加技能**：只要将其他Tizen API（例如 `Tizen.Multimedia`, `Tizen.NUI`）相关的搜索技能或文档放进 `docs/` 或 `.agent/skills/` 目录，代理就能立即读取并吸收新的开发能力。
- **MCP联动**：未来如果引入了直接解析Tizen程序集DLL的自定义MCP（例如 `dotnet-assembly-inspector`），甚至无需JSON目录，代理也能直接拆解DLL二进制内容编写代码，达成最极致的自动化。
