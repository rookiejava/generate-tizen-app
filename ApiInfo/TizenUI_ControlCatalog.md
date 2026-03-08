# Tizen.UI Control Catalog (Lightweight)

> 자동 생성됨: 2026-03-07T13:35:19.564Z
> 총 157개 UI 컨트롤

---

## 📦 Tizen.UI

### `Tizen.UI.Animation`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (6개):
  - `public Single CurrentProgress { get; }`
  - `public Int32 Duration { get; set; }`
  - `public AnimationEndAction EndAction { get; set; }`
  - `public Boolean IsLoop { get; set; }`
  - `public Single ProgressReachedTarget { get; set; }`
  - `public AnimationState State { get; }`
- **이벤트** (2개):
  - `public event EventHandler Finished`
  - `public event EventHandler ProgressReached`

### `Tizen.UI.FocusManager`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public FocusManager Instance { get; }`
- **이벤트** (1개):
  - `public event EventHandler<FocusChangedEventArgs> FocusChanged`

### `Tizen.UI.FontClient`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public FontClient Instance { get; }`

### `Tizen.UI.Gesture`
- **상속**: `Tizen.UI.NObject`
- **프로퍼티** (4개):
  - `public GestureSource Source { get; }`
  - `public GestureSourceData SourceData { get; }`
  - `public GestureState State { get; }`
  - `public UInt32 Time { get; }`

### `Tizen.UI.HoverEvent`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public Int32 Count { get; }`
  - `public Hover Item { get; }`
  - `public UInt32 Time { get; }`

### `Tizen.UI.ImageView`
- **상속**: `Tizen.UI.View`
- **인터페이스**: `Tizen.UI.IImage`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (13개):
  - `public String AlphaMaskUrl { get; set; }`
  - `public Thickness Border { get; set; }`
  - `public Boolean CropToMask { get; set; }`
  - `public FittingMode FittingMode { get; set; }`
  - `public Boolean ImageLoadWithViewSize { get; set; }`
  - `public Color ImageMultipliedColor { get; set; }`
  - `public Boolean IsNinePatchImage { get; set; }`
  - `public Boolean IsResourceReady { get; }`
  - `public String LoadingPlaceholderUrl { get; set; }`
  - `public ImageLoadingStatus LoadingStatus { get; }`
  - `public Boolean PreMultipliedAlpha { get; set; }`
  - `public String ResourceUrl { get; set; }`
  - `public Boolean SynchronousLoading { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler ResourcesLoaded`

### `Tizen.UI.InputMethodContext`
- **상속**: `Tizen.UI.NObject`
- **프로퍼티** (3개):
  - `public Rect InputMethodArea { get; }`
  - `public InputPanelState InputPanelState { get; }`
  - `public Boolean TextPrediction { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler InputPanelStateChanged`
  - `public event EventHandler Resized`

### `Tizen.UI.InputView`
- **상속**: `Tizen.UI.View`
- **인터페이스**: `Tizen.UI.IFontSizeScale`, `Tizen.UI.IText`, `Tizen.UI.ITextAlignment`, `Tizen.UI.ITextEditable`, `Tizen.UI.ITextPadding`
- **프로퍼티** (17개):
  - `public Int32 CursorWidth { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public TextAlignment HorizontalAlignment { get; set; }`
  - `public InputMethodContext InputMethodContext { get; }`
  - `public Boolean IsMarkupEnabled { get; set; }`
  - `public Boolean IsReadOnly { get; set; }`
  - `public Int32 MaxLength { get; set; }`
  - `public String PlaceholderText { get; set; }`
  - `public Color PlaceholderTextColor { get; set; }`
  - `public Color PrimaryCursorColor { get; set; }`
  - `public Int32 PrimaryCursorPosition { get; set; }`
  - `public Single ScaledFontSize { get; }`
  - `public Boolean SystemFontScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextAlignment VerticalAlignment { get; set; }`
- **이벤트** (3개):
  - `public event EventHandler<AnchorClickedEventArgs> AnchorClicked`
  - `public event EventHandler MaxLengthReached`
  - `public event EventHandler TextChanged`

### `Tizen.UI.KeyEvent`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (12개):
  - `public KeyDeviceClass DeviceClass { get; }`
  - `public String DeviceName { get; }`
  - `public KeyDeviceSubClass DeviceSubClass { get; }`
  - `public Boolean IsAltModifier { get; }`
  - `public Boolean IsCtrlModifier { get; }`
  - `public Boolean IsShiftModifier { get; }`
  - `public Int32 KeyCode { get; set; }`
  - `public Int32 KeyModifier { get; set; }`
  - `public String KeyPressedName { get; set; }`
  - `public String LogicalKey { get; }`
  - `public KeyState State { get; set; }`
  - `public UInt32 Time { get; set; }`

### `Tizen.UI.Layer`
- **상속**: `Tizen.UI.NObject`
- **인터페이스**: `Tizen.UI.IParentObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (9개):
  - `public IList<View> Children { get; }`
  - `public Int32 Count { get; }`
  - `public ResizePolicy HeightResizePolicy { get; set; }`
  - `public Boolean InheritLayoutDirection { get; set; }`
  - `public Boolean IsVisible { get; set; }`
  - `public View Item { get; set; }`
  - `public LayoutDirection LayoutDirection { get; set; }`
  - `public String Name { get; set; }`
  - `public ResizePolicy WidthResizePolicy { get; set; }`

### `Tizen.UI.LongPressGesture`
- **상속**: `Tizen.UI.Gesture`
- **프로퍼티** (3개):
  - `public Int32 NumberOfTouches { get; }`
  - `public Point Position { get; }`
  - `public Point ScreenPosition { get; }`

### `Tizen.UI.LongPressGestureDetector`
- **상속**: `Tizen.UI.GestureDetector`
- **생성자**:
  - `.ctor()`
- **이벤트** (1개):
  - `public event EventHandler<LongPressGestureDetectedEventArgs> Detected`

### `Tizen.UI.LottieAnimationView`
- **상속**: `Tizen.UI.ImageView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (7개):
  - `public Int32 CurrentFrame { get; set; }`
  - `public Boolean Loop { get; set; }`
  - `public AnimationState PlayState { get; }`
  - `public Int32 RepeatCount { get; set; }`
  - `public AnimationRepeatMode RepeatMode { get; set; }`
  - `public AnimationStopBehavior StopBehavior { get; set; }`
  - `public Int32 TotalFrame { get; }`
- **이벤트** (1개):
  - `public event EventHandler Finished`

### `Tizen.UI.NObject`
- **상속**: `System.Object`
- **인터페이스**: `System.IDisposable`
- **프로퍼티** (3개):
  - `public IntPtr Handle { get; }`
  - `public Boolean HasOwnership { get; set; }`
  - `public Boolean IsDisposed { get; }`

### `Tizen.UI.PanGesture`
- **상속**: `Tizen.UI.Gesture`
- **프로퍼티** (7개):
  - `public Point Displacement { get; }`
  - `public Int32 NumberOfTouches { get; }`
  - `public Point Position { get; }`
  - `public Point ScreenDisplacement { get; }`
  - `public Point ScreenPosition { get; }`
  - `public Point ScreenVelocity { get; }`
  - `public Point Velocity { get; }`

