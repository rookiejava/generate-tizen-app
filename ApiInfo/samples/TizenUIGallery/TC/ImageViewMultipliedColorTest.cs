using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class ImageViewMultipliedColorTest : Grid, ITestCase
    {
        public ImageViewMultipliedColorTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ImageView MultipliedColor Test",
                FontSize = 30,
            });
            Add(new HStack
            {
                new ImageView
                {
                    Name = "Bot",
                    BorderlineWidth = 5,
                    BorderlineColor = Color.White,
                    ResourceUrl = "dotnet_bot.png",
                    MultipliedColor = new Color(1, 0, 0, 0.5f),
                }.Margin(10),
                new ImageView
                {
                    BorderlineWidth = 5,
                    BorderlineColor = Color.White,
                    ResourceUrl = "dotnet_bot.png",
                    ImageMultipliedColor = new Color(1, 0, 0, 0.5f),
                }.Margin(10),
            }.Row(1));

            Add(new HStack
            {
                new ImageView
                {
                    Name = "Cat",
                    BorderlineWidth = 5,
                    BorderlineColor = Color.White,
                    ResourceUrl = "image2.jpg",
                    MultipliedColor = new Color(0, 1, 0, 0.5f)
                }.Margin(10),
                new ImageView
                {
                    BorderlineWidth = 5,
                    BorderlineColor = Color.White,
                    ResourceUrl = "image2.jpg",
                    ImageMultipliedColor = new Color(0, 1, 0, 0.5f)
                }.Margin(10),
            }.Row(2));

            Console.WriteLine($"Bot MultipliedColor : {this["Bot"].MultipliedColor}");
            Console.WriteLine($"Cat MultipliedColor : {this["Cat"].MultipliedColor}");
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
