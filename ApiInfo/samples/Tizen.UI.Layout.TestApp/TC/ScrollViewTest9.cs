using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollViewTest9 : Grid, ITestCase
    {
        public ScrollViewTest9()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ScrollView Content Change Test",
                FontSize = 30,
            });

            Add(new HStack
            {
                Children =
                {
                    new Button("Change")
                    {
                        Clicked = () =>
                        {
                            var rnd = new Random();
                            (this["ScrollView"] as ScrollLayout).Content = new HStack
                            {
                                Children =
                                {
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                    new View { DesiredWidth = 400, BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f) },
                                }
                            };
                        }
                    },
                }
            }.Row(1));

            Add(new ScrollLayout
            {
                Name = "ScrollView",
                ScrollDirection = ScrollDirection.Horizontal,
                Content = new Grid
                {
                    Name = "Grid",
                    RowDefinitions = {300, 300, 300, 300, 300, 300},
                    ColumnDefinitions = {300, 300, 300, 300, 300, 300},
                }
            }.Row(2));

            var rnd = new Random();
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    (this["Grid"] as Layout).Add(new View
                    {
                        BackgroundColor = new Color(rnd.Next(30, 255)/255f, rnd.Next(30, 255)/255f, rnd.Next(30, 255)/ 255f)
                    }.Row(row).Column(col));
                }
            }
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
