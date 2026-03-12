using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class OffscreenRenderingModeTest : Grid, ITestCase
    {
        public OffscreenRenderingModeTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "OffscreenRenderingModeTest",
                FontSize = 30,
            });

            Add(new Grid
            {
                RowDefinitions = { GridLength.Auto, GridLength.Auto },
                ColumnDefinitions = { GridLength.Star, GridLength.Star },
                Children =
                {
                    new TextView
                    {
                        Text = "OffscreenRenderMode.RefreshAlways",
                        FontSize = 20,
                    }.Row(0).Column(0).Center(),
                    new TextView
                    {
                        Text = "OffscreenRenderMode.None",
                        FontSize = 20,
                    }.Row(0).Column(1).Center(),
                    new AbsoluteLayout
                    {
                        DesiredHeight = 400,
                        DesiredWidth = 400,
                        BackgroundColor = Color.Green,
                        Opacity = 0.5f,
                        OffScreenRendering = OffScreenRendering.RefreshAlways,
                        Children =
                        {
                            new View
                            {
                                BackgroundColor = Color.Olive,
                            }.LayoutBounds(0.5f, 0.5f, 0.3f, 0.3f).LayoutFlags(AbsoluteLayoutFlags.All),
                            new View
                            {
                                BackgroundColor = Color.OrangeRed,
                            }.LayoutBounds(0.5f, 0.5f, 0.6f, 0.6f).LayoutFlags(AbsoluteLayoutFlags.All),
                            new View
                            {
                                BackgroundColor = Color.GreenYellow,
                            }.LayoutBounds(0.5f, 0.5f, 0.8f, 0.8f).LayoutFlags(AbsoluteLayoutFlags.All),
                        }
                    }.Row(1).Column(0),
                    new AbsoluteLayout
                    {
                        DesiredHeight = 400,
                        DesiredWidth = 400,
                        BackgroundColor = Color.Green,
                        Opacity = 0.5f,
                        Children =
                        {
                            new View
                            {
                                BackgroundColor = Color.Olive,
                            }.LayoutBounds(0.5f, 0.5f, 0.3f, 0.3f).LayoutFlags(AbsoluteLayoutFlags.All),
                            new View
                            {
                                BackgroundColor = Color.OrangeRed,
                            }.LayoutBounds(0.5f, 0.5f, 0.6f, 0.6f).LayoutFlags(AbsoluteLayoutFlags.All),
                            new View
                            {
                                BackgroundColor = Color.GreenYellow,
                            }.LayoutBounds(0.5f, 0.5f, 0.8f, 0.8f).LayoutFlags(AbsoluteLayoutFlags.All),
                        }
                    }.Row(1).Column(1),

                }
            }.Row(1));
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}
