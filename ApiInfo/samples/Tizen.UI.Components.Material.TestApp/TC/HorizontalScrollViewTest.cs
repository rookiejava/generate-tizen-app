using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class HorizontalScrollViewTest : VStack, INavigationTransition, ITestCase
    {
        private readonly Label header;
        private readonly ScrollView scroll;
        private readonly Random rand = new Random();

        public HorizontalScrollViewTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0x909090, 1f);
            ItemAlignment = LayoutAlignment.Start;

            Console.WriteLine("HorizontalScrollView Created!");

            Add(header = new Label()
            {
                Text = "HorizontalScrollView Test"
            });

            Add(scroll = new ScrollView()
            {
                BackgroundColor = new Color(0xFFFF00, 1f),
                ScrollDirection = ScrollDirection.Horizontal,
            }.Expand());

            scroll.ScrollStarted += (o, e) =>
            {
                header.Text = $"Scroll started {scroll.ScrollPosition.X}";
            };
            scroll.Scrolling += (o, e) =>
            {
                header.Text = $"Scrolling {scroll.ScrollPosition.X}";
            };
            scroll.ScrollFinished += (o, e) =>
            {
                header.Text = $"Scroll Finished {scroll.ScrollPosition.X}";
            };

            var listBox = new HStack()
            {
                BackgroundColor = Color.White,
                ItemAlignment = LayoutAlignment.Start,
                Spacing = 10f
            }.Margin(5f)
            .VerticalLayoutAlignment(LayoutAlignment.Fill);

            AddChildren(listBox);
            scroll.Content = listBox;
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
            Tizen.Log.Info(GetType().Name, $"GetType().Name={GetType().Name}, Activate()\n");
        }
        public void Deactivate()
        {
            Tizen.Log.Info(GetType().Name, $"GetType().Name={GetType().Name}, Deactivate()\n");
        }

        private float GetColor()
        {
            return (float)rand.Next(255) / 255f;
        }

        private View GetColorRect()
        {
            return new View()
            {
                BackgroundColor = new Color(GetColor(), GetColor(), GetColor(), 1),
                DesiredWidth = 250,
            }.VerticalLayoutAlignment(LayoutAlignment.Fill);
        }

        private void AddChildren(ViewGroup parent)
        {
            for (int i = 0; i < 100; i++)
            {
                parent.Add(GetColorRect());
            }
        }
    }
}
