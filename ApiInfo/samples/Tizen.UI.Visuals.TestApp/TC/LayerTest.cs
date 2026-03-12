using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Visuals;

namespace VisualObjectTest.TC
{
    class LayerTest : Grid, ITestCase
    {
        public LayerTest()
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
                Text = "LayerTest",
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
                    }.Margin(10)
                }
            }.Row(1).Spacing(10));

            this["Target"].Visuals().ForegroundEffectLayer.Add(new ColorVisual
            {
                Color = Color.Transparent,
                BorderlineColor = Color.Yellow,
                BorderlineWidth = 20,
                BorderlineOffset = 0f,
            });

            this["Target"].Visuals().ForegroundEffectLayer.Add(new ColorVisual
            {
                Color = Color.Transparent,
                BorderlineColor = Color.Black,
                BorderlineWidth = 1,
                BorderlineOffset = 1,
            });

            this["Target"].Visuals().ContentLayer.Add(new ColorVisual
            {
                Origin = VisualAlign.Center,
                PivotPoint = VisualAlign.Center,
                Width = 50, 
                Height = 50,
                TransformFlags = TransformFlags.PositionProportional,
                Color = Color.Red,
            });

            this["Target"].Visuals().BackgroundLayer.Add(new ColorVisual
            {
                Origin = VisualAlign.Center,
                PivotPoint = VisualAlign.Center,
                Width = 50,
                Height = 60,
                X = -30f,
                TransformFlags = TransformFlags.YProportional,
                Color = Color.Green,
            });

            this["Target"].Visuals().DecorationLayer.Add(new ColorVisual
            {
                Color = Color.Transparent,
                BorderlineColor = Color.Blue,
                BorderlineWidth = 30,
                BorderlineOffset = -1,
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
