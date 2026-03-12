using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class VerticalScrollViewTest : VStack, INavigationTransition, ITestCase
    {
        private readonly Label header;
        private readonly ScrollView scroll;
        private readonly Random rand = new Random();

        public VerticalScrollViewTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0x909090, 1f);
            ItemAlignment = LayoutAlignment.Start;

            Add(header = new()
            {
                Text = "Vertical Scroll View"
            });

            Add(scroll = new ScrollView()
            {
                BackgroundColor = new Color(0xFFFF00, 1f),
                ScrollDirection = ScrollDirection.Vertical,
            }.Expand());

            scroll.ScrollStarted += (o, e) =>
            {
                header.Text = $"Scroll started {scroll.ScrollPosition.Y}";
            };
            scroll.Scrolling += (o, e) =>
            {
                header.Text = $"Scrolling {scroll.ScrollPosition.Y}";
            };
            scroll.ScrollFinished += (o, e) =>
            {
                header.Text = $"Scroll Finished {scroll.ScrollPosition.Y}";
            };

            var listBox = new VStack()
            {
                BackgroundColor = Color.White,
                ItemAlignment = LayoutAlignment.Start,
                Spacing = 10f,
            }.Margin(5f)
            .HorizontalLayoutAlignment(LayoutAlignment.Fill);

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
            Tizen.Log.Info(GetType().Name, $"GetType().Name={GetType().Name}, Activate()\n");
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
                DesiredHeight = 200
            }.HorizontalLayoutAlignment(LayoutAlignment.Fill);
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
