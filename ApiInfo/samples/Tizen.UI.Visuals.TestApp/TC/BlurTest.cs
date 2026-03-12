using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Visuals;

namespace VisualObjectTest.TC
{
    class BlurTest1: Grid, ITestCase
    {
        public BlurTest1()
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
                Text = "Blur Cutout Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                Name = "VStack",
                Children =
                {
                    new TextView{ Text ="CutoutView", FontSize = 20 },
                    new HStack
                    {
                        new View
                        {
                            DesiredHeight = 200,
                            DesiredWidth = 300,
                            BackgroundColor = Color.White,
                            CornerRadius = 1,
                        }.Margin(10).Add(new ColorVisual
                        {
                            Color = Color.Green,
                            BlurRadius = 10,
                            CornerRadius = 1,
                            CutoutPolicy = VisualCutoutPolicy.ViewInside,
                        }),
                        new View
                        {
                            DesiredHeight = 200,
                            DesiredWidth = 300,
                            BackgroundColor = Color.White,
                        }.Margin(10).Add(new ColorVisual
                        {
                            Color = Color.Green,
                            BlurRadius = 10,
                            CutoutPolicy = VisualCutoutPolicy.ViewInside,
                        }),
                    },

#if API13_OR_GREATER
                    new TextView{ Text ="CutoutOutside", FontSize = 20 },
                    new HStack
                    {
                        new View
                        {
                            DesiredHeight = 200,
                            DesiredWidth = 300,
                            BackgroundColor = Color.White,
                            CornerRadius = 1,
                        }.Margin(10).Add(new ColorVisual
                        {
                            Color = Color.Green,
                            BlurRadius = 10,
                            CornerRadius = 1,
                            CutoutPolicy = VisualCutoutPolicy.ViewOutside,
                        }),
                        new View
                        {
                            DesiredHeight = 200,
                            DesiredWidth = 300,
                            BackgroundColor = Color.White,
                        }.Margin(10).Add(new ColorVisual
                        {
                            Color = Color.Green,
                            BlurRadius = 10,
                            CutoutPolicy = VisualCutoutPolicy.ViewOutside,
                        }),
                    },
#endif
                }
            }.Row(1).Spacing(10));

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
