using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollToTest4 : Grid, ITestCase
    {
        class TestViewModel : ViewModel
        {
            public int TargetNumber
            {
                get => Get<int>();
                set => Set(value);
            }
        }

        TestViewModel _viewModel = new();
        BindingSession<TestViewModel> _bindingSession = new();

        ScrollToPosition _scrollToPosition;
        public ScrollToTest4()
        {
            Name = "Outter";
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(80);
            RowDefinitions.Add(GridLength.Star);

            Add(new HStack
            {
                Spacing = 5,
                Children =
                {
                    new TextView
                    {
                        FontSize = 30,
                        DesiredWidth = 100,
                        DesiredHeight = 75,
                        Name = "TargetLabel",
                        HorizontalAlignment = TextAlignment.End,
                        VerticalAlignment = TextAlignment.Center,
                    }.Margin(5),
                    new Button("^")
                    {
                        DesiredWidth = 40,
                        Clicked = () =>
                        {
                            if (_viewModel.TargetNumber < 2500)
                                _viewModel.TargetNumber++;
                        }
                    },
                    new Button("V")
                    {
                        DesiredWidth = 40,
                        Clicked = () =>
                        {
                            if (_viewModel.TargetNumber > 0)
                                _viewModel.TargetNumber--;
                        }
                    },
                    new Button("+10")
                    {
                        Clicked = () =>
                        {
                            if (_viewModel.TargetNumber + 10 < 2500)
                                _viewModel.TargetNumber += 10;
                        }
                    },
                    new Button("-10")
                    {
                        Clicked = () =>
                        {
                            if (_viewModel.TargetNumber - 10 > 0)
                                _viewModel.TargetNumber -= 10;
                        }
                    },
                    new Button("MakeVisible")
                    {
                        Name = "ScrollToPosition",
                        Clicked = () =>
                        {
                            _scrollToPosition = (ScrollToPosition)(((int)_scrollToPosition + 1) % 4);
                            (this["ScrollToPosition"] as Button).Text = _scrollToPosition.ToString();
                        }
                    },
                    new Button("ScrollTo /w ani")
                    {
                        Clicked = () =>
                        {
                            (this["ScrollView"] as ScrollLayout).ScrollTo(this[$"{_viewModel.TargetNumber}"], true, _scrollToPosition);
                        }
                    },
                    new Button("ScrollTo")
                    {
                        Clicked = () =>
                        {
                            (this["ScrollView"] as ScrollLayout).ScrollTo(this[$"{_viewModel.TargetNumber}"], false, _scrollToPosition);
                        }
                    }
                }

            });

            _bindingSession.ViewModel = _viewModel;
            (this["TargetLabel"] as TextView).SetBinding(_bindingSession, (model, label) => label.Text = $"{model.TargetNumber}", "TargetNumber");

            var stack = new VStack();

            var rnd = new Random();
            for (int row = 0; row < 500; row++)
            {
                stack.Children.Add(new TextView
                {
                    FontSize = 20,
                    Name = $"{row}",
                    Text = $"{row}",
                    VerticalAlignment = TextAlignment.Center,
                    HorizontalAlignment = TextAlignment.Center,
                    DesiredHeight = 50,
                    BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                });
            }

            Add(new ScrollLayout
            {
                Name = "ScrollView",
                ScrollDirection = ScrollDirection.Vertical,
                Content = stack,
            }.Row(1));
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
