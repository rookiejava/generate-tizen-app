using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackAlignTest : Grid, ITestCase
    {
        public VStackAlignTest()
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
                Text = "VStack Align test",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Horizontal,
                Content = new HStack
                {
                    Padding = 10,
                    Spacing = 10,
                    Children =
                    {
                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Fill)
                        .ItemAlignment(LayoutAlignment.Center)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Fill)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Fill)
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredHeight(300)
                        .DesiredWidth(150),

                        new VStack
                        {
                            Padding = new Thickness(0, 0, 0, 20),
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
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredHeight(300)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Center)
                        .DesiredHeight(300)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredHeight(300)
                        .DesiredWidth(150),

                        new VStack
                        {
                            Padding = new Thickness(0, 20, 0, 0),
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
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredHeight(300)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Start)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.End)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.End)
                        .DesiredHeight(100)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Center)
                        .DesiredHeight(100)
                        .DesiredWidth(150),

                        new VStack
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredHeight(100)
                        .DesiredWidth(150),
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