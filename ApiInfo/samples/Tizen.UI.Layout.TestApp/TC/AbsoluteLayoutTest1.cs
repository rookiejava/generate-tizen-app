using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class AbsoluteLayoutTest1 : Grid, ITestCase
    {
        public AbsoluteLayoutTest1()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "AbsoluteLayout Test1",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                Children =
                {
                    new View
                    {
                        BackgroundColor = Color.AliceBlue
                    }.LayoutBounds(1, 1, 0.5f, 0.5f).LayoutFlags(AbsoluteLayoutFlags.All),
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue
                    }.LayoutBounds(1, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue
                    }.LayoutBounds(0, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(100, 100, 0, 0),
                }
            }.Row(1));
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
