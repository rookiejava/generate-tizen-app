## OVERVIEW

Tizen.UI C# Markup is a set of fluent helper methods and classes designed to simplify the process of building declarative user interfaces in code. The fluent API provided by C# Markup is available in the `Tizen.UI` and `Tizen.UI.Layouts` namespace.

Just as with XAML, C# Markup enables a clean separation between UI (View) and Business Logic (View Model).

## EXAMPLE

Here are some brief examples showing how common tasks can be achieved through the use of the C# Markup.

### Sizing
C# Markup allows us to define the sizing fluently and therefore chain multiple methods together to reduce the verbosity of our code:

```cs
new TextView().DesiredSize(200, 40);
```

### Binding

The Binding extensions provide a series of extension methods that support configuring Bindings on a `View`.

The extensions offer the following methods:

#### Bind (One way binding)
A one way binding from a view model property called `Title` to the `Text` property of an `TextView` can be created as follows:
```cs
new TextView().Bind(TextView.TextProperty, "Title")

//or

new TextView().BindText("Title"))
```

#### TwoWayBind (Two way binding)
A two way binding from a view model property called `UserText` to the `Text` property of an `TextField` can be created as follows:
```cs
new TextField().TwoWayBind(TextFieldBindings.TextProperty, "UserText")

//or

new TextField().BindText("UserText"))
```

### View
The `View` extensions provide a series of extension methods that support configuring the alignment of controls inheriting from `View`.

#### FixedWidth
The `FixedWidth` method sets the `View.WidthResizePolicy` property to `ResizePolicy.Fixed`.
Here's an example setting `TextView.WidthResizePolicy` to `ResizePolicy.Fixed` using `FixedWidth`:
```cs
new TextView().FixedWidth()
```

#### FixedHeight
The `FixedHeight` method sets the `View.HeightResizePolicy` property to `ResizePolicy.Fixed`.
Here's an example setting `TextView.HeightResizePolicy` to `ResizePolicy.Fixed` using `FixedHeight`:
```cs
new TextView().FixedHeight()
```

#### Fixed
The `Fixed` method sets both the `View.WidthResizePolicy` property and the `View.HeightResizePolicy` property to `ResizePolicy.Fixed`.
Here's an example setting both  `TextView.WidthResizePolicy` and `TextView.HeightResizePolicy` to `ResizePolicy.Fixed` using `Fixed`:
```cs
new TextView().Fixed()
```

#### UseNaturalSizeWidth
The `UseNaturalSizeWidth` method sets the `View.WidthResizePolicy` property to `ResizePolicy.UseNaturalSize`.
Here's an example setting `TextView.WidthResizePolicy` to `ResizePolicy.UseNaturalSize` using `UseNaturalSizeWidth`:
```cs
new TextView().UseNaturalSizeWidth()
```

#### UseNaturalSizeHeight
The `UseNaturalSizeHeight` method sets the `View.HeightResizePolicy` property to `ResizePolicy.UseNaturalSize`.
Here's an example setting `TextView.HeightResizePolicy` to `ResizePolicy.UseNaturalSize` using `UseNaturalSizeHeight`:
```cs
new TextView().UseNaturalSizeHeight()
```

#### UseNaturalSize
The `UseNaturalSize` method sets both the `View.WidthResizePolicy` property and the `View.HeightResizePolicy` property to `ResizePolicy.UseNaturalSize`.
Here's an example setting both  `TextView.WidthResizePolicy` and `TextView.HeightResizePolicy` to `ResizePolicy.UseNaturalSize` using `UseNaturalSize`:
```cs
new TextView().UseNaturalSize()
```

#### FillToParentWidth
The `FillToParentWidth` method sets the `View.WidthResizePolicy` property to `ResizePolicy.FillToParent`.
Here's an example setting `TextView.WidthResizePolicy` to `ResizePolicy.FillToParent` using `FillToParentWidth`:
```cs
new TextView().FillToParentWidth()
```

