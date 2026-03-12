using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Recycler;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class GridSpanDecoration : IGridSpanHelper
    {
        private readonly int _spacing;

        public GridSpanDecoration(int spacing)
        {
            _spacing = spacing;
        }

        public Thickness GetItemOffsets(View view, int position, RecyclerView recyclerView)
        {
            return new Thickness(_spacing);
        }

        public uint GetSpanSize(int position, RecyclerView recyclerView)
        {
            return (uint)(position % 4 == 0 ? 3 : 1);
        }
    }

    // This is an item decoration to add spacing between items.
    internal class GridSpaceDecoration : IItemDecoration
    {
        private readonly int _spacing;

        public GridSpaceDecoration(int spacing)
        {
            _spacing = spacing;
        }

        public Thickness GetItemOffsets(View view, int position, RecyclerView recyclerView)
        {
            return new Thickness(_spacing);
        }
    }

    internal class GridViewTest : Grid, INavigationTransition, ITestCase
    {
        public GridViewTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0xf1f1f3, 1);

            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);

            Add(new Label()
            {
                Text = "GridViewTest"
            });

            AddHorizontalGridView(3); // span count : 3
            AddVerticalGridView(8); // span count : 8
        }

        private void AddHorizontalGridView(uint spanCount)
        {
            Add(new Label()
            {
                Text = $"Horizontal SpanCount : {spanCount}"
            });
            var gridView = new GridView
            {
                BackgroundColor = Color.AliceBlue.WithAlpha(0.15f),
                IsHorizontal = true,
                ItemsSource = DataProvider.Instance.GetItems(),
                ItemTemplate = new ViewTemplate(typeof(HItemView)),
                ScrollBarVisibility = ScrollBarVisibility.Always,
                SpanCount = spanCount,
                ItemDecorations =
                {
                    new GridSpanDecoration(5),
                }
            }.Row(1);
            Add(gridView);
        }

        private void AddVerticalGridView(uint spanCount)
        {
            Add(new Label()
            {
                Text = $"Vertical SpanCount : {spanCount}"
            }.Row(2));

            var verticalGridView = new GridView()
            {
                BackgroundColor = Color.Crimson.WithAlpha(0.15f),
                IsHorizontal = false,
                ItemsSource = DataProvider.Instance.GetItems(),
                ItemTemplate = new ViewTemplate(typeof(VItemView)),
                ScrollBarVisibility = ScrollBarVisibility.Always,
                SpanCount = spanCount,
                ItemDecorations =
                {
                    new GridSpanDecoration(5),
                }
            }.Row(3);
            // Add the grid view to the layout.
            Add(verticalGridView);
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

        // This is a simple data provider to provide data to GridView.
        internal class DataProvider
        {
            private static readonly DataProvider _instance = new DataProvider();
            public static DataProvider Instance => _instance;

            private ObservableCollection<MyData> _items;
            public ObservableCollection<MyData> GetItems()
            {
                if (_items == null)
                {
                    _items = new ObservableCollection<MyData>();
                    for (int j = 0; j < 250; j++)
                    {
                        _items.Add(new MyData
                        {
                            Title = $"{j}th",
                            Position = j,
                        });
                    }
                }
                return _items;
            }
        }

        // This is a simple data model to bind to GridView's item.
        internal class MyData : ViewModel
        {
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
        }

        // This is the item model displayed when not in edit mode. It navigates to another page when clicked.
        internal class HItemView : Clickable, IBindableView
        {
            private readonly BindingSession<MyData> _session = new BindingSession<MyData>();

            public HItemView()
            {
                BackgroundColor = Color.BurlyWood.WithAlpha(0.4f);

                DesiredWidth = 90f;

                HStack stack;
                Body = stack = new HStack();

                var label = new Label()
                {
                    TextColor = new Color(0x848487, 1),
                    HorizontalAlignment = TextAlignment.Center,
                    VerticalAlignment = TextAlignment.Center,
                }.Expand();
                label.SetBinding(_session, TextBindings<Label>.TextProperty, "Title");
                stack.Add(label);

                Clicked += (sender, e) =>
                {
                    var data = (MyData)BindingContext;
                    Log.Info("DBG", $"Setting Item {data.Title} clicked");
                };
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (MyData)value;
            }
        }

        // This is the item model displayed when not in edit mode. It navigates to another page when clicked.
        internal class VItemView : Clickable, IBindableView
        {
            private readonly BindingSession<MyData> _session = new BindingSession<MyData>();

            public VItemView()
            {
                BackgroundColor = Color.BurlyWood.WithAlpha(0.4f);

                DesiredHeight = 150f;

                HStack stack;
                Body = stack = new HStack();

                var label = new Label()
                {
                    TextColor = new Color(0x848487, 1),
                    HorizontalAlignment = TextAlignment.Center,
                    VerticalAlignment = TextAlignment.Center,
                }.Expand();
                label.SetBinding(_session, TextBindings<Label>.TextProperty, "Title");
                stack.Add(label);

                Clicked += (sender, e) =>
                {
                    var data = (MyData)BindingContext;
                    Log.Info("DBG", $"Setting Item {data.Title} clicked");
                };
            }

            public object BindingContext
            {
                get => _session.ViewModel;
                set => _session.ViewModel = (MyData)value;
            }
        }
    }
}
