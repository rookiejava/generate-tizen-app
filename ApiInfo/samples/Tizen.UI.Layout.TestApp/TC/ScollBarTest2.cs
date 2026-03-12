using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollBarTest2 : Grid, ITestCase
    {
        public ScrollBarTest2()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new HStack
            {
                Children =
                {
                    new VStack
                    {
                        Padding = 20,
                        Children =
                        {
                            new TextView { Text = "ScrollPostion : ", Name = "Log1", FontSize = 20 },
                            new TextView { Text = "State : ", Name = "Log2", FontSize = 20 }
                        }
                    }.VerticalLayoutAlignment(LayoutAlignment.Center),
                    new Button("ScrollBarVisibility - Auto")
                    {
                        Name = "Btn1",
                        Clicked = () =>
                        {
                            var cur = (this["ScrollView"] as ScrollLayout).HorizontalScrollBarVisibility;
                            cur = (ScrollBarVisibility)(((int)cur + 1)%3);
                            (this["ScrollView"] as ScrollLayout).HorizontalScrollBarVisibility = cur;
                            (this["Btn1"] as Button).Text = "ScrollBarVisibility - " + cur;
                        }
                    }
                }
            });
            Add(new ScrollLayout
            {
                Name = "ScrollView",
                ScrollDirection = ScrollDirection.Horizontal,
                Content = new HStack
                {
                    Name = "HStack",
                    BackgroundColor = Color.Green,
                }
            }.Row(1));

            for (int i = 0; i < 50; i++)
            {
                var rnd = new Random();
                (this["HStack"] as Layout).Children.Add(new TextView
                {
                    Text = $"{i}",
                    VerticalAlignment = TextAlignment.Center,
                    DesiredWidth = 50,
                    BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                    FontSize = 20,
                });
            }
            var scrollview = (this["ScrollView"] as ScrollLayout);
            scrollview.Scrolling += (s, e) =>
            {
                (this["Log1"] as TextView).Text = $"ScrollPosition : {scrollview.ScrollPosition}";
            };
            scrollview.ScrollStarted += (s, e) =>
            {
                (this["Log2"] as TextView).Text = $"State : ScrollStarted";
            };
            scrollview.ScrollFinished+= (s, e) =>
            {
                (this["Log2"] as TextView).Text = $"State : ScrollFinished";
            };
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
