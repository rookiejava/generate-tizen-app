# API Summary: Tizen.UI.Markdown

Source: `c:\workspace\temp\Generate_TizenApp\Packages\Tizen.UI.Markdown.1.0.0-rc.5\lib\net8.0-tizen10.0\Tizen.UI.Markdown.dll`
Generated (UTC): 2026-03-07T11:20:28.6394988+00:00

## Namespace `Tizen.UI.Markdown`

### class `CodeStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.CodeStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(CodeStyle original)`
  - `.ctor()`
  - `public CodeStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(CodeStyle other)`
  - `public Color get_BackgroundColor()`
  - `public Single get_CornerRadius()`
  - `public static CodeStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public Color get_FontColor()`
  - `public String get_FontFamily()`
  - `public Single get_FontSize()`
  - `public Int32 get_Padding()`
  - `public Color get_TitleBackgroundColor()`
  - `public Color get_TitleFontColor()`
  - `public String get_TitleFontFamily()`
  - `public Single get_TitleFontSize()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(CodeStyle left, CodeStyle right)`
  - `public static Boolean op_Inequality(CodeStyle left, CodeStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BackgroundColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_CornerRadius(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontFamily(String value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSize(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Padding(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_TitleBackgroundColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_TitleFontColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_TitleFontFamily(String value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_TitleFontSize(Single value)`
  - `public String ToString()`
  - `public Color BackgroundColor { get; set; }`
  - `public Single CornerRadius { get; set; }`
  - `public CodeStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public Color FontColor { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Int32 Padding { get; set; }`
  - `public Color TitleBackgroundColor { get; set; }`
  - `public Color TitleFontColor { get; set; }`
  - `public String TitleFontFamily { get; set; }`
  - `public Single TitleFontSize { get; set; }`

### class `CommonStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.CommonStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(CommonStyle original)`
  - `.ctor()`
  - `public CommonStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(CommonStyle other)`
  - `public static CommonStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public Int32 get_Indent()`
  - `public Int32 get_ItemPadding()`
  - `public Int32 get_Padding()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(CommonStyle left, CommonStyle right)`
  - `public static Boolean op_Inequality(CommonStyle left, CommonStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Indent(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_ItemPadding(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Padding(Int32 value)`
  - `public String ToString()`
  - `public CommonStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public Int32 Indent { get; set; }`
  - `public Int32 ItemPadding { get; set; }`
  - `public Int32 Padding { get; set; }`

### class `HeadingStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.HeadingStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(HeadingStyle original)`
  - `.ctor()`
  - `public HeadingStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(HeadingStyle other)`
  - `public static HeadingStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public String get_FontFamily()`
  - `public Single get_FontSizeLevel1()`
  - `public Single get_FontSizeLevel2()`
  - `public Single get_FontSizeLevel3()`
  - `public Single get_FontSizeLevel4()`
  - `public Single get_FontSizeLevel5()`
  - `public Single get_FontSizeLevel6()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(HeadingStyle left, HeadingStyle right)`
  - `public static Boolean op_Inequality(HeadingStyle left, HeadingStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontFamily(String value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSizeLevel1(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSizeLevel2(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSizeLevel3(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSizeLevel4(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSizeLevel5(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSizeLevel6(Single value)`
  - `public String ToString()`
  - `public HeadingStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSizeLevel1 { get; set; }`
  - `public Single FontSizeLevel2 { get; set; }`
  - `public Single FontSizeLevel3 { get; set; }`
  - `public Single FontSizeLevel4 { get; set; }`
  - `public Single FontSizeLevel5 { get; set; }`
  - `public Single FontSizeLevel6 { get; set; }`

### interface `IContainerBlock`

- Members:
  - `public Void Add(View view)`
  - `public Boolean Remove(View view)`

