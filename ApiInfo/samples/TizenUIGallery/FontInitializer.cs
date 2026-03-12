using System;
using System.Collections.Generic;
using Tizen.System;
using Tizen.UI;

namespace TizenUIGallery
{
    public class FontInitializer
    {
        public static void Initialize()
        {
            FontconfigInitialize();
            FreetypeInitialize();
        }

        public static void FontconfigInitialize(bool syncCreation = true, List<string> fontFamilyList = null, List<string> extraFamilyList = null, string localeFamily = null)
        {
            Console.WriteLine("Fontconfig Initialize Start");
            if (fontFamilyList == null)
            {
                Console.WriteLine("Use default font family list");
                fontFamilyList = defaultFontFamilyList;
            }
            if (extraFamilyList == null)
            {
                Console.WriteLine("Use default extra family list");
                extraFamilyList = defaultExtraFamilyList;
            }
            if (localeFamily == null)
            {
                Console.WriteLine("Use default locale information");
                localeFamily = LocaleFamily;
            }
            Console.WriteLine($"Font PreCache [syncCreation :{Convert.ToInt32(syncCreation)}]");
            FontClient.PreCache(fontFamilyList, extraFamilyList, localeFamily, true, syncCreation);
        }

        public static void FreetypeInitialize(bool syncCreation = true, List<string> fontPathList = null, List<string> memoryFontPathList = null)
        {
            Console.WriteLine("Freetype Initialize Start");

            if (fontPathList == null)
            {
                fontPathList = defaultFontPathList;
            }
            string localeFamily = LocaleFamily;
            if (localeFamily != null)
            {
                foreach (string weight in weightList)
                {
                    string updatedLocaleFont = string.Format(localeFontNameFormat, localeFamily, weight);
                    defaultFontPathList.Add(updatedLocaleFont);
                    Console.WriteLine($"Locale Font : {updatedLocaleFont}");
                }
            }

            Console.WriteLine($"Font PreLoad [syncCreation :{Convert.ToInt32(syncCreation)}]");
            FontClient.FontPreLoad(fontPathList, memoryFontPathList, true, syncCreation);
        }

        private static string FindLocaleFontFamily()
        {
            string localeLanguage = SystemSettings.LocaleLanguage;

            if (localeLanguageMap.ContainsKey(localeLanguage))
            {
                Console.WriteLine($"Find locale font family [{localeLanguage}], [{localeLanguageMap[localeLanguage]}]");
                return localeLanguageMap[localeLanguage];
            }
            return null;
        }

        private static string LocaleFamily => FindLocaleFontFamily();

        private const string systemFontPath = "/usr/share/fonts/";
        private static readonly List<string> defaultFontFamilyList = new List<string> { "SamsungOneUI", "SamsungOneUI_200", "SamsungOneUI_300", "SamsungOneUI_400", "SamsungOneUI_450", "SamsungOneUI_500", "SamsungOneUI_600", "SamsungOneUI_700" };
        private static readonly List<string> defaultExtraFamilyList = new List<string> { "SamsungOneFallbackVD" };
        private static readonly List<string> weightList = new List<string> { "200", "300", "400", "500", "600", "700" };
        private const string localeFontNameFormat = systemFontPath + "{0}" + "-{1}.ttf";

        private static readonly List<string> defaultFontPathList = new List<string>
        {
            systemFontPath+"SamsungOneUI-200.ttf",
            systemFontPath+"SamsungOneUI-300.ttf",
            systemFontPath+"SamsungOneUI-400.ttf",
            systemFontPath+"SamsungOneUI-500.ttf",
            systemFontPath+"SamsungOneUI-600.ttf",
            systemFontPath+"SamsungOneUI-700.ttf",
        };

        private static readonly Dictionary<string, string> localeLanguageMap = new Dictionary<string, string>()
        {
            {"ko_KR", "SamsungOneUIKorean" },
            {"zh_CN", "SamsungOneUISCN" },
            {"zh_HK", "SamsungOneUITCN" },
            {"zh_TW", "SamsungOneUITCN" },
            {"ja_JP", "SamsungOneUIJP" }
        };
    }
}
