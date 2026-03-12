using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest11 : Grid, ITestCase
    {
        public ScrollViewTest11()
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
                Text = "Nested ScrollView Test",
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
                    DesiredHeight = 100,
                    BackgroundColor = new Color(rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f, rnd.Next(30, 255) / 255f)
                });
            }

            (this["VStack"] as Layout).Children.Insert(3, new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Vertical,
                DesiredHeight = 200,
                Content = new VStack
                {
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                    new TextView().Text("Hello World").FontSize(20),
                }
            });


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
