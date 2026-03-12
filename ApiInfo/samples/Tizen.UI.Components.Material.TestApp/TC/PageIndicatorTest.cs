using System;
using System.Linq;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class PageIndicatorTest : Grid, INavigationTransition, ITestCase
    {
        private Color[] _colorTable =
        {
            Color.Blue,
            Color.Green,
            Color.Orange,
            Color.Yellow,
            Color.Red,
            Color.Aqua,
            Color.DeepPink,
            Color.Beige,
            Color.DarkKhaki,
            Color.BlueViolet
        };

        public PageIndicatorTest() : base()
        {
            BackgroundColor = MaterialColor.Surface;

            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;

            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);

            Add(new HStack
            {
                DesiredHeight = 120f,
                Spacing = 20f,
                ItemAlignment = LayoutAlignment.Center,

                Children =
                {
                    new Button
                    {
                        Text = "Add Page",
                    }.Self(out var addButton),
                    new Button
                    {
                        Text = "Remove Page",
                    }.Self(out var removeButton),
                    new Button
                    {
                        Text = "Remove All",
                    }.Self(out var removeAllButton),
                }
            }.Row(0));
            Add(new PageScroller
            {
                Spacing = 80f,
                Padding = new Thickness(40f, 0),
                IsHorizontal = true,
                Children =
                {
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = _colorTable[0],
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = _colorTable[1],
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = _colorTable[2],
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = _colorTable[3],
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = _colorTable[4],
                    },
                }
            }.Self(out var pageScroller).Row(1));
            Add(new PageIndicator
            {
                PageDotTemplate = new PageDotTemplate(),
            }.Self(out var pageIndicator).Row(2));

            var adapter = new PageAdapter
            {
                Pager = pageScroller,
                PageIndicator = pageIndicator
            };

            addButton.Clicked += (_, _) =>
            {
                pageScroller.Add(new View
                {
                    DesiredWidth = 1000f,
                    BackgroundColor = _colorTable[pageScroller.PageCount],
                });
            };

            removeButton.Clicked += (_, _) =>
            {
                if (pageScroller.PageCount > 0)
                {
                    pageScroller.Remove(pageScroller[pageScroller.PageCount - 1]);
                }
            }
                ;
            removeAllButton.Clicked += (_, _) =>
            {
                foreach (var child in pageScroller.ToList())
                {
                    pageScroller.Remove(child);
                }
            };
        }

        private class PageDotTemplate : ViewTemplateSelector
        {
            protected override ViewTemplate OnSelectTemplate(object item, View container)
            {
                int index = (int)item;

                if (index == 0)
                    return new ViewTemplate(typeof(PageIndicatorHome));
                else if (index == 4)
                    return new ViewTemplate(typeof(PageIndicatorPlus));
                else
                    return new ViewTemplate(typeof(PageIndicatorDot));
            }
        }

        private class PageIndicatorHome : PageIndicatorDot
        {
            public PageIndicatorHome() : base(PageIndicatorDotVariables.Home)
            {
            }
        }

        private class PageIndicatorPlus : PageIndicatorDot
        {
            public PageIndicatorPlus() : base(PageIndicatorDotVariables.Plus)
            {
            }
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
