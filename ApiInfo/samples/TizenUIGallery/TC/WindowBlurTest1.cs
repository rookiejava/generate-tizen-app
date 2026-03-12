using TizenUIGallery.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.WindowBorder;

namespace TizenUIGallery.TC
{
    public class WindowBlurTest1 : Grid, ITestCase
    {
        public WindowBlurTest1()
        {
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
                Text = "Window Blur Test",
                FontSize = 30,
            });
            Add(new VStack
            {
                new Button("Blur - Background")
                {
                    Clicked = async () =>
                    {
                        var win = new Window($"Sub window", true);
                        win.SetPositionSize(100, 100, 300, 300);
                        win.SetTransparency(true);
                        win.SetBackgroundColor(Color.Transparent);
                        win.DefaultLayer.Add(new ImageView
                        {
                            HeightResizePolicy = ResizePolicy.FillToParent,
                            WidthResizePolicy = ResizePolicy.FillToParent,
                            ResourceUrl = "dotnet_bot.png",
                        });
                        win.Show();
                        win.SetBlur(new WindowBlur
                        {
                            BlurType = WindowBlurType.Background,
                            BlurRadius = 60,
                            BackgroundCornerRadius = 50,
                        });
                        await Task.Delay(10000);
                        win.Dispose();
                    }
                },

                new Button("Blur - Behind")
                {
                    Clicked = async () =>
                    {
                        var win = new Window($"Sub window", true);
                        win.SetPositionSize(100, 100, 300, 300);
                        win.SetBackgroundColor(Color.Green);
                        win.DefaultLayer.Add(new View
                        {
                            HeightResizePolicy = ResizePolicy.FillToParent,
                            WidthResizePolicy = ResizePolicy.FillToParent,
                            BackgroundColor = Color.Blue
                        });
                        win.Show();
                        win.SetBorderView(new BorderView());
                        win.SetBlur(new WindowBlur
                        {
                            BlurType = WindowBlurType.Behind,
                            BlurRadius = 60,
                        });
                        await Task.Delay(10000);
                        win.Dispose();
                    }
                },

            }.Row(1).Spacing(10));
        }

        public void Activate()
        {
            Window.Default.Title = "Default Window";
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}
