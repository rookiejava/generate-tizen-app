using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace {{APP_NAMESPACE}};

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
        // {{MAIN_VIEW_CONTENT}}
        return new Scaffold
        {
            AppBar = new AppBar
            {
                Title = "Tizen App",
            },
            Content = new VStack
            {
                new TextView
                {
                    Text = "Hello, Material Scaffold!",
                    FontSize = 24,
                    HorizontalAlignment = TextAlignment.Center,
                },
            }
        };
    }
}
