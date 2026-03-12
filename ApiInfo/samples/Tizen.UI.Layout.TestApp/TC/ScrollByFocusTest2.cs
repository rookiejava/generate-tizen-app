using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollByFocusTest2 : Grid, ITestCase
    {
        public ScrollByFocusTest2()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            Add(new ScrollLayout
            {
                Name = "VScroll",
                Padding = 10,
                Content = new VStack
                {
                    Name = "VStack",
                    BackgroundColor = Color.Green,
                }
            });

            for (int i = 0; i < 50; i++)
            {

                var hscroll = new ScrollLayout
                {
                    Name = "HScroll",
                    DesiredHeight = 100,
                    ScrollDirection = ScrollDirection.Horizontal,
                    Content = new HStack
                    {
                        Name = "HStack",
                        BackgroundColor = Color.Green,
                    }
                };

                for (int j = 0; j < 100; j++)
                {
                    var rnd = new Random();
                    (hscroll["HStack"] as Layout).Children.Add(new Button($"{i}, {j}")
                    {
                        FocusHighlightEnabled = true,
                        Focusable = true,
                        FocusableInTouch = true,
                        DesiredWidth = 100,
                        DesiredHeight = 100,
                        BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                    });
                }
                (this["VStack"] as Layout).Children.Add(hscroll);
            }

            FocusManager.Instance.FocusChanged += OnFocusChanged;
            DetachedFromWindow += (s, e) =>
            {
                FocusManager.Instance.FocusChanged -= OnFocusChanged;
            };
        }

        private void OnFocusChanged(object sender, FocusChangedEventArgs e)
        {
            if (e.FocusedView is Button btn)
            {
                Console.WriteLine($"Focused : {btn.Text}");
            }
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}
