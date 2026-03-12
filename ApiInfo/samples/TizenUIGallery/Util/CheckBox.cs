using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.Util
{
    public class CheckBox : Grid
    {
        bool _isChecked;
        ImageView _checkedView;

        public CheckBox(string text)
        {
            DesiredHeight = 60;
            Padding = 5;

            AccessibilityRole = AccessibilityRole.CheckBox;

            ColumnDefinitions.Add(40);
            ColumnDefinitions.Add(GridLength.Star);

            _checkedView = new ImageView
            {
                Name = "checkbox",
                Height = 30,
                Width = 30,
                ResourceUrl = "checkbox-unchecked.svg",
                FittingMode = FittingMode.ScaleToFit,
                AccessibilityRole = AccessibilityRole.None,
            }.Row(0).Column(0);
            Add(_checkedView);

            var label = new TextView
            {
                Name = "TextView",
                Text = text,
                FontSize = 25,
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Start,
                AccessibilityRole = AccessibilityRole.None,
            };
            Add(label.Row(0).Column(1));

            var tap = new TapGestureDetector();
            tap.Attach(this);
            tap.Detected += OnTapped;

#if API13_OR_GREATER
            AccessibilityActionReceived += (s, e) =>
            {
                if (e.ActionType == AccessibilityAction.Activated)
                {
                    IsChecked = !IsChecked;
                }
            };
#endif
        }

        public string Text
        {
            get => (this["TextView"] as TextView).Text;
            set => (this["TextView"] as TextView).Text = value;
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    _checkedView.ResourceUrl = _isChecked ? "checkbox-checked.svg" : "checkbox-unchecked.svg";
                    Toggled?.Invoke();
                }
            }
        }

        public Action Toggled { get; set; }

        void OnTapped(object sender, TapGestureDetectedEventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}
