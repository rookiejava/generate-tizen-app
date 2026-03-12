using TizenUIGallery.Util;
using SkiaSharp;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Skia;

namespace TizenUIGallery.TC
{
    public class SkiaViewTest3 : Grid, ITestCase
    {
        public SkiaViewTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(300);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(300);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "SkiaView Test3",
                FontSize = 30,
            }.ColumnSpan(3));

            Add(new ImageView
            {
                Name = "Img",
                ResourceUrl = "image2.jpg"
            }.Row(1).Column(1));

            var canvas = new SKCanvasView
            {
                Focusable = true,
                FocusableInTouch = true,
            };
            canvas.PaintSurface += (s, e) =>
            {
                var surface = e.Surface;
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                // configure our brush
                using var paint = new SKPaint
                {
                    IsAntialias = true,
                };
                using var paint1 = new SKPaint
                {
                    IsAntialias = true,
                    Color = new SKColor(0, 0, 0, 0),
                    BlendMode = SKBlendMode.Src,
                };
                canvas.DrawCircle(new SKPoint(e.Info.Rect.MidX, e.Info.Rect.MidY), e.Info.Rect.Width / 2.1f, paint1);
                paint.Shader = SKShader.CreateRadialGradient(
                            new SKPoint(e.Info.Rect.MidX, e.Info.Rect.MidY),
                            e.Info.Rect.Width / 2f,
                            new SKColor[] { new SKColor(0, 0, 0, 0), new SKColor(0, 0, 0, 0), SKColors.White },
                            null, SKShaderTileMode.Clamp);
                canvas.DrawCircle(new SKPoint(e.Info.Rect.MidX, e.Info.Rect.MidY), e.Info.Rect.Width / 2f, paint);

            };
            canvas.Row(1).Column(1); ;
            Add(canvas);
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
