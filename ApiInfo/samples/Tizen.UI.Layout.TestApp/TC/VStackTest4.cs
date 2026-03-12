using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackTest4 : ViewGroup, ITestCase
    {
        public VStackTest4()
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
                                Text = "Primary colors",
                            },
                            new HStack
                            {
                                Padding = 5,
                                Spacing = 15,
                                BorderlineColor = Color.Black,
                                BorderlineWidth = 1,
                                BorderlineOffset = 1,
                                Children =
                                {
                                    new View
                                    {
                                        BackgroundColor = Color.Red,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30
                                    },
                                    new TextView
                                    {
                                        Text = "Red",
                                        FontSize = 20,
                                    }
                                }
                            },

                            new HStack
                            {
                                Padding = 5,
                                Spacing = 15,
                                BorderlineColor = Color.Black,
                                BorderlineWidth = 1,
                                BorderlineOffset = 1,
                                Children =
                                {
                                    new View
                                    {
                                        BackgroundColor = Color.Yellow,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30
                                    },
                                    new TextView
                                    {
                                        Text = "Yellow",
                                        FontSize = 20,
                                    }
                                }
                            },

                            new HStack
                            {
                                Padding = 5,
                                Spacing = 15,
                                BorderlineColor = Color.Black,
                                BorderlineWidth = 1,
                                BorderlineOffset = 1,
                                Children =
                                {
                                    new View
                                    {
                                        BackgroundColor = Color.Blue,
                                        DesiredHeight = 30,
                                        DesiredWidth = 30
                                    },
                                    new TextView
                                    {
                                        Text = "Blue",
                                        FontSize = 20,
                                    }
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