### class `ListStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.ListStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(ListStyle original)`
  - `.ctor()`
  - `public ListStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(ListStyle other)`
  - `public static ListStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public Int32 get_ItemMarginBottom()`
  - `public Int32 get_ItemMarginTop()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(ListStyle left, ListStyle right)`
  - `public static Boolean op_Inequality(ListStyle left, ListStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_ItemMarginBottom(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_ItemMarginTop(Int32 value)`
  - `public String ToString()`
  - `public ListStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public Int32 ItemMarginBottom { get; set; }`
  - `public Int32 ItemMarginTop { get; set; }`

### class `MarkdownParser`

- Base: `System.Object`
- Members:
  - `static .cctor()`
  - `private static Void BuildPlainText(Block block, StringBuilder sb)`
  - `private static String GetInlinePlainText(ContainerInline inline)`
  - `public static String MarkdownToPlainText(String markdown)`
  - `public static MarkdownDocument Parse(String markdown)`

### class `MarkdownStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.MarkdownStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(MarkdownStyle original)`
  - `.ctor()`
  - `public MarkdownStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(MarkdownStyle other)`
  - `public CodeStyle get_Code()`
  - `public CommonStyle get_Common()`
  - `public static MarkdownStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public HeadingStyle get_Heading()`
  - `public ListStyle get_List()`
  - `public ParagraphStyle get_Paragraph()`
  - `public QuoteStyle get_Quote()`
  - `public TableStyle get_Table()`
  - `public ThematicBreakStyle get_ThematicBreak()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(MarkdownStyle left, MarkdownStyle right)`
  - `public static Boolean op_Inequality(MarkdownStyle left, MarkdownStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Code(CodeStyle value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Common(CommonStyle value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Heading(HeadingStyle value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_List(ListStyle value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Paragraph(ParagraphStyle value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Quote(QuoteStyle value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Table(TableStyle value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_ThematicBreak(ThematicBreakStyle value)`
  - `public String ToString()`
  - `public CodeStyle Code { get; set; }`
  - `public CommonStyle Common { get; set; }`
  - `public MarkdownStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public HeadingStyle Heading { get; set; }`
  - `public ListStyle List { get; set; }`
  - `public ParagraphStyle Paragraph { get; set; }`
  - `public QuoteStyle Quote { get; set; }`
  - `public TableStyle Table { get; set; }`
  - `public ThematicBreakStyle ThematicBreak { get; set; }`

### class `MarkdownView`

- Base: `Tizen.UI.Layouts.VStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor()`
  - `.ctor(MarkdownStyle style)`
  - `public MarkdownStyle get_Style()`
  - `public String get_Text()`
  - `public Void Render()`
  - `public Void set_Text(String value)`
  - `public MarkdownStyle Style { get; }`
  - `public String Text { get; set; }`

### class `ParagraphStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.ParagraphStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(ParagraphStyle original)`
  - `.ctor()`
  - `public ParagraphStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(ParagraphStyle other)`
  - `public static ParagraphStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public Color get_FontColor()`
  - `public String get_FontFamily()`
  - `public Single get_FontSize()`
  - `public Single get_LineHeight()`
  - `public Int32 get_StrikethroughThickness()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(ParagraphStyle left, ParagraphStyle right)`
  - `public static Boolean op_Inequality(ParagraphStyle left, ParagraphStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontFamily(String value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontSize(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_LineHeight(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_StrikethroughThickness(Int32 value)`
  - `public String ToString()`
  - `public ParagraphStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public Color FontColor { get; set; }`
  - `public String FontFamily { get; set; }`
  - `public Single FontSize { get; set; }`
  - `public Single LineHeight { get; set; }`
  - `public Int32 StrikethroughThickness { get; set; }`

### class `QuoteStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.QuoteStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(QuoteStyle original)`
  - `.ctor()`
  - `public QuoteStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(QuoteStyle other)`
  - `public Color get_BarColor()`
  - `public Single get_BarCornerRadius()`
  - `public Int32 get_BarMargin()`
  - `public Int32 get_BarWidth()`
  - `public static QuoteStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public Color get_FontColor()`
  - `public Int32 get_Padding()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(QuoteStyle left, QuoteStyle right)`
  - `public static Boolean op_Inequality(QuoteStyle left, QuoteStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BarColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BarCornerRadius(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BarMargin(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BarWidth(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_FontColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Padding(Int32 value)`
  - `public String ToString()`
  - `public Color BarColor { get; set; }`
  - `public Single BarCornerRadius { get; set; }`
  - `public Int32 BarMargin { get; set; }`
  - `public Int32 BarWidth { get; set; }`
  - `public QuoteStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public Color FontColor { get; set; }`
  - `public Int32 Padding { get; set; }`

