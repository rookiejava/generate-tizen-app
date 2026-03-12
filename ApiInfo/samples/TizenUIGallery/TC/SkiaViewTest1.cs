using TizenUIGallery.Util;
using SkiaSharp;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Skia;

namespace TizenUIGallery.TC
{
    public class SkiaViewTest1 : Grid, ITestCase
    {
        int startX = 100;
        int startY = 100;
        public SkiaViewTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Auto);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "SkiaView Test1",
                FontSize = 30,
            });

            var canvas = new SKCanvasView
            {
                Focusable = true,
                FocusableInTouch = true,
                DesiredHeight = 300,
                DesiredWidth = 300,
            };
            canvas.PaintSurface += (s, e) =>
            {
                var surface = e.Surface;
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                // configure our brush

                using (var paint = new SKPaint
                {
                    Color = SKColors.Green,
                    StrokeWidth = 2,
                    TextSize = 30,
                })
                {
                    canvas.DrawRect(new SKRect(0, 0, 30, 30), paint);
                    canvas.DrawRect(new SKRect(startX, startY, startX + 100, startY + 100), paint);
                }

            };
            canvas.KeyEvent += (s, e) =>
            {
                if (e.KeyEvent.State == KeyState.Up)
                    return;

                if (e.KeyEvent.KeyPressedName == "Left")
                {
                    startX -= 1;
                    canvas.Invalidate();
                }
                else if (e.KeyEvent.KeyPressedName == "Right")
                {
                    startX += 1;
                    canvas.Invalidate();
                }
                else if (e.KeyEvent.KeyPressedName == "Up")
                {
                    startY -= 1;
                    canvas.Invalidate();
                }
                else if (e.KeyEvent.KeyPressedName == "Down")
                {
                    startY += 1;
                    canvas.Invalidate();
                }
            };
            canvas.Row(1);
            Add(canvas);
            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("+")
                    {
                        DesiredWidth = 50,
                        Clicked = () =>
                        {
                            canvas.DesiredHeight += 10;
                            canvas.DesiredWidth += 10;
                        }
                    },
                    new Button("-")
                    {
                        DesiredWidth = 50,
                        Clicked = () =>
                        {
                            canvas.DesiredHeight -= 10;
                            canvas.DesiredWidth -= 10;
                        }
                    },
                }
            }.Row(2));
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
