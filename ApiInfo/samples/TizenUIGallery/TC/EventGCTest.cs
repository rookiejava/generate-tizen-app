using TizenUIGallery.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class EventGCTest : Grid, ITestCase
    {
        public EventGCTest()
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
                Text = "Event GC Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new HStack
                {
                    new Button("Add TouchEvent")
                    {
                        Clicked = () =>
                        {
                            this["Target"].TouchEvent += EventGCTest_TouchEvent;
                        }
                    },
                    new Button("Remove TouchEvent")
                    {
                        Clicked = () =>
                        {
                            this["Target"].TouchEvent -= EventGCTest_TouchEvent;
                        }
                    },
                    new Button("GC")
                    {
                        Clicked = () =>
                        {
                            for (int i = 0; i < 1000; i++)
                            {
                                var t = new byte[1000];
                            }
                            GC.Collect();
                            GC.Collect();
                        }
                    },
                }.Spacing(10),
                new View
                {
                    Name = "Target",
                    BackgroundColor = Color.Green,
                    DesiredHeight = 300,
                    DesiredWidth = 300,
                }
            }.Row(1).Spacing(10));
        }

        void EventGCTest_TouchEvent(object sender, TouchEventArgs e)
        {
            if (e.Touch[0].State == TouchState.Down)
            {
                (sender as View).BackgroundColor = Color.Red;
            }
            else
            {
                (sender as View).BackgroundColor = Color.Green;
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
