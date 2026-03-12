using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class VStackTest7 : Grid, ITestCase
    {
        public VStackTest7()
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
                Text = "Invisible spacing issue",
                FontSize = 30,
            });


            Add(new Grid
            {
                Children =
                {
                    new VStack
                    {
                        BorderlineWidth = 1,
                        BorderlineColor = Color.Black,
                        Spacing = 20,
                        Children =
                        {
                            new TextView
                            {
                                Text = "Hello ",
                                BackgroundColor = Color.Yellow
                            }.Expand(),
                            new TextView
                            {
                                Text = " World",
                                IsVisible = false,
                                BackgroundColor = Color.Yellow
                            }
                        }
                    }.Center(),

                    new VStack
                    {
                        BorderlineWidth = 1,
                        BorderlineColor = Color.Black,
                        Spacing = 20,
                        Children =
                        {
                            new TextView
                            {
                                Text = "Hello ",
                                BackgroundColor = Color.Yellow,
                                IsVisible = false,
                            }.Expand(),
                            new TextView
                            {
                                Text = " World",
                                BackgroundColor = Color.Yellow
                            }
                        }
                    }.Center().Margin(300, 0, 0, 0),

                    new VStack
                    {
                        BorderlineWidth = 1,
                        BorderlineColor = Color.Black,
                        Spacing = 20,
                        Children =
                        {
                            new TextView
                            {
                                Text = "Hello ",
                                BackgroundColor = Color.Yellow,
                            }.Expand(),
                            new TextView
                            {
                                Text = " World",
                                BackgroundColor = Color.Yellow
                            }
                        }
                    }.Center().Margin(-300, 0, 0, 0),
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
