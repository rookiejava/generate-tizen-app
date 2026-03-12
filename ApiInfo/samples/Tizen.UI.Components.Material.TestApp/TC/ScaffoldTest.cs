using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class ScaffoldTest : Scaffold, INavigationTransition, ITestCase
    {
        private readonly BottomBar _bottomBar;

        public ScaffoldTest() : base()
        {
            BackgroundColor = Color.White;
            AppBar = new AppBar()
            {
                Leading = new BackButton(),
                Title = "Scaffold Test"
            };
            BottomBar = new BottomBar()
            {
                Items =
                {
                    new TabItem("Text"),
                    new TabItem("Text"),
                    new TabItem("Text"),
                }
            }
            .Self(out _bottomBar);

            Content = new VStack()
            {
                Spacing = 10f,
                Children =
                {
                    new Button("Indicator")
                    {
                        ClickedCommand = (o, _) =>
                        {
                            HasIndicatorArea = !HasIndicatorArea;
                        }
                    }.MinimumWidth(400f).CenterHorizontal(),
                    new Button("Navigator")
                    {
                        ClickedCommand = (o, _) =>
                        {
                            HasNavigationBarArea = !HasNavigationBarArea;
                        }
                    }.MinimumWidth(400f).CenterHorizontal(),
                    new Button("Bottom bar")
                    {
                        ClickedCommand = (o, _) =>
                        {
                            if (BottomBar != null)
                            {
                                BottomBar = null;
                            }
                            else
                            {
                                BottomBar = _bottomBar;
                            }
                        }
                    }.MinimumWidth(400f).CenterHorizontal(),
                    new Button("Floating Button")
                    {
                        ClickedCommand = (o, _) =>
                        {
                            if (FloatingActionButton == null)
                            {
                                FloatingActionButton = new IconButton("ic_plus.svg", IconButtonVariables.FAB);
                            }
                            else
                            {
                                FloatingActionButton = null;
                            }
                        }
                    }.MinimumWidth(400f).CenterHorizontal(),
                    new Button("Floating Origin")
                    {
                        ClickedCommand = (o, _) =>
                        {
                            if (FloatingActionButton != null)
                            {
                                FloatingOrigin = (FloatingOrigin)(((int)FloatingOrigin + 1) % 3);
                            }
                        }
                    }.MinimumWidth(400f).CenterHorizontal(),
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
