using LayoutTest.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class UpdateLayoutTest6 : Grid, ITestCase
    {
        List<double> _history = new();

        public UpdateLayoutTest6()
        {
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            RowDefinitions.Add(100);
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "UpdateLayout Test6",
                FontSize = 30,
            });
            Add(new HStack
            {
                new Button("Expand")
                {
                    Clicked = () =>
                    {
                        UIApplication.Current.PostToUI(() =>
                        {
                            var stopwatch = Stopwatch.StartNew();
                            (this["Target"] as TextView).FontSize += 20;
                            UIApplication.Current.PostToUI(() =>
                            {
                                 Console.WriteLine($"Elapsed ms : {stopwatch.ElapsedMilliseconds}");
                                _history.Add(stopwatch.ElapsedMilliseconds);
                                if (_history.Count % 10 == 0)
                                {
                                    var total = _history.TakeLast(10).Sum();
                                    Console.WriteLine($" Avg(last 10) : {total/10d}");
                                    _history.Clear();
                                }
                            });
                        });
                    }
                },
                new Button("Less")
                {
                    Clicked = () =>
                    {
                        UIApplication.Current.PostToUI(() =>
                        {
                            var stopwatch = Stopwatch.StartNew();
                            (this["Target"] as TextView).FontSize -= 20;
                            UIApplication.Current.PostToUI(() =>
                            {
                                 Console.WriteLine($"Elapsed ms : {stopwatch.ElapsedMilliseconds}");
                                _history.Add(stopwatch.ElapsedMilliseconds);
                                if (_history.Count % 10 == 0)
                                {
                                    var total = _history.TakeLast(10).Sum();
                                    Console.WriteLine($" Avg(last 10) : {total/10d}");
                                    _history.Clear();
                                }
                            });
                        });
                    }
                },
                new Button("Expand2")
                {
                    Clicked = () =>
                    {
                        UIApplication.Current.PostToUI(() =>
                        {
                            var stopwatch = Stopwatch.StartNew();
                            (this["Target2"] as TextView).FontSize += 20;
                            UIApplication.Current.PostToUI(() =>
                            {
                                 Console.WriteLine($"Elapsed ms : {stopwatch.ElapsedMilliseconds}");
                                _history.Add(stopwatch.ElapsedMilliseconds);
                                if (_history.Count % 10 == 0)
                                {
                                    var total = _history.TakeLast(10).Sum();
                                    Console.WriteLine($" Avg(last 10) : {total/10d}");
                                    _history.Clear();
                                }
                            });
                        });
                    }
                },
                new Button("Less2")
                {
                    Clicked = () =>
                    {
                        UIApplication.Current.PostToUI(() =>
                        {
                            var stopwatch = Stopwatch.StartNew();
                            (this["Target2"] as TextView).FontSize -= 20;
                            UIApplication.Current.PostToUI(() =>
                            {
                                 Console.WriteLine($"Elapsed ms : {stopwatch.ElapsedMilliseconds}");
                                _history.Add(stopwatch.ElapsedMilliseconds);
                                if (_history.Count % 10 == 0)
                                {
                                    var total = _history.TakeLast(10).Sum();
                                    Console.WriteLine($" Avg(last 10) : {total/10d}");
                                    _history.Clear();
                                }
                            });
                        });
                    }
                },
                new Button("Expand3")
                {
                    Clicked = () =>
                    {
                        UIApplication.Current.PostToUI(() =>
                        {
                            var stopwatch = Stopwatch.StartNew();
                            (this["Target3"] as TextView).FontSize += 20;
                            UIApplication.Current.PostToUI(() =>
                            {
                                 Console.WriteLine($"Elapsed ms : {stopwatch.ElapsedMilliseconds}");
                                _history.Add(stopwatch.ElapsedMilliseconds);
                                if (_history.Count % 10 == 0)
                                {
                                    var total = _history.TakeLast(10).Sum();
                                    Console.WriteLine($" Avg(last 10) : {total/10d}");
                                    _history.Clear();
                                }
                            });
                        });
                    }
                },
                new Button("Less3")
                {
                    Clicked = () =>
                    {
                        UIApplication.Current.PostToUI(() =>
                        {
                            var stopwatch = Stopwatch.StartNew();
                            (this["Target3"] as TextView).FontSize -= 20;
                            UIApplication.Current.PostToUI(() =>
                            {
                                 Console.WriteLine($"Elapsed ms : {stopwatch.ElapsedMilliseconds}");
                                _history.Add(stopwatch.ElapsedMilliseconds);
                                if (_history.Count % 10 == 0)
                                {
                                    var total = _history.TakeLast(10).Sum();
                                    Console.WriteLine($" Avg(last 10) : {total/10d}");
                                    _history.Clear();
                                }
                            });
                        });
                    }
                },
            }.Row(1).Spacing(10));
            Add(new HStack
            {
                new VStack
                {
                    new HStack
                    {
                        new TextView
                        {
                            Text = "1",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                        new TextView
                        {
                            Text = "2",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                        new TextView
                        {
                            Text = "3",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                    }.BackgroundColor(Color.Orange).Spacing(10),

                    new HStack
                    {
                        new TextView
                        {
                            Text = "4",
                            FontSize = 30,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                        new TextView
                        {
                            Name = "Target",
                            Text = "5",
                            FontSize = 30,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                        new TextView
                        {
                            Text = "6",
                            FontSize = 30,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                    }.BackgroundColor(Color.Green).Spacing(10),

                    new HStack
                    {
                        new TextView
                        {
                            Text = "7",
                            FontSize = 20,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                        new TextView
                        {
                            Text = "8",
                            FontSize = 20,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                        new TextView
                        {
                            Text = "9",
                            FontSize = 20,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).TextCenter(),
                    }.BackgroundColor(Color.AliceBlue).Spacing(10),

                }.Spacing(10).BackgroundColor(Color.LightBlue).VerticalLayoutAlignment(LayoutAlignment.Center),

                new Grid
                {
                    RowDefinitions = { GridLength.Auto, GridLength.Auto, GridLength.Auto },
                    ColumnDefinitions = { GridLength.Auto, GridLength.Auto, GridLength.Auto },
                    RowSpacing = 10,
                    ColumnSpacing = 10,
                    Children =
                    {
                        new TextView
                        {
                            Text = "1",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(0).Column(0).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "2",
                            FontSize = 10,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(0).Column(1).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "3",
                            FontSize = 20,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(0).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Name = "Target2",
                            Text = "4",
                            FontSize = 30,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(1).Column(0).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "5",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(1).Column(1).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "6",
                            FontSize = 40,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(1).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "7",
                            FontSize = 33,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(0).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "8",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(1).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "9",
                            FontSize = 10,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                    }
                }.BackgroundColor(Color.LightCyan).VerticalLayoutAlignment(LayoutAlignment.Center),

                new FlexBox
                {
                    Direction = FlexDirection.Row,
                    Wrap = FlexWrap.Wrap,
                    Children =
                    {
                        new TextView
                        {
                            Text = "1",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "2",
                            FontSize = 20,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Name = "Target3",
                            Text = "3",
                            TextOverflow = TextOverflow.Clip,
                            FontSize = 40,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "4",
                            FontSize = 60,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "5",
                            FontSize = 20,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "6",
                            FontSize = 60,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "7",
                            FontSize = 40,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "8",
                            FontSize = 40,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),
                        new TextView
                        {
                            Text = "9",
                            FontSize = 50,
                            BorderlineWidth = 1,
                            BorderlineColor = Color.Black,
                        }.Margin(10).Row(2).Column(2).BackgroundColor(RandomColor()).TextCenter(),

                    }
                }.MaximumWidth(300).VerticalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.LightBlue)

            }.Row(2).Spacing(100).Padding(10));
        }

        Color RandomColor()
        {
            var rnd = new Random();
            return new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble());
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
