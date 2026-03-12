using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class TouchEventTest6 : Grid, ITestCase
    {
        public TouchEventTest6()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(150);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Star);


            var tap = new TapGestureDetector();
            tap.Detected += (s, e) =>
            {
                AppendLog($"[Tap] {e.View.Name}");
            };

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "TouchEventTest6 (Touch/Gesture consume)",
                FontSize = 30,
            });
            Add(new ScrollLayout
            {
                Padding = 20,
                BackgroundColor = Color.AntiqueWhite,
                Content = new VStack
                {
                    Name = "Log",
                }
            }.Row(1));
            Add(new AbsoluteLayout
            {
                new AbsoluteLayout
                {
                    Name = "Blue",
                    BackgroundColor = Color.Blue,
                    Children =
                    {
                        new AbsoluteLayout
                        {
                            Name = "Green",
                            BackgroundColor = Color.Green,
                            Children =
                            {
                                new AbsoluteLayout
                                {
                                    Name = "Yellow",
                                    BackgroundColor = Color.Yellow
                                }.Margin(50).LayoutBounds(0.5f, 0.5f, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All)
                            }
                        }.Margin(50).LayoutBounds(0.5f, 0.5f, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All)
                    }
                }.Margin(50).LayoutBounds(0.5f, 0.5f, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All)

            }.Row(2));
            Add(new Grid
            {
                ColumnDefinitions =
                {
                    GridLength.Star,
                    GridLength.Star,
                    GridLength.Star,
                    GridLength.Star,
                },
                RowDefinitions =
                {
                    50,
                    GridLength.Star,
                },
                Children =
                {
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Down (Touch)"
                    }.Row(0).Column(0).Center(),
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Move (Touch)"
                    }.Row(0).Column(1).Center(),
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Up (Touch)"
                    }.Row(0).Column(2).Center(),
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Set Tap Gesture"
                    }.Row(0).Column(3).Center(),

                    new VStack
                    {
                        new CheckBox("Blue Consume")
                        {
                            Name = "Blue-Down"
                        }.Center(),
                        new CheckBox("Green Consume")
                        {
                            Name = "Green-Down"
                        }.Center(),
                        new CheckBox("Yellow Consume")
                        {
                            Name = "Yellow-Down"
                        }.Center(),
                    }.Row(1).Column(0).Fill().BackgroundColorFromHex("#ffffff").Margin(10),

                    new VStack
                    {
                        new CheckBox("Blue Consume")
                        {
                            Name = "Blue-Move"
                        }.Center(),
                        new CheckBox("Green Consume")
                        {
                            Name = "Green-Move"
                        }.Center(),
                        new CheckBox("Yellow Consume")
                        {
                            Name = "Yellow-Move"
                        }.Center(),
                    }.Row(1).Column(1).Fill().BackgroundColorFromHex("#ffffff").Margin(10),

                    new VStack
                    {
                        new CheckBox("Blue Consume")
                        {
                            Name = "Blue-Up"
                        }.Center(),
                        new CheckBox("Green Consume")
                        {
                            Name = "Green-Up"
                        }.Center(),
                        new CheckBox("Yellow Consume")
                        {
                            Name = "Yellow-Up"
                        }.Center(),
                    }.Row(1).Column(2).Fill().BackgroundColorFromHex("#ffffff").Margin(10),

                    new VStack
                    {
                        new CheckBox("Blue Tap")
                        {
                            Name = "Blue-Tap",
                            Toggled = () =>
                            {
                                if ((this["Blue-Tap"] as CheckBox).IsChecked)
                                    tap.Attach(this["Blue"]);
                                else
                                    tap.Detach(this["Blue"]);
                            }
                        }.Center(),
                        new CheckBox("Green Tap")
                        {
                            Name = "Green-Tap",
                            Toggled = () =>
                            {
                                if ((this["Green-Tap"] as CheckBox).IsChecked)
                                    tap.Attach(this["Green"]);
                                else
                                    tap.Detach(this["Green"]);
                            }
                        }.Center(),
                        new CheckBox("Yellow Tap")
                        {
                            Name = "Yellow-Tap",
                            Toggled = () =>
                            {
                                if ((this["Yellow-Tap"] as CheckBox).IsChecked)
                                    tap.Attach(this["Yellow"]);
                                else
                                    tap.Detach(this["Yellow"]);
                            }
                        }.Center(),
                    }.Row(1).Column(3).Fill().BackgroundColorFromHex("#ffffff").Margin(10),
                }

            }.Row(3));
            this["Blue"].TouchEvent += (s, e) =>
            {
                AppendLog($"[{e.Touch[0].State}] Blue");
                if (e.Touch[0].State == TouchState.Down)
                {
                    e.Handled = (this["Blue-Down"] as CheckBox).IsChecked;
                }
                else if (e.Touch[0].State == TouchState.Motion)
                {
                    e.Handled = (this["Blue-Move"] as CheckBox).IsChecked;
                }
                else if (e.Touch[0].State == TouchState.Up)
                {
                    e.Handled = (this["Blue-Up"] as CheckBox).IsChecked;
                }
            };

            this["Green"].TouchEvent += (s, e) =>
            {
                AppendLog($"[{e.Touch[0].State}] Green");
                if (e.Touch[0].State == TouchState.Down)
                {
                    e.Handled = (this["Green-Down"] as CheckBox).IsChecked;
                }
                else if (e.Touch[0].State == TouchState.Motion)
                {
                    e.Handled = (this["Green-Move"] as CheckBox).IsChecked;
                }
                else if (e.Touch[0].State == TouchState.Up)
                {
                    e.Handled = (this["Green-Up"] as CheckBox).IsChecked;
                }
            };

            this["Yellow"].TouchEvent += (s, e) =>
            {
                AppendLog($"[{e.Touch[0].State}] Yellow");
                if (e.Touch[0].State == TouchState.Down)
                {
                    e.Handled = (this["Yellow-Down"] as CheckBox).IsChecked;
                }
                else if (e.Touch[0].State == TouchState.Motion)
                {
                    e.Handled = (this["Yellow-Move"] as CheckBox).IsChecked;
                }
                else if (e.Touch[0].State == TouchState.Up)
                {
                    e.Handled = (this["Yellow-Up"] as CheckBox).IsChecked;
                }
            };

        }

        void AppendLog(string log)
        {
            var vstack = (this["Log"] as VStack);

            vstack.Children.Insert(0, new TextView
            {
                FontSize = 15,
                Text = log
            });

            if (vstack.Children.Count > 80)
            {
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
                vstack.Children.RemoveAt(vstack.Children.Count - 1);
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
