using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.OneUI;
using Tizen.NUI.OneUI.Components;
using System;
using System.Collections.ObjectModel;

namespace ComponentsTest
{
    internal class StaggeredGridTest : VStack, INavigationTransition, ITestCase
    {
        private readonly Label header;

        private Label _spanCountLabel = null;

        public StaggeredGridTest()
        {
            LayoutWidth = LayoutDimension.MatchParent;
            LayoutHeight = LayoutDimension.MatchParent;
            BackgroundColor = UIColor.White;
            LayoutAlignment = LayoutAlignment.TopCenter;

            Add(header = new Label("StaggeredGridTest"));

            AddVerticalGridView(4); // span count : 4
        }

        private void AddVerticalGridView(uint spanCount)
        {
            Add(new Label()
            {
                Text = $"Vertical SpanCount : {spanCount}"
            }.Self(out _spanCountLabel));

            var verticalGridView = new StaggeredGridView()
            {
                LayoutWidth = 800,
                LayoutHeight = LayoutDimension.MatchParent,
                ItemsSource = DataProvider.Instance.GetItems(),
                ItemTemplate = new ViewTemplate(typeof(MyItemView)),
                ScrollBarVisibility = ScrollBarVisibility.Always,
                SpanCount = spanCount,
                IsHorizontal = false,
            };
            verticalGridView.AddItemDecoration(new GridItemDecoration(5));

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
                        });
                    }
                }
                return _items;
            }
        }

        // This is a simple data model to bind to GridView's item.
        internal class MyData
        {
            public string Title { get; set; }
        }

        // This is the item model displayed when not in edit mode. It navigates to another page when clicked.
        internal class MyItemView : Clickable
        {
            private readonly BindingSession<MyData> _session = new BindingSession<MyData>();

            public MyItemView()
            {
                LayoutWidth = LayoutDimension.MatchParent;
                LayoutHeight = LayoutDimension.MatchParent;
                BackgroundColor = UIColor.BurlyWood.WithAlpha(0.4f);

                var label = new Label()
                {
                    FontFamily = OneUIFont.Condensed600,
                    TextColor = new UIColor(0x848487, 1),
                    LayoutWidth = LayoutDimension.MatchParent,
                    LayoutHeight = LayoutDimension.MatchParent,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                };
                label.SetBinding(_session, LabelBindings.TextProperty, "Title");
                BindingContextChanged += (sender, e) =>
                {
                    _session.ViewModel = (MyData)BindingContext;
                    var size = new Random().Next(0, 2) == 0 ? 400 : 200;
                    LayoutWidth = size;
                    LayoutHeight = size;
                };

                Add(label);
            }
        }

        // This is an item decoration to add spacing between items.
        internal class GridItemDecoration : IItemDecoration
        {
            private readonly int _spacing;

            public GridItemDecoration(int spacing)
            {
                _spacing = spacing;
            }

            public UIExtents GetItemOffsets(View view, int position, RecyclerView recyclerView)
            {
                return new UIExtents(_spacing, _spacing, _spacing, _spacing);
            }
        }
    }
}
