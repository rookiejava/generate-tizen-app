using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest4 : Grid, ITestCase
    {
        public FlexBoxTest4()
        {
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            BackgroundColor = Color.Beige;

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "FlexBox Test4",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new FlexBox
                {
                    BackgroundColor = Color.Green,
                    Name= "Outter",
                    Direction = FlexDirection.Column,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {
                        new TextView
                        {
                            Name = "Text1",
                            BackgroundColor = Color.Gray,
                            FontSize = 20,
                            Text = "Hello world----- long"
                        },
                        new FlexBox
                        {
                            Direction = FlexDirection.Column,
                            Name = "Inner",
                            BackgroundColor = Color.Yellow,
                            AlignItems = FlexAlignItems.Start,
                            Children =
                            {
                                new TextView
                                {
                                    Name = "Text2",
                                    FontSize = 20,
                                    Text = "ABCDE"
                                },
                                new TextView
                                {
                                    Name = "Text3",
                                    FontSize = 20,
                                    Text = "abcde"
                                },
                                new FlexBox
                                {
                                    Name = "InnerInner",
                                    Direction = FlexDirection.Row,
                                    BackgroundColor = Color.Red,
                                    Children =
                                    {
                                        new View
                                        {
                                            Name = "GreenYellow",
                                            DesiredHeight = 30,
                                            DesiredWidth = 100,
                                            BackgroundColor = Color.GreenYellow,
                                        }.AlignSelf(FlexAlignSelf.End),
                                        new View
                                        {
                                            Name = "Cyan",
                                            DesiredHeight = 50,
                                            DesiredWidth = 100,
                                            BackgroundColor = Color.Cyan,
                                        },
                                    }
                                }.Grow(1)
                            }
                        },
                        new TextView
                        {
                            Name = "Text4",
                            BackgroundColor = Color.Blue,
                            FontSize = 20,
                            Text = "Hello world"
                        }
                    },
                }.LayoutBounds(0, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.None),

                new FlexBox
                {
                    BackgroundColor = Color.Green,
                    Name= "Outter",
                    Direction = FlexDirection.Column,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {

                        new TextView
                        {
                            Name = "Text1",
                            BackgroundColor = Color.Gray,
                            FontSize = 20,
                            Text = "Hello world----- long"
                        },
                        new FlexBox
                        {
                            Direction = FlexDirection.Column,
                            Name = "Inner",
                            BackgroundColor = Color.Yellow,
                            AlignItems = FlexAlignItems.Start,
                            Children =
                            {
                                new TextView
                                {
                                    Name = "Text2",
                                    FontSize = 20,
                                    Text = "ABCDE"
                                },
                                new TextView
                                {
                                    Name = "Text3",
                                    FontSize = 20,
                                    Text = "abcde"
                                },
                                new FlexBox
                                {
                                    Name = "InnerInner",
                                    Direction = FlexDirection.Row,
                                    BackgroundColor = Color.Red,
                                    Children =
                                    {
                                        new View
                                        {
                                            Name = "GreenYellow",
                                            DesiredHeight = 30,
                                            DesiredWidth = 100,
                                            BackgroundColor = Color.GreenYellow,
                                        }.AlignSelf(FlexAlignSelf.End),
                                        new View
                                        {
                                            Name = "Cyan",
                                            DesiredHeight = 50,
                                            DesiredWidth = 100,
                                            BackgroundColor = Color.Cyan,
                                        },
                                    }
                                }.Grow(1)
                            }
                        },
                        new TextView
                        {
                            Name = "Text4",
                            BackgroundColor = Color.Blue,
                            FontSize = 20,
                            Text = "Hello world"
                        }
                    },
                }.LayoutBounds(250, 0, 200, 150).LayoutFlags(AbsoluteLayoutFlags.None),

                new FlexBox
                {
                    BackgroundColor = Color.Green,
                    Name= "Outter",
                    Direction = FlexDirection.Column,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {

                        new TextView
                        {
                            BackgroundColor = Color.Gray,
                            FontSize = 20,
                            Text = "Hello world----- long"
                        },
                        new Grid
                        {
                            RowDefinitions = { GridLength.Auto },
                            ColumnDefinitions = { GridLength.Auto },
                            Children =
                            {
                                new FlexBox
                                {
                                    Direction = FlexDirection.Column,
                                    Name = "Inner",
                                    BackgroundColor = Color.Yellow,
                                    AlignItems = FlexAlignItems.Start,
                                    Children =
                                    {
                                        new TextView
                                        {
                                            FontSize = 20,
                                            Text = "ABCDE"
                                        },
                                        new TextView
                                        {
                                            FontSize = 20,
                                            Text = "abcde"
                                        },
                                        new Grid
                                        {
                                            RowDefinitions = { GridLength.Auto },
                                            ColumnDefinitions = { GridLength.Auto },
                                            Children =
                                            {
                                                new FlexBox
                                                {
                                                    Direction = FlexDirection.Row,
                                                    BackgroundColor = Color.Red,
                                                    Children =
                                                    {
                                                        new View
                                                        {
                                                            DesiredHeight = 30,
                                                            DesiredWidth = 100,
                                                            BackgroundColor = Color.GreenYellow,
                                                        }.AlignSelf(FlexAlignSelf.End),
                                                        new View
                                                        {
                                                            DesiredHeight = 50,
                                                            DesiredWidth = 100,
                                                            BackgroundColor = Color.Cyan,
                                                        },
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                            }
                        },
                        new TextView
                        {
                            BackgroundColor = Color.Blue,
                            FontSize = 20,
                            Text = "Hello world"
                        }
                    },
                }.LayoutBounds(500, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.None),

                new FlexBox
                {
                    BackgroundColor = Color.Green,
                    Name= "Outter",
                    Direction = FlexDirection.Column,
                    AlignItems = FlexAlignItems.Start,
                    Children =
                    {

                        new TextView
                        {
                            BackgroundColor = Color.Gray,
                            FontSize = 20,
                            Text = "Hello world----- long"
                        },
                        new Grid
                        {
                            RowDefinitions = { GridLength.Auto },
                            ColumnDefinitions = { GridLength.Auto },
                            Children =
                            {
                                new FlexBox
                                {
                                    Direction = FlexDirection.Column,
                                    Name = "Inner",
                                    BackgroundColor = Color.Yellow,
                                    AlignItems = FlexAlignItems.Start,
                                    Children =
                                    {
                                        new TextView
                                        {
                                            FontSize = 20,
                                            Text = "ABCDE"
                                        },
                                        new TextView
                                        {
                                            FontSize = 20,
                                            Text = "abcde"
                                        },
                                        new Grid
                                        {
                                            RowDefinitions = { GridLength.Auto },
                                            ColumnDefinitions = { GridLength.Auto },
                                            Children =
                                            {
                                                new FlexBox
                                                {
                                                    Direction = FlexDirection.Row,
                                                    BackgroundColor = Color.Red,
                                                    Children =
                                                    {
                                                        new View
                                                        {
                                                            DesiredHeight = 30,
                                                            DesiredWidth = 100,
                                                            BackgroundColor = Color.GreenYellow,
                                                        }.AlignSelf(FlexAlignSelf.End),
                                                        new View
                                                        {
                                                            DesiredHeight = 50,
                                                            DesiredWidth = 100,
                                                            BackgroundColor = Color.Cyan,
                                                        },
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                            }
                        },
                        new TextView
                        {
                            BackgroundColor = Color.Blue,
                            FontSize = 20,
                            Text = "Hello world"
                        }
                    },
                }.LayoutBounds(750, 0, 200, 150).LayoutFlags(AbsoluteLayoutFlags.None),

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
