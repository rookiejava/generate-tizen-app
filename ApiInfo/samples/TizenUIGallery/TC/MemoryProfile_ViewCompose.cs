using TizenUIGallery.Util;
using SkiaSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Primitives2D;
using Tizen.UI.Skia;

namespace TizenUIGallery.TC
{
    public class MemoryProfile_ViewCompose : Grid, ITestCase
    {
        public MemoryProfile_ViewCompose()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Auto);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "MemoryProfile_ViewCompose",
                FontSize = 30,
            });

            Add(new HStack
            {
                new Button("VectorView")
                {
                    Clicked = async () =>
                    {
                        var flex = this["Flex"] as FlexBox;
                        flex.Clear();
                        await Task.Delay(1);
                        var stopwatch = Stopwatch.StartNew();
                        for (int i = 0; i < 5000; i++)
                        {
                            flex.Add(new VectorComponent().Margin(10));
                        }
                        Console.WriteLine($"Elapsed : {stopwatch.ElapsedMilliseconds}");
                        UIApplication.Current.PostToUI(() =>
                        {
                            Console.WriteLine($"Elapsed On next Main loop: {stopwatch.ElapsedMilliseconds}");
                            UIApplication.Current.PostToUI(() =>
                            {
                                Console.WriteLine($"Elapsed On next next Main loop: {stopwatch.ElapsedMilliseconds}");
                            });
                        });
                    }
                },
                new Button("SkiaView")
                {
                    Clicked = async () =>
                    {
                        var flex = this["Flex"] as FlexBox;
                        flex.Clear();
                        await Task.Delay(1);
                        var stopwatch = Stopwatch.StartNew();
                        for (int i = 0; i < 5000; i++)
                        {
                            flex.Add(new SkiaComponent().Margin(10));
                        }
                        Console.WriteLine($"Elapsed : {stopwatch.ElapsedMilliseconds}");
                        UIApplication.Current.PostToUI(() =>
                        {
                            Console.WriteLine($"Elapsed On next Main loop: {stopwatch.ElapsedMilliseconds}");
                            UIApplication.Current.PostToUI(() =>
                            {
                                Console.WriteLine($"Elapsed On next next Main loop: {stopwatch.ElapsedMilliseconds}");
                            });
                        });
                    }
                },
                new Button("MultiView")
                {
                    Clicked = async () =>
                    {
                        var flex = this["Flex"] as FlexBox;
                        flex.Clear();
                        var stopwatch = Stopwatch.StartNew();
                        await Task.Delay(1);
                        for (int i = 0; i < 5000; i++)
                        {
                            flex.Add(new ViewComponent().Margin(10));
                        }
                        Console.WriteLine($"Elapsed : {stopwatch.ElapsedMilliseconds}");
                        UIApplication.Current.PostToUI(() =>
                        {
                            Console.WriteLine($"Elapsed On next Main loop: {stopwatch.ElapsedMilliseconds}");
                            UIApplication.Current.PostToUI(() =>
                            {
                                Console.WriteLine($"Elapsed On next next Main loop: {stopwatch.ElapsedMilliseconds}");
                            });
                        });
                    }
                },
                new Button("View")
                {
                    Clicked = async () =>
                    {
                        var flex = this["Flex"] as FlexBox;
                        flex.Clear();
                        var stopwatch = Stopwatch.StartNew();
                        await Task.Delay(1);
                        for (int i = 0; i < 5000; i++)
                        {
                            flex.Add(new View
                            {
                                CornerRadius = 10,
                                BackgroundColor = Color.Green,
                                DesiredHeight = 50,
                                DesiredWidth = 100,
                            }.Margin(10));
                        }
                        Console.WriteLine($"Elapsed : {stopwatch.ElapsedMilliseconds}");
                        UIApplication.Current.PostToUI(() =>
                        {
                            Console.WriteLine($"Elapsed On next Main loop: {stopwatch.ElapsedMilliseconds}");
                            UIApplication.Current.PostToUI(() =>
                            {
                                Console.WriteLine($"Elapsed On next next Main loop: {stopwatch.ElapsedMilliseconds}");
                            });
                        });
                    }
                },
                new Button("SVG")
                {
                    Clicked = async () =>
                    {
                        var flex = this["Flex"] as FlexBox;
                        flex.Clear();
                        var stopwatch = Stopwatch.StartNew();
                        await Task.Delay(1);
                        for (int i = 0; i < 5000; i++)
                        {
                            flex.Add(new ImageView
                            {
                                SynchronousLoading = true,
                                ResourceUrl = "svgtest1.svg",
                                DesiredHeight = 50,
                                DesiredWidth = 100,
                            }.Margin(10));
                        }
                        Console.WriteLine($"Elapsed : {stopwatch.ElapsedMilliseconds}");
                        UIApplication.Current.PostToUI(() =>
                        {
                            Console.WriteLine($"Elapsed On next Main loop: {stopwatch.ElapsedMilliseconds}");
                            UIApplication.Current.PostToUI(() =>
                            {
                                Console.WriteLine($"Elapsed On next next Main loop: {stopwatch.ElapsedMilliseconds}");
                            });
                        });
                    }
                },
                new Button("Scroll End")
                {
                    Clicked = () =>
                    {
                        var scroll = this["ScrollView"] as ScrollLayout;
                        scroll.ScrollTo(scroll.ScrollSize.Height, true);
                    }
                },
                new Button("Scroll Start")
                {
                    Clicked = () =>
                    {
                        var scroll = this["ScrollView"] as ScrollLayout;
                        scroll.ScrollTo(0, true);
                    }
                },
                new Button("Scroll loop * 10")
                {
                    Clicked = async () =>
                    {
                        var scroll = this["ScrollView"] as ScrollLayout;
                        for (int i = 0; i < 10; i++)
                        {
                            await scroll.ScrollTo(scroll.ScrollSize.Height, true);
                            await scroll.ScrollTo(0, true);
                        }
                        
                    }
                }
            }.Spacing(10).Row(1));

            Add(new ScrollLayout
            {
                Name = "ScrollView",
                Content = new FlexBox
                {
                    Name = "Flex",
                    Direction = FlexDirection.Row,
                    Wrap = FlexWrap.Wrap,
                    JustifyContent = FlexJustify.SpaceAround
                }
            }.Row(2));

        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

        class VectorComponent : VectorView
        {
            const int WIDTH = 100;
            const int HEIGHT = 50;

            public VectorComponent()
            {
                DesiredHeight = HEIGHT;
                DesiredWidth = WIDTH;
                var round = new RoundRectangle(0, 0, WIDTH, HEIGHT, HEIGHT * 0.3f, HEIGHT * 0.3f);
                round.Fill(new SolidPaint
                {
                    Color = Color.Green
                });
                Add(round);

                var circle = new Ellipse(WIDTH * 0.3f, HEIGHT / 2f, HEIGHT * 0.3f, HEIGHT * 0.3f);
                circle.Fill(new SolidPaint
                {
                    Color = Color.Red
                });
                Add(circle);

                var circle2 = new Ellipse(WIDTH * 0.7f, HEIGHT / 2f, HEIGHT * 0.3f, HEIGHT * 0.3f);
                circle2.Fill(new SolidPaint
                {
                    Color = Color.Blue
                });
                Add(circle2);
            }
        }

        class SkiaComponent : SKCanvasView
        {
            const int WIDTH = 100;
            const int HEIGHT = 50;

            public SkiaComponent()
            {
                DesiredWidth = WIDTH;
                DesiredHeight = HEIGHT;
                PaintSurface += Draw;
            }

            void Draw(object sender, SKPaintSurfaceEventArgs e)
            {
                var canvas = e.Surface.Canvas;
                canvas.Clear();

                using var greenPaint = new SKPaint
                {
                    IsAntialias = true,
                    Color = SKColors.Green,
                };
                canvas.DrawRoundRect(0, 0, WIDTH, HEIGHT, HEIGHT * 0.3f, HEIGHT * 0.3f, greenPaint);
                using var redPaint = new SKPaint
                {
                    IsAntialias = true,
                    Color = SKColors.Red,
                };
                using var bluePaint = new SKPaint
                {
                    IsAntialias = true,
                    Color = SKColors.Blue,
                };
                canvas.DrawCircle(WIDTH * 0.3f, HEIGHT / 2f, HEIGHT * 0.3f, redPaint);
                canvas.DrawCircle(WIDTH * 0.7f, HEIGHT / 2f, HEIGHT * 0.3f, bluePaint);
            }
        }

        class ViewComponent : AbsoluteLayout
        {
            const int WIDTH = 100;
            const int HEIGHT = 50;

            public ViewComponent()
            {
                DesiredHeight = HEIGHT;
                DesiredWidth = WIDTH;

                BackgroundColor = Color.Green;
                CornerRadius = HEIGHT * 0.3f;

                Add(new View
                {
                    DesiredHeight = HEIGHT * 0.6f,
                    DesiredWidth = HEIGHT * 0.6f,
                    BackgroundColor = Color.Red,
                    CornerRadius = 1f
                }.Margin(0, 0, HEIGHT * 0.6f + 10, 0).LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional));

                Add(new View
                {
                    DesiredHeight = HEIGHT * 0.6f,
                    DesiredWidth = HEIGHT * 0.6f,
                    BackgroundColor = Color.Blue,
                    CornerRadius = 1f
                }.Margin(HEIGHT * 0.6f + 10, 0, 0, 0).LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional));
            }
        }
    }
}
