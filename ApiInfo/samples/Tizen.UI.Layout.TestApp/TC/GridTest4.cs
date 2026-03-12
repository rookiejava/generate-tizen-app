using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest4 : ViewGroup, ITestCase
    {
        public GridTest4()
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
                        ColumnSpacing = 10,
                        RowSpacing = 5,
                        RowDefinitions =
                        {
                            new GridLength(2, GridUnitType.Star),
                            new GridRowDefinition(),
                            100,
                        },

                        ColumnDefinitions =
                        {
                            new GridColumnDefinition(),
                            new GridColumnDefinition(),
                        },
                        BackgroundColor = Color.RosyBrown,
                        Children =
                        {
                            new View
                            {
                                BackgroundColor = Color.Green
                            },
                            new TextView
                            {
                                Text = "Row 0, Column 0",
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                                FontSize = 20,
                            },
                            new View
                            {
                                BackgroundColor = Color.Blue,
                            }.Column(1),
                            new TextView
                            {
                                Text = "Row 0, Column 1",
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                                FontSize = 20,
                            }.Column(1),
                            new View
                            {
                                BackgroundColor = Color.Teal
                            }.Row(1),
                            new TextView
                            {
                                Text="Row 1, Column 0",
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                                FontSize = 20,
                            }.Row(1),
                            new View
                            {
                                BackgroundColor = Color.Purple
                            }.Row(1).Column(1),
                            new TextView
                            {
                                Text="Row1, Column 1",
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                                FontSize = 20,
                            }.Row(1).Column(1),
                            new View
                            {
                                BackgroundColor = Color.Red
                            }.Row(2).ColumnSpan(2),
                            new TextView
                            {
                                Text = "Row 2, Columns 0 and 1",
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                                FontSize = 20,
                            }.Row(2).ColumnSpan(2)
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
