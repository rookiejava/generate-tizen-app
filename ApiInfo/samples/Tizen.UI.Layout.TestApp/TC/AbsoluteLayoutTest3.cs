using System;
using Tizen.UI;
using Tizen.UI.Components.Animations;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class AbsoluteLayoutTest3 : Grid, ITestCase
    {
        public AbsoluteLayoutTest3()
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
                Text = "AbsoluteLayout Test3",
                FontSize = 30,
            });

            Add(
                new AbsoluteLayout {
                    new AbsoluteLayout()
                    {
                        Name = "Abs1",
                        BackgroundColor = Color.Blue,
                        Children =
                        {
                            new View()
                            {
                                BackgroundColor = Color.Red,
                                DesiredHeight = 100,
                                DesiredWidth = 100,
                                CornerRadius = 0.5f
                            }
                        },
                        Padding = 20
                    }.LayoutBounds(0.5f , 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
            }.Row(1));

            Console.WriteLine($"Abs1 measured : {this["Abs1"].Measure(500, 500)}");
            Console.WriteLine($"Abs1 measured : {this["Abs1"].Measure(float.PositiveInfinity, float.PositiveInfinity)}");

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
