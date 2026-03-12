## AbsoluteLayout
### 개요
 * View를 고정된 공간 또는 상대적인 비율의 공간에 배치하는 Layout
### Measure 규칙
 * Layout의 크기가 Fixed가 아닌 경우,
  각 children의 AbsoluteParam을 통해 명세된 위치와 크기가 그리는 가장 최외각 바운드가 Layout이 Measure하는 크기가 된다.


### Layout options
#### Child에 설정하는 옵션
##### LayoutBounds
``` c#
 view.LayoutBounds(x, y, width, height);
```

 * View가 배치될 위치와 크기를 LayoutBounds를 통해 지정한다. 값으로 설정 가능하고, 비율로도 설정 가능하다. 


 * 비율로 설정하는 경우, 
    * 위치는 0이면 시작 위치에서 붙어서 시작되며, 1이면 끝 위치에 붙어서 배치된다. 
    * 크기의 경우 Layout크기에 비례하여 지정되며 1일 경우 Layout의 크기와 일치 된다.
 * 크기에 -1값을 지정하면 View가 원래 갖는 Measure된 값으로 자동으로 배치된다. 

##### LayoutFlags 
``` c#
 view.LayoutFlags(flags);
```
 * LayoutBounds에 설정한 값이 각각 비율인지 값인지 설정하는 옵션이다. 기본 값은 None으로 LayoutBounds에 설정된 X/Y/Width/Height가 절대값으로 인식된다.

|Flag| Description|
|-|-|
|None|No flags set|
|XProportional|Indicates that the X position of the child element should be proportional to its parent.|
|YProportional|Indicates that the Y position of the child element should be proportional to its parent.|
|WidthProportional|Indicates that the width of the child element should be proportional to its parent.|
|HeightProportional|Indicates that the height of the child element should be proportional to its parent.|
|PositionProportional|Indicates that both the X and Y positions of the child element should be proportional to its parent.|
|SizeProportional|Indicates that both the width and height of the child element should be proportional to its parent.|
|All|Indicates that all properties of the child element should be proportional to its parent.|

 * 개별 Flag를 bit or연산으로 결합 할 수 있다. 
``` c#
 view.LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional); //X축과 Width를 비율로 설정
```

### 사용 예
* 600x600의 AbsoluteLayout안에 100x100의 Red View를 가운데(0.5,0.5)에 크기 만큼(-1x-1) 배치한다.
``` c#
new AbsoluteLayout
{
    DesiredWidth = 600,
    DesiredHeight = 600,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
            DesiredHeight = 100,
            DesiredWidth = 100,
        }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
    }
}
```


***

* LayoutBounds로 크기를 직접 지정하여 배치
``` c#
new AbsoluteLayout
{
    DesiredWidth = 600,
    DesiredHeight = 600,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
        }.LayoutBounds(0.5f, 0.5f, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
    }
}
```

***

* DesiredWidth/Height를 사용한 것과 LayoutBounds를 사용하여 크기를 지정한 것에 차이점
* DesiredWidth/Height는 Margin을 크기를 제외한 크기, LayoutBounds의 크기는 Margin을 포함한 크기로 계산 된다. 

``` c#
new AbsoluteLayout
{
    DesiredWidth = 600,
    DesiredHeight = 600,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
            DesiredWidth = 100,
            DesiredHeight = 100,
        }.LayoutBounds(0.5f, 0.5f, -1, -1)
         .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
         .Margin(10)
    }
}
```
``` c#
new AbsoluteLayout
{
    DesiredWidth = 600,
    DesiredHeight = 600,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
        }.LayoutBounds(0.5f, 0.5f, 100, 100)
         .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
         .Margin(10)
    }
}
```


***

 * `PositionProportional`과 Margin을 사용하여 responsive하게 동작하기
 * 크기에 상관 없이 항상 우측 하단에 배치하기
``` c#
new AbsoluteLayout
{
    DesiredWidth = 600,
    DesiredHeight = 600,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
            DesiredHeight = 100,
            DesiredWidth = 100,
        }.LayoutBounds(1f, 1f, -1, -1)
         .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
         .Margin(0, 0, 100, 100)
    }
}
```



