# Layout comparison (Tizen.NUI vs Tizen.UI)

### Pivot & ParentOrigin vs AbsoluteLayout

#### Center align View
<table>
<tr>
 <td colspan=2 align=center> </td>
</tr>
<tr>
  <td> <b>Legacy Layout (Tizen.NUI)></b> </td>
  <td> <b>New Layout (Tizen.UI)</b> </td>
</tr>
<tr>
  <td>

``` c#
var layout = new View
{
    SizeWidth = 300,
    SizeHeight = 300,
    BackgroundColor = Color.White,
};
var view = new View
{
    SizeWidth = 100,
    SizeHeight = 100,
    BackgroundColor = Color.Green,
    PivotPoint = Position.PivotPointCenter,
    ParentOrigin = Position.ParentOriginCenter,
    PositionUsesPivotPoint = true,
};
layout.Add(view);
```
  </td>
  <td> 

``` c#

new AbsoluteLayout
{
    DesiredWidth = 300,
    DesiredHeight = 300,
    BackgroundColor = Color.White,
    Children =
    {
        new View
        {
            DesiredHeight = 100,
            DesiredWidth = 100,
            BackgroundColor = Color.Green,
        }.LayoutBounds(0.5f, 0.5f, -1, -1)
         .LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
    }
};

```
 </td>
</tr>
</table>

#### Center Right Align View
<table>
   <tr>
       <td> <b>Legacy Layout (Tizen.NUI)></b> </td>
       <td> <b>New Layout (Tizen.UI)</b> </td>
   </tr>
<tr>
  <td>

``` c#
var layout = new View
{
    SizeWidth = 300,
    SizeHeight = 300,
    BackgroundColor = Color.White,
};
var view = new View
{
    SizeWidth = 100,
    SizeHeight = 100,
    BackgroundColor = Color.Green,
    PivotPoint = Position.PivotPointCenterRight,
    ParentOrigin = Position.ParentOriginCenterRight,
    PositionUsesPivotPoint = true,
};
layout.Add(view);
```
  </td>
  <td> 

``` c#

new AbsoluteLayout
{
    DesiredWidth = 300,
    DesiredHeight = 300,
    BackgroundColor = Color.White,
    Children =
    {
        new View
        {
            DesiredHeight = 100,
            DesiredWidth = 100,
            BackgroundColor = Color.Green,
        }.LayoutBounds(1, 0.5f, -1, -1)
         .LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
    }
};

```
 </td>
</tr>
</table>

#### Center Right Align View with right margin
<table>
   <tr>
       <td> <b>Legacy Layout (Tizen.NUI)></b> </td>
       <td> <b>New Layout (Tizen.UI)</b> </td>
   </tr>
<tr>
  <td>

``` c#
var layout = new View
{
    BackgroundColor = Color.White,
    SizeWidth = 300,
    SizeHeight = 300,
};
var view = new View
{
    SizeWidth = 100,
    SizeHeight = 100,
    BackgroundColor = Color.Green,
    PivotPoint = Position.PivotPointCenterRight,
    ParentOrigin = Position.ParentOriginCenterRight,
    PositionUsesPivotPoint = true,
    PositionX = -50,
};
layout.Add(view);
```
  </td>
  <td> 

``` c#

new AbsoluteLayout
{
    DesiredWidth = 300,
    DesiredHeight = 300,
    BackgroundColor = Color.White,
    Children =
    {
        new View
        {
            DesiredHeight = 100,
            DesiredWidth = 100,
            BackgroundColor = Color.Green,
        }.LayoutBounds(1, 0.5f, -1, -1)
         .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
         .Margin(0, 0, 50, 0),
    }
};

```
 </td>
</tr>
</table>

### LinearLayout vs HStack
#### Simple example
<table>
   <tr>
       <td> <b>Legacy Layout (Tizen.NUI)></b> </td>
       <td> <b>New Layout (Tizen.UI)</b> </td>
   </tr>
<tr>
  <td>

``` c#
var linearLayout = new View
{
    SizeWidth = 700,
    SizeHeight = 100,
    BackgroundColor = Color.White,
    Layout = new LinearLayout
    {
        LinearOrientation = LinearLayout.Orientation.Horizontal
    }
};

var first = new View
{
    SizeWidth = 100,
    HeightSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Blue,
};
linearLayout.Add(first);

var second = new View
{
    SizeWidth = 200,
    HeightSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Green
};
linearLayout.Add(second);

var third = new View
{
    SizeWidth = 300,
    HeightSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Red
};
linearLayout.Add(third);

```
  </td>
  <td> 

