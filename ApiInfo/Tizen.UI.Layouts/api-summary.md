# API Summary: Tizen.UI.Layouts

Source: `c:\workspace\temp\Generate_TizenApp\Packages\Tizen.UI.Layouts.1.0.0-rc.5\lib\net8.0-tizen10.0\Tizen.UI.Layouts.dll`
Generated (UTC): 2026-03-07T11:20:28.6123489+00:00

## Namespace `Tizen.UI.Layouts`

### class `AbsoluteLayout`

- Base: `Tizen.UI.Layouts.Layout`
- Members:
  - `.ctor()`
  - `public Void Add(View view, Rect bounds, AbsoluteLayoutFlags flags)`
  - `protected ILayoutManager get_LayoutManager()`
  - `protected ILayoutManager LayoutManager { get; }`

### class `AbsoluteLayoutExtensions`

- Base: `System.Object`
- Members:
  - `public static TView LayoutBounds<TView>(TView view, Single x, Single y, Single width, Single height) where TView : View`
  - `public static TView LayoutFlags<TView>(TView view, AbsoluteLayoutFlags flag) where TView : View`

### enum `AbsoluteLayoutFlags`

- Base: `System.Enum`
- Members:

### class `AbsoluteLayoutManager`

- Base: `Tizen.UI.Layouts.LayoutManager`
- Members:
  - `.ctor(ILayout absoluteLayout)`
  - `public Size ArrangeChildren(Rect bounds)`
  - `public ILayout get_AbsoluteLayout()`
  - `private static Boolean HasFlag(AbsoluteLayoutFlags a, AbsoluteLayoutFlags b)`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`
  - `private static Single ResolveChildMeasureConstraint(Single boundsValue, Boolean proportional, Single constraint)`
  - `private static Single ResolveDimension(Boolean isProportional, Single fromBounds, Single available, Single measured)`
  - `public ILayout AbsoluteLayout { get; }`

### class `AbsoluteParam`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `public Rect get_LayoutBounds()`
  - `public AbsoluteLayoutFlags get_LayoutFlags()`
  - `public Void set_LayoutBounds(Rect value)`
  - `public Void set_LayoutFlags(AbsoluteLayoutFlags value)`
  - `public Rect LayoutBounds { get; set; }`
  - `public AbsoluteLayoutFlags LayoutFlags { get; set; }`

### class `Dimension`

- Base: `System.Object`
- Members:
  - `public static Boolean IsExplicitSet(Single value)`
  - `public static Boolean IsMaximumSet(Single value)`
  - `public static Boolean IsMinimumSet(Single value)`
  - `public static Single ResolveMinimum(Single value)`

### enum `FlexAlignContent`

- Base: `System.Enum`
- Members:

### enum `FlexAlignItems`

- Base: `System.Enum`
- Members:

### enum `FlexAlignSelf`

- Base: `System.Enum`
- Members:

### struct `FlexBasis`

- Base: `System.ValueType`
- Interfaces: `System.IEquatable`1<Tizen.UI.Layouts.FlexBasis>`
- Members:
  - `static .cctor()`
  - `.ctor(Single length, Boolean isRelative)`
  - `public Boolean Equals(FlexBasis other)`
  - `public Boolean Equals(Object obj)`
  - `internal Boolean get_IsAuto()`
  - `internal Boolean get_IsRelative()`
  - `public Single get_Length()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(FlexBasis left, FlexBasis right)`
  - `public static FlexBasis op_Implicit(Single length)`
  - `public static Boolean op_Inequality(FlexBasis left, FlexBasis right)`
  - `internal Boolean IsAuto { get; }`
  - `internal Boolean IsRelative { get; }`
  - `public Single Length { get; }`

### class `FlexBox`

- Base: `Tizen.UI.Layouts.Layout`
- Interfaces: `Tizen.UI.Layouts.IFlexBox`, `Tizen.UI.Layouts.ILayout`
- Members:
  - `.ctor()`
  - `private Void AddFlexItem(View child)`
  - `private Void EnsureFlexItemPropertiesUpdated(FlexBox flex)`
  - `public FlexAlignContent get_AlignContent()`
  - `public FlexAlignItems get_AlignItems()`
  - `public FlexDirection get_Direction()`
  - `internal Boolean get_InMeasureMode()`
  - `public FlexJustify get_JustifyContent()`
  - `protected ILayoutManager get_LayoutManager()`
  - `public FlexPosition get_Position()`
  - `private Item get_Root()`
  - `public FlexWrap get_Wrap()`
  - `public Size Measure(Single availableWidth, Single availableHeight)`
  - `private static Boolean NeedsMeasureHack(Single widthConstraint, Single heightConstraint)`
  - `protected Void OnChildAdded(View view)`
  - `protected Void OnChildRemoved(View view)`
  - `private Void PrepareMeasureHack()`
  - `private Void RemoveFlexItem(View child)`
  - `private Void RestoreValues()`
  - `public Void set_AlignContent(FlexAlignContent value)`
  - `public Void set_AlignItems(FlexAlignItems value)`
  - `public Void set_Direction(FlexDirection value)`
  - `internal Void set_InMeasureMode(Boolean value)`
  - `public Void set_JustifyContent(FlexJustify value)`
  - `public Void set_Position(FlexPosition value)`
  - `public Void set_Wrap(FlexWrap value)`
  - `Void Tizen.UI.Layouts.IFlexBox.Layout(Single width, Single height)`
  - `IList<View> Tizen.UI.Layouts.ILayout.get_Children()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredHeight()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredWidth()`
  - `LayoutDirection Tizen.UI.Layouts.ILayout.get_LayoutDirection()`
  - `private Void UpdateFlexParam(View view)`
  - `public FlexAlignContent AlignContent { get; set; }`
  - `public FlexAlignItems AlignItems { get; set; }`
  - `public FlexDirection Direction { get; set; }`
  - `internal Boolean InMeasureMode { get; set; }`
  - `public FlexJustify JustifyContent { get; set; }`
  - `protected ILayoutManager LayoutManager { get; }`
  - `public FlexPosition Position { get; set; }`
  - `private Item Root { get; }`
  - `public FlexWrap Wrap { get; set; }`

### class `FlexBoxExtensions`

