using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest6 : ViewGroup, ITestCase
    {
        public GridTest6()
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
                        RowDefinitions =
                        {
                            GridLength.Star,
                            GridLength.Auto
                        },

                        Children =
                        {
                            new View
                            {
                                BackgroundColor = Color.Violet
                            },
                            new Grid
                            {
                                RowDefinitions =
                                {
                                    GridLength.Auto,
                                    GridLength.Auto,
                                    GridLength.Auto,
                                    GridLength.Auto,
                                    GridLength.Auto,
                                    GridLength.Auto,
                                },

                                Children =
                                {
                                    new View
                                    {
                                        BackgroundColor = Color.Violet,
                                        DesiredHeight = 10,
                                    },
                                    new TextView
                                    {
                                        FontSize = 20,
                                        Text = "Red = 123"
                                    }.Row(1).HorizontalLayoutAlignment(LayoutAlignment.Center).Margin(10),

                                    new View
                                    {
                                        BackgroundColor = Color.Violet,
                                        DesiredHeight = 10,
                                    }.Row(2),
                                    new TextView
                                    {
                                        FontSize = 20,
                                        Text = "Green = 432"
                                    }.Row(3).HorizontalLayoutAlignment(LayoutAlignment.Center).Margin(10),

                                    new View
                                    {
                                        BackgroundColor = Color.Violet,
                                        DesiredHeight = 10,
                                    }.Row(4),
                                    new TextView
                                    {
                                        FontSize = 20,
                                        Text = "Blue = 111"
                                    }.Row(5).HorizontalLayoutAlignment(LayoutAlignment.Center).Margin(10),
                                }

                            }.Row(1).Margin(20)
                        }
                    },
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
