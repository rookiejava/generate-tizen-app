using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class ImageViewPlaceholderTest : Grid, ITestCase
    {
        string[] images2 = new string[]
        {
                    "http://i.imgur.com/H8mbyUM.jpg",
                    "http://i.imgur.com/6ZUYWDE.jpg",
                    "http://i.imgur.com/t9gomWN.jpg",
                    "http://i.imgur.com/9f974SC.jpg",
                    "http://i.imgur.com/KQ3NtX5.jpg",
                    "http://i.imgur.com/ygrDkwo.jpg",
                    "http://i.imgur.com/SZOzETV.jpg",
                    "http://i.imgur.com/YQlie8b.jpg",
                    "http://i.imgur.com/kJS4q3U.jpg",
                    "http://i.imgur.com/MkH9aPa.jpg",
                    "http://i.imgur.com/C3b9otw.jpg",
                    "http://i.imgur.com/wpcsCMh.jpg",
                    "http://i.imgur.com/fH6dqpP.jpg",
                    "http://i.imgur.com/T38xuv3.jpg",
                    "http://i.imgur.com/jZ4qSxo.jpg",
                    "http://i.imgur.com/hb7ICRv.jpg",
        };
        int current = 0;

        public ImageViewPlaceholderTest()
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
                Text = "ImageView PlaceholderUrl Test",
                FontSize = 30,
            });
            Add(new VStack
            {
                new Button("Update Resource")
                {
                    Clicked = async () =>
                    {
                        (this["Image"] as ImageView).ResourceUrl = null;

                        await Task.Delay(10);

                        current = (current + 1) % images2.Length;
                        (this["Image"] as ImageView).ResourceUrl = images2[current];
                    }
                },
                new ImageView
                {
                    Name = "Image",
                    BorderlineWidth = 5,
                    BorderlineColor = Color.White,
                    ResourceUrl = "http://i.imgur.com/9f974SC.jpg",
#if API11_OR_GREATER
                    LoadingPlaceholderUrl = "dotnet_bot.png",
#endif
                    DesiredWidth = 600,
                    DesiredHeight = 400,
                }.Margin(10),
            }.Row(1).Spacing(10));

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
