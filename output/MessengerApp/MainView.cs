using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace MessengerApp;

/// <summary>
/// 메인 화면 View - AI가 생성하는 핵심 코드
/// </summary>
public class MainView : ContentView
{
    public MainView()
    {
        WidthResizePolicy = ResizePolicy.FillToParent;
        HeightResizePolicy = ResizePolicy.FillToParent;

        Body = CreateContent();
    }

    private View CreateContent()
    {
        return new Scaffold
        {
            BackgroundColor = Color.FromHex("#F5F5F5"),
            AppBar = new AppBar
            {
                TitleContent = new HStack
                {
                    ItemAlignment = LayoutAlignment.Center,
                    Spacing = 12,
                    Padding = new Thickness(16, 0, 0, 0),
                    Children =
                    {
                        new View
                        {
                            Width = 40,
                            Height = 40,
                            CornerRadius = 20,
                            BackgroundColor = Color.FromHex("#2196F3"),
                        },
                        new TextView
                        {
                            Text = "개발팀장 호딱이",
                            FontSize = 20,
                            TextColor = Color.Black,
                            VerticalAlignment = TextAlignment.Center,
                        }
                    }
                }
            },
            Content = new Grid
            {
                RowDefinitions =
                {
                    new GridRowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new GridRowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                },
                Children =
                {
                    // 1. 채팅 메시지 리스트
                    new Scrollable
                    {
                        WidthResizePolicy = ResizePolicy.FillToParent,
                        HeightResizePolicy = ResizePolicy.FillToParent,
                        Content = new VStack
                        {
                            Spacing = 16,
                            Padding = new Thickness(16),
                            Children =
                            {
                                CreateMessageBubble("안녕하세요, 대표님!", false),
                                CreateMessageBubble("호딱이 팀장입니다. MCP 서버 연결을 축하드립니다! 🚀", false),
                                CreateMessageBubble("고마워 호딱아! 이제 본격적으로 앱을 만들어보자.", true),
                                CreateMessageBubble("넵! 메신저 UI는 이렇게 구성해봤습니다. 마음에 드시나요?", false),
                            }
                        }
                    }.Row(0),

                    // 2. 하단 입력창 영역
                    new HStack
                    {
                        BackgroundColor = Color.White,
                        Height = 70,
                        Padding = new Thickness(12, 8),
                        Spacing = 8,
                        ItemAlignment = LayoutAlignment.Center,
                        Children =
                        {
                            new TextField
                            {
                                WidthResizePolicy = ResizePolicy.FillToParent,
                                PlaceholderText = "메시지를 입력하세요...",
                                VerticalAlignment = TextAlignment.Center,
                                BackgroundColor = Color.FromHex("#EEEEEE"),
                                CornerRadius = 8,
                            },
                            new Button
                            {
                                Text = "전송",
                                Width = 80,
                                Height = 48,
                                CornerRadius = 8,
                                BackgroundColor = Color.FromHex("#2196F3"),
                                TextColor = Color.White
                            }
                        }
                    }.Row(1)
                }
            }
        };
    }

    private View CreateMessageBubble(string text, bool isMine)
    {
        var container = new HStack
        {
            WidthResizePolicy = ResizePolicy.FillToParent,
        };
        
        var bubble = new VStack
        {
            BackgroundColor = isMine ? Color.FromHex("#DCF8C6") : Color.White,
            CornerRadius = 12,
            Padding = new Thickness(12, 8),
            Children =
            {
                new TextView
                {
                    Text = text,
                    FontSize = 16,
                    TextColor = Color.Black,
                    IsMultiline = true,
                }
            }
        };

        if (isMine)
        {
            container.Children.Add(new View { WidthResizePolicy = ResizePolicy.FillToParent });
            container.Children.Add(bubble);
        }
        else
        {
            container.Children.Add(bubble);
            container.Children.Add(new View { WidthResizePolicy = ResizePolicy.FillToParent });
        }

        return container;
    }
}
