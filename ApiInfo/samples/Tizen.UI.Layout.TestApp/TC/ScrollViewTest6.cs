using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest6 : Grid, ITestCase
    {
        public ScrollViewTest6()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Name = "VStack",
                    BackgroundColor = Color.Green,
                }.Margin(10),
            });

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
