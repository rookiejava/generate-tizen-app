using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Components.Recycler;

namespace ComponentsTest
{
    internal enum ItemMediaType
    {
        Image,
        Video,
    }

    internal class GalleryGridDecoration : IGridRelativeSizeHelper
    {

        public Thickness GetItemOffsets(View view, int position, RecyclerView recyclerView) => Thickness.Zero;
        public float GetAspectRatio(View view, int position, RecyclerView recyclerView) => 1f;
    }

    /// <summary>
    /// Custom GridLayoutManager to test span size.
    /// </summary>
    internal class GalleryGridView : GridView
    {
        public GalleryGridView() : base()
        {
            ItemAnimator = new DefaultItemAnimator();
            InterceptWheelEvent += OnWheelEvent;
        }

        public bool IsEditMode { get; set; }

        private Dictionary<object, (Point Position, Size Size)> _initialItemStates = new();

        // Wheel span
        public void OnWheelEvent(object sender, WheelEventArgs e)
        {
            if (IsEditMode || !e.Wheel.IsCtrlModifier)
                return;

            // Capture the position and size of the currently visible items.
            _initialItemStates.Clear();

            foreach (var child in RecyclerView.InnerScroller.Children)
            {
                child.Position();
                _initialItemStates[child.Holder().BindingContext] = (child.Position(), child.Size());
            }

            if (e.Wheel.Delta > 0)
            {
                SpanCount++;
            }
            else if (e.Wheel.Delta < 0 && SpanCount > 1)
            {
                SpanCount--;
            }

            foreach (var child in RecyclerView.InnerScroller.Children)
            {
                ViewHolder holder = child.Holder();

                if (_initialItemStates.TryGetValue(child.Holder().BindingContext, out var initialState))
                {
                    if (initialState.Position.X != child.X || initialState.Position.Y != child.Y ||
                        initialState.Size.Width != child.Width || initialState.Size.Height != child.Height)
                    {
                        ItemAnimator.AnimateChange(holder, holder,
                            initialState.Position.X, initialState.Position.Y, child.X, child.Y);
                    }
                }
            }
            ItemAnimator.RunPendingAnimations();
            e.Handled = true;
        }
    }

    internal class GalleryGridViewTest : VStack, INavigationTransition, ITestCase
    {
        private readonly Label header;
        private Label _selectionCountLabel = null;
        private Label _spanCountLabel = null;
        private View _topBar;
        private View _bottomBar;
        private readonly BindingSession<GalleryDataSource> _session = new BindingSession<GalleryDataSource>();

        public GalleryGridViewTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.Black;
            ItemAlignment = LayoutAlignment.Start;

            Add(header = new Label("GalleryGridViewTest"));

            AddVerticalGridView(8); // span count : 8
        }

        private void AddVerticalGridView(uint spanCount)
        {
            Add(new Label()
            {
                Text = $"Vertical SpanCount : {spanCount}",
                TextColor = Color.White,
            }.Self(out _spanCountLabel));

            // Create a vertical grid view. It has selection mode. When long press, it will enter selection mode.
            var verticalGridView = new GalleryGridView()
            {
                ItemsSource = DataProvider.Instance.GetGroupItems(),
                ItemTemplate = new ViewTemplate(typeof(GalleryItemView)),
                GroupHeaderTemplate = new ViewTemplate(typeof(GalleryGroupHeaderView)),
                ScrollBarVisibility = ScrollBarVisibility.Always,
                IsGrouped = true,
                IsHorizontal = false,
                SpanCount = spanCount,
                ItemDecorations =
                {
                    new GalleryGridDecoration(),
                }
            }.Expand();

            _session.ViewModel = DataProvider.Instance.GetGroupItems();

            // Top bar with checkbox and selected count label.
            _topBar = CreateTopBar(verticalGridView);
            // Add the grid view to the layout.
            Add(verticalGridView);

            // Bottom bar with delete button and more button.
            _bottomBar = CreateBottomBar(verticalGridView);

            _session.AddBinding((vm) =>
            {
                if (vm.IsSelectable)
                {
                    _topBar.IsVisible = true;
                    _bottomBar.IsVisible = true;
                }
                else
                {
                    _topBar.IsVisible = false;
                    _bottomBar.IsVisible = false;
                }
            }, nameof(GalleryDataSource.IsSelectable));
        }

