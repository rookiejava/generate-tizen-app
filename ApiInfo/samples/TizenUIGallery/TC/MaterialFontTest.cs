using System.Text;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class MaterialFontTest : Grid, ITestCase
    {
        public MaterialFontTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "MaterialFontTest",
                FontSize = 30,
            });

            var sb = new StringBuilder();
            var start = 0xe859;
            for (int i = 0; i < 300; i++)
            {
                sb.Append((char)(start + i));
            }

            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    Spacing = 4,
                    Children =
                    {
                        new TextView
                        {
                            FontSize = 60,
                            Text = sb.ToString(),
                            IsMultiline = true,
                            FontFamily = "MaterialIcons",
                        },
                    }
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
