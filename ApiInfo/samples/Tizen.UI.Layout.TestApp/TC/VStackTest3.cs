using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackTest3 : ViewGroup, ITestCase
    {
        public VStackTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Add(new Grid
            {
                Name = "Outter",
                BackgroundColor = Color.AliceBlue,

                Children =
                {
                    new VStack
                    {
                        Spacing = 6,
                        Children =
                        {
                            new TextView
                            {
                                FontSize = 30,
                                Text = "Start",
                                BackgroundColor = Color.Gray
                            }.HorizontalLayoutAlignment(LayoutAlignment.Start),
                            new TextView
                            {
                                FontSize = 30,
                                Text = "Center",
                                BackgroundColor = Color.Gray
                            }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                            new TextView
                            {
                                FontSize = 30,
                                Text = "End",
                                BackgroundColor = Color.Gray
                            }.HorizontalLayoutAlignment(LayoutAlignment.End),
                            new TextView
                            {
                                FontSize = 30,
                                Text = "Fill",
                                BackgroundColor = Color.Gray
                            }.HorizontalLayoutAlignment(LayoutAlignment.Fill),
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
