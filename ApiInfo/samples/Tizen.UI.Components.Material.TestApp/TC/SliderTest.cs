using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class SliderTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;
        private const float s_smallFontSize = 16f;
        private readonly float _rangeMin = -10;
        private readonly float _rangeMax = 10;

        public SliderTest() : base()
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
                        Text = "1. Normal slider",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new Label("ready")
                    {
                        FontSize = s_smallFontSize,
                        TextColor = MaterialColor.Primary,
                    }
                    .CenterHorizontal()
                    .Self(out var stateLabel1),
                    new Slider(_rangeMin, _rangeMax)
                    {
                        Value = 0f,
                    }
                    .Self(out var slider1)
                    .Self((_) =>
                    {
                        slider1.ValueChangeStarted += (_, _) => stateLabel1.Text = "Changing...";
                        slider1.ValueChangeFinished += (_, _) => stateLabel1.Text = "Ready";
                    }),
                    new HStack()
                    {
                        Spacing = 10f,
                        ItemAlignment = LayoutAlignment.Center,
                        Children =
                        {
                            new Button("<")
                            {
                                BackgroundColor = MaterialColor.OnSurfaceContainerHigher,
                                TextColor = MaterialColor.SurfaceContainerLowest,
                                FontSize = s_fontSize,
                                ClickedCommand = (s, e) => slider1.Value = Math.Max(_rangeMin, slider1.Value - 1f)
                            },
                            new Label(_rangeMin.ToString("0.##"))
                            {
                                TextColor = s_fontColor,
                                HorizontalAlignment = TextAlignment.Center,
                                VerticalAlignment = TextAlignment.Center,
                            }
                            .MinimumWidth(80f)
                            .Self(out var valueLabel1)
                            .Self((_) =>
                            {
                                slider1.ValueChanged += (_, _) => valueLabel1.Text = slider1.Value.ToString("0.##");
                            }),
                            new Button(">")
                            {
                                BackgroundColor = MaterialColor.OnSurfaceContainerHigher,
                                TextColor = MaterialColor.SurfaceContainerLowest,
                                FontSize = s_fontSize,
                                ClickedCommand = (s, e) => slider1.Value = Math.Min(_rangeMax, slider1.Value + 1f)
                            }
                        }
                    },
                    new Label()
                    {
                        Text = "2. Custom slider",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new CustomSlider(_rangeMin, _rangeMax)
                    {
                        Value = 0f,
                        Padding = new (0, 55f, 0, 0)
                    },
                    new Label()
                    {
                        Text = "3. Level bar",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new LevelBar(_rangeMin, _rangeMax, 5),
                    new Label()
                    {
                        Text = "4. Custom level bar",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new CustomLevelBar(_rangeMin, _rangeMax, 5)
                    {
                        Padding = new (0, 35f, 0f, 20f)
                    },
                    new Label()
                    {
                        Text = "5. Define a new slider",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new SimpleSlider(_rangeMin, _rangeMax)
                    {
                        Value = 0f,
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
    }

    internal class CustomSlider : Slider
    {
        private readonly Label _tooltip = new Label()
        {
            Width = 48f,
            Height = 44f,
            FontSize = 18f,
            TextColor = MaterialColor.InverseOnSurface,
            BackgroundColor = MaterialColor.InverseSurface,
            CornerRadius = 0.5f,
            HorizontalAlignment = TextAlignment.Center,
            VerticalAlignment = TextAlignment.Center,
        }
        .TextPadding(new Thickness(5f));

        public CustomSlider(float minValue, float maxValue) : base(minValue, maxValue)
        {
            this.AttachChild(_tooltip);
            _tooltip.Text = minValue.ToString("0.#");
        }

        protected override void OnTrailUpdated(float x, float y)
        {
            _tooltip.Text = Value.ToString("0.#");
            _tooltip.X = x - _tooltip.Width / 2f;
            _tooltip.Y = y - 20f - _tooltip.Height;
        }

        protected override void PlayInteractionStartedEffect(KeyDeviceClass device)
        {
            // disable animation
        }

        protected override void OnTrailAdded(View trail)
        {
            trail.SetBackground(SampleGradient.CreateLinearSample());
        }

        protected override void OnHandleAdded(View handle)
        {
            handle.IsVisible = false;
        }
    }

    internal class CustomLevelBar : LevelBar
    {
        private readonly Dictionary<int, View> _indice = new ();

        private readonly Label _tooltip = new Label()
        {
            Width = 60f,
            HeightResizePolicy = ResizePolicy.UseNaturalSize,
            FontSize = 18f,
            TextColor = MaterialColor.SurfaceContainer,
            BackgroundColor = MaterialColor.OnSurface,
            CornerRadius = 0.5f,
            HorizontalAlignment = TextAlignment.Center,
        }
        .TextPadding(new Thickness(5f));

        public CustomLevelBar(float minValue, float maxValue, int valueStepCount) : base(minValue, maxValue, valueStepCount)
        {
            this.AttachChild(_tooltip);
            _tooltip.Text = minValue.ToString("0.#");
        }

        protected override void OnTrailUpdated(float x, float y)
        {
            _tooltip.Text = Value.ToString("0.#");
            _tooltip.X = x - _tooltip.Width / 2f;
            _tooltip.Y = y - 50f;
        }

        protected override void OnTrailAdded(View trail)
        {
            trail.SetBackground(SampleGradient.CreateLinearSample());
        }

        protected override void OnHandleAdded(View handle)
        {
            handle.BorderlineWidth = 0f;
            handle.BackgroundColor = Color.White;
            handle.SetShadow(new Shadow()
            {
                BlurRadius = 10f,
                Color = Color.Gray,
                Offset = new Point(2f, 2f)
            });
        }

        protected override void OnDividerAdded(int index)
        {
            this.AttachChild(_indice[index] = new Label()
            {
                FontSize = 16f,
                Width = 40f,
                Height = 20f,
                HorizontalAlignment = TextAlignment.Center,
                TextColor = MaterialColor.OnSurface,
                Text = GetValueInStep(index).ToString(),
                PivotPoint = OriginPoint.Center,
                PositionUsesPivotPoint = true
            });
        }

        protected override void OnDividerUpdated(int index, float x, float y)
        {
            _indice[index].X = x;
            _indice[index].Y = y + 26f;
        }
    }

    internal class SimpleSlider : InteractiveProgress
    {
        private const float c_trackThickness = 20f;
        private readonly View _trail;
        private Size _currentSize;

        public SimpleSlider(float minValue, float maxValue) : base(minValue, maxValue)
        {
            this.Fill();
            DesiredHeight = c_trackThickness;
            BackgroundColor = MaterialColor.OrangeBright;

            Body = new Grid()
            {
                Children =
                {
                    new View()
                    {
                        DesiredWidth = 0,
                        BackgroundColor = MaterialColor.Red,
                    }
                    .Self(out _trail).FillVertical().StartHorizontal()
                }
            };

            Relayout += OnTrackRelayout;
        }

        protected override void OnValueRatioChanged(KeyDeviceClass device) => UpdateTrail(Width);

        private void OnTrackRelayout(object sender, EventArgs e)
        {
            Size newSize = new(Width, Height);
            if (_currentSize != newSize)
            {
                _currentSize = newSize;
                UpdateTrail(newSize.Width);
            }
        }

        private void UpdateTrail(float width)
        {
            _trail.DesiredWidth = width <= 0 ? 0f : width * ValueRatio;
        }
    }
}
