using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    class ZOrderTest : ViewGroup, ITestCase
    {
        public ZOrderTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "ZOrder Test",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 100,
                FontSize = 60,
            });

            Add(new TextView
            {
                Text = "Click to bring up top",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                Height = 100,
                FontSize = 50,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Y = 100,
                BackgroundColor = Color.Gray,
            });

            Add(new View
            {
                Name = "View1",
                ParentOriginX = 0.5f,
                ParentOriginY = 0.5f,
                PositionUsesPivotPoint = true,
                Height = 200,
                Width = 200,
                Y = -150,
                BackgroundColor = Color.Yellow,
            });
            Add(new View
            {
                Name = "View2",
                ParentOriginX = 0.5f,
                ParentOriginY = 0.5f,
                PositionUsesPivotPoint = true,
                Height = 200,
                Width = 200,
                X = -150,
                BackgroundColor = Color.Green,
            });

            Add(new View
            {
                Name = "View3",
                ParentOriginX = 0.5f,
                ParentOriginY = 0.5f,
                PositionUsesPivotPoint = true,
                Height = 200,
                Width = 200,
                X = 150,
                BackgroundColor = Color.Blue,
            });

            Add(new View
            {
                Name = "View4",
                ParentOriginX = 0.5f,
                ParentOriginY = 0.5f,
                PositionUsesPivotPoint = true,
                Height = 200,
                Width = 200,
                Y = 150,
                BackgroundColor = Color.Red,
            });


            this["View1"].TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                    (s as View)?.RaiseToTop();
                else if (e.Touch[0].State == TouchState.Up)
                    (s as View)?.LowerToBottom();
            };
            this["View2"].TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                    (s as View)?.RaiseToTop();
                else if (e.Touch[0].State == TouchState.Up)
                    (s as View)?.LowerToBottom();
            };
            this["View3"].TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                    (s as View)?.RaiseToTop();
                else if (e.Touch[0].State == TouchState.Up)
                    (s as View)?.LowerToBottom();
            };
            this["View4"].TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                    (s as View)?.RaiseToTop();
                else if (e.Touch[0].State == TouchState.Up)
                    (s as View)?.LowerToBottom();
            };

            this["View4"].AttachedToWindow += (s, e) =>
            {
                Console.WriteLine("View4 is attached Window");
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
