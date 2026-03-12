using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class StateManagementTest : ContentView, INavigationTransition, ITestCase
    {
        private readonly int fontSize = 16;
        private readonly float padding = 100f;

        public StateManagementTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            Body = new VStack()
            {
                Padding = new Thickness(padding),
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20f,
                Children =
                {
                    new Label()
                    {
                        Text = "1. Simple case",
                        FontSize = fontSize,
                    }
                    .CenterHorizontal(),
                    new View()
                    {
                        DesiredWidth = 100f,
                        DesiredHeight = 100f,
                    }
                    .When(UIState.Disabled, (o, _) => o.BackgroundColor = Color.Gray)
                    .When(UIState.Disabled.Excluded, (o, _) => o.BackgroundColor = Color.Cyan)
                    .Self(out var target1),
                    new ClickableHStack()
                    {
                        Spacing = 4f,
                        ItemAlignment = LayoutAlignment.Center,
                        Children =
                        {
                            new Label("Enabled/Disabled")
                            {
                                FontSize = fontSize,
                            }
                            .Center(),
                            new Switch()
                            {
                                SelectedChangedCommand = (_, _) => target1.IsEnabled = !target1.IsEnabled,
                            }
                            .Center()
                            .Self(out var disableSwitch1),
                        },
                        ClickedCommand = (_, e) => disableSwitch1.Toggle(e.InputDevice)
                    },
                    new Label()
                    {
                        Text = "2. Complicate case",
                        FontSize = fontSize,
                    }
                    .CenterHorizontal(),
                    new SelectableHStack()
                    {
                        Children =
                        {
                            new Label()
                            {
                                Text = "Click! (Unselected)",
                                FontSize = fontSize,
                            }
                            .TextPadding(20f)
                            .Self(out var label),
                        },
                        SelectedChangedCommand = (o, _) => label.Text = ((Selectable)o).IsSelected ? "Click! (Selected)" : "Click! (Unselected)",
                    }
                    .Center()
                    .When((o, e) =>
                    {
                        if (e.Test(UIState.Disabled))
                        {
                            o.BackgroundColor = Color.Gray;
                        }
                        else if (e.Test(UIState.Selected))
                        {
                            o.BackgroundColor = Color.Yellow;
                        }
                        else
                        {
                            o.BackgroundColor = Color.Cyan;
                        }
                    })
                    .Self(out var target2),
                    new HStack()
                    {
                        Spacing = 12f,
                        Children =
                        {
                            new ClickableHStack()
                            {
                                Spacing = 4f,
                                ItemAlignment = LayoutAlignment.Center,
                                Children =
                                {
                                    new Label("Enabled/Disabled")
                                    {
                                        FontSize = fontSize,
                                    }
                                    .Center(),
                                    new Switch()
                                    {
                                        SelectedChangedCommand = (_, _) => target2.IsEnabled = !target2.IsEnabled,
                                    }
                                    .Center()
                                .Self(out var disableSwitch2),
                                },
                                ClickedCommand = (_, e) => disableSwitch2.Toggle(e.InputDevice)
                            },
                        }
                    }.Center()
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
