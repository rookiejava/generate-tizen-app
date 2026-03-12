using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class ButtonTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;
        private int _longKeyBlockedButtonClickedCount;

        public ButtonTest() : base()
        {
            this.Fill();
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                Spacing = 20f,
                Padding = new(0f, 100f),
                Children =
                {
                    new Label()
                    {
                        Text = "1. Button with single text (contained/flat)",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("Button")
                    {
                        ClickedCommand = (s, e) => (s as Button).IsProgressing = true,
                    }.CenterHorizontal(),
                    new Button("Flat button", ButtonVariables.Flat)
                    {
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked",
                    }.CenterHorizontal(),
                    new HStack()
                    {
                        Spacing = 20f,
                        Children =
                        {
                            new Button("Hello")
                            {
                                ClickedCommand = (s, e) => (s as Button).Text = "Clicked",
                            }
                            .Self(out var helloButton),
                            // TODO Enable code after implement Switch
                            // new Switch()
                            // {
                            //     SelectedChangedCommand = (s, e) => helloButton.IsProgressing = !helloButton.IsProgressing
                            // }
                        }
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "2. Modify padding (contained/flat)",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("Hello")
                    {
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked!",
                        Padding = new Thickness(30f)
                    }.CenterHorizontal(),
                    new Button("Hello", ButtonVariables.Flat)
                    {
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked!",
                        Padding = new Thickness(30f),
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "3. Circle button",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new HStack()
                    {
                        Spacing = 20f,
                        Children =
                        {
                            new CircleButton(MaterialIcon.Home)
                            {
                                ClickedCommand = (s, e) => (s as CircleButton).IsProgressing = true
                            }
                            .Self(out var helloButton2),
                            // TODO Enable code after implement Switch
                            // new Switch()
                            // {
                            //     SelectedChangedCommand = (s, e) => helloButton2.IsProgressing = !helloButton2.IsProgressing
                            // }
                        }
                    }
                    .Center(),
                    new Label()
                    {
                        Text = "4. IconButton",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new IconButton(MaterialIcon.Lock)
                    {
                        IconMultipliedColor = MaterialColor.Primary
                    }.CenterHorizontal(),
                    new IconButton(MaterialIcon.Add, IconButtonVariables.FAB)
                    {
                        IconMultipliedColor = MaterialColor.Primary,
                        ClickedCommand = (s, e) =>
                        {
                            (s as IconButton).CornerRadius = CornerRadius.Zero;
                        }
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "5. Button with limited size (min/max)",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("Hello World")
                    {
                        ClickedCommand = (o, _) =>
                        {
                            if (o is Button minButton)
                            {
                                minButton.MinimumWidth(minButton.LayoutParam().MinimumWidth + 10f);
                            }
                        }
                    }
                    .CenterHorizontal()
                    .MinimumWidth(400f),
                    new Button("Hello World Hello World Hello World")
                    {
                        ClickedCommand = (o, _) =>
                        {
                            if (o is Button maxButton)
                            {
                                maxButton.MaximumWidth(maxButton.LayoutParam().MaximumWidth - 10f);
                            }
                        }
                    }
                    .CenterHorizontal()
                    .MaximumWidth(200f)
                    .MaximumHeight(1000f),
                    new Label()
                    {
                        Text = "6. Button with fixed size",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("Hello World")
                    {
                        DesiredWidth = 250f,
                        DesiredHeight = 60f,
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked!"
                    }.CenterHorizontal(),
                    new Button("Hello World")
                    {
                        DesiredWidth = 80f,
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked!"
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "7. Long touch press blocks click",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("No block")
                    {
                        LongPressedCommand = (s, e) => e.Handled = false,
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked"
                    }.CenterHorizontal(),
                    new Button("Block")
                    {
                        LongPressedCommand = (s, e) => e.Handled = true,
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked"
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "8. Long key press blocks click",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("No block")
                    {
                        ClickKeyType = ClickKeyType.Release,
                        LongPressedCommand = (s, e) => e.Handled = false,
                        ClickedCommand = (s, e) => (s as Button).Text = "Clicked"
                    }.CenterHorizontal(),
                    new Button("Block")
                    {
                        ClickKeyType = ClickKeyType.Release,
                        LongPressedCommand = (s, e) => e.Handled = true,
                        ClickedCommand = (s, e) =>
                        {
                            _longKeyBlockedButtonClickedCount++;
                            (s as Button).Text = $"Clicked {_longKeyBlockedButtonClickedCount}";
                        }
                    }.CenterHorizontal()
                }
            }
            .FillHorizontal();
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
