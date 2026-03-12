using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class BackgroundTest2 : Grid, ITestCase
    {
        public BackgroundTest2()
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
                Text = "Background Test2",
                FontSize = 30,
            }.ColumnSpan(4));



            var imgSize = ImageLoader.GetOriginalImageSize("bg.png");
            Console.WriteLine($"bg.png size : {imgSize}");
            Add(new AbsoluteLayout
            {
                Name = "Abs",
                Children =
                {
                    new View
                    {
                        DesiredWidth = 500,
                        DesiredHeight = 300,
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                    }
                    .Background(new ImageBackground 
                    {
                        Url = "bg.png",
                        PixelArea = new Rect(0, 0, 500 / imgSize.Width, 300 / imgSize.Height),
                        WrapModeU = ImageWrapMode.Repeat,
                        WrapModeV = ImageWrapMode.Repeat,
                    })
                    .LayoutBounds(10, 10, -1, -1),

                    new View
                    {
                        DesiredWidth = 500,
                        DesiredHeight = 300,
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                    }
                    .Background(new ImageBackground
                    {
                        Url = "bg.png",
                        PixelArea = new Rect(0, 0, 500 / imgSize.Width, 300 / imgSize.Height),
                        WrapModeU = ImageWrapMode.Repeat,
                    })
                    .LayoutBounds(600, 10, -1, -1),

                    new View
                    {
                        DesiredWidth = 500,
                        DesiredHeight = 300,
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                    }
                    .Background(new ImageBackground
                    {
                        Url = "bg.png",
                        PixelArea = new Rect(0, 0, 500 / imgSize.Width, 300 / imgSize.Height),
                        WrapModeV = ImageWrapMode.Repeat,
                    })
                    .LayoutBounds(1200, 10, -1, -1),
                }
            }.Row(1));

            Relayout += (s, e) =>
            {
                if (this.Size() != lastSize)
                {
                    lastSize = this.Size();
                    var imgSize = ImageLoader.GetOriginalImageSize("bg2.jpg");
                    Console.WriteLine($"bg.png size : {imgSize}");
                    SetBackground(new ImageBackground
                    {
                        Url = "bg2.jpg",
                        PixelArea = new Rect(0, 0, Width / imgSize.Width, Height / imgSize.Height),
                        WrapModeU = ImageWrapMode.Repeat,
                        WrapModeV = ImageWrapMode.Repeat,
                    });
                }
            };
        }

        Size lastSize = Size.Zero;

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
