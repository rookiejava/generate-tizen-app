using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewSnapTest1 : Grid, ITestCase
    {
        public ScrollViewSnapTest1()
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
                Text = "ScrollView Snap Test1",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    new TextView
                    {
                        Text = "Vertical, SnapPointsType.Mandatory",
                        FontSize = 20,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ScrollLayout
                    {
                        ScrollDirection = ScrollDirection.Vertical,
                        DesiredHeight = 300,
                        Content = new VStack().Self(stack =>
                        {
                            var rnd = new Random();
                            for (int i = 0; i < 40; i++)
                            {
                                stack.Add(new TextView
                                {
                                    FontSize = 30,
                                    HorizontalAlignment = TextAlignment.Center,
                                    VerticalAlignment = TextAlignment.Center,
                                    Text = $"{i+1}",
                                    BackgroundColor = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f),
                                    DesiredHeight = 200,
                                    DesiredWidth = 500,
                                });
                            }
                        }),
                    }
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Start)
                    .Self(out var scrollview1),

                    new HStack
                    {
                        new TextView
                        {
                            FontSize = 20,
                            Text = "Aligement: "
                        }.VerticalLayoutAlignment(LayoutAlignment.Center),
                        new Button("Start")
                        {
                            Clicked = () => scrollview1.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Start)
                        },
                        new Button("Center")
                        {
                            Clicked = () => scrollview1.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Center)
                        },
                        new Button("End")
                        {
                            Clicked = () => scrollview1.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.End)
                        },
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center).Spacing(10),

                    new TextView
                    {
                        Text = "Horizontal, SnapPointsType.Mandatory",
                        FontSize = 20,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ScrollLayout
                    {
                        ScrollDirection = ScrollDirection.Horizontal,
                        DesiredWidth = 700,
                        Content = new HStack().Self(stack =>
                        {
                            var rnd = new Random();
                            for (int i = 0; i < 40; i++)
                            {
                                stack.Add(new TextView
                                {
                                    FontSize = 30,
                                    HorizontalAlignment = TextAlignment.Center,
                                    VerticalAlignment = TextAlignment.Center,
                                    Text = $"{i+1}",
                                    BackgroundColor = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f),
                                    DesiredHeight = 200,
                                    DesiredWidth = 500,
                                });
                            }
                        }),
                    }
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Start)
                    .Self(out var scrollview2),

                    new HStack
                    {
                        new TextView
                        {
                            FontSize = 20,
                            Text = "Aligement: "
                        }.VerticalLayoutAlignment(LayoutAlignment.Center),
                        new Button("Start")
                        {
                            Clicked = () => scrollview2.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Start)
                        },
                        new Button("Center")
                        {
                            Clicked = () => scrollview2.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Center)
                        },
                        new Button("End")
                        {
                            Clicked = () => scrollview2.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.End)
                        },
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center).Spacing(10),

                    new TextView
                    {
                        Text = "Vertical, SnapPointsType.MandatorySingle",
                        FontSize = 20,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ScrollLayout
                    {
                        ScrollDirection = ScrollDirection.Vertical,
                        DesiredHeight = 300,
                        Content = new VStack().Self(stack =>
                        {
                            var rnd = new Random();
                            for (int i = 0; i < 40; i++)
                            {
                                stack.Add(new TextView
                                {
                                    FontSize = 30,
                                    HorizontalAlignment = TextAlignment.Center,
                                    VerticalAlignment = TextAlignment.Center,
                                    Text = $"{i+1}",
                                    BackgroundColor = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f),
                                    DesiredHeight = 200,
                                    DesiredWidth = 500,
                                });
                            }
                        }),
                    }
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Start)
                    .Self(out var scrollview3),

                    new HStack
                    {
                        new TextView
                        {
                            FontSize = 20,
                            Text = "Aligement: "
                        }.VerticalLayoutAlignment(LayoutAlignment.Center),
                        new Button("Start")
                        {
                            Clicked = () => scrollview3.SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Start)
                        },
                        new Button("Center")
                        {
                            Clicked = () => scrollview3.SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Center)
                        },
                        new Button("End")
                        {
                            Clicked = () => scrollview3.SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.End)
                        },
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center).Spacing(10),

                    new TextView
                    {
                        Text = "Horizontal, SnapPointsType.MandatorySingle",
                        FontSize = 20,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ScrollLayout
                    {
                        ScrollDirection = ScrollDirection.Horizontal,
                        DesiredWidth = 700,
                        Content = new HStack().Self(stack =>
                        {
                            var rnd = new Random();
                            for (int i = 0; i < 40; i++)
                            {
                                stack.Add(new TextView
                                {
                                    FontSize = 30,
                                    HorizontalAlignment = TextAlignment.Center,
                                    VerticalAlignment = TextAlignment.Center,
                                    Text = $"{i+1}",
                                    BackgroundColor = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f),
                                    DesiredHeight = 200,
                                    DesiredWidth = 500,
                                });
                            }
                        }),
                    }
                    .HorizontalLayoutAlignment(LayoutAlignment.Center)
                    .SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Start)
                    .Self(out var scrollview4),

                    new HStack
                    {
                        new TextView
                        {
                            FontSize = 20,
                            Text = "Aligement: "
                        }.VerticalLayoutAlignment(LayoutAlignment.Center),
                        new Button("Start")
                        {
                            Clicked = () => scrollview4.SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Start)
                        },
                        new Button("Center")
                        {
                            Clicked = () => scrollview4.SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Center)
                        },
                        new Button("End")
                        {
                            Clicked = () => scrollview4.SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.End)
                        },
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center).Spacing(10),

                    new ScrollLayout
                    {
                        ScrollDirection = ScrollDirection.Horizontal,
                        DesiredHeight = 200,
                        DesiredWidth = 500,
                        Content = new HStack
                        {
                        }.Self(stack =>
                        {
                            var rnd = new Random();
                            for (int i = 0; i < 20; i++)
                            {
                                stack.Add(new TextView
                                {
                                    FontSize = 30,
                                    HorizontalAlignment = TextAlignment.Center,
                                    VerticalAlignment = TextAlignment.Center,
                                    Text = $"{i+1}",
                                    BackgroundColor = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f),
                                    DesiredHeight = 200,
                                    DesiredWidth = 500,
                                });
                            }
                        }),
                    }.Self((scroll) =>
                    {
                        scroll.SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Center);
                    }),

                    new TextView
                    {
                        Text = "Horizontal / center with padding",
                        FontSize = 20,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ScrollLayout
                    {
                        BackgroundColor = Color.Yellow,
                        Padding = 30,
                        ScrollDirection = ScrollDirection.Horizontal,
                        DesiredHeight = 200,
                        DesiredWidth = 500,
                        Content = new HStack
                        {
                        }.Self(stack =>
                        {
                            var rnd = new Random();
                            for (int i = 0; i < 20; i++)
                            {
                                stack.Add(new View
                                {
                                    BackgroundColor = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f),
                                    DesiredHeight = 200 - 60,
                                    DesiredWidth = 500 - 60,
                                });
                            }
                        }),
                    }.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Center),

                    new TextView
                    {
                        Text = "Vertical / center with padding",
                        FontSize = 20,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ScrollLayout
                    {
                        BackgroundColor = Color.Yellow,
                        Padding = 30,
                        ScrollDirection = ScrollDirection.Vertical,
                        DesiredHeight = 200,
                        DesiredWidth = 500,
                        Content = new VStack
                        {
                        }.Self(stack =>
                        {
                            var rnd = new Random();
                            for (int i = 0; i < 20; i++)
                            {
                                stack.Add(new View
                                {
                                    BackgroundColor = new Color((float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f, (float)rnd.NextDouble() * 0.7f + 0.3f),
                                    DesiredHeight = 200 - 60,
                                    DesiredWidth = 500 - 60,
                                });
                            }
                        }),
                    }
                    .SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Center),
                }.Spacing(20).Padding(0, 20, 0, 20),

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
