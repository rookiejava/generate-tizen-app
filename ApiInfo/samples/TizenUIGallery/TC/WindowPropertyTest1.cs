using TizenUIGallery.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class WindowPropertyTest1 : Grid, ITestCase
    {
        List<Window> created = new();
        public WindowPropertyTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "WindowPropertyTest1",
                FontSize = 30,
            });
            Add(new VStack
            {
                new TextView
                {
                    Name = "TextView",
                    DesiredHeight = 300,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    IsMultiline = true,
                }.Margin(10),

                new Button("BackgroundColor")
                {
                    Clicked = async () =>
                    {
                        Random rnd = new Random();
                        Window.Default.SetBackgroundColor(Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                        Window.Default.DefaultLayer.IsVisible = false;
                        await Task.Delay(3000);
                        Window.Default.DefaultLayer.IsVisible = true;
                    }
                },

                new Button("Title")
                {
                    Clicked = () =>
                    {
                        (this["TextView"] as TextView).Text = $"Title : {Window.Default.Title}";
                    }
                },

                new Button("GetPosition")
                {
                    Clicked = () =>
                    {
                        (this["TextView"] as TextView).Text = $"Position : {Window.Default.GetPosition()}";
                    }
                },

                new Button("SetPosition : 100 x 100")
                {
                    Clicked = () =>
                    {
                        Window.Default.SetPosition(new Point(100, 100));
                    }
                },

                new Button("Create window")
                {
                    Clicked = async () =>
                    {
                        var win = new Window($"Sub window - {created.Count}", true);
                        win.DefaultLayer.Add(new View
                        {
                            HeightResizePolicy = ResizePolicy.FillToParent,
                            WidthResizePolicy = ResizePolicy.FillToParent,
                            BackgroundColor = Color.Green
                        });
                        win.KeyEvent += (s, e) =>
                        {
                            if (e.KeyEvent.KeyPressedName == "BackSpace" || e.KeyEvent.KeyPressedName == "XF86Back")
                            {
                                win.Lower();
                                e.Handled = true;
                                return;
                            }
                        };
                        win.Show();
                        await Task.Delay(1);
                        win.SetPositionSize(10 + 150 * created.Count, 10 + 150 * created.Count, 100, 100);
                        created.Add(win);
                    }
                },

                new Button("Get Window list")
                {
                    Clicked = () =>
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var win in UIApplication.Windows)
                        {
                            sb.AppendLine($"Window - {win.Title} - {win.GetPosition()} / {win.GetSize()}");
                        }
                        (this["TextView"] as TextView).Text = sb.ToString();
                    }
                },

                new Button("Get Layers")
                {
                    Clicked = () =>
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var layer in Window.Default.Layers)
                        {
                            sb.AppendLine($"Layer - {layer}");
                        }
                        (this["TextView"] as TextView).Text = sb.ToString();
                    }
                },

                new Button("Hide and Show")
                {
                    Clicked = async () =>
                    {
                        Window.Default.Hide();
                        await Task.Delay(3000);
                        Window.Default.Show();
                    }
                },

                new Button("Lower and Raise")
                {
                    Clicked = async () =>
                    {
                        Window.Default.Lower();
                        await Task.Delay(3000);
                        Window.Default.Raise();
                    }
                },

                new Button("Get Last Key Event")
                {
                    Clicked = () =>
                    {
                        var last = Window.Default.GetLastKeyEvent();
                        (this["TextView"] as TextView).Text = $"KeyName : {last.KeyPressedName}, State : {last.State}";
                    }
                },

                new Button("Get Touch Event")
                {
                    Clicked = () =>
                    {
                        var last = Window.Default.GetLastTouchEvent();
                        (this["TextView"] as TextView).Text = $"ScreenPosotion: {last[0].ScreenPosition} , State : {last[0].State}";
                    }
                },

            }.Row(1));

            Window.Default.VisibilityChanged += (s, e) =>
            {
                (this["TextView"] as TextView).Text = $"Visible was updated {Window.Default.IsVisible}";
                Console.WriteLine($"Visible was updated {Window.Default.IsVisible}");
            };
        }

        public void Activate()
        {
            Window.Default.Title = "Default Window";
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();

            foreach (var win in created)
            {
                win.Dispose();
            }
        }
    }
}
