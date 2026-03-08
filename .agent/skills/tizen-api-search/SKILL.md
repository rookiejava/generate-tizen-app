---
name: tizen-api-search
description: "Search and retrieve specific Tizen UI class properties, events, and inheritance details directly from local JSON metadata. Use this skill when you need to heal build errors or inspect API definitions like Margin, Padding, etc., without getting hallucinated code."
---

# Tizen API Search

This skill helps you search the true Tizen UI API specifications (extracted to `api-index.json` files) directly without having to grep through massive output or guess properties.

## When to use
- You encounter a `build error` stating "X does not contain a definition for Y" (e.g., `CS0117`).
- You need to know if a specific `Tizen.UI` or `Tizen.UI.Components` UI element supports a property, like `Padding`, `Margin`, `CornerRadius`, or `Shadow`.
- You want to see accurate class inheritance to understand supported base properties.

## How to use

Run the provided Node.js script located in the `generate-tizen-app` project.

```powershell
# 예시: Button 컨트롤의 속성/이벤트를 찾고 싶을 때
node scripts/search-tizen-api.js Button

# 예시: HStack 패딩 속성을 재확인하고 싶을 때
node scripts/search-tizen-api.js HStack
```

## Anti-Patterns
- ❌ Do NOT try to `cat` or `grep` `ApiInfo/TizenUI_ControlCatalog.md` manually to find missing properties. Use this script instead.
- ❌ Do NOT guess property names like `Margin` or `Shadow`. Verify them using this search mechanism.
