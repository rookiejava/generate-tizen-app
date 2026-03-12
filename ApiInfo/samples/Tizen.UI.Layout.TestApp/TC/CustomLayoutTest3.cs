using LayoutTest.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{

    class NoneViewGrid : IGridLayout
    {
        ViewGroup _owner;
        GridLayoutManager _layoutManager;
        LayoutHelper _layoutHelper;

        ObservableCollection<View> _children = new();
        List<GridColumnDefinition> _columns = new();
        List<GridRowDefinition> _rows = new();

        public NoneViewGrid(ViewGroup owner)
        {
            _owner = owner;
            _layoutManager = new GridLayoutManager(this);
            _layoutHelper = new LayoutHelper(owner, _layoutManager);
            _children.CollectionChanged += OnCollectionChanged;
        }

        public float ColumnSpacing { get; set; }
        public float RowSpacing { get; set; }


        public IList<GridRowDefinition> RowDefinitions => _rows;

        public IList<GridColumnDefinition> ColumnDefinitions => _columns;

        public IList<View> Children => _children;

        public Thickness Padding { get; set; }
        public float DesiredWidth { get; set; } = float.NaN;
        public float DesiredHeight { get; set; } = float.NaN;

        public LayoutParam LayoutParam => _owner.LayoutParam();

        public LayoutDirection LayoutDirection => _owner.LayoutDirection;

        public void OnChildAdded(View view)
        {
            _layoutHelper.OnChildAdded(view);
        }

        public void OnChildRemoved(View view)
        {
            _layoutHelper.OnChildRemoved(view);
        }
        public Size Measure(float availableWidth, float availableHeight)
        {
            return _layoutHelper.Measure(availableWidth, availableHeight);
        }

        void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    _owner.Children.Add((View)item);
                }
            }

            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    _owner.Children.Remove((View)item);
                }
            }
        }
    }

    class NoneViewVStack : IStackLayout
    {
        ViewGroup _owner;
        VStackLayoutManager _layoutManager;
        LayoutHelper _layoutHelper;
        ObservableCollection<View> _children = new();
        public NoneViewVStack(ViewGroup owner)
        {
            _owner = owner;
            _layoutManager = new VStackLayoutManager(this);
            _layoutHelper = new LayoutHelper(owner, _layoutManager);
            _children.CollectionChanged += OnCollectionChanged;
        }

        public float Spacing { get; set; }

        public LayoutAlignment ItemAlignment { get; set; }

        public IList<View> Children => _children;

        public Thickness Padding { get; set; }

        public float DesiredWidth { get; set; } = float.NaN;

        public float DesiredHeight { get; set; } = float.NaN;

        public LayoutParam LayoutParam => _owner.LayoutParam();

        public LayoutDirection LayoutDirection => _owner.LayoutDirection;

        public void OnChildAdded(View view)
        {
            _layoutHelper.OnChildAdded(view);
        }

        public void OnChildRemoved(View view)
        {
            _layoutHelper.OnChildRemoved(view);
        }

        public Size Measure(float availableWidth, float availableHeight)
        {
            return _layoutHelper.Measure(availableWidth, availableHeight);
        }

        void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    _owner.Children.Add((View)item);
                }
            }

            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    _owner.Children.Remove((View)item);
                }
            }
        }
    }

    class GridVStack : ViewGroup
    {
        NoneViewGrid _grid;
        NoneViewVStack _vstack;
        public GridVStack()
        {
            _grid = new NoneViewGrid(this);
            _grid.RowSpacing = 5;
            _grid.ColumnSpacing = 5;
            _vstack = new NoneViewVStack(this);
            _vstack.Spacing = 5;
        }

        public IList<View> GridChildren => _grid.Children;

        public IList<View> VStackChildren => _vstack.Children;

        public float Spacing
        {
            get => _vstack.Spacing;
            set
            {
                _vstack.Spacing = value;
                SendMeasureInvalidated();
            }
        }

        public IList<GridRowDefinition> RowDefinitions => _grid.RowDefinitions;

        public IList<GridColumnDefinition> ColumnDefinitions => _grid.ColumnDefinitions;

        protected override void OnChildAdded(View view)
        {
            base.OnChildAdded(view);
            _vstack.OnChildAdded(view);
            _grid.OnChildAdded(view);
        }

        protected override void OnChildRemoved(View view)
        {
            base.OnChildRemoved(view);
            _vstack.OnChildRemoved(view);
            _grid.OnChildRemoved(view);
        }

        public override Size Measure(float availableWidth, float availableHeight)
        {
            var size1 = _vstack.Measure(availableWidth, availableHeight);
            var size2 = _grid.Measure(availableWidth, availableHeight);
            return new Size(MathF.Max(size1.Width, size2.Width), MathF.Max(size1.Height, size2.Height));
        }
    }

    class CustomLayoutTest3 : Grid, ITestCase
    {
        public CustomLayoutTest3()
        {
            BackgroundColor = Color.White;
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Custom Layout Test3",
                FontSize = 30,
            });

            GridVStack gridStack = null;

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("Add on VStack")
                    {
                        Clicked = () =>
                        {
                            gridStack.VStackChildren.Add(RandomBox().DesiredHeight(120));
                        }
                    },
                    new Button("Remove on VStack")
                    {
                        Clicked = () =>
                        {
                            if (gridStack.VStackChildren.Count > 0)
                                gridStack.VStackChildren.Remove(gridStack.VStackChildren[^1]);
                        }
                    },
                    new Button("Add on Grid")
                    {
                        Clicked = () =>
                        {
                            int row = (gridStack.GridChildren.Count / gridStack.ColumnDefinitions.Count) % gridStack.RowDefinitions.Count;
                            int column = gridStack.GridChildren.Count % gridStack.ColumnDefinitions.Count;
                            gridStack.GridChildren.Add(RandomBox().Row(row).Column(column));
                        }
                    },
                    new Button("Remove on Grid")
                    {
                        Clicked = () =>
                        {
                            if (gridStack.GridChildren.Count > 0)
                                gridStack.GridChildren.Remove(gridStack.GridChildren[^1]);
                        }
                    },
                }
            }.Row(1));

            Add(gridStack = new GridVStack
            {
                RowDefinitions = {100, GridLength.Star, 100},
                ColumnDefinitions = { 100, GridLength.Star, 100 },
                GridChildren =
                {
                    RandomBox().Row(0).Column(0),
                    RandomBox().Row(0).Column(1),
                    RandomBox().Row(0).Column(2),
                    RandomBox().Row(1).Column(0),
                    RandomBox().Row(1).Column(1),
                    RandomBox().Row(1).Column(2),
                    RandomBox().Row(2).Column(0),
                    RandomBox().Row(2).Column(1),
                    RandomBox().Row(2).Column(2),
                }
            }.Row(2));
        }

        View RandomBox()
        {
            return new View
            {
                Opacity = 0.7f,
                BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)
            };
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}