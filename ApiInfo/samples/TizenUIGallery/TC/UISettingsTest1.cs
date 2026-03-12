using Tizen.Applications;
using Tizen.UI;

namespace TizenUIGallery.TC
{
    public class UISettingsTest1 : ViewGroup, ITestCase
    {
        public UISettingsTest1()
        {
            var brokenImagePath = Application.Current.DirectoryInfo.Resource+"/broken.png";
            UISettings.SetBrokenImageUrl(brokenImagePath);

            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = Color.White;

            Add(new TextView
            {
                Text = "UISettings Test1",
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

            Add(new ImageView
            {
                Name = "View1",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 200,
                X = 0,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                ResourceUrl = "dotnet_bot.png",
                FittingMode = FittingMode.ScaleToFit,
            });

            Add(new ImageView
            {
                Name = "View2",
                ParentOriginX = 0.5f,
                ParentOriginY = 0f,
                Height = 200,
                Width = 200,
                Y = 400,
                X = 0,
                PositionUsesPivotPoint = true,
                PivotPointX = 0.5f,
                PivotPointY = 0f,
                ResourceUrl = "invalid.png",
                FittingMode = FittingMode.ScaleToFill
            });
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
