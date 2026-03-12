using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class LabelPaddingResizeTest : Grid, ITestCase
    {
        public LabelPaddingResizeTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);


            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "LabelPaddingResize Test",
                FontSize = 30,
            });

            var target = new TextView
            {
                Name = "Text",
                TextOverflow = TextOverflow.Clip,
                Text = "1000",
                CornerRadius = 21,
                BackgroundColor = Color.FromHex("#663A3A3A"),
                FontSize = 20,
                DesiredWidth = 300,
                TextColor = Color.FromHex("#FF98E7FF"),
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1).TextPadding(20, 10, 20, 10);
            Add(target);

            var label = new TextView
            {
                FontSize = 40,
                BackgroundColor = Color.DeepSkyBlue,
                DesiredHeight = 100,
                Text = "<- less  <Drag area>  more ->",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Fill).Row(2);
            Add(label);

            Point pos = new Point(0, 0);
            label.TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    pos = e.Touch[0].Position;
                }
                else if (e.Touch[0].State == TouchState.Motion)
                {
                    var cur = e.Touch[0].Position;
                    var diff = (cur.X - pos.X) / 2f;
                    if (diff > 0)
                    {
                        this["Text"].Width += diff;
                    }
                    else if (this["Text"].Width> MathF.Abs(diff))
                    {
                        this["Text"].Width += diff;
                    }
                    pos = cur;
                }
            };
            Add(new FlexBox
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new Button("Expand with Animation")
                    {
                        Clicked = () =>
                        {
                            var ani = new Animation();
                            ani.AnimateTo(this["Text"], AnimatablePropertyValue.CreateSizeValue(160, this["Text"].Height), 0, 200);
                            ani.Play();
                        }
                    }.Margin(10),
                    new Button("Less with Animation")
                    {
                        Clicked = () =>
                        {
                            var ani = new Animation();
                            ani.AnimateTo(this["Text"], AnimatablePropertyValue.CreateSizeValue(40, this["Text"].Height), 0, 200);
                            ani.Play();
                        }
                    }.Margin(10),
                    new Button("Less on UI (Slow)")
                    {
                        Clicked = () =>
                        {
                            int count = 0;
                            Timer.Repeat(15, () =>
                            {
                                count++;

                                this["Text"].Width = 160 - count * 24;
                                if (count > 5)
                                    return false;
                                return true;
                            });
                        }
                    }.Margin(10),
                    new Button("Less on UI (Fast)")
                    {
                        Clicked = () =>
                        {
                            int count = 0;
                            Timer.Repeat(15, () =>
                            {
                                count++;

                                this["Text"].Width = 180 - count * 40;
                                if (count > 3)
                                    return false;
                                return true;
                            });
                        }
                    }.Margin(10),
                },
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
