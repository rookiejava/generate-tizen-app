using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class ToastTest : VStack, INavigationTransition, ITestCase
    {
        private const float s_fontSize = 20f;

        public ToastTest() : base()
        {
            BackgroundColor = MaterialColor.Background;
            Spacing = 12f;
            Padding = 20f;

            Toast reuseToast = new Toast("Lorem Ipsum is simply");
            reuseToast.Shown += (s, e) => Console.WriteLine("Shown");
            reuseToast.Hidden += (s, e) => Console.WriteLine("Hidden");

            Add(
                new Button("Variation1 : Short Text (Reusable)")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        reuseToast.Post();
                    }
                }
            );
            Add(
                new Button("Variation2 : Long Text")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        Toast toast = new Toast("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard");
                        toast.Post();

                        toast.Shown += (s2, e2) => Console.WriteLine("Shown");
                        toast.Hidden += (s2, e2) => Console.WriteLine("Hidden");
                    }
                }
            );
            Add(
                new Button("Variation3 : Short Text with Icon")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        Toast toast = new Toast("Lorem Ipsum is simply");
                        toast.IconResourceUrl = MaterialIcon.Photo;
                        toast.Post();

                        toast.Shown += (s2, e2) => Console.WriteLine("Shown");
                        toast.Hidden += (s2, e2) => Console.WriteLine("Hidden");
                    }
                }
            );
            Add(
                new Button("Variation4 : Long Text with Icon")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        Toast toast = new Toast("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard");
                        toast.IconResourceUrl = MaterialIcon.Photo;
                        toast.Post();

                        toast.Shown += (s2, e2) => Console.WriteLine("Shown");
                        toast.Hidden += (s2, e2) => Console.WriteLine("Hidden");
                    }
                }
            );
            Add(
                new Button("Duration : NotificationDuration.Short")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        Window mywin = Window.Default;
                        Toast toast = new Toast("Lorem Ipsum is simply dummy text", NotificationDuration.Short);
                        toast.Post();

                        toast.Shown += (s2, e2) => Console.WriteLine("Shown");
                        toast.Hidden += (s2, e2) => Console.WriteLine("Hidden");
                    }
                }
            );
            Add(
                new Button("Duration : NotificationDuration.Long")
                {
                    FontSize = s_fontSize,
                    ClickedCommand = (s, e) =>
                    {
                        Toast toast = new Toast("Lorem Ipsum is simply dummy text", NotificationDuration.Long);
                        toast.Post();

                        toast.Shown += (s2, e2) => Console.WriteLine("Shown");
                        toast.Hidden += (s2, e2) => Console.WriteLine("Hidden");
                    }
                }
            );
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
