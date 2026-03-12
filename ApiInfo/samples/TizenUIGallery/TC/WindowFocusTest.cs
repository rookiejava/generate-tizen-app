using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class WindowFocusTest : Grid, ITestCase
    {
        Window win;
        public WindowFocusTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            win = new Window
            {
                Title = "Focus Skipped Window"
            };
            win.Maximize(false);
            win.SetPosition(new Point(Window.Default.GetClientSize().Width/2, 100));
            win.SetSize(500, 200);
            win.DefaultLayer.Add(new AbsoluteLayout
            {
                Children = {
                    new TextView {
                        Name = "Text",
                        Text = "Focus Skipped window",
                        FontSize = 30,
                        TextColor = Color.Black,
                    }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                }
            });
            win.FocusChanged += (s, e) =>
            {
                win.SetBackgroundColor(e.HasFocus ? Color.LightGreen : Color.DarkGray);
                (this["TextView"] as TextView).Text = $"Focus changed - {e.HasFocus}";
                Console.WriteLine($"Focus changed - {e.HasFocus}");
            };
           win.TouchEvent += async (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    await win.StartMoveRequest();
                    e.Handled = true;
                }
            };

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "WindowFocusTest",
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

                new Button("Set focus skip - True")
                {
                    Clicked = () =>
                    {
                        (this["TextView"] as TextView).Text = $"win.SetFocusSkip(true)";
                        win.SetFocusSkip(true);
                    }
                },

                new Button("Set focus skip - False")
                {
                    Clicked = () =>
                    {
                        (this["TextView"] as TextView).Text = $"win.SetFocusSkip(false)";
                        win.SetFocusSkip(false);
                    }
                },

                new Button("Window Type - Normal")
                {
                    Clicked = () =>
                    {
                        win.WindowType = WindowType.Normal;
                        (this["TextView"] as TextView).Text = $"WindowType : {win.WindowType}";
                    }
                },

                new Button("Window Type - Notification")
                {
                    Clicked = () =>
                    {
                        win.WindowType = WindowType.Notification;
                        (this["TextView"] as TextView).Text = $"WindowType : {win.WindowType}";
                    }
                },

                new Button("Window Type - Utility")
                {
                    Clicked = () =>
                    {
                        win.WindowType = WindowType.Utility;
                        (this["TextView"] as TextView).Text = $"WindowType : {win.WindowType}";
                    }
                },

                new Button("Window Type - Ime")
                {
                    Clicked = () =>
                    {
                        win.WindowType = WindowType.Ime;
                        (this["TextView"] as TextView).Text = $"WindowType : {win.WindowType}";
                    }
                },

                new Button("Window Type - Desktop")
                {
                    Clicked = () =>
                    {
                        win.WindowType = WindowType.Desktop;
                        (this["TextView"] as TextView).Text = $"WindowType : {win.WindowType}";
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
            win?.Dispose();
            Dispose();
        }
    }
}
