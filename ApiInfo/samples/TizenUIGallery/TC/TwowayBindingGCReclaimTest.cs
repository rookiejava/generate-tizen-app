using TizenUIGallery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class TwowayBindingGCReclaimTest : Grid, ITestCase
    {
        class MyData : ViewModel
        {
            public MyData(string value)
            {
                Text = value;
            }
            public string Text
            {
                get => Get<string>();
                set => Set(value);
            }
        }
        int reclaimed = 0;
        List<WeakReference<View>> weaks = new List<WeakReference<View>>();

        MyData model;
        BindingSession<MyData> bindingSession;
        TextView label;
        TextField field;

        int createdCount = 1;
        bool isBinding = true;
        public TwowayBindingGCReclaimTest()
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
                Text = "Twoway binding GC Reclaim Test",
                FontSize = 30,
            });

            Add(new VStack{
                Spacing = 5,
                Name = "Main",
            }.Row(1));

            Add(new VStack
            {
                new TextView
                {
                    Name = "Log",
                    Text = "0 Reclaimed",
                    FontSize = 20,
                },
                new HStack
                {
                    new Button("Unbind")
                    {
                        Name = "Unbind",
                        Clicked = () =>
                        {
                            if (isBinding)
                            {
                                isBinding = false;
                                (this["Unbind"] as Button).Text = "Bind";
                                bindingSession.ClearBinding();
                            }
                            else
                            {
                                isBinding = true;
                                (this["Unbind"] as Button).Text = "Unbind";
                                label.SetBinding(bindingSession, TextBindings<TextView>.TextProperty, "Text");
                                field.SetTwoWayBinding(bindingSession, EditableTextBindings<TextField>.TextProperty, "Text");
                            }
                        }
                    },
                    new Button("Reset")
                    {
                        Clicked = () =>
                        {
                            ResetViews();
                        }
                    },
                    new Button("GC")
                    {
                        Clicked = () =>
                        {
                            GC.Collect();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.WaitForPendingFinalizers();

                            foreach (var weak in weaks.ToList())
                            {
                                if (!weak.TryGetTarget(out _))
                                {
                                    reclaimed++;
                                    weaks.Remove(weak);
                                }
                            }
                            (this["Log"] as TextView).Text = $"{reclaimed} Reclaimed";

                        }
                    }
                }
            }.Row(2));


            ResetViews();

        }

        void ResetViews()
        {
            (this["Main"] as Layout).Clear();
            model = new MyData($"Mickey {createdCount}");
            bindingSession = new BindingSession<MyData>();
            bindingSession.ViewModel = model;
            label = new TextView
            {
                FontSize = 20,
                TextColor = Color.Gray,
                BackgroundColor = Color.White,
                BorderlineColor = Color.Gray,
            };
            field = new TextField
            {
                FontSize = 20,
                BackgroundColor = new Color(Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f, Random.Shared.Next(100, 255) / 255f),
                BorderlineColor = Color.Gray,
            };

            (this["Main"] as Layout).Add(label);
            (this["Main"] as Layout).Add(field);
            weaks.Add(new WeakReference<View>(label));
            weaks.Add(new WeakReference<View>(field));

            label.SetBinding(bindingSession, TextBindings<TextView>.TextProperty, "Text");
            field.SetTwoWayBinding(bindingSession, EditableTextBindings<TextField>.TextProperty, "Text");

            (this["Unbind"] as Button).Text = "Unbind";
            isBinding = true;

            createdCount++;
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
