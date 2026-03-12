using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class CustomLayoutTest2 : Grid, ITestCase
    {
        public CustomLayoutTest2()
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
                Text = "Custom Layout Test2",
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
                        new CustomVStackLayout
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Fill)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Fill)
                        .DesiredWidth(150),

                        new CustomVStackLayout
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
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Fill)
                        .DesiredWidth(150),

                        // None Fill + Expand Test
                        new CustomVStackLayout
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Start).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
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
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.End).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(2),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredHeight = 50, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(1),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(2),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(3),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        // Test MaximumSize
                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(80),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        // Test MinimumSize
                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(300),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(300),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(300),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(300),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(300),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 40,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(200),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(500)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 10,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(200),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand(),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(600)
                        .DesiredWidth(150),

                        new CustomVStackLayout
                        {
                            Padding = 20,
                            BorderlineWidth = 2,
                            BorderlineColor = Color.Red,
                            BackgroundColor = Color.Green,
                            ClippingMode = ClippingMode.ClipChildren,
                            Spacing = 10,
                            Children =
                            {
                                new View { BackgroundColor = Color.Blue, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(100),
                                new View { BackgroundColor = Color.Cyan, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MinimumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                                new View { BackgroundColor = Color.Yellow, DesiredWidth = 50 }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Center).Expand().MaximumHeight(100),
                            }
                        }
                        .VerticalLayoutAlignment(LayoutAlignment.Center)
                        .DesiredHeight(600)
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