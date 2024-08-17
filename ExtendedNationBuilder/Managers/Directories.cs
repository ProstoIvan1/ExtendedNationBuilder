using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Managers
{
    public class Directories
    {
        private static string modFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
            @"\AppData\LocalLow\CPromptGames\Millennia\Mods\EnbNations\";
        public static string CustomNations { get; } = modFolder + @"CustomNations\";
        public static string Strings { get; } = modFolder + @"Strings\";
        public static string Flags { get; } = modFolder + @"Flags\";
        public static string Names { get; } = modFolder + @"Names\";
    }
}
