using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ExpandItemTest2 : Grid, ITestCase
    {
        public ExpandItemTest2()
        {
            BackgroundColor = Color.White;
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Expand item test2",
                FontSize = 30,
            });
            Add(new VStack
            {
                new HStack
                {
                    new View
                    {
                        DesiredWidth = 300,
                        DesiredHeight = 100,
                        BackgroundColor = Color.LightBlue,
                    },
                    new TextView
                    {
                        Name = "Text",
                    }.Expand(),
                    new View
                    {
                        DesiredWidth = 300,
                        BackgroundColor = Color.LightGreen,
                    }
                }.DesiredHeight(100),

                new TextField
                {
                    DesiredHeight = 30,
                    DesiredWidth = 300,
                    MaxLength = 1000,
                    FontSize = 20,
                    VerticalAlignment = TextAlignment.Center,
                    BorderlineColor = Color.Black,
                    BorderlineWidth = 1,
                    CornerRadius = 10,
                }.Self(view =>
                {
                    view.TextChanged += (s, e) =>
                    {
                        (this["Text"] as TextView).Text = view.Text;
                    };
                }),
            }.Row(1));
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