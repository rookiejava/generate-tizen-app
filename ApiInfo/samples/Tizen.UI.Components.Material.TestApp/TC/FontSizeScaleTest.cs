using ElmSharp.Accessible;
using System;

using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class FontSizeScaleTest : ScrollView, INavigationTransition, ITestCase
    {
        private const float _fontSize = 20f;
        private readonly float _rangeScaleMin = 0.5f;
        private readonly float _rangeScaleMax = 2.5f;
        private Label _label;
        private Label _valueLabel;
        private Label _valueLabelAdjusted;
        private Label _valueLabelMin;
        private Label _valueLabelMax;
        private Checkbox _check;

        public FontSizeScaleTest() : base()
        {
            BackgroundColor = MaterialColor.Background;
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            Content = CreateContents();
            UpdateValueLabel();
        }

        private VStack CreateContents()
        {
            return new VStack()
            {
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 10f,
                Padding = new (10f),
                Children =
                {
                    CreateCheckboxSection("SystemFontSizeScaleEnabled", (checkbox) =>
                    {
                        _label.SystemFontSizeScaleEnabled = checkbox.IsSelected;
                        UpdateValueLabel();
                    }),
                    CreateSystemScaleSection(),
                    CreateSliderSection("FontSizeScale", defaultValue: 1f, _rangeScaleMin, _rangeScaleMax, (slider, label) =>
                    {
                        _label.FontSizeScale = slider.Value;
                        _check.IsSelected = _label.SystemFontSizeScaleEnabled;
                        label.Text = slider.Value.ToString("0.##");
                        UpdateValueLabel();
                    }),
                    CreateSliderSection("MinimumFontSizeScale", defaultValue: _rangeScaleMin, _rangeScaleMin, _rangeScaleMax, (slider, label) =>
                    {
                        _label.MinimumFontSizeScale = slider.Value;
                        label.Text = slider.Value.ToString("0.##");
                        UpdateValueLabel();
                    }),
                    CreateSliderSection("MaximumFontSizeScale", defaultValue: _rangeScaleMax, _rangeScaleMin, _rangeScaleMax, (slider, label) =>
                    {
                        _label.MaximumFontSizeScale = slider.Value;
                        label.Text = slider.Value.ToString("0.##");
                        UpdateValueLabel();
                    }),
                    CreateSliderSection("LineHeight", defaultValue: 1f, minValue: 1f, maxValue: 3f, (slider, label) =>
                    {
                        _label.LineHeight = slider.Value;
                        label.Text = slider.Value.ToString("0.##");
                        UpdateValueLabel();
                    }),
                    CreateValueLabels(),
                    new Label()
                    {
                        Text = "Result",
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    },
                    // Result
                    new Label()
                    {
                        Text = $"Label FontSize:{_fontSize}",
                        FontSize = _fontSize,
                        FontSizeScale = 1.0f,
                        MaximumFontSizeScale = 2f,
                        TextColor = MaterialColor.SurfaceContainer,
                        BackgroundColor = MaterialColor.OnSurface
                    }
                    .Start()
                    .Self(out _label)
                }
            };
        }

        private View CreateSystemScaleSection()
        {
            return new HStack()
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                ItemAlignment = LayoutAlignment.Start,
                Spacing = 10f,
                Children =
                {
                    new Label()
                    {
                        Text = "SystemFontSizeScale",
                        DesiredWidth = 250f,
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    }.Center(),
                    new LevelBar(0.5f, 1.5f, 4)
                    {
                        Value = DummyFontScaleLoader.Instance.FontScale
                    }
                    .Expand()
                    .Self(out var slider),
                    new Label()
                    {
                        Text = slider.Value.ToString("0.##"),
                        DesiredWidth = 60f,
                        TextColor = MaterialColor.OnSurfaceContainerHighest,
                        FontSize = _fontSize
                    }
                    .Center()
                    .Self(out var label)
                    .Self((_) =>
                    {
                        slider.ValueChanged += (_, _) =>
                        {
                            label.Text = slider.Value.ToString("0.##");
                            DummyFontScaleLoader.Instance.FontScale = slider.Value;
                            UpdateValueLabel();
                        };
                    })
                },
            };
        }

        private ClickableHStack CreateCheckboxSection(string title, Action<Checkbox> onCheckedChanged)
        {
            return new ClickableHStack()
            {
                BackgroundColor = MaterialColor.Surface,
                BorderlineWidth = 1f,
                BorderlineColor = Color.Gray,
                CornerRadius = new(5f),
                Padding = new(16f, 8f),
                ItemAlignment = LayoutAlignment.Start,
                Children =
                {
                    new Label(title)
                    {
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    }
                    .Center(),
                    new Checkbox()
                    {
                        SelectedChangedCommand = (s, e) => onCheckedChanged(s as Checkbox)
                    }
                    .EndHorizontal()
                    .Expand()
                    .Self(out _check)
                },
                ClickedCommand = (s, e) =>
                {
                    _check.Toggle(e.InputDevice);
                }
            };
        }

        private HStack CreateSliderSection(string title, float defaultValue, float minValue, float maxValue, Action<Slider, Label> onValueChanged)
        {
            return new HStack()
            {
                ItemAlignment = LayoutAlignment.Start,
                Spacing = 10f,
                Children =
                {
                    new Label()
                    {
                        Text = title,
                        DesiredWidth = 250f,
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    }
                    .Center(),
                    new Slider(minValue, maxValue)
                    {
                        Value = defaultValue
                    }
                    .Expand()
                    .Self(out var slider),
                    new Label()
                    {
                        Text = slider.Value.ToString("0.##"),
                        DesiredWidth = 60f,
                        TextColor = MaterialColor.OnSurfaceContainerHighest,
                        FontSize = _fontSize
                    }
                    .Center()
                    .Self(out var label)
                    .Self((_) =>
                    {
                        slider.ValueChanged += (_, _) => onValueChanged(slider, label);
                    })
                },
            };
        }

        private VStack CreateValueLabels()
        {
            return new VStack()
            {
                BackgroundColor = MaterialColor.Surface,
                BorderlineWidth = 1f,
                BorderlineColor = Color.Gray,
                CornerRadius = new (5f),
                Spacing = 5f,
                Padding = new (16f, 8f),
                ItemAlignment = LayoutAlignment.Center,
                Children =
                {
                    new Label()
                    {
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    }
                    .Self(out _valueLabel),
                    new Label()
                    {
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    }
                    .Self(out _valueLabelAdjusted),
                    new Label()
                    {
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    }
                    .Self(out _valueLabelMin),
                    new Label()
                    {
                        FontSize = _fontSize,
                        TextColor = MaterialColor.OnSurfaceContainerHighest
                    }
                    .Self(out _valueLabelMax)
                }
            };
        }

        public void UpdateValueLabel()
        {
            _valueLabel.Text = $"FontSizeScale:{_label.FontSizeScale}";
            _valueLabelAdjusted.Text = $"AdjustedFontSizeScale:{_label.AdjustedFontSizeScale}";
            _valueLabelMin.Text = $"MinimumFontSizeScale:{_label.MinimumFontSizeScale}";
            _valueLabelMax.Text = $"MaximumFontSizeScale:{_label.MaximumFontSizeScale}";
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
