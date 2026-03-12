using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest3 : Grid, ITestCase
    {
        public FlexBoxTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);
            BackgroundColor = Color.Beige;
            Add(new FlexBox
            {
                Padding = 30,
                Name = "FlexBox",
                Direction = FlexDirection.Column,
                Children =
                {
                    new TextView
                    {
                        Name = "Text-Header",
                        Text = "HEADER",
                        FontSize = 20,
                        BackgroundColor = Color.Aqua,
                        HorizontalAlignment = TextAlignment.Center,
                    },
                    new FlexBox
                    {
                        Name = "InnerFlexBox",
                        Padding = 50,
                        Children =
                        {
                            new TextView
                            {
                                Name = "Text-Content",
                                Text = "CONTENT",
                                FontSize = 20,
                                BackgroundColor = Color.Gray,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }.Grow(1),
                            new View
                            {
                                Name = "Blue",
                                BackgroundColor = Color.Blue
                            }.Basis(50).Order(-1),
                            new View
                            {
                                Name = "Green",
                                BackgroundColor = Color.Green
                            }.Basis(50),
                        }
                    }.Grow(1),
                    new TextView
                    {
                        Name = "Text-Footer",
                        Text = "FOOTER",
                        FontSize = 20,
                        BackgroundColor = Color.Pink,
                        HorizontalAlignment = TextAlignment.Center,
                    }

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
