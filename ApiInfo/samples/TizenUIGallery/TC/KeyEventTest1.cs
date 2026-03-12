using System;
using System.Linq;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class KeyEventTest1 : Grid, ITestCase
    {
        public KeyEventTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "KeyEvent Test",
                FontSize = 30,
            });

            Add(new HStack
            {
                new ViewGroup
                {
                    Name = "View1",
                    Focusable = true,
                    FocusableInTouch = true,
                    DesiredWidth = 300,
                    BackgroundColor = Color.Brown,
                    Children =
                    {
                        new TextView
                        {
                            Name = "Label1"
                        }
                    }
                },
                new ViewGroup
                {
                    Name = "View2",
                    Focusable = true,
                    FocusableInTouch = true,
                    DesiredWidth = 300,
                    BackgroundColor = Color.Brown,
                    Children =
                    {
                        new TextView
                        {
                            Name = "Label2"
                        }
                    }
                },
                new ViewGroup
                {
                    Name = "View3",
                    Focusable = true,
                    FocusableInTouch = true,
                    DesiredWidth = 300,
                    BackgroundColor = Color.Brown,
                    Children =
                    {
                        new TextView
                        {
                            Name = "Label3"
                        }
                    }
                },

            }.Row(1).VerticalLayoutAlignment(LayoutAlignment.Start).DesiredHeight(300).Spacing(10));

            this["View1"].Focused += OnFocused;
            this["View1"].Unfocused += OnUnfocused;
            this["View1"].KeyEvent += OnKeyEvent;
            this["View2"].Focused += OnFocused;
            this["View2"].Unfocused += OnUnfocused;
            this["View2"].KeyEvent += OnKeyEvent;
            this["View3"].Focused += OnFocused;
            this["View3"].Unfocused += OnUnfocused;
            this["View3"].KeyEvent += OnKeyEvent;
        }

        void OnKeyEvent(object sender, KeyEventArgs e)
        {
            if ((sender as ViewGroup)?.Children?.FirstOrDefault() is TextView label)
            {
                label.Text = $"{e.KeyEvent.KeyPressedName}";
            }
        }

        void OnUnfocused(object sender, EventArgs e)
        {
            (sender as View).BackgroundColor = Color.Brown;
        }

        void OnFocused(object sender, EventArgs e)
        {
            (sender as View).BackgroundColor = Color.Yellow;
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