- Base: `System.Object`
- Members:
  - `public static TView AlignItems<TView>(TView view, FlexAlignItems alignItems) where TView : FlexBox`
  - `public static TView AlignSelf<TView>(TView view, FlexAlignSelf alignSelf) where TView : View`
  - `public static TView AutoAlign<TView>(TView view) where TView : View`
  - `public static TView AutoBasis<TView>(TView view) where TView : View`
  - `public static TView Basis<TView>(TView view, Single length) where TView : View`
  - `public static TView CenterAlign<TView>(TView view) where TView : View`
  - `public static TView CenterItems<TView>(TView view) where TView : FlexBox`
  - `public static TView CenterJustify<TView>(TView view) where TView : FlexBox`
  - `public static TView Column<TView>(TView view) where TView : FlexBox`
  - `public static TView ColumnReverse<TView>(TView view) where TView : FlexBox`
  - `public static TView Direction<TView>(TView view, FlexDirection direction) where TView : FlexBox`
  - `public static TView EndAlign<TView>(TView view) where TView : View`
  - `public static TView EndItems<TView>(TView view) where TView : FlexBox`
  - `public static TView EndJustify<TView>(TView view) where TView : FlexBox`
  - `public static TView Grow<TView>(TView view, Single grow) where TView : View`
  - `public static TView JustifyContent<TView>(TView view, FlexJustify justifyContent) where TView : FlexBox`
  - `public static TView Order<TView>(TView view, Int32 order) where TView : View`
  - `public static TView RelativeBasis<TView>(TView view, Single length) where TView : View`
  - `public static TView Row<TView>(TView view) where TView : FlexBox`
  - `public static TView RowReverse<TView>(TView view) where TView : FlexBox`
  - `public static TView Shrink<TView>(TView view, Single shrink) where TView : View`
  - `public static TView SpaceAroundJustify<TView>(TView view) where TView : FlexBox`
  - `public static TView SpaceBetweenJustify<TView>(TView view) where TView : FlexBox`
  - `public static TView SpaceEvenlyJustify<TView>(TView view) where TView : FlexBox`
  - `public static TView StartAlign<TView>(TView view) where TView : View`
  - `public static TView StartItems<TView>(TView view) where TView : FlexBox`
  - `public static TView StartJustify<TView>(TView view) where TView : FlexBox`
  - `public static TView StretchAlign<TView>(TView view) where TView : View`
  - `public static TView StretchItems<TView>(TView view) where TView : FlexBox`

### enum `FlexDirection`

- Base: `System.Enum`
- Members:

### enum `FlexJustify`

- Base: `System.Enum`
- Members:

### class `FlexLayoutManager`

- Base: `System.Object`
- Interfaces: `Tizen.UI.Layouts.ILayoutManager`
- Members:
  - `.ctor(IFlexBox flexLayout)`
  - `public Size ArrangeChildren(Rect bounds)`
  - `private IFlexBox get_FlexLayout()`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`
  - `private IFlexBox FlexLayout { get; }`

### class `FlexParam`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `public FlexAlignSelf get_AlignSelf()`
  - `internal FlexAlignSelf get_AlignSelfBackup()`
  - `public FlexBasis get_Basis()`
  - `internal Item get_FlexItem()`
  - `public Single get_Grow()`
  - `public Int32 get_Order()`
  - `public Single get_Shrink()`
  - `internal Single get_ShrinkBackup()`
  - `public Void set_AlignSelf(FlexAlignSelf value)`
  - `internal Void set_AlignSelfBackup(FlexAlignSelf value)`
  - `public Void set_Basis(FlexBasis value)`
  - `public Void set_Grow(Single value)`
  - `public Void set_Order(Int32 value)`
  - `public Void set_Shrink(Single value)`
  - `internal Void set_ShrinkBackup(Single value)`
  - `public FlexAlignSelf AlignSelf { get; set; }`
  - `internal FlexAlignSelf AlignSelfBackup { get; set; }`
  - `public FlexBasis Basis { get; set; }`
  - `internal Item FlexItem { get; }`
  - `public Single Grow { get; set; }`
  - `public Int32 Order { get; set; }`
  - `public Single Shrink { get; set; }`
  - `internal Single ShrinkBackup { get; set; }`

### enum `FlexPosition`

- Base: `System.Enum`
- Members:

### class `FlexRootParam`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `internal Item get_FlexItem()`
  - `internal Item FlexItem { get; }`

### enum `FlexWrap`

- Base: `System.Enum`
- Members:

### class `Grid`

- Base: `Tizen.UI.Layouts.Layout`
- Interfaces: `Tizen.UI.Layouts.IGridLayout`, `Tizen.UI.Layouts.ILayout`
- Members:
  - `.ctor()`
  - `public Void Add(View view, Int32 row, Int32 col)`
  - `public Void Add(View view, Int32 row, Int32 rowSpan, Int32 col, Int32 colSpan)`
  - `public IList<GridColumnDefinition> get_ColumnDefinitions()`
  - `public Single get_ColumnSpacing()`
  - `protected ILayoutManager get_LayoutManager()`
  - `public IList<GridRowDefinition> get_RowDefinitions()`
  - `public Single get_RowSpacing()`
  - `public Void set_ColumnDefinitions(IList<GridColumnDefinition> value)`
  - `public Void set_ColumnSpacing(Single value)`
  - `public Void set_RowDefinitions(IList<GridRowDefinition> value)`
  - `public Void set_RowSpacing(Single value)`
  - `IList<View> Tizen.UI.Layouts.ILayout.get_Children()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredHeight()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredWidth()`
  - `LayoutDirection Tizen.UI.Layouts.ILayout.get_LayoutDirection()`
  - `public IList<GridColumnDefinition> ColumnDefinitions { get; set; }`
  - `public Single ColumnSpacing { get; set; }`
  - `protected ILayoutManager LayoutManager { get; }`
  - `public IList<GridRowDefinition> RowDefinitions { get; set; }`
  - `public Single RowSpacing { get; set; }`

### class `GridColumnDefinition`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `public GridLength get_Width()`
  - `public static GridColumnDefinition op_Implicit(GridLength width)`
  - `public static GridColumnDefinition op_Implicit(Single width)`
  - `public Void set_Width(GridLength value)`
  - `public GridLength Width { get; set; }`

### class `GridExtensions`

- Base: `System.Object`
- Members:
  - `public static TView Column<TView>(TView view, Int32 column) where TView : View`
  - `public static TView Column<TView>(TView view, Int32 column, Int32 span) where TView : View`
  - `public static TView Column<TView, TColumn>(TView view, TColumn column) where TView : View where TColumn : Enum`
  - `public static TView Column<TView, TColumn>(TView view, TColumn column, TColumn last) where TView : View where TColumn : Enum`
  - `public static TView ColumnSpan<TView>(TView view, Int32 span) where TView : View`
  - `public static TView Row<TView>(TView view, Int32 row) where TView : View`
  - `public static TView Row<TView>(TView view, Int32 row, Int32 span) where TView : View`
  - `public static TView Row<TView, TRow>(TView view, TRow row) where TView : View where TRow : Enum`
  - `public static TView Row<TView, TRow>(TView view, TRow row, TRow last) where TView : View where TRow : Enum`
  - `public static TView RowSpan<TView>(TView view, Int32 span) where TView : View`
  - `private static Int32 ToInt(Enum enumValue)`

### class `GridLayoutManager`

- Base: `Tizen.UI.Layouts.LayoutManager`
- Members:
  - `.ctor(IGridLayout layout)`
  - `public Size ArrangeChildren(Rect bounds)`
  - `public IGridLayout get_Grid()`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`
  - `private static GridLayoutManager.GridLengthType ToGridLengthType(GridUnitType gridUnitType)`
  - `public IGridLayout Grid { get; }`

### struct `GridLength`

- Base: `System.ValueType`
- Members:
  - `static .cctor()`
  - `.ctor(Single value)`
  - `.ctor(Single value, GridUnitType type)`
  - `public Boolean Equals(Object obj)`
  - `private Boolean Equals(GridLength other)`
  - `public GridUnitType get_GridUnitType()`
  - `public Boolean get_IsAbsolute()`
  - `public Boolean get_IsAuto()`
  - `public Boolean get_IsStar()`
  - `public Single get_Value()`
  - `public Int32 GetHashCode()`
  - `public static GridLength op_Implicit(Single absoluteValue)`
  - `public String ToString()`
  - `public GridUnitType GridUnitType { get; }`
  - `public Boolean IsAbsolute { get; }`
  - `public Boolean IsAuto { get; }`
  - `public Boolean IsStar { get; }`
  - `public Single Value { get; }`

