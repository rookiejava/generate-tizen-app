using LayoutTest.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class UpdateLayoutTest4 : VStack, ITestCase
    {
        public UpdateLayoutTest4()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Spacing = 5;
            Name = "Outter";
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            Add(new TextView
            {
                DesiredHeight = 100,
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "UpdateLayoutTest4",
                FontSize = 30,
            }.Margin(0, 0, 0, 20));
            Add(new Button("Hide")
            {
                Clicked = () =>
                {
                    this["Target"].IsVisible = false;
                }
            });

            Add(new Button("Show")
            {
                Clicked = () =>
                {
                    this["Target"].IsVisible = true;
                }
            });

            Add(new HStack
            {
                new TextView
                {
                    FontSize = 40,
                    Text = "Hello",
                    BackgroundColor = Color.AliceBlue
                },
                new TextView
                {
                    FontSize = 40,
                    Name = "Target",
                    Text = "OneUI",
                    BackgroundColor = Color.Green,
                    IsVisible = false
                },
                new TextView
                {
                    FontSize = 40,
                    Text = "World",
                    BackgroundColor = Color.AliceBlue
                }

            }.Margin(30).Spacing(5));
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
