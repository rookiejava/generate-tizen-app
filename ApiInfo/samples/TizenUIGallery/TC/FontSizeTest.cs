using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class FontSizeTest : Grid, ITestCase
    {
        public FontSizeTest()
        {
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
                Text = "FontSize Text",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Spacing = 5,
                    Name = "VStack"
                }
            }.Row(1));

            for (int i = 10; i <= 100; i += 5)
            {
                (this["VStack"] as VStack).Add(new HStack
                {
                    Spacing = 5,
                    Children =
                    {
                        new View
                        {
                            BackgroundColor = Color.Green,
                            DesiredHeight = i,
                            DesiredWidth = 100,
                        }.VerticalLayoutAlignment(LayoutAlignment.Center),
                        new View
                        {
                            BackgroundColor = Color.Green,
                            DesiredHeight = i * 1.2f,
                            DesiredWidth = 100,
                        }.VerticalLayoutAlignment(LayoutAlignment.Center),
                        new TextView
                        {
                            Name = $"TextView-{i}",
                            FontSize = i,
                            IsMarkupEnabled = true,
                            LineHeight = 1,
                            Text = $"[{i}] -- Hello <background color='#ff0000'>Text</background> world g, ABCDEFG abcdef",
                            BackgroundColor = Color.Green,
                            VerticalAlignment = TextAlignment.Center,
                        }.VerticalLayoutAlignment(LayoutAlignment.Center),
                    }
                });
            }

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
