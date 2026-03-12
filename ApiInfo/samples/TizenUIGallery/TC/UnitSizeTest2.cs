using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class UnitSizeTest2 : Grid, ITestCase
    {
        public UnitSizeTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100.Dp().Pixel);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "UnitSize Test2",
                FontSize = 30.Dp(),
            });

            Add(new AbsoluteLayout
            {
                DesiredHeight = 500.Dp(),
                Children =
                {
                    new View().Name("Target1")
                    .DesiredHeight(100.Dp())
                    .DesiredWidth(100.Dp())
                    .Margin(70.Dp())
                    .BackgroundColor(Color.Violet)
                }
            }.Row(1));
            Add(new FlexBox
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                Children =
                {
                    new Button("X + 10 Unit")
                    {
                        Clicked = () =>
                        {
                            var margin = this["Target1"].LayoutParam().Margin;
                            this["Target1"].LayoutParam().Margin = margin with { Left = margin.Left + 10.Dp() };
                            this["Target1"].SendMeasureInvalidated();
                        }
                    },
                    new Button("Y + 10 Unit")
                    {
                        Clicked = () =>
                        {
                            var margin = this["Target1"].LayoutParam().Margin;
                            this["Target1"].LayoutParam().Margin = margin with { Top = margin.Top + 10.Dp() };
                            this["Target1"].SendMeasureInvalidated();
                        }
                    },
                    new Button("150x150 unit")
                    {
                        Clicked = () =>
                        {
                            this["Target1"].DesiredWidth = 150.Dp();
                            this["Target1"].DesiredHeight = 150.Dp();
                        }
                    },
                    new Button("100x100 unit")
                    {
                        Clicked = () =>
                        {
                            this["Target1"].DesiredWidth = 100.Dp();
                            this["Target1"].DesiredHeight = 100.Dp();
                        }
                    },
                    new Button("150x150 pixel")
                    {
                        Clicked = () =>
                        {
                            this["Target1"].DesiredWidth = 150;
                            this["Target1"].DesiredHeight = 150;
                        }
                    },
                    new Button("100x100 pixel")
                    {
                        Clicked = () =>
                        {
                            this["Target1"].DesiredWidth = 100;
                            this["Target1"].DesiredHeight = 100;
                        }
                    },
                }
            }.Row(2));

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
