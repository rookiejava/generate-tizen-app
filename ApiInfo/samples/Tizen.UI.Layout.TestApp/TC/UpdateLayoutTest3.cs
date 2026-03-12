using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class UpdateLayoutTest3 : VStack, ITestCase
    {
        public UpdateLayoutTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Spacing = 5;
            Name = "Outter";
            Padding = 20;
            BackgroundColor = Color.Red;
            Children.Add(new TextView
            {
                FontSize = 20,
                DesiredHeight = 50,
                BackgroundColor = Color.Blue,
                Name = "Add",
                Text = "Add",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            });
            Children.Add(new TextView
            {
                FontSize = 20,
                DesiredHeight = 50,
                BackgroundColor = Color.Blue,
                Name = "Remove",
                Text = "Remove",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            });

            var addTap = new TapGestureDetector();
            var removeTap = new TapGestureDetector();
            addTap.Attach(this["Add"]);
            removeTap.Attach(this["Remove"]);

            addTap.Detected += (s, e) =>
            {
                (this["Outter"] as Layout).Children.Add(new View
                {
                    DesiredHeight = 50,
                    BackgroundColor = Color.Green
                });
            };

            removeTap.Detected += (s, e) =>
            {
                if ((this["Outter"] as Layout).Children.Count > 2)
                {
                    (this["Outter"] as Layout).Children.RemoveAt((this["Outter"] as Layout).Children.Count - 1);
                }
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
