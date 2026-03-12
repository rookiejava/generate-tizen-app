using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class FocusManagerTest1 : Grid, ITestCase
    {
        public FocusManagerTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(50);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "FocusManager Test1",
                FontSize = 30,
            });

            Add(new TextView
            {
                Name = "Log",
                BackgroundColor = Color.Yellow,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                FontSize = 20,
            }.Row(1));

            var box = make100();
            box.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(2);
            Add(box);

            Add(new ScrollLayout
            {
                Content = new FlexBox
                {
                    BackgroundColor = Color.FromHex("#f9fff2"),
                    Wrap = FlexWrap.Wrap,
                    AlignContent = FlexAlignContent.Start,
                    Children =
                    {
                        new Button("Set 1x1")
                        {
                            Clicked = () =>
                            {
                                FocusManager.Instance.SetFocus(this["1x1"]);
                            }
                        }.Margin(10),
                        new Button("Set CustomFocusManager")
                        {
                            Clicked = () =>
                            {
                                FocusManager.Instance.SetCustomFocusAlgorithm(new MyCustomFocus());
                            }
                        }.Margin(10),
                        new Button("Reset FocusManager")
                        {
                            Clicked = () =>
                            {
                                FocusManager.Instance.SetCustomFocusAlgorithm(null);
                                FocusManager.Instance.EnableDefaultFocusAlgorithm(true);
                            }
                        }.Margin(10),
                        new Button("GetNearstFocusedView 55 - Up")
                        {
                            Clicked = () =>
                            {
                                box.Children[55].BackgroundColor = Color.Red;
                                var ret = FocusManager.Instance.GetNearestFocusableViewOverride(box, box.Children[55], FocusDirection.Up);
                                if (ret != null)
                                    ret.BackgroundColor = Color.Blue;
                            }
                        }.Margin(10),
                        new Button("GetNearstFocusedView - Up")
                        {
                            Clicked = () =>
                            {
                                var ret = FocusManager.Instance.GetNearestFocusableViewOverride(box, FocusManager.Instance.GetFocused(), FocusDirection.Up);
                                if (ret != null)
                                    ret.BackgroundColor = Color.Blue;
                            }
                        }.Margin(10),
                        new Button("GetNearstFocusedView - Down")
                        {
                            Clicked = () =>
                            {
                                var ret = FocusManager.Instance.GetNearestFocusableViewOverride(box, FocusManager.Instance.GetFocused(), FocusDirection.Down);
                                if (ret != null)
                                    ret.BackgroundColor = Color.Green;
                            }
                        }.Margin(10),
                        new Button("GetNearstFocusedView - Left")
                        {
                            Clicked = () =>
                            {
                                var ret = FocusManager.Instance.GetNearestFocusableViewOverride(box, FocusManager.Instance.GetFocused(), FocusDirection.Left);
                                if (ret != null)
                                    ret.BackgroundColor = Color.Yellow;
                            }
                        }.Margin(10),
                        new Button("GetNearstFocusedView - Right")
                        {
                            Clicked = () =>
                            {
                                var ret = FocusManager.Instance.GetNearestFocusableViewOverride(box, FocusManager.Instance.GetFocused(), FocusDirection.Right);
                                if (ret != null)
                                    ret.BackgroundColor = Color.Red;
                            }
                        }.Margin(10),
                    },
                }
            }.Row(3));

            FocusManager.Instance.FocusChanged += OnFocused;
        }

        void OnFocused(object sender, FocusChangedEventArgs e)
        {
            Console.WriteLine($"FocusChanged Prev :{e.PreviousFocusedView?.Name ?? "null"}, Focused :{e.FocusedView?.Name ?? "null"}");
            (this["Log"] as TextView).Text = $"FocusChanged Prev :{e.PreviousFocusedView?.Name ?? "null"}, Focused :{e.FocusedView?.Name ?? "null"}";
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            FocusManager.Instance.FocusChanged -= OnFocused;
            Dispose();
        }

        ViewGroup make100()
        {
            var layout = new ViewGroup
            {
                DesiredWidth = 400,
                DesiredHeight = 400,
            };

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var box = makeSmallBox(x, y, 40);
                    layout.Add(box);
                }
            }

            return layout;
        }
        
        View makeSmallBox(int x, int y, int sizeUnit)
        {
            Random rnd = new Random();
            var box = new View
            {
                Name = $"{x}x{y}",
                Focusable = true,
                FocusableInTouch = true,
                Width = sizeUnit,
                Height = sizeUnit,
                X = x * sizeUnit,
                Y = y * sizeUnit,
                BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3f), (float)(rnd.NextDouble() * 0.7 + 0.3f), (float)(rnd.NextDouble() * 0.7 + 0.3f), 1f),
            };
            return box;
        }

        class MyCustomFocus : IFocusAlgorithm
        {
            public View GetNextFocusableView(View current, View proposed, FocusDirection direction, string deviceName)
            {
                Console.WriteLine($"MyCustomFocus::GetNextFocusableView - current : {current?.Name ?? "null"} - proposed : {proposed?.Name ?? "null"} - direction : {direction} - deviceName : {deviceName}");
                return FocusManager.Instance.GetNearestFocusableView(current?.Parent, current, direction);
            }
        }

    }
}
