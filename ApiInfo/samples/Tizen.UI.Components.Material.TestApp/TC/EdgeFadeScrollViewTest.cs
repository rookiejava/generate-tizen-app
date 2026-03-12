using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class EdgeFadeScrollViewTest : Scaffold, INavigationTransition, ITestCase
    {
        private Random rand;

        public EdgeFadeScrollViewTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            rand = new Random();

            AppBar = new AppBar()
            {
                //Leading = new BackButton(),
                Title = "Edge fade ScrollView",
            };
            Content = new AbsoluteLayout
            {
                new ScrollView
                {
                    Content = new VStack()
                    {
                        Spacing = 10f,
                    }
                    .HorizontalLayoutAlignment(LayoutAlignment.Fill)
                    .Self(out var scrollContent),
                }
                .LayoutBounds(0, 0, 1, 1)
                .LayoutFlags(AbsoluteLayoutFlags.All)
                .Self(out var scrollView),
                new AbsoluteLayout // Edge fade source
                {
                    new Image // Edge fade mask image
                    {
                        ResourceUrl = "scroll_mask_v.png",
                    }
                    .LayoutBounds(0, 0, 1, 1)
                    .LayoutFlags(AbsoluteLayoutFlags.All),
                    new VStack
                    {
                        new View // Edge fade top handler. if opacity becomes 1f, fade will be disapper on top area.
                        {
                            BackgroundColor = Color.Black,
                            Opacity = 1f, // scroll start from the top position so default must be 1f.
                        }.Self(out var edgeFadeTopHandler).Expand(),
                        new View // Edge fade bottom handler. if opacity becomes 1f, fade will be disapper on bottom area.
                        {
                            BackgroundColor = Color.Black,
                            Opacity = 0f,
                        }.Self(out var edgeFadeBottomHandler).Expand(),
                    }
                    .LayoutBounds(0, 0, 1, 1)
                    .LayoutFlags(AbsoluteLayoutFlags.All)
                }
                .LayoutBounds(0, 0, 1, 1)
                .LayoutFlags(AbsoluteLayoutFlags.All)
                .Self(out var edgeFadeSource),
            };

            AddChildren(scrollContent, 20);

            var effect = RenderEffect.CreateMaskEffect(edgeFadeSource);
            scrollView.SetRenderEffect(effect);
            scrollView.Scrolling += (_, _) =>
            {
                float current = scrollView.ScrollPosition.Y;
                float scrollMax = scrollContent.Height - scrollView.Height;
                float edgeMargin = 100f;
                Log.Error($"On Scrolling position: {current}, max: {scrollMax}");

                if (current < edgeMargin)
                {
                    edgeFadeTopHandler.Opacity = (edgeMargin - current) / edgeMargin;
                }
                else if (current > scrollMax - edgeMargin)
                {
                    edgeFadeBottomHandler.Opacity = (edgeMargin + current - scrollMax) / edgeMargin;
                }
                else
                {
                    edgeFadeTopHandler.Opacity = 0f;
                    edgeFadeBottomHandler.Opacity = 0f;
                }
            };
        }

        private void AddChildren(ViewGroup view, int count)
        {
            for (int i = 0; i < count; i++)
            {
                view.Add(
                    new View
                    {
                        DesiredHeight = 100,
                        BackgroundColor = new Color(GetColor(), GetColor(), GetColor(), 1f),
                    }.HorizontalLayoutAlignment(LayoutAlignment.Fill)
                );
            }
        }

        private float GetColor()
        {
            return (float)rand.Next(255) / 255f;
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
