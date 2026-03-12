## ScrollView

The `ScrollView` is the basic component to show bigger content in a limited area with horizontal and vertical scrolling.
`ScrollView` can have only one unique child named `Content`.

The `Content` will move the position by user interaction (pan gesture) so the user can browse all areas of the `Content`.

`ScrollDirection` will determine which axis will be scrolled. `Horizontal` will move the `Content` on X-Positions, `Vertical` will move it on Y-Positions.
The `Both` option will move both axes if possible.

`ScrollBar` is the indicator of scroll position. The `ScrollBar` can show on the side of `ScrollDirection`.
`ScrollBarVisibility` is the option that changes the visibility of the `ScrollBar`. `Auto` will show the `ScrollBar` when the scroll moves, and hide if it ends.
`Always` will always show the `ScrollBar`, `Never` will hide the `ScrollBar`.

The `ScrollView` provides several events such as `Scrolling`, `ScrollStarted`, and `ScrollFinished`, `Dragging`, `DragStarted`, and `DragFinished` 

To know when the scroll reaches the end of directions, check the `IsScrolledToStart` and  `IsScrolledToEnd`.


> [!CAUTION]
> Be careful with the layout size of the Content to avoid recursive sizing negotiations.
> Mostly `ScrollView` determines its size by the parent or a fixed number, `Content` determines its size by the children or a > fixed number.


### Sample
```c#
var scroll = new ScrollView()
{
    ScrollDirection = ScrollDirection.Vertical,
    Content = new VStack()
    {
        BackgroundColor = Color.White,
        Spacing = 2f.Spx(),
    }.Self(out var listBox).FillHorizontal()
}.Fill();

for (int i = 0; i < 100; i++)
{
    listBox.Add(new View{
        DesiredHeight = 30f.Spx(),
        BackgroundColor = MaterialColor.SurfaceFixed,
    }.CenterHorizontal());
}
```

<br/>
<br/>

## RecyclerView(ListView)

If a large amount of data needs to be shown in the scrollable area, please consider using `RecyclerView`.
`RecyclerView` is a scrollable container that loads the children only when they need to be shown in the scrollable area, with recycling.
`RecyclerView` accepts a data source from `IEnumerable` `ItemsSource` and creates the items from the data by the `Adapter`. `LayoutManager` will manage the items' layout.

`ListView` is a prebuilt `RecyclerView` with layout items in a linear stack in scrolling directions.


> [!IMPORTANT]
> Do not use `ListView` for short-length scrolls.
> `ScrollView` is much easier and faster than `ListView` for short-length scrolls.

<br/>

### Create IEnumerable data

If data implements `INotifyPropertyChanged`, the bound property will get a notification of the property changing.
To update collection changes, `INotifyCollectionChanged` also needs to be implemented.
Use `ObservableCollection<T>` for collection update if necessary, or normally use `List<T>` in a simple data source.
The data source also needs to be a group of `IEnumerable` data to create the grouped list.

```c#
class ItemData : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private bool _isSelected;
    private string _title;

    public ItemtData(string title, bool selected)
    {
        _title = title;
        _isSelected = selected;
    }

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            NotifyPropertyChanged();
        }
    }

    public bool Selected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            NotifyPropertyChanged();
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

private ObservableCollection<ItemData> GetDataSource()
{
    ObservableCollection<ItemData> source = new ();
    for (int i = 0; i < 100; i++))
    {
        source.Add(new ItemData($"{i}th item", false));
    }

    return source;
}

listView.ItemsSource = GetDataSource();
```

<br/>
<br/>

for user convenience,
Tizen UI provides several pre-built ViewModels in `Tizen.UI.Components.Recycler`.
`ViewModel` implements `INotifyPropertyChanged` interface with providing property bag that can be set and get easily in the code with notifying PropertyChanged.
`ViewModelGroup` is ObservableCollection of `INotifyPropertyChanged` with also providing property bag.
`SelectableModel` extends `ViewModel`, which implements `ISelectableModel` that has `IsSelected` and `IsSelectable` properties.
`SelectableModelGroup` is the ObservableCollection of `ISelectableModel` with provides a list of `SelectedChildren` and `IsSelected` when all children are selected.
`ExclusiveSelectionModelGroup` is ObservableCollection of `ISelectableModel` for special case where only a single child can be selected and others need to be deselected exclusively.
Upon code can be easily changed by using ViewModels,


```c#
class ItemData : SelectableModel
{
    public ItemtData(string title, bool selected)
    {
        Title = title;
        IsSelected = selected;
    }

    public string Title
    {
        get => Get<string>();
        set => Set(value);
    }
}

class ItemDataGroup : SelectionModelGroup<ItemData> {}

private ItemDataGroup GetDataSource()
{
    ItemDataGroup source = new ();
    for (int i = 0; i < 100; i++))
    {
        source.Add(new ItemData($"{i}th item", false));
    }

    return source;
}

listView.ItemsSource = GetDataSource();
```


### Create item contents on ViewTemplate with data bindings

`ViewTemplate` helps to create items, and data can be bound via `BindingProperty`.
A new way of data binding is provided using `BindingSession` to reduce the performance burden.
The binding extension methods below are used in most cases in `ListView` implementation.

```c#
public static TView SetBinding<TView, TViewModel, TProperty>(this TView view, BindingSession<TViewModel> session, BindingProperty<TView, TProperty> property, string path) where TView : View

public static TView SetTwoWayBinding<TView, TViewModel, TProperty>(this TView view, BindingSession<TViewModel> session, TwoWayBindingProperty<TView, TProperty> property, string path) where TView : View
```
In some view classes provide pre-defined BindingProperties.

<br/>

#### `Tizen.UI.ViewBindings`
Property Type | Property Name
--|--
BindingProperty<View, float> | `WidthProperty`
BindingProperty<View, float> | `HeightProperty`
BindingProperty<View, float> | `XProperty`
BindingProperty<View, float> | `YProperty`
BindingProperty<View, Color> | `BackgroundColorProperty`

#### `Tizen.UI.ImageViewBindings`
Property Type | Property Name
--|--
BindingProperty<Image, string> | `ResourceUrlProperty`
BindingProperty<Image, Color> | `ImageMultipliedColorProperty`

#### `Tizen.UI.TextBindings<T>`
Property Type | Property Name | Condition
--|--|--
BindingProperty<T, string> | `TextProperty` | T: View, IText
BindingProperty<T, Color> | `TextColorProperty` | T: View, IText
BindingProperty<T, float> | `FontSizeProperty` | T: View, IText

#### `Tizen.UI.EditableTextBindings<T>`
Property Type | Property Name | Condition
--|--|--
TwoWayBindingProperty<T, string> | `TextProperty` | T: View, ITextEditable

#### `Tizen.UI.Components.SelectableBindings<TView>`
Property Type | Property Name | Condition
--|--|--
TwoWayBindingProperty<TView, bool> | `IsSelectedProperty` | TView : View, ISelectable
<br/>

`ViewTemplate` creates the content by setting the `LoadTemplate` Function or setting the type of the content class in the `ViewTemplate` constructor.
There is no restriction on content type if it inherits the `View` with implements `IBindableView`, but if the list is grouped, implementing the `IGroupedItem` interface will help to get the position in the group on item placement.

<br/>