#### FillToParentHeight
The `FillToParentHeight` method sets the `View.HeightResizePolicy` property to `ResizePolicy.FillToParent`.
Here's an example setting `TextView.HeightResizePolicy` to `ResizePolicy.HeightResizePolicy` using `FillToParentHeight`:
```cs
new TextView().FillToParentHeight()
```

#### FillToParent
The `FillToParent` method sets both the `View.WidthResizePolicy` property and the `View.HeightResizePolicy` property to `ResizePolicy.FillToParent`.
Here's an example setting both  `TextView.WidthResizePolicy` and `TextView.HeightResizePolicy` to `ResizePolicy.FillToParent` using `FillToParent`:
```cs
new TextView().FillToParent()
```

#### Margin
The `Padding`extension method allows you to set the margin for the `View`.
```cs
new TextView().Margin(50, 0, 0, 0)
new TextView().Margin(50)
```

#### MinimumWidth / MinimumHeight
The `MinimumWidth` and `MinimumHeight` extension method allows you to set  the minimum width the `View` will request during layout.
```cs
new TextView.MinimumWidth(10)
new TextView.MinimumHeight(10)
```

#### MaximumWidth / MaximumHeight
The `MaximumWidth` and `MaximumHeight` extension method allows you to set  the maximum width the `View` will request during layout.
```cs
new TextView.MaximumWidth(100)
new TextView.MaximumHeight(100)
```

#### FillHorizontal
The `FillHorizontal` method sets the `View.LayoutParam().HorizontalLayoutAlignment` property to LayoutAlignment.Fill.
Here's an example setting `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.Fill` using `FillHorizontal`:
```cs
new TextView().FillHorizontal()
```

#### FillVertical
The `FillVertical` method sets the `View.LayoutParam().VerticalLayoutAlignment` property to LayoutAlignment.Fill.
Here's an example setting `TextView.VerticalLayoutAlignment` to `LayoutAlignment.Fill` using `FillVertical`:
```cs
new TextView().FillVertical()
```

#### Fill
The `Fill` method sets both the `View.LayoutParam().HorizontalLayoutAlignment` property and the `View.LayoutParam().VerticalLayoutAlignment` property to `LayoutAlignment.Fill`.
Here's an example setting both  `TextView.VerticalLayoutAlignment` and `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.Fill` using `Fill`:
```cs
new TextView().Fill()
```

#### StartHorizontal
The `StartHorizontal` method sets the `View.LayoutParam().HorizontalLayoutAlignment` property to LayoutAlignment.Start.
Here's an example setting `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.Start` using `StartHorizontal`:
```cs
new TextView().StartHorizontal()
```

#### StartVertical
The `StartVertical` method sets the `View.LayoutParam().VerticalLayoutAlignment` property to LayoutAlignment.Start.
Here's an example setting `TextView.VerticalLayoutAlignment` to `LayoutAlignment.Start` using `StartVertical`:
```cs
new TextView().StartVertical()
```

#### Start
The `Start` method sets both the `View.LayoutParam().HorizontalLayoutAlignment` property and the `View.LayoutParam().VerticalLayoutAlignment` property to `LayoutAlignment.Start`.
Here's an example setting both  `TextView.VerticalLayoutAlignment` and `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.Start` using `Start`:
```cs
new TextView().Start()
```

#### CenterHorizontal
The `CenterHorizontal` method sets the `View.LayoutParam().HorizontalLayoutAlignment` property to LayoutAlignment.Center.
Here's an example setting `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.Center` using `CenterHorizontal`:
```cs
new TextView().CenterHorizontal()
```

#### CentetVertical
The `CentetVertical` method sets the `View.LayoutParam().VerticalLayoutAlignment` property to LayoutAlignment.Center.
Here's an example setting `TextView.VerticalLayoutAlignment` to `LayoutAlignment.Center` using `CentetVertical`:
```cs
new TextView().CentetVertical()
```

#### Center
The `Center` method sets both the `View.LayoutParam().HorizontalLayoutAlignment` property and the `View.LayoutParam().VerticalLayoutAlignment` property to `LayoutAlignment.Center`.
Here's an example setting both  `TextView.VerticalLayoutAlignment` and `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.Center` using `Center`:
```cs
new TextView().Center()
```

