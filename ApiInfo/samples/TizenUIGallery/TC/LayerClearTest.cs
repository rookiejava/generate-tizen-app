using TizenUIGallery.Util;
using System;
using Tizen.UI;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    class LayerClearTest : Grid, ITestCase
    {
        Layer _layer;
        public LayerClearTest()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            _layer = new Layer();

            Window.Default.Add(_layer);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Layer Clear Test",
                FontSize = 30,
            });

            Add(new VStack
            {
                new HStack
                {
                    new Button("Add")
                    {
                        Clicked = () =>
                        {
                            var rnd = new Random();
                            _layer.Add(new View
                            {
                                Width = 200,
                                Height = 200,
                                Y = 500,
                                X = _layer.Children.Count * 200,
                                BackgroundColor = new Color(rnd.Next(100, 255) / 255f, rnd.Next(100, 255) / 255f, rnd.Next(100, 255) / 255f)
                            });
                        }
                    },
                    new Button("Clear")
                    {
                        Clicked = () =>
                        {
                            _layer.Children.Clear();
                        }
                    }
                }.Spacing(10)
            }.Row(1).Spacing(10));

        }

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            _layer.Dispose();
            Dispose();
        }
    }
}
