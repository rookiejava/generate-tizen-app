using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class TextViewTest2 : Grid, ITestCase
    {
        int count = 0;
        TextView label;

        public TextViewTest2()
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
        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
        void UpdateText()
        {
            if (IsDisposed) return;
            Log.Info($"UpdateText... {count}");
            label.Text = $"TextView Test {++count} \n new line";
            UIApplication.Current.PostToUI(UpdateText);
        }
    }
}
