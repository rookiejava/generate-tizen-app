using Tizen.UI;
using Tizen.UI.Internal;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class WindowFrameRenderedCallbackTest : Grid, ITestCase
    {
        int count = 0;
        int rendered = 0;
        bool isExit = false;
        TextView label;

        public WindowFrameRenderedCallbackTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;
            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            label = new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                IsMultiline = true,
                IsMarkupEnabled = true,
                Text = $"TextView Test {count} \n new line" ,
                FontSize = 30,
            }.Row(1);

            Add(label);
            UIApplication.Current.PostToUI(UpdateText);
            Window.Default.AddFrameRenderedCallback(OnFrameRendered, 0);
        }

        void OnFrameRendered(int id)
        {
            rendered++;
            if (!isExit)
                Window.Default.AddFrameRenderedCallback(OnFrameRendered, 0);
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            isExit = true;
            Dispose();
        }
        void UpdateText()
        {
            if (IsDisposed) return;
            Log.Info($"UpdateText... {count}");
            label.Text = $"TextView Test {++count} rendered : {rendered} \n new line";
            if (!isExit)
                UIApplication.Current.PostToUI(UpdateText);
        }
    }
}
