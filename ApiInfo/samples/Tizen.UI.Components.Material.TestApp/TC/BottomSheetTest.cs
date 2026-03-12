using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class BottomSheetTest : ContentView, INavigationTransition, ITestCase
    {
        public BottomSheetTest() : base()
        {
            BackgroundColor = Color.White;

            Body = new VStack()
            {
                Spacing = 20f,
                Children =
                {
                    new Button("Show BottomSheet")
                    {
                        ClickedCommand = (o, e) =>
                        {
                            this.GetNavigation().PushModalAsync(new BottomSheetContainer()
                            {
                                ModalContent = new BottomSheet()
                                {
                                    Content = new VStack()
                                    {
                                        new Label()
                                        {
                                            Text = "BottomSheet TextView",
                                        },
                                        new Button("BottomSheet Button")
                                        {
                                            ClickedCommand = (o, e) => new Toast("Button").Post()
                                        },
                                    }
                                }
                            });
                        }
                    },
                    new Button("Show Custom Anchor BottomSheet")
                    {
                        ClickedCommand = (o, e) =>
                        {
                            this.GetNavigation().PushModalAsync(new BottomSheetContainer()
                            {
                                ModalContent = new BottomSheet(BottomSheetVariables.Default with { Anchors = new float[] { 120f, 320f, 520f }, DefaultAnchorIndex = 1 })
                                {
                                    Content = new VStack()
                                    {
                                        new Label()
                                        {
                                            Text = "BottomSheet TextView",
                                        },
                                        new Button("BottomSheet Button")
                                        {
                                            ClickedCommand = (o, e) => new Toast("Button").Post()
                                        },
                                    }
                                }
                            });
                        }
                    },
                    new Button("Show Custom Margin BottomSheet")
                    {
                        ClickedCommand = (o, e) =>
                        {
                            this.GetNavigation().PushModalAsync(new BottomSheetContainer()
                            {
                                ModalContent = new BottomSheet()
                                {
                                    Content = new VStack()
                                    {
                                        new Label()
                                        {
                                            Text = "BottomSheet TextView",
                                        },
                                        new Button("BottomSheet Button")
                                        {
                                            // TODO: Restore when Toast is updated.
                                            // ClickedCommand = (o, e) => new Toast("Button").Post()
                                        },
                                    }
                                }.Margin(100f, 0f, 100f, 0f),
                            });
                        }
                    },
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