#### EndHorizontal
The `EndHorizontal` method sets the `View.LayoutParam().HorizontalLayoutAlignment` property to LayoutAlignment.End.
Here's an example setting `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.End` using `EndHorizontal`:
```cs
new TextView().EndHorizontal()
```

#### EndVertical
The `EndVertical` method sets the `View.LayoutParam().VerticalLayoutAlignment` property to LayoutAlignment.End.
Here's an example setting `TextView.VerticalLayoutAlignment` to `LayoutAlignment.End` using `EndVertical`:
```cs
new TextView().EndVertical()
```

#### End
The `End` method sets both the `View.LayoutParam().HorizontalLayoutAlignment` property and the `View.LayoutParam().VerticalLayoutAlignment` property to `LayoutAlignment.End`.
Here's an example setting both  `TextView.VerticalLayoutAlignment` and `TextView.HorizontalLayoutAlignment` to `LayoutAlignment.End` using `End`:
```cs
new TextView().End()
```

### TextView
The `TextView` extensions provide a series of extension methods that support configuring a `TextView`.

The extensions offer the following methods:

#### Text
The `Text` method sets the `Text` property on an `TextView`.
```cs
new TextView().Text("This is TextView")
```

#### TextColor
The `TextColor` method sets the `TextColor` property on an `TextView`.
```cs
new TextView().TextColor(Color.Black)
```

#### TextColorFromHex
The `TextColorFromHex` method sets the `TextColor` property on an `TextView` as a hexadecimal string.
```cs
new TextView().TextColorFromHex("#ffffff")
```

#### FontSize
The `FontSize` method sets the `FontSize` property on an `TextView`.
```cs
new TextView().FontSize(15)
```

#### MultiLine
The `MultiLine` method sets the `MultiLine` property on an `TextView`.
```cs
new TextView().MultiLine(true)
```

#### TextStartHorizontal
The `TextStartHorizontal` method sets the `TextView.HorizontalAlignment` property to TextAlignment.Start.
```cs
new TextView().TextStartHorizontal()
```

#### TextStartVertical
The `TextStartVertical` method sets the `TextView.VerticalAlignment` property to TextAlignment.Start.
```cs
new TextView().TextStartVertical()
```

#### TextStart
The `TextStart` method sets both the `TextView.HorizontalAlignment` property and the `TextView.VerticalAlignment` property to TextAlignment.Start.
```cs
new TextView().TextStart()
```

#### TextCenterHorizontal
The `TextCenterHorizontal` method sets the `TextView.HorizontalAlignment` property to TextAlignment.Center.
```cs
new TextView().TextCenterHorizontal()
```

#### TextCenterVertical
The `TextCenterVertical` method sets the `TextView.VerticalAlignment` property to TextAlignment.Center.
```cs
new TextView().TextCenterVertical()
```

#### TextCenter
The `TextCenter` method sets both the `TextView.HorizontalAlignment` property and the `TextView.VerticalAlignment` property to TextAlignment.Center.
```cs
new TextView().TextCenter()
```

#### TextEndHorizontal
The `TextEndHorizontal` method sets the `TextView.HorizontalAlignment` property to TextAlignment.End.
```cs
new TextView().TextEndHorizontal()
```

#### TextEndVertical
The `TextEndVertical` method sets the `TextView.VerticalAlignment` property to TextAlignment.End.
```cs
new TextView().TextEndVertical()
```

#### TextEnd
The `TextEnd` method sets both the `TextView.HorizontalAlignment` property and the `TextView.VerticalAlignment` property to TextAlignment.End.
```cs
new TextView().TextEnd()
```

### ImageView
The `ImageView` extensions provide a series of extension methods that support configuring a `ImageView`.

The extensions offer the following methods:

#### ResourceUrl
The `ResourceUrl` method sets the `ResourceUrl` property on an `ImageView`.

The following example sets the `ResourceUrl` to "image.png":

```cs
new ImageView().ResourceUrl("image.png")
```