### class `GridParam`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `public Int32 get_Column()`
  - `public Int32 get_ColumnSpan()`
  - `public Int32 get_Row()`
  - `public Int32 get_RowSpan()`
  - `public Void set_Column(Int32 value)`
  - `public Void set_ColumnSpan(Int32 value)`
  - `public Void set_Row(Int32 value)`
  - `public Void set_RowSpan(Int32 value)`
  - `public Int32 Column { get; set; }`
  - `public Int32 ColumnSpan { get; set; }`
  - `public Int32 Row { get; set; }`
  - `public Int32 RowSpan { get; set; }`

### class `GridRowColumns`

- Base: `System.Object`
- Members:
  - `public static Int32 All<TEnum>() where TEnum : Enum`
  - `public static GridLength get_Auto()`
  - `public static GridLength get_Star()`
  - `public static Int32 Last<TEnum>() where TEnum : Enum`
  - `public static GridLength Stars(Single value)`
  - `private static Int32 ToInt(Enum enumValue)`
  - `public GridLength Auto { get; }`
  - `public GridLength Star { get; }`

### class `GridRowDefinition`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `public GridLength get_Height()`
  - `public static GridRowDefinition op_Implicit(GridLength height)`
  - `public static GridRowDefinition op_Implicit(Single height)`
  - `public Void set_Height(GridLength value)`
  - `public GridLength Height { get; set; }`

### enum `GridUnitType`

- Base: `System.Enum`
- Members:

### class `HStack`

- Base: `Tizen.UI.Layouts.StackBase`
- Members:
  - `.ctor()`
  - `protected ILayoutManager get_LayoutManager()`
  - `protected ILayoutManager LayoutManager { get; }`

### class `HStackLayoutManager`

- Base: `Tizen.UI.Layouts.StackLayoutManager`
- Members:
  - `.ctor(IStackLayout layout)`
  - `public Size ArrangeChildren(Rect bounds)`
  - `private static Single GetDistance(View view, Single width)`
  - `private static Single GetLeftIncludingMargin(View view, Boolean isLTR)`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`

### interface `IFlexBox`

- Interfaces: `Tizen.UI.Layouts.ILayout`
- Members:
  - `public Void Layout(Single width, Single height)`

### interface `IGridLayout`

- Interfaces: `Tizen.UI.Layouts.ILayout`
- Members:
  - `public IList<GridColumnDefinition> get_ColumnDefinitions()`
  - `public Single get_ColumnSpacing()`
  - `public IList<GridRowDefinition> get_RowDefinitions()`
  - `public Single get_RowSpacing()`
  - `public IList<GridColumnDefinition> ColumnDefinitions { get; }`
  - `public Single ColumnSpacing { get; }`
  - `public IList<GridRowDefinition> RowDefinitions { get; }`
  - `public Single RowSpacing { get; }`

### interface `ILayout`

- Members:
  - `public IList<View> get_Children()`
  - `public Single get_DesiredHeight()`
  - `public Single get_DesiredWidth()`
  - `public LayoutDirection get_LayoutDirection()`
  - `public LayoutParam get_LayoutParam()`
  - `public Thickness get_Padding()`
  - `public IList<View> Children { get; }`
  - `public Single DesiredHeight { get; }`
  - `public Single DesiredWidth { get; }`
  - `public LayoutDirection LayoutDirection { get; }`
  - `public LayoutParam LayoutParam { get; }`
  - `public Thickness Padding { get; }`

### interface `ILayoutManager`

- Members:
  - `public Size ArrangeChildren(Rect bounds)`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`

### interface `IStackLayout`

- Interfaces: `Tizen.UI.Layouts.ILayout`
- Members:
  - `public LayoutAlignment get_ItemAlignment()`
  - `public Single get_Spacing()`
  - `public LayoutAlignment ItemAlignment { get; }`
  - `public Single Spacing { get; }`

### class `Layout`

- Base: `Tizen.UI.ViewGroup`
- Interfaces: `Tizen.UI.Layouts.ILayout`
- Members:
  - `.ctor()`
  - `Void <.ctor>b__3_0(Object s, EventArgs e)`
  - `protected Void Dispose(Boolean disposing)`
  - `protected View get_EffectiveParent()`
  - `public static Boolean get_IsManualLayout()`
  - `public Boolean get_IsOnPseudoLayout()`
  - `protected ILayoutManager get_LayoutManager()`
  - `private Boolean get_LayoutRequested()`
  - `protected Boolean get_Measured()`
  - `private Boolean get_NeedForceLayout()`
  - `public Thickness get_Padding()`
  - `public Size Measure(Single availableWidth, Single availableHeight)`
  - `protected Void OnChildAdded(View view)`
  - `private Void OnChildMeasureInvalidated(Object sender, EventArgs e)`
  - `protected Void OnChildMeasureInvalidatedOverride(View child)`
  - `protected Void OnChildRemoved(View view)`
  - `private Void OnLayoutIterationOnce(Object sender, EventArgs e)`
  - `protected Void OnMeasureInvalidatedOverride()`
  - `private Void OnRelayout(Object sender, EventArgs e)`
  - `protected Void RequestLayout()`
  - `protected Void SendMeasureInvalidatedIfNeed()`
  - `public static Void set_IsManualLayout(Boolean value)`
  - `public Void set_IsOnPseudoLayout(Boolean value)`
  - `private Void set_LayoutRequested(Boolean value)`
  - `protected Void set_Measured(Boolean value)`
  - `private Void set_NeedForceLayout(Boolean value)`
  - `public Void set_Padding(Thickness value)`
  - `IList<View> Tizen.UI.Layouts.ILayout.get_Children()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredHeight()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredWidth()`
  - `LayoutDirection Tizen.UI.Layouts.ILayout.get_LayoutDirection()`
  - `LayoutParam Tizen.UI.Layouts.ILayout.get_LayoutParam()`
  - `public Void UpdateLayout()`
  - `public Size UpdateLayout(Rect bounds)`
  - `protected View EffectiveParent { get; }`
  - `public Boolean IsManualLayout { get; set; }`
  - `public Boolean IsOnPseudoLayout { get; set; }`
  - `protected ILayoutManager LayoutManager { get; }`
  - `private Boolean LayoutRequested { get; set; }`
  - `protected Boolean Measured { get; set; }`
  - `private Boolean NeedForceLayout { get; set; }`
  - `public Thickness Padding { get; set; }`
  - `LayoutParam Tizen.UI.Layouts.ILayout.LayoutParam { get; }`

### enum `LayoutAlignment`

- Base: `System.Enum`
- Members:

### class `LayoutExtensions`

