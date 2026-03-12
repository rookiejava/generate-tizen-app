## Layout FAQ
***
### Width/Height 대신 무엇을 사용해야 하나요?
 * `DesiredWidth`/`DesiredHeight`를 사용하세요. `DesiredWidth`, `DesiredHeight`는 View의 Measure의 결과로 사용되어 Layout이 배치할 때, 그 크기로 배치할 수 있게 합니다.

***

### View를 Layout에 가득 채우는 배치는 어떻게 해야 되나요?
 * Layout의 종류마다 방법이 다릅니다.
 * 단 Layout의 크기는 이미 결정되어 있어야 합니다. 즉 DesiredWidth/Height를 설정한 Layout이거나 Root Layout(부모가 Layout이 아닌)이어야 합니다.
#### AbsoluteLayout
 * View의 `LayoutBounds`를 `0, 0, 1, 1`로 설정하고, `LayoutFlags`를 `All`로 설정합니다.
``` c#
new AbsoluteLayout
{
    Children =
    {
        new View().LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All)
    }
}
```
#### HStack / VStack
 * `Expand()`옵션을 사용하세요.
``` c#
new HStack
{
    Children =
    {
        new View().Expand()
    }
}
```
#### Grid
 * Row/Column을 1개만 정의하고 그 값으로 Star를 사용하세요.
``` c#
new Grid
{
    RowDefinitions = { GridLength.Star },
    ColumnDefinitions = { GridLength.Star },
    Children =
    {
        new View()
    }
}
```

***

### View를 정 가운데 배치하려면 어떻게 하나요?
 * Layout 종류마다 방법이 다릅니다.
 * Layout의 크기도 결정되어 있어야 하고, View의 크기가 있어야 합니다. (measure시에 값을 줄 수 있는 View이거나 DesiredWidth/Height가 설정되어 있어야 합니다.)

#### AbsoluteLayout
 * LayoutBound에서 X/Y를 0.5f로 설정하고 Width/Height를 -1(Auto)로 설정하고 LayoutFlags를 PositionProportional로 설정합니다.
``` C#
new AbsoluteLayout
{
    Children =
    {
        new Label
        {
            Text = "Hello world"
        }
        .LayoutBounds(0.5f, 0.5f, -1, -1)
        .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
    }
}
```
#### HStack
 * HStack의 ItemAlignment를 Center로 설정하고 (한 개 있는 View를 Horizontally 가운데로 배치한다), View의 VerticalLayoutAlignment를 Center로 (View의 높이 보다 더 큰 공간에 대해 View를 가운데 위치 하게 한다) 설정한다.
``` c#
new HStack
{
    ItemAlignment = LayoutAlignment.Center,
    Children =
    {
        new Label
        {
            Text = "Hello world"
        }
        .VerticalLayoutAlignment(LayoutAlignment.Center)
    }
}
```
#### VStack
 * VStack의 ItemAlignment를 Center로 설정하고 (한 개 있는 View를 Vertically 가운데로 배치한다), View의 HorizontalLayoutAlignment를 Center로 (View의 넓이 보다 더 큰 공간에 대해 View를 가운데 위치 하게 한다) 설정한다.
``` c#
new VStack
{
    ItemAlignment = LayoutAlignment.Center,
    Children =
    {
        new Label
        {
            Text = "Hello world"
        }
        .HorizontalLayoutAlignment(LayoutAlignment.Center)
    }
}
```
#### Grid
 * 전체를 채우는 배치에서, View의 LayoutAlignment를 Center(View의 넓이/높이 보다 더 큰 공간에 대해 가운데 View를 배치 시키는)로 설정합니다. 
``` c#
new Grid
{
    RowDefinitions = { GridLength.Star },
    ColumnDefinitions = { GridLength.Star },
    Children =
    {
        new Label
        {
            Text = "Hello world"
        }
        .VerticalLayoutAlignment(LayoutAlignment.Center)
        .HorizontalLayoutAlignment(LayoutAlignment.Center),
    }
}
```
***
### View를 어떻게 전체 화면에 배치하나요?
 * Layer에 View를 넣고 `WidthResizePolicy`와 `HeightResizePolicy`를 `ResizePolicy.FillToParent`로 설정하면 됩니다. (ViewGroup(Layout)은 기본 값이 `ResizePolicy.FillToParent`이기 때문에 그냥 Layer에 넣기만 하면 됩니다)

``` c#
Window.Default.DefaultLayer.Add(new View
{
    WidthResizePolicy = ResizePolicy.FillToParent,
    HeightResizePolicy = ResizePolicy.FillToParent,
}); 
```