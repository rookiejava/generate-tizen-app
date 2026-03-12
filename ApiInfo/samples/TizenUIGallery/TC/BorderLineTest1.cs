using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class BorderLineTest1 : Grid, ITestCase
    {
        public BorderLineTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(50);
            RowDefinitions.Add(50);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "BorderLine Test1",
                FontSize = 30,
            });

            Add(new TextView
            {
                Name = "Log",
                BackgroundColor = Color.Yellow,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                FontSize = 20,
            }.Row(1));

            Add(new TextView
            {
                Name = "Log2",
                BackgroundColor = Color.Yellow,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                FontSize = 20,
            }.Row(2));

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new View
                    {
                        Name = "View1",
                        DesiredHeight = 300,
                        DesiredWidth = 300,
                    }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new ImageView
                    {
                        Name = "View2",
                        DesiredHeight = 300,
                        DesiredWidth = 300,
                        ResourceUrl = "img2.png",
                    }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center),
                }
            }.Row(3));

            int currentOffset = 0;
            int currentColor = 0;
            int currentBgColor = 0;

            Add(new FlexBox
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new Button("Width + 1")
                    {
                        Clicked = () =>
                        {
                            this["View1"].BorderlineWidth += 1;
                            this["View2"].BorderlineWidth += 1;

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("Width - 1")
                    {
                        Clicked = () =>
                        {
                            this["View1"].BorderlineWidth -= 1;
                            this["View2"].BorderlineWidth -= 1;

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("Offset")
                    {
                        Clicked = () =>
                        {
                            float[] offset = new float[3] { 0, 1, -1 };
                            currentOffset = (currentOffset + 1) % 3;
                            this["View1"].BorderlineOffset = offset[currentOffset];
                            this["View2"].BorderlineOffset = offset[currentOffset];

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("BorderColor")
                    {
                        Clicked = () =>
                        {
                            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Black, Color.Violet };
                            currentColor = (currentColor + 1) % 6;
                            this["View1"].BorderlineColor = colors[currentColor];
                            this["View2"].BorderlineColor = colors[currentColor];

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("BGColor")
                    {
                        Clicked = () =>
                        {
                            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Black, Color.Violet };
                            currentBgColor = (currentBgColor + 1) % 6;
                            this["View1"].BackgroundColor = colors[currentBgColor];
                            this["View2"].BackgroundColor = colors[currentBgColor];

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("SetBackground")
                    {
                        Clicked = () =>
                        {
                            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Black, Color.Violet };
                            currentBgColor = (currentBgColor + 1) % 6;
                            this["View1"].SetBackground(new ColorBackground{
                                Color = colors[currentBgColor],
                            });
                            this["View2"].SetBackground(new ColorBackground{
                                Color = colors[currentBgColor],
                            });

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),

                    new Button("SetCornerRadius")
                    {
                        Clicked = () =>
                        {
                            if (this["View1"].CornerRadius.BottomLeft > 0)
                            {
                                this["View1"].CornerRadius = 0;
                                this["View2"].CornerRadius = 0;
                            }
                            else
                            {
                                this["View1"].CornerRadius = 1;
                                this["View2"].CornerRadius = 1;
                            }

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("Top + 10")
                    {
                        Clicked = () =>
                        {
                            var radius = this["View1"].CornerRadius;
                            this["View1"].CornerRadius = new CornerRadius(radius.TopLeft + 10, radius.TopRight + 10, radius.BottomLeft, radius.BottomRight);
                            this["View2"].CornerRadius = new CornerRadius(radius.TopLeft + 10, radius.TopRight + 10, radius.BottomLeft, radius.BottomRight);

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("Top - 10")
                    {
                        Clicked = () =>
                        {
                            var radius = this["View1"].CornerRadius;
                            this["View1"].CornerRadius = new CornerRadius(radius.TopLeft - 10, radius.TopRight - 10, radius.BottomLeft, radius.BottomRight);
                            this["View2"].CornerRadius = new CornerRadius(radius.TopLeft - 10, radius.TopRight - 10, radius.BottomLeft, radius.BottomRight);

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("Radius + 10")
                    {
                        Clicked = () =>
                        {
                            var radius = this["View1"].CornerRadius;
                            this["View1"].CornerRadius = new CornerRadius(radius.TopLeft + 10, radius.TopRight + 10, radius.BottomLeft + 10, radius.BottomRight + 10);
                            this["View2"].CornerRadius = new CornerRadius(radius.TopLeft + 10, radius.TopRight + 10, radius.BottomLeft + 10, radius.BottomRight + 10);

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                    new Button("Radius - 10")
                    {
                        Clicked = () =>
                        {
                            var radius = this["View1"].CornerRadius;
                            this["View1"].CornerRadius = new CornerRadius(radius.TopLeft - 10, radius.TopRight - 10, radius.BottomLeft - 10, radius.BottomRight - 10);
                            this["View2"].CornerRadius = new CornerRadius(radius.TopLeft - 10, radius.TopRight - 10, radius.BottomLeft - 10, radius.BottomRight - 10);

                            (this["Log"] as TextView).Text = $" BorderlineWidth : {this["View1"].BorderlineWidth}, BorderlineOffset : {this["View1"].BorderlineOffset}";
                            (this["Log2"] as TextView).Text = $"BorderlineColor : {this["View1"].BorderlineColor}";
                        }
                    }.Margin(10),
                },
            }.Row(4));
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