- Base: `System.Object`
- Members:
  - `internal static Size AdjustForFill(Size size, Rect bounds, ILayout view)`
  - `private static Single AlignHorizontal(View view, Rect bounds, Thickness margin)`
  - `private static Single AlignHorizontal(Single startX, Single startMargin, Single endMargin, Single boundsWidth, Single desiredWidth, LayoutAlignment horizontalLayoutAlignment)`
  - `private static Single AlignVertical(View view, Rect bounds, Thickness margin)`
  - `public static Void Arrange(View view, Rect rect, Boolean ignoreRTL)`
  - `public static TView Center<TView>(TView view) where TView : View`
  - `public static TView CenterHorizontal<TView>(TView view) where TView : View`
  - `public static TView CenterVertical<TView>(TView view) where TView : View`
  - `public static Size ComputeDesiredSize(View view, Single widthConstraint, Single heightConstraint)`
  - `internal static Rect ComputeFrame(View view, Rect bounds)`
  - `public static TView End<TView>(TView view) where TView : View`
  - `public static TView EndHorizontal<TView>(TView view) where TView : View`
  - `public static TView EndVertical<TView>(TView view) where TView : View`
  - `public static TView Expand<TView>(TView view, Single weight) where TView : View`
  - `public static TView Expand<TView>(TView view) where TView : View`
  - `public static TView Fill<TView>(TView view) where TView : View`
  - `public static TView FillHorizontal<TView>(TView view) where TView : View`
  - `public static TView FillVertical<TView>(TView view) where TView : View`
  - `internal static Single GetEffectiveMaximumHeight(View view)`
  - `internal static Single GetEffectiveMaximumWidth(View view)`
  - `internal static Single GetEffectiveMinimumHeight(View view)`
  - `internal static Single GetEffectiveMinimumWidth(View view)`
  - `internal static View GetEffectiveParent(View view)`
  - `public static TView HorizontalLayoutAlignment<TView>(TView view, LayoutAlignment alignment) where TView : View`
  - `public static TView ItemAlignment<TView>(TView view, LayoutAlignment alignment) where TView : StackBase`
  - `public static TView Margin<TView>(TView view, Single left, Single top, Single right, Single bottom) where TView : View`
  - `public static TView Margin<TView>(TView view, Single horizontalSize, Single verticalSize) where TView : View`
  - `public static TView Margin<TView>(TView view, Single uniformSize) where TView : View`
  - `public static TView Margin<TView>(TView view, Thickness margin) where TView : View`
  - `public static TView MaximumHeight<TView>(TView view, Single max) where TView : View`
  - `public static TView MaximumWidth<TView>(TView view, Single max) where TView : View`
  - `public static TView MinimumHeight<TView>(TView view, Single min) where TView : View`
  - `public static TView MinimumWidth<TView>(TView view, Single min) where TView : View`
  - `public static TView Padding<TView>(TView view, Thickness padding) where TView : Layout`
  - `public static TView Padding<TView>(TView view, Single left, Single top, Single right, Single bottom) where TView : Layout`
  - `internal static Single ResolveMinMax(Single size, Single min, Single max)`
  - `public static TView Start<TView>(TView view) where TView : View`
  - `public static TView StartHorizontal<TView>(TView view) where TView : View`
  - `public static TView StartVertical<TView>(TView view) where TView : View`
  - `public static TView Translate<TView>(TView view, Single x, Single y) where TView : View`
  - `public static TView TranslateX<TView>(TView view, Single x) where TView : View`
  - `public static TView TranslateY<TView>(TView view, Single y) where TView : View`
  - `public static TView VerticalLayoutAlignment<TView>(TView view, LayoutAlignment alignment) where TView : View`

### class `LayoutHelper`

- Base: `System.Object`
- Interfaces: `System.IDisposable`
- Members:
  - `.ctor(ViewGroup viewGroup, ILayoutManager layoutManager)`
  - `Void <.ctor>b__8_0(Object s, EventArgs e)`
  - `public Void Dispose()`
  - `protected Void Dispose(Boolean disposing)`
  - `public Boolean get_Measured()`
  - `private Boolean IsOnPseudoLayout()`
  - `public Size Measure(Single availableWidth, Single availableHeight)`
  - `public Void OnChildAdded(View view)`
  - `private Void OnChildMeasureInvalidated(Object sender, EventArgs e)`
  - `public Void OnChildMeasureInvalidatedOverride(View child)`
  - `public Void OnChildRemoved(View view)`
  - `private Void OnLayoutIterationOnce(Object sender, EventArgs e)`
  - `public Void OnMeasureInvalidated()`
  - `private Void OnRelayout(Object sender, EventArgs e)`
  - `private Void RequestLayout()`
  - `private Void SendMeasureInvalidatedIfNeed()`
  - `public Void set_Measured(Boolean value)`
  - `public Void UpdateLayout()`
  - `public Size UpdateLayout(Rect bounds)`
  - `public Boolean Measured { get; set; }`

### class `LayoutManager`