### class `StyleDefaults`

- Base: `System.Object`
- Members:
  - `static .cctor()`
  - `public static Color get_CodeBackgroundColor()`
  - `public static Single get_CodeCornerRadius()`
  - `public static Color get_CodeFontColor()`
  - `public static String get_CodeFontFamily()`
  - `public static Single get_CodeFontSize()`
  - `public static Int32 get_CodePadding()`
  - `public static Color get_CodeTitleBackgroundColor()`
  - `public static Color get_CodeTitleFontColor()`
  - `public static String get_CodeTitleFontFamily()`
  - `public static Single get_CodeTitleFontSize()`
  - `public static Int32 get_CommonIndent()`
  - `public static Int32 get_CommonItemPadding()`
  - `public static Int32 get_CommonPadding()`
  - `public static String get_HeadingFontFamily()`
  - `public static Single get_HeadingFontSizeLevel1()`
  - `public static Single get_HeadingFontSizeLevel2()`
  - `public static Single get_HeadingFontSizeLevel3()`
  - `public static Single get_HeadingFontSizeLevel4()`
  - `public static Single get_HeadingFontSizeLevel5()`
  - `public static Single get_HeadingFontSizeLevel6()`
  - `public static Int32 get_ListItemMarginBottom()`
  - `public static Int32 get_ListItemMarginTop()`
  - `public static Color get_ParagraphFontColor()`
  - `public static String get_ParagraphFontFamily()`
  - `public static Single get_ParagraphFontSize()`
  - `public static Single get_ParagraphLineHeight()`
  - `public static Int32 get_ParagraphStrikethroughThickness()`
  - `public static Color get_QuoteBarColor()`
  - `public static Single get_QuoteBarCornerRadius()`
  - `public static Int32 get_QuoteBarMargin()`
  - `public static Int32 get_QuoteBarWidth()`
  - `public static Color get_QuoteFontColor()`
  - `public static Int32 get_QuotePadding()`
  - `public static Color get_TableBackgroundColor()`
  - `public static Color get_TableBorderColor()`
  - `public static Int32 get_TableBorderThickness()`
  - `public static Single get_TableCornerRadius()`
  - `public static Int32 get_TableItemPadding()`
  - `public static Int32 get_TablePadding()`
  - `public static Color get_ThematicBreakColor()`
  - `public static Int32 get_ThematicBreakMargin()`
  - `public static Int32 get_ThematicBreakThickness()`
  - `public static Void set_CodeBackgroundColor(Color value)`
  - `public static Void set_CodeCornerRadius(Single value)`
  - `public static Void set_CodeFontColor(Color value)`
  - `public static Void set_CodeFontFamily(String value)`
  - `public static Void set_CodeFontSize(Single value)`
  - `public static Void set_CodePadding(Int32 value)`
  - `public static Void set_CodeTitleBackgroundColor(Color value)`
  - `public static Void set_CodeTitleFontColor(Color value)`
  - `public static Void set_CodeTitleFontFamily(String value)`
  - `public static Void set_CodeTitleFontSize(Single value)`
  - `public static Void set_CommonIndent(Int32 value)`
  - `public static Void set_CommonItemPadding(Int32 value)`
  - `public static Void set_CommonPadding(Int32 value)`
  - `public static Void set_HeadingFontFamily(String value)`
  - `public static Void set_HeadingFontSizeLevel1(Single value)`
  - `public static Void set_HeadingFontSizeLevel2(Single value)`
  - `public static Void set_HeadingFontSizeLevel3(Single value)`
  - `public static Void set_HeadingFontSizeLevel4(Single value)`
  - `public static Void set_HeadingFontSizeLevel5(Single value)`
  - `public static Void set_HeadingFontSizeLevel6(Single value)`
  - `public static Void set_ListItemMarginBottom(Int32 value)`
  - `public static Void set_ListItemMarginTop(Int32 value)`
  - `public static Void set_ParagraphFontColor(Color value)`
  - `public static Void set_ParagraphFontFamily(String value)`
  - `public static Void set_ParagraphFontSize(Single value)`
  - `public static Void set_ParagraphLineHeight(Single value)`
  - `public static Void set_ParagraphStrikethroughThickness(Int32 value)`
  - `public static Void set_QuoteBarColor(Color value)`
  - `public static Void set_QuoteBarCornerRadius(Single value)`
  - `public static Void set_QuoteBarMargin(Int32 value)`
  - `public static Void set_QuoteBarWidth(Int32 value)`
  - `public static Void set_QuoteFontColor(Color value)`
  - `public static Void set_QuotePadding(Int32 value)`
  - `public static Void set_TableBackgroundColor(Color value)`
  - `public static Void set_TableBorderColor(Color value)`
  - `public static Void set_TableBorderThickness(Int32 value)`
  - `public static Void set_TableCornerRadius(Single value)`
  - `public static Void set_TableItemPadding(Int32 value)`
  - `public static Void set_TablePadding(Int32 value)`
  - `public static Void set_ThematicBreakColor(Color value)`
  - `public static Void set_ThematicBreakMargin(Int32 value)`
  - `public static Void set_ThematicBreakThickness(Int32 value)`
  - `public Color CodeBackgroundColor { get; set; }`
  - `public Single CodeCornerRadius { get; set; }`
  - `public Color CodeFontColor { get; set; }`
  - `public String CodeFontFamily { get; set; }`
  - `public Single CodeFontSize { get; set; }`
  - `public Int32 CodePadding { get; set; }`
  - `public Color CodeTitleBackgroundColor { get; set; }`
  - `public Color CodeTitleFontColor { get; set; }`
  - `public String CodeTitleFontFamily { get; set; }`
  - `public Single CodeTitleFontSize { get; set; }`
  - `public Int32 CommonIndent { get; set; }`
  - `public Int32 CommonItemPadding { get; set; }`
  - `public Int32 CommonPadding { get; set; }`
  - `public String HeadingFontFamily { get; set; }`
  - `public Single HeadingFontSizeLevel1 { get; set; }`
  - `public Single HeadingFontSizeLevel2 { get; set; }`
  - `public Single HeadingFontSizeLevel3 { get; set; }`
  - `public Single HeadingFontSizeLevel4 { get; set; }`
  - `public Single HeadingFontSizeLevel5 { get; set; }`
  - `public Single HeadingFontSizeLevel6 { get; set; }`
  - `public Int32 ListItemMarginBottom { get; set; }`
  - `public Int32 ListItemMarginTop { get; set; }`
  - `public Color ParagraphFontColor { get; set; }`
  - `public String ParagraphFontFamily { get; set; }`
  - `public Single ParagraphFontSize { get; set; }`
  - `public Single ParagraphLineHeight { get; set; }`
  - `public Int32 ParagraphStrikethroughThickness { get; set; }`
  - `public Color QuoteBarColor { get; set; }`
  - `public Single QuoteBarCornerRadius { get; set; }`
  - `public Int32 QuoteBarMargin { get; set; }`
  - `public Int32 QuoteBarWidth { get; set; }`
  - `public Color QuoteFontColor { get; set; }`
  - `public Int32 QuotePadding { get; set; }`
  - `public Color TableBackgroundColor { get; set; }`
  - `public Color TableBorderColor { get; set; }`
  - `public Int32 TableBorderThickness { get; set; }`
  - `public Single TableCornerRadius { get; set; }`
  - `public Int32 TableItemPadding { get; set; }`
  - `public Int32 TablePadding { get; set; }`
  - `public Color ThematicBreakColor { get; set; }`
  - `public Int32 ThematicBreakMargin { get; set; }`
  - `public Int32 ThematicBreakThickness { get; set; }`

