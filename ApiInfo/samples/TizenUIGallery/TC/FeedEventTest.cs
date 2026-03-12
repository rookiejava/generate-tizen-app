using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class FeedEventTest1 : Grid, ITestCase
    {
        public FeedEventTest1()
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
                Text = "FeedKey event test",
                FontSize = 30,
            });

            Add(new Button("Touch is BackButton event")
            {
                Clicked = () =>
                {
                    var keyEvent = new KeyEvent();
                    keyEvent.KeyPressedName = "XF86Back";
                    keyEvent.State = KeyState.Up;
                    Window.Default.FeedKey(keyEvent);
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
    }
}
