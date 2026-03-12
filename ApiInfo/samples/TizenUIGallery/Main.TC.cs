using System;
using System.Collections.Generic;
using Tizen.UI;

namespace TizenUIGallery
{
    partial class App : UIApplication
    {
        void MemoryProfile_EmptyScene()
        {
            Window.Default.DefaultLayer.Add(new View
            {
                BackgroundColor = Color.Green,
                HeightResizePolicy = ResizePolicy.FillToParent,
                WidthResizePolicy = ResizePolicy.FillToParent
            });
            Timer.Timeout(5000, () =>
            {
                GC.Collect();
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.WaitForPendingFinalizers();
                Exit();
            });
        }

        void MemoryProfile_SimpleScene1()
        {
            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f)
            };

            var text = new TextView
            {
                Text = "Hello world",
                FontSize = 80,
                TextColor = Color.Blue,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                X = 0,
                Y = 100,
                PivotPointX = 0.5f,
                PivotPointY = 0.5f,
                PositionUsesPivotPoint = true,
                WidthResizePolicy = ResizePolicy.UseNaturalSize,
                BackgroundColor = Color.Green,
            };


            var redBox = new View
            {
                BackgroundColor = Color.Red,
                Width = 300,
                Height = 300,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                X = 0,
                Y = 500,
                PivotPointX = 0.5f,
                PivotPointY = 0.5f,
                PositionUsesPivotPoint = true,
            };
            topLayout.Add(text);
            topLayout.Add(redBox);

            var box = make100();
            box.ParentOriginX = 0.5f;
            box.ParentOriginY = 0.5f;
            box.PivotPointX = 0.5f;
            box.PivotPointY = 0.5f;
            box.X = 0;
            box.Y = 400;
            box.PositionUsesPivotPoint = true;
            topLayout.Add(box);

            Window.Default.DefaultLayer.Add(topLayout);

