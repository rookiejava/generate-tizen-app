using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    class TouchEventTest3 : ViewGroup, ITestCase
    {
        public TouchEventTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "Touch event intercept test",
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

            Add(new TextView
            {
                Name = "State",
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 100,
                Y = 100,
                Text = "Current Intercept View 1"
            });

            var target1 = new ViewGroup
            {
                Width = 200,
                Height = 200,
                BackgroundColor = Color.Violet,
                X = 100,
                Y = 300,
            };

            var target2 = new ViewGroup
            {
                Width = 200,
                Height = 200,
                BackgroundColor = Color.Violet,
                X = 0,
                Y = 0,
            };

            var target3 = new ViewGroup
            {
                Width = 200,
                Height = 200,
                BackgroundColor = Color.Violet,
                X = 0,
                Y = 0,
            };


            Add(target1);
            target1.Add(target2);
            target2.Add(target3);

            int cur = 1;

            target1.InterceptTouchEvent += (s, e) =>
            {
                Console.WriteLine($"Intercep on target1 {cur}");
                if (cur != 1)
                    return;

                e.Handled = true;
                if (e.Touch[0].State == TouchState.Up)
                {
                    cur = 2;
                    (this["State"] as TextView).Text = "Current Intercept View 2";
                }
            };

            target2.InterceptTouchEvent += (s, e) =>
            {
                Console.WriteLine($"Intercep on target2 {cur}");
                if (cur != 2)
                    return;

                e.Handled = true;
                if (e.Touch[0].State == TouchState.Up)
                {
                    cur = 3;
                    (this["State"] as TextView).Text = "Current Intercept View 3";
                }
            };

            target3.InterceptTouchEvent += (s, e) =>
            {
                Console.WriteLine($"Intercep on target3 {cur}");

                if (cur != 3)
                    return;

                e.Handled = true;
                if (e.Touch[0].State == TouchState.Up)
                {
                    cur = 1;
                    (this["State"] as TextView).Text = "Current Intercept View 1";
                }
            };

            target1.TouchEvent += (s, e) =>
            {
                Console.WriteLine($"Touch on Target1 - {e.Touch[0].State}");
                if (e.Touch[0].State != TouchState.Interrupted)
                    e.Handled = true;
            };

            target2.TouchEvent += (s, e) =>
            {
                Console.WriteLine($"Touch on Target2 - {e.Touch[0].State}");
                if (e.Touch[0].State != TouchState.Interrupted)
                    e.Handled = true;
            };

            target3.TouchEvent += (s, e) =>
            {
                Console.WriteLine($"Touch on Target3 - {e.Touch[0].State}");
                if (e.Touch[0].State != TouchState.Interrupted)
                    e.Handled = true;
            };

            Console.WriteLine($"Get window 1 : {Window.GetWindow(this)}");

            this.AttachedToWindow += (s, e) =>
            {
                Console.WriteLine($"Get window 2 : {Window.GetWindow(this)}");
            };
        }
        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);

            Window.Default.InterceptTouchEvent += Default_InterceptTouchEvent;
        }

        public void Deactivate()
        {
            Window.Default.InterceptTouchEvent -= Default_InterceptTouchEvent;
            Dispose();
        }


        void Default_InterceptTouchEvent(object sender, TouchEventArgs e)
        {
            Console.WriteLine($"Window InterceptTouchEvent - {(e.Touch.Count > 0 ? e.Touch[0].State.ToString() : "")}");
        }
    }
}
