using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class ProgressBarTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;
        private readonly float _rangeMin = -10;
        private readonly float _rangeMax = 10;

        public ProgressBarTest() : base()
        {
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20f,
                Padding = new (50f),
                Children =
                {
                    new Label()
                    {
                        Text = "1. Normal progress bar",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },
                    new ProgressBar(_rangeMin, _rangeMax)
                    {
                        DividerStepCount = 3
                    }
                    .Self(out var progressBar1),
                    new HStack()
                    {
                        Spacing = 10f,
                        ItemAlignment = LayoutAlignment.Center,
                        Children =
                        {
                            new Button("<")
                            {
                                ClickedCommand = (s, e) => progressBar1.Value = Math.Max(_rangeMin, progressBar1.Value - 1f)
                            },
                            new Label(_rangeMin.ToString())
                            {
                                TextColor = s_fontColor,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }
                            .MinimumWidth(80f)
                            .Self(out var valueLabel1)
                            .Self((_) => progressBar1.ValueChanged += (_, _) => valueLabel1.Text = progressBar1.Value.ToString()),
                            new Button(">")
                            {
                                ClickedCommand = (s, e) => progressBar1.Value = Math.Min(_rangeMax, progressBar1.Value + 1f)
                            },
                            new Button("Reverse")
                            {
                                ClickedCommand = (s, e) => progressBar1.IsReversed = !progressBar1.IsReversed
                            }
                        }
                    },
                    new Button()
                    {
                        FontSize = s_fontSize,
                        Text = "To indeterminate",
                        ClickedCommand = (s, e) =>
                        {
                            progressBar1.IsDeterminate = !progressBar1.IsDeterminate;

                            if (progressBar1.IsDeterminate)
                            {
                                (s as Button).Text = "To indeterminate";
                            }
                            else
                            {
                                (s as Button).Text = "To determinate";
                            }
                        }
                    },
                    new Label()
                    {
                        Text = "2. Discrete progress bar",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },
                    new ProgressBar(_rangeMin, _rangeMax)
                    {
                        ValueStepCount = 5
                    }
                    .Self(out var progressBar2),
                    new HStack()
                    {
                        Spacing = 10f,
                        ItemAlignment = LayoutAlignment.Center,
                        Children =
                        {
                            new Button("<")
                            {
                                ClickedCommand = (s, e) => progressBar2.Value = Math.Max(_rangeMin, progressBar2.Value - 3f)
                            },
                            new Label(_rangeMin.ToString())
                            {
                                TextColor = s_fontColor,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }
                            .MinimumWidth(80f)
                            .Self(out var valueLabel2)
                            .Self((_) => progressBar2.ValueChanged += (_, _) => valueLabel2.Text = progressBar2.Value.ToString()),
                            new Button(">")
                            {
                                ClickedCommand = (s, e) => progressBar2.Value = Math.Min(_rangeMax, progressBar2.Value + 3f)
                            }
                        }
                    },
                    new Label()
                    {
                        Text = "3. Customize progress bar with tag",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },
                    new Grid()
                    {
                        Padding = new Thickness(20f,50f),
                        Children =
                        {
                            new CustomProgressBar(_rangeMin, _rangeMax)
                            .Self(out var progressBar3)
                        }
                    },
                    new HStack()
                    {
                        Spacing = 10f,
                        ItemAlignment = LayoutAlignment.Center,
                        Children =
                        {
                            new Button("<")
                            {
                                ClickedCommand = (s, e) => progressBar3.Value = Math.Max(_rangeMin, progressBar3.Value - 2f)
                            },
                            new Label(_rangeMin.ToString())
                            {
                                TextColor = s_fontColor,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }
                            .MinimumWidth(80f)
                            .Self(out var valueLabel3)
                            .Self((_) => progressBar3.ValueChanged += (_, _) => valueLabel3.Text = progressBar3.Value.ToString()),
                            new Button(">")
                            {
                                ClickedCommand = (s, e) => progressBar3.Value = Math.Min(_rangeMax, progressBar3.Value + 2f)
                            }
                        }
                    },
                    new Label()
                    {
                        Text = "4. Create a new progress bar from the scratch",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },
                    new SimpleProgress(_rangeMin, _rangeMax).Self(out var progressBar4),
                    new HStack()
                    {
                        Spacing = 10f,
                        ItemAlignment = LayoutAlignment.Center,
                        Children =
                        {
                            new Button("<")
                            {
                                ClickedCommand = (s, e) => progressBar4.Value = Math.Max(_rangeMin, progressBar4.Value - 2f)
                            },
                            new Label(_rangeMin.ToString())
                            {
                                TextColor = s_fontColor,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }
                            .MinimumWidth(80f)
                            .Self(out var valueLabel4)
                            .Self((_) => progressBar4.ValueChanged += (_, _) => valueLabel4.Text = progressBar4.Value.ToString()),
                            new Button(">")
                            {
                                ClickedCommand = (s, e) => progressBar4.Value = Math.Min(_rangeMax, progressBar4.Value + 2f)
                            }
                        }
                    }
                }
            };
        }

        public void WillAppear(bool byPopNavigation)
        {
        }

        public void WillDisappear(bool byPopNavigation)
        {
        }

        public void DidAppear(bool byPopNavigation)
        {
        }

        public void DidDisappear(bool byPopNavigation)
        {
            if (byPopNavigation)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        private class CustomProgressBar : ProgressBar
        {
            private readonly Label _tooltip;

            public CustomProgressBar(float minValue, float maxValue) : base(minValue, maxValue)
            {
                RootLayout.Padding(20, 50, 20, 0);
                RootLayout.Children.Add(new Label()
                {
                    FontSize = 18f,
                    DesiredWidth = 38f,
                    TextColor = MaterialColor.SurfaceContainer,
                    BackgroundColor = MaterialColor.InverseSurfaceContainer,
                    CornerRadius = 0.5f,
                    HorizontalAlignment = TextAlignment.Center,
                }
                .LayoutBounds(0.0f, 0.0f, -1.0f, -1.0f)
                .Self(out _tooltip));
                _tooltip.Text = minValue.ToString();
            }

            protected override void OnTrailUpdated(float x, float y)
            {
                _tooltip.Text = Value.ToString();
                _tooltip.AbsoluteParam().LayoutBounds = _tooltip.AbsoluteParam().LayoutBounds with { X = x - _tooltip.Width / 2f, Y = y - 42f };
            }
        }

        private class SimpleProgress : Progress
        {
            private readonly float c_trackHeight = 20f;
            private readonly View _trail;

            public SimpleProgress(float minValue, float maxValue) : base(minValue, maxValue)
            {
                WidthResizePolicy = ResizePolicy.FillToParent;
                DesiredHeight = c_trackHeight;
                BackgroundColor = MaterialColor.OrangeBright;

                Body = new View()
                {
                    HeightResizePolicy = ResizePolicy.FillToParent,
                    BackgroundColor = MaterialColor.Red,
                }
                .Self(out _trail);

                Relayout += OnTrackRelayout;
            }

            protected override void OnValueRatioChanged(KeyDeviceClass device) => UpdateTrail();

            private void OnTrackRelayout(object sender, EventArgs e) => UpdateTrail();

            private void UpdateTrail()
            {
                _trail.Width = Width <= 0 ? 0f : Width * ValueRatio;
            }
        }
    }
}
