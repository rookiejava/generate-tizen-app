using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Layouts;

namespace {{APP_NAMESPACE}};

/// <summary>
/// 메인 화면 View - AI가 생성하는 핵심 코드
/// </summary>
public class MainView : ContentView
{
    public MainView()
    {
        DesiredWidth = Window.Default.CurrentSize.Width;
        DesiredHeight = Window.Default.CurrentSize.Height;

        Body = CreateContent();
    }

    private View CreateContent()
    {
        // {{MAIN_VIEW_CONTENT}}
        return new VStack
        {
            new TextView
            {
                Text = "Hello, Tizen!",
                FontSize = 24,
                HorizontalAlignment = TextAlignment.Center,
            },
        };
    }
}
