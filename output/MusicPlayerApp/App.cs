using Tizen.Applications;
using Tizen.UI;
using Tizen.UI.Components.Material;

namespace MusicPlayerApp;

public class App : MaterialApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();

        var window = Window.Default;
        window.Title = "MusicPlayerApp";

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
