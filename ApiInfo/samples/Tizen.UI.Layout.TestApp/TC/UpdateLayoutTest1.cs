using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class UpdateLayoutTest1 : Grid, ITestCase
    {
        public UpdateLayoutTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Name = "Outter";
            BackgroundColor = Color.AliceBlue;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            Add(new HStack
            {
                Name = "Menu Layout",
                Spacing = 10,
                Children =
                {
                    new TextView
                    {
                        DesiredWidth = 200,
                        BackgroundColor = Color.Blue,
                        FontSize = 40,
                        Name = "Add",
                        Text = "Add",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
                    },
                    new TextView
                    {
                        DesiredWidth = 200,
                        FontSize = 40,
                        BackgroundColor = Color.Blue,
                        Name = "Remove",
                        Text = "Remove",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
                    },
                }
            }.Row(0));
            
            Add(new Grid
            {
                Name = "Inner",
                RowDefinitions =
                {
                    GridLength.Auto
                },
                ColumnDefinitions =
                {
                    GridLength.Star,
                    GridLength.Star,
                },
                Children =
                {
                    new HStack
                    {
                        BackgroundColor = Color.Yellow,
                        Spacing = 5,
                        Name = "ContentLayout1"
                    }.Row(0).Column(0).MinimumHeight(100),
                    new VStack
                    {
                        BackgroundColor = Color.YellowGreen,
                        Spacing = 5,
                        Name = "ContentLayout2"
                    }.Row(0).Column(1).MinimumHeight(100)
                }
            }.Row(1));

            var addTap = new TapGestureDetector();
            var removeTap = new TapGestureDetector();
            addTap.Attach(this["Add"]);
            removeTap.Attach(this["Remove"]);

            addTap.Detected += (s, e) =>
            {
                (this["ContentLayout1"] as Layout).Children.Add(new View
                {
                    DesiredWidth = 10,
                    BackgroundColor = Color.Green
                });
                (this["ContentLayout2"] as Layout).Children.Add(new View
                {
                    DesiredHeight = 10,
                    BackgroundColor = Color.Red
                });
            };
            removeTap.Detected += (s, e) =>
            {
                if ((this["ContentLayout1"] as Layout).Children.Count > 0)
                {
                    (this["ContentLayout1"] as Layout).Children.RemoveAt(0);
                }

                if ((this["ContentLayout2"] as Layout).Children.Count > 0)
                {
                    (this["ContentLayout2"] as Layout).Children.RemoveAt(0);
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
