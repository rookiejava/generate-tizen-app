using LayoutTest.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest11 : Grid, ITestCase
    {
        public GridTest11()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                Name = "heaer",
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Grid Swap test",
                FontSize = 30,
            });

            Add(new VStack()
            {
                Spacing = 20f,
                Children =
                {
                    new Grid()
                    {
                        ColumnDefinitions = { GridLength.Auto, GridLength.Auto },
                        Children =
                        {
                            new TextView{ Text = " Hello " }.Row(0).Column(0).BackgroundColor(Color.LightGreen).Self(out var hello),
                            new TextView{ Text = " World~~~~~ " }.Row(0).Column(1).BackgroundColor(Color.LightBlue).Self(out var world)
                        }
                    }.CenterHorizontal().Self(out var grid),
                    new Button("Swap")
                    {
                        Clicked = () =>
                        {
                            hello.Column(1 - hello.GridParam().Column);
                            world.Column(1 - world.GridParam().Column);
                        }
                    }.CenterHorizontal()
                }
            }.Row(1));
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
