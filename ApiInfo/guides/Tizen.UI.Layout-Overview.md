## OVERVIEW
**Layout** is arrange and group UI components in your application. 
- **AbsoluteLayout** is used to position and size using explicit values, or values relative to the size of the layout.
- **ScrollView** is a container capable of scrolling if its content requires.
- **HStack** organizes child views in a one-dimensional horizontal stack.
- **VStack** organizes child views in a one-dimensional vertical stack.
- **FlexBox** brings the similar capabilities of [CSS Flexible Box Layout](https://www.w3.org/TR/css-flexbox-1/).
- **Grid** is used for displaying elements in rows and columns.

**Layout** delegates layout and measurement to a **LayoutManager**.
- Each layout manager class implements the **ILayoutManager** interface.

## Layout Process
**ILayoutManager** works in two phases – **`Measure()`** and **`ArrangeChildren()`**.

### Step 1. Measure()
- Calculates and returns the total size of the layout given the constraints.
- The total size of the layout is determined by its children.
- Measures for the layout are propagated in a chain to measures for the children.

### Step2. ArrangeChildren()
- Arranges children according to their measured size and returns the actual size of the layout.
- Unlike `Measure()`, it is not called in a chain. Simply places child view by setting their position or/and size.
- Once arranged, the native DALi engine triggers a Relayout event to perform the required layout.

## When is layouting triggered?

### Case 1. When the root layout is arranged
- Starts the layout in response to a `Relayout` event raised by DALi(`ResizePolicy`) or manual size change.
- In the `Relayout` event handler, the view is measured according to the size assigned to it.
- After measuring all the sub-child views, arrange the child views.

### Case 2. When the size of child view is changed
- Changes in the size of children are notified by `MeasureInvalidated` event.

> ℹ️ Even if the size of the child view is generated multiple times in one rendering loop, ensure that the layout can only be performed once per rendering loop.

### Case 3. When the child view is added or removed
- If the size of the layout or the arrangement of child views changes, layouting will occurs.

### Case 4. When the `UpdatedLayout()` is called by user
- Call the Layout.UpdateLayout() to perform measure using the current view size and then arrange children.

## What's different in existing NUI Layout and Tizen.UI Layout
### 명시적인 Layout 클래스 제공
- View의 Layout속성을 통해 Layout타입이 결정되는 것에서 명시적으로 구체화된 Layout 클래스를 사용하는 방식으로 변경

### 보다 쉽고 편한 Layout 옵션 설정 제공
- View나 Layout클래스 변경 없이 Layout옵션을 구체화 할 수 있는 방식 적용
  ```CS
  Add(new Button().Row(2).Column(3).Margin(20));
  ```

### Layouting 최적화
- 기존에는 항상 Root View로부터 레이아웃을 시작
- Tizen.UI Layout은 변경에 대한 영향이 미치는 범위의 View로부터 Layouting 시작