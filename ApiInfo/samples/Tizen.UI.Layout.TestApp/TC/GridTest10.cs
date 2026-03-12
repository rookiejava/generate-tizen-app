using LayoutTest.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class GridTest10 : Grid, ITestCase
    {
        public GridTest10()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star); // need to check when GridLength.Auto
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                Name = "heaer",
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Grid bug test",
                FontSize = 30,
            });

            var target = new View
            {
                Name = "main",
                DesiredHeight = 300,
                DesiredWidth = 300,
                BackgroundColor = Color.Violet,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1);
            Add(target);

            Add(new FlexBox()
            {
                Name = "footer",
                BackgroundColor = Color.AliceBlue,
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new View
                    {
                        Name = "child1",
                        BackgroundColor = Color.Gold,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new View
                    {
                        Name = "child2",
                        BackgroundColor = Color.Blue,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new View
                    {
                        Name = "child3",
                        BackgroundColor = Color.Gold,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new View
                    {
                        Name = "child4",
                        BackgroundColor = Color.Blue,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new View
                    {
                        Name = "child5",
                        BackgroundColor = Color.Gold,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new View
                    {
                        Name = "child6",
                        BackgroundColor = Color.Blue,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new View
                    {
                        Name = "child7",
                        BackgroundColor = Color.Gold,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new View
                    {
                        Name = "child8",
                        BackgroundColor = Color.Blue,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                    new Button("Test")
                    {
                        Clicked = () =>
                        {
                            this.UpdateLayout();
                        },
                        Name = "child9",
                        BackgroundColor = Color.Gold,
                        DesiredHeight = 50,
                        DesiredWidth = 100,
                    },
                }
            }.Row(2).Margin(20));
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
