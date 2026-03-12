using Tizen.UI;
using Tizen.UI.Components.Animations;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class AbsoluteLayoutTest2 : Grid, ITestCase
    {
        public AbsoluteLayoutTest2()
        {
            Name = "Outter";
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
                Text = "AbsoluteLayout Test2",
                FontSize = 30,
            });

            Add(new ViewGroup
            {
                Children =
                {
                    new AbsoluteLayout
                    {
                        Name = "AbsLayout",
                        BackgroundColor = Color.AliceBlue,
                        Width = 300,
                        Height = 200,
                        Children =
                        {

                            new View
                            {
                                DesiredHeight = 100,
                                DesiredWidth = 100,
                                BackgroundColor = Color.Blue
                            }.LayoutBounds(0, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(20, 20, 0, 0),
                            new View
                            {
                                DesiredHeight = 100,
                                DesiredWidth = 100,
                                BackgroundColor = Color.Red
                            }.LayoutBounds(0.5f, 1, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(0, 0, 0, 20),
                            new View
                            {
                                DesiredHeight = 100,
                                DesiredWidth = 100,
                                BackgroundColor = Color.Green
                            }.LayoutBounds(1, 0, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional).Margin(0, 20, 20, 0),
                        }
                    }
                }
            }.Row(1));

            var timer = new Timer(5000);
            timer.TickHandler = () =>
            {
                var target = this["AbsLayout"];
                UIAnimation animation = new UIAnimation();
                animation.Add(0, 0.5f, new UIAnimation(p =>
                {
                    target.Width = 300 + 500 * p;
                    target.Height = 200 + 300 * p;
                }));
                animation.Add(0.5f, 1, new UIAnimation(p =>
                {
                    target.Width = 800 - 500 * p;
                    target.Height = 500 - 300 * p;
                }));
                target.Animate("Size", animation, length: 2000);
                return true;
            };
            timer.Start();

            DetachedFromWindow += (s, e) =>
            {
                timer.Stop();
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
