using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class LottieAnimationViewTest1 : Grid, ITestCase
    {
        public LottieAnimationViewTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "LottieAnimationView Test1",
                FontSize = 30,
            });

            Add(new ScrollLayout
            {
                Content = new VStack{
                    Spacing = 10,
                    Children = {
                        new TextView
                        {
                            Name = "Log",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            WidthResizePolicy = ResizePolicy.FillToParent,
                            FontSize = 20,
                            DesiredHeight = 50,
                        },
                        new TextView
                        {
                            Name = "Log2",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            FontSize = 20,
                            DesiredHeight = 50,
                        },
                        new LottieAnimationView
                        {
                            Name = "Lottie",
                            ParentOriginX = 0.5f,
                            ParentOriginY = 0f,
                            Height = 400,
                            Width = 400,
                            Y = 250,
                            X = 0,
                            PositionUsesPivotPoint = true,
                            PivotPointX = 0.5f,
                            PivotPointY = 0f,
                            BackgroundColor = Color.Yellow,
                            ResourceUrl = "cycle_animation.json",
                        },
                        new FlexBox
                        {
                            Wrap = FlexWrap.Wrap,
                            Children =
                            {
                                new Button("Set Frame + 10")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).CurrentFrame += 10;
                                    }
                                }.Margin(3),
                                new Button("Set Frame - 10")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).CurrentFrame -= 10;
                                    }
                                }.Margin(3),
                                new Button("Start")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Play();
                                    }
                                }.Margin(3),
                                new Button("Start - frame")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Play(50, 100);
                                    }
                                }.Margin(3),
                                new Button("Stop")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Stop();
                                    }
                                }.Margin(3),
                                new Button("Pause")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Pause();
                                    }
                                }.Margin(3),
                                new Button("RepeatMode")
                                {
                                    Clicked = () =>
                                    {
                                        var cur = (int)(this["Lottie"] as LottieAnimationView).RepeatMode;
                                        (this["Lottie"] as LottieAnimationView).RepeatMode = (AnimationRepeatMode)((cur + 1) % 2);
                                    }
                                }.Margin(3),
                                new Button("StopBehavior")
                                {
                                    Clicked = () =>
                                    {
                                        var cur = (int)(this["Lottie"] as LottieAnimationView).StopBehavior;
                                        (this["Lottie"] as LottieAnimationView).StopBehavior = (AnimationStopBehavior)((cur + 1) % 3);
                                    }
                                }.Margin(3),
                                new Button("Repeat + 1")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).RepeatCount += 1;
                                    }
                                }.Margin(3),
                                new Button("Repeat - 1")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).RepeatCount -= 1;
                                    }
                                }.Margin(3),
                            }
                        }
                    }
                }
            }.Row(1));

            Console.WriteLine($"--------- Default -------------------------------------------------------------");
            Console.WriteLine($"Total frame : {(this["Lottie"] as LottieAnimationView).TotalFrame}");
            Console.WriteLine($"Default : RepeatCount : {(this["Lottie"] as LottieAnimationView).RepeatCount}");
            Console.WriteLine($"Default : RepeatMode : {(this["Lottie"] as LottieAnimationView).RepeatMode}");
            Console.WriteLine($"Default : StopBehavior : {(this["Lottie"] as LottieAnimationView).StopBehavior}");
            (this["Lottie"] as LottieAnimationView).RepeatCount = 2;
            (this["Lottie"] as LottieAnimationView).StopBehavior = AnimationStopBehavior.CurrentFrame;
            (this["Lottie"] as LottieAnimationView).RepeatMode = AnimationRepeatMode.Reverse;

            Console.WriteLine($"RepeatCount : {(this["Lottie"] as LottieAnimationView).RepeatCount}");
            Console.WriteLine($"RepeatMode : {(this["Lottie"] as LottieAnimationView).RepeatMode}");
            Console.WriteLine($"StopBehavior : {(this["Lottie"] as LottieAnimationView).StopBehavior}");
            Console.WriteLine($"ContentInfo");
            var info = (this["Lottie"] as LottieAnimationView).GetContentInfo();
            foreach (var item in info)
            {
                Console.WriteLine($"  {item.Item1} : {item.Item2}, {item.Item3}");
            }

            Console.WriteLine($"----------------------------------------------------------------------");

            var timer = new Timer(100)
            {
                TickHandler = () =>
                {
                    (this["Log"] as TextView).Text = $"CurrentFrame:[{(this["Lottie"] as LottieAnimationView).CurrentFrame}] - state : [{(this["Lottie"] as LottieAnimationView).PlayState}]";
                    (this["Log2"] as TextView).Text = $"StopBehavior:[{(this["Lottie"] as LottieAnimationView).StopBehavior}] RepeatCount:[{(this["Lottie"] as LottieAnimationView).RepeatCount}] [{(this["Lottie"] as LottieAnimationView).RepeatMode}]";
                    return true;
                }
            };
            timer.Start();

            DetachedFromWindow += (s, e) =>
            {
                timer.Dispose();
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
