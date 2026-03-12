using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class AnimationTest3 : Grid, ITestCase
    {
        public AnimationTest3()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Animation Test3",
                FontSize = 30,
            }.ColumnSpan(2));

            var target = new View
            {
                DesiredHeight = 300,
                DesiredWidth = 300,
                BackgroundColor = Color.Violet,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1).Column(0);
            Add(target);

            var imageTarget = new ImageView
            {
                ResourceUrl = "bg.png",
                FittingMode = FittingMode.Fill
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1).Column(1);
            Add(imageTarget);

            Add(new FlexBox
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new Button("CornerRadius => 100")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateCornerRadiusValue(100), 0, 1000);
                            animation.AnimateTo(imageTarget, AnimatablePropertyValue.CreateCornerRadiusValue(100), 0, 1000);
                            animation.Play();
                        }
                    }.Margin(10),
                    new Button("CornerRadius => 0")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateCornerRadiusValue(0), 0, 1000);
                            animation.AnimateTo(imageTarget, AnimatablePropertyValue.CreateCornerRadiusValue(0), 0, 1000);
                            animation.Play();
                        }
                    }.Margin(10),

                    new Button("BackgroundColor => Red with alpha .5")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateBackgroundColorValue(Color.Red.MultiplyAlpha(0.5f)), 0, 1000);
                            animation.AnimateTo(imageTarget, AnimatablePropertyValue.CreateBackgroundColorValue(Color.Red.MultiplyAlpha(0.5f)), 0, 1000);
                            animation.Play();
                        }
                    }.Margin(10),

                    new Button("BackgroundColor => Violet")
                    {
                        Clicked = () =>
                        {
                            var animation = new Animation();
                            animation.AnimateTo(target, AnimatablePropertyValue.CreateBackgroundColorValue(Color.Violet), 0, 1000);
                            animation.AnimateTo(imageTarget, AnimatablePropertyValue.CreateBackgroundColorValue(Color.Violet), 0, 1000);
                            animation.Play();
                        }
                    }.Margin(10),
                },
            }.Row(2).ColumnSpan(2));
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
