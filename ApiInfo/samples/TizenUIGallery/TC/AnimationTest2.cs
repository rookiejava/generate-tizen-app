using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class AnimationTest2 : Grid, ITestCase
    {
        public AnimationTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Animation Test2",
                FontSize = 30,
            });

            var target = new View
            {
                DesiredHeight = 300,
                DesiredWidth = 300,
                BackgroundColor = Color.Violet,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1);
            Add(target);

            Add(new FlexBox
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new Button("Custom Value")
                    {
                        Clicked = async () =>
                        {
                            var origin = target.X;
                            var animation = new Animation();
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateCustomValue("PositionX", target.X + 100), 0, 1000);
                            animation.Play();
                            await Task.Delay(1000);
                            await target.MoveTo(origin, target.Y);
                        }
                    }.Margin(10),
                    new Button("RotateTo")
                    {
                        Clicked = async () =>
                        {
                            var origin = target.Rotation;
                            await target.RotateTo(target.Rotation + 45, 1000);
                            await Task.Delay(1000);
                            await target.RotateTo(origin);
                        }
                    }.Margin(10),
                    new Button("User alpha")
                    {
                        Clicked = async () =>
                        {
                            var animation = new Animation();
                            var alpha = new AlphaFunction((f)=>{
                                Console.WriteLine($"User alpha : {f}");
                                return f;
                            });
                            var originX = target.X;
                            var originY = target.Y;
                            animation.AnimateTo(target, AnimatablePropertyValue.CreatePositionValue(target.X - 100, target.Y), 0, 1000, alpha);
                            animation.Play();
                            await Task.Delay(1000);
                            await target.MoveTo(originX, originY);
                        }
                    }.Margin(10),
                    new Button("MoveTo")
                    {
                        Clicked = async () =>
                        {
                            await target.MoveTo(target.X - 100, target.Y, 1000);
                            await target.MoveTo(target.X + 100, target.Y, 1000);
                        }
                    }.Margin(10),
                    new Button("RotateTo2")
                    {
                        Clicked = async () =>
                        {
                            Console.WriteLine($"Current Rotate : {target.Rotation}");
                            await target.RotateTo(target.Rotation - 45, 1000);
                            Console.WriteLine($"after animation Current Rotate : {target.Rotation}");
                            await target.RotateTo(target.Rotation, 1000);
                        }
                    }.Margin(10),
                    new Button("EaseIn")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            var alpha = new AlphaFunction(BuiltinAlphaFunctions.EaseIn);
                            animation.AnimateTo(target, AnimatablePropertyValue.CreatePositionValue(target.X - 100, target.Y), 0, 1000, alpha);
                            animation.AnimateTo(target, AnimatablePropertyValue.CreatePositionValue(target.X, target.Y), 1000, 1000, alpha);
                            animation.Play();
                        }
                    }.Margin(10),
                    new Button("Scale")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            var alpha = new AlphaFunction(BuiltinAlphaFunctions.EaseInSine);
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateScaleValue(1.5f, 1.5f), 0, 1000, alpha);
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateScaleValue(1, 1), 1000, 1000, alpha);
                            animation.Play();
                        }
                    }.Margin(10),
                    new Button("Bezier")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            var alpha = new AlphaFunction(new Point(0.5f, 0), new Point(0.7f, 1));
                            animation.AnimateTo(target, AnimatablePropertyValue.CreatePositionValue(target.X - 100, target.Y), 0, 1000, alpha);
                            animation.AnimateTo(target, AnimatablePropertyValue.CreatePositionValue(target.X, target.Y), 1000, 1000, alpha);
                            animation.Play();
                        }
                    }.Margin(10),
                    new Button("Size")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateSizeValue(target.Width +100, target.Height + 100), 0, 100);
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateSizeValue(target.Width, target.Height), 100, 100);
                            animation.Play();
                        }
                    }.Margin(10),
                },
            }.Row(2));
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
