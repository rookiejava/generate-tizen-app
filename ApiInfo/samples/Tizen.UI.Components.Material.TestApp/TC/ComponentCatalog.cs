using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using System.Collections.Generic;

namespace ComponentsTest
{
    internal class ComponentCatalog : Grid, INavigationTransition, ITestCase
    {
        const string contentText = "hac dictum mauris massa penatibus sapien iaculis ornare,"
            + "facilisi malesuada quam est ullamcorper fusce. Interdum etiam himenaeos sapien molestie"
            + "facilisi malesuada quam est sem tempus metus penatibusff sem tempus metus penatibusff.";

        List<View> _components = new();

        public ComponentCatalog()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0xf1f1f3, 1);

            InitializeComponents();

            Grid _componentGrid = new Grid()
            {
                Padding = 10,
                RowSpacing = 20,
                ColumnSpacing = 20,
                ColumnDefinitions = { GridLength.Star, GridLength.Star, GridLength.Star},
            }.FillHorizontal().FillVertical();

            var scrollView = new ScrollView
            {
                Content = _componentGrid
            }.Row(1);
            Add(scrollView);

            GenerateCatalog(_componentGrid);
        }

        void GenerateCatalog(Grid grid)
        {
            int _numColumns = 3;
            int _numRows = _components.Count % _numColumns == 0 ? _components.Count / _numColumns : (_components.Count / _numColumns) + 1;
            for (int i = 0; i < _numRows; i++)
            {
                grid.RowDefinitions.Add( GridLength.Star );
            }
            for(int i=0; i < _components.Count; i++)
            {
                int row = i / _numColumns;
                int col = i % _numColumns;

                var component = _components[i];
                grid.Add(component, row, col);
            }
        }

        void InitializeComponents()
        {
            _components.Add(new BackButton());
            _components.Add(new VStack()
            {
                Spacing = 10,
                Padding = 10,
                Children = {
                    new Button() { Text = "Button" },
                    new Button("Flat button", ButtonVariables.Flat)
                }
            });
            _components.Add(new VStack()
            {
                Spacing = 10,
                Padding = 10,
                Children = {
                    new IconButton(MaterialIcon.Lock)
                    {
                        IconMultipliedColor = MaterialColor.Primary
                    }.CenterHorizontal(),
                    new IconButton(MaterialIcon.Add, IconButtonVariables.FAB)
                    {
                        IconMultipliedColor = MaterialColor.Primary,
                        ClickedCommand = (s, e) =>
                        {
                            (s as IconButton).CornerRadius = CornerRadius.Zero;
                        }
                    }
                }
            });
            _components.Add(new HStack()
            {
                Children = {
                    new Checkbox() { IsSelected = true },
                    new Checkbox() { IsSelected = false },
                    new Checkbox() { IsSelected = true }
                }
            }.Center());
            _components.Add(new CircleButton(MaterialIcon.Home) { });
            _components.Add(new VStack()
            {
                Children = {
                new Divider { DesiredWidth=150, DesiredHeight=30, Thickness = 5f, Style = DividerStyle.Dashed, DividerColor = Color.Blue },
                new Divider { DesiredWidth=150, DesiredHeight=30, Thickness = 5f, Style = DividerStyle.Dotted, DividerColor = Color.Red },
                new Divider { DesiredWidth=150, DesiredHeight=30, Thickness = 5f, Style = DividerStyle.Line, DividerColor = Color.Black }
                }
            }.Center());
            _components.Add(new LevelBar(-10, 10, 5)
            {
                Value = 5
            });
            _components.Add(new InputEditor()
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                DesiredWidth = 180f,
                DesiredHeight = 80f,
                Text = "InputEditor",
                FontSize = 20,
            }.Center());
            _components.Add(new InputField()
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                DesiredWidth = 180f,
                DesiredHeight = 80f,
                Text = "InputField",
                FontSize = 20,
            }.Center());
            _components.Add(new Label()
            {
                Text = "Label" 
            }.Center());
            _components.Add(new ProgressBar()
            {
                DesiredWidth = 200,
                IsDeterminate = false
            });
            _components.Add(new ProgressCircle(0, 100)
            {
                DesiredWidth = 200,
                Value = 50
            });
            _components.Add(new ProgressCircle()
            {
                Width = 100,
                IsDeterminate = false
            });
            _components.Add(new MoreButton());
            _components.Add(new HStack()
            {
                Spacing = 10,
                Children =
                        {
                            new RadioButton()
                            {
                                GroupName = "RadioGroup1"
                            },
                            new RadioButton()
                            {
                                IsSelected = true,
                                GroupName = "RadioGroup1"
                            },
                            new RadioButton()
                            {
                                GroupName = "RadioGroup1"
                            }
                        }
            }.Center());
            _components.Add(new VStack()
            {
                Spacing = 10,
                Children = {
                    new Slider(0, 100) { Value = 50 },
                    new CustomSlider(-10, 10)
                    {
                        Value = 0f,
                        Padding = new (0, 20f, 0, 35f)
                    }
                }
            });
            _components.Add(new SpinnerButton()
            {
                ModalContent = new DropdownList()
                {
                    Items =
                    {
                        new DropdownCheckItem("Item1"),
                        new DropdownCheckItem("Item2"),
                        new DropdownCheckItem("Item3"),
                    },
                }
            });
            _components.Add(new VStack()
            {
                Spacing = 20f,
                Children =
                        {
                            new Switch(){ IsSelected = true },
                            new Switch(){ IsSelected = false }
                        }
            }.CenterVertical());

            _components.Add(new DefaultSmallCard("Default Small Card", contentText, "OK"));
            _components.Add(new DropdownList()
            {
                Items =
                {
                    new DropdownCheckItem("Item1"),
                    new DropdownCheckItem("Item2"),
                    new DropdownCheckItem("Item3"),
                },
                DismissedCommand = (s, _) => new Toast((s as DropdownList).SelectedItem.Text).Post()
            });
            _components.Add(new HStack()
            {
                Spacing = 20f,
                DesiredHeight = 200,
                Children =
                        {
                            new SmartTip("Light Gray"),
                            new SmartTip("Dark Gray", SmartTipVariables.DarkGray)
                        }
            }.CenterHorizontal());
            _components.Add(new Button("Show AlertDialog")
            {
                ClickedCommand = (_, _) =>
                {
                    var alertDialog = new AlertDialog()
                    {
                        Title = "Title",
                        Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                    };
                    alertDialog.SetActionButtons(("Cancel", (o, e) => this.GetNavigation().PopModalAsync()), ("OK", (o, e) => this.GetNavigation().PopModalAsync()));
                    this.GetNavigation().PushModalAsync(new DialogContainer()
                    {
                        ModalContent = alertDialog
                    });
                }
            });
            _components.Add(new Button("Show BottomSheet")
            {
                ClickedCommand = (o, e) =>
                {
                    this.GetNavigation().PushModalAsync(new BottomSheetContainer()
                    {
                        ModalContent = new BottomSheet()
                        {
                            Content = new VStack()
                                    {
                                        new Label()
                                        {
                                            Text = "BottomSheet TextView",
                                        },
                                        new Button("BottomSheet Button")
                                        {
                                            ClickedCommand = (o, e) => new Toast("Button").Post()
                                        },
                                    }
                        }
                    });
                }
            });
            _components.Add(new Button("Show Dialog")
            {
                ClickedCommand = (s, e) =>
                {
                    this.GetNavigation().PushModalAsync(new DialogContainer()
                    {
                        ModalContent = new Dialog
                        {
                            HeaderView = new Label
                            {
                                Text = "Title",
                                TextColor = MaterialColor.OnSurfaceContainerHighest,
                                FontSize = MaterialFontSize.Lg,
                                FontFamily = MaterialFont.Normal600,
                            }.Margin(MaterialSpacing.Lg700, 0),
                            BodyView = new Label
                            {
                                IsMultiline = true,
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis cursus arcu. Nam pellentesque est id urna gravida feugiat. Aliquam tortor justo, iaculis a congue porttitor, egestas eget tortor.",
                                TextColor = MaterialColor.OnSurfaceContainerHigher,
                                FontSize = MaterialFontSize.Sm,
                                FontFamily = MaterialFont.Normal400,
                            }.Margin(MaterialSpacing.Lg700, 0),
                            FooterView = new HStack()
                            {
                                Spacing = MaterialSpacing.Md400,
                                Children =
                                        {
                                            new Button("Cancel")
                                            {
                                                TextColor = MaterialColor.OnSurfaceContainerSemi,
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                CornerRadius = MaterialCorner.Full,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                ClickedCommand = (s, e) =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                            new Button("OK")
                                            {
                                                TextColor = MaterialColor.OnSurfaceContainerSemi,
                                                FontSize = MaterialFontSize.Sm2,
                                                FontFamily = MaterialFont.Normal600,
                                                CornerRadius = MaterialCorner.Full,
                                                Padding = new Thickness(MaterialSpacing.Md200, MaterialSpacing.Xs20),
                                                BackgroundColor = MaterialColor.SurfaceContainerSemi,
                                                ClickedCommand = (s, e) =>
                                                {
                                                    this.GetNavigation().PopModalAsync();
                                                }
                                            }.MinimumWidth(144.Spx()).MinimumHeight(64.Spx()),
                                        }
                            }.Margin(MaterialSpacing.Lg700, MaterialSpacing.Sm60, MaterialSpacing.Lg700, 0).CenterHorizontal(),
                        }
                    });
                }
            });
            _components.Add(new Button("Long Text > Expand > Dismiss")
            {
                FontSize = 20f,
                ClickedCommand = (s, e) =>
                {
                    SnackBar SnackBar = new SnackBar("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor");
                    SnackBar.ActionButtonClicked += (s, e) =>
                    {
                        if ((e as SnackBarActionEventArgs).Action == SnackBarAction.ConfirmInDefaultMode)
                        {
                            SnackBar.ActionButtonText = "Delete";
                            SnackBar.ActionButtonTextColor = MaterialColor.Red;
                            Console.WriteLine("Clicked in default mode");
                        }
                    };
                    SnackBar.Post();
                }
            });
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
            Dispose();
        }
    }
}