- Base: `System.Object`
- Interfaces: `Tizen.UI.Layouts.ILayoutManager`
- Members:
  - `.ctor(ILayout layout)`
  - `public Size ArrangeChildren(Rect bounds)`
  - `public ILayout get_Layout()`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`
  - `public static Single ResolveConstraints(Single externalConstraint, Single explicitLength, Single measuredLength, Single min, Single max)`
  - `public ILayout Layout { get; }`

### class `LayoutParam`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `public Single get_Expand()`
  - `public LayoutAlignment get_HorizontalLayoutAlignment()`
  - `public Thickness get_Margin()`
  - `public Single get_MaximumHeight()`
  - `public Single get_MaximumWidth()`
  - `public Size get_MeasuredSize()`
  - `public Single get_MinimumHeight()`
  - `public Single get_MinimumWidth()`
  - `public Single get_TranslateX()`
  - `public Single get_TranslateY()`
  - `public LayoutAlignment get_VerticalLayoutAlignment()`
  - `public Void set_Expand(Single value)`
  - `public Void set_HorizontalLayoutAlignment(LayoutAlignment value)`
  - `public Void set_Margin(Thickness value)`
  - `public Void set_MaximumHeight(Single value)`
  - `public Void set_MaximumWidth(Single value)`
  - `public Void set_MeasuredSize(Size value)`
  - `public Void set_MinimumHeight(Single value)`
  - `public Void set_MinimumWidth(Single value)`
  - `public Void set_TranslateX(Single value)`
  - `public Void set_TranslateY(Single value)`
  - `public Void set_VerticalLayoutAlignment(LayoutAlignment value)`
  - `public Single Expand { get; set; }`
  - `public LayoutAlignment HorizontalLayoutAlignment { get; set; }`
  - `public Thickness Margin { get; set; }`
  - `public Single MaximumHeight { get; set; }`
  - `public Single MaximumWidth { get; set; }`
  - `public Size MeasuredSize { get; set; }`
  - `public Single MinimumHeight { get; set; }`
  - `public Single MinimumWidth { get; set; }`
  - `public Single TranslateX { get; set; }`
  - `public Single TranslateY { get; set; }`
  - `public LayoutAlignment VerticalLayoutAlignment { get; set; }`

### class `ScrollBar`

- Base: `Tizen.UI.ViewGroup`
- Interfaces: `System.IDisposable`, `Tizen.UI.IScrollBar`
- Members:
  - `.ctor()`
  - `private Boolean <Initialize>b__48_0()`
  - `private Void CreateHBar()`
  - `private Void CreateVBar()`
  - `protected Void Dispose(Boolean disposing)`
  - `private Void FadeIn()`
  - `private Void FadeOut()`
  - `public Color get_BarColor()`
  - `public Single get_BarMargin()`
  - `public Single get_BarMinSize()`
  - `public Single get_BarWidth()`
  - `public ScrollBarVisibility get_HorizontalScrollBarVisibility()`
  - `private Size get_ScrollArea()`
  - `public Point get_ScrollPosition()`
  - `public View get_Target()`
  - `public ScrollBarVisibility get_VerticalScrollBarVisibility()`
  - `private Size get_ViewPortSize()`
  - `private Void Initialize()`
  - `private Void OnLayoutDirectionChanged(Object sender, EventArgs e)`
  - `private Void OnRelayout(Object sender, EventArgs e)`
  - `private Void RemoveHBar()`
  - `private Void RemoveVBar()`
  - `public Void set_BarColor(Color value)`
  - `public Void set_BarMargin(Single value)`
  - `public Void set_BarMinSize(Single value)`
  - `public Void set_BarWidth(Single value)`
  - `public Void set_HorizontalScrollBarVisibility(ScrollBarVisibility value)`
  - `private Void set_ScrollArea(Size value)`
  - `public Void set_ScrollPosition(Point value)`
  - `public Void set_VerticalScrollBarVisibility(ScrollBarVisibility value)`
  - `private Void set_ViewPortSize(Size value)`
  - `private Void ShowBar()`
  - `Void Tizen.UI.IScrollBar.OnAttachedToScrollable(IScrollable scrollable)`
  - `public Void UpdateBarSize(Size scrollArea, Size viewportSize)`
  - `private Void UpdateBarSize()`
  - `private Void UpdateHBarSize(Single ratio)`
  - `private Void UpdatePosition(Point position)`
  - `public Void UpdateScrollPosition(Point position)`
  - `private Void UpdateVBarSize(Single ratio)`
  - `public Color BarColor { get; set; }`
  - `public Single BarMargin { get; set; }`
  - `public Single BarMinSize { get; set; }`
  - `public Single BarWidth { get; set; }`
  - `public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }`
  - `private Size ScrollArea { get; set; }`
  - `public Point ScrollPosition { get; set; }`
  - `public View Target { get; }`
  - `public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }`
  - `private Size ViewPortSize { get; set; }`

### class `ScrollLayout`

- Base: `Tizen.UI.Layouts.Layout`
- Interfaces: `Tizen.UI.IDescendantFocusObserver`, `Tizen.UI.IScrollable`
- Members:
  - `static .cctor()`
  - `.ctor()`
  - `public event EventHandler<DragEventArgs> DragFinished`
  - `public event EventHandler<DragEventArgs> Dragging`
  - `public event EventHandler<DragEventArgs> DragStarted`
  - `public event EventHandler<ScrollEventArgs> ScrollFinished`
  - `public event EventHandler<ScrollEventArgs> Scrolling`
  - `public event EventHandler<ScrollEventArgs> ScrollStarted`
  - `public Void add_DragFinished(EventHandler<DragEventArgs> value)`
  - `public Void add_Dragging(EventHandler<DragEventArgs> value)`
  - `public Void add_DragStarted(EventHandler<DragEventArgs> value)`
  - `public Void add_ScrollFinished(EventHandler<ScrollEventArgs> value)`
  - `public Void add_Scrolling(EventHandler<ScrollEventArgs> value)`
  - `public Void add_ScrollStarted(EventHandler<ScrollEventArgs> value)`
  - `private Point AdjustDelta(Point movement, Nullable<Point> currentPosition)`
  - `private Point AdjustScrollPosition(Point position)`
  - `private Void CancelScrollAnimation()`
  - `private Point ContentPositionToScrollPosition(Point content)`
  - `protected IScrollBar CreateScrollBar()`
  - `private Point DeltaFromScrollPosition(Point scrollPosition)`
  - `protected Void Dispose(Boolean disposing)`
  - `private Void EnsureScrollBar()`
  - `public View get_Content()`
  - `public ScrollBarVisibility get_HorizontalScrollBarVisibility()`
  - `public Boolean get_IsScrolling()`
  - `protected ILayoutManager get_LayoutManager()`
  - `public IScrollBar get_ScrollBar()`
  - `public ScrollDirection get_ScrollDirection()`
  - `public Func<Point, Point> get_ScrollingDestinationHandler()`
  - `public Point get_ScrollPosition()`
  - `public Size get_ScrollSize()`
  - `public ScrollBarVisibility get_VerticalScrollBarVisibility()`
  - `public Rect get_ViewPort()`
  - `protected ValueTuple<Int32, AlphaFunction> GetDurationAndAlpha(Point movement)`
  - `protected Void OnChildAdded(View view)`
  - `protected Void OnChildMeasureInvalidatedOverride(View child)`
  - `protected Void OnChildRemoved(View view)`
  - `private Void OnInterruptTouchingChildTouched(Object source, TouchEventArgs e)`
  - `private Void OnKeyEvent(Object sender, KeyEventArgs e)`
  - `private Void OnPan(Object sender, PanGestureDetectedEventArgs e)`
  - `private Void OnScrollAnimationFinished(Object sender, EventArgs e)`
  - `private Void OnScrolling()`
  - `private Void OnTouchEvent(Object sender, TouchEventArgs e)`
  - `protected Boolean OnWheel(WheelEvent wheel)`
  - `private Void OnWheelEvent(Object sender, WheelEventArgs e)`
  - `public Void remove_DragFinished(EventHandler<DragEventArgs> value)`
  - `public Void remove_Dragging(EventHandler<DragEventArgs> value)`
  - `public Void remove_DragStarted(EventHandler<DragEventArgs> value)`
  - `public Void remove_ScrollFinished(EventHandler<ScrollEventArgs> value)`
  - `public Void remove_Scrolling(EventHandler<ScrollEventArgs> value)`
  - `public Void remove_ScrollStarted(EventHandler<ScrollEventArgs> value)`
  - `protected Task ScrollContent(Point delta)`
  - `protected Point ScrollingDestinationOverride(Point dest)`
  - `private Point ScrollPositionFromDelta(Point delta)`
  - `public Task ScrollTo(View child, Boolean animation, ScrollToPosition scrollToPosition)`
  - `public Task ScrollTo(Single position, Boolean animation)`
  - `public Task ScrollTo(Point position, Boolean animation)`
  - `private Void SendScrollFinished()`
  - `private Void SendScrolling()`
  - `private Void SendScrollStarted()`
  - `public Void set_Content(View value)`
  - `public Void set_HorizontalScrollBarVisibility(ScrollBarVisibility value)`
  - `protected Void set_IsScrolling(Boolean value)`
  - `public Void set_ScrollBar(IScrollBar value)`
  - `public Void set_ScrollDirection(ScrollDirection value)`
  - `public Void set_ScrollingDestinationHandler(Func<Point, Point> value)`
  - `public Void set_ScrollSize(Size value)`
  - `public Void set_VerticalScrollBarVisibility(ScrollBarVisibility value)`
  - `private Void SetScroll(Point position)`
  - `private Void SetScrollBar(IScrollBar scrollbar)`
  - `Void Tizen.UI.IDescendantFocusObserver.OnDescendantFocused(View descendant)`
  - `Boolean Tizen.UI.IScrollable.get_CanScrollHorizontally()`
  - `Boolean Tizen.UI.IScrollable.get_CanScrollVertically()`
  - `Boolean Tizen.UI.IScrollable.get_IsScrolledToEnd()`
  - `Boolean Tizen.UI.IScrollable.get_IsScrolledToStart()`
  - `Task Tizen.UI.IScrollable.ScrollBy(Single x, Single y, Boolean animated)`
  - `Task Tizen.UI.IScrollable.ScrollTo(Single x, Single y, Boolean animation)`
  - `public Size UpdateLayout(Rect bounds)`
  - `private Void UpdateScrollingProperties()`
  - `private Void UpdateScrollPositionByUIPosition()`
  - `protected Point VelocityToMovement(Point velocity)`
  - `public View Content { get; set; }`
  - `public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }`
  - `public Boolean IsScrolling { get; set; }`
  - `protected ILayoutManager LayoutManager { get; }`
  - `public IScrollBar ScrollBar { get; set; }`
  - `public ScrollDirection ScrollDirection { get; set; }`
  - `public Func<Point, Point> ScrollingDestinationHandler { get; set; }`
  - `public Point ScrollPosition { get; }`
  - `public Size ScrollSize { get; set; }`
  - `Boolean Tizen.UI.IScrollable.CanScrollHorizontally { get; }`
  - `Boolean Tizen.UI.IScrollable.CanScrollVertically { get; }`
  - `Boolean Tizen.UI.IScrollable.IsScrolledToEnd { get; }`
  - `Boolean Tizen.UI.IScrollable.IsScrolledToStart { get; }`
  - `public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }`
  - `public Rect ViewPort { get; }`

### class `ScrollLayoutManager`

- Base: `Tizen.UI.Layouts.LayoutManager`
- Members:
  - `.ctor(ScrollLayout view)`
  - `public Size ArrangeChildren(Rect bounds)`
  - `public ScrollLayout get_ScrollView()`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`
  - `public ScrollLayout ScrollView { get; }`

