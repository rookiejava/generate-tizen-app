using System;
using System.Linq;
using Tizen.UI;

namespace TizenUIGallery.TC
{

    class MemoryProfile_ViewGroup : MemoryProfile_View<ViewGroup>, ITestCase { }

    class MemoryProfile_SingleView : MemoryProfile_View<View>, ITestCase { }

    class MemoryProfile_View<T> : ViewGroup where T : View, new()
    {
        Timer timer;
        public MemoryProfile_View()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            timer = new Timer(1000);

            int count = 0;
            timer.TickHandler = () =>
            {
                foreach (var child in Children.ToList())
                {
                    child.Dispose();
                }

                var itemW = Width / 50;
                var itemH = Height / 100;
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        var child = new T()
                        {
                            Width = itemW,
                            Height = itemH,
                            X = i * itemW,
                            Y = j * itemH,
                        };
                        Add(child);
                    }
                }
                if (count++ > 4)
                {
                    UIApplication.Current.Exit();
                }
                return true;
            };

            timer.Start();

            DetachedFromWindow += (s, e) =>
            {
                timer.Stop();
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
    }
}
