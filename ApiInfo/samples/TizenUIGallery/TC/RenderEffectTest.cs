#if API12_OR_GREATER

using TizenUIGallery.Util;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class RenderEffectTest : Grid, ITestCase
    {
        public RenderEffectTest()
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
                Text = "RenderEffect Test",
                FontSize = 30,
            });

            var target = new View
            {
                DesiredHeight = 300,
                DesiredWidth = 300,
                BackgroundColor = Color.Violet,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1);
            Add(target);

            Add(new AbsoluteLayout
            {
                new AbsoluteLayout
                {
                    ClippingMode = ClippingMode.ClipChildren,
                    BorderlineColor = Color.Black,
                    BorderlineOffset = -1,
                    BorderlineWidth = 1,
                    CornerRadius = 20,
                    DesiredHeight = 300,
                    DesiredWidth = 400,
                    Name = "Target",
                    Children =
                    {
                        new ImageView
                        {
                            ResourceUrl = "dotnet_bot.png",
                            Name = "Image",
                            DesiredHeight = 100,
                            DesiredWidth = 100,
                        }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional),
                        new TextView
                        {
                            Name = "Text",
                            Text = "Hello"
                        }
                    }
                }.LayoutBounds(100, 100, -1, -1).LayoutFlags(AbsoluteLayoutFlags.None),

                new ImageView
                {
                    Name = "ImageTarget2",
                    ResourceUrl = "img2.png"
                }.LayoutBounds(300, 300, 200, 300).LayoutFlags(AbsoluteLayoutFlags.None),

                new HStack
                {
                    new Button("BackdropEffect to TextView")
                    {
                        Clicked = () =>
                        {
                            this["Text"].SetRenderEffect(RenderEffect.CreateBackdropBlurEffect(30));
                        }
                    },
                    new Button("BackdropEffect to Image")
                    {
                        Clicked = () =>
                        {
                            this["Image"].SetRenderEffect(RenderEffect.CreateBackdropBlurEffect(30));
                        }
                    },
                    new Button("GaussianBlur to Photo")
                    {
                        Clicked = () =>
                        {
                            this["ImageTarget2"].SetRenderEffect(RenderEffect.CreateGaussianBlurEffect(20));
                        }
                    },
                    new Button("BackdropEffect to Box")
                    {
                        Clicked = () =>
                        {
                            this["Target"].SetRenderEffect(RenderEffect.CreateBackdropBlurEffect(30));
                        }
                    },
                    new Button("Resize Box")
                    {
                        Clicked = () =>
                        {
                            this["Target"].DesiredHeight += 30;
                            this["Target"].DesiredWidth += 30;
                        }
                    },
                    new Button("Update TextView Text")
                    {
                        Clicked = () =>
                        {
                            (this["Text"] as TextView).Text += "!";
                        }
                    },
                    new Button("Clear")
                    {
                        Clicked = () =>
                        {
                            this["Text"].SetRenderEffect(null);
                            this["Image"].SetRenderEffect(null);
                            this["Target"].SetRenderEffect(null);
                            this["ImageTarget2"].SetRenderEffect(null);
                        }
                    }
                }.Spacing(10)

            }.Row(1).Background(new ImageBackground
            {
                Url = "bg.png"
            }));

            UIApplication.Current.PostToUI(() =>
            {
                this["Image"].SetRenderEffect(RenderEffect.CreateBackdropBlurEffect(30));
                this["Text"].SetRenderEffect(RenderEffect.CreateBackdropBlurEffect(30));
            });

            this["Target"].SetRenderEffect(RenderEffect.CreateBackdropBlurEffect(30));

            var pan = new PanGestureDetector();
            pan.Attach(this["Target"]);
            pan.Attach(this["ImageTarget2"]);
            pan.Detected += (s, e) => {
                var bound = (e.View).AbsoluteParam().LayoutBounds;
                bound.X += e.Gesture.ScreenDisplacement.X;
                bound.Y += e.Gesture.ScreenDisplacement.Y;
                (e.View).LayoutBounds(bound.X, bound.Y, bound.Width, bound.Height);
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

#endif