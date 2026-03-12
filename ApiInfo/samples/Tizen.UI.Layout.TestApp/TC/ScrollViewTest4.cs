using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest4 : Grid, ITestCase
    {
        public ScrollViewTest4()
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

            for (int i = 0; i < 50; i++)
            {

                var hscroll = new ScrollLayout
                {
                    DesiredHeight = 100,
                    ScrollDirection = ScrollDirection.Horizontal,
                    Content = new HStack
                    {
                        Name = "HStack",
                        BackgroundColor = Color.Green,
                    }
                };

                for (int j = 0; j < 100; j++)
                {
                    var rnd = new Random();
                    (hscroll["HStack"] as Layout).Children.Add(new View
                    {
                        DesiredWidth = 50,
                        BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                    });
                }
                (this["VStack"] as Layout).Children.Add(hscroll);
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
