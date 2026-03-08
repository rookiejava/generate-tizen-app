using System;
using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;
using System.Collections.Generic;

namespace SettingsApp;

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
        var mainStack = new VStack
        {
            WidthResizePolicy = ResizePolicy.FillToParent,
            Spacing = 40,
            Padding = new Thickness(30),
            Children = 
            {
                CreateSectionTitle("🔔 알림 설정"),
                CreateSwitchRow("푸시 알림", true),
                CreateSwitchRow("이메일 알림", false),
                CreateSwitchRow("마케팅 수신 동의", true),
                
                CreateSectionTitle("💡 화면 밝기"),
                new Slider(0, 100)
                {
                    WidthResizePolicy = ResizePolicy.FillToParent,
                    Value = 70, // 초기 밝기
                    TrackThickness = 8,
                    TrailColor = Color.FromHex("#2196F3"),
                    TrackColor = Color.LightGray,
                    Padding = new Thickness(0, 20, 0, 20)
                },
                
                CreateSectionTitle("🎨 앱 테마"),
                CreateRadioRow("라이트 모드 (Light)", true),
                CreateRadioRow("다크 모드 (Dark)", false),
                CreateRadioRow("시스템 설정 따름", false)
            }
        };

        return new Scaffold
        {
            AppBar = new AppBar
            {
                Title = "환경설정"
            },
            Content = new ScrollView
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = mainStack
            }
        };
    }

    private View CreateSectionTitle(string title)
    {
        return new HStack
        {
            Padding = new Thickness(0, 20, 0, 10),
            WidthResizePolicy = ResizePolicy.FillToParent,
            Children = 
            {
                new Label
                {
                    Text = title,
                    FontSize = 26,
                    FontWeight = FontWeight.Bold,
                    TextColor = Color.FromHex("#1A1A1A")
                }
            }
        };
    }

    private View CreateSwitchRow(string title, bool initialState)
    {
        return new Grid
        {
            WidthResizePolicy = ResizePolicy.FillToParent,
            ColumnDefinitions = new List<GridColumnDefinition>
            {
                new GridColumnDefinition { Width = GridLength.Star },
                new GridColumnDefinition { Width = GridLength.Auto }
            },
            RowDefinitions = new List<GridRowDefinition>
            {
                new GridRowDefinition { Height = GridLength.Auto }
            },
            Children = 
            {
                new Label
                {
                    Text = title,
                    FontSize = 22,
                    TextColor = Color.Black,
                    VerticalAlignment = TextAlignment.Center
                },
                new Switch
                {
                    IsSelected = initialState
                }
            }
        };
    }

    private View CreateRadioRow(string title, bool isSelected)
    {
        return new Grid
        {
            WidthResizePolicy = ResizePolicy.FillToParent,
            ColumnDefinitions = new List<GridColumnDefinition>
            {
                new GridColumnDefinition { Width = GridLength.Auto },
                new GridColumnDefinition { Width = GridLength.Star }
            },
            RowDefinitions = new List<GridRowDefinition>
            {
                new GridRowDefinition { Height = GridLength.Auto }
            },
            ColumnSpacing = 15,
            Children = 
            {
                new RadioButton 
                { 
                    IsSelected = isSelected 
                },
                new Label
                {
                    Text = title,
                    FontSize = 22,
                    TextColor = Color.Black,
                    VerticalAlignment = TextAlignment.Center
                }
            }
        };
    }
}