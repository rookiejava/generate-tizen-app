using System;
using Tizen.UI;
using Tizen.UI.Layouts;
using Tizen.UI.Visuals;
using VisualObjectTest.Util;

namespace VisualObjectTest.TC
{
    class AddRemoveTest : Grid, ITestCase
    {
        public AddRemoveTest()
        {
            Name = "Outter";
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
                Text = "AddRemoveTest",
                FontSize = 30,
            });

            Add(new VStack
            {
                Name = "VStack",
                Children =
                {
                    new HStack
                    {
                        new Button("Add")
                        {
                            Clicked = () =>
                            {
                                var rnd = new Random();
                                var visual = new ColorVisual
                                {
                                    Width = 20,
                                    Height = 1,
                                    Color = new Color(rnd.Next(100, 255) / 255f, rnd.Next(100, 255) / 255f, rnd.Next(100, 255) / 255f),
                                    TransformFlags = TransformFlags.HeightProportional,
                                };
                                this["Target"].Add(visual);
                                LayoutVisuals(this["Target"]);
                            }
                        },
                        new Button("Remove")
                        {
                            Clicked = () =>
                            {
                                if (this["Target"].Visuals().Count > 0)
                                    this["Target"].Visuals().RemoveAt(this["Target"].Visuals().Count - 1);
                            }
                        },
                        new Button("<-------->")
                        {
                            Clicked = () =>
                            {
                                this["Target"].DesiredWidth += 10;
                            }
                        },
                        new Button(">-----<")
                        {
                            Clicked = () =>
                            {
                                this["Target"].DesiredWidth -= 10;
                            }
                        },
                        new Button("<--Height-->")
                        {
                            Clicked = () =>
                            {
                                this["Target"].DesiredHeight += 10;
                            }
                        },
                        new Button(">--Height--<")
                        {
                            Clicked = () =>
                            {
                                this["Target"].DesiredHeight -= 10;
                            }
                        }
                    }.Spacing(10).Padding(20),
                    new View
                    {
                        Name = "Target",
                        DesiredHeight = 400,
                        DesiredWidth = 600,
                        BorderlineColor = Color.Yellow,
                        BorderlineWidth = 1,
                        BorderlineOffset = 1,
                    }
                }
            }.Row(1).Spacing(10));

            this["Target"].Relayout += (s, e) =>
            {
                LayoutVisuals(this["Target"]);
            };

        }

        void LayoutVisuals(View view)
        {
            float left = 0;
            foreach (var visual in view.Visuals().ContentLayer)
            {
                visual.X = left;
                left += visual.Width;
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
