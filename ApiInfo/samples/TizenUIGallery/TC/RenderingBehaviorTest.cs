using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Internal;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class RenderingBehaviorTest : Grid, ITestCase
    {
        FrameUpdate _frameUpdate;
        Timer timer;
        public RenderingBehaviorTest()
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
                Text = "Rendering Behavior Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new HStack
                {
                    new Button("Continuously")
                    {
                        Clicked = () =>
                        {
                            Window.Default.SetRenderingBehavior(RenderingBehavior.Continuously);
                        }
                    },
                    new Button("If Required")
                    {
                        Clicked = () =>
                        {
                            Window.Default.SetRenderingBehavior(RenderingBehavior.IfRequired);
                        }
                    },
                    new Button("Refresh FrameCount")
                    {
                        Clicked = () =>
                        {
                            (this["Log"] as TextView).Text = $"Frame {_frameUpdate.FrameCount}";
                        }
                    },
                    new Button("Start Timer")
                    {
                        Clicked = () =>
                        {
                            if (timer == null)
                            {
                                timer = new Timer(15)
                                {
                                    TickHandler = () => {
                                        Console.WriteLine($"Frame {_frameUpdate.FrameCount}");
                                        ProcessorController.Instance.Awake();
                                        return true;
                                    }
                                };
                                timer.Start();
                            }
                        }
                    },
                    new Button("Stop Timer")
                    {
                        Clicked = () =>
                        {
                            timer?.Stop();
                        }
                    }
                }.Spacing(10),
                new TextView
                {
                    Name = "Log",
                    FontSize = 20,
                }
            }.Spacing(10).Row(1));

            _frameUpdate = new FrameUpdate();
            Window.Default.AddFrameUpdateCallback(_frameUpdate);
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Window.Default.RemoveFrameUpdateCallback(_frameUpdate);
            Dispose();
        }

        class FrameUpdate : FrameUpdateCallback
        {
            public int FrameCount { get; set; } = 0;

            protected override void OnUpdate(float elapsedSeconds)
            {
                FrameCount++;
                Console.WriteLine($"{FrameCount}");
            }
        }
    }
}
