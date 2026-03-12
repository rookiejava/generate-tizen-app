using System;
using System.Collections.Generic;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class SignalMemoryTest : Grid, ITestCase
    {
        HashSet<View> clickedView = new();
        const int MaxViewCount = 5000;
        TextView clickedCountLabel;
        public SignalMemoryTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "SignalMemoryTest",
                FontSize = 30,
            });
            Add(new VStack
            {
                new HStack
                {
                    new TextView { Text = "How many memory used when signal is connected? Clicked View :", FontSize = 20 },
                    new TextView { Name = "ClickedCount", FontSize = 20}.Self(out clickedCountLabel),
                },
                new AbsoluteLayout().Expand().Self(abs =>
                {
                    int sqrtSize = (int)MathF.Sqrt(MaxViewCount);
                    for (int i = 0; i < sqrtSize; i++)
                    {
                        for (int j = 0; j < sqrtSize; j++)
                        {
                            var view = new View
                            {
                                DesiredHeight = 10,
                                DesiredWidth = 10,
                                BackgroundColor = new Color(Random.Shared.Next(256) / 255f, Random.Shared.Next(256) / 255f, Random.Shared.Next(256) / 255f, 1f),
                            }.LayoutBounds(i * 10, j * 10, -1, -1).LayoutFlags(AbsoluteLayoutFlags.None);
                            view.TouchEvent += View_TouchEvent;
                            abs.Add(view);
                        }
                    }
                }),
            }.Row(1));
        }

        void View_TouchEvent(object sender, TouchEventArgs e)
        {
            if (clickedView.Add((View)sender))
            {
                clickedCountLabel.Text = $"{clickedView.Count}";
            }
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
