using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class AutoFontSizeTest1 : Grid, ITestCase
    {
        public AutoFontSizeTest1()
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
                Text = "AutoFontSize Test1",
                FontSize = 30,
            });

            var target = new TextView
            {
                Name = "Text",
                DesiredHeight = 100,
                DesiredWidth = 300,
                BackgroundColor = Color.Yellow,
                Text = $"Auto Font Size Test AAAA Long Text..",
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                FontSize = 20,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1);
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
                        this["Text"].DesiredWidth += diff;
                    }
                    else if (this["Text"].DesiredWidth > MathF.Abs(diff))
                    {
                        this["Text"].DesiredWidth += diff;
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
                    new Button("Enable")
                    {
                        Clicked = () =>
                        {
                            (this["Text"] as TextView).SetAutoSize(new AutoFontSize
                            {
                                Enabled = true,
                                MinimumSize = 1,
                                MaximumSize = 100
                            });
                        }
                    }.Margin(10),
                    new Button("Disable")
                    {
                        Clicked = () =>
                        {
                            (this["Text"] as TextView).SetAutoSize(new AutoFontSize
                            {
                                Enabled = false
                            });
                        }
                    }.Margin(10),
                    new Button("Set 30")
                    {
                        Clicked = () =>
                        {
                            (this["Text"] as TextView).FontSize = 30;
                        }
                    }.Margin(10),
                    new Button("Set 20")
                    {
                        Clicked = () =>
                        {
                            (this["Text"] as TextView).FontSize = 20;
                        }
                    }.Margin(10),
                    new Button("Set 10")
                    {
                        Clicked = () =>
                        {
                            (this["Text"] as TextView).FontSize = 10;
                        }
                    }.Margin(10),
                    new Button("Set 5")
                    {
                        Clicked = () =>
                        {
                            (this["Text"] as TextView).FontSize = 5;
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
