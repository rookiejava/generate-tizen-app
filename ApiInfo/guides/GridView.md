# GridView
`GridView` changed API in `Tizen.UI` for better usage and the unity of `ListView`.

## 1. ItemDecoration
Now Item Decoration is supported by `IList<IItemDecoration>`.
You don't have to call add, remove, or get the count by API,
But just add your decorations to the `ItemDecorations` list.

```diff

-        public void AddItemDecoration(IItemDecoration decoration)
-        public void AddItemDecoration(IItemDecoration decoration, int index)
-        public int GetItemDecorationCount()
-        public void RemoveItemDecoration(IItemDecoration decoration)

+        public IList<IItemDecoration> ItemDecorations
```

A brief sample code is below.
```c#
       internal class MyGridDecoration : IItemDecoration
       {
            private readonly int _spacing;
            public GridItemDecoration(int spacing = 5) => _spacing = spacing;
            public Thickness GetItemOffsets(View view, int position, RecyclerView recyclerView) => new Thickness(_spacing);
       }

       ...

       var myGridView = new GridView
       {
            ItemDecorations
            {
                 new MyGridDecoration(5f),
                 ...
            }
       }
```

## 2. SpanSize

To get the span size and index,
We provided `LayoutManger` property in `GridView`, and users have to customize the `GridLayoutManager`, which is a burden.
In `Tizen.UI`, instead of customizing `GridLayoutManager`, we provide `IGridSpanHelper` derived from `IItemDeocration`.
```diff
    public class GridView
    {
-        public GridLayoutManager LayoutManager
    }

    public class GridLayoutManager
    {
-        public virtual uint GetSpanSize(int position)
-        public virtual uint GetSpanIndex(int position)
    }


+    public interface IGridSpanHelper : IItemDecoration
+    {
+        uint GetSpanSize(int position, RecyclerView recyclerView);
+        int GetSpanIndex(int position, RecyclerView recyclerView) => -1;
+    }
```

A brief sample code is below.
```c#
       internal class MyGridSpanHelper : IGridSpanHelper
       {
            public GetSpanSize(int position, RecyclerView recyclerView)
            {
                  var gridView = recyclerView.Parent as GridView;
                  if (position == 0)
                       return gridView.SpanCount; // Full span
                  return 1; // default size
            }
       }

       ...

       var myGridView = new GridView
       {
            ItemDecorations
            {
                 new MyGridSpanHelper(),
                 ...
            }
       }
```

> [!NOTE]
> No need to set the span size on group header. how header will have full span size.

## 3. Selection
`GridView` provided selection by itself, but in MVVM, every data should be managed by the ViewModel, not the View.
So we get rid of selection-related API in `GridView`, but for user convenience, we provide an abstract class of ViewModels.

```diff
    public class GridView
    {
         // use IsSelectable PropertyChanged of SelectionModelGroup
-        public event EventHandler<bool> EditableChanged;
         // use IsSelectable in SelectionModelGroup
-        public bool IsEditable
         // use SelectedChildren in SelectionModelGroup
-        public IReadOnlyCollection<object> SelectedItems => _selectedItems;
         // set IsSelected false to SelectionModelGroup
-        public void ClearSelection()
         // Remove child in SelectedChildren from SelectionModelGroup 
-        public void RemoveSelectedItems()
         // Set IsSelected in your ISelectableModel(SelectableModel)
-        public void SetItemSelected(object item, bool selected)
    }
```

See more details how to use ViewModel in
[Scroll & List](Scroll-&-List#create-ienumerable-data)

## 4. Relative Size in item
The size of the item in the scroll-cross-axis is determined by `SpanCount` and `IGridSpanHelper`, but if you want to make the size of the item in the scroll-axis relatively in `SpanCount`, please implement `IGridRelativeSizeHelper`, which extends `IItemDecoration`.

```c#
    public interface IGridRelativeSizeHelper : IItemDecoration
    {
        float GetAspectRatio(View view, int position, RecyclerView recyclerView);
    }

```

See more changes related `RecyclerView` and `ListView`.