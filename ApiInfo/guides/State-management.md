## UIState

아래는 `View`가 가질 수 있는 기본 상태에 대한 설명이며, 모든 상태는 중첩이 가능하다.

State                  | Target                | Description
--                     | --                    | --
`UIState.Normal`       | 모든 `View`         | 어떤 상태도 가지지 않음을 나타냄 (default)
`UIState.Disabled`     | 모든 `View`         | `View.IsEnabled` 값이 false 가 될 때 발생
`UIState.Focused`      | 모든 `View`         | `View.IsFocused` 값이 true 가 될 때 발생 [tip](## "`FocusManager.Instance.SetFocus()` 로 설정 가능")
`UIState.Pressed`      | `IPressable`을 구현한 `View`   | `IPressable.IsPressed` 값이 true 가 될 때 발생
`UIState.Selected`     | `ISelectable`]을 구현한 `View`  | `ISelectable.IsSelected` 값이 true 가 될 때 발생

<br/>


`Pressed`와 `Selected` 는 어떤 View든 상응하는 인터페이스를 구현하기만 하면 해당 상태를 가질 수 있으며, Tizen.UI 컴포넌트 중 해당 인터페이스들을 구현한 클래스들은 아래와 같다.
 
## State Events

기본적으로 제공되는 상태 변경 이벤트는 `AddStateChangedEventHandler`로 제공된다.

```C#
button.AddStateChangedEventHandler(OnStateChanged);
```
```C#
private void OnStateChanged(object sender, UIStateChangedEventArgs e)
{
    // ...
};
```

코드 작성 편의를 위해 method chain 형식으로 제공되는 `When`도 같은 기능을 한다.

```C#
button.When((sender, e) =>
{
    // ...
});
```
`When`의 경우 콜백의 첫번째 인자인 sender의 타입이 `object`가 아니라 caller 타입을 그대로 계승한다는 차이점이 있다.

<br/>

#### UIStateChangedEventArgs

이벤트 인자로 넘어오는 `UIStateChangedEventArgs` 는 상태 변경 정보를 담고 있다.

```C#
e.Previous; // Focused, Selected
e.Current;  // Focused, Pressed
```

`==` operator 등을 이용해 간단하게 state 비교가 가능하다
```C#
e.Current == UIState.Focused;  // false
e.Current.Contains(UIState.Focused);  // true
e.Current == (UIState.Focused + UIState.Pressed);  // true
e.Current == (e.Previous - UIState.Selected + UIState.Pressed);  // true
```

상태는 보통 중첩되어 있기 때문에 복잡한 케이스를 조회할 수 있는 `Test` 메소드가 제공된다.
예를 들어 위와 같은 `Previous`와 `Current` 상태를 담고 있는 `UIStateChangedEventArgs`에 대해 아래와 같은 테스트를 진행 할 수 있다.

```C#
e.Test(UIState.Focused.Included);  // true  (현재 상태에 Focused 가 있는지)
e.Test(UIState.Disabled.Excluded); // true  (현재 상태에 Disabled 가 없는지)
e.Test(UIState.Selected.Removed);  // true  (Selected 상태가 제거 되었는지)
e.Test(UIState.Disabled.Removed);  // false (Disabled 상태가 제거 되었는지)
e.Test(UIState.Focused.Changed);   // false (Focused 상태에 변화가 있는지)
```

<br/>