### Layout
The `Layout` extensions provide a series of extension methods that support positioning `View`s in `Layout`s.

The extensions offer the following methods:

#### Padding
The `Padding`extension method allows you to set the inner padding of the `Layout`.
```cs
new FlexBox().Padding(10)
new HStack().Padding(50, 0, 50, 0)
```

### StackBase
The `StackBase` extensions provide a series of extension methods that support positioning `View`s in `StackBase` layouts such as `HStack`, `VStack`.

The extensions offer the following methods:

#### Spacing
The `Spacing`extension method allows you to set  the amount of space between children in `StackBase` layout.

```cs
new HStack().Spacing(50);
```

### AbsoluteLayout

The `AbsoluteLayout` extensions provide a series of extension methods that support positioning `View`s in `AbsoluteLayout`s.

The extensions offer the following methods:

#### LayoutBounds ####
The `LayoutBounds `extension method allows you to set the position and size of a `View` in an `AbsoluteLayout`.

#### LayoutFlags ####
The `LayoutFlags` extension method allows you to set a flag that indicates that the layout bounds position and size values for a child are proportional to the size of the `AbsoluteLayout`. 

```cs
new AbsoluteLayout
{
    new VStack
    {
    new ImageView()
       .DesiredHeight(154)
       .ResourceUrl("image.png"),
    new TextView
       .Text("Read Information")
       .TextColorFromHex("#565656")
       .FontSize(30)
    }
    .LayoutBounds(0, 0, 1, 1)
    .LayoutFlags(AbsoluteLayoutFlags.All)
    .Margin(0, 0, 30, 30)
    .Spacing(20)
}
```

### FlexBox
The `FlexBox` extensions provide a series of extension methods that support positioning a `View` in a `FlexBox`.

The extensions offer the following methods:

#### Direction
The `Direction` method sets the `Direction` property on a `FlexBox`.

The following example sets the `Direction` to `FlexDirection.Row`:

```cs
new FlexBox().Direction(FlexDirection.Row);

// or

new FlexBox().Row();
```

#### AlignItems
The `AlignItems` method sets the `AlignItems` property on a `FlexBox`.

The following example sets the `AlignItems` to `FlexAlignItems.Center`:

```cs
new FlexBox().AlignItems(FlexAlignItems.Center);

// or

new FlexBox().CenterItems();
```

#### JustifyContent
The `JustifyContent` method sets the `JustifyContent` property on a `FlexBox`.

The following example sets the `JustifyContent` to `FlexJustify.Start`:

```cs
new FlexBox().JustifyContent(FlexJustify.SpaceBetween);

// or

new FlexBox().SpaceBetweenJustify();
```

#### Grow
The `Grow` method sets the `View.FlexParam().Grow` property on a `View`.
```cs
new TextView().Grow(.5f);
```

#### Shrink
The `Shrink` method sets the `View.FlexParam().Shrink` property on a `View`.
```cs
new TextView().Shrink(.5f);
```

#### AlignSelf
The `AlignSelf` method sets the `View.FlexParam().AlignSelf` property on a `View`.
```cs
new TextView().AlignSelf(FlexAlignSelf.Auto);

// or

new TextView().AutoAlign();
```

#### Basis
The `Basis` method sets the `View.FlexParam().Basis` property on a `View`.
```cs
new TextView().AutoBasis();

// or

new TextView().Basis(.5f);

// or

new TextView().RelativeBasis(.5f);
```

#### Order
The `Order` method sets the `View.FlexParam().Order` property on a `View`.
```cs
new TextView().Order(1);
```

### Grid
The `Grid` extensions provide a series of extension methods that support configuring a `Grid`.

#### Defining Rows and Columns

To define rows and columns for a `Grid`, `Tizen.UI.Layouts` provides two helper methods:
- `Columns.Define`
- `Rows.Define`

To leverage these helper methods, we first add the following `using static` directive to the top of our class:
```cs
using static Tizen.UI.Layouts.GridRowColumns;
```

After adding the above using `static directive`, we can then define our Row + Column sizes using the following values to set the `GridLength`:


Tizen.UI.Layout | XAML | Tizen.UI.Layouts.GridRowColumns
---|---|---
GridLength.Auto | Auto | Auto
GridLength.Star | * | Star
new GridLength(2, GridLength.Star) | 2* | Stars(2)
new GridLength(20, GridLength.Absolute) | 20 | 20

Putting it all together, we can now define a Grid's Rows + Columns:
```cs
new Grid
{
    ColumnDefinitions = Columns.Define(30, Star, Stars(2)),
    RowDefinitions = Rows.Define(Auto, Star),   
};
```

The following example demonstrates how to create a Grid with 2 Rows:
- Row 0 Size: `GridLength.Auto`
- Row 1 Size: `GridLength.Star`

The following example demonstrates how to create a Grid with 3 Columns:
- Column 0 Size: `new GridLength(30, GridLength.Absolute)`
- Column 1 Size: `GridLength.Star`
- Column 2 Size: `new GridLength(GridLength.Star, 2)`:

```cs
// Add this using static to enable Columns.Define and Rows.Define 
using static Tizen.UI.Layouts.GridRowColumns;

// ...

new Grid
{
    ColumnDefinitions = Columns.Define(30, Star, Stars(2)),
    RowDefinitions = Rows.Define(Auto, Star),

    new TextView()
        .Text("This TextView is in Row 0 Column 0")
        .Row(0).Column(0)

    new TextView()
        .Text("This TextView is in Row 0 Column 1")
        .Row(0).Column(1)

    new TextView()
        .Text("This TextView is in Row 0 Column 2")
        .Row(1).Column(2)

    new TextView()
        .Text("This TextView is in Row 1 Column 0")
        .Row(1).Column(0)

    new TextView()
        .Text("This TextView is in Row 1 Column 1")
        .Row(1).Column(1)

    new TextView()
        .Text("This TextView is in Row 1 Column 2")
        .Row(1).Column(2)
}
```

#### Row
The `Row` method sets the `Grid.Row` and `Grid.RowSpan` on a View.

The following example sets the `Grid.Row` of a TextView to 0 and its `Grid.RowSpan` to 2, then sets the `Grid.Row` of a TextView to 1:
```cs
new Grid
{
    new TextView()
        .Text("This TextView is in Row 0 and spans 2 Columns")
        .Column(0, 2),

    new TextView()
        .Text("This TextView is in Row 1 and does not span multiple columns")
        .Column(1)
};
```

#### Column
The `Column` method sets the `Grid.Column` and `Grid.ColumnSpan` on a `View`.

The following example sets the `Grid.Column` of a `TextView` to 0 and its `Grid.ColumnSpan` to 2, then sets the `Grid.Column` of a TextView to 1:

```cs
new Grid
{
     new Button()
        .Text("This TextView is in Row 0 and spans 2 Columns")
        .Column(0, 2),

    new TextView()
        .Text("This TextView is in Row 1 and does not span multiple columns")
        .Column(1)
};
```

### ScrollView
The `ScrollView` extensions provide a series of extension methods that support configuring `ScrollView`.

The extensions offer the following methods:

#### ScrollDirection #####

The `ScrollDirection` method sets the `ScrollDirection` property on a `ScrollView`.

The following example sets the `ScrollDirection` to `ScrollDirection.Both`:

```cs
new ScrollView().ScrollDirection(ScrollDirection.Both);

// or

new ScrollView().ScrollBoth();
```


#### HorizontalScrollBarVisibility ####
The `HorizontalScrollBarVisibility` method sets the `HorizontalScrollBarVisibility` property on a `ScrollView`.

The following example sets the `HorizontalScrollBarVisibility` to `ScrollBarVisibility.Auto`:

```cs
new ScrollView().HorizontalScrollBarVisibility(ScrollBarVisibility.Auto);

// or

new ScrollView().ScrollBarAutoHorizontal();
```

#### VerticalScrollBarVisibility ####
The `VerticalScrollBarVisibility` method sets the `VerticalScrollBarVisibility` property on a `ScrollView`.

