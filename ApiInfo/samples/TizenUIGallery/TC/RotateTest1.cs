using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class RotateTest1 : Grid, ITestCase
    {
        public RotateTest1()
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
                Text = "Rotate Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new HStack
                {
                    Spacing = 10,
                    Children =
                    {
                        new TextView{ Text = "X:" , FontSize = 30 },
                        new TextField
                        {
                            Text = "0",
                            DesiredWidth = 100,
                            BackgroundColor = Color.White,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            FontSize = 30,
                        }.Self(field =>
                        {
                            field.TextChanged += (s, e) =>
                            {
                                UIApplication.Current.PostToUI(() =>
                                {
                                    try
                                    {
                                        Console.WriteLine($"!!! Text : {field.Text}");
                                        this["Target"].RotationX = float.Parse(field.Text);
                                        UpdateRotateState();
                                    }
                                    catch { }
                                });
                            };
                        }),

                        new TextView{ Text = "Y:" , FontSize = 30 },
                        new TextField
                        {
                            Text = "0",
                            DesiredWidth = 100,
                            BackgroundColor = Color.White,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            FontSize = 30,
                        }.Self(field =>
                        {
                            field.TextChanged += (s, e) =>
                            {
                                UIApplication.Current.PostToUI(() =>
                                {
                                    try
                                    {
                                        this["Target"].RotationY = float.Parse(field.Text);
                                        UpdateRotateState();
                                    }
                                    catch { }
                                });
                            };
                        }),

                        new TextView{ Text = "Z:" , FontSize = 30 },
                        new TextField
                        {
                            Text = "0",
                            DesiredWidth = 100,
                            BackgroundColor = Color.White,
                            BorderlineColor = Color.Black,
                            BorderlineWidth = 1,
                            FontSize = 30,
                        }.Self(field =>
                        {
                            field.TextChanged += (s, e) =>
                            {
                                UIApplication.Current.PostToUI(() =>
                                {
                                    try
                                    {
                                        this["Target"].Rotation = float.Parse(field.Text);
                                        UpdateRotateState();
                                    }
                                    catch { }
                                });
                            };
                        }),
                    }
                }.Margin(20),
                new TextView
                {
                    FontSize = 30,
                    Name = "Log"
                }

            }.Row(1));

            Add(new View
            {
                Name = "Target",
                BackgroundColor = Color.Green,
                DesiredHeight = 300,
                DesiredWidth = 300,
            }.VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center).Row(2));
        }

        void UpdateRotateState()
        {
            (this["Log"] as TextView).Text = $"X:{this["Target"].RotationX}, Y: {this["Target"].RotationY}, Z: {this["Target"].Rotation}";
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
