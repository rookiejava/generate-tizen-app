using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class SmartTipTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 16f;
        private static SmartTipArrowPosition _test2ArrowPosition = SmartTipArrowPosition.TopLeft;
        private SmartTipMenu _smartTipMenu;

        public SmartTipTest() : base()
        {
            BackgroundColor = new Color(0xF1F1F3, 1f);

            Content = new VStack()
            {
                Padding = 32f,
                Spacing = 32f,
                Children =
                {
                    new Label()
                    {
                        Text = "1. Basic SmartTips",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new HStack()
                    {
                        Spacing = 20f,
                        Children =
                        {
                            new SmartTip("Light Gray"),
                            new SmartTip("Dark Gray", SmartTipVariables.DarkGray)
                        }
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "2. SmartTipsView can contain any",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new SmartTipView()
                    {
                        Content = new HStack()
                        {
                            Padding = new (20f),
                            Spacing = 10f,
                            Children =
                            {
                                new Image(MaterialIcon.Photo)
                                {
                                    MultipliedColor = MaterialColor.Primary
                                },
                                new Label("Hello World")
                            }
                        }
                    }.CenterHorizontal(),
                    new SmartTipMenu()
                    {
                        TitleFillColor = MaterialColor.OnSurfaceContainerLowest,
                        TitleContent = new Label("Title")
                        {
                            TextColor = MaterialColor.Surface,
                            HorizontalAlignment = TextAlignment.Center,
                        }
                        .Self(out var title)
                        .Self(_ => title.SetTextPadding(10f))
                        .FillHorizontal(),
                        Content = new HStack()
                        {
                            Padding = new (10f),
                            Spacing = 10f,
                            ItemAlignment = LayoutAlignment.Center,
                            Children =
                            {
                                new IconButton(MaterialIcon.ArrowUp)
                                {
                                    IconMultipliedColor = MaterialColor.OnSurface,
                                    Padding = new (10),
                                    IconWidth = 30f,
                                    IconHeight = 30,
                                    ClickedCommand = (_, _) => title.FontSize += 10
                                }.CenterVertical(),
                                new IconButton(MaterialIcon.ArrowDown)
                                {
                                    IconMultipliedColor = MaterialColor.OnSurface,
                                    Padding = new (10),
                                    IconWidth = 30f,
                                    IconHeight = 30,
                                    ClickedCommand = (_, _) => title.FontSize = Math.Max(0, title.FontSize - 10)
                                }.CenterVertical(),
                                new IconButton(MaterialIcon.ArrowRight)
                                {
                                    IconMultipliedColor = MaterialColor.OnSurface,
                                    Padding = new (10),
                                    IconWidth = 30f,
                                    IconHeight = 30,
                                    ClickedCommand = (_, _) => _smartTipMenu.ArrowPosition = (SmartTipArrowPosition)(((int)_smartTipMenu.ArrowPosition + 1) % 9)
                                }.CenterVertical(),
                            }
                        }
                    }
                    .CenterHorizontal()
                    .Self(out _smartTipMenu),
                    new Label()
                    {
                        Text = "4. Post single SmartTip",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("Click to post")
                    {
                        ClickedCommand = (s, _) =>
                        {
                            new SmartTip("Hello World")
                            {
                                ArrowPosition = _test2ArrowPosition
                            }
                            .Post(s as View);
                        }
                    }.CenterHorizontal(),
                    new FlexBox()
                    {
                        JustifyContent = FlexJustify.SpaceAround,
                        Wrap = FlexWrap.Wrap,
                        Children =
                        {
                            new WithText(SmartTipArrowPosition.TopLeft)
                            {
                                IsSelected = true
                            },
                            new WithText(SmartTipArrowPosition.Top),
                            new WithText(SmartTipArrowPosition.TopRight),
                            new WithText(SmartTipArrowPosition.Left),
                            new WithText(SmartTipArrowPosition.Right),
                            new WithText(SmartTipArrowPosition.BottomLeft),
                            new WithText(SmartTipArrowPosition.Bottom),
                            new WithText(SmartTipArrowPosition.BottomRight),
                            new WithText(SmartTipArrowPosition.None)
                        }
                    }.CenterHorizontal(),
                    new Label()
                    {
                        Text = "5. Post multiple SmartTips",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.CenterHorizontal(),
                    new Button("Click to post")
                    {
                        ClickedCommand = (s, _) =>
                        {
                            var buttonBounds = (s as View).GetScreenBounds();

                            new SmartTip("A")
                            {
                                ArrowPosition = SmartTipArrowPosition.BottomLeft,
                            }
                            .Self(out var smartTipA)
                            .Post(new Point(buttonBounds.X, buttonBounds.Y));

                            new SmartTip("B")
                            {
                                ArrowPosition = SmartTipArrowPosition.BottomRight,
                                DismissedCommand = (_, _) => smartTipA.Dismiss()
                            }
                            .Post(new Point(buttonBounds.X + buttonBounds.Width, buttonBounds.Y));
                        }
                    }.CenterHorizontal()
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

        private class WithText : GroupSelectableBox
        {
            private static readonly string s_groupName = "ComponentsTest.SmartTipTest.WithText";
            private readonly SmartTipArrowPosition _arrowPosition;
            private HStack _stack;

            public WithText(SmartTipArrowPosition arrowPosition)
            {
                GroupName = s_groupName;
                Name = arrowPosition.ToString() + "-arrow";
                _arrowPosition = arrowPosition;
                this.Margin(2);

                Body = new HStack()
                {
                    Spacing = 2f,
                    Children =
                    {
                        new RadioButton()
                        {
                            IsClickable = false
                        }
                        .Self(out var radioButton),
                        new Label(Name)
                        {
                            FontSize = s_fontSize,
                            TextColor = Color.Black,
                            VerticalAlignment = TextAlignment.Center
                        }
                        .Fill().Expand()
                    }
                }
                .Self(out _stack);

                DesiredWidth = 300f;
                CornerRadius = 0.25f;
                BackgroundColor = new(0xEAEAEA, 1f);

                SelectedChanged += (s, e) =>
                {
                    radioButton.Toggle(e.InputDevice);
                    if (IsSelected)
                    {
                        _test2ArrowPosition = _arrowPosition;
                    }
                };
            }

            public override Thickness Padding
            {
                get => _stack.Padding;
                set => _stack.Padding = value;
            }

            protected override IList<View> InnerList => _stack;
        }
    }
}
