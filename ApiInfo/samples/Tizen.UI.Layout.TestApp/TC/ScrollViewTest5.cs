using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest5 : Grid, ITestCase
    {
        public ScrollViewTest5()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);

            Add(new Button("UpdateLayout")
            {
                Clicked = () =>
                {
                    (this["ScrollView"] as Layout).UpdateLayout();
                }
            });

            Add(new ScrollLayout
            {
                Name = "ScrollView",
                Padding = 10,
                Content = new VStack
                {
                    Name = "VStack",
                    BackgroundColor = Color.Green,
                }
            }.Row(1));

            for (int i = 0; i < 150; i++)
            {
                var rnd = new Random();
                (this["VStack"] as Layout).Children.Add(new View
                {
                    DesiredHeight = 50,
                    BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                });
            }
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
