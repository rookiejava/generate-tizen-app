## Layout bacsics
#### Measure기반 레이아웃
 * 모든 View의 크기는 Measure를 통해 측정 가능하다
 * Layout도 Measure를 통해 그 크기를 측정할 수 있으며, Layout은 고정된 크기로 크기가 설정되지 않은 이상 Children을 measure해서 가장 Fit한 크기로 measure가 된다. 
 * Measure되는 크기를 임의로 Fixed된 크기로 설정하기 위해서는 `DesiredWidth` / `DesiredHeight`를 설정하면 된다. 

#### 레이아웃을 사용할 때, 버려야 할 것들
 * `X`, `Y`, `Width`, `Height` : 크기와 위치는 Layout에 의해서 업데이트 되기 때문에 해당 속성을 설정하더라도 Layout에 의해서 다시 덮어 씌어짐
 * `WidthResizePolicy`, `HeightResizePolicy` : 이 두 속성은 ViewGroup에 Add되었을 때 크기를 변경하는 옵션이기에 Layout에 Add될 때는 적용되지 않음
 * `ParentOrigin`, `PivotPoint`, `PositionUsesPivotPoint` : 이 속성들은 View의 좌표 체계를 변경하는 속성으로 해당 옵션을 사용하면 Layout이 생각하는 배치 위치가 아닌 다른 위치에 View가 배치될 수 있어서 사용하면 안됨

#### Root Layout이란
 * Layout의 Parent가 Layout이 아닌 Layout은 개념적으로 Root Layout이라고 부르고
   Root Layout은 크기(`Width`/`Height`)를 직접 설정하거나 ViewGroup이나 Layer에 추가 될 때 `WidthResizePolicy`/`HeightResizePolicy`에 의해서 자동으로 크기가 설정된다. 
 * 따라서 Root Layout만 Measure를 통해 크기가 결정되는 것이 아닌 Layer에 추가되거나 ViewGroup에 추가되어 `ResizePolicy`의 영향을 받아 설정된 크기가 Root Layout의 크기가 된다.


#### 레이아웃이 배치한 공간과 View의 Measure된 크기와의 간극
 * Layout은 View가 설정한 Layout옵션에 의해서 View에게 공간을 할당하는데, 이때 View의 measure된 크기가 차이가 발생할 수 있다.(measure된 크기가 더 작을 수 있다)

 * 이 경우 Layout이 View에게 할당한 공간과 View의 measure된 크기와의 차이로 여백이 발생하는데, 이 여백을 처리하는 방식에 대한 옵션이 존재한다.

##### LayoutAlignment
|Option|Description|
|-|-|-|
|Fill|Fill the entire area if possible.|
|Start|Align with the leading edge of the available space, as determined by `View.LayoutDirection`.|
|Center|The center of an alignment.|![image](https://media.github.sec.samsung.net/user/376/files/8d2b730b-2310-4d4d-85d2-491f298359e6)|
|End|Align with the trailing edge of the available space, as determined by `View.LayoutDirection`.|

각 축에 대해서 개별적으로 설정, `View`.`HorizontalLayoutAlignment()` / `View`.`VerticalLayoutAlignment()`
기본 값이 `Fill`이기 때문에, Layout이 할당한 공간을 채워서 배치하는 것이 기본 동작.
**그러나 예외적으로 DesiredWidth/Height가 설정될 경우 그 크기를 존중해서 Fill이 설정되어 있을지라도, 지정된 크기로만 배치하고 Align은 Center로 설정됨**

 *  **중요** : `Fill`은 `FillToParent`와는 완전 다른 성격의 옵션입니다. `Fill`옵션을 사용하더라도 Layout을 모두 채우는 배치가 되지 않습니다.
 * **Layout의 각자의 고유의 알고리즘에 의해서 배치된 결과가** View의 실제 크기 (measure된 크기)와 다를 때 배치하는 옵션입니다.