using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest3 : ViewGroup, ITestCase
    {
        public GridTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Add(new Grid
            {
                Name = "Outter",
                BackgroundColor = Color.AliceBlue,
                Children =
                {
                    new Grid
                    {
                        BackgroundColor = Color.RosyBrown,
                        Children =
                        {
                            new TextView
                            {
                                BackgroundColor = Color.Bisque,
                                Text = "By default, a Grid contains one row and one column",
                                FontSize = 30,
                            }.HorizontalLayoutAlignment(LayoutAlignment.Center).VerticalLayoutAlignment(LayoutAlignment.Center)
                        }
                        
                    }.Margin(20, 35, 20, 20),
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
