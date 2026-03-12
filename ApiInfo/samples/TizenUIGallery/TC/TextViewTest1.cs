using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class TextViewTest1 : Grid, ITestCase
    {
        public TextViewTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            int speed = 80;

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "TextView Test1",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Spacing = 4,
                    Children =
                    {
                        new TextView
                        {
                            Name = "Text1",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "Text Shadow",
                            TextColor = Color.White,
                            FontSize = 60,
                        },
                        new TextView
                        {
                            Name = "Text2",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            WidthResizePolicy = ResizePolicy.FillToParent,
                            Text = "Underline",
                            FontSize = 100,
                            TextColor = Color.White,
                        },
                        new TextView
                        {
                            Name = "Text3",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            WidthResizePolicy = ResizePolicy.FillToParent,
                            Text = "Outline",
                            FontSize = 100,
                            TextColor = Color.White,
                        },
                        new Button("Clear")
                        {
                            Clicked = () =>
                            {
                                (this["Text1"] as TextView).ClearTextShadow();
                                (this["Text2"] as TextView).ClearUnderline();
                                (this["Text3"] as TextView).ClearOutline();
                            }
                        },
                        new TextView
                        {
                            Name = "Text4",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "AutoScroll text ... Text... aaaaa long..",
                            FontSize = 100,
                            TextColor = Color.White,
                        },
                        new HStack
                        {
                            Spacing = 5,
                            Children =
                            {
                                new Button("Faster")
                                {
                                    DesiredWidth = 100,
                                    Clicked = () =>
                                    {
                                        speed += 10;
                                        (this["Text4"] as TextView).StopTextScroll();
                                        (this["Text4"] as TextView).StartTextScroll(speed: speed);
                                    }
                                },
                                new Button("Slow")
                                {
                                    DesiredWidth = 100,
                                    Clicked = () =>
                                    {
                                        speed -= 10;
                                        (this["Text4"] as TextView).StopTextScroll();
                                        (this["Text4"] as TextView).StartTextScroll(speed: speed);
                                    }
                                },
                            }
                        },
                        new TextView
                        {
                            Name = "Text5",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "LineBreak mode sdfsldfjk asldkfjaslkfdj asdlfkjasl df asldkfj aslfjkd sdfllskajflj",
                            LineBreakMode = LineBreakMode.Word,
                            IsMultiline = true,
                            TextOverflow = TextOverflow.Clip,
                            FontSize = 30,
                            TextColor = Color.Black,
                        },
                        new TextView
                        {
                            Name = "Text6",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "Loooooooong text abcde",
                            TextOverflow = TextOverflow.Clip,
                            FontSize = 30,
                            TextColor = Color.Black,
                            DesiredHeight = 100,
                            DesiredWidth = 100,
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                        new HStack
                        {
                            Spacing = 5,
                            Children =
                            {
                                new Button("+")
                                {
                                    DesiredWidth = 100,
                                    Clicked = () =>
                                    {
                                        (this["Text6"] as TextView).DesiredWidth += 10;
                                    }
                                },
                                new Button("-")
                                {
                                    DesiredWidth = 100,
                                    Clicked = () =>
                                    {
                                        (this["Text6"] as TextView).DesiredWidth -= 10;
                                    }
                                },
                            }
                        },
                        new HStack
                        {
                            Spacing = 5,
                            Children =
                            {
                                new TextView
                                {
                                    FontSize = 30,
                                    Text = "<a href='www.tizen.org'>Click TextView Anchor</a>",
                                    IsMarkupEnabled = true,
                                    BackgroundColor = Color.BlueViolet
                                }.Self(view => view.AnchorClicked += (s, e) =>
                                {
                                     (this["AnchorLabel"] as TextView).Text = e.Href;
                                }),
                                new TextView
                                {
                                    FontSize = 30,
                                    Name = "AnchorLabel",
                                    BackgroundColor = Color.Yellow
                                },
                            }
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                        new TextView
                        {
                            Name = "Text7",
                            BackgroundColor = Color.Yellow,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "TextOverflow.EndEllipsis sdfsldfjk asldkfjaslkfdj asdlfkjasl df asldkfj aslfjkd sdfllskajflj",
                            TextOverflow = TextOverflow.EndEllipsis,
                            FontSize = 30,
                            TextColor = Color.Black,
                            DesiredWidth = 500,
                        },
                        new TextView
                        {
                            Name = "Text8",
                            BackgroundColor = Color.Yellow,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "sdfsldfjk asldkfjaslkfdj asdlfkjasl df asldkfj aslfjkd sdfllskajflj TextOverflow.StartEllipsis",
                            TextOverflow = TextOverflow.StartEllipsis,
                            FontSize = 30,
                            TextColor = Color.Black,
                            DesiredWidth = 500,
                        },
                        new TextView
                        {
                            Name = "Text9",
                            BackgroundColor = Color.Yellow,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "TextOverflow.MiddleEllipsis sdfsldfjk asldkfjaslkfdj asdlfkjasl df asldkfj aslfjkd sdfllskajflj",
                            TextOverflow = TextOverflow.MiddleEllipsis,
                            FontSize = 30,
                            TextColor = Color.Black,
                            DesiredWidth = 500,
                        },
                        new TextView
                        {
                            Name = "Text10",
                            BackgroundColor = Color.Yellow,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "TextOverflow.Marquee sdfsldfjk asldkfjaslkfdj asdlfkjasl df asldkfj aslfjkd sdfllskajflj",
                            TextOverflow = TextOverflow.Marquee,
                            FontSize = 30,
                            TextColor = Color.Black,
                            DesiredWidth = 500,
                        }.Self(view => view.SetMarqueeConfig()),
                        new TextView
                        {
                            Name = "Text11",
                            BackgroundColor = Color.Yellow,
                            VerticalAlignment = TextAlignment.Center,
                            Text = "TextOverflow.Clip sdfsldfjk asldkfjaslkfdj asdlfkjasl df asldkfj aslfjkd sdfllskajflj",
                            TextOverflow = TextOverflow.Clip,
                            FontSize = 30,
                            TextColor = Color.Black,
                            DesiredWidth = 500,
                        }
                    }
                }
            }.Row(1));
            
            (this["Text1"] as TextView).SetTextShadow(new TextShadow
            {
                Color = Color.Red, 
                Offset = new Point(1, 1),
                BlurRadius = 1f
            });
            (this["Text2"] as TextView).SetUnderline(new Underline
            {
                Color = Color.Red,
                Style = UnderlineStyle.Dashed,
                Thickness = 5,
                DashGap = 5,
                DashWidth = 5
            });
            (this["Text3"] as TextView).SetOutline(new Outline
            {
                Color = Color.Red,
                Width = 1
            });
            (this["Text4"] as TextView).StartTextScroll(loopCount:0, speed: speed);

            var tap3 = new TapGestureDetector();
            tap3.Attach(this["Text4"]);
            tap3.Detected += (s, e) =>
            {
                if ((this["Text4"] as TextView).IsTextScrolling)
                    (this["Text4"] as TextView).StopTextScroll();
                else
                    (this["Text4"] as TextView).StartTextScroll(speed: speed);
                
            };

            (this["Text6"] as TextView).SetAutoSize(new AutoFontSize
            {
                Enabled = true,
                MinimumSize = 1,
                MaximumSize = 100,
                StepSize = 1
            });
            (this["Text6"] as TextView).FontSizeAdjusted += (s, e) =>
            {
                Console.WriteLine($"FontSize changed :{(this["Text6"] as TextView).AutoAdjustedFontSize}");
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
