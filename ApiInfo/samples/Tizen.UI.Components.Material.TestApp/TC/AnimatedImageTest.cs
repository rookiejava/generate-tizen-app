using System.Linq;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class AnimatedImageTest : ScrollView, INavigationTransition, ITestCase
    {
        private static Color s_fontColor = MaterialColor.OnSurfaceContainerHighest;
        private const float s_fontSize = 20f;

        public AnimatedImageTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            Content = new VStack()
            {
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20f,
                BackgroundColor = MaterialColor.Background,
                Padding = new (0f, 20f),
                Children =
                {
                    new Label()
                    {
                        Text = "1. gif",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }
                    .HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new AnimatedImage("AGIF/dali-logo-anim.gif").HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new Label()
                    {
                        Text = "2. webp",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new AnimatedImage("AGIF/animated-webp.webp").HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new Label()
                    {
                        Text = "3. Sequential images",
                        FontSize = s_fontSize,
                        TextColor = s_fontColor
                    }.HorizontalLayoutAlignment(LayoutAlignment.Center),
                    new AnimatedImage(from i in Enumerable.Range(1, 8) select $"AGIF/dog-anim-00{i}.png").HorizontalLayoutAlignment(LayoutAlignment.Center)
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
