using System;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class SnackBarTest : VStack, ITestCase
    {
        private const float s_fontSize = 20f;

        public SnackBarTest() : base()
        {
            BackgroundColor = MaterialColor.Background;
            Spacing = 12f;
            Padding = 20f;

            SnackBar reuseSnackBar = new SnackBar("Lorem Ipsum is simply");

            reuseSnackBar.ActionButtonText = "Action Button";
            reuseSnackBar.Shown += (s, e) =>
            {
                Console.WriteLine("SnackBar is Shown");
            };
            reuseSnackBar.Hidden += (s, e) =>
            {
                Console.WriteLine("SnackBar is Hidden");
            };
            reuseSnackBar.ActionButtonClicked += (s, e) =>
            {
                if ((e as SnackBarActionEventArgs).Action == SnackBarAction.ConfirmInDefaultMode)
                {
                    reuseSnackBar.ActionButtonText = "Delete";
                    reuseSnackBar.ActionButtonTextColor = MaterialColor.RedBright;
                    Console.WriteLine("Clicked in default mode");
                }
                else if ((e as SnackBarActionEventArgs).Action == SnackBarAction.ConfirmInExpandMode)
                {
                    Console.WriteLine("Clicked in expand mode");
                }
            };

            Add(
                new Button("Resuable Snackbar : Short Text > Expand > Dismiss")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        reuseSnackBar.ActionButtonText = "Button";
                        reuseSnackBar.ActionButtonTextColor = MaterialColor.InversePrimary;
                        reuseSnackBar.Post();
                    }
                }
            );
            Add(
                new Button("Long Text > Expand > Dismiss")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        SnackBar SnackBar = new SnackBar("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor");
                        SnackBar.ActionButtonClicked += (s, e) =>
                        {
                            if ((e as SnackBarActionEventArgs).Action == SnackBarAction.ConfirmInDefaultMode)
                            {
                                SnackBar.ActionButtonText = "Delete";
                                SnackBar.ActionButtonTextColor = MaterialColor.RedBright;
                                Console.WriteLine("Clicked in default mode");
                            }
                        };
                        SnackBar.Post();
                    }
                }
            );
        }

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }
    }
}
