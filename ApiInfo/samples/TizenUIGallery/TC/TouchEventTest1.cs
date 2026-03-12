using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class TouchEventTest1 : ViewGroup, ITestCase
    {
        class MyViewModel : ViewModel
        {
            public string Text
            {
                get => Get<string>();
                set => Set(value);
            }
        }
        public TouchEventTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);
            var vm = new MyViewModel();
            var target = new VStack
            {
                Width = 300,
                Height = 300,
                BackgroundColor = Color.Violet,
                ParentOriginX = 0.5f,
                ParentOriginY = 0.5f,
                PivotPointX = 0.5f,
                PivotPointY = 0.5f,
                X = 0,
                Y = 0,
                Children =
                {
                    new TextView
                    {
                        FontSize = 20,
                        IsMultiline = true,
                        BackgroundColor = Color.Aqua,
                    }
                    .BindText("Text")
                    .VerticalLayoutAlignment(LayoutAlignment.Center)
                    .HorizontalLayoutAlignment(LayoutAlignment.Center),
                }
            }
            .VerticalLayoutAlignment(LayoutAlignment.Center)
            .ViewModel(vm);
            Add(target);

            Point startPoint = new Point(0, 0);
            target.TouchEvent += (s, e) =>
            {

                if (e.Touch[0].State == TouchState.Down)
                {
                    startPoint = e.Touch[0].Position;
                }
                if (e.Touch[0].State == TouchState.Motion)
                {
                    var touchpos = e.Touch[0].ScreenPosition;
                    var viewpos = target.ScreenPosition;
                    vm.Text = $"ScreenPosition : {target.ScreenPosition} , CurrentScreenPosition :{target.CurrentScreenPosition}";
                    var dx = touchpos.X - viewpos.X - startPoint.X;
                    var dy = touchpos.Y - viewpos.Y - startPoint.Y;
                    target.X += dx;
                    target.Y += dy;
                }
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
