using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class ResizePolicyFactorTest : Grid, ITestCase
    {
        public ResizePolicyFactorTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ResizePolicyFactorTest",
                FontSize = 30,
            });

            Add(new HStack
            {
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 50,
                Children =
                {
                    new ViewGroup
                    {
                        DesiredHeight = 300,
                        DesiredWidth = 300,
                        BackgroundColor = Color.Beige,
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                        Children = 
                        {
                            new View
                            {
                                HeightResizePolicy = ResizePolicy.SizeFixedOffsetFromParent,
                                WidthResizePolicy = ResizePolicy.SizeFixedOffsetFromParent,
                                PositionUsesPivotPoint = true,
                                PivotPoint = OriginPoint.Center,
                                ParentOrigin = OriginPoint.Center,
                                BackgroundColor = Color.Green.WithAlpha(0.2f),
                            }.Self(view =>
                            {
                                view.SetResizePolicyFactor(new Size(-20, -20));
                            })
                        }
                    },

                    new ViewGroup
                    {
                        DesiredHeight = 300,
                        DesiredWidth = 300,
                        BackgroundColor = Color.Beige,
                        BorderlineColor = Color.Black,
                        BorderlineWidth = 1,
                        Children =
                        {
                            new View
                            {
                                HeightResizePolicy = ResizePolicy.SizeRelativeToParent,
                                WidthResizePolicy = ResizePolicy.SizeRelativeToParent,
                                PositionUsesPivotPoint = true,
                                PivotPoint = OriginPoint.Center,
                                ParentOrigin = OriginPoint.Center,
                                BackgroundColor = Color.Green.WithAlpha(0.2f),
                            }.Self(view =>
                            {
                                view.SetResizePolicyFactor(new Size(1.2f, 1.2f));
                            })
                        }
                    },
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
