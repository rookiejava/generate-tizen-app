using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class InputFieldTest1 : Grid, INavigationTransition, ITestCase
    {
        InputMethodContext _inputMethodContext;

        public InputFieldTest1()
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
                Text = "InputField test",
                FontSize = 30,
            });

            var target = new InputField
            {
                FontSize = 50,
                BackgroundColor = Color.Violet,
                VerticalAlignment = TextAlignment.End,
            };
            var target2 = new InputField
            {
                FontSize = 50,
                BackgroundColor = Color.LightBlue,
                Text = "InputMethodContext Test",
                TextOverflow = TextOverflow.EndEllipsis,
            };

            var target3 = new InputField
            {
                FontSize = 50,
                BackgroundColor = Color.Green,
                HorizontalAlignment = TextAlignment.End,
                VerticalAlignment = TextAlignment.Center,
                Text = "1234567890123456789012345678901234567890",
            };

            var target4 = new HStack
            {
                Spacing = 5,
                Children =
                {
                    new InputField
                    {
                        FontSize = 50,
                        Text = "<a href='www.tizen.org'>Click InputField Anchor</a>",
                        IsMarkupEnabled = true,
                        HorizontalAlignment = TextAlignment.Center,
                        VerticalAlignment = TextAlignment.Center,
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
                    target.PasswordMode = target.PasswordMode == HiddenInputMode.All ? HiddenInputMode.None : HiddenInputMode.All;
            };
            target.PlaceholderText = "Placeholder";

            _inputMethodContext = target2.InputMethodContext;
            target2.InputMethodContext.TextPrediction = true;
            target2.InputMethodContext.InputPanelStateChanged += OnInputPanelVisibilityChanged;
            target2.InputMethodContext.Resized += OnInputPanelAreaChanged;

            target3.SetInputMethodPanelType(PanelLayout.URL);
            target3.SetInputMethodCapitalMode(AutoCapital.AllCharacter);

            target3.TextChanged += (s, e) =>
            {
                if (target3.Text.Length < target3.MaximumLength)
                    target3.BackgroundColor = Color.Blue;
            };

            target3.MaximumLengthReached += (s, e) =>
            {
                Log.Debug($"InputField MaxLengthReached, Text Length={target3.Text.Length}");
                target3.BackgroundColor = Color.OrangeRed;
            };
        }

        public void WillAppear(bool byPopNavigation)
        {
        }

        public void WillDisappear(bool byPopNavigation)
        {
        }

        public void DidAppear(bool byPopNavigation)
        {
        }

        public void DidDisappear(bool byPopNavigation)
        {
            if (byPopNavigation)
            {
                Deactivate();
            }
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