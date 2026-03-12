using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class PositionTest : Grid, ITestCase
    {
        public PositionTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(80);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Position Test",
                FontSize = 30,
            });

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("->")
                    {
                        DesiredWidth = 50,
                        Clicked = () =>
                        {
                            this["Target"].X += 50;
                            (this["TextView"] as TextView).Text = $"ScreenPosition [{this["Target"].ScreenPosition}] CurrentScreenPosition [{this["Target"].CurrentScreenPosition}]\nPosition [{new Point(this["Target"].X, this["Target"].Y)}] Current: [{this["Target"].CurrentPosition}]";
                        }
                    },
                    new Button("<-")
                    {
                        DesiredWidth = 50,
                        Clicked = () =>
                        {
                            this["Target"].X -= 50;
                            (this["TextView"] as TextView).Text = $"ScreenPosition [{this["Target"].ScreenPosition}] CurrentScreenPosition [{this["Target"].CurrentScreenPosition}]\nPosition [{new Point(this["Target"].X, this["Target"].Y)}] Current: [{this["Target"].CurrentPosition}]";
                        }
                    },
                    new Button("^")
                    {
                        DesiredWidth = 50,
                        Clicked = () =>
                        {
                            this["Target"].Y -= 50;
                            (this["TextView"] as TextView).Text = $"ScreenPosition [{this["Target"].ScreenPosition}] CurrentScreenPosition [{this["Target"].CurrentScreenPosition}]\nPosition [{new Point(this["Target"].X, this["Target"].Y)}] Current: [{this["Target"].CurrentPosition}]";
                        }
                    },
                    new Button("v")
                    {
                        DesiredWidth = 50,
                        Clicked = () =>
                        {
                            this["Target"].Y += 50;
                            (this["TextView"] as TextView).Text = $"ScreenPosition [{this["Target"].ScreenPosition}] CurrentScreenPosition [{this["Target"].CurrentScreenPosition}]\nPosition [{new Point(this["Target"].X, this["Target"].Y)}] Current: [{this["Target"].CurrentPosition}]";
                        }
                    },
                }
            }.Row(1));

            Add(new TextView
            {
                IsMultiline = true,
                Name = "TextView"
            }.Row(2).Margin(10));

            Add(new ViewGroup
            {
                Children =
                {
                    new View
                    {
                        Name = "Target",
                        HeightResizePolicy = ResizePolicy.Fixed,
                        WidthResizePolicy = ResizePolicy.Fixed,
                        Y = 100,
                        X = 100,
                        Width = 100,
                        Height = 100,
                        BackgroundColor = Color.Green,
                    }
                }
            }.Row(3));
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