        private View CreateTopBar(GridView gridView)
        {
            var topBar = new HStack
            {
                BackgroundColor = Color.Gray,
                Children =
                {
                    new Checkbox()
                    {
                    }.Self(out var check),
                    new Label
                    {
                        VerticalAlignment = TextAlignment.Center,
                        Text = "0",
                    }.Self(out _selectionCountLabel).Expand(),
                }
            };
            check.SetTwoWayBinding(_session, SelectableBindings<Checkbox>.IsSelectedProperty, nameof(GalleryDataSource.IsSelected));
            Add(topBar);
            _selectionCountLabel.SetBinding(_session, TextBindings<Label>.TextProperty, nameof(GalleryDataSource.SelectedCount));
            topBar.IsVisible = false;


            return topBar;
        }

        private View CreateBottomBar(GridView gridView)
        {
            var bottomBar = new HStack
            {
                ItemAlignment = LayoutAlignment.Center,
                BackgroundColor = Color.Gray,
                Children =
                {
                    new ActionButton(MaterialIcon.Add)
                    {
                        ClickedCommand = (_, _) => DoAdd(gridView)
                    }.Expand().HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ActionButton(MaterialIcon.DeleteTrash)
                    {
                        ClickedCommand = (_, _) => DoDelete(gridView)
                    }.Expand().HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new MoreButton()
                    {
                        /*
                        ModalContent = new DropdownList()
                        {
                            Items =
                            {
                                new DropdownItem("Item1"),
                                new DropdownItem("Item2"),
                                new DropdownItem("Item3"),
                            },
                            DismissedCommand = (s, _) => new Toast((s as DropdownList).SelectedItem.Text).Post()
                        }
                        */
                    }.Expand().HorizontalLayoutAlignment(LayoutAlignment.Center)
                },
            };
            Add(bottomBar);
            bottomBar.IsVisible = false;

            return bottomBar;
        }

        private void DoAdd(GridView gridView)
        {
            new Toast($"Added").Post();
            var item = DataProvider.Instance.Add();
        }

        private void DoDelete(GridView gridView)
        {
            var groups = DataProvider.Instance.GetGroupItems();

            new Toast($"{groups.SelectedCount} Deleted").Post();
            var selectedGroups = groups.SelectedChildren;

            // Remove selected groups
            foreach (var group in selectedGroups.ToList())
            {
                groups.Remove(group);
            }

            // Remove selected child
            foreach (var group in groups)
            {
                foreach (var child in group.SelectedChildren.ToList())
                {
                    group.Remove(child);
                }
            }

            DataProvider.Instance.ReassignFlatIndexes();
        }

        public void WillAppear(bool byPopNavigation)
        {
        }

        public void WillDisappear(bool byPopNavigation)
        {
        }

        public void DidAppear(bool byPopNavigation)
        {
        }

        public void DidDisappear(bool byPopNavigation)
        {
            if (byPopNavigation)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
        }

        public void Deactivate()
        {
            Dispose();
        }

