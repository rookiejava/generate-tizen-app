#if USE_DUMMY_THEME_LOADER
#if USE_DUMMY_FONT_SCALE_LOADER
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class SystemSettingTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;

        public SystemSettingTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20f,
                WidthResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = MaterialColor.Background,
                Padding = new (0f, 100f),
                Children =
                {
                    new Image(MaterialIcon.DummyIcon)
                    {
                        DesiredWidth = 100f,
                        DesiredHeight = 100f,
                        MultipliedColor = MaterialColor.OnSurfaceContainerHighest
                    }
                    .Center(),
                    new Label()
                    {
                        Text = "1. Theme test",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor,
                    }
                    .Center(),
                    new Button("Toggle theme")
                    {
                        FontSize = s_fontSize,
                        ClickedCommand = (s, e) => DummyThemeLoader.Instance.NextTheme(),
                    }
                    .Center()
                    .Margin(0f, 0f, 0f, 10f),
                    new Label()
                    {
                        Text = "2. Font scale test",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }
                    .Center(),
                    new Label()
                    {
                        Text = "1",
                        FontSize = s_fontSize,
                        TextColor = MaterialColor.Primary
                    }
                    .Center()
                    .Self(out var _label),
                    new LevelBar(0.5f, 1.5f, 4)
                    {
                        Padding = new (20f, 0f),
                        Value = 1f
                    }
                    .Self((slider) =>
                    {
                        slider.ValueChanged += (_, _) =>
                        {
                            _label.Text = $"{slider.Value:F2}";
                            DummyFontScaleLoader.Instance.FontScale = slider.Value;
                        };
                    })
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
}
#endif
#endif
