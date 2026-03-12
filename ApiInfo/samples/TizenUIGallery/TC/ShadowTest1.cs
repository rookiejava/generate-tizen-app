using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class ShadowTest1 : Grid, ITestCase
    {
        public ShadowTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Shadow Test1",
                FontSize = 30,
            });
            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    new TextView().Text("Text Shadow").FontSize(60).TextColor(Color.White).HorizontalLayoutAlignment(LayoutAlignment.Center).Margin(10)
                    .Self(view =>
                    {
                        view.SetTextShadow(new TextShadow
                        {
                            Color = Color.Gray,
                            Offset = new Point(1, 1),
                            BlurRadius = 5f
                        });
                    }),
                    new TextView().Text("View Shadow").FontSize(60).TextColor(Color.White).HorizontalLayoutAlignment(LayoutAlignment.Center).Margin(10)
                    .Self(view =>
                    {
                        view.SetShadow(new Shadow
                        {
                            Color = Color.Gray,
                            Offset = new Point(2, 2),
                            BlurRadius = 5f
                        });
                    }),

                    new View().Name("View1").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red).CornerRadius(30).Margin(10)
                    .Self(view =>
                    {
                        view.SetShadow(new Shadow
                        {
                            Color = Color.Black,
                            Offset = new Point(2, 2),
                            BlurRadius = 10f
                        });
                    }),
                    new View().Name("View2").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red).Margin(10)
                    .Self(view =>
                    {
                        view.SetShadow(new Shadow
                        {
                            Color = Color.Black,
                            Offset = new Point(0, 0),
                            Extends = new Size(5, 5),
                            BlurRadius = 10f
                        });
                    }),

                    new TextView().Text("Apply CutoutView").FontSize(20).Center(),
                    new View().Name("View3").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red.WithAlpha(0.1f)).CornerRadius(0.2f).Margin(20, 10, 20, 20)
                    .Self(view =>
                    {
                        view.SetShadow(new Shadow
                        {
                            Color = Color.Black,
                            Offset = new Point(0, 0),
                            Extends = new Size(5, 5),
                            BlurRadius = 10f,
                            CutoutPolicy = VisualCutoutPolicy.ViewInside,
                        });
                    }),

                    new TextView().Text("Apply Cutout None").FontSize(20).Center(),
                    new View().Name("View4").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red.WithAlpha(0.1f)).CornerRadius(0.2f).Margin(20, 10, 20, 20)
                    .Self(view =>
                    {
                        view.SetShadow(new Shadow
                        {
                            Color = Color.Black,
                            Offset = new Point(0, 0),
                            Extends = new Size(5, 5),
                            BlurRadius = 10f,
                        });
                    }),
                    new Button("Clear Shadow")
                    {
                        Clicked = () =>
                        {
                            this["View1"].ClearShadow();
                            this["View2"].ClearShadow();
                            this["View3"].ClearShadow();
                            this["View4"].ClearShadow();
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
