## Overview

There are 2 blur methods.

Name                 | Description
--                   | --
`Backgroun blur`      | `View`에 설정하는 속성으로, 해당 `View`의 뒤에 보이는 영역을 blur.<br/> ⚠️ 동일 윈도우 내에 존재하는 객체만 blur 됨
`Window blur`      | `Window`에 설정하는 속성으로, 윈도우 영역 만큼 뒷부분을 blur 하거나 윈도우 영역을 제외한 나머지를 blur.<br/> ⚠️ 윈도우 영역 중 일부만 지정 불가

<br/>
<br/>

## Blur Samples

### Background blur
```C#
view.SetRenderEffect(RenderEffect.CreateBackdropBlurEffect(20f /*blurRadius*/));
```
> [!WARNING]
> figma의 `BackgroundBlur`값은 radius가 아닌 diameter이므로 반으로 나눠 적용해야 함
> `RenderEffect.CreateBackdropBlurEffect(20f)`

<br/>

### Window blur

> [!WARNING]
> WIP: Need to support window blur method

The left image shows the `WindowBlurType.Background` while right one shows the `WindowBlurType.Behind`.

#### Background
```C#
var window = NUIApplication.GetDefaultWindow();
window.SetTransparency(true);
window.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f); // dim color
window.BlurInfo = new WindowBlurInfo(WindowBlurType.Background, 60 /* blurRadius */, 10 /* cornerRadius */);
```

#### Behind
```C#
var window = NUIApplication.GetDefaultWindow();
window.SetTransparency(false);
window.BlurInfo = new WindowBlurInfo(WindowBlurType.Behind, 60 /* blurRadius */);
```

<br/>