using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest2 : ViewGroup, ITestCase
    {
        public GridTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            var grid = new Grid
            {
                Name = "OutterLayout",
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = Color.White,
                RowDefinitions =
                {
                    new GridRowDefinition
                    {
                        Height = 100,
                    },
                    new GridRowDefinition
                    {
                        Height = new GridLength(1, GridUnitType.Star)
                    }
                },
                ColumnDefinitions =
                {
                    new GridColumnDefinition
                    {
                        Width = new GridLength(1, GridUnitType.Auto)
                    },
                    new GridColumnDefinition
                    {
                        Width = new GridLength(1, GridUnitType.Star)
                    },
                }
             };

            grid.Add(new TextView
            {
                Name = "Title",
                BackgroundColor = Color.CornflowerBlue,
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                FontSize = 40,
                Text = "Grid2"
            }, 0, 1, 0, 2);

            grid.Add(new TextView
            {
                FontSize = 30,
                Name = "Content",
                Text = "The .NET Multi-platform App UI (.NET MAUI) Grid, is a layout that organizes its children into rows and columns, which can have proportional or absolute sizes. By default, a Grid contains one row and one column. In addition, a Grid can be used as a parent layout that contains other child layouts.",
                IsMultiline = true,
                BackgroundColor = Color.Gray,
            }, 1, 1);
            grid["Content"].LayoutParam().Margin = new Thickness(50);
            Add(grid);

            var menuGrid = new Grid
            {
                Name = "MenuGrid",
                BackgroundColor = Color.DarkGreen,
                RowSpacing = 5,
                RowDefinitions =
                {
                    new GridLength(50f),
                    new GridLength(50f),
                    new GridLength(50f),
                    new GridLength(50f),
                    new GridLength(50f),
                },
                ColumnDefinitions = 
                { 
                    new GridLength(1, GridUnitType.Auto)
                }
            };

            grid.Add(menuGrid, 1, 0);
            menuGrid.Add(new TextView
            {
                FontSize = 20,
                Name = "Label1",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                BackgroundColor = Color.Yellow,
                Text = "Item1"
            }, 0, 0);

            menuGrid.Add(new TextView
            {
                FontSize = 20,
                Name = "Label2",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                BackgroundColor = Color.Yellow,
                Text = "Item2"
            }, 1, 0);

            menuGrid.Add(new TextView
            {
                FontSize = 20,
                Name = "Text",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                BackgroundColor = Color.Yellow,
                Text = "Item33333"
            }, 2, 0);

            menuGrid.Add(new TextView
            {
                FontSize = 20,
                Name = "Add",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                BackgroundColor = Color.Yellow,
                Text = "+"
            }, 3, 0);


            menuGrid.Add(new TextView
            {
                FontSize = 20,
                Name = "Remove",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                BackgroundColor = Color.Yellow,
                Text = "-"
            }, 4, 0);

            var tap = new TapGestureDetector();
            tap.Attach(menuGrid["Add"]);
            tap.Attach(menuGrid["Remove"]);
            tap.Detected += (s, e) =>
            {
                if (e.View == menuGrid["Add"])
                {
                    (menuGrid["Text"] as TextView).Text += "AA";
                }
                else
                {
                    (menuGrid["Text"] as TextView).Text = (menuGrid["Text"] as TextView).Text.Substring(2);
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
