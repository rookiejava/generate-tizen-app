using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class DividerTest : ScrollView, INavigationTransition, ITestCase
    {
        private readonly Divider _horizontalDivider;
        private readonly Divider _verticalDivider;

        public DividerTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                ItemAlignment = LayoutAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.SizeRelativeToParent,
                Spacing = 10f,
                Children =
                {
                    new Divider()
                    {
                        DesiredWidth = 300,
                        DesiredHeight = 60,
                    }
                    .Self(out _horizontalDivider),
                    new Divider(DividerDirection.Vertical)
                    {
                        DesiredWidth = 60,
                        DesiredHeight = 300,
                    }
                    .Self(out _verticalDivider),
                    new Button("Dividers-line")
                    {
                        ClickedCommand = (s, e) =>
                        {
                            if ((s as Button).Text == "Dividers-line")
                            {
                                (s as Button).Text = "Dividers-dashed";
                                _horizontalDivider.Style = DividerStyle.Dashed;
                                _verticalDivider.Style = DividerStyle.Dashed;
                            }
                            else if ((s as Button).Text == "Dividers-dashed")
                            {
                                (s as Button).Text = "Dividers-dotted";
                                _horizontalDivider.Style = DividerStyle.Dotted;
                                _verticalDivider.Style = DividerStyle.Dotted;
                            }
                            else if ((s as Button).Text == "Dividers-dotted")
                            {
                                (s as Button).Text = "Dividers-color";
                                _horizontalDivider.DividerColor = Color.Red; // custom color
                                _verticalDivider.DividerColor = Color.Red; // custom color
                            }
                            else if ((s as Button).Text == "Dividers-color")
                            {
                                (s as Button).Text = "Dividers-line";
                                _horizontalDivider.Style = DividerStyle.Line;
                                _verticalDivider.Style = DividerStyle.Line;
                                _horizontalDivider.DividerColor = new Color(0xD6D6D8, 1f); // origin color
                                _verticalDivider.DividerColor = new Color(0xD6D6D8, 1f); // origin color
                                _horizontalDivider.Thickness = 1f;
                                _verticalDivider.Thickness = 1f;
                            }
                        }
                    },
                    new Button("Thikness +")
                    {
                        ClickedCommand = (s, e) =>
                        {
                            _horizontalDivider.Thickness += 1f;
                            _verticalDivider.Thickness += 1f;
                        }
                    },
                    new Button("Thikness -")
                    {
                        ClickedCommand = (s, e) =>
                        {
                            if (_horizontalDivider.Thickness > 2f)
                            {
                                _horizontalDivider.Thickness -= 1f;
                                _verticalDivider.Thickness -= 1f;
                            }
                            else
                            {
                                _horizontalDivider.Thickness = 1f;
                                _verticalDivider.Thickness = 1f;
                            }
                        }
                    }
                }
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
