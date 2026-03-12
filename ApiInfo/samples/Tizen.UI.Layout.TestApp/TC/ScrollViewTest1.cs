using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest1 : Grid, ITestCase
    {
        public ScrollViewTest1()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            Add(new ScrollLayout
            {
                Padding = 10,
                Content = new VStack
                {
                    Name = "VStack",
                    BackgroundColor = Color.Green,
                }
            });

            for (int i = 0; i < 250; i++)
            {
                var rnd = new Random();
                (this["VStack"] as Layout).Children.Add(new TextView
                {
                    FontSize = 20,
                    Text = $"{i+1}",
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
