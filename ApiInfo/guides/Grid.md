# Grid
## 개요
 * 특정 사이즈로 Row와 Column을 정의하고 이 기반으로 child를 특정 row/column에 배치하는 레이아웃
 * MAUI의 Grid레이아웃과 동일한 동작 https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/grid?view=net-maui-8.0
## Meausre 규칙
 * RowDefinitions와 ColumnDefinitions에 GridLength를 통해 명세된 크기를 기반으로 크기가 결정됨

## 배치 규칙
 * Row/Column index에 의해서 지정된 cell에 child를 배치

## Layout Options
### Grid에 설정되는 옵션
#### RowDefinitions / ColumnDefinitions
``` c#
grid.RowDefinition.Add(length);
grid.ColumnDefinitions.Add(length);
```
 * 생성시에 객체 이니셜라이저를 사용하여 설정 하는 예
``` c#
new Grid {
   RowDefinitions = {
       200,
       GridLength.Start,
       GridLength.Auto,
   },
   ColumnDefinitions = {
       GridLength.Start,
   }
}
```
### GridLength
|GridLength| Description |
|-|-|
|`GridLength.Auto` | Cell에 포함된 View의 크기를 measure하여 그 크기로 설정 |
|`GridLength.Star` | Grid의 남은 공간을 확장하여 크기로 설정 |
|`float`| Fixed 크기로 Cell 크기를 설정 |

### ColumnSpacing
``` c#
grid.ColumnSpacing = value;
```
 * Column간 간격을 설정
### RowSpacing
``` c#
grid.RowSpacing = value;
```
 * Row간 간격 설정

### Child에 설정되는 옵션
#### Row
``` c#
view.Row(value);
```
 * child가 배치될 Row를 선택
#### Column
``` c#
view.Column(value);
```
 * child가 배치될 Column을 선택

#### RowSpan
``` c#
view.RowSpan(value);
```
 * child이 배치될 Row의 갯수를 설정

#### ColumnSpan
``` c#
view.ColumnSpan(value);
```
 * child이 배치될 Column의 갯수를 설정

## 사용 예
<table>
<tr>
  <td> 코드 </td>
  <td> 동작 </td>
</tr>
<tr>
  <td>

``` c#
new Grid
{
    DesiredWidth = 800,
    DesiredHeight = 350,
    BackgroundColor = Color.LightGray,
    RowDefinitions = { 100, GridLength.Auto, GridLength.Star },
    ColumnDefinitions = { GridLength.Star, GridLength.Star },
    Children =
    {
        new View
        {
            BackgroundColor = Color.Red,
        }.Row(0).Column(0),
        new View
        {
            BackgroundColor = Color.LightPink,
        }.Row(0).Column(1),

        new View
        {
            BackgroundColor = Color.Blue,
            DesiredHeight = 200,
        }.Row(1).Column(0).ColumnSpan(2),
        new View
        {
            BackgroundColor = Color.Green,
        }.Row(2).Column(0),

        new View
        {
            BackgroundColor = Color.LightBlue,
        }.Row(2).Column(1),
    }
}
```

  </td>
  <td>


  </td>
</tr>
<tr>
 <td colspan=2>
 800x350으로 고정 크기의 Grid이고
 Row는 `100`, `GridLength.Auto`, `GridLength.Star`로 설정되어 있어서 첫번째 Row는 100, 두번째 Row는 거기에 위치하는 Blue View의 높이인 200, 마지막 Row는 Star로서 남은 공간이 할당 되어 50이 된다. 
 Column은 GridLength.Star, GridLength.Star로 설정 되어 있어서 Width인 800을 각 셀이 균등하게 배분되어 400, 400으로 각 셀의 넓이가 설정된다. 
 Blue View의 경우 ColumnSpan이 2이기 때문에 두 Column에 걸쳐서 배치가 된다. 
 </td>
</tr>
</table>

***

<table>
<tr>
  <td> 코드 </td>
</tr>
<tr>
  <td>

``` c#
new Grid
{
    DesiredWidth = 800,
    DesiredHeight = 100,
    BackgroundColor = Color.LightGray,
    ColumnDefinitions = { GridLength.Star, GridLength.Star, GridLength.Star, GridLength.Star },
    RowDefinitions = { GridLength.Star, 10 },
    Children =
    {
        new View
        {
            BorderlineColor = Color.Black,
            BorderlineWidth = 1,
            BackgroundColor = Color.LightGreen,
        }.Row(0).Column(0).RowSpan(2),
        new View
        {
            BorderlineColor = Color.Black,
            BorderlineWidth = 1,
            BackgroundColor = Color.LightGreen,
        }.Row(0).Column(1).RowSpan(2),
        new View
        {
            BorderlineColor = Color.Black,
            BorderlineWidth = 1,
            BackgroundColor = Color.LightGreen,
        }.Row(0).Column(2).RowSpan(2),
        new View
        {
            BorderlineColor = Color.Black,
            BorderlineWidth = 1,
            BackgroundColor = Color.LightGreen,
        }.Row(0).Column(3).RowSpan(2),

        // indicator
        new View
        {
            BackgroundColor = Color.Black,
        }.Row(1).Column(1),
    }
}
```

  </td>
</tr>
<tr>
<td> 동작 </td>
</tr>
<tr>
 <td>

 </td>
</tr>
<tr>
<td>
 Row는 Star와 10으로 정의되어 있기 때문에, 총 높이 100에서 10을 제외한 높이와 10의 높이를 갖는 두 Row가 설정되고
 Column은 Star가 4개로 정의되어 있기 때문에, 총 넓이 800을 4로 나눠서 각각 200의 넓이를 갖는 4개의 Column이 설정된다. 
 LightGreen View들은 RowSpan을 2로 설정하였기에 높이를 모두 체우도록 배치되고
 Indicator로 만든 View는 Row 1와 Column 1로 설정되어 있기 때문에 Row 정의에서 10에 해당하는 셀에 배치되고 Column 1에 대응되는 두번째 칸에 배치된다.
 그리고 LightGreen View와 Row(1), Column(1) 셀을 공유하여 배치되어 있기 때문에 그 공간 만큼 겹쳐서 배치가 된다. 
</td>
</tr>
</table>