The following example sets the `VerticalScrollBarVisibility` to `ScrollBarVisibility.Auto`:

```cs
new ScrollView().VerticalScrollBarVisibility(ScrollBarVisibility.Auto);

// or

new ScrollView().ScrollBarAutoVertical();
```

#### ScrollBarVisibility ####
The `ScrollBarVisibility` method sets both the `VerticalScrollBarVisibility` and `HorizontalScrollBarVisibility` properties on a `ScrollView`.

The following example sets both the `VerticalScrollBarVisibility` and `HorizontalScrollBarVisibility` to `ScrollBarVisibility.Auto`:

```cs
new ScrollView().ScrollBarVisibility(ScrollBarVisibility.Auto);

// or

new ScrollView().ScrollBarAuto();
```


## NUI XAML vs Tizen.UI C# Markup

#### NUI XAML
```xml
 <View
      x:Name="Card_CustomView_2765_2000"
      WidthSpecification="420"
      HeightSpecification="470"
      Position2D="2375,27.5"
      BackgroundColor="#bebebe93"
      CornerRadius="10,10,10,10">
      
      <View.Layout>
        <AbsoluteLayout />
      </View.Layout>

      <ImageView
          x:Name="ImageView_I2765_2000__1208_269"
          Name="ImageView"
          SizeWidth="323"
          SizeHeight="154"
          Position2D="49,38"
          ResourceUrl="image.png"/>

      <TextTextView
          x:Name="TextTextView_I2765_2000__1208_270"
          Name="TextTextView"
          SizeWidth="319"
          SizeHeight="144"
          PointSize="6.666666666666667"
          Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry"
          TextColor="#565656"
          VerticalAlignment="Top"
          MultiLine="True"
          Position2D="53,216"/>
</View>
```

#### Tizen.UI C# Markup
```cs
new AbsoluteLayout
{
    new VStack
    {
        new ImageView()
            .Name("ImageView_I2765_2000__1208_269")
            .DesiredWidth(323)
            .DesiredHeight(154)
            .ResourceUrl("image.png"),

        new TextView()
            .Name("TextTextView_I2765_2000__1208_270")
            .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
            .TextColorFromHex("#565656")
            .TextStartHorizontal()
            .MultiLine(true)
            .FontSize(30),
    }
    .DesiredWidth(420)
    .DesiredHeight(470)
    .CornerRadius(10)
    .BackgroundColorFromHex("#93bebebe")
    .LayoutBounds(0, 0, 1, 1)
    .LayoutFlags(AbsoluteLayoutFlags.All)
    .Margin(50)
    .Spacing(20)
}
```

## Design to Code Sample