### class `TableStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.TableStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(TableStyle original)`
  - `.ctor()`
  - `public TableStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(TableStyle other)`
  - `public Color get_BackgroundColor()`
  - `public Color get_BorderColor()`
  - `public Int32 get_BorderThickness()`
  - `public Single get_CornerRadius()`
  - `public static TableStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public Int32 get_ItemPadding()`
  - `public Int32 get_Padding()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(TableStyle left, TableStyle right)`
  - `public static Boolean op_Inequality(TableStyle left, TableStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BackgroundColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BorderColor(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_BorderThickness(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_CornerRadius(Single value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_ItemPadding(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Padding(Int32 value)`
  - `public String ToString()`
  - `public Color BackgroundColor { get; set; }`
  - `public Color BorderColor { get; set; }`
  - `public Int32 BorderThickness { get; set; }`
  - `public Single CornerRadius { get; set; }`
  - `public TableStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public Int32 ItemPadding { get; set; }`
  - `public Int32 Padding { get; set; }`

### class `ThematicBreakStyle`

- Base: `System.Object`
- Interfaces: `System.IEquatable`1<Tizen.UI.Markdown.ThematicBreakStyle>`
- Members:
  - `static .cctor()`
  - `.ctor(ThematicBreakStyle original)`
  - `.ctor()`
  - `public ThematicBreakStyle <Clone>$()`
  - `public Boolean Equals(Object obj)`
  - `public Boolean Equals(ThematicBreakStyle other)`
  - `public Color get_Color()`
  - `public static ThematicBreakStyle get_Default()`
  - `protected Type get_EqualityContract()`
  - `public Int32 get_Margin()`
  - `public Int32 get_Thickness()`
  - `public Int32 GetHashCode()`
  - `public static Boolean op_Equality(ThematicBreakStyle left, ThematicBreakStyle right)`
  - `public static Boolean op_Inequality(ThematicBreakStyle left, ThematicBreakStyle right)`
  - `protected Boolean PrintMembers(StringBuilder builder)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Color(Color value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Margin(Int32 value)`
  - `public Void modreq(System.Runtime.CompilerServices.IsExternalInit) set_Thickness(Int32 value)`
  - `public String ToString()`
  - `public Color Color { get; set; }`
  - `public ThematicBreakStyle Default { get; }`
  - `protected Type EqualityContract { get; }`
  - `public Int32 Margin { get; set; }`
  - `public Int32 Thickness { get; set; }`

## Namespace `Tizen.UI.Markdown.MarkdownUI`

### class `MarkdownUIBuilder`

- Base: `System.Object`
- Members:
  - `.ctor(MarkdownStyle style)`
  - `private static Void AppendEscaped(StringBuilder sb, String text, Int32 start, Int32 length)`
  - `public Void Build(Block block, IContainerBlock parent, StringBuilder path, Int32 childIndex)`
  - `private View CreateContainer(Block block)`
  - `private View CreateLeaf(Block block, String text)`
  - `private MarkdownUICacheManager get_CacheManager()`
  - `public MarkdownStyle get_Style()`
  - `private Int32 GetIndent(Block block)`
  - `private String GetInlineText(ContainerInline inline)`
  - `private Int32 GetListDepth(Block block)`
  - `private static Boolean IsUpdatable(Block block)`
  - `public Void RemoveUnusedViews()`
  - `private Void UpdateLeaf(View view, Block block, String text)`
  - `private MarkdownUICacheManager CacheManager { get; }`
  - `public MarkdownStyle Style { get; }`

### class `MarkdownUICacheManager`

- Base: `System.Object`
- Members:
  - `.ctor()`
  - `public Void Add(String key, View value)`
  - `public static String CreateKey(Block block, String path)`
  - `public View Get(String key)`
  - `public Void MarkVisited(String key)`
  - `public Void RemoveUnusedViews()`

### class `UICode`

- Base: `Tizen.UI.Layouts.VStack`
- Members:
  - `.ctor(String language, String text, Int32 indent, CodeStyle codeStyle)`
  - `private static View CreateCode(String text, CodeStyle style)`
  - `private static View CreateTitle(String text, CodeStyle style)`
  - `public String get_Code()`
  - `public Int32 get_ContentHash()`
  - `public String get_Language()`
  - `public Void set_Code(String value)`
  - `public Void set_ContentHash(Int32 value)`
  - `public Void set_Language(String value)`
  - `public String Code { get; set; }`
  - `public Int32 ContentHash { get; set; }`
  - `public String Language { get; set; }`

### class `UIContainer`

- Base: `Tizen.UI.Layouts.VStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor(CommonStyle style)`

### class `UIHeading`

- Base: `Tizen.UI.Markdown.MarkdownUI.UIParagraph`
- Members:
  - `.ctor(String text, Int32 level, HeadingStyle headingStyle, ParagraphStyle paragraphStyle)`
  - `public Int32 get_Level()`
  - `private HeadingStyle get_Style()`
  - `public Void set_Level(Int32 value)`
  - `public Int32 Level { get; set; }`
  - `private HeadingStyle Style { get; }`

### class `UIList`

- Base: `Tizen.UI.Layouts.VStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor()`
  - `public static Single GetBulletMargin(Int32 bulletSize, ParagraphStyle paragraph)`
  - `public static Int32 GetBulletSize(ParagraphStyle paragraph)`
  - `public static Single GetNumberPadding(ParagraphStyle paragraph)`
  - `public static Int32 GetNumberSize(ParagraphStyle paragraph)`

### class `UIListItem`

- Base: `Tizen.UI.Layouts.VStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor(CommonStyle commonStyle)`

### class `UIListItemParagraph`

- Base: `Tizen.UI.Layouts.HStack`
- Members:
  - `.ctor(String text, Boolean isOrdered, Int32 numberOrDepth, ListStyle listStyle, ParagraphStyle paragraphStyle)`
  - `private static Void ApplyBulletStyle(View bullet, Int32 depth, ParagraphStyle style)`
  - `private static View CreateBullet(Int32 depth, ParagraphStyle style)`
  - `private static View CreateNumber(Int32 number, ParagraphStyle style)`
  - `public String get_Text()`
  - `public Void set_Text(String value)`
  - `public String Text { get; set; }`

### class `UIParagraph`

- Base: `Tizen.UI.TextView`
- Members:
  - `.ctor(String text, ParagraphStyle paragraphStyle)`

### class `UIQuote`

- Base: `Tizen.UI.Layouts.HStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor(Boolean isHeader, Int32 indent, QuoteStyle quoteStyle, CommonStyle commonStyle, ParagraphStyle paragraphStyle)`
  - `Void Tizen.UI.Markdown.IContainerBlock.Add(View view)`
  - `Boolean Tizen.UI.Markdown.IContainerBlock.Remove(View view)`

### class `UIQuoteBar`

- Base: `Tizen.UI.View`
- Members:
  - `.ctor(QuoteStyle quoteStyle, Int32 barMargin)`

### class `UIQuoteParagraph`

- Base: `Tizen.UI.Markdown.MarkdownUI.UIParagraph`
- Members:
  - `.ctor(String text, QuoteStyle quoteStyle, ParagraphStyle paragraphStyle)`

### class `UITable`

- Base: `Tizen.UI.Layouts.VStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor(TableStyle tableStyle)`

### class `UITableCell`

- Base: `Tizen.UI.Layouts.VStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor(TableStyle style)`

### class `UITableHeaderRow`

- Base: `Tizen.UI.Layouts.Grid`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor(TableStyle tableStyle)`
  - `Void Tizen.UI.Markdown.IContainerBlock.Add(View view)`
  - `Boolean Tizen.UI.Markdown.IContainerBlock.Remove(View view)`

### class `UITableRow`

- Base: `Tizen.UI.Layouts.HStack`
- Interfaces: `Tizen.UI.Markdown.IContainerBlock`
- Members:
  - `.ctor(TableStyle tableStyle)`

### class `UIThematicBreak`

- Base: `Tizen.UI.View`
- Members:
  - `.ctor(ThematicBreakStyle thematicBreakStyle)`

## Extension Methods

- _(none)_

