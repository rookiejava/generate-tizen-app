using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class HStackTest1 : ViewGroup, ITestCase
    {
        public HStackTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Add(new Grid
            {
                Name = "Outter",
                BackgroundColor = Color.AliceBlue,

                RowDefinitions =
                {
                    GridLength.Auto,
                },

                ColumnDefinitions =
                {
                    GridLength.Auto,
                },

                Children =
                {
                    new HStack
                    {
                        BackgroundColor = Color.Gray,
                        Padding = 5,
                        Spacing = 5,
                        Children =
                        {
                            new View
                            {
                                BackgroundColor = Color.Red,
                                DesiredWidth = 30,
                                DesiredHeight = 30,
                            },
                            new TextView
                            {
                                Text = "Red",
                                FontSize = 20,
                            }.VerticalLayoutAlignment(LayoutAlignment.Center)
                        }
                    }.Margin(20)
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
