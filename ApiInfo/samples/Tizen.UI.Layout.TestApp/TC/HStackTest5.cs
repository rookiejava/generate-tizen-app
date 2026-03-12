using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class HStackTest5 : Grid, ITestCase
    {
        public HStackTest5()
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
                Text = "HStack size measure issue",
                FontSize = 30,
            });


            Add(new Grid
            {
                ColumnDefinitions =
                {
                    500,
                    GridLength.Star,
                },
                Children =
                {
                    new HStack
                    {
                        BorderlineWidth = 1,
                        BorderlineColor = Color.Black,
                        Children =
                        {
                            new TextView
                            {
                                FontSize = 30,
                                IsMultiline = true,
                                Text = "Very looooooooooooong text..... very loooooooooooooooong text, abcdefg hie image view label layuout grid stack vstack hstack, nui2, desiredsize, compute"
                            }
                        }
                    },

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
