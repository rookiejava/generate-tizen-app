using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.Util
{
    public class Button : Grid
    {
        public Button(string text)
        {
            Focusable = true;
            FocusableInTouch = true;
            DesiredHeight = 60;
            Padding = 5;
            CornerRadius = 5;
            BackgroundColor = Color.BlueViolet;

            Add(new TextView
            {
                Name = "TextView",
                Text = text,
                FontSize = 20,
                TextColor = Color.White,
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
            });
            var tap = new TapGestureDetector();
            tap.Attach(this);
            tap.Detected += OnTapped;
            KeyEvent += Button_KeyEvent;
        }

        void Button_KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyEvent.State == KeyState.Down && e.KeyEvent.KeyPressedName == "Return")
            {
                e.Handled = true;
                Clicked?.Invoke();
            }
        }

        public bool FocusHighlightEnabled
        {
            set
            {
                if (value)
                {
                    Focused += OnFocused;
                    Unfocused += OnUnfocused;
                }
                else
                {
                    Focused -= OnFocused;
                    Unfocused -= OnUnfocused;
                }
            }
        }

        void OnUnfocused(object sender, EventArgs e)
        {
            BorderlineColor = Color.Red;
            BorderlineWidth = 0;
        }

        void OnFocused(object sender, EventArgs e)
        {
            BorderlineColor = Color.Red;
            BorderlineOffset = -1;
            BorderlineWidth = 5;
        }

        public string Text
        {
            get => (this["TextView"] as TextView).Text;
            set => (this["TextView"] as TextView).Text = value;
        }

        public Action Clicked { get; set; }

        void OnTapped(object sender, TapGestureDetectedEventArgs e)
        {
            Clicked?.Invoke();
        }
    }
}
