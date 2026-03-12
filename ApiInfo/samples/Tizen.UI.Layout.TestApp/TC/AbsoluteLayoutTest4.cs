using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class AbsoluteLayoutTest4 : Grid, ITestCase
    {
        public AbsoluteLayoutTest4()
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
                Text = "Pivot/Origin vs AbsoluteLayout",
                FontSize = 30,
            });
            Add(new ScrollLayout
            {
                Content = new Grid
                {
                    ColumnDefinitions = { GridLength.Star, GridLength.Star },
                    Children =
                    {
                        new VStack
                        {
                            BackgroundColor = Color.LightBlue,
                            Children =
                            {
                                CreateCenterAlignViewWithPivot()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateTopCenterAlignViewWithPivot()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateTopRightAlignViewWithPivot()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateCenterLeftAlignViewWithPivot()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateCenterRightAlignViewWithPivot()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateBottomAlignViewWithPivot()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),
                            }
                        }.Column(0),
                        new VStack
                        {
                            BackgroundColor = Color.LightGreen,
                            Children =
                            {
                                CreateCenterAlignViewWithAbsoluteLayout()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateTopCenterAlignViewWithAbsoluteLayout()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateTopRightAlignViewWithAbsoluteLayout()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateCenterLeftAlignViewWithAbsoluteLayout()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateCenterRightAlignViewWithAbsoluteLayout()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),

                                CreateBottomAlignViewWithAbsoluteLayout()
                                .DesiredWidth(300)
                                .DesiredHeight(300)
                                .Margin(100),
                            }

                        }.Column(1)
                    }
                }
            }.Row(1));
        }

        View CreateCenterAlignViewWithPivot()
        {
            return new ViewGroup
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        ParentOrigin = OriginPoint.Center,
                        PivotPoint = OriginPoint.Center,
                        PositionUsesPivotPoint = true,
                        Width = 100,
                        Height = 100,
                        X = 0,
                        Y = 0,
                        BackgroundColor = Color.Green,
                    }
                }
            };
        }

        View CreateTopCenterAlignViewWithPivot()
        {
            return new ViewGroup
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        ParentOrigin = OriginPoint.TopCenter,
                        PivotPoint = OriginPoint.TopCenter,
                        PositionUsesPivotPoint = true,
                        Width = 100,
                        Height = 100,
                        X = 0,
                        Y = 0,
                        BackgroundColor = Color.Green,
                    }
                }
            };
        }

        View CreateTopRightAlignViewWithPivot()
        {
            return new ViewGroup
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        ParentOrigin = OriginPoint.TopRight,
                        PivotPoint = OriginPoint.TopRight,
                        PositionUsesPivotPoint = true,
                        Width = 100,
                        Height = 100,
                        X = 0,
                        Y = 0,
                        BackgroundColor = Color.Green,
                    }
                }
            };
        }

        View CreateCenterLeftAlignViewWithPivot()
        {
            return new ViewGroup
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        ParentOrigin = OriginPoint.CenterLeft,
                        PivotPoint = OriginPoint.CenterLeft,
                        PositionUsesPivotPoint = true,
                        Width = 100,
                        Height = 100,
                        X = 0,
                        Y = 0,
                        BackgroundColor = Color.Green,
                    }
                }
            };
        }

        View CreateCenterRightAlignViewWithPivot()
        {
            return new ViewGroup
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        ParentOrigin = OriginPoint.CenterRight,
                        PivotPoint = OriginPoint.CenterRight,
                        PositionUsesPivotPoint = true,
                        Width = 100,
                        Height = 100,
                        X = 0,
                        Y = 0,
                        BackgroundColor = Color.Green,
                    }
                }
            };
        }

        View CreateBottomAlignViewWithPivot()
        {
            return new ViewGroup
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        ParentOrigin = OriginPoint.BottomCenter,
                        PivotPoint = OriginPoint.BottomCenter,
                        PositionUsesPivotPoint = true,
                        Width = 100,
                        Height = 100,
                        X = 0,
                        Y = 0,
                        BackgroundColor = Color.Green,
                    }
                }
            };
        }

        View CreateCenterAlignViewWithAbsoluteLayout()
        {
            return new AbsoluteLayout
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue,
                    }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                }
            };
        }

        View CreateTopCenterAlignViewWithAbsoluteLayout()
        {
            return new AbsoluteLayout
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue,
                    }.LayoutBounds(0.5f, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                }
            };
        }

        View CreateTopRightAlignViewWithAbsoluteLayout()
        {
            return new AbsoluteLayout
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue,
                    }.LayoutBounds(1, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                }
            };
        }

        View CreateCenterLeftAlignViewWithAbsoluteLayout()
        {
            return new AbsoluteLayout
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue,
                    }.LayoutBounds(0, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                }
            };
        }

        View CreateCenterRightAlignViewWithAbsoluteLayout()
        {
            return new AbsoluteLayout
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue,
                    }.LayoutBounds(1, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                }
            };
        }

        View CreateBottomAlignViewWithAbsoluteLayout()
        {
            return new AbsoluteLayout
            {
                BackgroundColor = Color.White,
                Children =
                {
                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.Blue,
                    }.LayoutBounds(0.5f, 1, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                }
            };
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
