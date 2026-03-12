using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackTest1 : ViewGroup, ITestCase
    {
        public VStackTest1()
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
                        Children =
                        {
                            new TextView
                            {
                                FontSize = 30,
                                Text = "Primary colors"
                            },
                            new View
                            {
                                BackgroundColor = Color.Red,
                                DesiredHeight = 30,
                                DesiredWidth = 300,
                            },
                            new View
                            {
                                BackgroundColor = Color.Yellow,
                                DesiredHeight = 30,
                                DesiredWidth = 300
                            },
                            new View
                            {
                                BackgroundColor = Color.Blue,
                                DesiredHeight = 30,
                                DesiredWidth = 300
                            },
                            new TextView
                            {
                                FontSize = 30,
                                Text = "Secondary colors"
                            },
                            new View
                            {
                                BackgroundColor = Color.Green,
                                DesiredHeight = 30,
                                DesiredWidth = 300,
                            },
                            new View
                            {
                                BackgroundColor = Color.Orange,
                                DesiredHeight = 30,
                                DesiredWidth = 300
                            },
                            new View
                            {
                                BackgroundColor = Color.Purple,
                                DesiredHeight = 30,
                                DesiredWidth = 300
                            }
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
