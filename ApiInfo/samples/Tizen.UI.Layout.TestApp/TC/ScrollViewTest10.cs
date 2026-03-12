using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest10 : Grid, ITestCase
    {
        public ScrollViewTest10()
        {
            Name = "Outter";
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
                Text = "Sticky view poc",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Name = "ScrollView",
                ScrollDirection = ScrollDirection.Vertical,
                Content = new VStack
                {
                    Name = "VStack",
                }
            }.Row(1));

            var rnd = new Random();
            for (int row = 0; row < 600; row++)
            {
                (this["VStack"] as Layout).Add(new View
                {
                    DesiredHeight = 200,
                    BackgroundColor = new Color(rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f)
                });
            }

            (this["ScrollView"] as ScrollLayout).Add(new TextView
            {
                Text = "Sticky header",
                Name = "flow",
                BackgroundColor = Color.GreenYellow,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Y = 500,
                Height = 100,
            });

            (this["ScrollView"] as ScrollLayout).Scrolling += (s, e) =>
            {
                this["flow"].Y = MathF.Max(0, -(this["ScrollView"] as ScrollLayout).ScrollPosition.Y + 500);
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
