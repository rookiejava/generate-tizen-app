using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class PivotPointTest : Grid, ITestCase
    {
        public PivotPointTest()
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
                Text = "PivotPointTest",
                FontSize = 30,
            });
            Add(new AbsoluteLayout
            {
                new ViewGroup
                {
                    BackgroundColor = new Color(0.8f, 0, 0, 0.5f),
                    DesiredWidth = 300,
                    DesiredHeight = 300,
                    Children =
                    {
                        new ViewGroup
                        {
                            Name = "Target",
                            BackgroundColor = new Color(0, 0.8f, 0, 0.5f),
                            Width = 150,
                            Height = 150,
                            PivotPoint = OriginPoint.TopRight,
                            PositionUsesPivotPoint = true,
                            X = 150,
                            Y = 0,
                            Children =
                            {
                                new View
                                {
                                    Name = "Target2",
                                    BackgroundColor = new Color(0, 0.0f, 0.5f, 0.5f),
                                    Width = 150,
                                    Height = 150,
                                    ParentOrigin = OriginPoint.BottomRight,
                                    PivotPoint = OriginPoint.TopRight,
                                    PositionUsesPivotPoint = true,
                                }
                            }
                        }
                    }
                }.LayoutBounds(200, 200, -1, -1)
            }.Row(1));

            UIApplication.Current.PostToUI(() =>
            {
                Console.WriteLine($"ScreenPosition : {this["Target"].ScreenPosition}");
                Console.WriteLine($"CurrentScreenPosition : {this["Target"].CurrentScreenPosition}");

                Console.WriteLine($"ScreenPosition2 : {this["Target2"].ScreenPosition}");
                Console.WriteLine($"CurrentScreenPosition2 : {this["Target2"].CurrentScreenPosition}");
            });

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
