using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ExpandItemTest : Grid, ITestCase
    {
        public ExpandItemTest()
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
                Text = "Expand item test",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Horizontal,
                Content = new HStack
                {
                    Padding = 10,
                    Spacing = 10,
                    Children =
                    {
                        new AbsoluteLayout
                        {
                            DesiredWidth = 400,
                            BackgroundColor = Color.LightBlue,
                            Children =
                            {
                                new VStack
                                {
                                    new TextView
                                    {
                                        Text = "Head",
                                        FontSize = 20,
                                    },
                                    new ScrollLayout
                                    {
                                        BackgroundColor = Color.Yellow,
                                        ScrollDirection = ScrollDirection.Vertical,
                                        Content = new VStack
                                        {
                                            new TextView{ Text = "Item1, "}, new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},
                                        }.Spacing(10),
                                    }.Expand(),
                                    new View
                                    {
                                        DesiredHeight = 10,
                                        BackgroundColor = Color.Red
                                    },
                                    new ScrollLayout
                                    {
                                        BackgroundColor = Color.LightPink,
                                        ScrollDirection = ScrollDirection.Vertical,
                                        Content = new VStack
                                        {
                                            new TextView{ Text = "Item1, "}, new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},
                                        }.Spacing(10),
                                    }.Expand(),
                                    new View
                                    {
                                        DesiredHeight = 10,
                                        BackgroundColor = Color.Green
                                    },
                                    new TextView
                                    {
                                        Text = "Footer",
                                        FontSize = 20
                                    }
                                }.LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All)
                            }
                        },

                        new AbsoluteLayout
                        {
                            DesiredWidth = 400,
                            BackgroundColor = Color.LightBlue,
                            Children =
                            {
                                new Grid
                                {
                                    RowDefinitions = {GridLength.Auto, GridLength.Star, GridLength.Auto, GridLength.Star, GridLength.Auto, GridLength.Auto },
                                    Children =
                                    {
                                        new TextView
                                        {
                                            Text = "Header",
                                            FontSize = 20,
                                        }.Row(0),
                                        new ScrollLayout
                                        {
                                            BackgroundColor = Color.Yellow,
                                            ScrollDirection = ScrollDirection.Vertical,
                                            Content = new VStack
                                            {
                                                new TextView{ Text = "Item1, "}, new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},
                                            }.Spacing(10),
                                        }.Expand().Row(1),
                                        new View
                                        {
                                            DesiredHeight = 10,
                                            BackgroundColor = Color.Red
                                        }.Row(2),
                                        new ScrollLayout
                                        {
                                            BackgroundColor = Color.LightPink,
                                            ScrollDirection = ScrollDirection.Vertical,
                                            Content = new VStack
                                            {
                                                new TextView{ Text = "Item1, "}, new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},new TextView{ Text = "Item1, "},
                                            }.Spacing(10),
                                        }.Expand().Row(3),
                                        new View
                                        {
                                            DesiredHeight = 10,
                                            BackgroundColor = Color.Green
                                        }.Row(4),
                                        new TextView
                                        {
                                            Text = "Footer",
                                            FontSize = 20,
                                        }.Row(5),
                                    }

                                }.LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All)
                            }
                        }
                    }
                }
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