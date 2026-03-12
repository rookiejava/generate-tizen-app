using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class UpdateLayoutTest2 : Grid, ITestCase
    {
        public UpdateLayoutTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Name = "Outter";
            BackgroundColor = Color.AliceBlue;
            RowDefinitions.Add(50);
            RowDefinitions.Add(GridLength.Star);
            Add(new HStack
            {
                Name = "Menu Layout",
                Spacing = 10,
                Children =
                {
                    new TextView
                    {
                        FontSize = 20,
                        DesiredWidth = 200,
                        BackgroundColor = Color.Blue,
                        Name = "Add",
                        Text = "Add",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
                    },
                    new TextView
                    {
                        FontSize = 20,
                        DesiredWidth = 200,
                        BackgroundColor = Color.Blue,
                        Name = "Remove",
                        Text = "Remove",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
                    },
                    new TextView
                    {
                        FontSize = 20,
                        DesiredWidth = 200,
                        BackgroundColor = Color.Blue,
                        Name = "More",
                        Text = "More Margin",
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
                    },
                    new TextView
                    {
                        FontSize = 20,
                        DesiredWidth = 200,
                        BackgroundColor = Color.Blue,
                        Name = "Less",
                        Text = "Less Margin",
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
            var moreTap = new TapGestureDetector();
            var lessTap = new TapGestureDetector();
            addTap.Attach(this["Add"]);
            removeTap.Attach(this["Remove"]);
            moreTap.Attach(this["More"]);
            lessTap.Attach(this["Less"]);

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

            moreTap.Detected += (s, e) =>
            {
                foreach (var child in (this["ContentLayout1"] as Layout).Children)
                {
                    child.Margin(child.LayoutParam().Margin.Top + 1);
                }
                foreach (var child in (this["ContentLayout2"] as Layout).Children)
                {
                    child.Margin(child.LayoutParam().Margin.Top + 1);
                }
            };

            lessTap.Detected += (s, e) =>
            {
                foreach (var child in (this["ContentLayout1"] as Layout).Children)
                {
                    child.Margin(MathF.Max(0, child.LayoutParam().Margin.Top - 1));
                }
                foreach (var child in (this["ContentLayout2"] as Layout).Children)
                {
                    child.Margin(MathF.Max(0, child.LayoutParam().Margin.Top - 1));
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
