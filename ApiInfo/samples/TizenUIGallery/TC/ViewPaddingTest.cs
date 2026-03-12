using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Internal;

namespace TizenUIGallery.TC
{
    class ViewPaddingTest : Grid, ITestCase
    {
        public ViewPaddingTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            var view1 = new ImageView
            {
                ResourceUrl = "img1.jpg",
                BackgroundColor = Color.Red,
                HeightResizePolicy = ResizePolicy.FillToParent,
                WidthResizePolicy = ResizePolicy.FillToParent
            };
            view1.SetPadding(100);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ViewPaddingTest",
                FontSize = 30,
            });
            Add(new VStack
            {
                Children =
                {
                    new TextView
                    {
                        Text = "with View.Padding(100)",
                        FontSize = 20,
                    },
                    view1.HorizontalLayoutAlignment(LayoutAlignment.Start),
                    new TextView
                    {
                        Text = "without View.Padding",
                        FontSize = 20,
                    },
                    new ImageView
                    {
                        ResourceUrl = "img1.jpg",
                        BackgroundColor = Color.Blue,
                        HeightResizePolicy = ResizePolicy.FillToParent,
                        WidthResizePolicy = ResizePolicy.FillToParent
                    }
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
