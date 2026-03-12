using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class ClippingMode1 : Grid, ITestCase
    {
        public ClippingMode1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            RowDefinitions.Add(GridLength.Auto);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "ClippingMode Test",
                FontSize = 30,
            });
            
            var view1 = new ViewGroup
            {
                Name = "View1",
                DesiredHeight = 200,
                DesiredWidth = 200,
                BackgroundColor = Color.Yellow,
            }.Row(1).VerticalLayoutAlignment(LayoutAlignment.Center).HorizontalLayoutAlignment(LayoutAlignment.Center);

            Add(view1);

            var sub1 = new ViewGroup
            {
                ParentOriginX = 0.5f,
                ParentOriginY = 0.5f,
                PositionUsesPivotPoint = true,
                Height = 200,
                Width = 200,
                X = -100,
                Y = -100,
                BackgroundColor = Color.Green,
            };

            view1.Add(sub1);

            Add(new Button($"Change - {view1.ClippingMode}")
            {
                Name = "Btn1",
                Clicked = () =>
                {
                    var mode = view1.ClippingMode;
                    mode = (ClippingMode)(((int)mode + 1) % 3);
                    view1.ClippingMode = mode;
                    (this["Btn1"] as Button).Text = $"Change - {view1.ClippingMode}";
                }
            }.Row(2));

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
