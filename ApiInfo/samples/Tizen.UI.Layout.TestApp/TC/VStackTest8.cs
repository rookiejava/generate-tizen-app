using LayoutTest.Util;
using Tizen.UI;
using Tizen.UI.Components.Animations;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackTest8 : Grid, ITestCase
    {
        public VStackTest8()
        {
            // vstack이 중첩되면서 안쪽 vstack이 expand일 경우 제대로 배치 안됨
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "VStack nested and exapnd",
                FontSize = 30,
            });
            Add(new HStack
            {
                new Button("Add View")
                {
                    Clicked = () =>
                    {
                        AddView();
                    }
                },
            }.Row(1));

            Add(new AbsoluteLayout
            {
                Name = "Abs",
            }.Row(2));

            AddView();

        }

        void AddView()
        {
            var testView = new TestView2().LayoutBounds(10, 10, 1000, -1);
            (this["Abs"] as Layout).Add(testView);
            var animation = new UIAnimation(p =>
            {
                testView.DesiredHeight = p * 300;
            });
            animation.Commit(this, "open", rate:100, length: 500);
        }

        class TestView2 : VStack
        {
            public TestView2()
            {
                BorderlineColor = Color.Black;
                BorderlineWidth = 2;

                Add(new VStack
                {
                    Name = "Test",
                    BackgroundColor = Color.Blue,
                    Children =
                    {
                        new TextView { Text = "VStack > Text2", BackgroundColor = Color.LightBlue, FontSize = 22 },
                        new TextView { Text = "VStack > Text3ww", BackgroundColor = Color.LightGreen, FontSize = 32 },
                    }
                }.Expand().VerticalLayoutAlignment(LayoutAlignment.Start).MinimumHeight(100));
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
