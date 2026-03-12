using Tizen.UI.Components;
using Tizen.UI.Internal;
using Tizen.UI.Components.Material;

namespace HelloTizenUI
{
    public class AppConfig : MaterialConfig
    {
        public AppConfig()
        {
            //IgnoreDpi = true;
        }

        public override UIVariables CreateVariables() => new UIVariables()
        {
            SystemFontSizeScaleEnabled = true,
            MinimumFontSizeScale = 0.75f,
            MaximumFontSizeScale = 3f
        };
    }
}
