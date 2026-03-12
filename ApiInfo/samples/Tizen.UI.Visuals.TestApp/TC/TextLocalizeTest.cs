using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Visuals;

namespace VisualObjectTest.TC
{
    class TextLocalizeTest : Grid, ITestCase
    {
        public TextLocalizeTest()
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
                Text = "TextLocalizeTest",
                FontSize = 30,
            });

            Add(new VStack
            {
                Name = "VStack",
                Children =
                {
                    new View
                    {
                        Name = "Target",
                        DesiredHeight = 200,
                        DesiredWidth = 300,
                        BackgroundColor = Color.White.WithAlpha(0.5f),
                    }.Margin(10).Add(new TextVisual
                    {
                        TransformFlags = TransformFlags.PositionProportional,
                        Origin = VisualAlign.Center,
                        PivotPoint = VisualAlign.Center,
                        Width = 200,
                        Height = 300,
                        VerticalAlignment = TextAlignment.Center,
                        HorizontalAlignment = TextAlignment.Center,
                        TextColor = Color.Blue,
                        FontSize = 20,
                    }.BindLocalizedText("Greetings"))
                }
            }.Row(1).Spacing(10));


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
