using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class HStackTest2 : ViewGroup, ITestCase
    {
        public HStackTest2()
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
                        BackgroundColor = Color.GreenYellow,
                        DesiredHeight = 200,
                        Padding = 5,
                        Spacing = 5,
                        Children =
                        {
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Start",
                                BackgroundColor = Color.Gray
                            }.VerticalLayoutAlignment(LayoutAlignment.Start),
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Center",
                                BackgroundColor = Color.Gray
                            }.VerticalLayoutAlignment(LayoutAlignment.Center),
                            new TextView
                            {
                                FontSize = 20,
                                Text = "End",
                                BackgroundColor = Color.Gray
                            }.VerticalLayoutAlignment(LayoutAlignment.End),
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Fill",
                                BackgroundColor = Color.Gray
                            }.VerticalLayoutAlignment(LayoutAlignment.Fill),
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
