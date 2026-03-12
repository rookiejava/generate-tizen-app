using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class DaliPaddingTest : Grid, ITestCase
    {
        public DaliPaddingTest()
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
                Text = "DaliPaddingTest",
                FontSize = 30,
            });
            Add(new VStack
            {
                Children =
                {
                    new TextView
                    {
                        Name = "Target",
                        Text = "Test",
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                    }
                    .TextPadding(100, 0, 0, 0)
                    .HorizontalLayoutAlignment(LayoutAlignment.Start),
                    new TextField
                    {
                        Name = "Target2",
                        Text = "Test",
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                    }
                    .TextPadding(100, 0, 0, 0)
                    .HorizontalLayoutAlignment(LayoutAlignment.Start),

                    new TextEditor
                    {
                        Name = "Target3",
                        Text = "Test",
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                    }
                    .TextPadding(100, 0, 0, 0)
                    .HorizontalLayoutAlignment(LayoutAlignment.Start),

                    new ImageView
                    {
                        Name = "Target4",
                        ResourceUrl = "img1.jpg",
                        BackgroundColor = Color.Red,
                    }
                    .ImagePadding(100, 10, 50, 30)
                    .HorizontalLayoutAlignment(LayoutAlignment.Start),
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
