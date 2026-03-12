using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewSnapTest2 : Grid, ITestCase
    {
        public ScrollViewSnapTest2()
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
                Text = "ScrollView Snap Test2",
                FontSize = 30,
            });

            Add(new VStack
            {
                new TextView
                {
                    Text = "Picker example",
                    FontSize = 20,
                }.HorizontalLayoutAlignment(LayoutAlignment.Center),

                new HStack
                {
                    new AbsoluteLayout
                    {
                        BackgroundColor = Color.LightBlue,
                        DesiredHeight = 150,
                        DesiredWidth = 200,
                        Children =
                        {
                            new ScrollLayout
                            {
                                VerticalScrollBarVisibility = ScrollBarVisibility.Never,
                                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                                Padding = new Thickness(0, 60, 0, 60),
                                ScrollDirection = ScrollDirection.Vertical,
                                Content = new VStack
                                {
                                }.Self(stack =>
                                {
                                    for (int i = 0; i < 10; i++)
                                    {
                                        stack.Add(new TextView
                                        {
                                            FontSize = 20,
                                            DesiredHeight = 60,
                                            VerticalAlignment = TextAlignment.Center,
                                            HorizontalAlignment = TextAlignment.Center,
                                            Text = $"{i+1}"
                                        });
                                    }
                                }),
                            }
                            .LayoutBounds(0.5f, 0.5f, 1, 1)
                            .LayoutFlags(AbsoluteLayoutFlags.All)
                            .SetSnap(SnapPointsType.MandatorySingle, SnapPointsAlignment.Center)
                            .Self(scroll =>
                            {
                                UIApplication.Current.PostToUI(() =>
                                {
                                    var content = scroll.Content as ViewGroup;
                                    scroll.ScrollTo(content[0], false, ScrollToPosition.Center);
                                });
                            }),
                            new View
                            {
                                DesiredHeight = 2,
                                CornerRadius = 1,
                                BackgroundColor = Color.Black,
                            }
                            .Margin(30, 0, 30, 60)
                            .LayoutBounds(0.5f,0.5f, 1, -1)
                            .LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional),
                            new View
                            {
                                DesiredHeight = 2,
                                CornerRadius = 1,
                                BackgroundColor = Color.Black,
                            }
                            .Margin(30, 60, 30, 0)
                            .LayoutBounds(0.5f,0.5f, 1, -1)
                            .LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional)
                        }
                    },
                    new AbsoluteLayout
                    {
                        BackgroundColor = Color.LightBlue,
                        DesiredHeight = 150,
                        DesiredWidth = 200,
                        Children =
                        {
                            new ScrollLayout
                            {
                                VerticalScrollBarVisibility = ScrollBarVisibility.Never,
                                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                                Padding = new Thickness(0, 60, 0, 60),
                                ScrollDirection = ScrollDirection.Vertical,
                                Content = new VStack
                                {
                                }.Self(stack =>
                                {
                                    for (int i = 0; i < 31; i++)
                                    {
                                        stack.Add(new TextView
                                        {
                                            FontSize = 20,
                                            DesiredHeight = 60,
                                            VerticalAlignment = TextAlignment.Center,
                                            HorizontalAlignment = TextAlignment.Center,
                                            Text = $"{i+1}"
                                        });
                                    }
                                }),
                            }
                            .LayoutBounds(0.5f, 0.5f, 1, 1)
                            .LayoutFlags(AbsoluteLayoutFlags.All)
                            .SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Center)
                            .Self(scroll =>
                            {
                                UIApplication.Current.PostToUI(() =>
                                {
                                    var content = scroll.Content as ViewGroup;
                                    scroll.ScrollTo(content[0], false, ScrollToPosition.Center);
                                });
                            }),
                            new View
                            {
                                DesiredHeight = 2,
                                CornerRadius = 1,
                                BackgroundColor = Color.Black,
                            }
                            .Margin(30, 0, 30, 60)
                            .LayoutBounds(0.5f,0.5f, 1, -1)
                            .LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional),
                            new View
                            {
                                DesiredHeight = 2,
                                CornerRadius = 1,
                                BackgroundColor = Color.Black,
                            }
                            .Margin(30, 60, 30, 0)
                            .LayoutBounds(0.5f,0.5f, 1, -1)
                            .LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional)
                        }
                    },
                }.Spacing(20),


                new TextView
                {
                    Text = "Uneven example",
                    FontSize = 20,
                }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                new ScrollLayout
                {
                    BackgroundColor = Color.LightGreen,
                    ScrollDirection = ScrollDirection.Horizontal,
                    DesiredHeight = 150,
                    DesiredWidth = 300,
                    Padding = new Thickness(50, 0, 50, 0),
                    Content = new HStack
                    {
                        DesiredHeight = 150,
                    }.Self(stack =>
                    {
                        var rnd = new Random();
                        for (int i = 0; i < 50; i++)
                        {
                            stack.Add(new View
                            {
                                BackgroundColor = new Color((float)(rnd.NextDouble()*0.7 + 0.3f), (float)(rnd.NextDouble()*0.7 + 0.3f), (float)(rnd.NextDouble()*0.7 + 0.3f)),
                                DesiredWidth = rnd.Next(100, 300),
                            });
                        }
                    })
                }.SetSnap(SnapPointsType.Mandatory, SnapPointsAlignment.Center),
            }.Row(1).Spacing(20).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center));
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
