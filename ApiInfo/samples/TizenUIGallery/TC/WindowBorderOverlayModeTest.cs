using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.WindowBorder;

namespace TizenUIGallery.TC
{
    public class WindowBorderOverlayModeTest : Grid, ITestCase
    {
        BorderView _borderView;
        public WindowBorderOverlayModeTest()
        {
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
                Text = "WindowBorderOverlayMode Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new Button("SetBorder with overlay border mode")
                {
                    Clicked = () =>
                    {
                        var border = _borderView = new BorderView
                        {
                            EnableOverlayBorder = true,
                        };
                        Window.Default.SetBorderView(border);
                    }
                },
                new Button("Maximize(false)")
                {
                    Clicked = () =>
                    {
                        Window.Default.Maximize(false);
                    }
                },
                new Button("Maximize(true)")
                {
                    Clicked = () =>
                    {
                        Window.Default.Maximize(true);
                    }
                },
                new Button("Show OverLayBorder")
                {
                    Clicked = () =>
                    {
                        _borderView?.ShowOverlayBorder();
                    }
                },
                new Button("Show OverLayBorder timeout (3 sec)")
                {
                    Clicked = async () =>
                    {
                        _borderView?.ShowOverlayBorder();
                        await Task.Delay(3000);
                        _borderView?.HideOverlayBorder();
                    }
                },
                new Button("Hide OverLayBorder")
                {
                    Clicked = () =>
                    {
                        _borderView?.HideOverlayBorder();
                    }
                },
            }.Row(1).Margin(10, 10, 10, 10).Spacing(10));

            ClippingMode = ClippingMode.ClipChildren;
            CornerRadius = new CornerRadius(0.03f);

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
