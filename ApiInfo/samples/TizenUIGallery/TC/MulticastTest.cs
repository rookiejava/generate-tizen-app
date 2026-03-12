using TizenUIGallery.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class MulticastTest : Grid, ITestCase
    {
        bool isRun = false;
        public MulticastTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "AnimationTest1",
                FontSize = 30,
            });
            Add(new VStack
            {
                Spacing = 10,
                Children =
                {
                    new TextView
                    {
                        Name = "Log"
                    },
                    new Button("Test with Event")
                    {
                        Clicked = async () =>
                        {
                            if (isRun)
                                return;
                            (this["Log"] as TextView).Text = "Add Event Handlers...";
                            isRun = true;
                            await Task.Run(() =>
                            {
                                for (int i = 0; i < 5000; i++)
                                {
                                    int local = i;
                                    var handler = (EventHandler)((object sender, EventArgs args) =>
                                    {
                                        Console.WriteLine($"{local}");
                                    });
                                    _eventList.Add(handler);
                                    DummyEvent += handler;
                                }
                            });
                            for (int i = 5000 - 1; i >= 0; i -= 100)
                            {
                                (this["Log"] as TextView).Text = $"Remove Event Handler from {i}-{i-100}";
                                await Task.Run(() =>
                                {
                                    for (int j = i; j > i - 100; j--)
                                    {
                                        DummyEvent -= _eventList[j];
                                    }
                                });
                            }
                            isRun = false;
                            (this["Log"] as TextView).Text = "Done";
                        }
                    },
                    new Button("Test with WeakEvent")
                    {
                        Clicked = async () =>
                        {
                            if (isRun)
                                return;
                            (this["Log"] as TextView).Text = "Add Event Handlers...";
                            isRun = true;
                            await Task.Run(() =>
                            {
                                for (int i = 0; i < 5000; i++)
                                {
                                    int local = i;
                                    var handler = (EventHandler)((object sender, EventArgs args) =>
                                    {
                                        Console.WriteLine($"{local}");
                                    });
                                    _eventList.Add(handler);
                                    WeakDummyEvent += handler;
                                }
                            });
                            for (int i = 5000 - 1; i >= 0; i -= 100)
                            {
                                (this["Log"] as TextView).Text = $"Remove Event Handler from {i}-{i-100}";
                                await Task.Run(() =>
                                {
                                    for (int j = i; j > i - 100; j--)
                                    {
                                        WeakDummyEvent -= _eventList[j];
                                    }
                                });
                            }
                            isRun = false;
                            (this["Log"] as TextView).Text = "Done";
                        }
                    }
                }
            }.Row(1));
        }

        List<EventHandler> _eventList = new List<EventHandler>();
#pragma warning disable CS0067 // The event 'MulticastTest.DummyEvent' is never used
        public event EventHandler DummyEvent;
#pragma warning restore CS0067 // The event 'MulticastTest.DummyEvent' is never used

        WeakEventManager _weakEventManager = new();
        public event EventHandler WeakDummyEvent
        {
            add => _weakEventManager.AddEventHandler(value);
            remove => _weakEventManager.RemoveEventHandler(value);
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
