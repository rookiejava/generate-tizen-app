using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class TextInTheLayout : Grid, ITestCase
    {

        class TextInButton : ContentView
        {
            public TextInButton()
            {
                BorderlineColor = Color.Black;
                BorderlineWidth = 1;
                this.HorizontalLayoutAlignment(LayoutAlignment.Center);
                Body = new HStack
                {
                    new TextView
                    {
                        FontSize = 20,
                        TextOverflow = TextOverflow.EndEllipsis,
                        Text = "Hello world Hello world Hello world Hello world"
                    }.Center().Margin(10),
                };
                Body.TouchEvent += OnTouch;
                this.MaximumWidth(400);
            }

            void OnTouch(object sender, TouchEventArgs e)
            {
                e.Handled = true;
                if (e.Touch[0].State == TouchState.Up)
                {
                    var width = this.LayoutParam().MaximumWidth;
                    this.MaximumWidth(width - 10);
                }
            }
        }

        public TextInTheLayout()
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
                Text = "Text in the Layout",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Children =
                    {
                        new TextView
                        {
                            FontSize = 15,
                            Text = "ContentView[MaximumWidth(400)] > HStack > TextView[Margin(10)]"
                        }.Center(),
                        new TextInButton(),
                        new TextView
                        {
                            FontSize = 15,
                            Text = "Absolute[Margin(10),Padding(5), DesiredWidth(300)]> TextView[LayoutBound(.5f, .5f, -1, -1), Margin(10)]"
                        }.Center(),
                        new AbsoluteLayout
                        {
                            DesiredWidth = 300,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Padding = 5,
                            Children =
                            {
                                new TextView
                                {
                                    BackgroundColor = Color.Yellow,
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(10)
                            }
                        }.Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    view.DesiredWidth -= 5;
                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "Absolute[Margin(10), HorizontalLayoutAlignment(Center), MaximumWith(400)]> TextView[LayoutBound(.5f, .5f, -1, -1), Margin(10)]"
                        }.Center(),
                        new AbsoluteLayout
                        {
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(10)
                            }
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center).MaximumWidth(400).Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    var max = view.LayoutParam().MaximumWidth;
                                    view.MaximumWidth(max - 20);

                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "Absolute[Margin(10), HorizontalLayoutAlignment(Fill), MaximumWith(400)]> TextView[LayoutBound(.5f, .5f, -1, -1), Margin(10)]"
                        }.Center(),
                        new AbsoluteLayout
                        {
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(10)
                            }
                        }.HorizontalLayoutAlignment(LayoutAlignment.Fill).MaximumWidth(400).Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    var max = view.LayoutParam().MaximumWidth;
                                    view.MaximumWidth(max - 20);

                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "Grid[Margin(10), DesiredWidth(300), DesiredHeight(50)]> TextView[Margin(10)]"
                        }.Center(),
                        new Grid
                        {
                            DesiredHeight = 50,
                            DesiredWidth = 300,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.Margin(10)
                            }
                        }.Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    view.DesiredWidth -= 5;
                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "Grid[Margin(10), HorizontalLayoutAlignment(Center), MaximumWith(400)]> TextView[Margin(10)]"
                        }.Center(),
                        new Grid
                        {
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.Margin(10)
                            }
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center).MaximumWidth(400).Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    var max = view.LayoutParam().MaximumWidth;
                                    view.MaximumWidth(max - 20);

                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "Grid[Margin(10), HorizontalLayoutAlignment(Fill), MaximumWith(400)]> TextView[Margin(10)]"
                        }.Center(),
                        new Grid
                        {
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.Margin(10).Center()
                            }
                        }.HorizontalLayoutAlignment(LayoutAlignment.Fill).MaximumWidth(400).Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    var max = view.LayoutParam().MaximumWidth;
                                    view.MaximumWidth(max - 20);

                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "HStack[Margin(10), DesiredWidth(300), DesiredHeight(50)]> TextView[Margin(10)]"
                        }.Center(),
                        new HStack
                        {
                            DesiredHeight = 50,
                            DesiredWidth = 300,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.Margin(10)
                            }
                        }.Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    view.DesiredWidth -= 5;
                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "HStack[Margin(10), HorizontalLayoutAlignment(Center), MaximumWith(400)]> TextView[Margin(10)]"
                        }.Center(),
                        new HStack
                        {
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.Margin(10)
                            }
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center).MaximumWidth(400).Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    var max = view.LayoutParam().MaximumWidth;
                                    view.MaximumWidth(max - 20);

                                }
                            };
                        }),

                        new TextView
                        {
                            FontSize = 15,
                            Text = "HStack[Margin(10), HorizontalLayoutAlignment(Fill), MaximumWith(400)]> TextView[Margin(10)]"
                        }.Center(),
                        new HStack
                        {
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 20,
                                    TextOverflow = TextOverflow.EndEllipsis,
                                    Text = "Hello world Hello world Hello world Hello world"
                                }.Margin(10).Center()
                            }
                        }.HorizontalLayoutAlignment(LayoutAlignment.Fill).MaximumWidth(400).Margin(10).Self(view =>
                        {
                            view.TouchEvent += (s, e) =>
                            {
                                e.Handled = true;
                                if (e.Touch[0].State == TouchState.Up)
                                {
                                    var max = view.LayoutParam().MaximumWidth;
                                    view.MaximumWidth(max - 20);

                                }
                            };
                        }),
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
