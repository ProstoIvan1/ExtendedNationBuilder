using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilderAvalonia.ViewModels
{
    public class CityNameTableRecord(string name = "")
    {
        public string Name { get; set; } = name;
    }

    public static class ConventNamesEnum
    {
        public static IEnumerable<string> ToStrEnum(this IEnumerable<CityNameTableRecord> names)
        {
            var nameList = new List<string>();

            foreach (var name in names)
            {
                nameList.Add(name.Name);
            }

            return nameList.AsEnumerable();
        }
    }
}
