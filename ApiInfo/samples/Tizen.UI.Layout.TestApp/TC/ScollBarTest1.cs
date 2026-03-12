using System;
using LayoutTest.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollBarTest1 : Grid, ITestCase
    {
        public ScrollBarTest1()
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
                            new TextView { Text = "ScrollPostion : ", Name = "Log1", FontSize = 20, },
                            new TextView { Text = "State : ", Name = "Log2", FontSize = 20, }
                        }
                    }.VerticalLayoutAlignment(LayoutAlignment.Center),
                    new Button("ScrollBarVisibility - Auto")
                    {
                        Name = "Btn1",
                        Clicked = () =>
                        {
                            var cur = (this["ScrollView"] as ScrollLayout).VerticalScrollBarVisibility;
                            cur = (ScrollBarVisibility)(((int)cur + 1)%3);
                            (this["ScrollView"] as ScrollLayout).VerticalScrollBarVisibility = cur;
                            (this["Btn1"] as Button).Text = "ScrollBarVisibility - " + cur;
                        }
                    }
                }
            });
            Add(new ScrollLayout
            {
                Name = "ScrollView",
                Content = new VStack
                {
                    Name = "VStack",
                    BackgroundColor = Color.Green,
                }
            }.Row(1));

            for (int i = 0; i < 50; i++)
            {
                var rnd = new Random();
                (this["VStack"] as Layout).Children.Add(new View
                {
                    DesiredHeight = 50,
                    BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
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
