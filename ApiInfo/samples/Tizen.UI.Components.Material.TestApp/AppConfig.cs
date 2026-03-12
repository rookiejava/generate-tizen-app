using Tizen.UI.Components;
using Tizen.UI.Internal;
using Tizen.UI.Components.Material;

namespace ComponentsTest
{
    public class AppConfig : MaterialConfig
    {
        public AppConfig()
        {
            IgnoreDpi = true;
        }

        public override UIVariables CreateVariables() => new UIVariables()
        {
            SystemFontSizeScaleEnabled = true,
            MinimumFontSizeScale = 0.75f,
            MaximumFontSizeScale = 3f
        };

#if USE_DUMMY_THEME_LOADER
        public override IThemeLoader CreateThemeLoader() => new DummyThemeLoader(ResourceManager.ResourceDirectory + "dummy_light", ResourceManager.ResourceDirectory + "dummy_dark");
#endif

#if USE_DUMMY_FONT_SCALE_LOADER
        public override IFontScaleLoader CreateFontScaleLoader() => DummyFontScaleLoader.Instance;
#endif
    }
}
