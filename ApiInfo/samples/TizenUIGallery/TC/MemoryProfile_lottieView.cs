using Tizen.UI;

namespace TizenUIGallery.TC
{
    public class MemoryProfile_lottieView : ViewGroup, ITestCase
    {
        public MemoryProfile_lottieView()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "LottieAnimationView Test1",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 100,
                FontSize = 60,
            });

            Add(new TextView
            {
                Name = "Log",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                Y = 110,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 80,
                FontSize = 20,
            });

            Add(new TextView
            {
                Name = "Log2",
                BackgroundColor = Color.Yellow,
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                PivotPointY = 0f,
                Y = 190,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = TextAlignment.Center,
                VerticalAlignment = TextAlignment.Center,
                WidthResizePolicy = ResizePolicy.FillToParent,
                Height = 80,
                FontSize = 20,
            });


            Add(new LottieAnimationView
            {
                Name = "View1",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 400,
                Width = 400,
                Y = 250,
                X = 0,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                BackgroundColor = Color.Yellow,
                ResourceUrl = "cycle_animation.json",
            });

            (this["View1"] as LottieAnimationView).Loop = true;
            (this["View1"] as LottieAnimationView).StopBehavior = AnimationStopBehavior.CurrentFrame;

            (this["View1"] as LottieAnimationView).Play();


            var timer = Timer.Repeat(100, () =>
            {
                (this["Log"] as TextView).Text = $"CurrentFrame :{(this["View1"] as LottieAnimationView).CurrentFrame} - state : {(this["View1"] as LottieAnimationView).PlayState}";
                (this["Log2"] as TextView).Text = $"StopBehavior {(this["View1"] as LottieAnimationView).StopBehavior} RepeatCount : {(this["View1"] as LottieAnimationView).RepeatCount}[{(this["View1"] as LottieAnimationView).RepeatMode}]";
                return true;
            });

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
