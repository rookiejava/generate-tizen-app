using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class LottieAnimationViewTest2 : Grid, ITestCase
    {
        public LottieAnimationViewTest2()
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
                Text = "LottieAnimationView Test2",
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
                        new TextEditor
                        {
                            Name = "Log2",
                            BackgroundColor = Color.Yellow,
                            HorizontalAlignment = TextAlignment.Center,
                            VerticalAlignment = TextAlignment.Center,
                            FontSize = 20,
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
                            ResourceUrl = "light_bulb.json",
                        },
                        new FlexBox
                        {
                            Wrap = FlexWrap.Wrap,
                            Children =
                            {
                                new Button("Play()")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Play();
                                    }
                                }.Margin(3),
                                 new Button("Play(\"activate:start\")")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Play("activate:start");
                                    }
                                }.Margin(3),
                                new Button("Play(\"activate:start\", \"inactivate:end\")")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Play("activate:start", "inactivate:end");
                                    }
                                }.Margin(3),
                                new Button("Play(\"inactivate:start\", \"inactivate:end\")")
                                {
                                    Clicked = () =>
                                    {
                                        (this["Lottie"] as LottieAnimationView).Play("inactivate:start", "inactivate:end");
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
                            }
                        }
                    }
                }
            }.Row(1));

            var info = (this["Lottie"] as LottieAnimationView).GetMarkerInfo();
            (this["Log2"] as TextEditor).Text = $"GetMarkerInfo()";
            foreach (var item in info)
            {
                Log.Error($"  {item.Item1} : {item.Item2}, {item.Item3}");
                (this["Log2"] as TextEditor).Text += $"\n [{item.Item1} : {item.Item2}, {item.Item3}]";
            }

            var timer = new Timer(100)
            {
                TickHandler = () =>
                {
                    (this["Log"] as TextView).Text = $"CurrentFrame:[{(this["Lottie"] as LottieAnimationView).CurrentFrame}] - state : [{(this["Lottie"] as LottieAnimationView).PlayState}]";
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
