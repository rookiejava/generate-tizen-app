using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class WindowPropertyTest2 : Grid, ITestCase
    {
        public WindowPropertyTest2()
        {
            Window.Default.SetBackgroundColor(Color.White);
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Relayout += (s, e) =>
            {
                Console.WriteLine($"OnRelayout : {this.Size()}");
            };

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "WindowPropertyTest2",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new Button("Resize").LayoutBounds(0, 0, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("TopLeft"),
                new Button("Resize").LayoutBounds(0.5f, 0, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("Top"),
                new Button("Resize").LayoutBounds(0.5f, 1, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("Bottom"),
                new Button("Resize").LayoutBounds(1, 0, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("TopRight"),
                new Button("Resize").LayoutBounds(0, 0.5f, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("Left"),
                new Button("Resize").LayoutBounds(1, 0.5f, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("Right"),
                new Button("Resize").LayoutBounds(0, 1, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("BottomLeft"),
                new Button("Resize").LayoutBounds(1, 1, 100, 100).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Name("BottomRight"),

                new VStack
                {
                    Children =
                    {
                        new Button("Move bar")
                        {
                            Name = "MoveBar"
                        },
                        new TextView()
                        {
                            FontSize = 20,
                            Name = "IsMaximized",
                            IsMultiline = true,
                            Text = $"IsMaximized : {Window.Default.IsMaximized}",
                        },
                        new TextView()
                        {
                            FontSize = 20,
                            Name = "Log",
                            IsMultiline = true,
                            Text = $"State",
                        },
                        new Button("Maximize(true)")
                        {
                            Clicked = () =>
                            {
                                Window.Default.Maximize(true);
                            }
                        },
                        new Button("Maximize(false)")
                        {
                            Clicked = () =>
                            {
                                Window.Default.Maximize(false);
                            }
                        },
                        new Button("ResizePolicy - FreeFrom")
                        {
                            Clicked = () =>
                            {
                                Window.Default.SetWindowResizePolicy(WindowResizePolicy.FreeForm);
                            }
                        },
                        new Button("ResizePolicy - KeepRatio")
                        {
                            Clicked = () =>
                            {
                                Window.Default.SetWindowResizePolicy(WindowResizePolicy.KeepRatio);
                            }
                        },
                        new Button("ResizePolicy - Fixed")
                        {
                            Clicked = () =>
                            {
                                Window.Default.SetWindowResizePolicy(WindowResizePolicy.Fixed);
                            }
                        },
                        new Button("SetBorderArea (20)")
                        {
                            Clicked = () =>
                            {
                                Window.Default.BorderArea = new Thickness(20);
                            }
                        },
                        new Button("SetBorderArea (0)")
                        {
                            Clicked = () =>
                            {
                                Window.Default.BorderArea = new Thickness(0);
                            }
                        },
                        new Button("Add new Layer")
                        {
                            Clicked = async () =>
                            {
                                var layer = new Layer();
                                layer.Add(new View
                                {
                                    BackgroundColor = new Color(1, 0, 0, 0.2f),
                                    HeightResizePolicy = ResizePolicy.FillToParent,
                                    WidthResizePolicy = ResizePolicy.FillToParent,
                                });
                                Window.Default.Add(layer);
                                await Task.Delay(10000);
                                Window.Default.Remove(layer);
                                layer.Dispose();
                            }
                        },
                    }
                }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
            }.Row(1).Margin(10, 10, 10, 10));


            this["TopLeft"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {

                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.TopLeft);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };
            this["TopRight"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.TopRight);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };
            this["BottomLeft"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.BottomLeft);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };
            this["BottomRight"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.BottomRight);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };
            this["Left"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.Left);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };
            this["Right"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.Right);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };
            this["Top"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.Top);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };
            this["Bottom"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Resize Start";
                    await Window.Default.StartResizeRequest(WindowResizeDirection.Bottom);
                    (this["Log"] as TextView).Text = $"Resize Completed : {Window.Default.GetSize()}";
                    e.Handled = true;
                }
            };

            this["MoveBar"].TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    (this["Log"] as TextView).Text = $"Move Start";
                    await Window.Default.StartMoveRequest();
                    (this["Log"] as TextView).Text = $"Move Completed : {Window.Default.GetPosition()}";
                    e.Handled = true;
                }
            };

            Window.Default.Resized += OnResized;
        }

        private void OnResized(object sender, System.EventArgs e)
        {
            (this["IsMaximized"] as TextView).Text = $"IsMaximized : {Window.Default.IsMaximized}";
        }

        public void Activate()
        {
            Window.Default.Title = "Default Window";
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Window.Default.Resized -= OnResized;
            Dispose();
        }
    }
}