### class `ScrollViewExtensions`

- Base: `System.Object`
- Members:
  - `public static TView HorizontalScrollBarVisibility<TView>(TView view, ScrollBarVisibility scrollBarVisibility) where TView : ScrollLayout`
  - `public static TView ScrollBarAlways<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarAlwaysHorizontal<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarAlwaysVertical<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarAuto<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarAutoHorizontal<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarAutoVertical<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarNever<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarNeverHorizontal<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollbarNeverVertical<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollBarVisibility<TView>(TView view, ScrollBarVisibility scrollBarVisibility) where TView : ScrollLayout`
  - `public static TView ScrollBoth<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollDirection<TView>(TView view, ScrollDirection scrollDirection) where TView : ScrollLayout`
  - `public static TView ScrollHorizontal<TView>(TView view) where TView : ScrollLayout`
  - `public static TView ScrollVertical<TView>(TView view) where TView : ScrollLayout`
  - `public static TView VerticalScrollBarVisibility<TView>(TView view, ScrollBarVisibility scrollBarVisibility) where TView : ScrollLayout`

### class `SnapControlExtensions`

- Base: `System.Object`
- Members:
  - `private static Void ClearSnapData(ScrollLayout scrollview)`
  - `private static SnapControlExtensions.SnapControlData GetSnapData(ScrollLayout scrollview)`
  - `public static T SetSnap<T>(T scrollView, SnapPointsType snapType, SnapPointsAlignment align) where T : ScrollLayout`

### enum `SnapPointsAlignment`

- Base: `System.Enum`
- Members:

### enum `SnapPointsType`

- Base: `System.Enum`
- Members:

### class `StackBase`

- Base: `Tizen.UI.Layouts.Layout`
- Interfaces: `Tizen.UI.Layouts.ILayout`, `Tizen.UI.Layouts.IStackLayout`
- Members:
  - `.ctor()`
  - `public LayoutAlignment get_ItemAlignment()`
  - `public Single get_Spacing()`
  - `public Void set_ItemAlignment(LayoutAlignment value)`
  - `public Void set_Spacing(Single value)`
  - `IList<View> Tizen.UI.Layouts.ILayout.get_Children()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredHeight()`
  - `Single Tizen.UI.Layouts.ILayout.get_DesiredWidth()`
  - `LayoutDirection Tizen.UI.Layouts.ILayout.get_LayoutDirection()`
  - `public LayoutAlignment ItemAlignment { get; set; }`
  - `public Single Spacing { get; set; }`

### class `StackBaseExtensions`

- Base: `System.Object`
- Members:
  - `public static TView Spacing<TView>(TView view, Single spacing) where TView : StackBase`

### class `StackLayoutManager`

- Base: `Tizen.UI.Layouts.LayoutManager`
- Members:
  - `.ctor(IStackLayout stack)`
  - `public IStackLayout get_Stack()`
  - `protected static Single MeasureSpacing(Single spacing, Int32 childCount)`
  - `public IStackLayout Stack { get; }`

### class `ViewExtensions`

- Base: `System.Object`
- Members:
  - `public static AbsoluteParam AbsoluteParam(View view)`
  - `public static FlexParam FlexParam(View view)`
  - `internal static FlexRootParam FlexRootParam(View view)`
  - `internal static Size GetConstraints(Item item)`
  - `internal static Rect GetFrame(Item item)`
  - `public static GridParam GridParam(View view)`
  - `public static Boolean HasFlexParam(View view)`
  - `internal static Int32 IndexOf(Item parent, Item child)`
  - `public static LayoutParam LayoutParam(View view)`
  - `internal static Void Remove(Item parent, Item child)`
  - `internal static Basis ToFlexBasis(FlexBasis basis)`

### class `VStack`

- Base: `Tizen.UI.Layouts.StackBase`
- Members:
  - `.ctor()`
  - `protected ILayoutManager get_LayoutManager()`
  - `protected ILayoutManager LayoutManager { get; }`

### class `VStackLayoutManager`

- Base: `Tizen.UI.Layouts.StackLayoutManager`
- Members:
  - `.ctor(IStackLayout stackLayout)`
  - `public Size ArrangeChildren(Rect bounds)`
  - `private static Single GetDistance(View view, Single height)`
  - `private static Single GetTopIncludingMargin(View view)`
  - `public Size Measure(Single widthConstraint, Single heightConstraint)`

## Namespace `Tizen.UI.Layouts.Flex`

### enum `AlignContent`

- Base: `System.Enum`
- Members:

### enum `AlignItems`

- Base: `System.Enum`
- Members:

### enum `AlignSelf`

- Base: `System.Enum`
- Members:

### struct `Basis`

- Base: `System.ValueType`
- Members:
  - `static .cctor()`
  - `.ctor(Single length, Boolean isRelative)`
  - `public Boolean get_IsAuto()`
  - `public Boolean get_IsRelative()`
  - `public Single get_Length()`
  - `public Boolean IsAuto { get; }`
  - `public Boolean IsRelative { get; }`
  - `public Single Length { get; }`

### enum `Direction`

- Base: `System.Enum`
- Members:

### class `Item`

