using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest7 : ViewGroup, ITestCase
    {
        public GridTest7()
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
                        ColumnSpacing = 5,
                        RowSpacing = 5,
                        
                        RowDefinitions =
                        {
                            GridLength.Auto,
                            GridLength.Auto,
                            GridLength.Star,
                            200
                        },
                        ColumnDefinitions =
                        {
                            GridLength.Auto,
                            GridLength.Star,
                            200
                        },

                        Children =
                        {
                            new TextView
                            {
                                Text = "Grid",
                                FontSize = 80,
                                HorizontalAlignment = TextAlignment.Center,
                            }.ColumnSpan(3),
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Autosized cell",
                                TextColor = Color.White,
                                BackgroundColor = Color.Blue
                            }.Row(1).Column(0),
                            new View
                            {
                                BackgroundColor = Color.Silver
                            }.Row(1).Column(1),
                            new View
                            {
                                BackgroundColor = Color.Teal
                            }.Row(2).Column(0),
                            new TextView
                            {
                                FontSize = 20,
                                Text = "Leftover space",
                                TextColor = Color.Purple,
                                BackgroundColor = Color.Aqua,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }.Row(2).Column(1),
                            new TextView
                            {
                                FontSize = 20,
                                IsMultiline = true,
                                Text = "Span two rows (or more if you want)",
                                TextColor = Color.Yellow,
                                BackgroundColor = Color.Navy,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }.Column(2).Row(1).RowSpan(2),
                            new TextView
                            {
                                FontSize = 20,
                                IsMultiline = true,
                                Text = "Span 2 columns",
                                TextColor = Color.Blue,
                                BackgroundColor = Color.Yellow,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }.Column(0).ColumnSpan(2).Row(3).RowSpan(4),
                            new TextView
                            {
                                FontSize = 20,
                                IsMultiline = true,
                                Text = "Fixed 100x100",
                                TextColor = Color.Aqua,
                                BackgroundColor = Color.Red,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }.Column(2).Row(3)
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
