using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;
using System.Collections.Generic;

namespace MusicPlayerApp;

public class MainView : ContentView
{
    public MainView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.FillToParent;
        BackgroundColor = Color.FromHex("#FAFAFA");

        Body = CreateContent();
    }

    private View CreateContent()
    {
        return new Scaffold
        {
            AppBar = new AppBar
            {
                Title = "Music Player"
            },
            Content = new VStack
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                ItemAlignment = LayoutAlignment.Center,
                Spacing = 20,
                Children =
                {
                    new ImageView
                    {
                        ResourceUrl = "album_cover.png", // Placeholder for album cover image
                        Width = 300,
                        Height = 300,
                        FittingMode = FittingMode.ScaleToFill,
                        BackgroundColor = Color.LightGray,
                        CornerRadius = new CornerRadius(10),
                    },
                    new Label
                    {
                        Text = "Song Title Here",
                        FontWeight = FontWeight.Bold,
                        FontSize = 32,
                        TextColor = Color.Black,
                        HorizontalAlignment = TextAlignment.Center,
                    },
                    new Label
                    {
                        Text = "Artist Name",
                        FontWeight = FontWeight.Bold,
                        FontSize = 24,
                        TextColor = Color.DarkGray,
                        HorizontalAlignment = TextAlignment.Center,
                    },
                    new Slider(0, 100)
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        Value = 30, // Example progress value
                        TrackThickness = 8,
                        TrailColor = Color.FromHex("#6200EE"), // Purple
                        TrackColor = Color.LightGray,
                        Padding = new Thickness(40, 0, 40, 0),
                    },
                    new Grid
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        ColumnDefinitions = new List<GridColumnDefinition>
                        {
                            new GridColumnDefinition { Width = GridLength.Star },
                            new GridColumnDefinition { Width = GridLength.Star },
                            new GridColumnDefinition { Width = GridLength.Star },
                        },
                        ColumnSpacing = 10,
                        Children =
                        {
                            new IconButton
                            {
                                IconResourceUrl = "ic_skip_previous_white.png", // Placeholder for previous icon
                                IconWidth = 60,
                                IconHeight = 60,
                                IconMultipliedColor = Color.Black,
                                BackgroundColor = Color.Transparent,
                            },
                            new IconButton
                            {
                                IconResourceUrl = "ic_play_arrow_white.png", // Placeholder for play icon
                                IconWidth = 80,
                                IconHeight = 80,
                                IconMultipliedColor = Color.Black,
                                BackgroundColor = Color.Transparent,
                            },
                            new IconButton
                            {
                                IconResourceUrl = "ic_skip_next_white.png", // Placeholder for next icon
                                IconWidth = 60,
                                IconHeight = 60,
                                IconMultipliedColor = Color.Black,
                                BackgroundColor = Color.Transparent,
                            },
                        }
                    }
                }
            }
        };
    }
}