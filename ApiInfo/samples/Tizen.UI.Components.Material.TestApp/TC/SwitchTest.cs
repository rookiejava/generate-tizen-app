using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class SwitchTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;

        public SwitchTest() : base()
        {
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                Padding = new (0, 100f),
                Spacing = 20f,
                Children =
                {
#if USE_DUMMY_THEME_LOADER
                    new Button("Toggle theme")
                    {
                        FontSize = s_fontSize,
                        ClickedCommand = (s, e) => DummyThemeLoader.Instance.NextTheme(),
                    }.CenterHorizontal(),
#endif
                    new Label()
                    {
                        Text = "1. Disabled switch",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Switch()
                    {
                        IsEnabled = false
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "2. Normal switch",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Switch().CenterHorizontal(),
                    new Label()
                    {
                        Text = "3. Custom size switch",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Switch(SwitchVariables.Default with
                    {
                        TrackWidth = 45f,
                        TrackHeight = 28f
                    }).CenterHorizontal(),
                    new Label()
                    {
                        Text = "4. Switch with clickable container",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new ClickableHStack()
                    {
                        BackgroundColor = MaterialColor.Surface,
                        Padding = new (8f, 4f),
                        BorderlineColor = s_fontColor,
                        BorderlineWidth = 1f,
                        Children =
                        {
                            new Label("Unselected")
                            {
                                FontSize = s_fontSize,
                                TextColor = s_fontColor
                            }
                            .MinimumWidth(100)
                            .CenterVertical()
                            .Self(out var siblingText),
                            new Switch()
                            {
                                SelectedChangedCommand = (s, e) => siblingText.Text = (s as Switch).IsSelected ? "Selected" : "Unselected"
                            }
                            .CenterHorizontal()
                            .Self(out var switchChild)
                        },
                        ClickedCommand = (s, e) => switchChild.Toggle(e.InputDevice)
                    }
                    .CenterHorizontal()
                    .Self(out var clickableContainer)
                }
            }
            .FillHorizontal()
            .StartVertical();
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
