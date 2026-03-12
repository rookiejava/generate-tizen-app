using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    class FlexBoxTest11 : Grid, ITestCase
    {
        public FlexBoxTest11()
        {
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "FlexBoxTest 11 - AlignItems.Stretch vs AlignItems.Center (random size)",
                FontSize = 30,
            });

            Add(new AbsoluteLayout
            {
                new FlexBox
                {
                    BackgroundColor = Color.LightBlue,
                    Direction = FlexDirection.Row,
                    Wrap = FlexWrap.Wrap,
                    AlignItems = FlexAlignItems.Stretch,
                    Children =
                    {
                        new SizedBox().SetMeasureSize(183, 137),
                        new SizedBox().SetMeasureSize(160, 137),
                        new SizedBox().SetMeasureSize(140, 179),
                        new SizedBox().SetMeasureSize(92, 130),
                        new SizedBox().SetMeasureSize(89, 176),
                        new SizedBox().SetMeasureSize(111, 116),
                        new SizedBox().SetMeasureSize(178, 99),
                        new SizedBox().SetMeasureSize(154, 178),
                        new SizedBox().SetMeasureSize(181, 86),
                        new SizedBox().SetMeasureSize(149, 121),
                        new SizedBox().SetMeasureSize(111, 80),
                        new SizedBox().SetMeasureSize(94, 169),
                    }
                }.MaximumWidth(800),

                new FlexBox
                {
                    BackgroundColor = Color.LightBlue,
                    Direction = FlexDirection.Row,
                    Wrap = FlexWrap.Wrap,
                    AlignItems = FlexAlignItems.Center,
                    Children =
                    {
                        new SizedBox().SetMeasureSize(183, 137),
                        new SizedBox().SetMeasureSize(160, 137),
                        new SizedBox().SetMeasureSize(140, 179),
                        new SizedBox().SetMeasureSize(92, 130),
                        new SizedBox().SetMeasureSize(89, 176),
                        new SizedBox().SetMeasureSize(111, 116),
                        new SizedBox().SetMeasureSize(178, 99),
                        new SizedBox().SetMeasureSize(154, 178),
                        new SizedBox().SetMeasureSize(181, 86),
                        new SizedBox().SetMeasureSize(149, 121),
                        new SizedBox().SetMeasureSize(111, 80),
                        new SizedBox().SetMeasureSize(94, 169),
                    }
                }.MaximumWidth(800).LayoutBounds(810, 0, -1, -1)
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

        class SizedBox : Grid
        {
            public SizedBox()
            {
                Add(new TextView { Name = "TextView", FontSize = 13 }.TextCenter());
                Relayout += OnRelayout;
                this.Margin(20);
            }

            void OnRelayout(object sender, EventArgs e)
            {
                (this["TextView"] as TextView).Text = $"({Width:.0}x{Height:.0})";
            }

            public override Size Measure(float availableWidth, float availableHeight)
            {
                return new Size(measureWidth, measureHeight);
            }

            float measureWidth = 0;
            float measureHeight = 0;

            public SizedBox SetMeasureSize(float width, float height)
            {
                var rnd = new Random();
                measureWidth = width;
                measureHeight = height;
                BackgroundColor = new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble());
                return this;
            }
        }
    }
}
