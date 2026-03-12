using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace DeclarativeSample.Util
{

    public class Button : ContentView
    {
        public Button(string text)
        {
            BackgroundColor = Color.BlueViolet;
            DesiredHeight = 60;
            Body = new ButtonContent(text)
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
            };
        }

        ButtonContent Inner => Body as ButtonContent;

        public string Text
        {
            get => Inner.Text;
            set => Inner.Text = value;
        }

        public Action Clicked
        {
            get => Inner.Clicked;
            set => Inner.Clicked = value;
        }
    }

    public class ButtonContent : Grid
    {
        public ButtonContent(string text)
        {
            Padding = 5;
            CornerRadius = 5;

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
