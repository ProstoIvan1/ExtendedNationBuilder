using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder
{
    public static class CharController
    {
        public static char[] InvalidNameChars { get; } = 
        "!@#$%^&*()+=[]{}\\|/;:'\",.?№~`\n".ToCharArray();

        public static char[] InvalidIdChars { get; } = InvalidNameChars.Append('-').Append(' ').ToArray();

        public static string ClearName(this string name)
        {
            var result = name;
            foreach (char c in name)
            {
                if (InvalidNameChars.Contains(c))
                    result = result.Replace(c.ToString(), null);
            }
            return result;
        }

        public static string ClearId(this string name)
        {
            var result = name;
            foreach (char c in name)
            {
                if (InvalidIdChars.Contains(c))
                    result = result.Replace(c.ToString(), null);
            }
            return result;
        }
    }
}
