using System;
using System.IO;
using System.Net.Http;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    class PaletteTest : ContentView, INavigationTransition, ITestCase
    {
        public PaletteTest() : base()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = MaterialColor.Background;

            Body = new Scrollable
            {
                Content = new VStack
                {
                    CreatePaletteView("PaletteTest/10by10tree.png").HorizontalLayoutAlignment(LayoutAlignment.Center),
                    CreatePaletteView("PaletteTest/3color.jpeg").HorizontalLayoutAlignment(LayoutAlignment.Center),
                    CreatePaletteView("PaletteTest/red2.jpg").HorizontalLayoutAlignment(LayoutAlignment.Center),
                    CreatePaletteView("PaletteTest/rock.jpg").HorizontalLayoutAlignment(LayoutAlignment.Center),
                    CreatePaletteView("http://i.imgur.com/H8mbyUM.jpg").HorizontalLayoutAlignment(LayoutAlignment.Center),
                }.Spacing(20).Margin(0, 50, 0, 200),
            };
        }

        View CreatePaletteView(string path)
        {
            return new Grid
            {
                BorderlineColor = Color.Black,
                BorderlineWidth = 1,
                BorderlineOffset = 1,
                RowDefinitions = { GridLength.Auto },
                ColumnDefinitions = { 400, 300 },

                Children =
                {
                    new Image(path)
                    {
                        FittingMode = FittingMode.ScaleToFill,
                        SynchronousLoading = path.StartsWith("http") ? false : true
                    }.Column(0),
                    new VStack
                    {
                    }.Column(1).Self(async layout =>
                    {
                        PixelBuffer buffer = null;
                        if (path.StartsWith("http"))
                        {
                            using (HttpClient httpClient = new HttpClient())
                            {
                                try
                                {
                                    using (Stream imageStream = await httpClient.GetStreamAsync(path))
                                    {
                                        buffer = ImageLoader.LoadImage(imageStream);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"FileDownload Error : {ex.Message}");
                                    return;
                                }
                              }
                        }
                        else
                        {
                            buffer = ImageLoader.LoadImageFromFile(path);
                        }
                        var palette = await Palette.GenerateAsync(buffer);
                        if (palette.Dominant != null)
                        {
                            layout.Add(AddColorText("Dominant", palette.Dominant).Expand());
                        }
                        if (palette.LightVibrant != null)
                        {
                            layout.Add(AddColorText("Light Vibrant", palette.LightVibrant).Expand());
                        }
                        if (palette.Vibrant != null)
                        {
                            layout.Add(AddColorText("Vibrant", palette.Vibrant).Expand());
                        }
                        if (palette.DarkVibrant != null)
                        {
                            layout.Add(AddColorText("Dark Vibrant", palette.DarkVibrant).Expand());
                        }
                        if (palette.LightMuted != null)
                        {
                            layout.Add(AddColorText("Light Muted", palette.LightMuted).Expand());
                        }
                        if (palette.Muted != null)
                        {
                            layout.Add(AddColorText("Muted", palette.Muted).Expand());
                        }
                        if (palette.DarkMuted != null)
                        {
                            layout.Add(AddColorText("Dark Muted", palette.DarkMuted).Expand());
                        }
                    })
                }

            };
        }

        View AddColorText(string name, Swatch color)
        {
            return new VStack
            {
                BorderlineColor = Color.Black,
                BorderlineWidth = 1,
                ItemAlignment = LayoutAlignment.Center,
                BackgroundColor = color.Color,
                Children =
                {
                    new Label(name) { FontSize = 30, TextColor = color.TitleTextColor, VerticalAlignment = TextAlignment.Center, HorizontalAlignment = TextAlignment.Center },
                    new Label($"RGB ({(int)(color.Color.R * 255)}, {(int)(color.Color.G * 255)}, {(int)(color.Color.B * 255)})")
                    { 
                        FontSize = 20,
                        TextColor = color.TitleTextColor,
                        VerticalAlignment = TextAlignment.Center,
                        HorizontalAlignment = TextAlignment.Center
                    },
                }
            }.Padding(10);
        }

        public void WillAppear(bool byPopNavigation)
        {
        }

        public void WillDisappear(bool byPopNavigation)
        {
        }

        public void DidAppear(bool byPopNavigation)
        {
        }

        public void DidDisappear(bool byPopNavigation)
        {
            if (byPopNavigation)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }
    }
}
