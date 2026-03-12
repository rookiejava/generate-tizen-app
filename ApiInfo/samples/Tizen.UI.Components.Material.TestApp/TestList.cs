using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    class TestList : Grid
    {
        ITestCase _currentTest;

        public TestList(IEnumerable<Type> testcases)
        {
            BackgroundColor = Color.White;
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);
            Add(new VStack
            {
                Name = "Header",
                BackgroundColor = MaterialColor.Primary,
                Padding = 30,
                Children =
                {
                    new Label
                    {
                        FontSize = 50,
                        Text = "Components Gallery",
                        TextColor = MaterialColor.OnPrimary,

                    }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Start),
                    new Label
                    {
                        FontSize = 20,
                        Text = "Tests variaous components defined in Material UX",
                        TextColor = MaterialColor.OnPrimary,
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
                    ClickedCommand = (s, e) =>
                    {
                        _currentTest = (ITestCase)Activator.CreateInstance(test);
                        _currentTest.Activate();
                        _ = this.GetNavigation().PushAsync(_currentTest as Scaffold ?? new TestCaseScaffold(test.Name, _currentTest));
                    }
                }.Margin(2));
            }
            Add(new ScrollView
            {
                Content = list
            }.VerticalLayoutAlignment(LayoutAlignment.Fill).HorizontalLayoutAlignment(LayoutAlignment.Fill).Row(1));
        }

        private class TestCaseScaffold : Scaffold, INavigationTransition
        {
            public TestCaseScaffold(string name, ITestCase test)
            {
                AppBar = new AppBar()
                {
                    Leading = new BackButton(),
                    Title = name
                };
                Content = test as View;
            }

            public void WillAppear(bool byPopNavigation)
            {
                (Content as INavigationTransition)?.WillAppear(byPopNavigation);
            }

            public void WillDisappear(bool byPopNavigation)
            {
                (Content as INavigationTransition)?.WillDisappear(byPopNavigation);
            }

            public void DidAppear(bool byPopNavigation)
            {
                (Content as INavigationTransition)?.DidAppear(byPopNavigation);
            }

            public void DidDisappear(bool byPopNavigation)
            {
                (Content as INavigationTransition)?.DidDisappear(byPopNavigation);
            }
        }
    }
}
