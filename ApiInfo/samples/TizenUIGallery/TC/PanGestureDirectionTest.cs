using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class PanGestureDirectionTest : Grid, ITestCase
    {
        public PanGestureDirectionTest()
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
                Text = "PanGestureDirectionTest",
                FontSize = 30,
            });


            Add(new AbsoluteLayout
            {
                new VStack
                {
                    Name = "Target1",
                    ItemAlignment = LayoutAlignment.Center,
                    BackgroundColor = Color.Cornsilk,
                    Children =
                    {
                        new TextView
                        {
                            TextColor = Color.Black,
                            FontSize = 30,
                            Text = "Any"
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                        new TextView
                        {
                            IsMultiline = true,
                            TextColor = Color.Black,
                            FontSize = 30,
                            Name = "Label1"
                        }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center)
                    },
                    DesiredWidth = 300,
                    DesiredHeight = 300,
                }.LayoutBounds(0, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(50),
                new VStack
                {
                    Name = "Target2",
                    ItemAlignment = LayoutAlignment.Center,
                    BackgroundColor = Color.Cornsilk,
                    Children =
                    {
                        new TextView
                        {
                            TextColor = Color.Black,
                            FontSize = 30,
                            Text = "Horizontal"
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                        new TextView
                        {
                            IsMultiline = true,
                            TextColor = Color.Black,
                            FontSize = 30,
                            Name = "Label2"
                        }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center)
                    },
                    DesiredWidth = 300,
                    DesiredHeight = 300,
                }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                new VStack
                {
                    Name = "Target3",
                    ItemAlignment = LayoutAlignment.Center,
                    BackgroundColor = Color.Cornsilk,
                    Children =
                    {
                        new TextView
                        {
                            TextColor = Color.Black,
                            FontSize = 30,
                            Text = "Vertical"
                        }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                        new TextView
                        {
                            IsMultiline = true,
                            TextColor = Color.Black,
                            FontSize = 30,
                            Name = "Label3"
                        }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center)
                    },
                    DesiredWidth = 300,
                    DesiredHeight = 300,
                }.LayoutBounds(1f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(50),

            }.Row(1));

            var panAny = new PanGestureDetector();
            panAny.Attach(this["Target1"]);
            panAny.Detected += (s, e) =>
            {
                (this["Label1"] as TextView).Text = $"Detect : {e.Gesture.ScreenPosition}";
            };

            var panHorizontal = new PanGestureDetector { Direction = PanGestureDirection.Horizontal };
            panHorizontal.Attach(this["Target2"]);
            panHorizontal.Detected += (s, e) =>
            {
                (this["Label2"] as TextView).Text = $"Detect : {e.Gesture.ScreenPosition}";
            };

            var panVertical = new PanGestureDetector { Direction = PanGestureDirection.Vertical };
            panVertical.Attach(this["Target3"]);
            panVertical.Detected += (s, e) =>
            {
                (this["Label3"] as TextView).Text = $"Detect : {e.Gesture.ScreenPosition}";
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
