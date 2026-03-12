using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class RenderPropertyNotificationTest1 : VStack, ITestCase
    {
        public RenderPropertyNotificationTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            Spacing = 5;
            Add(new TextView
            {
                DesiredHeight = 80,
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Render Notification Test",
                FontSize = 30,
            });

            Add(new TextView
            {
                DesiredHeight = 30,
                FontSize = 20,
                VerticalAlignment = TextAlignment.Center,
                Name = "Log",
                BackgroundColor = Color.AntiqueWhite
            }.Margin(5));

            Add(new ViewGroup
            {
                Name = "Outter",
                DesiredHeight = 300,
                BackgroundColor = Color.FloralWhite,
                Children =
                {
                    new View
                    {
                        Name = "Target",
                        Height = 200,
                        Width = 200,
                        BackgroundColor = Color.Red,
                        PositionUsesPivotPoint = true,
                        ParentOrigin = OriginPoint.Center,
                    }
                }
            });


            Add(new Button("Position")
            {
                Clicked = async () =>
                {
                    // test with instance method
                    this["Target"].AddRenderNotification(RenderNotificationKey.Position, OnUpdatePosition);
                    await this["Target"].MoveTo(500, 0, 1000);
                    await this["Target"].MoveTo(0, 0);
                    this["Target"].RemoveRenderNotification(RenderNotificationKey.Position, OnUpdatePosition);
                }
            });
            Add(new Button("Size")
            {
                Clicked = async () =>
                {
                    // test with local action
                    var update = () =>
                    {
                        (this["Log"] as TextView).Text = $"Update Size : {this["Target"].CurrentSize}";
                    };
                    this["Target"].AddRenderNotification(RenderNotificationKey.Size, update);
                    var animation = new Animation();
                    animation.AnimateTo(this["Target"], AnimatablePropertyValue.CreateSizeValue(300, 300), 0, 1000);
                    animation.AnimateTo(this["Target"], AnimatablePropertyValue.CreateSizeValue(200, 200), 1000, 1000);
                    await animation.PlayAsync();
                    this["Target"].RemoveRenderNotification(RenderNotificationKey.Size, update);
                }
            });
            Add(new Button("ScreenPosition")
            {
                Clicked = async () =>
                {
                    this["Target"].AddRenderNotification(RenderNotificationKey.ScreenPosition,
                        () => (this["Log"] as TextView).Text = $"Update ScreenPosition : {this["Target"].CurrentScreenPosition}");
                    await this["Outter"].MoveTo(this["Outter"].X + 100, this["Outter"].Y, 1000);
                    await this["Outter"].MoveTo(this["Outter"].X, this["Outter"].Y);
                    this["Target"].RemoveRenderNotification(RenderNotificationKey.ScreenPosition);
                }
            });
            Add(new Button("Scale")
            {
                Clicked = async () =>
                {
                    this["Target"].AddRenderNotification(RenderNotificationKey.Scale,
                        () => (this["Log"] as TextView).Text = $"Update Scale : {this["Target"].CurrentScale}");
                    var animation = new Animation();
                    animation.AnimateTo(this["Target"], AnimatablePropertyValue.CreateScaleValue(new Size(2, 2)), 0, 1000);
                    animation.AnimateTo(this["Target"], AnimatablePropertyValue.CreateScaleValue(new Size(1, 1)), 1000, 1000);
                    await animation.PlayAsync();
                    this["Target"].RemoveRenderNotification(RenderNotificationKey.Scale);
                }
            });
            Add(new Button("WorldScale")
            {
                Clicked = async () =>
                {
                    this["Target"].AddRenderNotification(RenderNotificationKey.WorldScale,
                        () => (this["Log"] as TextView).Text = $"Update WorldScale : {this["Target"].WorldScale}");
                    var animation = new Animation();
                    animation.AnimateTo(this["Outter"], AnimatablePropertyValue.CreateScaleValue(new Size(2, 2)), 0, 1000);
                    animation.AnimateTo(this["Outter"], AnimatablePropertyValue.CreateScaleValue(new Size(1, 1)), 1000, 1000);
                    await animation.PlayAsync();
                    this["Target"].RemoveRenderNotification(RenderNotificationKey.WorldScale);
                }
            });
            Add(new Button("Opacity")
            {
                Clicked = async () =>
                {
                    this["Target"].AddRenderNotification(RenderNotificationKey.Opacity,
                        () => (this["Log"] as TextView).Text = $"Update Opacity : {this["Target"].CurrentOpacity}");
                    var animation = new Animation();
                    animation.AnimateTo(this["Target"], AnimatablePropertyValue.CreateOpacityValue(0.5f), 0, 1000);
                    animation.AnimateTo(this["Target"], AnimatablePropertyValue.CreateOpacityValue(1), 1000, 1000);
                    await animation.PlayAsync();
                    this["Target"].RemoveRenderNotification(RenderNotificationKey.Opacity);
                }
            });

        }

        void OnUpdatePosition()
        {
            (this["Log"] as TextView).Text = $"Update Position : {this["Target"].CurrentPosition}";
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
