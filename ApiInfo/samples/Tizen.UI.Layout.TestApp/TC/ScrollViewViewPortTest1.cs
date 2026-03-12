using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewViewPortTest1 : Grid, ITestCase
    {
        public ScrollViewViewPortTest1()
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
                Text = "ScrollViewViewPort Test1",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Both,
                Content = new VStack
                {
                    new TextView
                    {
                        Text = "ViewPort example",
                        FontSize = 20,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),

                    new ScrollLayout
                    {
                        ScrollDirection = ScrollDirection.Horizontal,
                        DesiredHeight = 100,
                        DesiredWidth = 350,
                        BackgroundColor = Color.LightBlue,
                        Content = new HStack
                        {
                            BackgroundColor = Color.LightGreen
                        }.Self(stack =>
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                stack.Add(new TextView
                                {
                                    DesiredWidth = 50,
                                    Text = $"{i+1}",
                                    FontSize = 20,
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    BorderlineColor = Color.Black,
                                    BorderlineWidth = 1,
                                });
                            }
                        }),
                    }.Self(out var scroller),

                    new AbsoluteLayout
                    {
                        new HStack
                        {
                            DesiredHeight = 100,
                            BackgroundColor = Color.LightGreen
                        }.Self(stack =>
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                stack.Add(new TextView
                                {
                                    DesiredWidth = 50,
                                    Text = $"{i+1}",
                                    FontSize = 20,
                                    VerticalAlignment = TextAlignment.Center,
                                    HorizontalAlignment = TextAlignment.Center,
                                    BorderlineColor = Color.Black,
                                    BorderlineWidth = 1,
                                });
                            }
                        }).HorizontalLayoutAlignment(LayoutAlignment.Center)
                        .LayoutBounds(0, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),

                        new View
                        {
                            DesiredHeight = 100,
                            DesiredWidth = 400,
                            BorderlineColor = Color.Red,
                            BorderlineWidth = 2,
                            BorderlineOffset = -1,
                        }.LayoutBounds(0, 0, -1, -1).Self(out var marker)

                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                }.Spacing(20)
            }.Row(1).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center));

            scroller.Dragging += (sender, e) =>
            {
                var viewPort = scroller.ViewPort;
                marker.Margin(viewPort.X, 0, 0, 0);
                marker.DesiredHeight = viewPort.Height;
                marker.DesiredWidth = viewPort.Width;
            };
            scroller.Scrolling += (sender, e) =>
            {
                var viewPort = scroller.ViewPort;
                marker.Margin(viewPort.X, 0, 0, 0);
                marker.DesiredHeight = viewPort.Height;
                marker.DesiredWidth = viewPort.Width;
            };

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
