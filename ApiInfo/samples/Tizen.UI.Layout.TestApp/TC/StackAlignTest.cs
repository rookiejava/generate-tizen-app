using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class StackAlignTest : Grid, ITestCase
    {
        public StackAlignTest()
        {
            BackgroundColor = Color.White;
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Stack Align test",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                Children =
                {
                    new HStack
                    {
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        BackgroundColor = Color.Green,
                        DesiredWidth = 300,
                        DesiredHeight = 150,
                        ClippingMode = ClippingMode.ClipChildren,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        }
                    }
                    .VerticalLayoutAlignment(LayoutAlignment.Center)
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .ItemAlignment(LayoutAlignment.Center)
                    .LayoutBounds(0, 0, -1, -1)
                    .LayoutFlags(AbsoluteLayoutFlags.None)
                    .Margin(20, 20, 0, 0),

                    new HStack
                    {
                        ClippingMode = ClippingMode.ClipChildren,
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        BackgroundColor = Color.Green,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        }
                    }
                    .VerticalLayoutAlignment(LayoutAlignment.Center)
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .ItemAlignment(LayoutAlignment.Center)
                    .LayoutBounds(0, 0, 300+20, 150+200)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(20, 200, 0, 0),

                    new View
                    {
                        ClippingMode = ClippingMode.ClipChildren,
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        DesiredHeight = 150,
                        DesiredWidth = 300,
                    }
                    .VerticalLayoutAlignment(LayoutAlignment.Center)
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .LayoutBounds(0, 0, -1, -1)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(20, 200, 0, 0),


                    // vertical
                    new VStack
                    {
                        DesiredWidth = 150,
                        DesiredHeight = 300,
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        BackgroundColor = Color.Green,
                        ClippingMode = ClippingMode.ClipChildren,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        }
                    }
                    .VerticalLayoutAlignment(LayoutAlignment.Center)
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .ItemAlignment(LayoutAlignment.Center)
                    .LayoutBounds(1, 0, -1, -1)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 20, 200, 0),


                    new VStack
                    {
                        ClippingMode = ClippingMode.ClipChildren,
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        BackgroundColor = Color.Green,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        }
                    }
                    .VerticalLayoutAlignment(LayoutAlignment.Center)
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .ItemAlignment(LayoutAlignment.Center)
                    .LayoutBounds(1, 0, 150+20, 300+20)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 20, 20, 0),

                    new View
                    {
                        ClippingMode = ClippingMode.ClipChildren,
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        DesiredHeight = 300,
                        DesiredWidth = 150,
                    }
                    .VerticalLayoutAlignment(LayoutAlignment.Center)
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .LayoutBounds(1, 0, -1, -1)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 20, 20, 0),

                }
            }.Row(1));
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
