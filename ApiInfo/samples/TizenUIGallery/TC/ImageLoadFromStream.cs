using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class ImageLoadFromStream : Grid, ITestCase
    {
        public ImageLoadFromStream()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ImageLoadFromStream",
                FontSize = 30,
            });
            Add(new AbsoluteLayout
            {
                Name = "AbsoluteLayout"
            }.Row(1));
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourcePath = assemblyName + ".Resource." + "image2.jpg";
            using var pixelBuffer = ImageLoader.LoadImage(assembly.GetManifestResourceStream(resourcePath));
            using var pixelData = pixelBuffer.Export();
            using var imgurl = pixelData.GenerateUrl();
            (this["AbsoluteLayout"] as AbsoluteLayout).Add(new ImageView
            {
                SynchronousLoading = true,
                ResourceUrl = imgurl.ToString()
            }.LayoutBounds(0.5f, 0.5f, -1, -1).LayoutFlags(AbsoluteLayoutFlags.PositionProportional));
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
