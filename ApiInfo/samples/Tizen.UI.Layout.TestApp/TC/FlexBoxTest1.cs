using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest1 : Grid, ITestCase
    {
        public FlexBoxTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);
            BackgroundColor = Color.Beige;
            Add(new FlexBox
            {
                Direction = FlexDirection.Column,
                AlignItems = FlexAlignItems.Center,
                JustifyContent = FlexJustify.SpaceEvenly,
                Children =
                {
                    new TextView
                    {
                        Text = "FlexBox in Action",
                        FontSize = 30,
                    },
                    new ImageView
                    {
                        FittingMode = FittingMode.ScaleToFit,
                        ResourceUrl = "dotnet_bot.png",
                        DesiredHeight = 300
                    },
                    new TextView
                    {
                        Text = "not button",
                        TextColor = Color.White,
                        VerticalAlignment = TextAlignment.Center,
                        HorizontalAlignment = TextAlignment.Center,
                        CornerRadius = new CornerRadius(20),
                        BackgroundColor = Color.Blue,
                        DesiredHeight = 70,
                        DesiredWidth = 200,
                    },
                    new TextView
                    {
                        Text = "Another TextView"
                    }
                }
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
