using LayoutTest.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class ScrollToTest2 : Grid, ITestCase
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
        public ScrollToTest2()
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
                    new Button("+100")
                    {
                        Clicked = () =>
                        {
                            _viewModel.TargetNumber += 100;
                        }
                    },
                    new Button("-100")
                    {
                        Clicked = () =>
                        {
                            if (_viewModel.TargetNumber - 100 >= 0)
                                _viewModel.TargetNumber -= 100;
                        }
                    },
                    new Button("ScrollTo /w ani")
                    {
                        Clicked = () =>
                        {
                            (this["ScrollView"] as ScrollLayout).ScrollTo(_viewModel.TargetNumber, true);
                        }
                    },
                    new Button("ScrollTo")
                    {
                        Clicked = () =>
                        {
                            (this["ScrollView"] as ScrollLayout).ScrollTo(_viewModel.TargetNumber, false);
                        }
                    },
                    new TextView
                    {
                        DesiredWidth = 500,
                        DesiredHeight = 80,
                        FontSize = 30,
                        Name = "Log"
                    }
                }

            });

            _bindingSession.ViewModel = _viewModel;
            (this["TargetLabel"] as TextView).SetBinding(_bindingSession, (model, label) => label.Text = $"{model.TargetNumber} px", "TargetNumber");

            Add(new ScrollLayout
            {
                ScrollDirection = ScrollDirection.Horizontal,
                Name = "ScrollView",
                Content = new HStack
                {
                    Name = "HStack",
                    BackgroundColor = Color.Green,
                }
            }.Row(1));

            for (int i = 0; i < 500; i++)
            {
                var rnd = new Random();
                (this["HStack"] as Layout).Children.Add(new TextView
                {
                    FontSize = 20,
                    Text = $"{i + 1}",
                    HorizontalAlignment = TextAlignment.Center,
                    VerticalAlignment = TextAlignment.Center,
                    DesiredWidth = 50,
                    BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3), (float)(rnd.NextDouble() * 0.7 + 0.3)),
                });
            }

            (this["ScrollView"] as ScrollLayout).Scrolling += (s, e) =>
            {
                (this["Log"] as TextView).Text = $"ScrollPosition : {(this["ScrollView"] as ScrollLayout).ScrollPosition}";
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
