using System;
using System.Linq;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    class PerformanceTest1 : ViewGroup, ITestCase
    {

        Timer ntimer;
        public PerformanceTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            var contentArea = new ViewGroup
            {
                X = 0,
                Y = 0,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 600,
                BackgroundColor = Color.Gray,
            };
            Add(contentArea);

            AddParticle(contentArea, 100);

            var label = new TextView
            {
                X = 0,
                Y = 650,
                WidthResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = Color.DeepSkyBlue,
                Height = 100,
                Text = "<- less  <Drag area>  more ->",
                FontSize = 40,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            };
            Add(label);

            Point pos = new Point(0, 0);
            label.TouchEvent += (s, e) =>
            {
                if (e.Touch[0].State == TouchState.Down)
                {
                    pos = e.Touch[0].Position;
                }
                else if (e.Touch[0].State == TouchState.Motion)
                {
                    var cur = e.Touch[0].Position;
                    var diff = (cur.X - pos.X) / 2f;
                    if (diff > 0)
                        AddParticle(contentArea, (int)diff);
                    else
                        RemoveParticle(contentArea, -(int)diff);
                    pos = cur;
                }
            };

            var fpsLabel = new TextView
            {
                X = 0,
                Y = 750,
                WidthResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = Color.DeepSkyBlue,
                Height = 100,
                Text = "FPS : ",
                FontSize = 40,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            };

            Add(fpsLabel);

            var _frameUpdate = new FrameUpdate();
            Window.Default.AddFrameUpdateCallback(_frameUpdate);

            //var timer = ElmSharp.EcoreMainloop.AddTimer(0.1, () =>
            //{
            //    foreach (var view in contentArea.Children)
            //    {
            //        (view as Particle).MoveWithAnimation();
            //    }
            //    fpsLabel.Text = $"Views : {contentArea.Children.Count}, Rendering FPS : {_frameUpdate.GetFPS():0.00}";
            //    return true;
            //});

            ntimer = new Timer(100)
            {
                TickHandler = () =>
                {
                    foreach (var view in contentArea.Children)
                    {
                        (view as Particle).MoveWithAnimation();
                    }
                    fpsLabel.Text = $"Views : {contentArea.Children.Count}, Rendering FPS : {_frameUpdate.GetFPS():0.00}";
                    return true;
                }
            };
            ntimer.Start();

            DetachedFromWindow += (s, e) =>
            {
                ntimer.Dispose();
                //ElmSharp.EcoreMainloop.RemoveTimer(timer);
                Window.Default.RemoveFrameUpdateCallback(_frameUpdate);
            };
        }

        void AddParticle(ViewGroup group, int count)
        {
            for (int i = 0; i < count; i++)
            {
                group.Add(MakeParticle());
            }
        }

        void RemoveParticle(ViewGroup group, int count)
        {
            count = Math.Min(count, group.Count);
            var toremove = group.Children.Take(count);
            foreach (var view in toremove)
            {
                group.Remove(view);
                view.Dispose();
            }
        }

        View MakeParticle()
        {
            var rnd = new Random();
            return new Particle
            {
                Width = 30,
                Height = 30,
                BackgroundColor = new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1),
                X = (float)rnd.NextDouble() * 720,
                Y = (float)rnd.NextDouble() * 500,
            };
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }

        public class FrameUpdate : FrameUpdateCallback
        {
            float avgFPS = 0;
            float totalElapsed = 0;
            float[] elapsedHistory = new float[10];
            int idx = 0;


            public bool FrameUpdated { get; set; }

            public void Reset()
            {
                totalElapsed = 0;
                avgFPS = 0;
            }

            public float GetFPS()
            {
                return avgFPS;
            }

            protected override void OnUpdate(float elapsedSeconds)
            {

                elapsedHistory[idx] = elapsedSeconds;
                totalElapsed += elapsedSeconds;

                idx = (idx + 1) % 10;

                totalElapsed -= elapsedHistory[idx];
                var avgElapsedTime = totalElapsed / 10;
                avgFPS = avgElapsedTime == 0 ? 0 : 1 / avgElapsedTime;
                FrameUpdated = true;
            }
        }

    }
}
