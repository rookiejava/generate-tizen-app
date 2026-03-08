using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;
using System.Collections.Generic;

namespace SmartHomeApp;

public class MainView : ContentView
{
    public MainView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.FillToParent;
        BackgroundColor = Color.FromHex("#F0F0F0");

        Body = CreateContent();
    }

    private View CreateContent()
    {
        var tile1 = CreateTile("거실 조명", "💡", true);
        var tile2 = CreateTile("에어컨", "❄️", false);
        var tile3 = CreateTile("공기청정기", "🍃", true);
        var tile4 = CreateTile("스마트 TV", "📺", false);

        return new Scaffold
        {
            AppBar = new AppBar 
            {
                Title = "Smart Home IoT",
            },
            Content = new VStack
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                Padding = new Thickness(30),
                Spacing = 40,
                Children = 
                {
                    // Top Section
                    new VStack 
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        ItemAlignment = LayoutAlignment.Start,
                        Spacing = 10,
                        Children = 
                        {
                            new Label 
                            { 
                                Text = "환영합니다, 대표님 👋", 
                                FontSize = 36, 
                                FontWeight = FontWeight.Bold,
                                TextColor = Color.Black 
                            },
                            new Label 
                            { 
                                Text = "현재 서울 날씨: 맑음 ☀️ / 온도: 24°C", 
                                FontSize = 24, 
                                TextColor = Color.DarkGray 
                            }
                        }
                    },
                    
                    // Bottom Section (Tiles)
                    new Grid
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        HeightResizePolicy = ResizePolicy.FillToParent,
                        ColumnDefinitions = new List<GridColumnDefinition>
                        {
                            new GridColumnDefinition { Width = GridLength.Star },
                            new GridColumnDefinition { Width = GridLength.Star }
                        },
                        RowDefinitions = new List<GridRowDefinition>
                        {
                            new GridRowDefinition { Height = GridLength.Star },
                            new GridRowDefinition { Height = GridLength.Star }
                        },
                        ColumnSpacing = 20,
                        RowSpacing = 20,
                        Children = 
                        {
                            tile1,
                            tile2,
                            tile3,
                            tile4
                        }
                    }
                }
            }
        };
    }

    private View CreateTile(string title, string iconText, bool initialState)
    {
        var tileSwitch = new Switch 
        { 
            IsSelected = initialState 
        };
        
        var tile = new VStack 
        {
            BackgroundColor = Color.White,
            CornerRadius = new CornerRadius(16),
            ItemAlignment = LayoutAlignment.Center,
            Padding = new Thickness(20),
            Spacing = 15,
            WidthResizePolicy = ResizePolicy.FillToParent,
            HeightResizePolicy = ResizePolicy.FillToParent,
            Children = 
            {
                new Label 
                {
                    Text = iconText,
                    FontSize = 50,
                    HorizontalAlignment = TextAlignment.Center
                },
                new Label 
                { 
                    Text = title, 
                    FontSize = 24, 
                    FontWeight = FontWeight.Bold,
                    HorizontalAlignment = TextAlignment.Center,
                    TextColor = Color.Black
                },
                tileSwitch
            }
        };
        return tile;
    }
}
