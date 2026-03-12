using System;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    public class Particle : View
    {

        public double Velocity { get; set; }
        public double Direction { get; set; }

        public double XDistance { get; set; }
        public double YDistance { get; set; }

        public bool VerticalDirection { get; set; }
        public bool HorizontalDirection { get; set; }

        public Particle()
        {
            var rand = new Random();
            Velocity = rand.NextDouble() * 20 + 5d;
            Direction = rand.NextDouble();
            var vv = Velocity * Velocity;
            XDistance = Math.Sqrt(vv * Direction);
            YDistance = Math.Sqrt(vv * (1 - Direction));
        }

        public void Move()
        {
            var parent = Parent;
            if (parent == null)
                return;

            if (X < 0)
            {
                HorizontalDirection = true;
            }
            else if (X > parent.Width)
            {
                HorizontalDirection = false;
            }
            if (Y < 0)
            {
                VerticalDirection = true;
            }
            else if (Y > parent.Height)
            {
                VerticalDirection = false;
            }

            var currentX = X + XDistance * (HorizontalDirection ? 1 : -1);
            var currentY = Y + YDistance * (VerticalDirection ? 1 : -1);
            X = (float)currentX;
            Y = (float)currentY;
        }

        public void MoveWithAnimation()
        {
            var parent = Parent;
            if (parent == null)
                return;


            if (X < 0)
            {
                HorizontalDirection = true;
            }
            else if (X > parent.Width)
            {
                HorizontalDirection = false;
            }
            if (Y < 0)
            {
                VerticalDirection = true;
            }
            else if (Y > parent.Height)
            {
                VerticalDirection = false;
            }

            var currentX = X + XDistance * (HorizontalDirection ? 1 : -1);
            var currentY = Y + YDistance * (VerticalDirection ? 1 : -1);

            //_ = this.MoveTo((float)currentX, (float)currentY, 100);
            Animation animation = new Animation();
            animation.AnimateTo(this, AnimatablePropertyValue.CreatePositionValue((float)currentX, (float)currentY), 0, 100);
            animation.Play();
        }

        public void MoveOnRenderThread(Point currentPos, out float currentX, out float currentY)
        {
            if (IsDisposed)
            {
                currentX = 0;
                currentY = 0;
                return;
            }

            var parent = Parent;
            if (currentPos.X < 0)
            {
                HorizontalDirection = true;
            }
            else if (currentPos.X > parent.Width)
            {
                HorizontalDirection = false;
            }
            if (currentPos.Y < 0)
            {
                VerticalDirection = true;
            }
            else if (currentPos.Y > parent.Height)
            {
                VerticalDirection = false;
            }

            currentX = (float)(currentPos.X + XDistance * (HorizontalDirection ? 1 : -1));
            currentY = (float)(currentPos.Y + YDistance * (VerticalDirection ? 1 : -1));
        }
    }
}
