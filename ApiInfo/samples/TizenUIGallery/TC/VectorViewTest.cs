using System.Collections.Generic;
using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Primitives2D;
using Tizen.UI.Layouts;
using TizenUIGallery.Util;

namespace TizenUIGallery.TC
{
    public class VectorViewTest : Grid, ITestCase
    {
        float currentMargin = 0;
        public VectorViewTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);


            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "VectorView Test",
                FontSize = 30,
            });

            Add(new HStack
            {
                Spacing = 10,
                Children =
                {
                    new Button("Size --")
                    {
                        Clicked = () =>
                        {
                            currentMargin += 10;
                            this["View1"].Margin(currentMargin);
                        }
                    },
                    new Button("Size ++")
                    {
                        Clicked = () =>
                        {
                            currentMargin -= 10;
                            this["View1"].Margin(currentMargin);
                        }
                    }
                }
            }.Row(1));

            var vectorView = new VectorView
            {
                Name = "View1",
                BackgroundColor = Color.LightYellow,
            }.Row(2);
            Add(vectorView);

            var dashArray = new List<float>() { 20, 20 }.ToArray();
            GradientStop[] GetGradientStop(Color color)
            {
                return new GradientStop[]
                {
                    new GradientStop(Color.White, 0.0f),
                    new GradientStop(color, 0.5f),
                    new GradientStop(Color.Black, 1.0f),
                };
            }
            LinearGradientPaint GetLinearGradientPaint(Color color, SpreadType spread = SpreadType.Pad, FillRule fillRule = FillRule.Winding, float strokeWidth = 0, StrokeCap strokeCap = StrokeCap.Square, StrokeJoin strokeJoin = StrokeJoin.Bevel)
            {
                return new LinearGradientPaint
                {
                    StartPoint = new Point(0f, 0f),
                    EndPoint = new Point(1f, 1f),
                    GradientStops = GetGradientStop(color),
                    Spread = spread,

                    StrokeWidth = strokeWidth,
                    StrokeDashArray = dashArray,
                    StrokeCap = strokeCap,
                    StrokeJoin = strokeJoin,
                };
            }
            RadialGradientPaint GetRadialGradientPaint(Color color, SpreadType spread = SpreadType.Pad, FillRule fillRule = FillRule.Winding, float strokeWidth = 0, StrokeCap strokeCap = StrokeCap.Square, StrokeJoin strokeJoin = StrokeJoin.Bevel)
            {
                return new RadialGradientPaint
                {
                    Center = new Point(0.5f, 0.5f),
                    Radius = 0.5f,
                    GradientStops = GetGradientStop(color),
                    Spread = spread,

                    StrokeWidth = strokeWidth,
                    StrokeDashArray = dashArray,
                    StrokeCap = strokeCap,
                    StrokeJoin = strokeJoin,
                };
            }
            SolidPaint GetSolidPaint(Color color, FillRule fillRule = FillRule.Winding, float strokeWidth = 0, StrokeCap strokeCap = StrokeCap.Square, StrokeJoin strokeJoin = StrokeJoin.Bevel)
            {
                return new SolidPaint
                {
                    Color = color,
                    FillRule = fillRule,

                    StrokeWidth = strokeWidth,
                    StrokeDashArray = dashArray,
                    StrokeCap = strokeCap,
                    StrokeJoin = strokeJoin,
                };
            }

            DrawPaint(vectorView, dashArray);

            vectorView.Relayout += (s, e) => DrawPaint(vectorView, dashArray);

            void DrawPaint(VectorView vectorView, float[] dashArray)
            {
                vectorView.Clear();

                var border = new RoundRectangle(10, 10, vectorView.Width - 20, vectorView.Height - 20, 20, 20);
                border.Stroke(GetSolidPaint(Color.LightBlue, strokeWidth: 10));
                vectorView.Add(border);


                var width = 70;
                var height = 150;

                var width2 = 250;
                var height2 = 70;

                //RoundRectangle
                var roundrect1 = new RoundRectangle(50, 50, width, height, 10, 100);
                roundrect1.Fill(GetSolidPaint(color: Color.Red, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                roundrect1.Stroke(GetSolidPaint(color: Color.Green, strokeWidth: 10, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                vectorView.Add(roundrect1);

                var roundrect2 = new RoundRectangle(150, 50, width, height, 100, 10);
                roundrect2.Fill(GetRadialGradientPaint(color: Color.Red, spread: SpreadType.Pad, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                roundrect2.Stroke(GetLinearGradientPaint(color: Color.Green, spread: SpreadType.Pad, strokeWidth: 10, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                vectorView.Add(roundrect2);

                var roundrect3 = new RoundRectangle(15, 250, width2, height2, 10, 100);
                roundrect3.Fill(GetRadialGradientPaint(color: Color.Red, spread: SpreadType.Reflect, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                roundrect3.Stroke(GetLinearGradientPaint(color: Color.Green, spread: SpreadType.Reflect, strokeWidth: 10, strokeCap: StrokeCap.Round, strokeJoin: StrokeJoin.Round));
                vectorView.Add(roundrect3);

                var roundrect4 = new RoundRectangle(15, 350, width2, height2, 100, 10);
                roundrect4.Fill(GetRadialGradientPaint(color: Color.Red, spread: SpreadType.Repeat, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                roundrect4.Stroke(GetLinearGradientPaint(color: Color.Green, spread: SpreadType.Repeat, strokeWidth: 10, strokeCap: StrokeCap.Flat, strokeJoin: StrokeJoin.Miter));
                vectorView.Add(roundrect4);

                //Ellipse
                var circle1 = new Ellipse(800, 150, width / 2, height / 2);
                circle1.Fill(GetSolidPaint(color: Color.Green, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                circle1.Stroke(GetSolidPaint(color: Color.Red, strokeWidth: 10, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                vectorView.Add(circle1);

                var circle2 = new Ellipse(900, 150, width / 2, height / 2);
                circle2.Fill(GetRadialGradientPaint(color: Color.Green, spread: SpreadType.Pad, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                circle2.Stroke(GetLinearGradientPaint(color: Color.Red, spread: SpreadType.Pad, strokeWidth: 10, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                vectorView.Add(circle2);

                var circle3 = new Ellipse(850, 300, width2 / 2, height2 / 2);
                circle3.Fill(GetRadialGradientPaint(color: Color.Green, spread: SpreadType.Reflect, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                circle3.Stroke(GetLinearGradientPaint(color: Color.Red, spread: SpreadType.Reflect, strokeWidth: 10, strokeCap: StrokeCap.Round, strokeJoin: StrokeJoin.Round));
                vectorView.Add(circle3);

                var circle4 = new Ellipse(850, 400, width2 / 2, height2 / 2);
                circle4.Fill(GetRadialGradientPaint(color: Color.Green, spread: SpreadType.Repeat, strokeWidth: 0, strokeCap: StrokeCap.Square, strokeJoin: StrokeJoin.Bevel));
                circle4.Stroke(GetLinearGradientPaint(color: Color.Red, spread: SpreadType.Repeat, strokeWidth: 10, strokeCap: StrokeCap.Flat, strokeJoin: StrokeJoin.Miter));
                vectorView.Add(circle4);

                //CustomShape
                var starShape = new CustomShape(new IPath[]
                {
                    new MoveTo(0, -160),
                    new LineTo(125,160),
                    new LineTo(-180,-45),
                    new LineTo(180,-45),
                    new LineTo(-125,160),
                    new Close(),
                });
                starShape.Translate(500, 250);

                //ImageDrawable
                var path = Application.Current.DirectoryInfo.SharedResource + "TizenUIGallery.png";
                var img = new ImageDrawable(path, 400, 400);
                img.Translate(300, 0);
                img.ClipPath(starShape);
                vectorView.Add(img);

                //arc
                var arcShape = new CustomShape();
                arcShape.Stroke(GetRadialGradientPaint(color: Color.Blue, SpreadType.Reflect, strokeWidth: 10, strokeCap: StrokeCap.Round, strokeJoin: StrokeJoin.Round));
                arcShape.Path = new IPath[]
                {
                    Path.ArcTo(500.0f, 250.0f, 200.0f, 160, 220, false),
                    Path.ArcTo(500.0f, 250.0f, 200.0f, 30, 120, true),
                    Path.DrawCircle(500, 250, 100),
                };
                vectorView.Add(arcShape);
            }
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
