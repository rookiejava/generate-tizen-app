using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    class TouchEventTest2 : ViewGroup, ITestCase
    {
        public TouchEventTest2()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            var target = new View
            {
                Width = 200,
                Height = 200,
                BackgroundColor = Color.Violet,
                X = 100,
                Y = 100,
                TouchEdgeInsets = new Thickness(0, 50),
            };
            Add(target);

            target.TouchEvent += (s, e) =>
            {

                if (e.Touch[0].State == TouchState.Down)
                {
                    var rnd = new Random();
                    target.BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7), (float)(rnd.NextDouble() * 0.7), (float)(rnd.NextDouble() * 0.7), 1);
                }
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
