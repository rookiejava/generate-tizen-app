using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class TouchEventTest7 : Grid, ITestCase
    {
        public TouchEventTest7()
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
                Text = "TouchEventTest7 (Touch / Interrupted propagation)",
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
                        Text = "Down (Intercept)"
                    }.Row(0).Column(0).Center(),
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Move (Intercept)"
                    }.Row(0).Column(1).Center(),
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Up (Intercept)"
                    }.Row(0).Column(2).Center(),

                    new VStack
                    {
                        new CheckBox("Green Consume")
                        {
                            Name = "Green-Down"
                        }.Center(),
                    }.Row(1).Column(0).Fill().BackgroundColorFromHex("#ffffff").Margin(10),

                    new VStack
                    {
                        new CheckBox("Green Consume")
                        {
                            Name = "Green-Move"
                        }.Center(),
                    }.Row(1).Column(1).Fill().BackgroundColorFromHex("#ffffff").Margin(10),

                    new VStack
                    {
                        new CheckBox("Green Consume")
                        {
                            Name = "Green-Up",
                            IsChecked = true
                        }.Center(),
                    }.Row(1).Column(2).Fill().BackgroundColorFromHex("#ffffff").Margin(10),
                }
            }.Row(3));

            this["Blue"].TouchEvent += (s, e) =>
            {
                AppendLog($"[{e.Touch[0].State}] Blue");
            };

            this["Green"].TouchEvent += (s, e) =>
            {
                AppendLog($"[{e.Touch[0].State}] Green - consume");
                e.Handled = true;
            };

            this["Green"].InterceptTouchEvent += (s, e) =>
            {
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

                AppendLog($"[InterceptTouchEvent - {e.Touch[0].State}] Green - Intercepted : {e.Handled}");
            };

            this["Yellow"].TouchEvent += (s, e) =>
            {
                AppendLog($"[{e.Touch[0].State}] Yellow - consume");
                e.Handled = true;
            };

        }

        int count = 0;

        void AppendLog(string log)
        {
            var vstack = (this["Log"] as VStack);
            count++;
            vstack.Children.Insert(0, new TextView
            {
                FontSize = 15,
                Text = $"[{count:D3}]{log}"
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
