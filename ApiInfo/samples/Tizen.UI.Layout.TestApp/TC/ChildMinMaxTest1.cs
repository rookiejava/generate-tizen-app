using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components.Animations;

namespace LayoutTest.TC
{
    class ChildMinMaxTest1 : Grid, ITestCase
    {
        public ChildMinMaxTest1()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Flex Child Min/Max Test1",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new FlexBox
                {
                    Name = "Target1",
                    JustifyContent = FlexJustify.Start,
                    Direction = FlexDirection.Row,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new View { BackgroundColor = Color.Yellow, Opacity = 0.7f }.Basis(30).Shrink(0),
                        new MyGrid { BackgroundColor = Color.Green, Opacity = 0.7f }.Shrink(1).Grow(1).MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Shrink(0),
                    }
                }.LayoutBounds(0.5f, 0, 1, 30).LayoutFlags(AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional),
                new FlexBox
                {
                    Name = "Target2",
                    JustifyContent = FlexJustify.Center,
                    Direction = FlexDirection.Row,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new View { BackgroundColor = Color.Yellow, Opacity = 0.7f }.Basis(30).Shrink(0),
                        new MyGrid { BackgroundColor = Color.Green, Opacity = 0.7f }.Shrink(1).Grow(1).MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Shrink(0),
                    }
                }.LayoutBounds(0.5f, 30, 1, 30).LayoutFlags(AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional),
                new FlexBox
                {
                    Name = "Target3",
                    JustifyContent = FlexJustify.End,
                    Direction = FlexDirection.Row,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new View { BackgroundColor = Color.Yellow, Opacity = 0.7f }.Basis(30).Shrink(0),
                        new MyGrid { BackgroundColor = Color.Green, Opacity = 0.7f }.Shrink(1).Grow(1).MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Shrink(0),
                    }
                }.LayoutBounds(0.5f, 60, 1, 30).LayoutFlags(AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional),
                new FlexBox
                {
                    Name = "Target4",
                    JustifyContent = FlexJustify.Center,
                    Direction = FlexDirection.Row,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new View { BackgroundColor = Color.Yellow, Opacity = 0.7f }.Basis(30).Shrink(0),
                        new MyGrid { BackgroundColor = Color.Green, Opacity = 0.7f }.Shrink(1).Grow(1).MaximumWidth(400).MinimumWidth(0),
                        new MyGrid { BackgroundColor = Color.Blue, Opacity = 0.7f }.Shrink(1).Grow(2).MaximumWidth(300).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Shrink(0),
                    }
                }.LayoutBounds(0.5f, 90, 1, 30).LayoutFlags(AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional),

                new Button("Test")
                {
                    Clicked = () => Test()
                }.LayoutBounds(0.5f, 1, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                new TextView
                {
                    FontSize = 20,
                    Text = "<-- less  |  more -->",
                    BackgroundColor = Color.Green,
                    DesiredHeight = 50,
                    Name = "Touch"
                }.TextCenter().LayoutBounds(0.5f, 1, 1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional).Margin(0, 0, 0, 60),
            }.Row(1));

            PanGestureDetector pan = new PanGestureDetector();
            pan.Attach(this["Touch"]);
            pan.Detected += (s, e) =>
            {
                var diff = e.Gesture.ScreenDisplacement.X;
                var old = this["Target1"].AbsoluteParam().LayoutBounds;
                this["Target1"].AbsoluteParam().LayoutBounds = old with { Width = old.Width += (diff / Width) };
                this["Target1"].SendMeasureInvalidated();
                old = this["Target2"].AbsoluteParam().LayoutBounds;
                this["Target2"].AbsoluteParam().LayoutBounds = old with { Width = old.Width += (diff / Width) };
                this["Target2"].SendMeasureInvalidated();
                old = this["Target3"].AbsoluteParam().LayoutBounds;
                this["Target3"].AbsoluteParam().LayoutBounds = old with { Width = old.Width += (diff / Width) };
                this["Target3"].SendMeasureInvalidated();
                old = this["Target4"].AbsoluteParam().LayoutBounds;
                this["Target4"].AbsoluteParam().LayoutBounds = old with { Width = old.Width += (diff / Width) };
                this["Target4"].SendMeasureInvalidated();
            };

        }

        void Test()
        {
            var less = new UIAnimation(p =>
            {
                this["Target1"].LayoutBounds(0.5f, 0, 1 - 0.5f * p, 30);
                this["Target1"].SendMeasureInvalidated();
                this["Target2"].LayoutBounds(0.5f, 30, 1 - 0.5f * p, 30);
                this["Target2"].SendMeasureInvalidated();
                this["Target3"].LayoutBounds(0.5f, 60, 1 - 0.5f * p, 30);
                this["Target3"].SendMeasureInvalidated();
            });
            var expand = new UIAnimation(p =>
            {
                this["Target1"].LayoutBounds(0.5f, 0, 0.5f + 0.5f * p, 30);
                this["Target1"].SendMeasureInvalidated();
                this["Target2"].LayoutBounds(0.5f, 30, 0.5f + 0.5f * p, 30);
                this["Target2"].SendMeasureInvalidated();
                this["Target3"].LayoutBounds(0.5f, 60, 0.5f + 0.5f * p, 30);
                this["Target3"].SendMeasureInvalidated();
            });
            var ani = new UIAnimation
            {
                { 0, 0.5f, less },
                { 0.5f, 1, expand }
            };
            ani.Commit(this, "Test", length: 10000);
        }

        class MyGrid : Grid
        {
            float _width;
            public MyGrid()
            {
                Add(new TextView { Name = "TextView", FontSize = 13 }.TextCenter());
                Relayout += OnRelayout;
            }

            void OnRelayout(object sender, EventArgs e)
            {
                if (_width != Width)
                {
                    _width = Width;
                    (this["TextView"] as TextView).Text = $"{Width:.0} [{this.LayoutParam().MinimumWidth}~{this.LayoutParam().MaximumWidth}]";
                }
            }
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
