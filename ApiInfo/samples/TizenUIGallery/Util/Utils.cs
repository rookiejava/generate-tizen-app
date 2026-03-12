using Tizen.UI;

namespace TizenUIGallery.Util
{
    static class Common
    {

        public static string MakeAutomationId(this View view, string name)
        {
            return $"{view.GetType()}:{name}";
        }
    }
}
    