using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest5 : Grid, ITestCase
    {
        public FlexBoxTest5()
        {
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            BackgroundColor = Color.Beige;

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "FlexBox Test5",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new FlexBox
                {
                    Name = "FlexBox1",
                    BackgroundColor = Color.Green,
                    Direction = FlexDirection.Row,
                    Wrap = FlexWrap.Wrap,
                    Children =
                    {
                        new View
                        {
                            BackgroundColor = Color.Red,
                            DesiredWidth = 100,
                            DesiredHeight = 100,
                        }.Margin(10),
                        new View
                        {
                            DesiredWidth = 100,
                            DesiredHeight = 100,
                            BackgroundColor = Color.Yellow,
                        }.Margin(10).Basis(100).Grow(1).Shrink(0),
                        new View
                        {
                            BackgroundColor = Color.Red,
                            DesiredWidth = 100,
                            DesiredHeight = 100,
                        }.Margin(10),
                        new FlexBox
                        {
                            BackgroundColor = Color.Blue,
                            Direction = FlexDirection.Column,
                            Wrap = FlexWrap.Wrap,
                            Children =
                            {
                                new View
                                {
                                    BackgroundColor = Color.Red,
                                    DesiredWidth = 100,
                                    DesiredHeight = 100,
                                }.Margin(10),
                                new View
                                {
                                    BackgroundColor = Color.Red,
                                    DesiredWidth = 100,
                                    DesiredHeight = 100,
                                }.Margin(10),
                                new View
                                {
                                    BackgroundColor = Color.DarkBlue,
                                    DesiredWidth = 100,
                                    DesiredHeight = 100,
                                }.Margin(10),
                            }

                        }.MinimumWidth(250).Shrink(0),
                        new View
                        {
                            BackgroundColor = Color.Red,
                            DesiredWidth = 100,
                            DesiredHeight = 100,
                        }.Margin(10),
                    }
                }.LayoutBounds(0, 0, 500, -1),

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
