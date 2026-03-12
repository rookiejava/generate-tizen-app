using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class TextFieldTest1 : Grid, ITestCase
    {
        InputMethodContext _inputMethodContext;

        public TextFieldTest1()
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
                Text = "TextField test",
                FontSize = 30,
            });

            var target = new TextField
            {
                FontSize = 50,
                BackgroundColor = Color.Violet,
            };
            var target2 = new TextField
            {
                FontSize = 50,
                BackgroundColor = Color.LightBlue,
                Text = "InputMethodContext Test",
                TextOverflow = TextOverflow.EndEllipsis,
            };

            var target3 = new TextField
            {
                FontSize = 50,
                BackgroundColor = Color.Green,
                Text = "1234567890123456789012345678901234567890",
            };

            var target4 = new HStack
            {
                Spacing = 5,
                Children =
                {
                    new TextField
                    {
                        FontSize = 50,
                        Text = "<a href='www.tizen.org'>Click TextField Anchor</a>",
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
            target.TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Up)
                    target.IsPassword = !target.IsPassword;
            };
            target.PlaceholderText = "Placeholder";

            _inputMethodContext = target2.InputMethodContext;
            target2.InputMethodContext.TextPrediction = true;
            target2.InputMethodContext.InputPanelStateChanged += OnInputPanelVisibilityChanged;
            target2.InputMethodContext.Resized += OnInputPanelAreaChanged;

            target3.SetInputMethodSetting(new InputMethodSetting
            {
                PanelLayout = PanelLayout.URL,
                AutoCapital = AutoCapital.AllCharacter
            });

            target3.TextChanged += (s, e) =>
            {
                if (target3.Text.Length < target3.MaxLength)
                    target3.BackgroundColor = Color.Green;
            };

            target3.MaxLengthReached += (s, e) =>
            {
                Log.Debug($"TextField MaxLengthReached, Text Length={target3.Text.Length}");
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
            InputPanelState panelState = _inputMethodContext.InputPanelState;
            Log.Debug($"[StatusChanged] visibility state = {panelState}");
        }

        void OnInputPanelAreaChanged(object sender, EventArgs e)
        {
            Log.Debug($"[resized] InputMethodArea = {_inputMethodContext.InputMethodArea}");
        }
    }
}