# 🧠 How It Works: 独立CLI生成器 (Standalone Generator) 工作原理

[English](how_cli_works-en.md) | [한국어](how_cli_works.md) | [日本語](how_cli_works-ja.md) | [简体中文](how_cli_works-zh.md)

本文档说明 `generate-tizen-app` 项目中提供的 **独立CLI工具 (`scripts/Generate-App.js`)** 是如何利用大型语言模型(LLM)，将自然语言需求转化为能够完美编译为Tizen C#应用程序代码的。

*(想了解在代理环境下的交互原理，请参考 `how_agent_works.md`。)*

---

## 🏗️ 1. 代理的知识结构 (知识的混合结合)

在生成应用程序代码时，代理(LLM)主要结合两种不同的知识来源来编写代码。

### A. Tizen.UI 专用知识 (注入的最新知识)
- **对象**: Tizen 最新开源的UI框架（如 `Tizen.UI`, `Tizen.UI.Components.Material` 等）
- **来源**: `ApiInfo/TizenUI_ControlCatalog.json` (Phase 1 中从DLL包内自动提取的元数据)
- **工作机制**: CLI在生成提示(Prompt)时，将Markdown格式的目录 (`TizenUI_ControlCatalog.md`) 信息一次性注入作为 **上下文**。
- **效果**: 即便框架进行了更新，只要通过脚本 (`Generate-ControlCatalog.js`) 重新提取元数据喂给LLM，**始终能够做到以零幻觉 (Hallucination) 的精确名称和属性生成最新UI组件 (`View`, `Button`, `VideoOverlayView` 等)**。

### B. Tizen.FX 及 C# 通用知识 (预训练内置知识)
- **对象**: 视频播放 (`Tizen.Multimedia`)、传感器、网络、蓝牙等 **系统核心功能 (Tizen.FX)** 以及 C# 语法。
- **来源**: 大型语言模型(LLM)自身已经通过全世界海量代码库学习到的“预训练数据(Pre-trained Knowledge)”。
- **工作机制**: 当LLM收到诸如“生成一个视频播放应用”的请求时，它会优先构造其已学过的 `Tizen.Multimedia.Player` 类以及视频加载/播放序列（如 `PrepareAsync()`, `Start()`）。即使目录中没有这部分内容，LLM也可凭借其强大的推理能力将其结合在一起。
- **效果**: 目录中无需包含所有 Tizen 系统 API，**UI 外的功能均由 LLM 强大的背景知识进行自动补充**。

---

## 🛠️ 2. 全套代码生成流水线

输入示例：“生成视频播放器应用”

1. **知识融合**:
   LLM 从注入的 `TizenUI_ControlCatalog` 挑选出用于画面布局的界面元素 (`Scaffold`, `VStack`, `VideoOverlayView`, `Material.Button`)，接着结合内部知识编写调用多媒体API (`Tizen.Multimedia.Player`) 的C#代码结构。
2. **生成代码 (替换 `MainView.cs`)**:
   在保留项目基础模板入口 (`App.cs`) 不变的前提下，仅**动态生成 / 替换**负责主界面与逻辑的 `MainView.cs` 类中 `CreateContent()` 方法内的代码。
3. **拼装项目 (`Create-TizenProject.js`)**:
   将生成的 `MainView.cs` 及其它构成Tizen项目文件结构的必要文件（`.csproj`, `tizen-manifest.xml`）拼装至 `output/{AppName}` 目录。
4. **编译构建 (`dotnet build`)**:
   在该目录内执行构建命令，提取出可运行的Tizen应用程序（`.tpk` 或 .NET 库）。

---

## 🛡️ 3. 潜在的风险与自我修复 (Self-Healing) 机制

LLM 内部自带的知识 (如 Tizen.FX) 不能受到 100% 信任。因为平台版本更新可能会导致之前的参数发生变更，或者注入目录的内容使 LLM 产生混淆、乱用属性。为了克服此现象，工具利用了 **Self-Healing(自我修复) 循环**。

1. 在执行 `dotnet build` 步骤时检测到 **编译错误**。
2. 解析错误日志（如 `CS0117: 没有属性`, `CS1061: 没有方法`, `CS0246: 没有类/命名空间` 等）。
3. **自动调用本地 API 技能 (动态注入 API 提示)**
   - 从解析到的错误中提取出出问题的组件名（例如：`Button`）或属性名（例如：`SetColumn`）。
   - CLI 工具在后台自动调用 `node scripts/search-tizen-api.js` 脚本，从原始 `api-index.json` 数据中翻找实际 API 规范，从而备好提示。
4. 将该日志与 **“动态获取到的 API 提示”** 连同原始生成的 `MainView.cs` 代码一起，**再次反馈给 LLM** 进行处理。
5. LLM 根据新提供的准确 API 提示，意识到先前的版本知识导致了该错误，于是代码会被 **自我纠正并再次执行编译** (最多反复重试设定次数)。

这种 **[最新UI目录 (提示)] + [基础引擎 (内置知识)] + [构建/错误分析 (利用API技能治愈)]** 的三合一协同作用，使得用户哪怕不再介入终端页面操作，仅通过一行简单的自然语言描述也足以诞生出一款能够完美运行的 Tizen 应用。
