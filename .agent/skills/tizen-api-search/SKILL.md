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
# 예시 1: Button 컨트롤의 속성/이벤트를 찾고 싶을 때 (부분 일치 검색)
node scripts/search-tizen-api.js Button

# 예시 2: 특정 네임스페이스의 정확한 클래스를 찾고 싶을 때 (예: Material 네임스페이스)
node scripts/search-tizen-api.js Material.Button

# 예시 3: 특정 속성(Property), 이벤트, 메서드 이름이 포함된 컨트롤을 찾고 싶을 때 (-m 옵션)
node scripts/search-tizen-api.js -m TextColor
node scripts/search-tizen-api.js -m IsMultiline
```

## Note on Enums
- Enum types (e.g. `LineBreakMode`) are listed in the metadata, but their specific constant values (e.g. `Wordwrap`) are NOT included in the underlying `api-index.json`. The search script will flag Enum types directly to prevent you from fruitlessly searching for their specific values in this dataset.

## Anti-Patterns
- ❌ Do NOT try to `cat` or `grep` `ApiInfo/TizenUI_ControlCatalog.md` manually to find missing properties. Use this script instead.
- ❌ Do NOT guess property names like `Margin` or `Shadow`. Verify them using this search mechanism.
