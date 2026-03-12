using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class IMEOpenCloseTest : ContentView, INavigationTransition, ITestCase
    {
        const float IMEHeight = 500;
        public IMEOpenCloseTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Body = new Grid()
            {
                RowDefinitions =
                {
                    GridLength.Auto,
                    GridLength.Star,
                    150,
                },
                Children =
                {
                    new VStack
                    {
                        new Button("IME Open simulation")
                        {
                            ClickedCommand = (s, e) =>
                            {
                                var size = Window.Default.GetClientSize();
                                Window.Default.DefaultLayer.SetSize(size.Width, size.Height - IMEHeight);
                            }
                        },
                        new Button("IME close simulation")
                        {
                            ClickedCommand = (s, e) =>
                            {
                                var size = Window.Default.GetClientSize();
                                Window.Default.DefaultLayer.SetSize(size.Width, size.Height);
                            }
                        },
                        new Button("Clear focus")
                        {
                            ClickedCommand = (s, e) =>
                            {
                                FocusManager.Instance.ClearFocus();
                            }
                        },
                        new Label($" Page Size : {Width}x{Height}").Self(label =>
                        {
                            Relayout += (s, e) =>
                            {
                                label.Text = $"Page Size {Width}x{Height}";
                            };
                        }),
                    }.Spacing(10),

                    new View
                    {
                        DesiredHeight = 100,
                        DesiredWidth = 100,
                        BackgroundColor = Color.LightBlue,
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center).VerticalLayoutAlignment(LayoutAlignment.End).Row(1),
                    new InputField
                    {
                        DesiredHeight = 30,
                        DesiredWidth = 500,
                        BackgroundColor = Color.Gray,
                        BorderlineColor = Color.Blue,
                        BorderlineWidth = 1,
                    }.Self(input =>
                    {
                        input.InputMethodContext.InputPanelStateChanged += (s, e) =>
                        {
                            if (input.InputMethodContext.InputPanelState == InputPanelState.Show)
                            {
                                var size = Window.Default.GetClientSize();
                                var imeheight = input.InputMethodContext.InputMethodArea.Y;
                                Window.Default.DefaultLayer.SetSize(size.Width, imeheight);
                            }
                            else if (input.InputMethodContext.InputPanelState == InputPanelState.Hide)
                            {
                                var size = Window.Default.GetClientSize();
                                Window.Default.DefaultLayer.SetSize(size.Width, size.Height);
                            }
                        };
                    }).Row(1).VerticalLayoutAlignment(LayoutAlignment.End),
                },
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
            Dispose();
        }

        // TODO: This is temporary code until Tizen.UI.Components.Materail.Button is updated.
        private class AlertDialogButton : Grid
        {
            public AlertDialogButton(string text)
            {
                Focusable = true;
                FocusableInTouch = true;

                Add(new Label
                {
                    Name = "TextView",
                    Text = text,
                    VerticalAlignment = TextAlignment.Center,
                    HorizontalAlignment = TextAlignment.Center,
                });

                TouchEvent += (o, e) =>
                {
                    Clicked?.Invoke();
                    e.Handled = true;
                };
            }

            public string Text
            {
                get => (this["TextView"] as Label).Text;
                set => (this["TextView"] as Label).Text = value;
            }

            public Color TextColor
            {
                get => (this["TextView"] as Label).TextColor;
                set => (this["TextView"] as Label).TextColor = value;
            }

            public float FontSize
            {
                get => (this["TextView"] as Label).FontSize;
                set => (this["TextView"] as Label).FontSize = value;
            }

            public string FontFamily
            {
                get => (this["TextView"] as Label).FontFamily;
                set => (this["TextView"] as Label).FontFamily = value;
            }

            public Action Clicked { get; set; }
        }
    }
}
