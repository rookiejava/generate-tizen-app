using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class BackgroundTest1 : Grid, ITestCase
    {
        public BackgroundTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Background Test1",
                FontSize = 30,
            });

            var target = new View
            {
                Name = "View1",
                DesiredHeight = 300,
                DesiredWidth = 300,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(1);
            Add(target);

            Add(new FlexBox
            {
                BackgroundColor = Color.FromHex("#f9fff2"),
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                Children =
                {
                    new Button("ColorBackground")
                    {
                        Clicked = () =>
                        {
                            var colorVisual = new ColorBackground
                            {
                                Color = Color.Green
                            };
                            this["View1"].SetBackground(colorVisual);
                            Console.WriteLine($"BackgroundColor : {this["View1"].BackgroundColor}");
                        }
                    }.Margin(10),
                    new Button("ColorVisual2")
                    {
                        Clicked = () =>
                        {
                            var colorVisual = new ColorBackground
                            {
                                Color = Color.Red,
                            };
                            this["View1"].SetBackground(colorVisual);
                        }
                    }.Margin(10),
                    new Button("ColorVisual3")
                    {
                        Clicked = () =>
                        {
                            var colorVisual = new ColorBackground
                            {
                                Color = Color.Blue,
                            };
                            this["View1"].SetBackground(colorVisual);
                        }
                    }.Margin(10),
                    new Button("ImageBackground")
                    {
                        Clicked = () =>
                        {
                            this["View1"].SetBackground(new ImageBackground
                            {
                                Url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "img2.png",
                            });
                        }
                    }.Margin(10),
                    new Button("ImageVisual2")
                    {
                        Clicked = () =>
                        {
                            this["View1"].SetBackground(new ImageBackground
                            {
                                Url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "animated.gif",
                            });
                        }
                    }.Margin(10),
                    new Button("ImageVisual3")
                    {
                        Clicked = () =>
                        {
                            this["View1"].SetBackground(new ImageBackground
                            {
                                Url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "keyboard_focus.9.png",
                            });
                        }
                    }.Margin(10),
                    new Button("GradientBackground")
                    {
                        Clicked = () =>
                        {
                            this["View1"].SetBackground(new LinearGradientBackground
                            {
                                StartPoint = new Point(-1, -1),
                                EndPoint = new Point(1, 1),
                                GradientStops =
                                {
                                    new GradientStop(Color.Yellow, 0.0f),
                                    new GradientStop(Color.Orange, 0.5f),
                                    new GradientStop(Color.Red, 1.0f)
                                }
                            });
                        }
                    }.Margin(10),
                    new Button("GradientVisual2")
                    {
                        Clicked = () =>
                        {
                            this["View1"].SetBackground(new RadialGradientBackground
                            {
                                Center = new Point(0, 0),
                                Radius = 1,
                                GradientStops =
                                {
                                    new GradientStop(Color.Yellow, 0.0f),
                                    new GradientStop(Color.Red, 0.2f),
                                    new GradientStop(Color.Blue, 0.5f),
                                    new GradientStop(Color.GreenYellow, 0.7f),
                                    new GradientStop(Color.Black, 1f)
                                }
                            });
                        }
                    }.Margin(10),
                    new Button("GradientVisual3")
                    {
                        Clicked = () =>
                        {
                            this["View1"].SetBackground(new LinearGradientBackground
                            {
                                StartPoint = new Point(-1, 0),
                                EndPoint = new Point(1, 0),
                                GradientStops =
                                {
                                    new GradientStop(Color.Red, 0f),
                                    new GradientStop(Color.Orange, 0.2f),
                                    new GradientStop(Color.Yellow, 0.4f),
                                    new GradientStop(Color.Green, 0.6f),
                                    new GradientStop(Color.Blue, 0.8f),
                                    new GradientStop(Color.Navy, 1f),
                                }
                            });
                        }
                    }.Margin(10),
                    new Button("BackgroundColor(Red)")
                    {
                        Clicked = () =>
                        {
                            this["View1"].BackgroundColor = Color.Red;
                            Console.WriteLine($"BackgroundColor : {this["View1"].BackgroundColor}");
                        }
                    }.Margin(10),

                    new Button("Get BackgroundColor")
                    {
                        Clicked = () =>
                        {
                            Console.WriteLine($"BackgroundColor : {this["View1"].BackgroundColor}");
                        }
                    }.Margin(10),
                },
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
    }
}