        // This is a simple page to show how to navigate to another page using GridView's item.
        public class PreviewContentPage : Scaffold
        {
            public PreviewContentPage(string title, int position)
            {
                WidthResizePolicy = ResizePolicy.FillToParent;
                HeightResizePolicy = ResizePolicy.FillToParent;

                AppBar = new AppBar()
                {
                    Leading = new BackButton(),
                    Title = "  ",
                    Trailing = new MoreButton(),
                };

                Content = new Label
                {
                    BackgroundColor = Color.BurlyWood,
                    Text = title,
                    VerticalAlignment = TextAlignment.Center,
                    HorizontalAlignment = TextAlignment.Center,
                }.Self(out var label);

                BottomBar = new GridView()
                {
                    DesiredHeight = 200,
                    BackgroundColor = MaterialColor.Background,
                    ItemsSource = DataProvider.Instance.GetGroupChildItems(),
                    ItemTemplate = new ViewTemplate(typeof(PreivewItemView)),
                    IsHorizontal = true,
                    ItemDecorations =
                    {
                        new GalleryGridDecoration(),
                    }
                }.Self(out var gridView);

                Relayout += (sender, e) =>
                {
                    gridView.ScrollTo(position, ScrollToPosition.Center, false);
                };

                PreviewModel.Instance.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == nameof(PreviewModel.Instance.SelectedItem))
                    {
                        label.Text = PreviewModel.Instance.SelectedItem;
                    }
                };
            }
        }

        // This is a simple item view to show how to navigate to another page using GridView's item.
        internal class PreivewItemView : ClickableBox, IBindableView
        {
            private readonly BindingSession<GalleryData> _session = new BindingSession<GalleryData>();

            private AbsoluteLayout _layout => Body as AbsoluteLayout;
            public PreivewItemView()
            {
                BackgroundColor = Color.Orange.WithAlpha(0.4f);
                this.Margin(5f);
                Body = new AbsoluteLayout();

                var label = new Label()
                {
                    FontFamily = MaterialFont.Normal600,
                    TextColor = new Color(0x848487, 1),
                    DesiredWidth = 100,
                    DesiredHeight = 100,
                    HorizontalAlignment = TextAlignment.Center,
                    VerticalAlignment = TextAlignment.Center,
                };
                label.SetBinding(_session, TextBindings<Label>.TextProperty, nameof(GalleryData.Title));
                label.LayoutFlags(AbsoluteLayoutFlags.PositionProportional);
                label.LayoutBounds(0.5f, 0, 1, -1);
                _layout.Add(label);

                Clicked += (sender, e) =>
                {
                    var previewData = (GalleryData)BindingContext;
                    Log.Info("DBG", $"data.SelectedTitle {previewData.Title} clicked");
                    PreviewModel.Instance.SelectedItem = previewData.Title;
                    PreviewModel.Instance.SelectedIndex = previewData.FlatIndex;
                };
            }


            public override Thickness Padding
            {
                get => _layout.Padding;
                set => _layout.Padding = value;
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (GalleryData)value;
            }


            protected override IList<View> InnerList => Body as ViewGroup;
        }

        // This is a singleton model to share data between pages. It is used to show how to navigate to another page using GridView's item.
        internal class PreviewModel : ViewModel
        {
            private static readonly PreviewModel _instance = new PreviewModel();

            public static PreviewModel Instance => _instance;

            private PreviewModel()
            {
            }

            public int SelectedIndex
            {
                get => Get<int>();
                set => Set(value);
            }

            public string SelectedItem
            {
                get => Get<string>();
                set => Set(value);
            }
        }


        // This is a simple data provider to provide data to GridView.
        internal class DataProvider
        {
            private static readonly DataProvider _instance = new DataProvider();
            public static DataProvider Instance => _instance;

            private GalleryDataSource _groupItems;
            public GalleryDataSource GetGroupItems()
            {
                if (_groupItems == null)
                {
                    _groupItems = new GalleryDataSource();
                    DateTime startDate = DateTime.Now.Date;
                    int flatIndex = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        var group = new GalleryGroupData
                        {
                            Title = startDate.ToString("yyyy-MM-dd"),
                            IsSelectable = false,
                        };

                        for (int j = 0; j < 50; j++)
                        {
                            group.Add(new GalleryData
                            {
                                Title = $"{j}th",
                                Position = j,
                                IsSelectable = false,
                                IsSelected = false,
                                FlatIndex = flatIndex,
                                ItemMediaType = j == 17 ? ItemMediaType.Video : ItemMediaType.Image,
                            });
                            flatIndex++;
                        }
                        _groupItems.Add(group);
                        startDate = startDate.AddDays(3);
                    }
                }
                return _groupItems;
            }

            public ObservableCollection<GalleryData> GetGroupChildItems()
            {
                var items = new ObservableCollection<GalleryData>();
                foreach (var group in GetGroupItems())
                {
                    foreach (var child in group)
                    {
                        items.Add(child);
                    }
                }
                return items;
            }

            public void ReassignFlatIndexes()
            {
                if (_groupItems == null)
                    return;
                int flatIndex = 0;
                foreach (var group in _groupItems)
                {
                    int pos = 0;
                    foreach (var data in group)
                    {
                        data.Position = pos;
                        data.FlatIndex = flatIndex;
                        flatIndex++;
                        pos++;
                    }
                }
            }

            public GalleryData Add()
            {
                Console.WriteLine($"Add");
                GalleryData item = null;
                if (_groupItems == null)
                    return item;
                var firstGroup = _groupItems.FirstOrDefault();
                if (firstGroup != null)
                {
                    item = new GalleryData
                    {
                        Title = $"new",
                        IsSelected = false,
                    };
                    firstGroup.Insert(3, item);
                    Console.WriteLine($"Inserted!");
                    ReassignFlatIndexes();
                }
                return item;
            }
        }

        internal class GalleryDataSource : SelectionModelGroup<GalleryGroupData>
        {
            public GalleryDataSource() : base()
            {
                IsSelectable = false;
            }
        }

        internal class GalleryGroupData : SelectionModelGroup<GalleryData>
        {
            public string Title
            {
                get => Get<string>();
                set => Set(value);
            }

            public string SubTitle
            {
                get => Get<string>();
                set => Set(value);
            }
        }

        // This is a simple data model to bind to GridView's item.
        internal class GalleryData : SelectableModel
        {
            public GalleryData() : base()
            {
                IsSelectable = false;
            }

            public int Position
            {
                get => Get<int>();
                set => Set(value);
            }

            public string Title
            {
                get => Get<string>();
                set => Set(value);
            }
            public int FlatIndex
            {
                get => Get<int>();
                set => Set(value);
            }

            public ItemMediaType ItemMediaType
            {
                get => Get<ItemMediaType>();
                set => Set(value);
            }
        }

        // This is the item model displayed when in edit mode.
        internal class GalleryItemView : SelectableBox, IBindableView
        {
            private readonly BindingSession<GalleryData> _session = new BindingSession<GalleryData>();
            private AbsoluteLayout _layout => Body as AbsoluteLayout;

            public GalleryItemView()
            {
                IsSelectable = DataProvider.Instance.GetGroupItems().IsSelectable;
                BackgroundColor = Color.BurlyWood.WithAlpha(0.4f);
                Body = new AbsoluteLayout();
                this.Margin(5f);

                var label = new Label()
                {
                    FontFamily = MaterialFont.Normal600,
                    TextColor = Color.White,
                    HorizontalAlignment = TextAlignment.Center,
                    VerticalAlignment = TextAlignment.Center,
                };
                label.SetBinding(_session, TextBindings<Label>.TextProperty, nameof(GalleryData.Title));
                label.LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
                label.LayoutBounds(0, 1, 1, -1);
                _layout.Add(label);

                var playIcon = new Image()
                {
                    ResourceUrl = MaterialIcon.PlayCircle,
                    ImageMultipliedColor = Color.White,
                };
                playIcon.SetBinding(_session, (vm, v) =>
                {
                    if (vm.ItemMediaType == ItemMediaType.Video)
                    {
                        playIcon.IsVisible = true;
                    }
                    else
                    {
                        playIcon.IsVisible = false;
                    }
                }, nameof(GalleryData.ItemMediaType));
                playIcon.LayoutFlags(AbsoluteLayoutFlags.PositionProportional);
                playIcon.LayoutBounds(0.5f, 0.5f, -1, -1);
                _layout.Add(playIcon);

                var check = new Checkbox();
                check.LayoutFlags(AbsoluteLayoutFlags.None);
                check.LayoutBounds(1f, 1f, -1, -1);
                check.IsVisible = IsSelectable;
                _layout.Add(check);

                check.SetTwoWayBinding(_session, SelectableBindings<Checkbox>.IsSelectedProperty, nameof(GalleryData.IsSelected));
                this.SetTwoWayBinding(_session, SelectableBindings<GalleryItemView>.IsSelectedProperty, nameof(GalleryData.IsSelected));
                // bind isSelectable for edit mode.
                this.SetBinding(_session, (vm, v) =>
                {
                    if (IsSelectable != vm.IsSelectable)
                    {
                        IsSelectable = vm.IsSelectable;
                        if (IsSelectable)
                        {
                            check.IsVisible = true;
                        }
                        else
                        {
                            check.IsVisible = false;
                        }
                    }
                }, nameof(GalleryData.IsSelectable));

                Clicked += (sender, e) =>
                {
                    Log.Info("DBG", $"Setting Item {_session.ViewModel?.Title} clicked");
                    if (!IsSelectable)
                    {
                        var page = new PreviewContentPage(_session.ViewModel.Title, _session.ViewModel.FlatIndex);
                        this.GetNavigation()?.PushAsync(page);
                    }

                    e.Handled = true;
                };

                LongPressedCommand = (sender, e) =>
                {
                    Log.Info("DBG", $"LongPressGesture {IsSelectable}");
                    if (!IsSelectable)
                    {
                        DataProvider.Instance.GetGroupItems().IsSelectable = true;
                        e.Handled = true;
                    }

                };
            }

            public override Thickness Padding
            {
                get => _layout.Padding;
                set => _layout.Padding = value;
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (GalleryData)value;
            }

            protected override IList<View> InnerList => Body as ViewGroup;
        }


        internal class GalleryGroupHeaderView : SelectableBox, IBindableView
        {
            private readonly BindingSession<GalleryGroupData> _session = new BindingSession<GalleryGroupData>();
            private HStack _layout => Body as HStack;

            public GalleryGroupHeaderView()
            {
                IsSelectable = DataProvider.Instance.GetGroupItems().IsSelectable;
                DesiredHeight = 100;
                Body = new HStack()
                {
                    Children =
                    {
                        new Checkbox().Self(out var check),
                        new Label()
                        {
                            FontFamily = MaterialFont.Normal600,
                            TextColor = Color.White,
                            HorizontalAlignment = TextAlignment.Start,
                            VerticalAlignment = TextAlignment.Center,
                        }.Expand().Self(out var label),
                    },
                };

                check.IsVisible = IsSelectable;
                check.SetTwoWayBinding(_session, SelectableBindings<Checkbox>.IsSelectedProperty, nameof(GalleryGroupData.IsSelected));
                this.SetTwoWayBinding(_session, SelectableBindings<GalleryGroupHeaderView>.IsSelectedProperty, nameof(GalleryGroupData.IsSelected));

                label.SetBinding(_session, TextBindings<Label>.TextProperty, nameof(GalleryGroupData.Title));

                // bind isSelectable for edit mode.
                this.SetBinding(_session, (vm, v) =>
                {
                    if (IsSelectable != vm.IsSelectable)
                    {
                        IsSelectable = vm.IsSelectable;
                        if (IsSelectable)
                        {
                            check.IsVisible = true;
                        }
                        else
                        {
                            check.IsVisible = false;
                        }
                    }
                }, nameof(GalleryGroupData.IsSelectable));
            }

            public override Thickness Padding
            {
                get => _layout.Padding;
                set => _layout.Padding = value;
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (GalleryGroupData)value;
            }

            protected override IList<View> InnerList => Body as ViewGroup;
        }
    }
}
