using TizenUIGallery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class GCReclaimTest : Grid, ITestCase
    {
        int reclaimed = 0;
        List<WeakReference<View>> weaks = new List<WeakReference<View>>();
        bool run = true;
        public GCReclaimTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(30);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "GC Reclaim Test",
                FontSize = 30,
            });

            Add(new TextView
            {
                Name = "Log",
                Text = "0 Reclaimed",
                FontSize = 20,
            }.Row(1));


            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
            };
            topLayout.Row(2);

            var box = Make100();
            box.ParentOriginX = 0.5f;
            box.ParentOriginY = 0.5f;
            box.PivotPointX = 0.5f;
            box.PivotPointY = 0.5f;
            box.X = 0;
            box.Y = 0;
            box.PositionUsesPivotPoint = true;
            topLayout.Add(box);

            Timer timer2 = null;
            var timer = Timer.Repeat(4000, () =>
            {
                if (!run)
                    return false;
                var list = RemoveRandom(box);
                timer2 = Timer.Repeat(2000, () =>
                {
                    CreateBox(box, list);

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

                    return false;
                });
                return run;
            });

            Add(topLayout);

            DetachedFromWindow += (s, e) =>
            {
                timer.Stop();
                timer2?.Stop();
            };
        }

        ViewGroup Make100()
        {
            var layout = new ViewGroup
            {
                Width = 400,
                Height = 400,
            };

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var box = MakeSmallBox(x, y, 40);
                    layout.Add(box);
                }
            }

            return layout;
        }

        View MakeSmallBox(int x, int y, int sizeUnit)
        {
            Random rnd = new Random();
            var box = new View
            {
                Width = sizeUnit,
                Height = sizeUnit,
                X = x * sizeUnit,
                Y = y * sizeUnit,
                BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3f), (float)(rnd.NextDouble() * 0.7 + 0.3f), (float)(rnd.NextDouble() * 0.7 + 0.3f), 1f),
            };
            box.TouchEvent += (s, e) => { };
            box.Relayout += (s, e) => { };
            return box;
        }

        List<(int, int)> RemoveRandom(ViewGroup view)
        {
            var list = new List<(int, int)>();
            var rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                int target = rnd.Next(view.Count);
                var child = view[target];
                var pos = ((int)(child.X / child.Width), (int)(child.Y / child.Height));
                list.Add(pos);
                view.Remove(child);
                weaks.Add(new WeakReference<View>(child));
            }
            return list;
        }

        void CreateBox(ViewGroup view, List<(int, int)> positions)
        {
            foreach (var pos in positions)
            {
                var child = MakeSmallBox(pos.Item1, pos.Item2, 40);
                view.Add(child);
            }
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            run = false;
            Dispose();
        }
    }
}