- Base: `System.Object`
- Interfaces: `System.Collections.Generic.IEnumerable`1<Tizen.UI.Layouts.Flex.Item>`, `System.Collections.IEnumerable`
- Members:
  - `.ctor()`
  - `.ctor(Single width, Single height)`
  - `private static Single absolute_pos(Single pos1, Single pos2, Single size, Single dim)`
  - `private static Single absolute_size(Single val, Single pos1, Single pos2, Single dim)`
  - `public Void Add(Item child)`
  - `private static AlignItems child_align(Item child, Item parent)`
  - `public AlignContent get_AlignContent()`
  - `public AlignItems get_AlignItems()`
  - `public AlignSelf get_AlignSelf()`
  - `public Basis get_Basis()`
  - `public Single get_Bottom()`
  - `private IList<Item> get_Children()`
  - `public Int32 get_Count()`
  - `public Direction get_Direction()`
  - `public Single[] get_Frame()`
  - `public Single get_Grow()`
  - `public Single get_Height()`
  - `public Boolean get_IsVisible()`
  - `public Item get_Item(Int32 index)`
  - `public Justify get_JustifyContent()`
  - `public Single get_Left()`
  - `public Single get_MarginBottom()`
  - `public Single get_MarginLeft()`
  - `public Single get_MarginRight()`
  - `public Single get_MarginTop()`
  - `public Single get_MaximumHeight()`
  - `public Single get_MaximumWidth()`
  - `public Single get_MinimumHeight()`
  - `public Single get_MinimumWidth()`
  - `public Int32 get_Order()`
  - `public Single get_PaddingBottom()`
  - `public Single get_PaddingLeft()`
  - `public Single get_PaddingRight()`
  - `public Single get_PaddingTop()`
  - `public Item get_Parent()`
  - `public Position get_Position()`
  - `public Single get_Right()`
  - `public Item get_Root()`
  - `public Item.SelfSizingDelegate get_SelfSizing()`
  - `private Boolean get_ShouldOrderChildren()`
  - `public Single get_Shrink()`
  - `public Single get_Top()`
  - `public Single get_Width()`
  - `public Wrap get_Wrap()`
  - `public Void InsertAt(Int32 index, Item child)`
  - `public Item ItemAt(Int32 index)`
  - `public Void Layout()`
  - `private static Void layout_align(Justify align, Single flex_dim, Int32 children_count, Single& pos_p, Single& spacing_p)`
  - `private static Void layout_align(AlignContent align, Single flex_dim, UInt32 children_count, Single& pos_p, Single& spacing_p)`
  - `private static Void layout_item(Item item, Single width, Single height)`
  - `private static Void layout_items(Item item, Int32 child_begin, Int32 child_end, Int32 children_count, Item.flex_layout& layout)`
  - `private Single MarginThickness(Boolean vertical)`
  - `public Item RemoveAt(UInt32 index)`
  - `public Void set_AlignContent(AlignContent value)`
  - `public Void set_AlignItems(AlignItems value)`
  - `public Void set_AlignSelf(AlignSelf value)`
  - `public Void set_Basis(Basis value)`
  - `public Void set_Bottom(Single value)`
  - `private Void set_Children(IList<Item> value)`
  - `public Void set_Direction(Direction value)`
  - `public Void set_Grow(Single value)`
  - `public Void set_Height(Single value)`
  - `public Void set_IsVisible(Boolean value)`
  - `public Void set_JustifyContent(Justify value)`
  - `public Void set_Left(Single value)`
  - `public Void set_MarginBottom(Single value)`
  - `public Void set_MarginLeft(Single value)`
  - `public Void set_MarginRight(Single value)`
  - `public Void set_MarginTop(Single value)`
  - `public Void set_MaximumHeight(Single value)`
  - `public Void set_MaximumWidth(Single value)`
  - `public Void set_MinimumHeight(Single value)`
  - `public Void set_MinimumWidth(Single value)`
  - `public Void set_Order(Int32 value)`
  - `public Void set_PaddingBottom(Single value)`
  - `public Void set_PaddingLeft(Single value)`
  - `public Void set_PaddingRight(Single value)`
  - `public Void set_PaddingTop(Single value)`
  - `private Void set_Parent(Item value)`
  - `public Void set_Position(Position value)`
  - `public Void set_Right(Single value)`
  - `public Void set_SelfSizing(Item.SelfSizingDelegate value)`
  - `private Void set_ShouldOrderChildren(Boolean value)`
  - `public Void set_Shrink(Single value)`
  - `public Void set_Top(Single value)`
  - `public Void set_Width(Single value)`
  - `public Void set_Wrap(Wrap value)`
  - `IEnumerator<Item> System.Collections.Generic.IEnumerable<Tizen.UI.Layouts.Flex.Item>.GetEnumerator()`
  - `IEnumerator System.Collections.IEnumerable.GetEnumerator()`
  - `private Void ValidateChild(Item child)`
  - `public AlignContent AlignContent { get; set; }`
  - `public AlignItems AlignItems { get; set; }`
  - `public AlignSelf AlignSelf { get; set; }`
  - `public Basis Basis { get; set; }`
  - `public Single Bottom { get; set; }`
  - `private IList<Item> Children { get; set; }`
  - `public Int32 Count { get; }`
  - `public Direction Direction { get; set; }`
  - `public Single[] Frame { get; }`
  - `public Single Grow { get; set; }`
  - `public Single Height { get; set; }`
  - `public Boolean IsVisible { get; set; }`
  - `public Item Item { get; }`
  - `public Justify JustifyContent { get; set; }`
  - `public Single Left { get; set; }`
  - `public Single MarginBottom { get; set; }`
  - `public Single MarginLeft { get; set; }`
  - `public Single MarginRight { get; set; }`
  - `public Single MarginTop { get; set; }`
  - `public Single MaximumHeight { get; set; }`
  - `public Single MaximumWidth { get; set; }`
  - `public Single MinimumHeight { get; set; }`
  - `public Single MinimumWidth { get; set; }`
  - `public Int32 Order { get; set; }`
  - `public Single PaddingBottom { get; set; }`
  - `public Single PaddingLeft { get; set; }`
  - `public Single PaddingRight { get; set; }`
  - `public Single PaddingTop { get; set; }`
  - `public Item Parent { get; set; }`
  - `public Position Position { get; set; }`
  - `public Single Right { get; set; }`
  - `public Item Root { get; }`
  - `public Item.SelfSizingDelegate SelfSizing { get; set; }`
  - `private Boolean ShouldOrderChildren { get; set; }`
  - `public Single Shrink { get; set; }`
  - `public Single Top { get; set; }`
  - `public Single Width { get; set; }`
  - `public Wrap Wrap { get; set; }`

### enum `Justify`

- Base: `System.Enum`
- Members:

### enum `Position`

- Base: `System.Enum`
- Members:

### enum `Wrap`

- Base: `System.Enum`
- Members:

## Extension Methods

### Target `System.Enum`

- `private static Int32 ToInt(Enum enumValue)`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `private static Int32 ToInt(Enum enumValue)`
  - Declared in: `Tizen.UI.Layouts.GridRowColumns` (`Tizen.UI.Layouts`)

### Target `System.Single`

- `internal static Single ResolveMinMax(Single size, Single min, Single max)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)