``` c#
new HStack
{
    DesiredWidth = 700,
    DesiredHeight = 100,
    BackgroundColor = Color.White,
    Children =
    {
        new View
        {
            DesiredWidth = 100,
            BackgroundColor = Color.Blue,
        },
        new View
        {
            DesiredWidth = 200,
            BackgroundColor = Color.Green,
        },
        new View
        {
            DesiredWidth = 300,
            BackgroundColor = Color.Red,
        }
    }
}
```
 </td>
</tr>
</table>

#### Expand example
<table>
   <tr>
       <td> <b>Legacy Layout (Tizen.NUI)></b> </td>
       <td> <b>New Layout (Tizen.UI)</b> </td>
   </tr>
<tr>
  <td>

``` c#
var linearLayout = new View
{
    SizeWidth = 600,
    SizeHeight = 100,
    BackgroundColor = Color.White,
    Layout = new LinearLayout
    {
        LinearOrientation = LinearLayout.Orientation.Horizontal
    }
};

var first = new View
{
    SizeWidth = 100,
    HeightSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Blue,
};
linearLayout.Add(first);

var secondExpand = new View
{
    WidthSpecification = LayoutParamPolicies.MatchParent,
    HeightSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Green
};
linearLayout.Add(secondExpand);

var third = new View
{
    SizeWidth = 100,
    HeightSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Red
};
linearLayout.Add(third);
```
  </td>
  <td> 

``` c#
new HStack
{
    DesiredWidth = 600,
    DesiredHeight = 100,
    BackgroundColor = Color.White,
    Children =
    {
        new View
        {
            DesiredWidth = 100,
            BackgroundColor = Color.Blue,
        },
        new View
        {
            BackgroundColor = Color.Green,
        }.Expand(),
        new View
        {
            DesiredWidth = 100,
            BackgroundColor = Color.Red,
        }
    }
}

```
 </td>
</tr>
</table>

### LinearLayout vs VStack
#### Simple example
<table>
   <tr>
       <td> <b>Legacy Layout (Tizen.NUI)></b> </td>
       <td> <b>New Layout (Tizen.UI)</b> </td>
   </tr>
<tr>
  <td>

``` c#
var linearLayout = new View
{
    SizeWidth = 100,
    SizeHeight = 700,
    BackgroundColor = Color.White,
    Layout = new LinearLayout
    {
        LinearOrientation = LinearLayout.Orientation.Vertical
    }
};

var first = new View
{
    SizeHeight = 100,
    WidthSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Blue,
};
linearLayout.Add(first);

var second = new View
{
    SizeHeight = 200,
    WidthSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Green
};
linearLayout.Add(second);

var third = new View
{
    SizeHeight = 300,
    WidthSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Red
};
linearLayout.Add(third);

```
  </td>
  <td> 

``` c#
new VStack
{
    DesiredWidth = 100,
    DesiredHeight = 700,
    BackgroundColor = Color.White,
    Children =
    {
        new View
        {
            DesiredHeight = 100,
            BackgroundColor = Color.Blue,
        },
        new View
        {
            DesiredHeight = 200,
            BackgroundColor = Color.Green,
        },
        new View
        {
            DesiredHeight = 300,
            BackgroundColor = Color.Red,
        }
    }
}
```
 </td>
</tr>
</table>

#### Expand example
<table>
   <tr>
       <td> <b>Legacy Layout (Tizen.NUI)></b> </td>
       <td> <b>New Layout (Tizen.UI)</b> </td>
   </tr>
<tr>
  <td>

``` c#
var linearLayout = new View
{
    SizeWidth = 100,
    SizeHeight = 600,
    BackgroundColor = Color.White,
    Layout = new LinearLayout
    {
        LinearOrientation = LinearLayout.Orientation.Vertical
    }
};

var first = new View
{
    SizeHeight = 100,
    WidthSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Blue,
};
linearLayout.Add(first);

var secondExpand = new View
{
    WidthSpecification = LayoutParamPolicies.MatchParent,
    HeightSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Green
};
linearLayout.Add(secondExpand);

var third = new View
{
    SizeHeight = 100,
    WidthSpecification = LayoutParamPolicies.MatchParent,
    BackgroundColor = Color.Red
};
linearLayout.Add(third);

```
  </td>
  <td> 

``` c#
new VStack
{
    DesiredWidth = 100,
    DesiredHeight = 600,
    BackgroundColor = Color.White,
    Children =
    {
        new View
        {
            DesiredHeight = 100,
            BackgroundColor = Color.Blue,
        },
        new View
        {
            BackgroundColor = Color.Green,
        }.Expand(),
        new View
        {
            DesiredHeight = 100,
            BackgroundColor = Color.Red,
        }
    }
}
```
 </td>
</tr>
</table>