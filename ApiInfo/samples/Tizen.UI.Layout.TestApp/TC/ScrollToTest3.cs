using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollToTest3 : Grid, ITestCase
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
        public ScrollToTest3()
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

            var grid = new Grid();

            for (int i = 0; i < 50; i++)
            {
                grid.RowDefinitions.Add(80);
                grid.ColumnDefinitions.Add(80);
            }

            var rnd = new Random();
            for (int row = 0; row < 50; row++)
            {
                for (int col = 0; col < 50; col++)
                {
                    grid.Children.Add(new TextView
                    {
                        FontSize = 20,
                        Name = $"{row * 50 + col}",
                        Text = $"{row * 50 + col}",
                        VerticalAlignment = TextAlignment.Center,
                        HorizontalAlignment = TextAlignment.Center,
                        BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                    }.Row(row).Column(col));
                }
            }
            
            Add(new ScrollLayout
            {
                Focusable = true,
                FocusableInTouch = true,
                Name = "ScrollView",
                ScrollDirection = ScrollDirection.Both,
                Content = grid,
            }.Row(1));

            (this["ScrollView"] as ScrollLayout).ScrollStarted += (s, e) =>
            {
                Console.WriteLine($"ScrollStart-----");
            };

            (this["ScrollView"] as ScrollLayout).ScrollFinished += (s, e) =>
            {
                Console.WriteLine($"ScrollEnd----");
            };

            (this["ScrollView"] as ScrollLayout).Scrolling += (s, e) =>
            {
                Console.WriteLine($"Scrolling : {(this["ScrollView"] as ScrollLayout).ScrollPosition}");
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
    }
}
