using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Components.Material;

namespace {{APP_NAMESPACE}};

public class App : MaterialApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();

        var window = Window.Default;
        window.Title = "{{APP_LABEL}}";

        // === AI 생성 코드 시작 ===
        var mainView = new MainView();
        // === AI 생성 코드 끝 ===

        window.DefaultLayer.Children.Add(mainView);
    }

    static void Main(string[] args)
    {
        var app = new App();
        app.Run(args);
    }
}
