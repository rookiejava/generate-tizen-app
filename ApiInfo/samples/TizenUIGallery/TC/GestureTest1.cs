using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class GestureTest1 : Grid, ITestCase
    {
        GestureDetector _detector;
        public GestureTest1()
        {
            Name = "Backgroud";

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
                Text = "Gesture Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new TextView
                {
                    Name = "Log",
                    FontSize = 20,
                    TextColor = Color.Black,
                    BackgroundColor = Color.White,
                },
                new View
                {
                    Name = "Area1",
                    BackgroundColor = Color.Gray,
                    DesiredHeight = 150,
                },
                new HStack
                {
                    new Grid
                    {
                        Name = "Area2",
                        DesiredHeight = 600,
                        DesiredWidth = 600,
                        BackgroundColor = Color.YellowGreen,
                        Children =
                        {
                            new View
                            {
                                Name = "InnerArea",
                                DesiredWidth = 300,
                                DesiredHeight = 300,
                                BackgroundColor = Color.Yellow,
                            }
                        }
                    },

                    new Grid
                    {
                        Name = "Intercept",
                        DesiredHeight = 600,
                        DesiredWidth = 600,
                        BackgroundColor = Color.LightBlue,
                        Children =
                        {
                            new View
                            {
                                Name = "Inner",
                                DesiredWidth = 300,
                                DesiredHeight = 300,
                                BackgroundColor = Color.Yellow,
                            }
                        }
                    },
                }.HorizontalLayoutAlignment(LayoutAlignment.Center).Spacing(10),
            }.Row(1));

            {
                var gesture = new TapGestureDetector();
                gesture.Attach(this["Area1"]);
                gesture.Attach(this["Area2"]);
                gesture.Attach(this["InnerArea"]);
                gesture.Attach(this);

                gesture.Detected += (s, e) =>
                {
                    (this["Log"] as TextView).Text = $"Tap On {e.View.Name}";
                    Console.WriteLine($"Tap On {e.View.Name}");

                    if (e.View == this["InnerArea"])
                    {
                        e.Handled = false;
                    }
                };
                _detector = gesture;
            }
            {
                var gesture = new LongPressGestureDetector();
                gesture.Attach(this["Area1"]);
                gesture.Attach(this["Area2"]);
                gesture.Attach(this["InnerArea"]);
                gesture.Attach(this);

                gesture.Detected += (s, e) =>
                {
                    (this["Log"] as TextView).Text = $"LongPress On {e.View.Name}";
                    Console.WriteLine($"LongPress On {e.View.Name}");

                    if (e.View == this["InnerArea"])
                    {
                        e.Handled = false;
                    }
                };
            }
            {
                var gesture = new PanGestureDetector();
                gesture.Attach(this["Area1"]);
                gesture.Attach(this["Area2"]);
                gesture.Attach(this["InnerArea"]);
                gesture.Attach(this);

                gesture.Detected += (s, e) =>
                {
                    (this["Log"] as TextView).Text = $"Pan On {e.View.Name} - {e.Gesture.Displacement}, State : {e.Gesture.State}";
                    Console.WriteLine($"Pan On {e.View.Name} - {e.Gesture.Displacement} , State : {e.Gesture.State}");

                    if (e.View == this["InnerArea"])
                    {
                        e.Handled = false;
                    }
                };
            }
            {
                var gesture = new PinchGestureDetector();
                gesture.Attach(this["Area1"]);
                gesture.Attach(this["Area2"]);
                gesture.Attach(this["InnerArea"]);
                gesture.Attach(this);

                gesture.Detected += (s, e) =>
                {
                    (this["Log"] as TextView).Text = $"Pinch On {e.View.Name} - {e.Gesture.Scale}";
                    Console.WriteLine($"Pinch On {e.View.Name} - {e.Gesture.Scale}");

                    if (e.View == this["InnerArea"])
                    {
                        e.Handled = false;
                    }
                };
            }

            {
                var gesture = new PanGestureDetector();
                gesture.Attach(this["Inner"]);
                gesture.Detected += (s, e) =>
                {
                    Console.WriteLine($"Pan on Inner {e.Gesture.State}");
                };
                this["Inner"].TouchEvent += (s, e) => { e.Handled = true; };

                var gesture2 = new PanGestureDetector();
                this["Intercept"].InterceptTouchEvent += (s, e) =>
                {
#if API11_OR_GREATER
                    gesture2.HandleEvent(s as View, e.Touch);
#endif
                };
                gesture2.Detected += (s, e) =>
                {
                    Console.WriteLine($"Pan on Intercept {e.Gesture.State}");
                };
            }

        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            // dispose test
            _detector?.Dispose();
            Dispose();
        }
    }
}
