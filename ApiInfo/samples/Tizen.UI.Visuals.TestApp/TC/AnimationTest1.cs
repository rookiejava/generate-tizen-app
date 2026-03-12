using Tizen.UI;
using Tizen.UI.Components.Animations;
using Tizen.UI.Layouts;
using Tizen.UI.Visuals;

namespace VisualObjectTest.TC
{
    class AnimationTest1 : Grid, ITestCase
    {
        public AnimationTest1()
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
                Text = "AnimationTest1",
                FontSize = 30,
            });

            Add(new VStack
            {
                Name = "VStack",
                Children =
                {
                    new View
                    {
                        Name = "Target",
                        DesiredHeight = 200,
                        DesiredWidth = 300,
                        BackgroundColor = Color.White,
                        CornerRadius = 10,
                    },
                    new View
                    {
                        Name = "Target2",
                        DesiredHeight = 200,
                        DesiredWidth = 300,
                        BackgroundColor = Color.White,
                        CornerRadius = 10,
                    }.Add(new ColorVisual
                    {
                        ModifyHeight = -30,
                        ModifyWidth = -30,
                        PivotPoint = VisualAlign.Center,
                        Origin = VisualAlign.Center,
                        Color = Color.Yellow,
                    })
                }
            }.Row(1).Spacing(10));


            var visual1 = new ColorVisual
            {
                X = 10, 
                Y = 0.25f,
                Width = 0.1f,
                ModifyWidth = -20,
                Height = 10,
                TransformFlags = TransformFlags.YProportional | TransformFlags.WidthProportional,

                Color = Color.Red,
                CornerRadius = 1,
            };
            this["Target"].Visuals().Add(visual1);

            var visual2 = new ColorVisual
            {
                X = 10,
                Y = 0.75f,
                Width = 0.1f,
                ModifyWidth = -20,
                Height = 10,
                TransformFlags = TransformFlags.YProportional | TransformFlags.WidthProportional,

                Color = Color.Blue,
                CornerRadius = 1,
            };
            this["Target"].Visuals().Add(visual2);

            var tapGesture = new TapGestureDetector();
            tapGesture.Attach(this["Target"]);
            tapGesture.Detected += (s, e) =>
            {
                var animation = new UIAnimation(f =>
                {
                    visual1.Width = (f * 0.9f + 0.1f);
                });
                var animation2 = new UIAnimation(f =>
                {
                    visual2.Width = (f * 0.9f + 0.1f);
                }, easing: Easing.Sin);
                animation.Add(0, 1, animation2);
                animation.Commit(this["Target"], "Progress", length:2000);
            };

            var tapGesture2 = new TapGestureDetector();
            tapGesture2.Attach(this["Target2"]);
            tapGesture2.Detected += (s, e) =>
            {
                var animation = new UIAnimation(f =>
                {
                    (this["Target2"].Visuals()[0] as ColorVisual).CornerRadius = f;
                    var start = Color.Yellow;
                    var end = Color.Blue;
                    (this["Target2"].Visuals()[0] as ColorVisual).Color = new Color(start.R - (start.R - end.R) * f, start.G - (start.G - end.G) * f, start.B - (start.B - end.B) * f);
                });
                animation.Commit(this["Target2"], "Progress", length: 2000);
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
