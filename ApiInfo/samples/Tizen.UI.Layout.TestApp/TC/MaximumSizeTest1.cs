using LayoutTest.Util;
using System;
using System.Text;
using Tizen.UI;
using Tizen.UI.Components.Animations;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class MaximumSizeTest1 : Grid, ITestCase
    {
        PanGestureDetector pan;
        public MaximumSizeTest1()
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
                Text = "MaximumSizeTest1",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new HStack
                {
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView {
                            BackgroundColor = Color.Yellow,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "HStack { TextView }"
                        },
                        new TextView {
                            Name = "Label1",
                            BackgroundColor = Color.Green,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "Loooooong Text"
                        }.MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.DesiredWidth(30),
                    }
                }.LayoutBounds(0.5f, 0, 1, 30).LayoutFlags(AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional),

                new HStack
                {
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView {
                            BackgroundColor = Color.Yellow,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "HStack { ContentView { TextView } }"
                        },
                        new MyLabel {
                            Name = "Label2",
                            BackgroundColor = Color.Green,
                            Opacity = 0.7f,
                            Text = "Loooooong Text"
                        }.MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.DesiredWidth(30),
                    }
                }.LayoutBounds(0.5f, 40, 1, 30).LayoutFlags(AbsoluteLayoutFlags.XProportional| AbsoluteLayoutFlags.WidthProportional),

                new HStack
                {
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView {
                            BackgroundColor = Color.Yellow,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "HStack { Grid { TextView } }",
                            VerticalAlignment = TextAlignment.Center,
                        },
                        new Button ("Text") {
                            Name = "Button1",
                            BackgroundColor = Color.Green,
                            Opacity = 0.7f,
                            Text = "Loooooong Text"
                        }.MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.DesiredWidth(30),
                    }
                }.LayoutBounds(0.5f, 80, 1, 60).LayoutFlags(AbsoluteLayoutFlags.XProportional| AbsoluteLayoutFlags.WidthProportional),

                new HStack
                {
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView {
                            BackgroundColor = Color.Yellow,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "HStack { Grid(margin) { TextView } }",
                            VerticalAlignment = TextAlignment.Center,
                        },
                        new Button ("Text") {
                            Name = "Button2",
                            BackgroundColor = Color.Green,
                            Opacity = 0.7f,
                            Text = "Loooooong Text"
                        }.MaximumWidth(400).MinimumWidth(200).Margin(50, 0),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.DesiredWidth(30),
                    }
                }.LayoutBounds(0.5f, 150, 1, 60).LayoutFlags(AbsoluteLayoutFlags.XProportional| AbsoluteLayoutFlags.WidthProportional),

                new HStack
                {
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView {
                            BackgroundColor = Color.Yellow,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "HStack { ContentView { button } }",
                            VerticalAlignment = TextAlignment.Center,
                        },
                        new MyButton {
                            Name = "Button3",
                            BackgroundColor = Color.Green,
                            Opacity = 0.7f,
                            Text = "Loooooong Text"
                        }.MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.DesiredWidth(30),
                    }
                }.LayoutBounds(0.5f, 220, 1, 60).LayoutFlags(AbsoluteLayoutFlags.XProportional| AbsoluteLayoutFlags.WidthProportional),

                new HStack
                {
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView {
                            BackgroundColor = Color.Yellow,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "HStack { ContentView(margin) { button } }",
                            VerticalAlignment = TextAlignment.Center,
                        }.DesiredWidth(400),
                        new MyButton {
                            Name = "Button4",
                            BackgroundColor = Color.Green,
                            Opacity = 0.7f,
                            Text = "Loooooong Text"
                        }.MaximumWidth(400).MinimumWidth(200).Margin(20, 0),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.DesiredWidth(30),
                    }
                }.LayoutBounds(0.5f, 290, 1, 60).LayoutFlags(AbsoluteLayoutFlags.XProportional| AbsoluteLayoutFlags.WidthProportional),

                new HStack
                {
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView {
                            BackgroundColor = Color.Yellow,
                            Opacity = 0.7f,
                            FontSize = 20,
                            Text = "HStack { HStack { label } }",
                            VerticalAlignment = TextAlignment.Center,
                        },
                        new HStack {
                            BackgroundColor = Color.Green,
                            Opacity = 0.7f,
                            Children =
                            {
                                new TextView {
                                    Name = "Label3",
                                    BackgroundColor = Color.Red,
                                    Opacity = 0.7f,
                                    FontSize = 20,
                                    Text = "Loooooong Text"
                                }
                            }
                        }.MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.DesiredWidth(30),
                    }
                }.LayoutBounds(0.5f, 360, 1, 60).LayoutFlags(AbsoluteLayoutFlags.XProportional| AbsoluteLayoutFlags.WidthProportional),


                new FlexBox
                {
                    JustifyContent = FlexJustify.Start,
                    Direction = FlexDirection.Row,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView { BackgroundColor = Color.Yellow, FontSize = 20, Text = "FlexBox { TextView }", Opacity = 0.7f }.Shrink(0),
                        new TextView { Name = "Label4", Text = "Loooooong Text", FontSize = 20, BackgroundColor = Color.Green, Opacity = 0.7f }.AutoBasis().Shrink(1).Grow(0).MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Grow(1).Shrink(0),
                    }
                }.LayoutBounds(0.5f, 430, 1, 60).LayoutFlags(AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional),

                new FlexBox
                {
                    JustifyContent = FlexJustify.Start,
                    Direction = FlexDirection.Row,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    BorderlineOffset = .5f,
                    Children =
                    {
                        new TextView { BackgroundColor = Color.Yellow, FontSize = 20, Text = "FlexBox { MyButton }", Opacity = 0.7f }.Shrink(0),
                        new MyButton { Name = "Button5", Text = "Loooooong Text", BackgroundColor = Color.Green, Opacity = 0.7f }.AutoBasis().Shrink(1).Grow(0).MaximumWidth(400).MinimumWidth(200),
                        new View { BackgroundColor = Color.Red, Opacity = 0.7f }.Basis(30).Grow(1).Shrink(0),
                    }
                }.LayoutBounds(0.5f, 500, 1, 60).LayoutFlags(AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional),

                new TextView
                {
                    FontSize = 20,
                    Text = "<-- less  |  more -->",
                    BackgroundColor = Color.Green,
                    DesiredHeight = 50,
                    Name = "Touch"
                }.TextCenter().LayoutBounds(0.5f, 1, 1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional).Margin(0, 0, 0, 60),
            }.Row(1).Padding(50));

            pan = new PanGestureDetector();
            pan.Attach(this["Touch"]);
            int currentLength = 5;
            pan.Detected += (s, e) =>
            {
                var diff = e.Gesture.ScreenDisplacement.X;
                currentLength += (int)(diff / 10);
                Console.WriteLine($"Pan : {currentLength}");
                (this["Label1"] as TextView).Text = DummyText(currentLength); 
                (this["Label2"] as MyLabel).Text = DummyText(currentLength);
                (this["Label3"] as TextView).Text = DummyText(currentLength);
                (this["Label4"] as TextView).Text = DummyText(currentLength);
                (this["Button1"] as Button).Text = DummyText(currentLength);
                (this["Button2"] as Button).Text = DummyText(currentLength);
                (this["Button3"] as MyButton).Text = DummyText(currentLength);
                (this["Button4"] as MyButton).Text = DummyText(currentLength);
                (this["Button5"] as MyButton).Text = DummyText(currentLength);
            };

        }

        string DummyText(int length)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Lo");
            for (int i = 0; i < length; i++)
            {
                sb.Append("o");
            }
            sb.AppendLine("ng Text");
            return sb.ToString();
        }

        class MyLabel : ContentView
        {
            public MyLabel()
            {
                Body = new TextView
                {
                    FontSize = 20,
                };

                var tap = new TapGestureDetector();
                tap.Attach(this);
                tap.Detected += (s, e) =>
                {
                    if (Inner.Measure(float.PositiveInfinity, Height).Width > Width)
                    {
                        Inner.StartTextScroll(1);
                    }
                };

                Relayout += (s, e) =>
                {
                    if (Inner.Measure(float.PositiveInfinity, Height).Width <= Width)
                    {
                        if (Inner.IsTextScrolling)
                            Inner.StopTextScroll();
                    }
                };
            }

            TextView Inner => Body as TextView;

            public string Text
            {
                get => Inner.Text;
                set => Inner.Text = value;
            }
        }

        class MyButton : ContentView
        {
            public MyButton()
            {
                Body = new Button("");
            }

            Button Inner => Body as Button;

            public string Text
            {
                get => Inner.Text;
                set => Inner.Text = value;
            }

        }

        class MyGrid : Grid
        {
            float _width;
            public MyGrid()
            {
                Add(new TextView { Name = "TextView", FontSize = 13 }.TextCenter());
                Relayout += OnRelayout;
            }

            void OnRelayout(object sender, EventArgs e)
            {
                if (_width != Width)
                {
                    _width = Width;
                    (this["TextView"] as TextView).Text = $"{Width:.0} [{this.LayoutParam().MinimumWidth}~{this.LayoutParam().MaximumWidth}]";
                }
            }
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
