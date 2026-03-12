using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Internal;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class ProgressCircleTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private readonly float _fontSize = 20f;

        public ProgressCircleTest() : base()
        {
            this.Fill();
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
                        Text = "1. Normal progress circle",
                        FontSize = _fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new ProgressCircle(0, 100)
                    {
                        DesiredWidth = 100f,
                        DesiredHeight = 100f,
                        Value = 50
                    }
                    .CenterHorizontal()
                    .Self(out var progressCircle1),
                    new Slider(0, 100)
                    {
                        DesiredWidth = 200f,
                        Padding = new (0f, 0f, 0f, 20f),
                        Value = progressCircle1.Value
                    }
                    .CenterHorizontal()
                    .Self((slider1) =>
                    {
                        slider1.ValueChanged += (_, _) => progressCircle1.Value = slider1.Value;
                    }),
                    new Button("Switch indeterminate")
                    {
                        FontSize = _fontSize,
                        ClickedCommand = (s, _) => progressCircle1.IsDeterminate = !progressCircle1.IsDeterminate,
                    }
                    .CenterHorizontal()
                    .Margin(0f, 0f, 0f, 20f),
                    new Label()
                    {
                        Text = "2. Progress circle coloring",
                        FontSize = _fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new AbsoluteLayout()
                    {
                        new Label("0")
                        {
                            FontSize = _fontSize,
                            TextColor = s_fontColor
                        }
                        .LayoutBounds(0.5f, 0.5f, -1, -1)
                        .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                        .Self(out var label2),
                        new ProgressCircle(0, 100)
                        {
                            DesiredWidth = 100f,
                            DesiredHeight = 100f,
                            Value = 50
                        }
                        .LayoutBounds(0.5f, 0.5f, -1, -1)
                        .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                        .Self(out var progressCircle2)
                        .Self((_) =>
                        {
                            progressCircle2.ValueChanged += (s, e) =>
                            {
                                label2.Text = progressCircle2.Value.ToString("0");
                                progressCircle2.TrailColor = progressCircle2.Value < 25 ? MaterialColor.Red : MaterialColor.Primary;
                            };
                        })
                    },
                    new Slider(0, 100)
                    {
                        DesiredWidth = 200f,
                        Padding = new (0f, 0f, 0f, 20f),
                        Value = progressCircle2.Value
                    }
                    .CenterHorizontal()
                    .Self((slider2) =>
                    {
                        slider2.ValueChanged += (_, _) => progressCircle2.Value = slider2.Value;
                    }),
                    new Label()
                    {
                        Text = "3. Define a new progress with lottie",
                        FontSize = _fontSize,
                        TextColor = s_fontColor
                    }
                    .CenterHorizontal(),
                    new SimpleLottieProgress(0, 100)
                    {
                        DesiredWidth = 80f,
                        DesiredHeight = 80f,
                    }
                    .CenterHorizontal()
                    .Self(out var progress3),
                    new Slider(0, 100)
                    {
                        DesiredWidth = 200f,
                        Padding = new (0f, 0f, 0f, 20f)
                    }
                    .CenterHorizontal()
                    .Self((slider3) =>
                    {
                        slider3.ValueChanged += (_, _) => progress3.Value = slider3.Value;
                    }),
                    new Button("Switch indeterminate")
                    {
                        FontSize = _fontSize,
                        ClickedCommand = (s, _) => progress3.IsDeterminate = !progress3.IsDeterminate,
                    }
                    .CenterHorizontal()
                    .Margin(0f, 0f, 0f, 20f)
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

        private class SimpleLottieProgress : LottieImageProgress
        {
            public SimpleLottieProgress(float minValue, float maxValue) : base(minValue, maxValue)
            {
            }

            protected override string GetDeterminateImageUrl() => ResourceManager.GetPath("progress_determinate_sample.json");

            protected override string GetIndeterminateImageUrl() => ResourceManager.GetPath("progress_indeterminate_sample.json");
        }
    }
}
