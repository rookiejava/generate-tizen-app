using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    class MemoryProfile_Binding1 : ViewGroup, ITestCase
    {
        public MemoryProfile_Binding1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            
            var target = new View
            {
                Width = 300,
                Height = 300,
                BackgroundColor = Color.Violet,
                ParentOriginX = 0f,
                ParentOriginY = 0f,
                X = 0,
                Y = 0,
                PositionUsesPivotPoint = false,
            };
            Add(target);

            var model = new BindingMdoel1();
            model.X = 50;
            model.Y = 50;

            BindingSession<BindingMdoel1> session = new BindingSession<BindingMdoel1>();

            target.SetBinding(session, ViewBindings.XProperty, "X");
            target.SetBinding(session, ViewBindings.YProperty, "Y");
            session.ViewModel = model;

            Random rnd = new Random();
            var timer = Timer.Repeat(15, () =>
            {
                model.Move();
                return true;
            });

            DetachedFromWindow += (s, e) =>
            {
                timer.Stop();
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
    
    class BindingMdoel1 : ViewModel
    {
        public double XDistance { get; set; } = 10;
        public double YDistance { get; set; } = 5;


        public bool VerticalDirection { get; set; }
        public bool HorizontalDirection { get; set; }

        
        public float X 
        {
            get => Get<float>();
            set => Set(value);
        }
        public float Y
        {
            get => Get<float>();
            set => Set(value);
        }

        public void Move()
        {
            if (X < 0)
            {
                HorizontalDirection = true;
            }
            else if (X > 400)
            {
                HorizontalDirection = false;
            }
            if (Y < 0)
            {
                VerticalDirection = true;
            }
            else if (Y > 700)
            {
                VerticalDirection = false;
            }
            var currentX = X + XDistance * (HorizontalDirection ? 1 : -1);
            var currentY = Y + YDistance * (VerticalDirection ? 1 : -1);
            X = (float)currentX;
            Y = (float)currentY;
        }
    }
}
