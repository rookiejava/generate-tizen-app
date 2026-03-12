using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ResponsiveLayoutTest : ViewGroup, ITestCase
    {
        public ResponsiveLayoutTest()
        {
            Name = "Outter";
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Vertical,
                Content = new Grid
                {
                    Name = "MAIN",
                    RowSpacing = 5,
                    ColumnSpacing = 5,
                }
            });
            var grid = this["MAIN"] as Grid;

            grid.Add(CreateMovieContent());
            grid.Add(CreateLeftFlyout());
            grid.Add(CreateCommentList());

            if (IsMobileWidth)
            {
                IsMoble = true;
                SetupMobileView(grid);

            }
            else
            {
                SetupDesktopView(grid);
            }
            Relayout += OnRelayout;
        }

        bool IsMoble { get; set; }
        bool IsMobileWidth => Window.Default.GetClientSize().Width <= 1200;

        void OnRelayout(object sender, EventArgs e)
        {
            if (IsMobileWidth && !IsMoble)
            {
                IsMoble = true;
                SetupMobileView(this["MAIN"] as Grid);
            }
            else if (!IsMobileWidth && IsMoble)
            {
                IsMoble = false;
                SetupDesktopView(this["MAIN"] as Grid);
            }
        }

        void SetupDesktopView(Grid grid)
        {
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            grid.RowDefinitions.Add(GridLength.Auto);
            grid.RowDefinitions.Add(GridLength.Star);

            grid.ColumnDefinitions.Add(GridLength.Star);
            grid.ColumnDefinitions.Add(500);

            grid["MovieContent"].Row(0).RowSpan(1).Column(0).ColumnSpan(1);
            grid["LeftFlyout"].Row(0).RowSpan(2).Column(1).ColumnSpan(1);
            grid["Comments"].Row(1).RowSpan(1).Column(0).ColumnSpan(1);
            grid.SendMeasureInvalidated();
        }

        void SetupMobileView(Grid grid)
        {
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            grid.RowDefinitions.Add(GridLength.Auto);
            grid.RowDefinitions.Add(GridLength.Auto);
            grid.RowDefinitions.Add(GridLength.Auto);

            grid.ColumnDefinitions.Add(GridLength.Star);

            grid["MovieContent"].Row(0).RowSpan(1).Column(0).ColumnSpan(1);
            grid["LeftFlyout"].Row(1).RowSpan(0).Column(0).ColumnSpan(1);
            grid["Comments"].Row(2).RowSpan(1).Column(0).ColumnSpan(1);
            grid.SendMeasureInvalidated();
        }

        View CreateMovieContent()
        {
            return new ScaledImageView
            {
                Name = "MovieContent",
                CornerRadius = 0.1f,
                BorderlineColor = Color.Gray,
                BorderlineWidth = 1,
                BorderlineOffset = 1,
                FittingMode = FittingMode.ScaleToFill,
                ResourceUrl = "animated.gif"
            }.Margin(10);
        }

        View CreateLeftFlyout()
        {
            return new VStack
            {
                Name = "LeftFlyout",
                Spacing = 5,
                Children =
                {
                    CreateHList(),
                    CreateVList(),
                }
            }.Margin(10);
        }

        View CreateHList()
        {
            return new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Horizontal,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                Content = new HStack
                {
                    Spacing = 5,
                    Children =
                    {
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                        CreateCardView(),
                    }
                }
            };
        }

        View CreateVList()
        {
            return new VStack
            {
                Spacing = 5,
                Children =
                {
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                    CreateHCardView(),
                }
            };
        }

        View CreateHCardView()
        {
            Random random = new Random();
            return new HStack
            {
                CornerRadius = 0.1f,
                BackgroundColor = Color.White,
                DesiredHeight = 200,
                Children =
                {
                    new View
                    {
                        CornerRadius = 0.1f,
                        DesiredWidth = 300,
                        BackgroundColor = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()),
                    },
                    new VStack
                    {
                        Spacing = 3,
                        Children =
                        {
                            new TextView { Text = "Title ... ", FontSize = 30 },
                            new TextView { Text = "details ... ", FontSize = 20 },
                        }
                    }.Margin(20),
                }
            };
        }

        View CreateCardView()
        {
            Random random = new Random();
            return new VStack
            {
                DesiredWidth = 200,
                ClippingMode = ClippingMode.ClipChildren,
                BackgroundColor = Color.White,
                CornerRadius = 0.1f,
                Children =
                {
                    new View
                    {
                        CornerRadius = 0.1f,
                        DesiredHeight = 300,
                        BackgroundColor = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()),
                    },
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Text... Text."
                    }.Margin(10)
                }
            };
        }

        View CreateCommentList()
        {
            return new VStack
            {
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
                CreateComment(),
            }.Spacing(10).Margin(10).Name("Comments");
        }

        View CreateComment()
        {
            return new HStack
            {
                CornerRadius = 0.1f,
                BackgroundColor = Color.White,
                Spacing = 10,
                Children =
                {
                    new View
                    {
                        DesiredHeight = 60,
                        DesiredWidth = 60,
                        CornerRadius = 1,
                        BackgroundColor = Color.Green,
                    }.VerticalLayoutAlignment(LayoutAlignment.Start).Margin(20),
                    new VStack
                    {
                        new TextView { Text = "@UserName", FontSize = 30 },
                        new TextView { Text = "~~~ text ... asdfasf asdfasfda dasfasfd dsfasfasfd\n asfdsadfa asdfafdsaf asfdasfd  asfdsadfa\n asdfafdsaf asfdasfd \n asfdsadfa asdfafdsaf asfdasfd", FontSize = 20, IsMultiline = true, TextOverflow = TextOverflow.Clip },
                    }.Margin(20),
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

        class ScaledImageView : ImageView
        {
            public override Size Measure(float availableWidth, float availableHeight)
            {
                if (!float.IsInfinity(availableWidth))
                {
                    return new Size(availableWidth, availableWidth * 0.5f);
                }
                return base.Measure(availableWidth, availableHeight);
            }
        }
    }
}
