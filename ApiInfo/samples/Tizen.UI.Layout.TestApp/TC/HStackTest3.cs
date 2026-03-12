using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class HStackTest3 : ViewGroup, ITestCase
    {
        public HStackTest3()
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
                        Spacing = 6,
                        Children =
                        {
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Primary colors:",
                            },
                            new VStack
                            {
                                Spacing = 6,
                                Children =
                                {
                                    new View
                                    {
                                        BackgroundColor = Color.Red,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30,
                                    },
                                    new View
                                    {
                                        BackgroundColor = Color.Yellow,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30,
                                    },
                                    new View
                                    {
                                        BackgroundColor = Color.Blue,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30,
                                    },
                                }
                            },
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Secondary colors:",
                            },
                            new VStack
                            {
                                Spacing = 6,
                                Children =
                                {
                                    new View
                                    {
                                        BackgroundColor = Color.Green,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30,
                                    },
                                    new View
                                    {
                                        BackgroundColor = Color.Orange,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30,
                                    },
                                    new View
                                    {
                                        BackgroundColor = Color.Purple,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30,
                                    },
                                }
                            },
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
