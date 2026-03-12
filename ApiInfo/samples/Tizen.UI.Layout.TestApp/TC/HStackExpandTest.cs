using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class HStackExpandTest : Grid, ITestCase
    {
        public HStackExpandTest()
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
                Text = "HStack Expand test",
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
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Fill)
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
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Fill)
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
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Fill)
                        .DesiredHeight(150),

                        //// None Fill + Expand Test
                        new HStack
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Start).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
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
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
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
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.End).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(2),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(1),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(2),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(3),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .ItemAlignment(LayoutAlignment.Start)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        //// Test MaximumSize
                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(80),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        //// Test MinimumSize
                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MinimumWidth(300),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MinimumWidth(300),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(300),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(300),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MinimumWidth(300),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MinimumWidth(200),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MinimumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(500)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 10,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MinimumWidth(200),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(600)
                        .DesiredHeight(150),

                        new HStack
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 10,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Cyan, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Expand().MaximumWidth(100),
                            }
                        }
                        .HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredWidth(600)
                        .DesiredHeight(150),
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