            Timer.Timeout(5000, () =>
            {
                GC.Collect();
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.WaitForPendingFinalizers();
                Exit();
            });
        }

        void StartTimeProfile_SimpleScene()
        {
            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f)
            };

            var text = new TextView
            {
                Text = "Hello world",
                FontSize = 80,
                TextColor = Color.Blue,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                X = 0,
                Y = 100,
                PivotPointX = 0.5f,
                PivotPointY = 0.5f,
                PositionUsesPivotPoint = true,
                WidthResizePolicy = ResizePolicy.UseNaturalSize,
                BackgroundColor = Color.Green,
            };
            
            topLayout.Add(text);
            
            for (int i = 0; i < 100; i++)
            {
                var box = make100();
                box.ParentOriginX = 0f;
                box.ParentOriginY = 0f;
                box.PivotPointX = 0.5f;
                box.PivotPointY = 0.5f;
                box.X = (i % 10) * 20;
                box.Y = (i / 10) * 20 + 300;
                box.PositionUsesPivotPoint = false;
                topLayout.Add(box);
            }

            Window.Default.DefaultLayer.Add(topLayout);
        }

        ViewGroup make100()
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
                    var box = makeSmallBox(x, y, 40);
                    layout.Add(box);
                }
            }

            return layout;
        }

        View makeSmallBox(int x, int y, int sizeUnit)
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
            return box;
        }


        void MemoryProfile_DynamicScene()
        {
            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f)
            };

            var box = make100();
            box.ParentOriginX = 0.5f;
            box.ParentOriginY = 0.5f;
            box.PivotPointX = 0.5f;
            box.PivotPointY = 0.5f;
            box.X = 0;
            box.Y = 0;
            box.PositionUsesPivotPoint = true;
            topLayout.Add(box);

            Timer.Repeat(15, () =>
            {
                RandomMove(box);
                return true;
            });

            Window.Default.DefaultLayer.Add(topLayout);

            Timer.Timeout(15000, () =>
            {
                GC.Collect();
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.WaitForPendingFinalizers();
                Exit();
            });
        }

        void RandomMove(ViewGroup view)
        {
            Random rnd = new Random();
            foreach (var child in view.Children)
            {
                child.X += rnd.Next(-50, 50);
                child.Y += rnd.Next(-50, 50);
            }
        }

        void MemoryProfile_DynamicScene2()
        {
            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f)
            };

            var box = make100();
            box.ParentOriginX = 0.5f;
            box.ParentOriginY = 0.5f;
            box.PivotPointX = 0.5f;
            box.PivotPointY = 0.5f;
            box.X = 0;
            box.Y = 0;
            box.PositionUsesPivotPoint = true;
            topLayout.Add(box);

            Timer.Repeat(15, () =>
            {
                RandomColor(box);
                return true;
            });

            Window.Default.DefaultLayer.Add(topLayout);

            Timer.Timeout(15000, () =>
            {
                GC.Collect();
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.WaitForPendingFinalizers();
                Exit();
            });
        }

        void RandomColor(ViewGroup view)
        {
            Random rnd = new Random();
            foreach (var child in view.Children)
            {
                child.BackgroundColor = new Color((float)(rnd.NextDouble() * 0.7 + 0.3f), (float)(rnd.NextDouble() * 0.7 + 0.3f), (float)(rnd.NextDouble() * 0.7 + 0.3f), 1f);
            }
        }

        void MemoryProfile_DynamicScene3()
        {
            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f)
            };

            var box = make100();
            box.ParentOriginX = 0.5f;
            box.ParentOriginY = 0.5f;
            box.PivotPointX = 0.5f;
            box.PivotPointY = 0.5f;
            box.X = 0;
            box.Y = 0;
            box.PositionUsesPivotPoint = true;
            topLayout.Add(box);

            Timer.Repeat(150, () =>
            {
                RandomOpacity(box);
                return true;
            });

            Window.Default.DefaultLayer.Add(topLayout);

            Timer.Timeout(15000, () =>
            {
                GC.Collect();
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.WaitForPendingFinalizers();
                Exit();
            });
        }

        void RandomOpacity(ViewGroup view)
        {
            Random rnd = new Random();
            foreach (var child in view.Children)
            {
                child.Opacity = (float)rnd.NextDouble();
            }
        }

        void MemoryProfile_DynamicScene4()
        {
            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f)
            };

            var box = make100();
            box.ParentOriginX = 0.5f;
            box.ParentOriginY = 0.5f;
            box.PivotPointX = 0.5f;
            box.PivotPointY = 0.5f;
            box.X = 0;
            box.Y = 0;
            box.PositionUsesPivotPoint = true;
            topLayout.Add(box);

            bool run = true;

            Timer.Repeat(150, () =>
            {
                RandomColor(box);
                return run;
            });

            Timer.Timeout(60 * 1000 * 2, () =>
            {
                run = false;
            });

            Timer.Repeat(10000, () =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return true;
            });

            Window.Default.DefaultLayer.Add(topLayout);

            Timer.Timeout(60 * 1000 * 3, () =>
            {
                GC.Collect();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.WaitForPendingFinalizers();
                GC.WaitForFullGCComplete();
                GC.WaitForFullGCComplete();
                Current.PostToUI(() => Exit());
            });
        }

        void MemoryProfile_CreateDeleteScene()
        {
            var topLayout = new ViewGroup
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f)
            };

            var box = make100();
            box.ParentOriginX = 0.5f;
            box.ParentOriginY = 0.5f;
            box.PivotPointX = 0.5f;
            box.PivotPointY = 0.5f;
            box.X = 0;
            box.Y = 0;
            box.PositionUsesPivotPoint = true;
            topLayout.Add(box);

            bool run = true;

            Timer.Repeat(8000, () =>
            {
                var list = RemoveRandom(box);
                Timer.Timeout(4000, () =>
                {
                    CreateBox(box, list);
                });
                return run;
            });

            Timer.Timeout(60 * 1000 * 3, () =>
            {
                run = false;
            });

            Window.Default.DefaultLayer.Add(topLayout);

            Timer.Timeout(60 * 1000 * 4, () =>
            {
                GC.Collect();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.WaitForPendingFinalizers();
                GC.WaitForFullGCComplete();
                GC.WaitForFullGCComplete();
                Current.PostToUI(() => Exit());
            });
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
                child.Dispose();
            }
            return list;
        }

        void CreateBox(ViewGroup view, List<(int, int)> positions)
        {
            foreach (var pos in positions)
            {
                var child = makeSmallBox(pos.Item1, pos.Item2, 40);
                view.Add(child);
            }
        }
    }
}
