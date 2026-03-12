using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class TextEditorTest1 : Grid, ITestCase
    {
        public TextEditorTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(50);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "TextEidtor test",
                FontSize = 30,
            });

            var target = new TextEditor
            {
                FontSize = 20,
                BackgroundColor = Color.Violet,
            };
            var target2 = new TextEditor
            {
                FontSize = 20,
                BackgroundColor = Color.LightBlue,
                Text = "InputMethodContext Test"
            };

            var target3 = new TextEditor
            {
                FontSize = 20,
                BackgroundColor = Color.Green,
                MaxLength = 30,
                PlaceholderText = "MaxLenght: 30"
            };

            var target4 = new HStack
            {
                Spacing = 5,
                Children =
                {
                    new TextEditor
                    {
                        FontSize = 50,
                        Text = "<a href='www.tizen.org'>Click TextEditor Anchor</a>",
                        IsMarkupEnabled = true,
                        BackgroundColor = Color.BlueViolet
                    }.Self(view => view.AnchorClicked += (s, e) =>
                    {
                            (this["AnchorLabel"] as TextView).Text = e.Href;
                    }),
                    new TextView
                    {
                        FontSize = 50,
                        Name = "AnchorLabel",
                        BackgroundColor = Color.Yellow
                    },
                }
            };

            Add(target.Row(1));
            Add(target2.Row(2));
            Add(target3.Row(3));
            Add(target4.Row(4));

            target2.InputMethodContext.TextPrediction = true;
            target2.InputMethodContext.InputPanelStateChanged += OnInputPanelVisibilityChanged;
            target2.InputMethodContext.Resized += OnInputPanelAreaChanged;
            target2.InputMethodContext.Resized += OnInputPanelAreaChanged;

            target3.TextChanged += (s, e) =>
            {
                Log.Debug($"TextEditor TextChanged, Length={target3.Text.Length}, MaxLength={target3.MaxLength}");
                if (target3.Text.Length < target3.MaxLength)
                    target3.BackgroundColor = Color.Green;
            };

            target3.MaxLengthReached += (s, e) =>
            {
                Log.Debug($"TextEditor MaxLengthReached, Text Length={target3.Text.Length}");
                target3.BackgroundColor = Color.OrangeRed;
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

        void OnInputPanelVisibilityChanged(object sender, EventArgs e)
        {
            InputPanelState panelState = (sender as InputMethodContext).InputPanelState;
            Log.Debug($"[StatusChanged][OnInputPanelVisibilityChanged]visibility state = {panelState}");
        }

        void OnInputPanelAreaChanged(object sender, EventArgs e)
        {
            Log.Debug($"InputMethodArea = {(sender as InputMethodContext).InputMethodArea}");
        }
    }
}
