#if API13_OR_GREATER

using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class InnerShadowTest1 : Grid, ITestCase
    {
        public InnerShadowTest1()
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
                Text = "InnerShadow Test1",
                FontSize = 30,
            });
            Add(new ScrollLayout
            {
                Content = new VStack
                {
                    new TextView
                    {
                        Text = "Inset(5), BlurRadius(10), Color(Yellow)",
                        FontSize = 15,
                    }.Center(),
                    new View().Name("View1").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red).CornerRadius(30).Margin(10)
                    .Self(view =>
                    {
                        view.SetInnerShadow(new InnerShadow
                        {
                            Inset = 5,
                            BlurRadius = 10,
                            Color = Color.Yellow,
                        });
                    }),

                    new TextView
                    {
                        Text = "Inset(5, 10, 15, 20), BlurRadius(10), Color(Yellow)",
                        FontSize = 15,
                    }.Center(),
                    new View().Name("View2").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red).CornerRadius(30).Margin(10)
                    .Self(view =>
                    {
                        view.SetInnerShadow(new InnerShadow
                        {
                            Inset = new Thickness(5, 10, 15, 20),
                            BlurRadius = 10,
                            Color = Color.Yellow,
                        });
                    }),

                    new TextView
                    {
                        Text = "Inset(0), BlurRadius(10), Color(Yellow)",
                        FontSize = 15,
                    }.Center(),
                    new View().Name("View3").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red).CornerRadius(30).Margin(10)
                    .Self(view =>
                    {
                        view.SetInnerShadow(new InnerShadow
                        {
                            Inset = 0,
                            BlurRadius = 10,
                            Color = Color.Yellow,
                        });
                    }),

                    new View().Name("View4").DesiredHeight(100).DesiredWidth(100).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Red).CornerRadius(30).Margin(10)
                    .Self(view =>
                    {
                        view.SetInnerShadow(new InnerShadow
                        {
                            Inset = 0,
                            BlurRadius = 10,
                            Color = Color.Yellow,
                        });
                        view.SetShadow(new Shadow
                        {
                            BlurRadius = 10,
                            Color = Color.Green,
                        });
                    }),

                    new Button("Clear Shadow")
                    {
                        Clicked = () =>
                        {
                            this["View1"].ClearInnerShadow();
                            this["View2"].ClearInnerShadow();
                            this["View3"].ClearInnerShadow();
                            this["View4"].ClearInnerShadow();
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

#endif