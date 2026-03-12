using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class AnimationTest1 : Grid, ITestCase
    {
        public AnimationTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto); // need to check when GridLength.Auto
            ColumnDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "AnimationTest1",
                FontSize = 30,
            }.ColumnSpan(4));
            
            var target = new View
            {
                DesiredHeight = 300,
                DesiredWidth = 300,
                BackgroundColor = Color.Violet,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1).ColumnSpan(4);
            Add(target);

            Add(new Button("rotate 45 -> 0")
            {
                Clicked = async () =>
                {
                    await target.RotateTo(45);
                    await target.RotateTo(0);
                }
            }.Row(2).Column(0).Margin(20));

            Add(new Button("Rotate Position")
            {
                Clicked = () =>
                {
                    var ani = new Animation();
                    var originX = target.X;
                    var originY = target.Y;

                    ani.AnimateTo(target, AnimatablePropertyValue.CreateRotationValue(0, 0, 45), 0, 250);
                    ani.AnimateTo(target, AnimatablePropertyValue.CreatePositionValue(target.X + 100, target.Y + 100), 0, 250, new AlphaFunction(BuiltinAlphaFunctions.EaseIn));
                    ani.AnimateTo(target, AnimatablePropertyValue.CreateRotationValue(0, 0, 0), 250, 250);
                    ani.AnimateTo(target, AnimatablePropertyValue.CreatePositionValue(originX, originY), 250, 250);
                    ani.Play();
                }
            }.Row(2).Column(1).Margin(0, 20));

            Add(new Button("MoveTo")
            {
                Clicked = async () =>
                {
                    var x = target.X;
                    var y = target.Y;
                    await target.MoveTo(x + 100, y + 100);
                    await target.MoveTo(x -100, y + 100);
                    await target.MoveTo(x, y);
                }
            }.Row(2).Column(2).Margin(20));


            Add(new Button("PositionX")
            {
                Clicked = async () =>
                {
                    int origin = (int)target.X;
                    int dest = origin + 300;
                    var ani = new Animation();
                    ani.AnimateTo(target, AnimatablePropertyValue.CreateCustomValue("PositionX", dest), 0, 2000);
                    await ani.PlayAsync();
                    if (target.IsDisposed) return;
                    ani.Clear();
                    ani.AnimateTo(target, AnimatablePropertyValue.CreateCustomValue("PositionX", origin), 0, 2000);
                    await ani.PlayAsync();
                }
            }.Row(2).Column(3).Margin(20));
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
