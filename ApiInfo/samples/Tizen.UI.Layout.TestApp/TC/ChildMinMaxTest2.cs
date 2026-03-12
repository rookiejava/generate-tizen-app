using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Components.Animations;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ChildMinMaxTest2 : Grid, ITestCase
    {
        public ChildMinMaxTest2()
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
                Text = "Flex Child Min/Max Test2",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new FlexBox
                {
                    Name = "Target1",
                    JustifyContent = FlexJustify.Start,
                    Direction = FlexDirection.Column,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new View { BackgroundColor = Color.Yellow, Opacity = 0.7f }.Basis(30).Shrink(0),
                        new MyGrid { BackgroundColor = Color.Green, Opacity = 0.7f }.Shrink(1).Grow(1).MaximumHeight(400).MinimumHeight(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Shrink(0),
                    }
                }.LayoutBounds(0, 0.5f, 60, 1).LayoutFlags(AbsoluteLayoutFlags.HeightProportional | AbsoluteLayoutFlags.YProportional),
                new FlexBox
                {
                    Name = "Target2",
                    JustifyContent = FlexJustify.Center,
                    Direction = FlexDirection.Column,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new View { BackgroundColor = Color.Yellow, Opacity = 0.7f }.Basis(30).Shrink(0),
                        new MyGrid { BackgroundColor = Color.Green, Opacity = 0.7f }.Shrink(1).Grow(1).MaximumHeight(400).MinimumHeight(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Shrink(0),
                    }
                }.LayoutBounds(60, 0.5f, 60, 1).LayoutFlags(AbsoluteLayoutFlags.HeightProportional | AbsoluteLayoutFlags.YProportional),
                new FlexBox
                {
                    Name = "Target3",
                    JustifyContent = FlexJustify.End,
                    Direction = FlexDirection.Column,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new View { BackgroundColor = Color.Yellow, Opacity = 0.7f }.Basis(30).Shrink(0),
                        new MyGrid { BackgroundColor = Color.Green, Opacity = 0.7f }.Shrink(1).Grow(1).MaximumHeight(400).MinimumHeight(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Shrink(0),
                    }
                }.LayoutBounds(120, 0.5f, 60, 1).LayoutFlags(AbsoluteLayoutFlags.HeightProportional | AbsoluteLayoutFlags.YProportional),
                new FlexBox
                {
                    Name = "Target4",
                    JustifyContent = FlexJustify.Center,
                    Direction = FlexDirection.Column,
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
                }.LayoutBounds(180, 0.5f, 60, 1).LayoutFlags(AbsoluteLayoutFlags.HeightProportional | AbsoluteLayoutFlags.YProportional),

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
                this["Target1"].AbsoluteParam().LayoutBounds = old with { Height = old.Height += (diff / Height) };
                this["Target1"].SendMeasureInvalidated();
                old = this["Target2"].AbsoluteParam().LayoutBounds;
                this["Target2"].AbsoluteParam().LayoutBounds = old with { Height = old.Height += (diff / Height) };
                this["Target2"].SendMeasureInvalidated();
                old = this["Target3"].AbsoluteParam().LayoutBounds;
                this["Target3"].AbsoluteParam().LayoutBounds = old with { Height = old.Height += (diff / Height) };
                this["Target3"].SendMeasureInvalidated();
                old = this["Target4"].AbsoluteParam().LayoutBounds;
                this["Target4"].AbsoluteParam().LayoutBounds = old with { Height = old.Height += (diff / Height) };
                this["Target4"].SendMeasureInvalidated();
            };

        }

        class MyGrid : Grid
        {
            float _height;
            public MyGrid()
            {
                Add(new TextView { Name = "TextView", FontSize = 13, IsMultiline = true }.TextCenter());
                Relayout += OnRelayout;
            }

            void OnRelayout(object sender, EventArgs e)
            {
                if (_height != Height)
                {
                    _height = Height;
                    (this["TextView"] as TextView).Text = $"{Height:.0} [{this.LayoutParam().MinimumHeight}~{this.LayoutParam().MaximumHeight}]";
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
