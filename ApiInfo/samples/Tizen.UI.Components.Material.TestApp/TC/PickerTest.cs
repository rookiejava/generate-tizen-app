using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using System.Collections.ObjectModel;

namespace ComponentsTest
{
    internal class PickerTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;
        private readonly Label pickerValueLabel;
        private readonly Picker picker;

        public PickerTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            string[] textValue = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
            Content = new VStack()
            {
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20f,
                BackgroundColor = MaterialColor.Background,
                Padding = new (0f, 20f),

                Children =
                {
                    new Label()
                    {
                        Text = "1. Number Picker",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },
                    new Picker(new ClosedRange<int>(1, 100))
                    {
                    }
                    .Self(out picker),
                    new Label()
                    {
                        Text = "Picker Value : " + picker.Value.ToString(),
                        FontSize = 60f
                    }
                    .Self(out pickerValueLabel),
                    new Label()
                    {
                        Text = "2. Picker with displayed values",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    },
                    new Picker(new ClosedRange<int>(0, 10))
                    {
                        Value = 5,
                        DisplayedValues = new ReadOnlyCollection<string>(textValue)
                    }
                }
            };

            picker.ValueChanged += (s, e) =>
            {
                var picker = s as Picker;
                pickerValueLabel.Text = "Picker Value : " + picker.Value.ToString();
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
        }
        public void Deactivate()
        {
        }
    }
}
