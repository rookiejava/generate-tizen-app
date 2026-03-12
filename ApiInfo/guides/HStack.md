# HStack
## 개요
 * Child를 수평으로 순차적으로 배열

## Measure규칙
 * Layout의 크기가 Fixed가 아닌 경우
   * Width는 모든 children의 Width의 합으로 계산된다. 
   * Height는 children중 가장 height가 큰 것으로 height가 결정된다. 

## 배치 규칙
 * Child의 Size를 measure하여 measure된 width만큼 순차적으로 수평 방향으로 child를 배치한다.
 * child의 넓이의 경우 measure된 크기를 기반으로 공간이 할당 되기 때문에, 할당된 공간과 child의 넓이의 차이가 발생하지 않는다.
 * child의 높이의 경우 child중 가장 높이가 큰 높이로 공간이 할당 되기 때문에, 할당된 공간과 child의 높이에 차이가 발생한다. 따라서 여기에 VerticalLayoutAlignment가 적용된다. 

## Layout Options
### Layout에 설정되는 옵션
#### Spacing
 * child간 간격을 설정 한다.
``` c#
 hstack.Spacing(value);
```

#### ItemAlignment
 * Children을 배치하고 남은 공간을 처리할 방식을 결정한다. 동작 조건으로는 Layout의 Size가 고정된 크기로 결정 되어 있어야 하고, Children을 모두 배치하고 남는 공간이 존재해야 한다. 

``` c#
 hstack.ItemAlignment(align);
```

### Child에 설정되는 옵션
#### VerticalLayoutAlignment
 * 수직 방향으로 Child가 배치될 방식을 결정한다. 

``` c#
 view.VerticalLayoutAlignment(align);
```

   앞선 설명에서 HStack의 높이는 가장 큰 child의 높이로 설정된다고 하였기에, HStack의 높이가 Child의 높이보다 더 큰 상황이 존재한다. 이때 child의 높이보다 더 긴 공간을 배치하는 방식을 결정한다. 

|Option|Description|
|-|-|
|LayoutAlignment.Fill| Fill the entire area if possible. |
|LayoutAlignment.Start|Align with the leading edge of the available space, as determined by `View.LayoutDirection`. |
|LayoutAlignment.Center|The center of an alignment.|
|LayoutAlignment.End|Align with the trailing edge of the available space, as determined by `View.LayoutDirection` |

이 옵션의 기본 값은 `Fill`이다. 별도로 설정하지 않으면 HStack의 높이 만큼 child의 높이가 설정된다. 단, 예외적으로 `DesiredHeight`가 설정되어 있을 경우, `Fill`로 설정되어 있더라도 `DesiredHeight`만큼만 설정되며 `Center`로 정렬된다.

#### Expand
 * HStack의 남는 공간 만큼 Child의 넓이를 확장시키는 옵션이다. 이 옵션이 동작하기 위해서는 HStack이 고정된 크기로 설정되어 있어야 하고 Children이 measure된 넓이 보다 더 큰 공간이 있어야 한다. 

``` c#
 view.Expand(); 
 view.Expand(2);
```

 * HStack안에 2개 이상의 View에 Expand가 설정될 경우 남는 공간을 Expand에 설정한 값을 기준으로 비율대로 분배하여 할당 한다. Expand에 인자 없이 호출한 경우 1로 설정된다.


## 사용 예

<table>
<tr>
 <td> 코드 </td>
 <td> 동작 </td>
</tr>
<tr>
<td>

``` c#
new HStack
{
    DesiredWidth = 800,
    DesiredHeight = 300,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
            DesiredHeight = 100,
            DesiredWidth = 100,
        },
        new View
        {
            BackgroundColor = Color.Green,
            DesiredWidth = 300,
        },

        new View
        {
            BackgroundColor = Color.Yellow,
            DesiredHeight = 150,
            DesiredWidth = 200,
        }.VerticalLayoutAlignment(LayoutAlignment.Start),
    }
}
```

</td>
<td>

</td>
</tr>
<tr>
<td colspan=2>
 녹색 View의 경우 높이가 `DesiredHeight`로 설정되어 있지 않기 때문에 `VertialLayoutAlignment`의 기본값인 `Fill`이 적용되어 HStack의 높이 만큼 설정되었고,
 마찬가지로 노란색 View도 높이가 `DesiredHeight`로 설정되어 있지 않지만, `VertialLayoutAlignment`를 `Start`로 설정 했기 때문에 위쪽에 붙어서 배치 되었다.
</td>
</tr>
</table>


***

<table>
<tr>
 <td> 코드 </td>
 <td> 동작 </td>
</tr>
<tr>
<td>

``` c#
new HStack
{
    DesiredWidth = 800,
    DesiredHeight = 300,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
            DesiredWidth = 100,
        },
        new View
        {
            BackgroundColor = Color.Green,
        }.Expand(),
        new View
        {
            BackgroundColor = Color.Yellow,
            DesiredWidth = 200,
        },
    }
}
```

</td>
<td>

</td>
</tr>
<tr>
<td colspan=2>
 녹색 View에 Expand가 적용 되었기 때문에, 빨간 View와 노란 View가 차지하는 넓이를 제외하고 남은 넓이가 모두 녹색 View에게 배치되었다.
</td>
</tr>
</table>

***

<table>
<tr>
 <td> 코드 </td>
 <td> 동작 </td>
</tr>
<tr>
<td>

``` c#
new HStack
{
    DesiredWidth = 800,
    DesiredHeight = 300,
    BackgroundColor = Color.LightBlue,
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
            DesiredWidth = 100,
        },
        new View
        {
            BackgroundColor = Color.Green,
            DesiredWidth = 100,
        }.Expand().HorizontalLayoutAlignment(LayoutAlignment.Start),
        new View
        {
            BackgroundColor = Color.Yellow,
            DesiredWidth = 200,
        },
    }
}
```

</td>
<td>

</td>
</tr>
<tr>
<td colspan=2>
 위 예제에서 2가지만 변경되었는데, 녹색 View의 DesiredWidth가 100으로 설정 되었고 HorizontalLayoutAlignment가 Start로 설정되었다.
 Expand로 인해서 녹색 View의 넓이는 HStack의 남은 공간으로 할당 되었지만 View의 실제 넓이(DesiredWidth)와 차이가 발생하였고, 그 남는 공간을 체우는 방식이 Start이기 때문에 녹색 View가 앞쪽으로 배치되었고 그 남는 공간은 그대로 남는 공간으로 남아 있게 된다.

즉, 공간은 넓게 할당 받았지만, 배치는 할당 받은 공간을 여백으로 두는 방식(Start)을 선택 했기에 저런 모양으로 배치가 된다.
</td>
</tr>
</table>