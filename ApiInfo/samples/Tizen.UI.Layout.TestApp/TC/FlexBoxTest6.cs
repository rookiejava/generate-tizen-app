using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest6 : FlexBox, ITestCase
    {
        public FlexBoxTest6()
        {
            BackgroundColor = Color.Beige;
            Padding = 10;
            Direction = FlexDirection.Column;
            JustifyContent = FlexJustify.Center;
            AlignItems = FlexAlignItems.Center;
            Children.Add(new View
            {
                BackgroundColor = Color.Red,
                DesiredHeight = 100,
            }.AlignSelf(FlexAlignSelf.Stretch).Margin(5));
            Children.Add(new View
            {
                BackgroundColor = Color.Green,
                DesiredHeight = 100,
                DesiredWidth = 100,
            }.Margin(5));
            Children.Add(new FlexBox
            {
                BackgroundColor = Color.Blue,
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.Center,
                AlignItems = FlexAlignItems.Center,
                Children =
                {
                    new View
                    {
                        BackgroundColor = Color.Green,
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                    }.Margin(5),
                    new View
                    {
                        BackgroundColor = Color.Green,
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                    }.Margin(5),
                }
            }.Margin(5));

            Children.Add(
                new Grid
                {
                    RowDefinitions = { GridLength.Auto },
                    ColumnDefinitions = { GridLength.Auto },
                    Children =
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
                        }.Margin(5)
                    }
                });

            //Children.Add(new FlexBox
            //{
            //    BackgroundColor = Color.Cyan,
            //    Direction = FlexDirection.Row,
            //    JustifyContent = FlexJustify.Center,
            //    AlignItems = FlexAlignItems.Center,
            //    DesiredWidth = 200,
            //    Children =
            //    {
            //        new View
            //        {
            //            BackgroundColor = Color.Green,
            //            DesiredHeight = 50,
            //            DesiredWidth = 50,
            //        }.Margin(5),
            //        new FlexBox
            //        {
            //            BackgroundColor = Color.Yellow,
            //            DesiredWidth = 90,
            //            Direction = FlexDirection.Row,
            //            Wrap = FlexWrap.Wrap,
            //            JustifyContent = FlexJustify.Center,
            //            AlignItems = FlexAlignItems.Center,
            //            Children =
            //            {
            //                new View
            //                {
            //                    BackgroundColor = Color.Green,
            //                    DesiredHeight = 50,
            //                    DesiredWidth = 50,
            //                }.Margin(5),
            //                new View
            //                {
            //                    BackgroundColor = Color.Green,
            //                    DesiredHeight = 50,
            //                    DesiredWidth = 50,
            //                }.Margin(5),
            //            }
            //        }.AlignSelf(FlexAlignSelf.Stretch).Margin(5),
            //    }
            //}.Margin(5));
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
