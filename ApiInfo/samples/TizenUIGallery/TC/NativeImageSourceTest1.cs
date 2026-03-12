using SkiaSharp;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using TizenUIGallery.Util;
using Tizen.UI.Internal;

namespace TizenUIGallery.TC
{
    public class NativeImageSourceTest1 : Grid, ITestCase
    {
        NativeImageSource _imageSource;
        public NativeImageSourceTest1()
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
                Text = "NativeImageSource Test1",
                FontSize = 30,
            });


            var target = new TbmSurfaceView
            {
                DesiredWidth = 400,
                DesiredHeight = 400
            };
            _imageSource = new NativeImageSource(400, 400);
            target.SetSource(_imageSource);

            Add(new AbsoluteLayout
            {
                target.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                new Button("Update")
                {
                    Clicked = () =>
                    {
                        Draw();
                        Window.Default.KeepRendering(0);
                    }
                }
            }.Row(1));

            UIApplication.Current.PostToUI(() =>
            {
                Draw();
            });
        }

        void Draw()
        {
            IntPtr pixels = _imageSource.AccquiredBuffer(out var w, out var h, out var stride);
            var info = new SKImageInfo(w, h);
            var surface = SKSurface.Create(info, pixels, stride);

            var canvas = surface.Canvas;
            var rnd = new Random();
            canvas.Clear(new SKColor((byte)rnd.Next(100, 255), (byte)rnd.Next(100, 255), (byte)rnd.Next(100, 255)));


            var redBrush = new SKPaint
            {
                Color = new SKColor(0xff, 0, 0),
                IsStroke = true
            };
            var blueBrush = new SKPaint
            {
                Color = new SKColor(0, 0, 0xff),
                IsStroke = true
            };

            // Draw using Skia
            for (int i = 0; i < 64; i += 8)
            {
                var rect = new SKRect(i, i, 256 - i - 1, 256 - i - 1);
                canvas.DrawRect(rect, (i % 16 == 0) ? redBrush : blueBrush);
            }
            _imageSource.ReleaseBuffer();
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
