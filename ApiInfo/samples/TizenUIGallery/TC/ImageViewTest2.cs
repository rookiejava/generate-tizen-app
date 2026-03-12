using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class ImageViewTest2 : Grid, ITestCase
    {
        public ImageViewTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(400);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ImageViewTest2",
                FontSize = 30,
            }.ColumnSpan(4));

            var imgSize = ImageLoader.GetOriginalImageSize("bg.png");
            Console.WriteLine($"bg.png size : {imgSize}");
            Add(new AbsoluteLayout
            {
                Name = "Abs",
                Children =
                {
                    new RepeatableImageView
                    {
                        ResourceUrl = "bg.png",
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                        PixelArea = new Rect(0, 0, 500 / imgSize.Width, 300 / imgSize.Height),
                        WrapModeU = ImageWrapMode.Repeat,
                        WrapModeV = ImageWrapMode.Repeat,
                    }
                    .LayoutBounds(10, 10, 500, 300),

                    new RepeatableImageView
                    {
                        ResourceUrl = "bg.png",
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                        PixelArea = new Rect(0, 0, 500 / imgSize.Width, 300 / imgSize.Height),
                        WrapModeU = ImageWrapMode.Repeat,
                    }
                    .LayoutBounds(600, 10, 500, 300),

                    new RepeatableImageView
                    {
                        ResourceUrl = "bg.png",
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                        WrapModeV = ImageWrapMode.Repeat,
                        PixelArea = new Rect(0, 0, 500 / imgSize.Width, 300 / imgSize.Height),
                    }
                    .LayoutBounds(1200, 10, 500, 300),
                }
            }.Row(1));

            var img1 = new CustomReleaseImageView
            {
                ResourceUrl = "big1.jpg",
                ReleasePolicy = ImageReleasePolicy.Destroyed,
            };

            var img2 = new CustomReleaseImageView
            {
                ResourceUrl = "big2.jpg",
                ReleasePolicy = ImageReleasePolicy.Detached,
            };
            Add(new HStack
            {
                new Button("Show")
                {
                    Clicked = () =>
                    {
                        if (!((this["HStack"] as HStack)?.Contains(img1) ?? false))
                        {
                            (this["HStack"] as HStack).Add(img1);
                            (this["HStack"] as HStack).Add(img2);
                        }
                    }
                },
                new Button("Hide")
                {
                    Clicked = () =>
                    {
                        (this["HStack"] as HStack).Remove(img1);
                        (this["HStack"] as HStack).Remove(img2);
                    }
                },
            }.Row(2).Name("HStack"));

        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

        class RepeatableImageView : ImageView
        {
            public ImageWrapMode WrapModeV
            {
                set => VisualMap.SetWrapModeV(value);
            }

            public ImageWrapMode WrapModeU
            {
                set => VisualMap.SetWrapModeV(value);
            }

            public Rect PixelArea
            {
                set => VisualMap.SetPixelArea(value);
            }
        }

        class CustomReleaseImageView : ImageView
        {
            public ImageReleasePolicy ReleasePolicy
            {
                set => VisualMap.SetReleasePolicy(value);
            }
        }
    }
}