```cs
public partial class HomeView : ContentView
    {
        void InitializeComponent()
        {
            Body = new AbsoluteLayout
            {
                // TitleScreenView
                new AbsoluteLayout
                {
                    new FlexBox
                    {
                        new Button("Read Information")
                                .Name("Button1")
                                .DesiredWidth(360)
                                .DesiredHeight(104)
                                .BackgroundColorFromHex("#9c9c9c8e"),
                        new View().Basis(20),
                        new Button("Watch Movie")
                            .Name("Button2")
                            .DesiredWidth(360)
                            .DesiredHeight(104)
                            .BackgroundColorFromHex("#9c9c9c8e"),
                    }
                    .LayoutBounds(1, 1, -1, -1)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 0, 30, 30),

                }.Name("TitleScreenView")
                .LayoutBounds(0, 0, 1, 288)
                .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.YProportional | AbsoluteLayoutFlags.WidthProportional)
                .Margin(132, 0, 0, 0)
                .Background(new ImageBackground().Url("HomeView/image_bdf20c83edb9cc3b1c96b1ba2a1bd630b0fb26bc.png")),

                // menu view
                new FlexBox
                {
                    new ImageView()
                        .ResourceUrl("HomeView/image_0501bb48512e3551323d2486d436d24018bc789a.png")
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_b4151edac073a3ef18e6149b2bd778576a72208c.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_6a5438811e38db84b5cbf3951139d6b7fcee4f50.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_61b42c24de586936a213c4a8095c2f200f85a211.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_8c69435f6623fb63639ee11eb2ef8c12e59cd7e2.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_9794436308e9b0a94233cc27310602e12d57925d.png")
                        .Center(),

                    new View().DesiredHeight(20),

                    new ImageView()
                        .DesiredHeight(80)
                        .DesiredWidth(80)
                        .ResourceUrl("HomeView/image_f15e3e559bb542faf10eb7673db400ad6e96ce5e.png")
                        .Center(),
                }
                .Name("MenuView")
                .Direction(FlexDirection.Column)
                .CenterItems()
                .CenterJustify()
                .Padding(10)
                .BackgroundColorFromHex("#3f4358")
                .Fill()
                .LayoutBounds(0, 0, 132, 1)
                .LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.YProportional | AbsoluteLayoutFlags.HeightProportional),

                // AppsView / scrollview
                new FlexBox
                {
                    new ScrollLayout
                    {
                        Content = new HStack
                        {
                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_730f1fe85421951b45279847df3e2aa225331b22.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_a60912bd871a95dcd5282e1169cd83bda38893fc.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_7b05959d8404880dee9416b42dcf7b5101312159.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_7aed9bc7eecc996e9fd1b4a80417a262eafacc1a.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_63df5fae2b4130161d55a8266a6702e20980071c.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_e1770480d25ca6787d718cebf4b06a9eabf44f44.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_5d8435f15dbf7f8c83d077e48dfa18812b208c34.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_45ba345bbd40cc8cfe07eb859371f314c5ac3c1f.png"),

                            new ImageView()
                                .DesiredSize(160,134)
                                .ResourceUrl("HomeView/image_63df5fae2b4130161d55a8266a6702e20980071c.png")
                        }
                        .Spacing(50)
                    }
                    .ScrollHorizontal()
                    .Margin(50, 0, 50, 0)
                    .DesiredHeight(230)
                    .Shrink(0),

                    // on now
                    new TextView()
                        .Text("On Now")
                        .FontSize(30)
                        .TextColorFromHex("#ffffff")
                        .TextStartHorizontal()
                        .Margin(50, 0, 0, 0)
                        .Shrink(0),

                    new ScrollLayout
                    {
                        Content = new HStack
                        {
                            // cardview
                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_d17b52bb046b52b3be7f87254f943f45595d77f5.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            // cardview
                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_354d454ca0c96093a60f0ee48a77e66a6f769844.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_bedcce857199c251bace03ea5704f6b5b3c3d30b.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_6782d2ef946031d0082350e5ab8ddff32840f2fb.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_7869bd74985903b244c81a849a10a93dcbc244a4.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),

                            new AbsoluteLayout
                            {
                                new VStack
                                {
                                    new ImageView()
                                        .DesiredHeight(154)
                                        .ResourceUrl("HomeView/image_d17b52bb046b52b3be7f87254f943f45595d77f5.png"),

                                    new TextView()
                                        .Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry")
                                        .TextColorFromHex("#565656")
                                        .MultiLine(true)
                                        .FontSize(30),

                                    new HStack
                                    {
                                        new Button("Summary")
                                            .DesiredSize(150, 49),

                                        new Button("Watch")
                                            .DesiredSize(150, 49),
                                    }
                                    .Spacing(20)
                                }
                                .Spacing(20)
                                .LayoutBounds(0, 0, 1, 1)
                                .LayoutFlags(AbsoluteLayoutFlags.All)
                                .Margin(50),
                            }
                            .DesiredSize(420, 470)
                            .CornerRadius(10)
                            .BackgroundColorFromHex("#93bebebe")
                            .Margin(50),
                        }
                    }
                    .ScrollHorizontal()
                }
                .BackgroundColorFromHex("#68768b")
                .Direction(FlexDirection.Column)
                .LayoutBounds(0, 0, 1, 1)
                .LayoutFlags(AbsoluteLayoutFlags.All)
                .Margin(132, 288, 0, 0),
            }.Name("Frame")
             .BackgroundColorFromHex("#ffffff");
        }
    }
```