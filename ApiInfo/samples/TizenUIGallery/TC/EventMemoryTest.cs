using TizenUIGallery.Util;
using System;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class EventMemoryTest : Grid, ITestCase
    {
        public EventMemoryTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Event Memory Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new TextView
                {
                    Name = "Log",
                    DesiredHeight = 100,
                    BackgroundColor = Color.LightGray,
                    FontSize = 20,
                    IsMultiline = true,
                },

                new Button("Add/Remove repeat test")
                {
                    Name = "Test1",
                    Clicked = async () =>
                    {
                        var view = new View();
                        void HandleAttachedWindow(object sender, EventArgs eventArgs)
                        {
                            (this["Log"] as TextView).Text = $"Attached Window {sender}";
                        };

                        for (int i = 0; i < 100000; i++)
                        {
                            view.AttachedToWindow += HandleAttachedWindow;
                            view.AttachedToWindow -= HandleAttachedWindow;
                        }

                        view.AttachedToWindow += HandleAttachedWindow;

                        this.Add(view);
                        await Task.Delay(10);
                        this.Remove(view);
                        (this["Test1"] as Button).Text = "Done";
                    }
                },
                new Button("Many view with events")
                {
                    Name = "Test2",
                    Clicked = async () =>
                    {
                        void HandleAttachedWindow(object sender, EventArgs eventArgs)
                        {
                            (this["Log"] as TextView).Text = $"Attached Window {sender}";
                        };
                        for (int i = 0; i < 300000; i++)
                        {
                            var view = new View();
                            view.AttachedToWindow += HandleAttachedWindow;
                            view.Focused += (s,e) => { };
                            view.TouchEvent += (s, e) => { };
                            view.Dispose();
                            if (i % 1000 == 0)
                            {
                                await Task.Delay(1);
                            }
                        }
                        (this["Test2"] as Button).Text = "Done";
                    }
                },
                new Button("Many View 2")
                {
                    Name = "Test3",
                    Clicked = () =>
                    {
                        var absLayout = (AbsoluteLayout)this["Abs"];
                        for (int i = 0; i < 100; i++)
                        {
                            for (int j = 0; j < 100; j++)
                            {
                                var view = new View
                                {
                                    BackgroundColor = Color.Green,
                                    BorderlineColor = Color.Black,
                                    BorderlineWidth = 1,
                                }.LayoutBounds(10 * i, 10 * j, 10, 10).LayoutFlags(AbsoluteLayoutFlags.None);

                                view.TouchEvent += (s, e) =>
                                {
                                    Console.WriteLine("Clicked");
                                };
                                absLayout.Add(view);
                            }
                        }
                    }
                }

            }.Row(1));
            Add(new AbsoluteLayout().Row(1).Name("Abs"));
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
