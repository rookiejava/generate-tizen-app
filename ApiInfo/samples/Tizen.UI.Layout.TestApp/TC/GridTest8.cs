using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest8 : Grid, ITestCase
    {
        public GridTest8()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Name = "Outter";
            Padding = 10;
            BackgroundColor = Color.AliceBlue;

            Add(new Grid
            {
                Name = "Inner",
                ColumnDefinitions =
                {
                    GridLength.Star,
                    GridLength.Auto,
                    GridLength.Star,
                },
                RowDefinitions =
                {
                    GridLength.Star
                },
                Children =
                {
                    new View
                    {
                        BackgroundColor = Color.Red
                    }.Column(0),
                    new TextView
                    {
                        FontSize = 30,
                        Name = "Text",
                        Text = "Content",
                        BackgroundColor = Color.Green,
                    }.Column(1),
                    new View
                    {
                        BackgroundColor = Color.Blue,
                    }.Column(2)
                }
            });

            var tap = new TapGestureDetector();
            tap.Attach(this["Text"]);
            tap.Detected += (s, e) =>
            {
                (this["Text"] as TextView).Text += "AA";
            };

            var longTap = new LongPressGestureDetector();
            longTap.Attach(this["Text"]);
            longTap.Detected += (s, e) =>
            {
                if (e.Gesture.State == GestureState.Started)
                    (this["Text"] as TextView).Text = (this["Text"] as TextView).Text.Substring(1);
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
