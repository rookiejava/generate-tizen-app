using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest3 : Grid, ITestCase
    {
        public ScrollViewTest3()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            var grid = new Grid();

            for (int i = 0; i < 30; i++)
            {
                grid.RowDefinitions.Add(80);
                grid.ColumnDefinitions.Add(80);
            }

            var rnd = new Random();
            for (int row = 0; row < 30; row++)
            {
                for (int col = 0; col < 30; col++)
                {
                    grid.Children.Add(new View
                    {
                        BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                    }.Row(row).Column(col));
                }
            }
            
            Add(new ScrollLayout
            {
                Padding = 10,
                ScrollDirection = ScrollDirection.Both,
                Content = grid,
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
