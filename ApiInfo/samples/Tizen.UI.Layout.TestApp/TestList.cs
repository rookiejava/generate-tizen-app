using LayoutTest.Util;
using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest
{
    class TestList : Grid
    {
        ITestCase _currentTest;
        public TestList(IEnumerable<Type> testcases)
        {
            BackgroundColor = Color.White;
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);
            Children.Add(new VStack
            {
                Name = "Header",
                BackgroundColor = Color.FromHex("#2196f3"),
                Padding = 30,
                Children =
                {
                    new TextView
                    {
                        FontSize = 50,
                        Text = "Layout Gallery",
                        TextColor = Color.White,

                    }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Start),
                    new TextView
                    {
                        FontSize = 20,
                        Text = "Flexible and usable layouts",
                        TextColor = Color.White,
                    }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Start).Margin(10, 0, 0, 0)
                }
            });

            var list = new FlexBox()
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.SpaceAround
            }.Margin(10);
            foreach (var test in testcases)
            {
                list.Add(new Button(test.Name)
                {
                    DesiredWidth = 240,
                    DesiredHeight = 50,
                    Clicked = () =>
                    {
                        _currentTest = (ITestCase)Activator.CreateInstance(test);
                        _currentTest.Activate();
                        IsVisible = false;
                    },
                }.Margin(2));
            }

            Children.Add(new ScrollLayout
            {
                Content = list
            }.Row(1));
        }

        public bool BackButtonPressed()
        {
            if (_currentTest != null)
            {
                _currentTest.Deactivate();
                _currentTest = null;
                IsVisible = true;
                return true;
            }
            return false;
        }
    }
}
