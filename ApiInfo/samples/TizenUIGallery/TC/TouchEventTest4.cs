using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    class TouchEventTest4 : ViewGroup, ITestCase
    {
        public TouchEventTest4()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "Touch event propagation test",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 80,
                FontSize = 50,
            });


            var target1 = new ViewGroup
            {
                Width = 600,
                Height = 200,
                BackgroundColor = Color.Violet,
                X = 100,
                Y = 300,
            };

            var target2 = new ViewGroup
            {
                Width = 200,
                Height = 200,
                BackgroundColor = Color.Green,
                X = 0,
                Y = 0,
            };

            var target3 = new ViewGroup
            {
                Width = 200,
                Height = 200,
                BackgroundColor = Color.Honeydew,
                X = 200,
                Y = 0,
            };

            target1.TouchEvent += (s, e) =>
            {
                e.Handled = true;
                Console.WriteLine($"Touch on target1 - {e.Touch[0].State}");
            };

            target2.TouchEvent += (s, e) =>
            {
                e.Handled = true;
                Console.WriteLine($"Touch on target2 - {e.Touch[0].State}");
            };

            target3.TouchEvent += (s, e) =>
            {
                e.Handled = true;
                Console.WriteLine($"Touch on target3 -  {e.Touch[0].State}");
            };

            Add(target1);
            target1.Add(target2);
            target2.Add(target3);
            
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
