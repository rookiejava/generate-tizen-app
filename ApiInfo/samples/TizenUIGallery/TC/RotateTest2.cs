using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class RotateTest2 : Grid, ITestCase
    {
        public RotateTest2()
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
                Text = "Rotate Test2",
                FontSize = 30,
            });
            Add(new AbsoluteLayout
            {
                new AbsoluteLayout
                {
                    CornerRadius = 0.1f,
                    ClippingMode = ClippingMode.ClipChildren,
                    Children = {
                        new ImageView
                        {
                            ResourceUrl = "img2.png",
                            FittingMode = FittingMode.ScaleToFill,
                            BackgroundColor = Color.LightBlue,
                            DesiredHeight = 600,
                            DesiredWidth = 400,
                        }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                        new View
                        {
                            ScaleX = 1.5f,
                            ScaleY = 1.5f,
                            Name = "Visual",
                            DesiredHeight = 600,
                            DesiredWidth = 400,
                        }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                    }
                }.Name("Target").LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
            }.Row(1));

            this["Target"].TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down || e.Touch[0].State == TouchState.Motion)
                {
                    var xRatio = ((e.Touch[0].Position.X - this["Target"].Width / 2f) / (this["Target"].Width / 2f)).Clamp(-1, 1);
                    var yRatio = ((e.Touch[0].Position.Y - this["Target"].Height / 2f) / (this["Target"].Height / 2f)).Clamp(-1, 1);

                    var ani = new Animation();
                    ani.AnimateTo(this["Target"], AnimatablePropertyValue.CreateRotationValue(yRatio * 30, -xRatio * 30, 0), 0, 50);
                    ani.AnimateTo(this["Visual"], AnimatablePropertyValue.CreatePositionValue(60 * xRatio, 60 * yRatio), 0, 50);
                    ani.Play();

                }
                else
                {
                    var ani = new Animation();
                    ani.AnimateTo(this["Target"], AnimatablePropertyValue.CreateRotationValue(0, 0, 0), 0, 250);
                    ani.AnimateTo(this["Visual"], AnimatablePropertyValue.CreatePositionValue(0, 0), 0, 250);
                    ani.Play();
                }
            };

            this["Visual"].SetBackground(new LinearGradientBackground
            {
                StartPoint = new Point(-1f, -1f),
                EndPoint = new Point(1f, 1f),
                GradientStops =
                {
                    new GradientStop(Color.White.WithAlpha(0f), 0.3f),
                    new GradientStop(Color.FromHex("#fffff0").WithAlpha(0.6f), 0.4f),
                    new GradientStop(Color.White.WithAlpha(0f), 0.5f),
                    new GradientStop(Color.FromHex("#fffff0").WithAlpha(0.6f), 0.6f),
                    new GradientStop(Color.White.WithAlpha(0f), 0.7f),
                }
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
