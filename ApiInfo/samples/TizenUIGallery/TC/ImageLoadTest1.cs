using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class ImageLoadTest1 : Grid, ITestCase
    {
        public ImageLoadTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(300);
            RowDefinitions.Add(300);
            RowDefinitions.Add(GridLength.Star);
            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ImageLoad Test1",
                FontSize = 30,
            });
            Add(new AbsoluteLayout
            {
                new ImageView
                {
                    ResourceUrl = "big1.jpg",
                    FittingMode = FittingMode.ScaleToFill,
#if API12_OR_GREATER
                    ImageLoadWithViewSize = true,
#endif
                }.LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.All)
            }.Row(1).DesiredWidth(300).HorizontalLayoutAlignment(LayoutAlignment.Center).BackgroundColor(Color.Gray).Name("AbsLayout"));

            Add(new HStack
            {
                new ImageView
                {
                    ResourceUrl = "img2.png",
#if API12_OR_GREATER
                    ImageLoadWithViewSize = true,
#endif
                },
                new ImageView
                {
#if API12_OR_GREATER
                    ImageLoadWithViewSize = true,
#endif
                    ResourceUrl = "image2.jpg",
                },
                new ImageView
                {
#if API12_OR_GREATER
                    ImageLoadWithViewSize = true,
#endif
                    ResourceUrl = "image.png",
                },
                new ImageView
                {
#if API12_OR_GREATER
                    ImageLoadWithViewSize = true,
#endif
                    ResourceUrl = "img2.jpg",
                }
            }.Row(2));

            Add(new FlexBox
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new Button("< -- >")
                    {
                        Clicked = () =>
                        {
                            this["AbsLayout"].DesiredWidth += 20;
                        }
                    },

                    new Button(">--<")
                    {
                        Clicked = () =>
                        {
                            this["AbsLayout"].DesiredWidth -= 20;
                        }
                    },
                }
            }.Row(3));
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
