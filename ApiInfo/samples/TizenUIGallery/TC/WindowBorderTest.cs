using TizenUIGallery.Util;
using System;
using System.ComponentModel;
using Tizen.UI;
using Tizen.UI.Internal;
using Tizen.UI.Layouts;
using Tizen.UI.WindowBorder;

namespace TizenUIGallery.TC
{
    public class WindowBorderTest : Grid, ITestCase
    {
        public WindowBorderTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "WindowBorder Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new Button("MoveBar")
                {
                    Name = "MoveBar"
                },
                new Button("SetBorder")
                {
                    Clicked = () =>
                    {
                        var border = new BorderView();
                        Window.Default.SetBorderView(border);
                    }
                },
                new Button("SetBorder - header")
                {
                    Clicked = () =>
                    {
                        Window.Default.Title = "TizenUIGallery";
                        var border = new BorderView(new ViewTemplate(typeof(CustomHeader)), null)
                        {
                            CornerRadius = new CornerRadius(0, 0, 0.03f, 0.03f)
                        };
                        Window.Default.SetBorderView(border);
                    }
                },
                new Button("SetBorder - header/footer")
                {
                    Clicked = () =>
                    {
                        Window.Default.Title = "TizenUIGallery";
                        var border = new BorderView(new ViewTemplate(typeof(CustomHeader)))
                        {
                            CornerRadius = new CornerRadius(0, 0, 0.03f, 0.03f),
                            BorderActiveColor = Color.Red,
                        };
                        Window.Default.SetBorderView(border);
                    }
                },
                new Button("Border on new window")
                {
                    Clicked = () =>
                    {
                        var win = new Window
                        {
                            Title = "Popup"
                        };

                        win.Maximize(false);
                        win.SetSize(300, 200);
                        win.DefaultLayer.Add(new AbsoluteLayout
                        {
                            BackgroundColor = Color.LightGreen,
                            Children =
                            {
                                new TextView
                                {
                                    Text = "Popup window",
                                    FontSize = 30,
                                    TextColor = Color.Black,
                                }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                            }
                        });

                        var border = new BorderView(new ViewTemplate(typeof(CustomHeader)))
                        {
                            CornerRadius = new CornerRadius(0, 0, 0.03f, 0.03f)
                        };
                        win.SetBorderView(border);
                    }
                },
                new Button("ClearBorder")
                {
                    Clicked = () =>
                    {
                        Window.Default.ClearBorderView();
                    }
                },
            }.Row(1).Margin(10, 10, 10, 10).Spacing(10));

            ClippingMode = ClippingMode.ClipChildren;
            CornerRadius = new CornerRadius(0.03f);

            this["MoveBar"].TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    _ = Window.Default.StartMoveRequest();
                    e.Handled = true;
                }
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

        class CustomHeader : Grid, IBindableView
        {
            // TODO : Need to update with EmbeddedResource
            const string MinimizeIcon = $"{ResourceManager.CommonResourcePath}minimalize.png";
            const string MaximizeIcon = $"{ResourceManager.CommonResourcePath}maximalize.png";
            const string SmallWindowIcon = $"{ResourceManager.CommonResourcePath}smallwindow.png";
            const string CloseIcon = $"{ResourceManager.CommonResourcePath}close.png";
            ImageView _minimize;
            ImageView _maximize;
            ImageView _closeButton;
            TextView _title;

            TapGestureDetector _tapGestureDetector = new TapGestureDetector();

            public CustomHeader()
            {
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f);
                ColumnDefinitions.Add(20);
                ColumnDefinitions.Add(GridLength.Star);
                ColumnDefinitions.Add(GridLength.Auto);
                ColumnDefinitions.Add(GridLength.Auto);
                ColumnDefinitions.Add(GridLength.Auto);
                ColumnDefinitions.Add(20);
                // TODO: Need to check pixel size to response various dpi
                RowDefinitions.Add(48);

                _minimize = new ImageView()
                {
                    SynchronousLoading = true,
                    ResourceUrl = MinimizeIcon
                };
                _maximize = new ImageView()
                {
                    SynchronousLoading = true,
                    ResourceUrl = MaximizeIcon
                };
                _closeButton = new ImageView()
                {
                    SynchronousLoading = true,
                    ResourceUrl = CloseIcon
                };

                _title = new TextView()
                {
                    FontSize = 20,
                    TextColor = Color.Black,
                    VerticalAlignment = TextAlignment.Center,
                    HorizontalAlignment = TextAlignment.Start,
                };

                Add(_title.Column(1));
                Add(_minimize.Column(2));
                Add(_maximize.Column(3));
                Add(_closeButton.Column(4));

                _tapGestureDetector.Detected += OnTapDetected;
                _tapGestureDetector.Attach(_maximize);
                _tapGestureDetector.Attach(_minimize);
                _tapGestureDetector.Attach(_closeButton);
            }

            void OnTapDetected(object sender, TapGestureDetectedEventArgs e)
            {
                if (e.View == _maximize)
                {
                    if (_viewModel != null)
                    {
                        _viewModel.MaximizeAction(!_viewModel.IsMaximized);
                    }
                    e.Handled = true;
                }
                else if (e.View == _minimize)
                {
                    _viewModel?.MinimizeAction();
                    e.Handled = true;
                }
                else if (e.View == _closeButton)
                {
                    _viewModel?.CloseAction();
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }

            public bool IsMaximized => _viewModel?.IsMaximized ?? false;

            BorderView.BorderViewModel _viewModel;

            public object BindingContext
            {
                get => _viewModel;
                set
                {
                    if (_viewModel != null)
                    {

                    }

                    _viewModel = value as BorderView.BorderViewModel;

                    if (_viewModel != null)
                    {
                        _viewModel.PropertyChanged += OnPropertyChanged;
                        UpdateIsMaximized(_viewModel.IsMaximized);
                        UpdateTitle();
                    }
                }
            }

            void UpdateIsMaximized(bool maximized)
            {
                _maximize.ResourceUrl = maximized ? SmallWindowIcon : MaximizeIcon;
            }

            void UpdateTitle()
            {
                _title.Text = _viewModel?.TargetWindow?.Title ?? string.Empty;
            }

            void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (_viewModel == null)
                    return;

                if (e.PropertyName == nameof(BorderView.BorderViewModel.IsMaximized))
                {
                    UpdateIsMaximized(_viewModel.IsMaximized);
                }
                else if (e.PropertyName == nameof(BorderView.BorderViewModel.TargetWindow))
                {
                    UpdateTitle();
                }
            }
        }

    }
}
