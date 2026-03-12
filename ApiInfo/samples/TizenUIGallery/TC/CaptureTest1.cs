#if API12_OR_GREATER
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class CaptureTest1 : Grid, ITestCase
    {
        public CaptureTest1()
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
                Text = "Capture Test1",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                Name = "AbsLayout",
                Children =
                {
                    new HStack
                    {
                        new TextView
                        {
                            Name = "Target1",
                            DesiredHeight = 300,
                            DesiredWidth = 300,
                            BackgroundColor = Color.AliceBlue,
                            Text = "Hello",
                            FontSize = 20,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                        },
                        new ImageView
                        {
                            Name = "Target2",
                            ResourceUrl = "image2.jpg",
                        },
                        new Grid
                        {
                            DesiredWidth = 400,
                            Name = "Target3",
                            RowDefinitions = { 50, GridLength.Star, 60 },
                            ColumnDefinitions = { 30, 30, 30, GridLength.Star },
                            Children =
                            {
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(0).Column(0),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(0).Column(1),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(0).Column(2),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(0).Column(3),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(1).Column(0),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(1).Column(1),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(1).Column(2),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(1).Column(3),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(2).Column(0),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(2).Column(1),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(2).Column(2),
                                new View { BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f)}.Row(2).Column(3),
                            }
                        }
                    }
                }
            }.Row(1));

            var tap = new TapGestureDetector
            {
                MaximumTapsRequired = 2,
            };
            tap.Attach(this["Target1"]);
            tap.Attach(this["Target2"]);
            tap.Attach(this["Target3"]);
            tap.Attach(this);
            tap.Detected += async (s, e) =>
            {
                using var url = await ScreenShot.CaptureAsync(e.View);
                var img = new ImageView
                {
                    Name = "Img",
                    BorderlineWidth = 3,
                    BorderlineColor = Color.White,
                    SynchronousLoading = true,
                    DesiredHeight = 300,
                    DesiredWidth = 300,
                    BackgroundColor = Color.Gray,
                    ResourceUrl = url.ToString(),
                }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional);
                (this["AbsLayout"] as Layout).Add(img);
                await Task.Delay(5000);
                img.Dispose();
            };

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
#endif