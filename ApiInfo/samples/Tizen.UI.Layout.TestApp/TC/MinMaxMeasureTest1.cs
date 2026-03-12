using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class MinMaxMeasureTest1 : Grid, ITestCase
    {
        public MinMaxMeasureTest1()
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
                Text = "Min Max Measure Test1",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new ImageView
                {
                    BackgroundColor = Color.Coral,
                }.MinimumHeight(100).MinimumWidth(100).LayoutBounds(0, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                new ImageView
                {
                    ResourceUrl = "img2.png",
                    FittingMode = FittingMode.ScaleToFill,
                }.MaximumWidth(300).MaximumHeight(300).LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                new ImageView
                {
                    ResourceUrl = "profile.jpg",
                }.MinimumHeight(200).MinimumWidth(200).LayoutBounds(1, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
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
