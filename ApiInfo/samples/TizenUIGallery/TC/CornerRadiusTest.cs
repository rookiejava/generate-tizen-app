using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class CornerRadiusTest : Grid, ITestCase
    {
        public CornerRadiusTest()
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
                    new TextView().Name("CornerRadius").Text("<---------- Drag ---------->").FontSize(30).TextCenterHorizontal(),
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

            float curCornerRadius = 0;
            var pan = new PanGestureDetector();
            pan.Detected += (s, e) =>
            {
                if (e.Gesture.State == GestureState.Continuing)
                {
                    var diff = (e.Gesture.Displacement.X) / 5f;
                    curCornerRadius += diff;
                    curCornerRadius = MathF.Max(0, MathF.Min(curCornerRadius, this["Target"].Height));
                    this["Target"].CornerRadius = curCornerRadius;
                    this["ImageTarget"].CornerRadius = curCornerRadius;
                    (this["Log"] as TextView).Text = $"Current radius : {this["Target"].CornerRadius}";
                }
            };
            pan.Attach(this["CornerRadius"]);
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
