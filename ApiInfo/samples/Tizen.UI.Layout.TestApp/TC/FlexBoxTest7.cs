using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest7 : Grid, ITestCase
    {
        public FlexBoxTest7()
        {
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            BackgroundColor = Color.Beige;

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "FlexBox Test7",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new FlexBox
                {
                    Name = "Inner",
                    BackgroundColor = Color.Yellow,
                    DesiredWidth = 140,
                    Direction = FlexDirection.Row,
                    Wrap = FlexWrap.Wrap,
                    JustifyContent = FlexJustify.Center,
                    AlignItems = FlexAlignItems.Center,
                    Children =
                    {
                        new View
                        {
                                Name = "Green2",
                            BackgroundColor = Color.Green,
                            DesiredHeight = 50,
                            DesiredWidth = 50,
                        }.Margin(10),
                        new View
                        {
                            Name = "Green3",
                            BackgroundColor = Color.Green,
                            DesiredHeight = 50,
                            DesiredWidth = 50,
                        }.Margin(10),
                        new View
                        {
                            Name = "Green4",
                            BackgroundColor = Color.Green,
                            DesiredHeight = 50,
                            DesiredWidth = 50,
                        }.Margin(10),
                    }
                }.LayoutBounds(100, 100, -1, -1),
            }.Row(1));


            //var measrued = this["Inner"].Measure(float.PositiveInfinity, float.PositiveInfinity);
            //Console.WriteLine($"[FlexBoxTest4] measured size : {measrued}");

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
