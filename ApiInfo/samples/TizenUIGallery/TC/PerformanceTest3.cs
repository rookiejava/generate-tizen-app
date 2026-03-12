using System;
using System.Diagnostics;
using System.Linq;
using Tizen.UI;
using Tizen.UI.Internal;

namespace TizenUIGallery.TC
{
    class PerformanceTest3 : ViewGroup, ITestCase
    {
        FrameUpdate _frameUpdate;
        public PerformanceTest3()
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

            AddParticle(contentArea, 450);

            var fpsLabel = new TextView
            {
                X = 0,
                Y = 750,
                WidthResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = Color.DeepSkyBlue,
                Height = 100,
                Text = "FPS : ",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            };

            Add(fpsLabel);

            var fpsLabel2 = new TextView
            {
                X = 0,
                Y = 850,
                WidthResizePolicy = ResizePolicy.FillToParent,
                BackgroundColor = Color.DeepSkyBlue,
                Height = 100,
                Text = "FPS : ",
                FontSize = 30,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
            };

            Add(fpsLabel2);

            _frameUpdate = new FrameUpdate(contentArea);
            Window.Default.AddFrameUpdateCallback(_frameUpdate);

            var timer = Stopwatch.StartNew();

            Window.Default.SetRenderingBehavior(RenderingBehavior.Continuously);

            var repeat = Timer.Repeat(500, () =>
            {
                fpsLabel.Text = $"{timer.Elapsed.ToString(@"mm\:ss")},  Views : {contentArea.Children.Count}, FPS : {_frameUpdate.GetAccumulateFPS():0.00}";
                fpsLabel2.Text = $"FPS (last 10) : {_frameUpdate.GetFPS():0.00}";
                return true;
            });

            DetachedFromWindow += (s, e) =>
            {
                repeat.Stop();
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
            Window.Default.RemoveFrameUpdateCallback(_frameUpdate);
            Window.Default.SetRenderingBehavior(RenderingBehavior.IfRequired);
            Dispose();
        }

        public class FrameUpdate : FrameUpdateCallback
        {
            float avgFPS = 0;
            float totalElapsed = 0;
            float[] elapsedHistory = new float[10];
            int idx = 0;
            float accumulateFPS = 0;
            double accumulateElapsed = 0;
            long renderCount = 0;
            ViewGroup _content;

            public FrameUpdate(ViewGroup content)
            {
                _content = content;
            }

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

            public float GetAccumulateFPS()
            {
                return accumulateFPS;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            protected override void OnUpdate(float elapsedSeconds)
            {
                elapsedHistory[idx] = elapsedSeconds;
                totalElapsed += elapsedSeconds;
                accumulateElapsed += elapsedSeconds;

                stopwatch.Restart();
                foreach (var view in _content)
                {
                    var pos = GetPosition(view.ID);
                    (view as Particle).MoveOnRenderThread(pos, out var newX, out var newY);
                    SetPosition(view.ID, new Point(newX, newY));
                }
                var milisecond = stopwatch.ElapsedMilliseconds;
                elapsedHistory[idx] += (milisecond / 1000);
                totalElapsed += (milisecond / 1000);
                accumulateElapsed += (milisecond / 1000);

                idx = (idx + 1) % 10;
                renderCount++;

                totalElapsed -= elapsedHistory[idx];
                var avgElapsedTime = totalElapsed / 10;
                avgFPS = avgElapsedTime == 0 ? 0 : 1 / avgElapsedTime;
                var avgtime = (accumulateElapsed / renderCount);
                accumulateFPS = avgtime == 0 ? 0 : 1 / (float)avgtime;
                FrameUpdated = true;
            }
        }

    }
}
