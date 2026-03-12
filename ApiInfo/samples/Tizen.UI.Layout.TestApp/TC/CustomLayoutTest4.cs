using LayoutTest.Util;
using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class MultLayout : ViewGroup
    {
        abstract class LayoutImpl : ILayout, IDisposable
        {
            ViewGroup _owner;
            LayoutManager _layoutManager;
            LayoutHelper _layoutHelper;
            public LayoutImpl(ViewGroup owner)
            {
                _owner = owner;
                _layoutManager = CreateLayoutManager();
                _layoutHelper = new LayoutHelper(owner, _layoutManager);
            }

            protected abstract LayoutManager CreateLayoutManager();

            public LayoutHelper LayoutHelper => _layoutHelper;

            public IList<View> Children => _owner.Children;

            public Thickness Padding { get; set; }

            public float DesiredWidth => _owner.DesiredWidth;

            public float DesiredHeight => _owner.DesiredHeight;

            public LayoutParam LayoutParam => _owner.LayoutParam();

            public LayoutDirection LayoutDirection => _owner.LayoutDirection;

            public void Dispose()
            {

            }

            protected void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _layoutHelper.Dispose();
                }
            }
        }

        abstract class StackImpl : LayoutImpl, IStackLayout
        {
            protected StackImpl(ViewGroup owner) : base(owner)
            {
            }

            public float Spacing { get; set; }

            public LayoutAlignment ItemAlignment { get; set; }
        }

        class VStackImpl : StackImpl
        {
            public VStackImpl(ViewGroup owner) : base(owner)
            {
            }

            protected override LayoutManager CreateLayoutManager()
            {
                return new VStackLayoutManager(this);
            }
        }

        class HStackImpl : StackImpl
        {
            public HStackImpl(ViewGroup owner) : base(owner) { }

            protected override LayoutManager CreateLayoutManager()
            {
                return new HStackLayoutManager(this);
            }
        }

        class AbsoluteImpl : LayoutImpl
        {
            public AbsoluteImpl(ViewGroup owner) : base(owner) { }

            protected override LayoutManager CreateLayoutManager()
            {
                return new AbsoluteLayoutManager(this);
            }
        }

        class GridImpl : LayoutImpl , IGridLayout
        {
            public GridImpl(ViewGroup owner) : base(owner) { }

            public float ColumnSpacing { get; set; }

            public float RowSpacing { get; set; }

            public IList<GridRowDefinition> RowDefinitions { get; set; } = new List<GridRowDefinition>();

            public IList<GridColumnDefinition> ColumnDefinitions { get; set; } = new List<GridColumnDefinition>();

            protected override LayoutManager CreateLayoutManager()
            {
                return new GridLayoutManager(this);
            }
        }

        LayoutImpl _layoutImpl;

        public MultLayout()
        {
            _layoutImpl = CreateVStack();
        }

        public void AsVStack()
        {
            _layoutImpl?.Dispose();
            _layoutImpl = CreateVStack();
            SendMeasureInvalidated();
        }

        public void AsHStack()
        {
            _layoutImpl?.Dispose();
            _layoutImpl = CreateHStack();
            SendMeasureInvalidated();
        }

        public void AsGrid()
        {
            _layoutImpl?.Dispose();
            _layoutImpl = CreateGrid();
            SendMeasureInvalidated();
        }

        public void AsAbsolute()
        {
            _layoutImpl?.Dispose();
            _layoutImpl = CreateAbsolute();
            SendMeasureInvalidated();
        }

        LayoutImpl CreateVStack()
        {
            return new VStackImpl(this)
            {
                Spacing = 20
            };
        }

        LayoutImpl CreateHStack()
        {
            return new HStackImpl(this)
            {
                Spacing = 20
            };
        }

        LayoutImpl CreateGrid()
        {
            return new GridImpl(this)
            {
                ColumnDefinitions = { GridLength.Star, GridLength.Star, GridLength.Star, GridLength.Star },
                RowDefinitions = { GridLength.Star, GridLength.Star, GridLength.Star, GridLength.Star },
                ColumnSpacing = 20,
                RowSpacing = 20,
            };
        }

        LayoutImpl CreateAbsolute()
        {
            return new AbsoluteImpl(this);
        }

        public override Size Measure(float availableWidth, float availableHeight)
        {
            return _layoutImpl?.LayoutHelper.Measure(availableWidth, availableHeight) ?? Size.Zero;
        }
    }
    class CustomLayoutTest4 : Grid, ITestCase
    {
        public CustomLayoutTest4()
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
                Text = "Custom Layout Test4",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Both,
                Content = new MultLayout
                {
                    RandomBox(1).Row(0).Column(0).LayoutBounds(10, 120, -1, -1),
                    RandomBox(2).Row(0).Column(1).LayoutBounds(20, 110, -1, -1),
                    RandomBox(3).Row(0).Column(2).LayoutBounds(30, 100, -1, -1),
                    RandomBox(4).Row(0).Column(3).LayoutBounds(40, 90, -1, -1),
                    RandomBox(5).Row(1).Column(0).LayoutBounds(50, 80, -1, -1),
                    RandomBox(6).Row(1).Column(1).LayoutBounds(60, 70, -1, -1),
                    RandomBox(7).Row(1).Column(2).LayoutBounds(70, 60, -1, -1),
                    RandomBox(8).Row(1).Column(3).LayoutBounds(80, 50, -1, -1),
                    RandomBox(9).Row(2).Column(0).LayoutBounds(90, 40, -1, -1),
                    RandomBox(10).Row(2).Column(1).LayoutBounds(100, 30, -1, -1),
                    RandomBox(11).Row(2).Column(2).LayoutBounds(110, 20, -1, -1),
                    RandomBox(12).Row(2).Column(3).LayoutBounds(120, 10, -1, -1),

                }.Self(out var layout)
            }.Row(2));

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("As VStack")
                    {
                        Clicked = () =>
                        {
                            layout.AsVStack();
                        }
                    },
                    new Button("As HStack")
                    {
                        Clicked = () =>
                        {
                            layout.AsHStack();
                        }
                    },
                    new Button("As Grid")
                    {
                        Clicked = () =>
                        {
                            layout.AsGrid();
                        }
                    },
                    new Button("As Absolute")
                    {
                        Clicked = () =>
                        {
                            layout.AsAbsolute();
                        }
                    },
                }
            }.Row(1));
        }

        View RandomBox(int i)
        {
            return new TextView
            {
                Text = $"{i}",
                FontSize = 20,
                DesiredHeight = 150,
                DesiredWidth = 150,
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