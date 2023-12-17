using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Albatross.Yokai_Watch.Games.YW1
{
    public static class YW1Support
    {
        public static Dictionary<string, string> AvailableLanguages = new Dictionary<string, string>()
        {
            { "English (GB)", "engb"},
            { "English (US)", "en"},
            { "Deutsch", "de"},
            { "Español", "es"},
            { "Français", "fr"},
            { "Italiano", "it"},
        };
    }
}
