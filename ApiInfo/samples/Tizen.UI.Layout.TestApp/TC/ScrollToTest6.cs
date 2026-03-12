using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollToTest6 : Grid, ITestCase
    {
        public ScrollToTest6()
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
                Text = "ScrollToTest6",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    new TextView
                    {
                        FontSize = 20,
                        Text = "200x500, Padding(30), content (120x420)"
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
                                    DesiredHeight = 200 - 80,
                                    DesiredWidth = 500 - 80,
                                });
                            }
                        }),
                    }.Self(out var scroll1),
                    new HStack
                    {
                        new Button("ScrollToFirst(center)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[0], true, ScrollToPosition.Center);
                            }
                        },
                        new Button("ScrollToFirst(Start)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[0], true, ScrollToPosition.Start);
                            }
                        },
                        new Button("ScrollToFirst(End)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[0], true, ScrollToPosition.End);
                            }
                        },
                        new Button("ScrollTo 10(center)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[10], true, ScrollToPosition.Center);
                            }
                        },
                        new Button("ScrollTo 10(Start)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[10], true, ScrollToPosition.Start);
                            }
                        },
                        new Button("ScrollTo 10(End)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[10], true, ScrollToPosition.End);
                            }
                        },

                        new Button("ScrollToLast(center)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[(scroll1.Content as ViewGroup).Count - 1], true, ScrollToPosition.Center);
                            }
                        },
                        new Button("ScrollToLast(Start)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[(scroll1.Content as ViewGroup).Count - 1], true, ScrollToPosition.Start);
                            }
                        },
                        new Button("ScrollToLast(End)")
                        {
                            Clicked = () =>
                            {
                                scroll1.ScrollTo((scroll1.Content as ViewGroup)[(scroll1.Content as ViewGroup).Count - 1], true, ScrollToPosition.End);
                            }
                        },
                    }.Spacing(20).HorizontalLayoutAlignment(LayoutAlignment.Center).AttachScroll(),

                    new TextView
                    {
                        FontSize = 20,
                        Text = "200x500, Padding(30), content (120x420)"
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
                                    DesiredHeight = 200 - 80,
                                    DesiredWidth = 500 - 80,
                                });
                            }
                        }),
                    }.Self(out var scroll2),
                    new HStack
                    {
                        new Button("ScrollToFirst(center)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[0], true, ScrollToPosition.Center);
                            }
                        },
                        new Button("ScrollToFirst(Start)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[0], true, ScrollToPosition.Start);
                            }
                        },
                        new Button("ScrollToFirst(End)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[0], true, ScrollToPosition.End);
                            }
                        },
                        new Button("ScrollTo 10(center)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[10], true, ScrollToPosition.Center);
                            }
                        },
                        new Button("ScrollTo 10(Start)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[10], true, ScrollToPosition.Start);
                            }
                        },
                        new Button("ScrollTo 10(End)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[10], true, ScrollToPosition.End);
                            }
                        },

                        new Button("ScrollToLast(center)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[(scroll2.Content as ViewGroup).Count - 1], true, ScrollToPosition.Center);
                            }
                        },
                        new Button("ScrollToLast(Start)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[(scroll2.Content as ViewGroup).Count - 1], true, ScrollToPosition.Start);
                            }
                        },
                        new Button("ScrollToLast(End)")
                        {
                            Clicked = () =>
                            {
                                scroll2.ScrollTo((scroll2.Content as ViewGroup)[(scroll2.Content as ViewGroup).Count - 1], true, ScrollToPosition.End);
                            }
                        },
                    }.Spacing(20).HorizontalLayoutAlignment(LayoutAlignment.Center).AttachScroll(),

                }.Spacing(20),

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

    static class AttachScrollView
    {
        public static ScrollLayout AttachScroll(this View view)
        {
            bool isHorizontal = false;
            if (view is HStack)
            {
                isHorizontal = true;
            }
            else if (view is FlexBox flex)
            {
                isHorizontal = flex.Direction == FlexDirection.Row;
            }

            return new ScrollLayout
            {
                ScrollDirection = isHorizontal ? ScrollDirection.Horizontal : ScrollDirection.Vertical,
                Content = view,
            };
        }
    }
}
