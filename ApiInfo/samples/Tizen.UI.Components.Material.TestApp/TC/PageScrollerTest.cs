using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    internal class PageScrollerTest : Grid, INavigationTransition, ITestCase
    {
        public PageScrollerTest() : base()
        {
            BackgroundColor = MaterialColor.Surface;
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;

            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);

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
                        BackgroundColor = Color.Blue,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Green,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Orange,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Yellow,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Red,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Blue,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Green,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Orange,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Yellow,
                    },
                    new View
                    {
                        DesiredWidth = 1000f,
                        BackgroundColor = Color.Red,
                    },
                }
            }.Self(out var pageScroller).Row(0));
            Add(new PageIndicator().Self(out var pageIndicator).Row(1));

            var adapter = new PageAdapter
            {
                Pager = pageScroller,
                PageIndicator = pageIndicator
            };

            pageScroller.ScrollStarted += OnScrollStarted;
            pageScroller.ScrollFinished += OnScrollFinished;
            pageScroller.Scrolling += OnScrolling;
            pageScroller.DragStarted += OnDragStarted;
            pageScroller.DragFinished += OnDragFinished;
            pageScroller.Dragging += OnDragging;
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
        private void OnScrollStarted(object o, EventArgs e)
        {
            Tizen.Log.Debug("PageScrollerTest", "Scroll Started");
        }

        private void OnScrollFinished(object o, EventArgs e)
        {
            Tizen.Log.Debug("PageScrollerTest", "Scroll Finished");
        }

        private void OnScrolling(object o, EventArgs e)
        {
            Tizen.Log.Debug("PageScrollerTest", "Scrolling");
        }

        private void OnDragStarted(object o, EventArgs e)
        {
            Tizen.Log.Debug("PageScrollerTest", "Drag Started");
        }

        private void OnDragFinished(object o, EventArgs e)
        {
            Tizen.Log.Debug("PageScrollerTest", "Drag Started");
        }

        private void OnDragging(object o, DragEventArgs e)
        {
            Tizen.Log.Debug("PageScrollerTest", $"Dragging");
        }
    }
}
