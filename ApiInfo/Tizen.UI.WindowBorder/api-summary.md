# API Summary: Tizen.UI.WindowBorder

Source: `c:\workspace\temp\Generate_TizenApp\Packages\Tizen.UI.WindowBorder.1.0.0-rc.5\lib\net8.0-tizen10.0\Tizen.UI.WindowBorder.dll`
Generated (UTC): 2026-03-07T11:20:28.7078907+00:00

## Namespace `Tizen.UI.WindowBorder`

### class `BorderView`

- Base: `Tizen.UI.ContentView`
- Interfaces: `Tizen.UI.WindowBorder.IWindowBorderProvider`
- Members:
  - `static .cctor()`
  - `.ctor()`
  - `.ctor(ViewTemplate header)`
  - `.ctor(ViewTemplate header, ViewTemplate footer)`
  - `private Void <CreateViewModel>b__56_0(WindowResizeDirection direction)`
  - `private Void <CreateViewModel>b__56_1(Boolean maximize)`
  - `private Void <CreateViewModel>b__56_2()`
  - `private Void <CreateViewModel>b__56_3()`
  - `private Void <CreateViewModel>b__56_5()`
  - `private Void <CreateViewModel>b__56_7()`
  - `private Color <OnTouchEvent>b__52_0(Task t)`
  - `private BorderView.BorderViewModel CreateViewModel()`
  - `private WindowResizeDirection DetectResizeArea(Point point)`
  - `private Void EnterOverlayBorder()`
  - `private Void ExitOverlayBorder()`
  - `public Color get_BorderActiveColor()`
  - `public Thickness get_BorderArea()`
  - `public Color get_BorderColor()`
  - `public Single get_DefaultBorderWidth()`
  - `private Color get_EffectiveBorderColor()`
  - `public Boolean get_EnableOverlayBorder()`
  - `public ViewTemplate get_FooterTemplate()`
  - `public ViewTemplate get_HeaderTemplate()`
  - `protected Window get_TargetWindow()`
  - `protected BorderView.BorderViewModel get_ViewModel()`
  - `public Void HideOverlayBorder()`
  - `protected Void Initialize()`
  - `protected Void OnTargetWindowResized()`
  - `private Void OnTouchEvent(Object sender, TouchEventArgs e)`
  - `private Void OnWindowResized(Object sender, EventArgs e)`
  - `public Void set_BorderActiveColor(Color value)`
  - `public Void set_BorderArea(Thickness value)`
  - `public Void set_BorderColor(Color value)`
  - `public Void set_DefaultBorderWidth(Single value)`
  - `public Void set_EnableOverlayBorder(Boolean value)`
  - `public Void ShowOverlayBorder()`
  - `View Tizen.UI.WindowBorder.IWindowBorderProvider.get_BorderView()`
  - `Void Tizen.UI.WindowBorder.IWindowBorderProvider.SetTargetWindow(Window window)`
  - `private Void UpdateBorderWidth()`
  - `public Color BorderActiveColor { get; set; }`
  - `public Thickness BorderArea { get; set; }`
  - `public Color BorderColor { get; set; }`
  - `public Single DefaultBorderWidth { get; set; }`
  - `private Color EffectiveBorderColor { get; }`
  - `public Boolean EnableOverlayBorder { get; set; }`
  - `public ViewTemplate FooterTemplate { get; }`
  - `public ViewTemplate HeaderTemplate { get; }`
  - `protected Window TargetWindow { get; }`
  - `View Tizen.UI.WindowBorder.IWindowBorderProvider.BorderView { get; }`
  - `protected BorderView.BorderViewModel ViewModel { get; }`

### interface `IWindowBorderProvider`

- Members:
  - `public Thickness get_BorderArea()`
  - `public View get_BorderView()`
  - `public Void SetTargetWindow(Window window)`
  - `public Thickness BorderArea { get; }`
  - `public View BorderView { get; }`

### class `WindowExtensions`

- Base: `System.Object`
- Members:
  - `static .cctor()`
  - `public static Void ClearBorderView(Window window)`
  - `public static Layer GetBorderLayer(Window window)`
  - `public static Void SetBorderView(Window window, IWindowBorderProvider provider)`

## Extension Methods

### Target `Tizen.UI.Window`

- `public static Void ClearBorderView(Window window)`
  - Declared in: `Tizen.UI.WindowBorder.WindowExtensions` (`Tizen.UI.WindowBorder`)
- `public static Layer GetBorderLayer(Window window)`
  - Declared in: `Tizen.UI.WindowBorder.WindowExtensions` (`Tizen.UI.WindowBorder`)
- `public static Void SetBorderView(Window window, IWindowBorderProvider provider)`
  - Declared in: `Tizen.UI.WindowBorder.WindowExtensions` (`Tizen.UI.WindowBorder`)