### `Tizen.UI.PanGestureDetector`
- **상속**: `Tizen.UI.GestureDetector`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public PanGestureDirection Direction { get; set; }`
  - `public Int32 MaximumTouchesRequired { get; set; }`
  - `public Int32 MinimumTouchesRequired { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler<PanGestureDetectedEventArgs> Detected`

### `Tizen.UI.PinchGesture`
- **상속**: `Tizen.UI.Gesture`
- **프로퍼티** (4개):
  - `public Point Center { get; }`
  - `public Single Scale { get; }`
  - `public Point ScreenCenter { get; }`
  - `public Single Speed { get; }`

### `Tizen.UI.PinchGestureDetector`
- **상속**: `Tizen.UI.GestureDetector`
- **생성자**:
  - `.ctor()`
- **이벤트** (1개):
  - `public event EventHandler<PinchGestureDetectedEventArgs> Detected`

### `Tizen.UI.PixelBuffer`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor(Int32 width, Int32 height, PixelFormat pixelFormat)`
- **프로퍼티** (3개):
  - `public Int32 Height { get; }`
  - `public PixelFormat PixelFormat { get; }`
  - `public Int32 Width { get; }`

### `Tizen.UI.PixelData`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor(Byte[] buffer, Int32 width, Int32 height, PixelFormat pixelFormat)`
- **프로퍼티** (3개):
  - `public UInt32 Height { get; }`
  - `public PixelFormat PixelFormat { get; }`
  - `public UInt32 Width { get; }`

### `Tizen.UI.RotationGesture`
- **상속**: `Tizen.UI.Gesture`
- **프로퍼티** (3개):
  - `public Point Center { get; }`
  - `public Single Rotation { get; }`
  - `public Point ScreenCenter { get; }`

### `Tizen.UI.RotationGestureDetector`
- **상속**: `Tizen.UI.GestureDetector`
- **생성자**:
  - `.ctor()`
- **이벤트** (1개):
  - `public event EventHandler<RotationGestureDetectedEventArgs> Detected`

### `Tizen.UI.TapGesture`
- **상속**: `Tizen.UI.Gesture`
- **프로퍼티** (3개):
  - `public Int32 NumberOfTaps { get; }`
  - `public Point Position { get; }`
  - `public Point ScreenPosition { get; }`

### `Tizen.UI.TapGestureDetector`
- **상속**: `Tizen.UI.GestureDetector`
- **생성자**:
  - `.ctor()`
  - `.ctor(Int32 tapsRequired)`
- **프로퍼티** (2개):
  - `public Int32 MaximumTapsRequired { get; set; }`
  - `public Int32 MinimumTapsRequired { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler<TapGestureDetectedEventArgs> Detected`

### `Tizen.UI.TextEditor`
- **상속**: `Tizen.UI.InputView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public Boolean IsAbsoluteLineHeight { get; set; }`
  - `public Single LineHeight { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`

### `Tizen.UI.TextField`
- **상속**: `Tizen.UI.InputView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (2개):
  - `public Boolean IsPassword { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`

### `Tizen.UI.TextView`
- **상속**: `Tizen.UI.View`
- **인터페이스**: `Tizen.UI.IFontSizeScale`, `Tizen.UI.IText`, `Tizen.UI.ITextAlignment`, `Tizen.UI.ITextFormatting`, `Tizen.UI.ITextPadding`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (18개):
  - `public Single AutoAdjustedFontSize { get; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public TextAlignment HorizontalAlignment { get; set; }`
  - `public Boolean IsAbsoluteLineHeight { get; set; }`
  - `public Boolean IsMarkupEnabled { get; set; }`
  - `public Boolean IsMultiline { get; set; }`
  - `public Boolean IsTextCutout { get; set; }`
  - `public Boolean IsTextScrolling { get; }`
  - `public LineBreakMode LineBreakMode { get; set; }`
  - `public Int32 LineCount { get; }`
  - `public Single LineHeight { get; set; }`
  - `public Single ScaledFontSize { get; }`
  - `public Boolean SystemFontScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`
  - `public TextAlignment VerticalAlignment { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler<AnchorClickedEventArgs> AnchorClicked`
  - `public event EventHandler FontSizeAdjusted`

### `Tizen.UI.Timer`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor(UInt32 millisec)`
- **프로퍼티** (3개):
  - `public UInt32 Interval { get; set; }`
  - `public Boolean IsRunning { get; }`
  - `public Func<Boolean> TickHandler { get; set; }`

### `Tizen.UI.TouchEvent`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public Int32 Count { get; }`
  - `public Touch Item { get; }`
  - `public UInt32 Time { get; }`

### `Tizen.UI.TouchPoint`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor(Int32 deviceId, TouchState state, Single screenX, Single screenY)`
- **프로퍼티** (5개):
  - `public Int32 DeviceId { get; set; }`
  - `public View HitView { get; set; }`
  - `public Point Position { get; set; }`
  - `public Point ScreenPosition { get; set; }`
  - `public TouchState State { get; set; }`

### `Tizen.UI.VideoOverlayView`
- **상속**: `Tizen.UI.View`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public Rect DisplayArea { get; }`

### `Tizen.UI.View`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (65개):
  - `public String AccessibilityDescription { get; set; }`
  - `public Boolean AccessibilityHidden { get; set; }`
  - `public Boolean AccessibilityHighlightable { get; set; }`
  - `public String AccessibilityName { get; set; }`
  - `public AccessibilityRole AccessibilityRole { get; set; }`
  - `public String AccessibilityValue { get; set; }`
  - `public String AutomationId { get; set; }`
  - `public Color BackgroundColor { get; set; }`
  - `public Color BorderlineColor { get; set; }`
  - `public Single BorderlineOffset { get; set; }`
  - `public Single BorderlineWidth { get; set; }`
  - `public Rect Bounds { get; }`
  - `public ClippingMode ClippingMode { get; set; }`
  - `public CornerRadius CornerRadius { get; set; }`
  - `public Single CurrentOpacity { get; }`
  - `public Point CurrentPosition { get; }`
  - `public Size CurrentScale { get; }`
  - `public Point CurrentScreenPosition { get; }`
  - `public Size CurrentSize { get; }`
  - `public Single DesiredHeight { get; set; }`
  - `public Single DesiredWidth { get; set; }`
  - `public Boolean DisallowInterceptTouchEvent { get; set; }`
  - `public View DownFocusableView { get; set; }`
  - `public Boolean Focusable { get; set; }`
  - `public Boolean FocusableChildren { get; set; }`
  - `public Boolean FocusableInTouch { get; set; }`
  - `public Single Height { get; set; }`
  - `public ResizePolicy HeightResizePolicy { get; set; }`
  - `public UInt32 ID { get; }`
  - `public Boolean InheritLayoutDirection { get; set; }`
  - `public Boolean IsEnabled { get; set; }`
  - `public Boolean IsOnWindow { get; }`
  - `public Boolean IsVisible { get; set; }`
  - `public View Item { get; }`
  - `public LayoutDirection LayoutDirection { get; set; }`
  - `public View LeftFocusableView { get; set; }`
  - `public Color MultipliedColor { get; set; }`
  - `public String Name { get; set; }`
  - `public Size NaturalSize { get; }`
  - `public OffScreenRendering OffScreenRendering { get; set; }`
  - `public Single Opacity { get; set; }`
  - `public View Parent { get; }`
  - `public NObject ParentObject { get; }`
  - `public Point ParentOrigin { get; set; }`
  - `public Single ParentOriginX { get; set; }`
  - `public Single ParentOriginY { get; set; }`
  - `public Point PivotPoint { get; set; }`
  - `public Single PivotPointX { get; set; }`
  - `public Single PivotPointY { get; set; }`
  - `public Boolean PositionUsesPivotPoint { get; set; }`
  - `public View RightFocusableView { get; set; }`
  - `public Single Rotation { get; set; }`
  - `public Single RotationX { get; set; }`
  - `public Single RotationY { get; set; }`
  - `public Single ScaleX { get; set; }`
  - `public Single ScaleY { get; set; }`
  - `public Point ScreenPosition { get; }`
  - `public Boolean Sensitive { get; set; }`
  - `public Thickness TouchEdgeInsets { get; set; }`
  - `public View UpFocusableView { get; set; }`
  - `public Single Width { get; set; }`
  - `public ResizePolicy WidthResizePolicy { get; set; }`
  - `public Size WorldScale { get; }`
  - `public Single X { get; set; }`
  - `public Single Y { get; set; }`
- **이벤트** (21개):
  - `public event EventHandler<AccessibilityActionReceivedEventArgs> AccessibilityActionReceived`
  - `public event EventHandler<AccessibilityDescriptionRequestedEventArgs> AccessibilityDescriptionRequested`
  - `public event EventHandler<AccessibilityHighlightChangedEventArgs> AccessibilityHighlightChanged`
  - `public event EventHandler<AccessibilityNameRequestedEventArgs> AccessibilityNameRequested`
  - `public event EventHandler AttachedToWindow`
  - `public event EventHandler DetachedFromWindow`
  - `public event EventHandler Disposing`
  - `public event EventHandler EnabledChanged`
  - `public event EventHandler Focused`
  - `public event EventHandler<HoverEventArgs> HoverEvent`
  - `public event EventHandler<TouchEventArgs> InterceptTouchEvent`
  - `public event EventHandler<WheelEventArgs> InterceptWheelEvent`
  - `public event EventHandler<KeyEventArgs> KeyEvent`
  - `public event EventHandler LayoutDirectionChanged`
  - `public event EventHandler MeasureInvalidated`
  - `public event EventHandler Relayout`
  - `public event EventHandler<TokenPropertyChangedEventArgs> TokenPropertyChanged`
  - `public event EventHandler<TouchEventArgs> TouchEvent`
  - `public event EventHandler Unfocused`
  - `public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged`
  - `public event EventHandler<WheelEventArgs> WheelEvent`

### `Tizen.UI.ViewGroup`
- **상속**: `Tizen.UI.View`
- **인터페이스**: `System.Collections.Generic.ICollection`1<Tizen.UI.View>`, `System.Collections.Generic.IEnumerable`1<Tizen.UI.View>`, `System.Collections.Generic.IList`1<Tizen.UI.View>`, `System.Collections.IEnumerable`, `Tizen.UI.IParentObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (4개):
  - `public IList<View> Children { get; }`
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public View Item { get; set; }`

### `Tizen.UI.WebView`
- **상속**: `Tizen.UI.View`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public Boolean CanGoBack { get; }`
  - `public Boolean CanGoForward { get; }`
  - `public WebViewSource Source { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler<WebNavigationEventArgs> NavigationCompleted`
  - `public event EventHandler<WebNavigationEventArgs> NavigationStarted`

### `Tizen.UI.WheelEvent`
- **상속**: `Tizen.UI.NObject`
- **프로퍼티** (9개):
  - `public Int32 Delta { get; }`
  - `public WheelDirection Direction { get; }`
  - `public Boolean IsAltModifier { get; }`
  - `public Boolean IsCtrlModifier { get; }`
  - `public Boolean IsShiftModifier { get; }`
  - `public UInt32 Modifier { get; }`
  - `public Point Position { get; }`
  - `public UInt32 Time { get; }`
  - `public WheelType WheelType { get; }`

### `Tizen.UI.Window`
- **상속**: `Tizen.UI.NObject`
- **인터페이스**: `Tizen.Common.IWindowProvider`
- **생성자**:
  - `.ctor()`
  - `.ctor(String name)`
  - `.ctor(String name, Boolean isTranslucent)`
- **프로퍼티** (12개):
  - `public Thickness BorderArea { get; set; }`
  - `public Window Default { get; set; }`
  - `public Layer DefaultLayer { get; }`
  - `public Int32 DPI { get; }`
  - `public Boolean IsAlwaysOnTop { get; set; }`
  - `public Boolean IsMaximized { get; }`
  - `public Boolean IsMinimized { get; }`
  - `public Boolean IsModal { get; set; }`
  - `public Boolean IsVisible { get; }`
  - `public IReadOnlyList<Layer> Layers { get; }`
  - `public String Title { get; set; }`
  - `public WindowType WindowType { get; set; }`
- **이벤트** (10개):
  - `public event EventHandler<WindowFocusChangedEventArgs> FocusChanged`
  - `public event EventHandler<HoverEventArgs> HoverEvent`
  - `public event EventHandler<TouchEventArgs> InterceptTouchEvent`
  - `public event EventHandler<WheelEventArgs> InterceptWheelEvent`
  - `public event EventHandler<KeyEventArgs> KeyEvent`
  - `public event EventHandler Moved`
  - `public event EventHandler Resized`
  - `public event EventHandler<TouchEventArgs> TouchEvent`
  - `public event EventHandler VisibilityChanged`
  - `public event EventHandler<WheelEventArgs> WheelEvent`

### `Tizen.UI.Internal.DaliNativeApp`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor(String[] args, WindowMode windowMode, Rect windowBounds, Boolean useTask)`
- **프로퍼티** (11개):
  - `public Action<IntPtr> AppControlHandler { get; set; }`
  - `public Action<Int32> BatteryLowHandler { get; set; }`
  - `public Action CreatedHandler { get; set; }`
  - `public DaliNativeApp Current { get; set; }`
  - `public Action<Int32> DeviceOrientationChangedHandler { get; set; }`
  - `public Action<String> LanguageChangedHandler { get; set; }`
  - `public Action<Int32> MemoryLowHandler { get; set; }`
  - `public Action PausedHandler { get; set; }`
  - `public Action<String> RegionChangedHandler { get; set; }`
  - `public Action ResumedHandler { get; set; }`
  - `public Action TerminatedHandler { get; set; }`

### `Tizen.UI.Internal.Geometry`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public GeometryType GeometryType { get; set; }`

### `Tizen.UI.Internal.ProcessorController`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public ProcessorController Instance { get; }`
  - `public Boolean IsOnProcess { get; set; }`
  - `public Boolean IsOnRelayout { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler LayoutIteration`
  - `public event EventHandler LayoutIterationOnce`

### `Tizen.UI.Internal.Renderer`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor(Geometry geometry, Shader shader)`
- **프로퍼티** (23개):
  - `public Color BlendColor { get; set; }`
  - `public BlendEquationType BlendEquationAlpha { get; set; }`
  - `public BlendEquationType BlendEquationRgb { get; set; }`
  - `public BlendFactorType BlendFactorDestAlpha { get; set; }`
  - `public BlendFactorType BlendFactorDestRgb { get; set; }`
  - `public BlendFactorType BlendFactorSrcAlpha { get; set; }`
  - `public BlendFactorType BlendFactorSrcRgb { get; set; }`
  - `public BlendModeType BlendMode { get; set; }`
  - `public Boolean BlendPreMultipliedAlpha { get; set; }`
  - `public DepthFunctionType DepthFunction { get; set; }`
  - `public Int32 DepthIndex { get; set; }`
  - `public DepthTestModeType DepthTestMode { get; set; }`
  - `public DepthWriteModeType DepthWriteMode { get; set; }`
  - `public FaceCullingModeType FaceCullingMode { get; set; }`
  - `public Int32 IndexRangeCount { get; set; }`
  - `public Int32 IndexRangeFirst { get; set; }`
  - `public StencilOperationType InternalStencilOperationOnZFail { get; set; }`
  - `public RenderModeType RenderMode { get; set; }`
  - `public StencilFunctionType StencilFunction { get; set; }`
  - `public Int32 StencilFunctionReference { get; set; }`
  - `public Int32 StencilMask { get; set; }`
  - `public StencilOperationType StencilOperationOnFail { get; set; }`
  - `public StencilOperationType StencilOperationOnZPass { get; set; }`

### `Tizen.UI.Internal.RenderPropertyNotification`
- **상속**: `Tizen.UI.NObject`
- **프로퍼티** (1개):
  - `public Action UpdateAction { get; set; }`

## 📦 Tizen.UI.Components

### `Tizen.UI.Components.Clickable`
- **상속**: `Tizen.UI.Components.Pressable`
- **인터페이스**: `Tizen.UI.Components.IClickable`
- **생성자**:
  - `.ctor()`
  - `.ctor(IClickableVariables variables)`
- **프로퍼티** (4개):
  - `public Action<Object, InputEventArgs> ClickedCommand { get; set; }`
  - `public ClickKeyType ClickKeyType { get; set; }`
  - `public Boolean IsClickable { get; set; }`
  - `public Action<Object, InputEventArgs> LongPressedCommand { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler<InputEventArgs> Clicked`
  - `public event EventHandler<InputEventArgs> LongPressed`

### `Tizen.UI.Components.ClickableBox`
- **상속**: `Tizen.UI.Components.Clickable`
- **인터페이스**: `System.Collections.Generic.ICollection`1<Tizen.UI.View>`, `System.Collections.Generic.IEnumerable`1<Tizen.UI.View>`, `System.Collections.Generic.IList`1<Tizen.UI.View>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.ILayoutBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (5개):
  - `public IList<View> Children { get; }`
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public View Item { get; set; }`
  - `public Thickness Padding { get; set; }`

### `Tizen.UI.Components.ClickableGrid`
- **상속**: `Tizen.UI.Components.ClickableBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (5개):
  - `public IList<GridColumnDefinition> ColumnDefinitions { get; set; }`
  - `public Single ColumnSpacing { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public IList<GridRowDefinition> RowDefinitions { get; set; }`
  - `public Single RowSpacing { get; set; }`

### `Tizen.UI.Components.ClickableHStack`
- **상속**: `Tizen.UI.Components.ClickableBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public LayoutAlignment ItemAlignment { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public Single Spacing { get; set; }`

### `Tizen.UI.Components.ClickableVStack`
- **상속**: `Tizen.UI.Components.ClickableBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public LayoutAlignment ItemAlignment { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public Single Spacing { get; set; }`

### `Tizen.UI.Components.GroupSelectable`
- **상속**: `Tizen.UI.Components.Selectable`
- **인터페이스**: `Tizen.UI.Components.IGroupSelectable`, `Tizen.UI.Components.ISelectable`
- **생성자**:
  - `.ctor()`
  - `.ctor(IClickableVariables variables)`
- **프로퍼티** (3개):
  - `public SelectionGroup Group { get; }`
  - `public String GroupName { get; set; }`
  - `public Boolean IsGrouped { get; }`

### `Tizen.UI.Components.GroupSelectableBox`
- **상속**: `Tizen.UI.Components.GroupSelectable`
- **인터페이스**: `System.Collections.Generic.ICollection`1<Tizen.UI.View>`, `System.Collections.Generic.IEnumerable`1<Tizen.UI.View>`, `System.Collections.Generic.IList`1<Tizen.UI.View>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.ILayoutBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (5개):
  - `public IList<View> Children { get; }`
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public View Item { get; set; }`
  - `public Thickness Padding { get; set; }`

### `Tizen.UI.Components.InteractiveProgress`
- **상속**: `Tizen.UI.Components.Pressable`
- **생성자**:
  - `.ctor(Single minimumValue, Single maximumValue)`
- **프로퍼티** (7개):
  - `public Boolean IgnoreTap { get; set; }`
  - `public Boolean IgnoreTouchDown { get; set; }`
  - `public ClosedRange<Single> Range { get; set; }`
  - `public Boolean UseRelativeTouchPoint { get; set; }`
  - `public Single Value { get; set; }`
  - `public Boolean ValueChanging { get; }`
  - `public Int32 ValueStepCount { get; set; }`
- **이벤트** (3개):
  - `public event EventHandler<InputEventArgs> ValueChanged`
  - `public event EventHandler<InputEventArgs> ValueChangeFinished`
  - `public event EventHandler<InputEventArgs> ValueChangeStarted`

### `Tizen.UI.Components.Navigator`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `Tizen.UI.Components.INavigateBackHandler`, `Tizen.UI.Components.INavigation`, `Tizen.UI.Components.INavigationAnimation`, `Tizen.UI.Components.INavigationTransition`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (7개):
  - `public View CurrentView { get; }`
  - `public IReadOnlyList<View> ModalStack { get; }`
  - `public IReadOnlyList<View> NavigationStack { get; }`
  - `public Func<View, View, INavigationAnimationController> PopAnimation { get; }`
  - `public Func<View, View, INavigationAnimationController> PopModalAnimation { get; }`
  - `public Func<View, View, INavigationAnimationController> PushAnimation { get; }`
  - `public Func<View, View, INavigationAnimationController> PushModalAnimation { get; }`

### `Tizen.UI.Components.Pressable`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `Tizen.UI.Components.IPressable`, `Tizen.UI.Components.ITouchEffectTarget`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (2개):
  - `public Boolean IsPressed { get; set; }`
  - `public Action<Object, InputEventArgs> PressedChangedCommand { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler<InputEventArgs> PressedChanged`

### `Tizen.UI.Components.PressableBox`
- **상속**: `Tizen.UI.Components.Pressable`
- **인터페이스**: `System.Collections.Generic.ICollection`1<Tizen.UI.View>`, `System.Collections.Generic.IEnumerable`1<Tizen.UI.View>`, `System.Collections.Generic.IList`1<Tizen.UI.View>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.ILayoutBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (5개):
  - `public IList<View> Children { get; }`
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public View Item { get; set; }`
  - `public Thickness Padding { get; set; }`

### `Tizen.UI.Components.Progress`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor(Single minimumValue, Single maximumValue)`
- **프로퍼티** (4개):
  - `public Boolean IsDeterminate { get; set; }`
  - `public ClosedRange<Single> Range { get; set; }`
  - `public Single Value { get; set; }`
  - `public Int32 ValueStepCount { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler ValueChanged`

### `Tizen.UI.Components.ScaffoldBase`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (7개):
  - `public View FloatingActionButton { get; set; }`
  - `public Point FloatingOffset { get; set; }`
  - `public FloatingOrigin FloatingOrigin { get; set; }`
  - `public Boolean HasIndicatorArea { get; set; }`
  - `public Boolean HasNavigationBarArea { get; set; }`
  - `public Color IndicatorAreaColor { get; set; }`
  - `public IColorProvider IndicatorAreaColorProvider { get; set; }`

### `Tizen.UI.Components.Scrollable`
- **상속**: `Tizen.UI.Layouts.Layout`
- **인터페이스**: `Tizen.UI.IDescendantFocusObserver`, `Tizen.UI.IScrollable`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (19개):
  - `public Boolean CanScrollHorizontally { get; }`
  - `public Boolean CanScrollVertically { get; }`
  - `public View Content { get; set; }`
  - `public IEdgeEffect HorizontalEdgeEffect { get; set; }`
  - `public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }`
  - `public Boolean IsScrolledToEnd { get; }`
  - `public Boolean IsScrolledToStart { get; }`
  - `public Boolean IsScrolling { get; set; }`
  - `public OverScrollMode OverScrollMode { get; set; }`
  - `public Single ScrollableHeight { get; }`
  - `public Single ScrollableWidth { get; }`
  - `public IScrollBar ScrollBar { get; set; }`
  - `public ScrollDirection ScrollDirection { get; set; }`
  - `public Func<Point, Point> ScrollingDestinationHandler { get; set; }`
  - `public Point ScrollPosition { get; }`
  - `public Size ScrollSize { get; set; }`
  - `public IEdgeEffect VerticalEdgeEffect { get; set; }`
  - `public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }`
  - `public Rect ViewPort { get; }`
- **이벤트** (6개):
  - `public event EventHandler<DragEventArgs> DragFinished`
  - `public event EventHandler<DragEventArgs> Dragging`
  - `public event EventHandler<DragEventArgs> DragStarted`
  - `public event EventHandler<ScrollEventArgs> ScrollFinished`
  - `public event EventHandler<ScrollEventArgs> Scrolling`
  - `public event EventHandler<ScrollEventArgs> ScrollStarted`

### `Tizen.UI.Components.ScrollBarBase`
- **상속**: `Tizen.UI.ViewGroup`
- **인터페이스**: `System.IDisposable`, `Tizen.UI.IScrollBar`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (10개):
  - `public Color BarColor { get; set; }`
  - `public CornerRadius BarCornerRadius { get; set; }`
  - `public Thickness BarMargin { get; set; }`
  - `public Single BarMinSize { get; set; }`
  - `public Shadow BarShadow { get; set; }`
  - `public Single BarThickness { get; set; }`
  - `public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }`
  - `public Point ScrollPosition { get; set; }`
  - `public View Target { get; }`
  - `public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }`

### `Tizen.UI.Components.Selectable`
- **상속**: `Tizen.UI.Components.Clickable`
- **인터페이스**: `Tizen.UI.Components.ISelectable`
- **생성자**:
  - `.ctor()`
  - `.ctor(IClickableVariables variables)`
- **프로퍼티** (3개):
  - `public Boolean IsSelectable { get; set; }`
  - `public Boolean IsSelected { get; set; }`
  - `public Action<Object, InputEventArgs> SelectedChangedCommand { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler<InputEventArgs> SelectedChanged`

### `Tizen.UI.Components.SelectableBox`
- **상속**: `Tizen.UI.Components.Selectable`
- **인터페이스**: `System.Collections.Generic.ICollection`1<Tizen.UI.View>`, `System.Collections.Generic.IEnumerable`1<Tizen.UI.View>`, `System.Collections.Generic.IList`1<Tizen.UI.View>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.ILayoutBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (5개):
  - `public IList<View> Children { get; }`
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public View Item { get; set; }`
  - `public Thickness Padding { get; set; }`

### `Tizen.UI.Components.SelectableHStack`
- **상속**: `Tizen.UI.Components.SelectableBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public LayoutAlignment ItemAlignment { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public Single Spacing { get; set; }`

### `Tizen.UI.Components.SelectableVStack`
- **상속**: `Tizen.UI.Components.SelectableBox`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public LayoutAlignment ItemAlignment { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public Single Spacing { get; set; }`

### `Tizen.UI.Components.SelectionGroupBox`1`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `System.Collections.Generic.ICollection`1<T>`, `System.Collections.Generic.IEnumerable`1<T>`, `System.Collections.Generic.IList`1<T>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.ILayoutBox`, `Tizen.UI.Components.ISelectionGroup`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (11개):
  - `public IList<View> Children { get; }`
  - `public Int32 Count { get; }`
  - `public Boolean EmptySelectionAllowed { get; set; }`
  - `public Boolean IsReadOnly { get; }`
  - `public T Item { get; set; }`
  - `public Action<Object, SelectionGroupItemClickedEventArgs> ItemClickedCommand { get; set; }`
  - `public ICollection<T> Items { get; }`
  - `public Thickness Padding { get; set; }`
  - `public Int32 SelectedIndex { get; }`
  - `public T SelectedItem { get; }`
  - `public Action<Object, GroupSelectionChangedEventArgs> SelectionChangedCommand { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler<SelectionGroupItemClickedEventArgs> ItemClicked`
  - `public event EventHandler<GroupSelectionChangedEventArgs> SelectionChanged`

### `Tizen.UI.Components.TimeCounter`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
  - `.ctor(Int32 totalTimeInMilliseconds)`
- **프로퍼티** (4개):
  - `public Boolean IsWarning { get; set; }`
  - `public Int32 RemainingTime { get; set; }`
  - `public Int32 TotalTime { get; set; }`
  - `public Int32 WarningTime { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler RemainingTimeChanged`
  - `public event EventHandler WarningChanged`

### `Tizen.UI.Components.Recycler.RecyclerView`
- **상속**: `Tizen.UI.ViewGroup`
- **인터페이스**: `Tizen.UI.IDescendantFocusObserver`, `Tizen.UI.IScrollable`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (19개):
  - `public Adapter Adapter { get; set; }`
  - `public Boolean HasSticky { get; set; }`
  - `public IEdgeEffect HorizontalEdgeEffect { get; set; }`
  - `public RecycleScroller InnerScroller { get; }`
  - `public StickyArea InnerStickArea { get; }`
  - `public Boolean IsScrolledToEnd { get; }`
  - `public Boolean IsScrolledToStart { get; }`
  - `public Boolean IsScrolling { get; set; }`
  - `public IList<IItemDecoration> ItemDecorations { get; }`
  - `public Rect LastViewPort { get; set; }`
  - `public LayoutManager LayoutManager { get; set; }`
  - `public OverScrollMode OverScrollMode { get; set; }`
  - `public Single PrefetchBaseSize { get; set; }`
  - `public Int32 RecycledPoolSize { get; set; }`
  - `public ScrollDirection ScrollDirection { get; }`
  - `public Point ScrollPosition { get; }`
  - `public Boolean StickyCandidateVisible { get; set; }`
  - `public IEdgeEffect VerticalEdgeEffect { get; set; }`
  - `public Rect ViewPort { get; }`
- **이벤트** (7개):
  - `public event EventHandler<DragEventArgs> DragFinished`
  - `public event EventHandler<DragEventArgs> Dragging`
  - `public event EventHandler<DragEventArgs> DragStarted`
  - `public event EventHandler<ScrollEventArgs> ScrollCanceled`
  - `public event EventHandler<ScrollEventArgs> ScrollFinished`
  - `public event EventHandler<ScrollEventArgs> Scrolling`
  - `public event EventHandler<ScrollEventArgs> ScrollStarted`

### `Tizen.UI.Components.Recycler.RecycleScroller`
- **상속**: `Tizen.UI.ViewGroup`
- **생성자**:
  - `.ctor(RecyclerView recyclerView)`
- **프로퍼티** (6개):
  - `public Rect CurrentViewPort { get; }`
  - `public Boolean IsScrollAnimationStarted { get; set; }`
  - `public IList<View> RecycleBody { get; }`
  - `public Single ScrollX { get; }`
  - `public Single ScrollY { get; }`
  - `public Rect ViewPort { get; }`
- **이벤트** (4개):
  - `public event EventHandler ScrollAnimationCanceled`
  - `public event EventHandler ScrollAnimationFinished`
  - `public event EventHandler ScrollAnimationStarted`
  - `public event EventHandler<ScrollEventArgs> Scrolling`

## 📦 Tizen.UI.Components.Material

### `Tizen.UI.Components.Material.AdapterView`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (7개):
  - `public Thickness InnerMargin { get; set; }`
  - `public IList<IItemDecoration> ItemDecorations { get; }`
  - `public IEnumerable ItemsSource { get; set; }`
  - `public ViewTemplate ItemTemplate { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public Single PrefetchBaseSize { get; set; }`
  - `public ScrollBarVisibility ScrollBarVisibility { get; set; }`
- **이벤트** (6개):
  - `public event EventHandler<DragEventArgs> DragFinished`
  - `public event EventHandler<DragEventArgs> Dragging`
  - `public event EventHandler<DragEventArgs> DragStarted`
  - `public event EventHandler<ScrollEventArgs> ScrollFinished`
  - `public event EventHandler<ScrollEventArgs> Scrolling`
  - `public event EventHandler<ScrollEventArgs> ScrollStarted`

### `Tizen.UI.Components.Material.AlertDialog`
- **상속**: `Tizen.UI.Components.Material.Dialog`
- **생성자**:
  - `.ctor()`
  - `.ctor(AlertDialogVariables variables)`
- **프로퍼티** (2개):
  - `public String Message { get; set; }`
  - `public String Title { get; set; }`

### `Tizen.UI.Components.Material.AnimatedImage`
- **상속**: `Tizen.UI.Components.Material.Image`
- **인터페이스**: `Tizen.UI.Components.IAnimatedImage`
- **생성자**:
  - `.ctor()`
  - `.ctor(String resourceUrl)`
  - `.ctor(IEnumerable<String> sequentialResourceUrls, Int32 preloadingBatchSize, Int32 cacheSize)`
- **프로퍼티** (7개):
  - `public Int32 CurrentFrame { get; set; }`
  - `public Single FrameSpeedFactor { get; set; }`
  - `public Boolean IsLooping { get; set; }`
  - `public Int32 RepeatCount { get; set; }`
  - `public AnimationRepeatMode RepeatMode { get; set; }`
  - `public AnimationStopBehavior StopBehavior { get; set; }`
  - `public Int32 TotalFrame { get; }`

### `Tizen.UI.Components.Material.AppBar`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `Tizen.UI.Components.IColorProvider`, `Tizen.UI.Components.ITitle`
- **생성자**:
  - `.ctor()`
  - `.ctor(AppBarVariables variables)`
  - `.ctor(Boolean useUniformedContentColor, AppBarVariables variables)`
- **프로퍼티** (7개):
  - `public IList<View> ActionButtons { get; }`
  - `public Color DominantColor { get; set; }`
  - `public View Leading { get; set; }`
  - `public String Title { get; set; }`
  - `public View TitleContent { get; set; }`
  - `public View Trailing { get; set; }`
  - `public Color UnifiedContentColor { get; }`
- **이벤트** (1개):
  - `public event EventHandler DominantColorChanged`

### `Tizen.UI.Components.Material.BackButton`
- **상속**: `Tizen.UI.Components.Material.IconButton`
- **인터페이스**: `Tizen.UI.Components.Material.IAppBarContent`
- **생성자**:
  - `.ctor()`
  - `.ctor(IconButtonVariables variables)`
- **프로퍼티** (2개):
  - `public Boolean ExitOnRoot { get; set; }`
  - `public INavigation Navigation { get; set; }`

### `Tizen.UI.Components.Material.BottomSheet`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
  - `.ctor(BottomSheetVariables variables)`
- **프로퍼티** (3개):
  - `public IReadOnlyList<Single> Anchors { get; }`
  - `public View Content { get; set; }`
  - `public Int32 DefaultAnchorIndex { get; }`

### `Tizen.UI.Components.Material.BottomSheetContainer`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `Tizen.UI.Components.IModalContainer`, `Tizen.UI.Components.INavigationAnimation`
- **생성자**:
  - `.ctor()`
  - `.ctor(BottomSheetContainerVariables variables)`
- **프로퍼티** (6개):
  - `public View ModalContent { get; set; }`
  - `public Func<View, View, INavigationAnimationController> PopAnimation { get; }`
  - `public Func<View, View, INavigationAnimationController> PopModalAnimation { get; }`
  - `public Func<View, View, INavigationAnimationController> PushAnimation { get; }`
  - `public Func<View, View, INavigationAnimationController> PushModalAnimation { get; }`
  - `public View Scrim { get; set; }`

### `Tizen.UI.Components.Material.Button`
- **상속**: `Tizen.UI.Components.Clickable`
- **인터페이스**: `Tizen.UI.Components.IFlexibleText`, `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(ButtonVariables variables)`
  - `.ctor(String text)`
  - `.ctor(String text, ButtonVariables variables)`
- **프로퍼티** (8개):
  - `public AutoFontSize AutoFontSize { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Boolean IsProgressing { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`

### `Tizen.UI.Components.Material.Card`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
  - `.ctor(CardVariables variables)`
- **프로퍼티** (1개):
  - `public View Content { get; set; }`

### `Tizen.UI.Components.Material.CircleButton`
- **상속**: `Tizen.UI.Components.Clickable`
- **생성자**:
  - `.ctor()`
  - `.ctor(CircleButtonVariables variables)`
  - `.ctor(String iconResourceUrl)`
  - `.ctor(String iconResourceUrl, CircleButtonVariables variables)`
- **프로퍼티** (6개):
  - `public Single IconHeight { get; set; }`
  - `public Color IconMultipliedColor { get; set; }`
  - `public String IconResourceUrl { get; set; }`
  - `public Single IconWidth { get; set; }`
  - `public Boolean IsProgressing { get; set; }`
  - `public Thickness Padding { get; set; }`

### `Tizen.UI.Components.Material.Dialog`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
  - `.ctor(DialogVariables variables)`
- **프로퍼티** (3개):
  - `public View BodyView { get; set; }`
  - `public View FooterView { get; set; }`
  - `public View HeaderView { get; set; }`

### `Tizen.UI.Components.Material.DialogContainer`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `Tizen.UI.Components.IModalContainer`
- **생성자**:
  - `.ctor()`
  - `.ctor(DialogContainerVariables variables)`
- **프로퍼티** (2개):
  - `public View ModalContent { get; set; }`
  - `public View Scrim { get; set; }`

### `Tizen.UI.Components.Material.Divider`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
  - `.ctor(DividerVariables variables)`
  - `.ctor(DividerDirection direction)`
  - `.ctor(DividerDirection direction, DividerVariables variables)`
- **프로퍼티** (3개):
  - `public Color DividerColor { get; set; }`
  - `public DividerStyle Style { get; set; }`
  - `public Single Thickness { get; set; }`

### `Tizen.UI.Components.Material.DoubleTitle`
- **상속**: `Tizen.UI.Layouts.VStack`
- **인터페이스**: `Tizen.UI.Components.IDoubleTitle`, `Tizen.UI.Components.ITitle`, `Tizen.UI.Components.Material.IAppBarContent`
- **생성자**:
  - `.ctor(String title, String subtitle)`
  - `.ctor(String title, String subtitle, DoubleTitleVariables variables)`
- **프로퍼티** (5개):
  - `public Single ItemSpacing { get; set; }`
  - `public String Subtitle { get; set; }`
  - `public Label SubtitleLabel { get; }`
  - `public String Title { get; set; }`
  - `public Label TitleLabel { get; }`

### `Tizen.UI.Components.Material.Drawer`1`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `System.Collections.Generic.ICollection`1<T>`, `System.Collections.Generic.IEnumerable`1<T>`, `System.Collections.Generic.IList`1<T>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.ISelectionGroup`
- **생성자**:
  - `.ctor()`
  - `.ctor(ModalDrawerVariables variables)`
- **프로퍼티** (9개):
  - `public View Content { get; set; }`
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public T Item { get; set; }`
  - `public IList<T> Items { get; }`
  - `public Single ItemSpacing { get; set; }`
  - `public Int32 SelectedIndex { get; }`
  - `public T SelectedItem { get; }`
  - `public Action<Object, GroupSelectionChangedEventArgs> SelectionChangedCommand { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler<GroupSelectionChangedEventArgs> SelectionChanged`

### `Tizen.UI.Components.Material.DrawerItem`
- **상속**: `Tizen.UI.Components.GroupSelectable`
- **인터페이스**: `Tizen.UI.Components.IFlexibleText`, `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(DrawerItemVariables variables)`
  - `.ctor(String text)`
  - `.ctor(String text, DrawerItemVariables variables)`
- **프로퍼티** (6개):
  - `public AutoFontSize AutoFontSize { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`

### `Tizen.UI.Components.Material.DropdownContainer`
- **상속**: `Tizen.UI.ViewGroup`
- **인터페이스**: `Tizen.UI.Components.INavigateBackHandler`, `Tizen.UI.Components.INavigationAnimation`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public Thickness BoundaryPadding { get; set; }`
  - `public Single ScrimBlur { get; set; }`
  - `public Color ScrimColor { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler Dismissed`
  - `public event EventHandler Hidden`

### `Tizen.UI.Components.Material.DropdownItem`
- **상속**: `Tizen.UI.Components.GroupSelectable`
- **인터페이스**: `Tizen.UI.Components.IFlexibleText`, `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(DropdownItemVariables variables)`
  - `.ctor(String text)`
  - `.ctor(String text, DropdownItemVariables variables)`
- **프로퍼티** (14개):
  - `public AutoFontSize AutoFontSize { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single IconHeight { get; set; }`
  - `public Color IconMultipliedColor { get; set; }`
  - `public IconPlacement IconPlacement { get; set; }`
  - `public String IconResourceUrl { get; set; }`
  - `public Single IconWidth { get; set; }`
  - `public Single ItemSpacing { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public Boolean SystemFontSizeScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`

### `Tizen.UI.Components.Material.DropdownList`1`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `System.Collections.Generic.ICollection`1<T>`, `System.Collections.Generic.IEnumerable`1<T>`, `System.Collections.Generic.IList`1<T>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.IAnchoredModal`, `Tizen.UI.Components.ISelectionGroup`
- **생성자**:
  - `.ctor()`
  - `.ctor(DropdownListVariables variables)`
- **프로퍼티** (12개):
  - `public Int32 Count { get; }`
  - `public Action<Object, EventArgs> DismissedCommand { get; set; }`
  - `public Boolean EmptySelectionAllowed { get; set; }`
  - `public Action<Object, EventArgs> HiddenCommand { get; set; }`
  - `public Boolean IsReadOnly { get; }`
  - `public T Item { get; set; }`
  - `public Action<Object, SelectionGroupItemClickedEventArgs> ItemClickedCommand { get; set; }`
  - `public IList<T> Items { get; }`
  - `public ModalPivot ModalPivot { get; set; }`
  - `public Int32 SelectedIndex { get; }`
  - `public T SelectedItem { get; }`
  - `public Action<Object, GroupSelectionChangedEventArgs> SelectionChangedCommand { get; set; }`
- **이벤트** (4개):
  - `public event EventHandler Dismissed`
  - `public event EventHandler Hidden`
  - `public event EventHandler<SelectionGroupItemClickedEventArgs> ItemClicked`
  - `public event EventHandler<GroupSelectionChangedEventArgs> SelectionChanged`

### `Tizen.UI.Components.Material.FloatingActionButtonScrollBar`
- **상속**: `Tizen.UI.Components.Material.ScrollBar`
- **생성자**:
  - `.ctor()`
  - `.ctor(ScrollBarVariables varables)`
  - `.ctor(ScrollBarVariables variables, IconButtonVariables iconVariables)`
- **프로퍼티** (5개):
  - `public IconButton FloatingActionButton { get; set; }`
  - `public Action FloatingActionButtonClicked { get; set; }`
  - `public IconButton FloatingIcon { get; }`
  - `public Point FloatingOffset { get; set; }`
  - `public FloatingOrigin FloatingOrigin { get; set; }`

### `Tizen.UI.Components.Material.GridView`
- **상속**: `Tizen.UI.Components.Material.LoopedAdapterView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (9개):
  - `public ViewTemplate GroupBodyTemplate { get; set; }`
  - `public ViewTemplate GroupHeaderTemplate { get; set; }`
  - `public IEdgeEffect HorizontalEdgeEffect { get; set; }`
  - `public Boolean IsGrouped { get; set; }`
  - `public Boolean IsHorizontal { get; set; }`
  - `public IItemAnimator ItemAnimator { get; set; }`
  - `public OverScrollMode OverScrollMode { get; set; }`
  - `public UInt32 SpanCount { get; set; }`
  - `public IEdgeEffect VerticalEdgeEffect { get; set; }`

### `Tizen.UI.Components.Material.IconButton`
- **상속**: `Tizen.UI.Components.Clickable`
- **생성자**:
  - `.ctor()`
  - `.ctor(IconButtonVariables variables)`
  - `.ctor(String iconResourceUrl)`
  - `.ctor(String iconResourceUrl, IconButtonVariables variables)`
- **프로퍼티** (6개):
  - `public CornerRadius IconCornerRadius { get; set; }`
  - `public Single IconHeight { get; set; }`
  - `public Color IconMultipliedColor { get; set; }`
  - `public String IconResourceUrl { get; set; }`
  - `public Single IconWidth { get; set; }`
  - `public Thickness Padding { get; set; }`

### `Tizen.UI.Components.Material.InputEditor`
- **상속**: `Tizen.UI.View`
- **인터페이스**: `Tizen.UI.Components.IDecoratableText`, `Tizen.UI.IFontSizeScale`, `Tizen.UI.IText`, `Tizen.UI.ITextAlignment`, `Tizen.UI.ITextEditable`, `Tizen.UI.ITextPadding`
- **생성자**:
  - `.ctor()`
  - `.ctor(InputEditorVariables variables)`
  - `.ctor(InputEditorVariables variables, InputEditorImpl impl)`
- **프로퍼티** (39개):
  - `public Single AdjustedFontSizeScale { get; }`
  - `public Int32 CursorPosition { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single FontSizeScale { get; set; }`
  - `public FontSlant FontSlant { get; set; }`
  - `public FontWeight FontWeight { get; set; }`
  - `public FontWidth FontWidth { get; set; }`
  - `public TextAlignment HorizontalAlignment { get; set; }`
  - `public Color InputColor { get; set; }`
  - `public String InputFontFamily { get; set; }`
  - `public Single InputFontSize { get; set; }`
  - `public FontSlant InputFontSlant { get; set; }`
  - `public FontWeight InputFontWeight { get; set; }`
  - `public FontWidth InputFontWidth { get; set; }`
  - `public InputMethodContext InputMethodContext { get; }`
  - `public Boolean IsAbsoluteLineHeight { get; set; }`
  - `public Boolean IsEditable { get; set; }`
  - `public Boolean IsMarkupEnabled { get; set; }`
  - `public Single LineHeight { get; set; }`
  - `public LineBreakMode LineWLineBreakModerapMode { get; set; }`
  - `public Single MaximumFontSizeScale { get; set; }`
  - `public Int32 MaximumLength { get; set; }`
  - `public Single MinimumFontSizeScale { get; set; }`
  - `public Nullable<Outline> Outline { get; set; }`
  - `public String PlaceholderText { get; set; }`
  - `public Color PlaceholderTextColor { get; set; }`
  - `public String SelectedText { get; }`
  - `public ClosedRange<Int32> SelectedTextIndex { get; }`
  - `public Boolean SelectionEnabled { get; set; }`
  - `public Nullable<Strikethrough> Strikethrough { get; set; }`
  - `public Boolean SystemFontFamilyEnabled { get; set; }`
  - `public Boolean SystemFontSizeScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`
  - `public Nullable<TextShadow> TextShadow { get; set; }`
  - `public Nullable<Underline> Underline { get; set; }`
  - `public TextAlignment VerticalAlignment { get; set; }`
- **이벤트** (8개):
  - `public event EventHandler<AnchorClickedEventArgs> AnchorClicked`
  - `public event EventHandler CursorMoved`
  - `public event EventHandler<String> KeyPressed`
  - `public event EventHandler MaximumLengthReached`
  - `public event EventHandler SelectionChanged`
  - `public event EventHandler SelectionCleared`
  - `public event EventHandler SelectionStarted`
  - `public event EventHandler TextChanged`

### `Tizen.UI.Components.Material.InputField`
- **상속**: `Tizen.UI.View`
- **인터페이스**: `Tizen.UI.Components.IDecoratableText`, `Tizen.UI.IFontSizeScale`, `Tizen.UI.IText`, `Tizen.UI.ITextAlignment`, `Tizen.UI.ITextEditable`, `Tizen.UI.ITextPadding`
- **생성자**:
  - `.ctor()`
  - `.ctor(InputFieldVariables variables)`
  - `.ctor(InputFieldVariables variables, InputFieldImpl impl)`
- **프로퍼티** (39개):
  - `public Single AdjustedFontSizeScale { get; }`
  - `public Boolean ClearFocusOnExecutionKey { get; set; }`
  - `public Int32 CursorPosition { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single FontSizeScale { get; set; }`
  - `public FontSlant FontSlant { get; set; }`
  - `public FontWeight FontWeight { get; set; }`
  - `public FontWidth FontWidth { get; set; }`
  - `public TextAlignment HorizontalAlignment { get; set; }`
  - `public Color InputColor { get; set; }`
  - `public String InputFontFamily { get; set; }`
  - `public Single InputFontSize { get; set; }`
  - `public FontSlant InputFontSlant { get; set; }`
  - `public FontWeight InputFontWeight { get; set; }`
  - `public FontWidth InputFontWidth { get; set; }`
  - `public InputMethodContext InputMethodContext { get; }`
  - `public Boolean IsEditable { get; set; }`
  - `public Boolean IsMarkupEnabled { get; set; }`
  - `public Single MaximumFontSizeScale { get; set; }`
  - `public Int32 MaximumLength { get; set; }`
  - `public Single MinimumFontSizeScale { get; set; }`
  - `public Nullable<Outline> Outline { get; set; }`
  - `public HiddenInputMode PasswordMode { get; set; }`
  - `public String PlaceholderText { get; set; }`
  - `public Color PlaceholderTextColor { get; set; }`
  - `public String SelectedText { get; }`
  - `public ClosedRange<Int32> SelectedTextIndex { get; }`
  - `public Boolean SelectionEnabled { get; set; }`
  - `public Boolean ShowPlaceholderTextOnFocus { get; set; }`
  - `public Nullable<Strikethrough> Strikethrough { get; set; }`
  - `public Boolean SystemFontFamilyEnabled { get; set; }`
  - `public Boolean SystemFontSizeScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`
  - `public Nullable<TextShadow> TextShadow { get; set; }`
  - `public Nullable<Underline> Underline { get; set; }`
  - `public TextAlignment VerticalAlignment { get; set; }`
- **이벤트** (8개):
  - `public event EventHandler<AnchorClickedEventArgs> AnchorClicked`
  - `public event EventHandler CursorMoved`
  - `public event EventHandler<String> KeyPressed`
  - `public event EventHandler MaximumLengthReached`
  - `public event EventHandler SelectionChanged`
  - `public event EventHandler SelectionCleared`
  - `public event EventHandler SelectionStarted`
  - `public event EventHandler TextChanged`

### `Tizen.UI.Components.Material.Label`
- **상속**: `Tizen.UI.View`
- **인터페이스**: `Tizen.UI.Components.IDecoratableText`, `Tizen.UI.Components.IFlexibleText`, `Tizen.UI.IFontSizeScale`, `Tizen.UI.IText`, `Tizen.UI.ITextAlignment`, `Tizen.UI.ITextFormatting`, `Tizen.UI.ITextPadding`
- **생성자**:
  - `.ctor()`
  - `.ctor(String text)`
  - `.ctor(LabelVariables variables)`
  - `.ctor(String text, LabelVariables variables)`
  - `.ctor(String text, LabelVariables variables, LabelImpl impl)`
- **프로퍼티** (30개):
  - `public Single AdjustedFontSize { get; }`
  - `public Single AdjustedFontSizeScale { get; }`
  - `public Color AnchorClickedColor { get; set; }`
  - `public Color AnchorColor { get; set; }`
  - `public AutoFontSize AutoFontSize { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single FontSizeScale { get; set; }`
  - `public FontSlant FontSlant { get; set; }`
  - `public FontWeight FontWeight { get; set; }`
  - `public FontWidth FontWidth { get; set; }`
  - `public TextAlignment HorizontalAlignment { get; set; }`
  - `public Boolean IsAbsoluteLineHeight { get; set; }`
  - `public Boolean IsMarkupEnabled { get; set; }`
  - `public Boolean IsMultiline { get; set; }`
  - `public Boolean IsTextCutout { get; set; }`
  - `public LineBreakMode LineBreakMode { get; set; }`
  - `public Single LineHeight { get; set; }`
  - `public Single MaximumFontSizeScale { get; set; }`
  - `public Single MinimumFontSizeScale { get; set; }`
  - `public Nullable<Outline> Outline { get; set; }`
  - `public Nullable<Strikethrough> Strikethrough { get; set; }`
  - `public Boolean SystemFontFamilyEnabled { get; set; }`
  - `public Boolean SystemFontSizeScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`
  - `public Nullable<TextShadow> TextShadow { get; set; }`
  - `public Nullable<Underline> Underline { get; set; }`
  - `public TextAlignment VerticalAlignment { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler<AnchorClickedEventArgs> AnchorClicked`
  - `public event EventHandler FontSizeAdjusted`

### `Tizen.UI.Components.Material.LevelBar`
- **상속**: `Tizen.UI.Components.InteractiveProgress`
- **생성자**:
  - `.ctor(Single minimumValue, Single maximumValue, Int32 valueStepCount)`
  - `.ctor(Single minimumValue, Single maximumValue, Int32 valueStepCount, LevelBarVariables variables)`
- **프로퍼티** (2개):
  - `public Thickness Padding { get; set; }`
  - `public Single TrackThickness { get; set; }`

### `Tizen.UI.Components.Material.ListView`
- **상속**: `Tizen.UI.Components.Material.LoopedAdapterView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (13개):
  - `public ViewTemplate DividerTemplate { get; set; }`
  - `public ViewTemplate GroupBodyTemplate { get; set; }`
  - `public ViewTemplate GroupFooterTemplate { get; set; }`
  - `public ViewTemplate GroupHeaderTemplate { get; set; }`
  - `public Boolean HasDivider { get; set; }`
  - `public IEdgeEffect HorizontalEdgeEffect { get; set; }`
  - `public Boolean IsGrouped { get; set; }`
  - `public Boolean IsHorizontal { get; set; }`
  - `public Boolean IsStickyHeader { get; set; }`
  - `public IItemAnimator ItemAnimator { get; set; }`
  - `public ItemTouchHelper ItemTouchHelper { get; set; }`
  - `public OverScrollMode OverScrollMode { get; set; }`
  - `public IEdgeEffect VerticalEdgeEffect { get; set; }`

### `Tizen.UI.Components.Material.LoopedAdapterView`
- **상속**: `Tizen.UI.Components.Material.AdapterView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public Boolean IsLooping { get; set; }`

### `Tizen.UI.Components.Material.LottieImage`
- **상속**: `Tizen.UI.Components.Material.Image`
- **인터페이스**: `Tizen.UI.Components.IAnimatedImage`
- **생성자**:
  - `.ctor()`
  - `.ctor(String resourceUrl)`
- **프로퍼티** (9개):
  - `public Int32 CurrentFrame { get; set; }`
  - `public Single FrameSpeedFactor { get; set; }`
  - `public Boolean IsLooping { get; set; }`
  - `public AnimationState PlayState { get; }`
  - `public Boolean RedrawInScalingDown { get; set; }`
  - `public Int32 RepeatCount { get; set; }`
  - `public AnimationRepeatMode RepeatMode { get; set; }`
  - `public AnimationStopBehavior StopBehavior { get; set; }`
  - `public Int32 TotalFrame { get; }`
- **이벤트** (1개):
  - `public event EventHandler Finished`

### `Tizen.UI.Components.Material.LottieImageTimeCounter`
- **상속**: `Tizen.UI.Components.TimeCounter`
- **생성자**:
  - `.ctor(String resourceUrl)`
  - `.ctor(Int32 totalTimeInMilliseconds, String resourceUrl)`
- **프로퍼티** (2개):
  - `public LottieImage LottieImage { get; }`
  - `public Boolean UseReverseFrameIndex { get; set; }`

### `Tizen.UI.Components.Material.MoreButton`
- **상속**: `Tizen.UI.Components.Material.IconButton`
- **인터페이스**: `Tizen.UI.Components.Material.IAppBarContent`
- **생성자**:
  - `.ctor()`
  - `.ctor(IconButtonVariables variables)`
- **프로퍼티** (1개):
  - `public IAnchoredModal ModalContent { get; set; }`

### `Tizen.UI.Components.Material.PageIndicator`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `Tizen.UI.Components.Material.IPageIndicator`
- **생성자**:
  - `.ctor()`
  - `.ctor(PageIndicatorVariables variables)`
- **프로퍼티** (6개):
  - `public Int32 CurrentPage { get; set; }`
  - `public View Item { get; set; }`
  - `public PageAdapter PageAdapter { get; set; }`
  - `public Int32 PageCount { get; }`
  - `public ViewTemplate PageDotTemplate { get; set; }`
  - `public Single Spacing { get; set; }`

### `Tizen.UI.Components.Material.PageScroller`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `System.Collections.Generic.ICollection`1<Tizen.UI.View>`, `System.Collections.Generic.IEnumerable`1<Tizen.UI.View>`, `System.Collections.Generic.IList`1<Tizen.UI.View>`, `System.Collections.IEnumerable`, `Tizen.UI.Components.Material.IPager`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (11개):
  - `public IList<View> Children { get; }`
  - `public Int32 CurrentPage { get; }`
  - `public Boolean IsHorizontal { get; set; }`
  - `public Boolean IsScrolling { get; }`
  - `public View Item { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public PageAdapter PageAdapter { get; set; }`
  - `public Int32 PageCount { get; }`
  - `public SnapPointsAlignment SnapPointsAlignment { get; set; }`
  - `public SnapPointsType SnapPointType { get; set; }`
  - `public Single Spacing { get; set; }`
- **이벤트** (6개):
  - `public event EventHandler DragFinished`
  - `public event EventHandler<DragEventArgs> Dragging`
  - `public event EventHandler DragStarted`
  - `public event EventHandler ScrollFinished`
  - `public event EventHandler Scrolling`
  - `public event EventHandler ScrollStarted`

### `Tizen.UI.Components.Material.PickerBase`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor(ClosedRange<Int32> range, PickerVariables variables)`
- **프로퍼티** (4개):
  - `public ReadOnlyCollection<String> DisplayedValues { get; set; }`
  - `public ClosedRange<Int32> Range { get; set; }`
  - `public Int32 Step { get; set; }`
  - `public Int32 Value { get; set; }`
- **이벤트** (3개):
  - `public event EventHandler EditModeChanged`
  - `public event EventHandler<Boolean> InputPanelVisibilityChanged`
  - `public event EventHandler ValueChanged`

### `Tizen.UI.Components.Material.PickerInputField`
- **상속**: `Tizen.UI.Components.Material.InputField`
- **생성자**:
  - `.ctor(PickerBase picker)`
- **프로퍼티** (2개):
  - `public PickerBase Picker { get; }`
  - `public PickerInputFilter PickerInputFilter { get; }`

### `Tizen.UI.Components.Material.PickerListBase`
- **상속**: `Tizen.UI.Components.Recycler.RecyclerView`
- **생성자**:
  - `.ctor(Picker picker)`
- **프로퍼티** (2개):
  - `public Boolean IsLooping { get; set; }`
  - `public PickerListAdapter PickerAdapter { get; }`

### `Tizen.UI.Components.Material.PickerListItemView`
- **상속**: `Tizen.UI.Components.Material.Label`
- **인터페이스**: `Tizen.UI.IBindableView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public Object BindingContext { get; set; }`

### `Tizen.UI.Components.Material.ProgressBar`
- **상속**: `Tizen.UI.Components.Progress`
- **생성자**:
  - `.ctor()`
  - `.ctor(ProgressBarVariables variables)`
  - `.ctor(Single minimumValue, Single maximumValue)`
  - `.ctor(Single minimumValue, Single maximumValue, ProgressBarVariables variables)`
- **프로퍼티** (5개):
  - `public Int32 DividerStepCount { get; set; }`
  - `public Boolean IsReversed { get; set; }`
  - `public Color TrackColor { get; set; }`
  - `public Single TrackThickness { get; set; }`
  - `public Color TrailColor { get; set; }`

### `Tizen.UI.Components.Material.ProgressCircle`
- **상속**: `Tizen.UI.Components.Progress`
- **생성자**:
  - `.ctor()`
  - `.ctor(ProgressCircleVariables variables)`
  - `.ctor(Single minimumValue, Single maximumValue)`
  - `.ctor(Single minimumValue, Single maximumValue, ProgressCircleVariables variables)`
- **프로퍼티** (3개):
  - `public Color TrackColor { get; set; }`
  - `public Single TrackThickness { get; set; }`
  - `public Color TrailColor { get; set; }`

### `Tizen.UI.Components.Material.ProgressRing`
- **상속**: `Tizen.UI.Primitives2D.VectorView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (4개):
  - `public Single Progress { get; set; }`
  - `public Single Thickness { get; set; }`
  - `public Color TrackColor { get; set; }`
  - `public Color TrailColor { get; set; }`

### `Tizen.UI.Components.Material.ProgressTimer`
- **상속**: `Tizen.UI.Components.TimeCounter`
- **생성자**:
  - `.ctor()`
  - `.ctor(Int32 totalTimeInMilliseconds)`
  - `.ctor(ProgressTimerVariables variables)`
- **프로퍼티** (5개):
  - `public Boolean IsPaused { get; set; }`
  - `public Boolean IsReversed { get; set; }`
  - `public Color TrackColor { get; set; }`
  - `public Single TrackThickness { get; set; }`
  - `public Color TrailColor { get; set; }`
- **이벤트** (1개):
  - `public event EventHandler PausedChanged`

### `Tizen.UI.Components.Material.Scaffold`
- **상속**: `Tizen.UI.Components.ScaffoldBase`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public AppBar AppBar { get; set; }`
  - `public View BottomBar { get; set; }`
  - `public View Content { get; set; }`

### `Tizen.UI.Components.Material.Slider`
- **상속**: `Tizen.UI.Components.InteractiveProgress`
- **생성자**:
  - `.ctor(Single minimumValue, Single maximumValue)`
  - `.ctor(Single minimumValue, Single maximumValue, SliderVariables variables)`
- **프로퍼티** (6개):
  - `public Func<Slider, String> AccessibilityValueTextGenerator { get; set; }`
  - `public Single KeyStep { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `public Color TrackColor { get; set; }`
  - `public Single TrackThickness { get; set; }`
  - `public Color TrailColor { get; set; }`

### `Tizen.UI.Components.Material.SmartTip`
- **상속**: `Tizen.UI.Components.Material.SmartTipBase`
- **인터페이스**: `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(String text)`
  - `.ctor(String text, SmartTipVariables variables)`
- **프로퍼티** (10개):
  - `public Thickness ContentPadding { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single FontSizeScale { get; set; }`
  - `public TextAlignment HorizontalAlignment { get; set; }`
  - `public Boolean IsMultiline { get; set; }`
  - `public Boolean SystemFontSizeScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextAlignment VerticalAlignment { get; set; }`

### `Tizen.UI.Components.Material.SmartTipBackground`
- **상속**: `Tizen.UI.Primitives2D.VectorView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (9개):
  - `public Single ArrowHeight { get; set; }`
  - `public SmartTipArrowPosition ArrowPosition { get; set; }`
  - `public Single ArrowWidth { get; set; }`
  - `public CornerRadius BubbleCornerRadius { get; set; }`
  - `public Color FillColor { get; set; }`
  - `public Color StrokeColor { get; set; }`
  - `public Single StrokeWidth { get; set; }`
  - `public Color UpperAreaFillColor { get; set; }`
  - `public Single UpperAreaThickness { get; set; }`

### `Tizen.UI.Components.Material.SmartTipBase`
- **상속**: `Tizen.UI.ContentView`
- **생성자**:
  - `.ctor()`
  - `.ctor(SmartTipViewVariables variables)`
- **프로퍼티** (9개):
  - `public Single ArrowHeight { get; set; }`
  - `public SmartTipArrowPosition ArrowPosition { get; set; }`
  - `public Single ArrowWidth { get; set; }`
  - `public Action<Object, EventArgs> DismissedCommand { get; set; }`
  - `public Action<Object, EventArgs> HiddenCommand { get; set; }`
  - `public CornerRadius ShapeCornerRadius { get; set; }`
  - `public Color ShapeFillColor { get; set; }`
  - `public IEnumerable<Shadow> ShapeShadows { get; set; }`
  - `public Color ShapeStrokeColor { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler Dismissed`
  - `public event EventHandler Hidden`

### `Tizen.UI.Components.Material.SmartTipContainer`
- **상속**: `Tizen.UI.ViewGroup`
- **인터페이스**: `Tizen.UI.Components.INavigateBackHandler`, `Tizen.UI.Components.INavigationAnimation`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public Thickness BoundaryPadding { get; set; }`
  - `public Single ScrimBlur { get; set; }`
  - `public Color ScrimColor { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler Dismissed`
  - `public event EventHandler Hidden`

### `Tizen.UI.Components.Material.SmartTipMenu`
- **상속**: `Tizen.UI.Components.Material.SmartTipBase`
- **생성자**:
  - `.ctor()`
  - `.ctor(SmartTipViewVariables variables)`
- **프로퍼티** (3개):
  - `public View Content { get; set; }`
  - `public View TitleContent { get; set; }`
  - `public Color TitleFillColor { get; set; }`

### `Tizen.UI.Components.Material.SmartTipView`
- **상속**: `Tizen.UI.Components.Material.SmartTipBase`
- **생성자**:
  - `.ctor()`
  - `.ctor(SmartTipViewVariables variables)`
- **프로퍼티** (1개):
  - `public View Content { get; set; }`

### `Tizen.UI.Components.Material.SnackBar`
- **상속**: `Tizen.UI.Layouts.Grid`
- **인터페이스**: `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(SnackBarVariables variables)`
  - `.ctor(String text)`
  - `.ctor(String text, UInt32 duration)`
  - `.ctor(String text, UInt32 duration, SnackBarVariables variables)`
- **프로퍼티** (8개):
  - `public String ActionButtonText { get; set; }`
  - `public Color ActionButtonTextColor { get; set; }`
  - `public UInt32 Duration { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single ItemSpacing { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
- **이벤트** (3개):
  - `public event EventHandler<SnackBarActionEventArgs> ActionButtonClicked`
  - `public event EventHandler Hidden`
  - `public event EventHandler Shown`

### `Tizen.UI.Components.Material.SpinnerButton`
- **상속**: `Tizen.UI.Components.Clickable`
- **인터페이스**: `Tizen.UI.Components.IFlexibleText`, `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(SpinnerButtonVariables variables)`
- **프로퍼티** (10개):
  - `public AutoFontSize AutoFontSize { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Color IconMixColor { get; set; }`
  - `public Single ItemSpacing { get; set; }`
  - `public IAnchoredModal ModalContent { get; set; }`
  - `public Boolean SystemFontSizeScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`

### `Tizen.UI.Components.Material.TabItem`
- **상속**: `Tizen.UI.Components.GroupSelectable`
- **인터페이스**: `Tizen.UI.Components.IFlexibleText`, `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(TabItemVariables variables)`
  - `.ctor(String text)`
  - `.ctor(String text, TabItemVariables variables)`
- **프로퍼티** (12개):
  - `public AutoFontSize AutoFontSize { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single IconHeight { get; set; }`
  - `public Color IconMultipliedColor { get; set; }`
  - `public String IconResourceUrl { get; set; }`
  - `public Single IconWidth { get; set; }`
  - `public Single ItemSpacing { get; set; }`
  - `public Boolean SystemFontSizeScaleEnabled { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextOverflow TextOverflow { get; set; }`

### `Tizen.UI.Components.Material.Toast`
- **상속**: `Tizen.UI.Layouts.Grid`
- **인터페이스**: `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
  - `.ctor(ToastVariables variables)`
  - `.ctor(String text)`
  - `.ctor(String text, UInt32 duration)`
  - `.ctor(String text, UInt32 duration, ToastVariables variables)`
- **프로퍼티** (10개):
  - `public UInt32 Duration { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single IconHeight { get; set; }`
  - `public Color IconMultipliedColor { get; set; }`
  - `public String IconResourceUrl { get; set; }`
  - `public Single IconWidth { get; set; }`
  - `public Single ItemSpacing { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler Hidden`
  - `public event EventHandler Shown`

## 📦 Tizen.UI.Layouts

### `Tizen.UI.Layouts.FlexBox`
- **상속**: `Tizen.UI.Layouts.Layout`
- **인터페이스**: `Tizen.UI.Layouts.IFlexBox`, `Tizen.UI.Layouts.ILayout`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (6개):
  - `public FlexAlignContent AlignContent { get; set; }`
  - `public FlexAlignItems AlignItems { get; set; }`
  - `public FlexDirection Direction { get; set; }`
  - `public FlexJustify JustifyContent { get; set; }`
  - `public FlexPosition Position { get; set; }`
  - `public FlexWrap Wrap { get; set; }`

### `Tizen.UI.Layouts.Grid`
- **상속**: `Tizen.UI.Layouts.Layout`
- **인터페이스**: `Tizen.UI.Layouts.IGridLayout`, `Tizen.UI.Layouts.ILayout`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (4개):
  - `public IList<GridColumnDefinition> ColumnDefinitions { get; set; }`
  - `public Single ColumnSpacing { get; set; }`
  - `public IList<GridRowDefinition> RowDefinitions { get; set; }`
  - `public Single RowSpacing { get; set; }`

### `Tizen.UI.Layouts.Layout`
- **상속**: `Tizen.UI.ViewGroup`
- **인터페이스**: `Tizen.UI.Layouts.ILayout`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (3개):
  - `public Boolean IsManualLayout { get; set; }`
  - `public Boolean IsOnPseudoLayout { get; set; }`
  - `public Thickness Padding { get; set; }`

### `Tizen.UI.Layouts.ScrollBar`
- **상속**: `Tizen.UI.ViewGroup`
- **인터페이스**: `System.IDisposable`, `Tizen.UI.IScrollBar`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (8개):
  - `public Color BarColor { get; set; }`
  - `public Single BarMargin { get; set; }`
  - `public Single BarMinSize { get; set; }`
  - `public Single BarWidth { get; set; }`
  - `public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }`
  - `public Point ScrollPosition { get; set; }`
  - `public View Target { get; }`
  - `public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }`

### `Tizen.UI.Layouts.ScrollLayout`
- **상속**: `Tizen.UI.Layouts.Layout`
- **인터페이스**: `Tizen.UI.IDescendantFocusObserver`, `Tizen.UI.IScrollable`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (10개):
  - `public View Content { get; set; }`
  - `public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }`
  - `public Boolean IsScrolling { get; set; }`
  - `public IScrollBar ScrollBar { get; set; }`
  - `public ScrollDirection ScrollDirection { get; set; }`
  - `public Func<Point, Point> ScrollingDestinationHandler { get; set; }`
  - `public Point ScrollPosition { get; }`
  - `public Size ScrollSize { get; set; }`
  - `public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }`
  - `public Rect ViewPort { get; }`
- **이벤트** (6개):
  - `public event EventHandler<DragEventArgs> DragFinished`
  - `public event EventHandler<DragEventArgs> Dragging`
  - `public event EventHandler<DragEventArgs> DragStarted`
  - `public event EventHandler<ScrollEventArgs> ScrollFinished`
  - `public event EventHandler<ScrollEventArgs> Scrolling`
  - `public event EventHandler<ScrollEventArgs> ScrollStarted`

### `Tizen.UI.Layouts.StackBase`
- **상속**: `Tizen.UI.Layouts.Layout`
- **인터페이스**: `Tizen.UI.Layouts.ILayout`, `Tizen.UI.Layouts.IStackLayout`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (2개):
  - `public LayoutAlignment ItemAlignment { get; set; }`
  - `public Single Spacing { get; set; }`

## 📦 Tizen.UI.Markdown

### `Tizen.UI.Markdown.MarkdownView`
- **상속**: `Tizen.UI.Layouts.VStack`
- **인터페이스**: `Tizen.UI.Markdown.IContainerBlock`
- **생성자**:
  - `.ctor()`
  - `.ctor(MarkdownStyle style)`
- **프로퍼티** (2개):
  - `public MarkdownStyle Style { get; }`
  - `public String Text { get; set; }`

### `Tizen.UI.Markdown.MarkdownUI.UICode`
- **상속**: `Tizen.UI.Layouts.VStack`
- **생성자**:
  - `.ctor(String language, String text, Int32 indent, CodeStyle codeStyle)`
- **프로퍼티** (3개):
  - `public String Code { get; set; }`
  - `public Int32 ContentHash { get; set; }`
  - `public String Language { get; set; }`

### `Tizen.UI.Markdown.MarkdownUI.UIHeading`
- **상속**: `Tizen.UI.Markdown.MarkdownUI.UIParagraph`
- **생성자**:
  - `.ctor(String text, Int32 level, HeadingStyle headingStyle, ParagraphStyle paragraphStyle)`
- **프로퍼티** (1개):
  - `public Int32 Level { get; set; }`

### `Tizen.UI.Markdown.MarkdownUI.UIListItemParagraph`
- **상속**: `Tizen.UI.Layouts.HStack`
- **생성자**:
  - `.ctor(String text, Boolean isOrdered, Int32 numberOrDepth, ListStyle listStyle, ParagraphStyle paragraphStyle)`
- **프로퍼티** (1개):
  - `public String Text { get; set; }`

## 📦 Tizen.UI.Primitives2D

### `Tizen.UI.Primitives2D.CustomShape`
- **상속**: `Tizen.UI.Primitives2D.Shape`
- **생성자**:
  - `.ctor(IEnumerable<IPath> path)`
- **프로퍼티** (1개):
  - `public IEnumerable<IPath> Path { get; set; }`

### `Tizen.UI.Primitives2D.Drawable`
- **상속**: `Tizen.UI.NObject`
- **프로퍼티** (1개):
  - `public Rect BoundingBox { get; }`

### `Tizen.UI.Primitives2D.DrawableGroup`
- **상속**: `Tizen.UI.Primitives2D.Drawable`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public IReadOnlyCollection<Drawable> Drawables { get; }`

### `Tizen.UI.Primitives2D.Ellipse`
- **상속**: `Tizen.UI.Primitives2D.Shape`
- **생성자**:
  - `.ctor(Single centerX, Single centerY, Single radiusX, Single radiusY)`
- **프로퍼티** (4개):
  - `public Single CenterX { get; set; }`
  - `public Single CenterY { get; set; }`
  - `public Single RadiusX { get; set; }`
  - `public Single RadiusY { get; set; }`

### `Tizen.UI.Primitives2D.GradientPaint`
- **상속**: `Tizen.UI.NObject`
- **인터페이스**: `Tizen.UI.Primitives2D.IPaint`
- **프로퍼티** (7개):
  - `public FillRule FillRule { get; set; }`
  - `public GradientStop[] GradientStops { get; set; }`
  - `public SpreadType Spread { get; set; }`
  - `public StrokeCap StrokeCap { get; set; }`
  - `public Single[] StrokeDashArray { get; set; }`
  - `public StrokeJoin StrokeJoin { get; set; }`
  - `public Single StrokeWidth { get; set; }`

### `Tizen.UI.Primitives2D.ImageDrawable`
- **상속**: `Tizen.UI.Primitives2D.Drawable`
- **생성자**:
  - `.ctor(String url, Single width, Single height)`
- **프로퍼티** (3개):
  - `public Single Height { get; set; }`
  - `public String Url { get; set; }`
  - `public Single Width { get; set; }`

### `Tizen.UI.Primitives2D.LinearGradientPaint`
- **상속**: `Tizen.UI.Primitives2D.GradientPaint`
- **생성자**:
  - `.ctor()`
  - `.ctor(Single startPointX, Single startPointY, Single endPointX, Single endPointY)`
- **프로퍼티** (2개):
  - `public Point EndPoint { get; set; }`
  - `public Point StartPoint { get; set; }`

### `Tizen.UI.Primitives2D.RadialGradientPaint`
- **상속**: `Tizen.UI.Primitives2D.GradientPaint`
- **생성자**:
  - `.ctor()`
  - `.ctor(Single centerX, Single centerY, Single radius)`
- **프로퍼티** (2개):
  - `public Point Center { get; set; }`
  - `public Single Radius { get; set; }`

### `Tizen.UI.Primitives2D.Rectangle`
- **상속**: `Tizen.UI.Primitives2D.Shape`
- **생성자**:
  - `.ctor(Single x, Single y, Single width, Single height)`
- **프로퍼티** (4개):
  - `public Single Height { get; set; }`
  - `public Single Width { get; set; }`
  - `public Single X { get; set; }`
  - `public Single Y { get; set; }`

### `Tizen.UI.Primitives2D.RoundRectangle`
- **상속**: `Tizen.UI.Primitives2D.Shape`
- **생성자**:
  - `.ctor(Single x, Single y, Single width, Single height, Single radiusX, Single radiusY)`
- **프로퍼티** (6개):
  - `public Single Height { get; set; }`
  - `public Single RadiusX { get; set; }`
  - `public Single RadiusY { get; set; }`
  - `public Single Width { get; set; }`
  - `public Single X { get; set; }`
  - `public Single Y { get; set; }`

### `Tizen.UI.Primitives2D.VectorView`
- **상속**: `Tizen.UI.View`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public IReadOnlyCollection<Drawable> Drawables { get; }`

## 📦 Tizen.UI.Scene3D

### `Tizen.UI.Scene3D.Camera`
- **상속**: `Tizen.UI.Scene3D.SceneObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (7개):
  - `public Single AspectRatio { get; set; }`
  - `public Single FarPlaneDistance { get; set; }`
  - `public Single FieldOfView { get; set; }`
  - `public Single NearPlaneDistance { get; set; }`
  - `public Single OrthographicSize { get; set; }`
  - `public ProjectionDirection ProjectionDirection { get; set; }`
  - `public Boolean UseOrthographicProjection { get; set; }`

### `Tizen.UI.Scene3D.Light`
- **상속**: `Tizen.UI.Scene3D.SceneObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (4개):
  - `public Boolean IsShadowEnabled { get; set; }`
  - `public Boolean IsShadowSoftFilteringEnabled { get; set; }`
  - `public Color MultipliedColor { get; set; }`
  - `public Single ShadowIntensity { get; set; }`

### `Tizen.UI.Scene3D.Material`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (9개):
  - `public MaterialAlphaMode AlphaMode { get; set; }`
  - `public Color BaseColorFactor { get; set; }`
  - `public String BaseColorUrl { get; set; }`
  - `public Single MetallicFactor { get; set; }`
  - `public String MetallicRoughnessUrl { get; set; }`
  - `public String Name { get; set; }`
  - `public Single NormalScale { get; set; }`
  - `public String NormalUrl { get; set; }`
  - `public Single RoughnessFactor { get; set; }`

### `Tizen.UI.Scene3D.ModelPrimitive`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (2개):
  - `public Geometry Geometry { get; set; }`
  - `public Material Material { get; set; }`

### `Tizen.UI.Scene3D.Panel`
- **상속**: `Tizen.UI.Scene3D.SceneObject`
- **인터페이스**: `Tizen.UI.IParentObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public View Content { get; set; }`

### `Tizen.UI.Scene3D.Scene3DView`
- **상속**: `Tizen.UI.ViewGroup`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (6개):
  - `public IReadOnlyList<Camera> Cameras { get; }`
  - `public Camera DefaultCamera { get; }`
  - `public Single ImageBasedLightScaleFactor { get; set; }`
  - `public IReadOnlyList<Light> Lights { get; }`
  - `public IReadOnlyList<Model3D> Models { get; }`
  - `public Boolean UseFramebuffer { get; set; }`
- **이벤트** (2개):
  - `public event EventHandler CameraTransitionFinished`
  - `public event EventHandler ResourceReady`

### `Tizen.UI.Scene3D.SceneObject`
- **상속**: `Tizen.UI.NObject`
- **프로퍼티** (12개):
  - `public Boolean IsVisible { get; set; }`
  - `public String Name { get; set; }`
  - `public Single Opacity { get; set; }`
  - `public SceneObject Parent { get; }`
  - `public NObject ParentObject { get; }`
  - `public Point3D ParentOrigin { get; set; }`
  - `public Point3D PivotPoint { get; set; }`
  - `public Point3D Position { get; set; }`
  - `public Boolean PositionUsesPivotPoint { get; set; }`
  - `public Quaternion Rotation { get; set; }`
  - `public Size3D Scale { get; set; }`
  - `public Size3D Size { get; set; }`

### `Tizen.UI.Scene3D.SceneObjectGroup`1`
- **상속**: `Tizen.UI.Scene3D.SceneObject`
- **인터페이스**: `System.Collections.Generic.ICollection`1<T>`, `System.Collections.Generic.IEnumerable`1<T>`, `System.Collections.Generic.IList`1<T>`, `System.Collections.IEnumerable`
- **프로퍼티** (4개):
  - `public IList<T> Children { get; }`
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public T Item { get; set; }`

## 📦 Tizen.UI.Skia

### `Tizen.UI.Skia.CustomRenderingView`
- **상속**: `Tizen.UI.ImageView`
- **생성자**:
  - `.ctor()`
- **이벤트** (1개):
  - `public event EventHandler<SKPaintSurfaceEventArgs> PaintSurface`

### `Tizen.UI.Skia.SKCanvasView`
- **상속**: `Tizen.UI.Skia.CustomRenderingView`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (1개):
  - `public Boolean IgnorePixelScaling { get; set; }`

## 📦 Tizen.UI.Visuals

### `Tizen.UI.Visuals.ColorVisual`
- **상속**: `Tizen.UI.Visuals.RoundedVisual`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (2개):
  - `public Single BlurRadius { get; set; }`
  - `public VisualCutoutPolicy CutoutPolicy { get; set; }`

### `Tizen.UI.Visuals.ImageVisual`
- **상속**: `Tizen.UI.Visuals.RoundedVisual`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (18개):
  - `public String AlphaMaskUrl { get; set; }`
  - `public Boolean CropToMask { get; set; }`
  - `public Single DesiredHeight { get; set; }`
  - `public Single DesiredWidth { get; set; }`
  - `public Boolean FastTrackUploading { get; set; }`
  - `public FittingMode FittingMode { get; set; }`
  - `public Boolean ImageLoadWithViewSize { get; set; }`
  - `public ImageLoadPolicy LoadPolicy { get; set; }`
  - `public Single MaskContentScale { get; set; }`
  - `public ImageMaskingMode MaskingMode { get; set; }`
  - `public Boolean OrientationCorrection { get; set; }`
  - `public Rect PixelArea { get; set; }`
  - `public Boolean PreMultipliedAlpha { get; set; }`
  - `public ImageReleasePolicy ReleasePolicy { get; set; }`
  - `public String ResourceUrl { get; set; }`
  - `public Boolean SynchronousLoading { get; set; }`
  - `public ImageWrapMode WrapModeU { get; set; }`
  - `public ImageWrapMode WrapModeV { get; set; }`

### `Tizen.UI.Visuals.NPatchVisual`
- **상속**: `Tizen.UI.Visuals.ImageVisual`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (4개):
  - `public Single AuxiliaryImageAlpha { get; set; }`
  - `public String AuxiliaryImageUrl { get; set; }`
  - `public Thickness Border { get; set; }`
  - `public Boolean BorderOnly { get; set; }`

### `Tizen.UI.Visuals.RoundedVisual`
- **상속**: `Tizen.UI.Visuals.VisualObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (5개):
  - `public Color BorderlineColor { get; set; }`
  - `public Single BorderlineOffset { get; set; }`
  - `public Single BorderlineWidth { get; set; }`
  - `public CornerRadius CornerRadius { get; set; }`
  - `public CornerRadius CornerSquareness { get; set; }`

### `Tizen.UI.Visuals.TextVisual`
- **상속**: `Tizen.UI.Visuals.VisualObject`
- **인터페이스**: `Tizen.UI.IText`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (8개):
  - `public Boolean EnableMarkup { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public TextAlignment HorizontalAlignment { get; set; }`
  - `public Boolean MultiLine { get; set; }`
  - `public String Text { get; set; }`
  - `public Color TextColor { get; set; }`
  - `public TextAlignment VerticalAlignment { get; set; }`

### `Tizen.UI.Visuals.VisualObject`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor()`
- **프로퍼티** (12개):
  - `public Color Color { get; set; }`
  - `public Single Height { get; set; }`
  - `public Single ModifyHeight { get; set; }`
  - `public Single ModifyWidth { get; set; }`
  - `public Single Opacity { get; set; }`
  - `public VisualAlign Origin { get; set; }`
  - `public VisualAlign PivotPoint { get; set; }`
  - `public Int32 SiblingOrder { get; set; }`
  - `public TransformFlags TransformFlags { get; set; }`
  - `public Single Width { get; set; }`
  - `public Single X { get; set; }`
  - `public Single Y { get; set; }`

### `Tizen.UI.Visuals.Internal.VisualObjectContainer`
- **상속**: `Tizen.UI.NObject`
- **인터페이스**: `System.Collections.Generic.ICollection`1<Tizen.UI.Visuals.VisualObject>`, `System.Collections.Generic.IEnumerable`1<Tizen.UI.Visuals.VisualObject>`, `System.Collections.Generic.IList`1<Tizen.UI.Visuals.VisualObject>`, `System.Collections.IEnumerable`
- **생성자**:
  - `.ctor(View owner, ContainerRange range)`
- **프로퍼티** (3개):
  - `public Int32 Count { get; }`
  - `public Boolean IsReadOnly { get; }`
  - `public VisualObject Item { get; set; }`

## 📦 Tizen.UI.Widget

### `Tizen.UI.Widget.DaliNativeWidget`
- **상속**: `Tizen.UI.NObject`
- **생성자**:
  - `.ctor(String[] args)`
- **프로퍼티** (11개):
  - `public Action<IntPtr> AppControlHandler { get; set; }`
  - `public Action<Int32> BatteryLowHandler { get; set; }`
  - `public Action CreatedHandler { get; set; }`
  - `public DaliNativeWidget Current { get; set; }`
  - `public Action<Int32> DeviceOrientationChangedHandler { get; set; }`
  - `public Action<String> LanguageChangedHandler { get; set; }`
  - `public Action<Int32> MemoryLowHandler { get; set; }`
  - `public Action PausedHandler { get; set; }`
  - `public Action<String> RegionChangedHandler { get; set; }`
  - `public Action ResumedHandler { get; set; }`
  - `public Action TerminatedHandler { get; set; }`

## 📦 Tizen.UI.WindowBorder

### `Tizen.UI.WindowBorder.BorderView`
- **상속**: `Tizen.UI.ContentView`
- **인터페이스**: `Tizen.UI.WindowBorder.IWindowBorderProvider`
- **생성자**:
  - `.ctor()`
  - `.ctor(ViewTemplate header)`
  - `.ctor(ViewTemplate header, ViewTemplate footer)`
- **프로퍼티** (7개):
  - `public Color BorderActiveColor { get; set; }`
  - `public Thickness BorderArea { get; set; }`
  - `public Color BorderColor { get; set; }`
  - `public Single DefaultBorderWidth { get; set; }`
  - `public Boolean EnableOverlayBorder { get; set; }`
  - `public ViewTemplate FooterTemplate { get; }`
  - `public ViewTemplate HeaderTemplate { get; }`

