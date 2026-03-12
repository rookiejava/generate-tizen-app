using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest1 : ViewGroup, ITestCase
    {
        public GridTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            var layout1 = CreateTestCase1();
            layout1.Width = 300;
            layout1.Height = 300;
            layout1.X = 0;
            layout1.Y = 0;
            Add(layout1);

            var layout2 = CreateTestCase2();
            layout2.Width = 300;
            layout2.Height = 300;
            layout2.X = 310;
            Add(layout2);

            var layout3 = CreateTestCase3();
            layout3.Width = 300;
            layout3.Height = 300;
            layout3.X = 620;
            Add(layout3);
        }

        Grid CreateTestCase1()
        {
            var layout = new Grid()
            {
                BackgroundColor = Color.White,
                RowDefinitions =
                {
                    new GridRowDefinition
                    {
                        Height = 300
                    }
                },
                ColumnDefinitions =
                {
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Auto),
                    },
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Star),
                    },
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Auto),
                    },
                }
            };

            layout.Add(new View
            {
                DesiredWidth = 30,
                BackgroundColor = Color.Red
            }, 0, 0);
            layout.Add(new View
            {
                BackgroundColor = Color.Green
            }, 0, 1);
            layout.Add(new View
            {
                DesiredWidth = 30,
                BackgroundColor = Color.Blue
            }, 0, 2);

            return layout;
        }

        Grid CreateTestCase2()
        {
            var layout = new Grid()
            {
                BackgroundColor = Color.White,
                RowDefinitions =
                {
                    new GridRowDefinition
                    {
                        Height = 300
                    }
                },
                ColumnDefinitions =
                {
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Auto),
                    },
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Star),
                    },
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Auto),
                    },
                }
            };
            var view1 = new View
            {
                DesiredWidth = 30,
                BackgroundColor = Color.Red
            };
            view1.LayoutParam().Margin = new Thickness(10);
            layout.Add(view1, 0, 0);
            layout.Add(new View
            {
                Name = "Main",
                BackgroundColor = Color.Green
            }, 0, 1);
            layout.Add(new View
            {
                DesiredWidth = 30,
                BackgroundColor = Color.Blue
            }, 0, 2);

            layout["Main"].LayoutParam().Margin = new Thickness(5);
            return layout;
        }

        Grid CreateTestCase3()
        {
            var layout = new Grid()
            {
                BackgroundColor = Color.White,
                RowDefinitions =
                {
                    new GridRowDefinition
                    {
                        Height = 300
                    }
                },
                ColumnDefinitions =
                {
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Auto),
                    },
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Star),
                    },
                    new GridColumnDefinition
                    {
                        Width = new(1, GridUnitType.Auto),
                    },
                }
            };
            var view1 = new TextView
            {
                Text = "Text abcde",
                BackgroundColor = Color.Red
            };
            layout.Add(view1, 0, 0);
            layout.Add(new View
            {
                Name = "Main",
                BackgroundColor = Color.Green
            }, 0, 1);
            layout.Add(new TextView
            {
                DesiredWidth = 80,
                Text = "Very long text width multi lines",
                IsMultiline = true,
                BackgroundColor = Color.Blue
            }, 0, 2);

            layout["Main"].LayoutParam().Margin = new Thickness(5);
            return layout;
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
