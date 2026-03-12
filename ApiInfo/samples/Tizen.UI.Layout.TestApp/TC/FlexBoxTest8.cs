using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest8 : Grid, ITestCase
    {
        public FlexBoxTest8()
        {
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            BackgroundColor = Color.Beige;

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "FlexBox Test8",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new FlexBox
                {
                    BackgroundColor = Color.Cyan,
                    Direction = FlexDirection.Row,
                    JustifyContent = FlexJustify.Center,
                    AlignItems = FlexAlignItems.Center,
                    DesiredWidth = 200,
                    Children =
                    {
                        new View
                        {
                            BackgroundColor = Color.Green,
                            DesiredHeight = 50,
                            DesiredWidth = 50,
                        }.Margin(5),
                        new FlexBox
                        {
                            BackgroundColor = Color.Yellow,
                            DesiredWidth = 90,
                            Direction = FlexDirection.Row,
                            Wrap = FlexWrap.Wrap,
                            JustifyContent = FlexJustify.Center,
                            AlignItems = FlexAlignItems.Center,
                            Children =
                            {
                                new View
                                {
                                    BackgroundColor = Color.Green,
                                    DesiredHeight = 50,
                                    DesiredWidth = 50,
                                }.Margin(5),
                                new View
                                {
                                    BackgroundColor = Color.Green,
                                    DesiredHeight = 50,
                                    DesiredWidth = 50,
                                }.Margin(5),
                            }
                        }.AlignSelf(FlexAlignSelf.Stretch).Margin(5),
                    }
                }.Margin(5).LayoutBounds(100, 100, -1, -1),
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
