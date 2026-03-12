using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class HStackTest4 : ViewGroup, ITestCase
    {
        public HStackTest4()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new LayeredLabel("abcd")
                    {
                        BackgroundColor = Color.Cornsilk,
                    },
                    new LayeredLabel("efg")
                    {
                        BackgroundColor = Color.Cornsilk,
                    },
                    new LayeredLabel("1253322")
                    {
                        BackgroundColor = Color.Cornsilk,
                    },
                    new LayeredLabel("222232323")
                    {
                        BackgroundColor = Color.Cornsilk,
                    },
                    new LayeredLabel("abdde")
                    {
                        BackgroundColor = Color.Cornsilk,
                    }
                }
            }.HorizontalLayoutAlignment(LayoutAlignment.Center));
        }

        class LayeredLabel : Grid
        {
            public LayeredLabel(string text)
            {
                ColumnDefinitions.Add(GridLength.Auto);
                RowDefinitions.Add(GridLength.Auto);
                Add(new TextView
                {
                    FontSize = 30,
                    Text = text
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
