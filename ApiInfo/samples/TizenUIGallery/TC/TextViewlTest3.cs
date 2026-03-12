using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class TextViewlTest3 : Grid, ITestCase
    {
        public TextViewlTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "TextView Test3",
                FontSize = 30,
            });

            Add(new VStack
            {
                new TextView
                {
                    IsMultiline = true,
                    FontSize = 20,
                }.Self(out var log),
                new TextView
                {
                    BackgroundColor = Color.Red,
                    FontSize = 100,
                    Text = ""
                }.HorizontalLayoutAlignment(LayoutAlignment.Center).Self(out var label1),
                new TextView
                {
                    BackgroundColor = Color.Red,
                    FontSize = 100,
                    Text = "   ",
                    
                }.HorizontalLayoutAlignment(LayoutAlignment.Center).Self(out var label2),
                new TextView
                {
                    Text = "Hello world",
                    FontSize = 100,
                    DesiredWidth = 0,
                }.HorizontalLayoutAlignment(LayoutAlignment.Center).Self(out var label3),
            }.Row(1).Spacing(10).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.LightBlue));

            var measure1 = label1.Measure(float.PositiveInfinity, float.PositiveInfinity);
            var measure2 = label2.Measure(float.PositiveInfinity, float.PositiveInfinity);
            var measure3 = label3.Measure(float.PositiveInfinity, float.PositiveInfinity);

            log.Text = $"(empty string) Measure : {measure1}\n'   '(white space) Measured : {measure2}\nHello world(DesiredWidth=0) Measured : {measure3}";
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
