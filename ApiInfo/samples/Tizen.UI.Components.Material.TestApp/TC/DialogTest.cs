using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class DialogTest : ContentView, INavigationTransition, ITestCase
    {
        public DialogTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Body = new VStack()
            {
                Spacing = 20f,
                Children =
                {
                    new Button("Show Dialog")
                    {
                        ClickedCommand = (s, e) =>
                        {
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = new Dialog
                                {
                                    HeaderView = new Label
                                    {
                                        Text = "Title",
                                        TextColor = MaterialColor.OnSurfaceContainerHighest,
                                        FontSize = MaterialFontSize.Lg,
                                        FontFamily = MaterialFont.Normal600,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    BodyView = new Label
                                    {
                                        IsMultiline = true,
                                        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                                        TextColor = MaterialColor.OnSurfaceContainerHigher,
                                        FontSize = MaterialFontSize.Sm,
                                        FontFamily = MaterialFont.Normal400,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    FooterView = new HStack()
                                    {
                                        Spacing = MaterialSpacing.Md400,
                                        Children =
                                        {
                                            new AlertDialogButton("Cancel")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                            new AlertDialogButton("OK")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                        }
                                    }.Margin(MaterialSpacing.Lg700, MaterialSpacing.Sm60, MaterialSpacing.Lg700, 0).EndHorizontal(),
                                }
                            });
                        }
                    },
                    new Button("Show Dialog at Center without Top 80Spx")
                    {
                        ClickedCommand = (s, e) =>
                        {
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = new Dialog
                                {
                                    HeaderView = new Label
                                    {
                                        Text = "Title",
                                        TextColor = MaterialColor.OnSurfaceContainerHighest,
                                        FontSize = MaterialFontSize.Lg,
                                        FontFamily = MaterialFont.Normal600,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    BodyView = new Label
                                    {
                                        IsMultiline = true,
                                        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                                        TextColor = MaterialColor.OnSurfaceContainerHigher,
                                        FontSize = MaterialFontSize.Sm,
                                        FontFamily = MaterialFont.Normal400,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    FooterView = new HStack()
                                    {
                                        Spacing = MaterialSpacing.Md400,
                                        Children =
                                        {
                                            new AlertDialogButton("Cancel")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                            new AlertDialogButton("OK")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                        }
                                    }.Margin(MaterialSpacing.Lg700, MaterialSpacing.Sm60, MaterialSpacing.Lg700, 0).EndHorizontal(),
                                },
                            }.Self(out var dialogContainer));
                            dialogContainer.Margin(0, 80f.Spx(), 0, 0);
                        }
                    },
                    new Button("Show Dialog at Top without Top 80Spx")
                    {
                        ClickedCommand = (s, e) =>
                        {
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = new Dialog
                                {
                                    HeaderView = new Label
                                    {
                                        Text = "Title",
                                        TextColor = MaterialColor.OnSurfaceContainerHighest,
                                        FontSize = MaterialFontSize.Lg,
                                        FontFamily = MaterialFont.Normal600,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    BodyView = new Label
                                    {
                                        IsMultiline = true,
                                        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                                        TextColor = MaterialColor.OnSurfaceContainerHigher,
                                        FontSize = MaterialFontSize.Sm,
                                        FontFamily = MaterialFont.Normal400,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    FooterView = new HStack()
                                    {
                                        Spacing = MaterialSpacing.Md400,
                                        Children =
                                        {
                                            new AlertDialogButton("Cancel")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                            new AlertDialogButton("OK")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                        }
                                    }.Margin(MaterialSpacing.Lg700, MaterialSpacing.Sm60, MaterialSpacing.Lg700, 0).EndHorizontal(),
                                }.LayoutBounds(0.5f, 0f, -1f, -1f).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                            }.Self(out var dialogContainer));
                            dialogContainer.Margin(0, 80f.Spx(), 0, 0);
                        },
                    },
                    new Button("Show Dialog at 100Spx from Top without Top 80Spx")
                    {
                        ClickedCommand = (s, e) =>
                        {
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = new Dialog
                                {
                                    HeaderView = new Label
                                    {
                                        Text = "Title",
                                        TextColor = MaterialColor.OnSurfaceContainerHighest,
                                        FontSize = MaterialFontSize.Lg,
                                        FontFamily = MaterialFont.Normal600,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    BodyView = new Label
                                    {
                                        IsMultiline = true,
                                        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                                        TextColor = MaterialColor.OnSurfaceContainerHigher,
                                        FontSize = MaterialFontSize.Sm,
                                        FontFamily = MaterialFont.Normal400,
                                    }.Margin(MaterialSpacing.Lg700, 0),
                                    FooterView = new HStack()
                                    {
                                        Spacing = MaterialSpacing.Md400,
                                        Children =
                                        {
                                            new AlertDialogButton("Cancel")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                            new AlertDialogButton("OK")
                                            {
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                Clicked = () =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                        }
                                    }.Margin(MaterialSpacing.Lg700, MaterialSpacing.Sm60, MaterialSpacing.Lg700, 0).EndHorizontal(),
                                }.Margin(0, 100f.Spx(), 0, 0).LayoutBounds(0.5f, 0f, -1f, -1f).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                            }.Self(out var dialogContainer));
                            dialogContainer.Margin(0, 80f.Spx(), 0, 0);
                        },
                    },
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
                AccessibilityName = text;
                AccessibilityRole = AccessibilityRole.Button;

                Add(new Label
                {
                    Name = "TextView",
                    Text = text,
                    TextColor = MaterialColor.Primary,
                    VerticalAlignment = TextAlignment.Center,
                    HorizontalAlignment = TextAlignment.Center,
                    AccessibilityHidden = true,
                });

                TouchEvent += (o, e) =>
                {
                    Clicked?.Invoke();
                    e.Handled = true;
                };

                AccessibilityActionReceived += (s, e) =>
                {
                    Tizen.Log.Info(GetType().Name, $"GetType().Name={GetType().Name}, Activate()\n");
                    if (e.ActionType == AccessibilityAction.Activated)
                    {
                        Clicked?.Invoke();
                    }
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
