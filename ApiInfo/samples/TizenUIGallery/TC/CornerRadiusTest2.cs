using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class CornerRadiusTest2 : Grid, ITestCase
    {
        public CornerRadiusTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(50);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "CornerRadius Test",
                FontSize = 30,
            });

            Add(new TextView
            {
                Name = "Log",
                BackgroundColor = Color.Yellow,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                FontSize = 20,
            }.Row(1));

            Add(new AbsoluteLayout
            {
                new ImageView().Name("ImageTarget").ResourceUrl("image2.jpg").DesiredHeight(200).DesiredWidth(200).LayoutBounds(0, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(30),
                new View().Name("Target").BackgroundColor(Color.BlueViolet).DesiredHeight(200).DesiredWidth(200).LayoutBounds(1, 1, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(30)
            }.Row(2));

            Add(new VStack
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Children =
                {
                    new HStack
                    {
                        new Button("0.2")
                        {
                            DesiredWidth = 50,
                            Clicked = () =>
                            {
                                var r = new CornerRadius(0.2f);
                                this["Target"].CornerRadius = r;
                                this["ImageTarget"].CornerRadius = r;
                               (this["Log"] as TextView).Text = $"Current radius : {r}";
                            }
                        },
                        new Button("0.3")
                        {
                            DesiredWidth = 50,
                            Clicked = () =>
                            {
                                var r = new CornerRadius(0.3f);
                                this["Target"].CornerRadius = r;
                                this["ImageTarget"].CornerRadius = r;
                               (this["Log"] as TextView).Text = $"Current radius : {r}";
                            }
                        },
                        new Button("0.5")
                        {
                            DesiredWidth = 50,
                            Clicked = () =>
                            {
                                var r = new CornerRadius(0.5f);
                                this["Target"].CornerRadius = r;
                                this["ImageTarget"].CornerRadius = r;
                               (this["Log"] as TextView).Text = $"Current radius : {r}";
                            }
                        },
                        new Button("1")
                        {
                            DesiredWidth = 50,
                            Clicked = () =>
                            {
                                var r = new CornerRadius(1f);
                                this["Target"].CornerRadius = r;
                                this["ImageTarget"].CornerRadius = r;
                               (this["Log"] as TextView).Text = $"Current radius : {r}";
                            }
                        },
                        new Button("50")
                        {
                            DesiredWidth = 50,
                            Clicked = () =>
                            {
                                var r = new CornerRadius(50);
                                this["Target"].CornerRadius = r;
                                this["ImageTarget"].CornerRadius = r;
                               (this["Log"] as TextView).Text = $"Current radius : {r}";
                            }
                        },
                    }.Spacing(20),
                    new Button("Random background color")
                    {
                        Clicked = () =>
                        {
                            var rnd = new Random();
                            this["Target"].BackgroundColor = new Color(rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f, 1);
                        }
                    }.Margin(10),
                    new Button("Set Shadow")
                    {
                        Clicked = () =>
                        {
                            this["Target"].SetShadow(new Shadow
                            {
                                Color = Color.Black,
                                Offset = new Point(2, 2),
                                BlurRadius = 10f
                            });
                            this["ImageTarget"].SetShadow(new Shadow
                            {
                                Color = Color.Black,
                                Offset = new Point(2, 2),
                                BlurRadius = 10f
                            });
                        }
                    }.Margin(10),
                    new Button("Clear Shadow")
                    {
                        Clicked = () =>
                        {
                            this["Target"].ClearShadow();
                            this["ImageTarget"].ClearShadow();
                        }
                    }.Margin(10),
                },
            }.Row(3));
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
