using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class HStackAlignTest : Grid, ITestCase
    {
        public HStackAlignTest()
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
                Text = "HStack Align test",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Vertical,
                Content = new VStack
                {
                    Padding = 10,
                    Spacing = 10,
                    Children =
                    {
                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Fill)
                        .ItemAlignment(LayoutAlignment.Center)
                        .DesiredHeight(150),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Fill)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredHeight(150),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Fill)
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredHeight(150),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredHeight(150)
                        .DesiredWidth(300),

                        new HStack
                        {
                            Padding = new Thickness(0, 0, 20, 0),
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredHeight(150)
                        .DesiredWidth(300),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Center)
                        .DesiredHeight(150)
                        .DesiredWidth(300),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredHeight(150)
                        .DesiredWidth(300),

                        new HStack
                        {
                            Padding = new Thickness(20, 0, 0, 0),
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredHeight(150)
                        .DesiredWidth(300),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Start)
                        .DesiredHeight(150),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(150),

                        new HStack
                        {
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
                        .HorizontalLayoutAlignment(LayoutAlignment.End)
                        .DesiredHeight(150),

                        new HStack
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredHeight(150)
                        .DesiredWidth(100),

                        new HStack
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Center)
                        .DesiredHeight(150)
                        .DesiredWidth(100),

                        new HStack
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredHeight(150)
                        .DesiredWidth(100),
                    }
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