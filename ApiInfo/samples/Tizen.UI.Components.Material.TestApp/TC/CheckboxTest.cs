using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class CheckboxTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;

        public CheckboxTest() : base()
        {
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                Padding = new(0, 100),
                Spacing = 20f,
                Children =
                {
                    new Label("1. Single checkbox")
                    {
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Checkbox().Self(out var check1).CenterHorizontal(),
                    new Button("Toggle disable")
                    {
                        FontSize = s_fontSize,
                        ClickedCommand = (s, e) => check1.IsEnabled = !check1.IsEnabled
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "2. Checkbox with clickable container",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new ClickableHStack()
                    {
                        DesiredWidth = 200f,
                        BackgroundColor = MaterialColor.Surface,
                        BorderlineWidth = 1f,
                        BorderlineColor = Color.Gray,
                        CornerRadius = new (5f),
                        Padding = new (16f, 8f),
                        Children =
                        {
                            new Label("Unchecked")
                            {
                                FontSize = s_fontSize,
                                TextColor = s_fontColor,
                                VerticalAlignment = TextAlignment.Center
                            }
                            .Self(out var siblingText)
                            .Expand()
                            .Fill(),
                            new Checkbox()
                            {
                                SelectedChangedCommand = (s, e) => siblingText.Text = (s as Checkbox).IsSelected ? "Checked" : "Unchecked"
                            }
                            .Self(out var check2)
                        },
                        ClickedCommand = (s, e) => check2.Toggle(e.InputDevice)
                    }.CenterHorizontal()
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