### Target `T`

- `public static T SetSnap<T>(T scrollView, SnapPointsType snapType, SnapPointsAlignment align) where T : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.SnapControlExtensions` (`Tizen.UI.Layouts`)

### Target `Tizen.UI.Layouts.Flex.Item`

- `internal static Size GetConstraints(Item item)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `internal static Rect GetFrame(Item item)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `internal static Int32 IndexOf(Item parent, Item child)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `internal static Void Remove(Item parent, Item child)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)

### Target `Tizen.UI.Layouts.FlexBasis`

- `internal static Basis ToFlexBasis(FlexBasis basis)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)

### Target `Tizen.UI.Layouts.ScrollLayout`

- `private static Void ClearSnapData(ScrollLayout scrollview)`
  - Declared in: `Tizen.UI.Layouts.SnapControlExtensions` (`Tizen.UI.Layouts`)
- `private static SnapControlExtensions.SnapControlData GetSnapData(ScrollLayout scrollview)`
  - Declared in: `Tizen.UI.Layouts.SnapControlExtensions` (`Tizen.UI.Layouts`)

### Target `Tizen.UI.Size`

- `internal static Size AdjustForFill(Size size, Rect bounds, ILayout view)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)

### Target `Tizen.UI.View`

- `public static Void Arrange(View view, Rect rect, Boolean ignoreRTL)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static Size ComputeDesiredSize(View view, Single widthConstraint, Single heightConstraint)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `internal static Rect ComputeFrame(View view, Rect bounds)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `internal static Single GetEffectiveMaximumHeight(View view)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `internal static Single GetEffectiveMaximumWidth(View view)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `internal static Single GetEffectiveMinimumHeight(View view)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `internal static Single GetEffectiveMinimumWidth(View view)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `internal static View GetEffectiveParent(View view)`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static AbsoluteParam AbsoluteParam(View view)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `public static FlexParam FlexParam(View view)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `internal static FlexRootParam FlexRootParam(View view)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `public static GridParam GridParam(View view)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `public static Boolean HasFlexParam(View view)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)
- `public static LayoutParam LayoutParam(View view)`
  - Declared in: `Tizen.UI.Layouts.ViewExtensions` (`Tizen.UI.Layouts`)

### Target `TView`

- `public static TView LayoutBounds<TView>(TView view, Single x, Single y, Single width, Single height) where TView : View`
  - Declared in: `Tizen.UI.Layouts.AbsoluteLayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView LayoutFlags<TView>(TView view, AbsoluteLayoutFlags flag) where TView : View`
  - Declared in: `Tizen.UI.Layouts.AbsoluteLayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView AlignItems<TView>(TView view, FlexAlignItems alignItems) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView AlignSelf<TView>(TView view, FlexAlignSelf alignSelf) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView AutoAlign<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView AutoBasis<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Basis<TView>(TView view, Single length) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView CenterAlign<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView CenterItems<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView CenterJustify<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Column<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView ColumnReverse<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Direction<TView>(TView view, FlexDirection direction) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView EndAlign<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView EndItems<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView EndJustify<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Grow<TView>(TView view, Single grow) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView JustifyContent<TView>(TView view, FlexJustify justifyContent) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Order<TView>(TView view, Int32 order) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView RelativeBasis<TView>(TView view, Single length) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Row<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView RowReverse<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Shrink<TView>(TView view, Single shrink) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView SpaceAroundJustify<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView SpaceBetweenJustify<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView SpaceEvenlyJustify<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView StartAlign<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView StartItems<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView StartJustify<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView StretchAlign<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView StretchItems<TView>(TView view) where TView : FlexBox`
  - Declared in: `Tizen.UI.Layouts.FlexBoxExtensions` (`Tizen.UI.Layouts`)
- `public static TView Column<TView>(TView view, Int32 column) where TView : View`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Column<TView>(TView view, Int32 column, Int32 span) where TView : View`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Column<TView, TColumn>(TView view, TColumn column) where TView : View where TColumn : Enum`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Column<TView, TColumn>(TView view, TColumn column, TColumn last) where TView : View where TColumn : Enum`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView ColumnSpan<TView>(TView view, Int32 span) where TView : View`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Row<TView>(TView view, Int32 row) where TView : View`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Row<TView>(TView view, Int32 row, Int32 span) where TView : View`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Row<TView, TRow>(TView view, TRow row) where TView : View where TRow : Enum`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Row<TView, TRow>(TView view, TRow row, TRow last) where TView : View where TRow : Enum`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView RowSpan<TView>(TView view, Int32 span) where TView : View`
  - Declared in: `Tizen.UI.Layouts.GridExtensions` (`Tizen.UI.Layouts`)
- `public static TView Center<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView CenterHorizontal<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView CenterVertical<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView End<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView EndHorizontal<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView EndVertical<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Expand<TView>(TView view, Single weight) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Expand<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Fill<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView FillHorizontal<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView FillVertical<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView HorizontalLayoutAlignment<TView>(TView view, LayoutAlignment alignment) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView ItemAlignment<TView>(TView view, LayoutAlignment alignment) where TView : StackBase`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Margin<TView>(TView view, Single left, Single top, Single right, Single bottom) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Margin<TView>(TView view, Single horizontalSize, Single verticalSize) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Margin<TView>(TView view, Single uniformSize) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Margin<TView>(TView view, Thickness margin) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView MaximumHeight<TView>(TView view, Single max) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView MaximumWidth<TView>(TView view, Single max) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView MinimumHeight<TView>(TView view, Single min) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView MinimumWidth<TView>(TView view, Single min) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Padding<TView>(TView view, Thickness padding) where TView : Layout`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Padding<TView>(TView view, Single left, Single top, Single right, Single bottom) where TView : Layout`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Start<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView StartHorizontal<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView StartVertical<TView>(TView view) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView Translate<TView>(TView view, Single x, Single y) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView TranslateX<TView>(TView view, Single x) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView TranslateY<TView>(TView view, Single y) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView VerticalLayoutAlignment<TView>(TView view, LayoutAlignment alignment) where TView : View`
  - Declared in: `Tizen.UI.Layouts.LayoutExtensions` (`Tizen.UI.Layouts`)
- `public static TView HorizontalScrollBarVisibility<TView>(TView view, ScrollBarVisibility scrollBarVisibility) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarAlways<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarAlwaysHorizontal<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarAlwaysVertical<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarAuto<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarAutoHorizontal<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarAutoVertical<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarNever<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarNeverHorizontal<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollbarNeverVertical<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBarVisibility<TView>(TView view, ScrollBarVisibility scrollBarVisibility) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollBoth<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollDirection<TView>(TView view, ScrollDirection scrollDirection) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollHorizontal<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView ScrollVertical<TView>(TView view) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView VerticalScrollBarVisibility<TView>(TView view, ScrollBarVisibility scrollBarVisibility) where TView : ScrollLayout`
  - Declared in: `Tizen.UI.Layouts.ScrollViewExtensions` (`Tizen.UI.Layouts`)
- `public static TView Spacing<TView>(TView view, Single spacing) where TView : StackBase`
  - Declared in: `Tizen.UI.Layouts.StackBaseExtensions` (`Tizen.UI.Layouts`)

