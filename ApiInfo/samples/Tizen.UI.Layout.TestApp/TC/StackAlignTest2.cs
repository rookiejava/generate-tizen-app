using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class StackAlignTest2 : Grid, ITestCase
    {
        public StackAlignTest2()
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
                Text = "Stack Align test2",
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
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Green, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.End).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Orange, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Blue, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Start).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        }
                    }
                    .ItemAlignment(LayoutAlignment.Center)
                    .LayoutBounds(0, 0, -1, -1)
                    .DesiredSize(120, 60)
                    .LayoutFlags(AbsoluteLayoutFlags.None)
                    .Margin(120, 60, 0, 0),


                    new HStack
                    {
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Green, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.End).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Orange, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Blue, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Start).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        }
                    }
                    .ItemAlignment(LayoutAlignment.Start)
                    .LayoutBounds(0, 0, -1, -1)
                    .DesiredSize(120, 60)
                    .LayoutFlags(AbsoluteLayoutFlags.None)
                    .Margin(120, 150 + 60, 0, 0),

                    new HStack
                    {
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Green, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.End).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Orange, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Blue, DesiredHeight = 100, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Start).HorizontalLayoutAlignment(LayoutAlignment.Center),
                        }
                    }
                    .ItemAlignment(LayoutAlignment.End)
                    .LayoutBounds(0, 0, -1, -1)
                    .DesiredSize(120, 60)
                    .LayoutFlags(AbsoluteLayoutFlags.None)
                    .Margin(120, 300 + 60, 0, 0),


                    // vertical
                    new VStack
                    {
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Green, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Start),
                            new View { BackgroundColor = Color.Orange, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.End),
                        }
                    }
                    .ItemAlignment(LayoutAlignment.Start)
                    .LayoutBounds(1, 0, -1, -1)
                    .DesiredSize(60, 120)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 100, 60, 0),

                    new VStack
                    {
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Green, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Start),
                            new View { BackgroundColor = Color.Orange, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.End),
                        }
                    }
                    .ItemAlignment(LayoutAlignment.Center)
                    .LayoutBounds(1, 0, -1, -1)
                    .DesiredSize(60, 120)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 100, 200, 0),

                    new VStack
                    {
                        BorderlineWidth = 2,
                        BorderlineColor = Color.Red,
                        Spacing = 40,
                        Children =
                        {
                            new View { BackgroundColor = Color.Green, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Start),
                            new View { BackgroundColor = Color.Orange, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 100 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.End),
                        }
                    }
                    .ItemAlignment(LayoutAlignment.End)
                    .LayoutBounds(1, 0, -1, -1)
                    .DesiredSize(60, 120)
                    .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                    .Margin(0, 100, 360, 0),

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
