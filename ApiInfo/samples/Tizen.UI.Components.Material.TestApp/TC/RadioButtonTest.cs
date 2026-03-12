using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class RadioButtonTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;

        public RadioButtonTest() : base()
        {
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                Padding = new(0, 100),
                Spacing = 20f,
                Children =
                {
                    new Label("1. Single radio button")
                    {
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new RadioButton().CenterHorizontal(),
                    new Label("2. Radio button in a group (only buttons)")
                    {
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Label()
                    {
                        FontSize = s_fontSize,
                        TextColor = MaterialColor.Primary,
                    }
                    .CenterHorizontal()
                    .Self(out var selectionLabel),
                    new HStack()
                    {
                        Spacing = 10,
                        Children =
                        {
                            new RadioButton()
                            {
                                GroupName = "RadioGroup1"
                            },
                            new RadioButton()
                            {
                                IsSelected = true,
                                GroupName = "RadioGroup1"
                            },
                            new RadioButton()
                            {
                                GroupName = "RadioGroup1"
                            },
                            new RadioButton()
                            {
                                GroupName = "RadioGroup1"
                            },
                            new RadioButton()
                            {
                                GroupName = "RadioGroup1"
                            }
                            .Self((s) =>
                            {
                                selectionLabel.Text = $"{s.Group.SelectedIndex}th item is selected";
                                s.Group.SelectionChanged += (s, e) => selectionLabel.Text = $"{((SelectionGroup)s).SelectedIndex}th item is selected";
                            })
                        }
                    }.CenterHorizontal(),
                    new Label("3. Radio button with text")
                    {
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Label("No item selected")
                    {
                        FontSize = s_fontSize,
                        TextColor = MaterialColor.Primary,
                    }
                    .CenterHorizontal()
                    .Self(out var selectionLabel2),
                    new WithText("Item 1")
                    .CenterHorizontal(),
                    new WithText("Item 2")
                    .CenterHorizontal(),
                    new WithText("Item 3")
                    {
                        IsEnabled = false
                    }
                    .CenterHorizontal(),
                    new WithText("Item 4")
                    .CenterHorizontal(),
                    new WithText("Item 5")
                    .CenterHorizontal()
                    .Self((s) => s.Group.SelectionChanged += (s, e) => selectionLabel2.Text = $"{e.Current?.Name} is selected")
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

        private class WithText : GroupSelectable
        {
            private static readonly string s_groupName = "ComponentsTest.RadioButtonTest.WithText";

            public WithText(string text)
            {
                GroupName = s_groupName;
                Name = text;

                Body = new HStack()
                {
                    Spacing = 2f,
                    DesiredWidth = 300f,
                    Children =
                    {
                        new RadioButton()
                        {
                            IsClickable = false
                        }
                        .Self(out var radioButton)
                        .CenterVertical(),
                        new Label(text)
                        {
                            FontSize = s_fontSize,
                            TextColor = Color.Black
                        }
                        .Expand()
                        .FillHorizontal()
                        .CenterVertical()
                    }
                };

                BackgroundColor = new (0xEAEAEA, 1f);
                CornerRadius = new CornerRadius(0.25f);
                SelectedChanged += (s, e) => radioButton.Toggle(e.InputDevice);
            }
        }
    }
}
