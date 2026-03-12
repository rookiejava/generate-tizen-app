using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest7 : Grid, ITestCase
    {
        public ScrollViewTest7()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(200);
            RowDefinitions.Add(GridLength.Star);

            Add(new VStack
            {
                Padding = 20,
                Children =
                {
                    new TextView { Text = "ScrollPostion : ", Name = "Log1", FontSize = 30 },
                    new TextView { Text = "State : ", Name = "Log2", FontSize = 30 }
                }
            }.VerticalLayoutAlignment(LayoutAlignment.Center));
            Add(new ScrollLayout
            {
                Name = "ScrollView",
                Content = new VStack
                {
                    Name = "VStack",
                    BackgroundColor = Color.Green,
                }
            }.Row(1));

            for (int i = 0; i < 250; i++)
            {
                var rnd = new Random();
                (this["VStack"] as Layout).Children.Add(new View
                {
                    DesiredHeight = 50,
                    BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                });
            }
            var scrollview = (this["ScrollView"] as ScrollLayout);
            scrollview.Scrolling += (s, e) =>
            {
                (this["Log1"] as TextView).Text = $"ScrollPosition : {scrollview.ScrollPosition}";
            };
            scrollview.ScrollStarted += (s, e) =>
            {
                (this["Log2"] as TextView).Text = $"State : ScrollStarted";
            };
            scrollview.ScrollFinished+= (s, e) =>
            {
                (this["Log2"] as TextView).Text = $"State : ScrollFinished";
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
