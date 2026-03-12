using TizenUIGallery.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class DisallowInterceptTouchTest : Grid, ITestCase
    {
        public DisallowInterceptTouchTest()
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
                Text = "DisallowInterceptTouchEvent test",
                FontSize = 30,
            });

            Add(new TouchableGradientBackground
            {
                Children =
                {
                    new Grid
                    {
                        new PriorityTouchableGradientBackground(),
                    }.Padding(10).BorderlineColor(Color.Red).BorderlineWidth(2),

                    new DownConsumeView().Row(0).Column(1).Margin(100),

                    new TouchableGradientBackground().Row(1).Column(1).BorderlineColor(Color.Green).BorderlineWidth(2),

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

        class TouchableGradientBackground : Grid
        {
            LinearGradientBackground _background;
            List<float> stops = new() { 0f, .2f, .4f, .6f, .8f, 1f };
            int startIndex = 0;
            public TouchableGradientBackground()
            {
                RowDefinitions.Add(GridLength.Star);
                RowDefinitions.Add(GridLength.Star);
                ColumnDefinitions.Add(GridLength.Star);
                ColumnDefinitions.Add(GridLength.Star);

                BorderlineColor = Color.White;
                BorderlineWidth = 2;

                _background = new LinearGradientBackground
                {
                    StartPoint = new Point(-1, 0),
                    EndPoint = new Point(1, 0),
                    GradientStops =
                    {
                        new GradientStop(Color.Red, stops[0]),
                        new GradientStop(Color.Orange, stops[1]),
                        new GradientStop(Color.Yellow, stops[2]),
                        new GradientStop(Color.Green, stops[3]),
                        new GradientStop(Color.Blue, stops[4]),
                        new GradientStop(Color.Navy, stops[5]),
                    }
                };

                InterceptTouchEvent += OnInterceptTouchEvent;
                TouchEvent += OnTouchEvent;
                SetBackground(_background);
            }

            protected virtual void OnTouchEvent(object sender, TouchEventArgs e)
            {
                Console.WriteLine($"OnTouchEvent - {e.Touch[0].State}");

                if (e.Touch[0].State == TouchState.Motion)
                {
                    Move();
                    e.Handled = true;
                }
            }

            Point lastPoint;
            void OnInterceptTouchEvent(object sender, TouchEventArgs e)
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    lastPoint = e.Touch[0].ScreenPosition;
                }
                else if (e.Touch[0].State == TouchState.Motion)
                {
                    Move();
                    e.Handled = true;
                }
            }

            void Move()
            {
                startIndex++;
                for (int i = 0; i < _background.GradientStops.Count; i++)
                {
                    _background.GradientStops[i] = _background.GradientStops[i] with { Offset = stops[(i + startIndex) % 6] };
                }
                SetBackground(_background);
            }
        }

        class PriorityTouchableGradientBackground : TouchableGradientBackground
        {
            protected override void OnTouchEvent(object sender, TouchEventArgs e)
            {
                if (e.Touch[0].State == TouchState.Started)
                {
                    Parent.DisallowInterceptTouchEvent = true;
                }
                else if (e.Touch[0].State == TouchState.Finished || e.Touch[0].State == TouchState.Interrupted)
                {
                    Parent.DisallowInterceptTouchEvent = false;
                }
                base.OnTouchEvent(sender, e);
            }
        }

        class DownConsumeView : View
        {
            public DownConsumeView()
            {
                BackgroundColor = Color.LightBlue;
                TouchEvent += OnTouch;
            }

            void OnTouch(object sender, TouchEventArgs e)
            {
                e.Handled = true;
                if (e.Touch[0].State == TouchState.Down)
                {
                    BackgroundColor = Color.Cyan;
                }
                else if (e.Touch[0].State == TouchState.Up || e.Touch[0].State == TouchState.Interrupted)
                {
                    BackgroundColor = Color.LightBlue;
                }
            }
        }
    }
}
