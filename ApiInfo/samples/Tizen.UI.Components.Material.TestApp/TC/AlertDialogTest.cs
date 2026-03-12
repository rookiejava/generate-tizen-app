using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class AlertDialogTest : ContentView, INavigationTransition, ITestCase
    {
        public AlertDialogTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Body = new VStack()
            {
                Spacing = 20f,
                Children =
                {
                    new Button("Show AlertDialog")
                    {
                        ClickedCommand = (_, _) =>
                        {
                            var alertDialog = new AlertDialog()
                            {
                                Title = "Title",
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                            };
                            alertDialog.SetActionButtons(("Cancel", (o, e) => this.GetNavigation().PopModalAsync()), ("OK", (o, e) => this.GetNavigation().PopModalAsync()));
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = alertDialog
                            });
                        }
                    },
                    new Button("Show AlertDialog at Center without Top 80Spx")
                    {
                        ClickedCommand = (_, _) =>
                        {
                            var alertDialog = new AlertDialog()
                            {
                                Title = "Title",
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                            };
                            alertDialog.SetActionButtons(("Cancel", (o, e) => this.GetNavigation().PopModalAsync()), ("OK", (o, e) => this.GetNavigation().PopModalAsync()));
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = alertDialog,
                            }.Self(out var dialogContainer));
                            dialogContainer.Margin(0, 80f.Spx(), 0, 0);
                        }
                    },
                    new Button("Show AlertDialog at Top without Top 80Spx")
                    {
                        ClickedCommand = (_, _) =>
                        {
                            var alertDialog = new AlertDialog()
                            {
                                Title = "Title",
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                            }.LayoutBounds(0.5f, 0f, -1f, -1f).LayoutFlags(AbsoluteLayoutFlags.PositionProportional);
                            alertDialog.SetActionButtons(("Cancel", (o, e) => this.GetNavigation().PopModalAsync()), ("OK", (o, e) => this.GetNavigation().PopModalAsync()));
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = alertDialog,
                            }.Self(out var dialogContainer));
                            dialogContainer.Margin(0, 80f.Spx(), 0, 0);
                        }
                    },
                    new Button("Show AlertDialog at 100Spx from Top without Top 80Spx")
                    {
                        ClickedCommand = (_, _) =>
                        {
                            var alertDialog = new AlertDialog()
                            {
                                Title = "Title",
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                            }.Margin(0, 100f.Spx(), 0, 0).LayoutBounds(0.5f, 0f, -1f, -1f).LayoutFlags(AbsoluteLayoutFlags.PositionProportional);
                            alertDialog.SetActionButtons(("Cancel", (o, e) => this.GetNavigation().PopModalAsync()), ("OK", (o, e) => this.GetNavigation().PopModalAsync()));
                            this.GetNavigation().PushModalAsync(new DialogContainer()
                            {
                                ModalContent = alertDialog,
                            }.Self(out var dialogContainer));
                            dialogContainer.Margin(0, 80f.Spx(), 0, 0);
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
            Dispose();
        }
    }
}
