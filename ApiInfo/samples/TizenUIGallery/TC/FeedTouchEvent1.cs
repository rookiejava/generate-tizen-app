using TizenUIGallery.Util;
using System.Threading.Tasks;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class FeedTouchEvent1 : Grid, ITestCase
    {
        public FeedTouchEvent1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Auto);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "FeedTouchEvent1",
                FontSize = 30,
            });

            InterceptTouchEvent += (s, e) =>
            {
                Console.WriteLine($"Intercept Touch :({e.Touch[0].State}) ScreenPosition {e.Touch[0].ScreenPosition}");
            };

            Add(new VStack
            {
                new Button("Trigger Touch event after 1 second")
                {
                    Clicked = async () =>
                    {
                        await Task.Delay(1000);
                        var screenPos = this["BackButton"].ScreenPosition;

                        var touchdown = new TouchPoint(Window.Default.GetLastTouchEvent()[0].DeviceId, TouchState.Down, screenPos.X + 10, screenPos.Y + 10);
                        Window.Default.FeedTouch(touchdown, (int)Window.Default.GetLastTouchEvent().Time + 1000);

                        await Task.Delay(100);

                        var touchup = new TouchPoint(Window.Default.GetLastTouchEvent()[0].DeviceId, TouchState.Up, screenPos.X + 10, screenPos.Y + 10);
                        Window.Default.FeedTouch(touchup, (int)Window.Default.GetLastTouchEvent().Time + 100);
                    }
                },
                new Button("BackButton")
                {
                    Name = "BackButton",
                    Clicked = () =>
                    {
                        var keyEvent = new KeyEvent();
                        keyEvent.KeyPressedName = "XF86Back";
                        keyEvent.State = KeyState.Up;
                        Window.Default.FeedKey(keyEvent);
                    }
                }.Margin(10),
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
    }
}
