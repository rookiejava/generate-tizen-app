using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class ScaffoldBaseTest : ScaffoldBase, INavigationTransition, ITestCase
    {
        public ScaffoldBaseTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            HasIndicatorArea = true;
            HasNavigationBarArea = true;
            Body = new VStack
            {
                BackgroundColor = Color.AliceBlue,
                Children =
                {
                    new Label
                    {
                        Text = "Hello Body"
                        , FontSize = 20
                    },
                    new Label
                    {
                        DesiredHeight = 80,
                        DesiredWidth = 400,
                        Text = "Toggle Appbar",
                        FontSize = 20,
                        BorderlineColor = Color.Blue,
                        CornerRadius = 10,
                        BackgroundColor = Color.LightYellow,
                        BorderlineWidth = 1,
                        VerticalAlignment = TextAlignment.Center,
                        HorizontalAlignment = TextAlignment.Center,
                    }.Self(view =>
                    {
                        view.TouchEvent += (s, e) =>
                        {
                            if (e.Touch[0].State == TouchState.Up)
                            {
                                if (HasIndicatorArea)
                                {
                                    HasIndicatorArea = false;
                                }
                                else
                                {
                                    HasIndicatorArea = true;
                                }
                            }
                        };
                    }),
                    new Label
                    {
                        DesiredHeight = 80,
                        DesiredWidth = 400,
                        Text = "Toggle bottom navigation",
                        FontSize = 20,
                        BorderlineColor = Color.Blue,
                        CornerRadius = 10,
                        BackgroundColor = Color.LightYellow,
                        BorderlineWidth = 1,
                        VerticalAlignment = TextAlignment.Center,
                        HorizontalAlignment = TextAlignment.Center,
                    }.Self(view =>
                    {
                        view.TouchEvent += (s, e) =>
                        {
                            if (e.Touch[0].State == TouchState.Up)
                            {
                                if (HasNavigationBarArea)
                                {
                                    HasNavigationBarArea = false;
                                }
                                else
                                {
                                    HasNavigationBarArea = true;
                                }
                            }
                        };
                    }),
                }
            };
            FloatingActionButton = new View
            {
                DesiredHeight = 100,
                DesiredWidth = 100,
                CornerRadius = 1,
                BackgroundColor = Color.Green,
            };
            IndicatorAreaColor = Color.Magenta;
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
