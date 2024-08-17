using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Entities
{
    public record CityName(string Id, string Name) : IEntity;

    public class CityNames : IEntity, IEnumerable<CityName>
    {
        public string Id { get; }
        public string Name { get; set; }
        public CityTableType TableType { get; set; }
        public List<CityName> List { get; } = new();

        public string[] GetNames()
        {
            List<string> result = new();

            foreach(CityName name in List)
                result.Add(name.Name);

            return result.ToArray();
        }

        public CityNames(string id, string name, CityTableType tableType, IEnumerable<CityName> names)
        {
            Id = id.ClearId();
            Name = name.ClearName();
            List.AddRange(names);
            TableType = tableType;
        }

        public CityNames(string id, string name, CityTableType tableType, IEnumerable<string> names) :
            this(id, name, tableType, ConvertToCityNameList(names))
        { }

        public IEnumerator<CityName> GetEnumerator() => List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static List<CityName> ConvertToCityNameList(IEnumerable<string> names)
        {
            List<CityName> result = new();

            foreach (string name in names)
            {
                result.Add(new CityName(name.ClearId(), name.ClearName()));
            }

            return result;
        }
    }

    public class CityAndTownNames
    {
        public CityNames CityNames { get; set; }
        public CityNames TownNames { get; set; }

        public CityAndTownNames(string nationName, IEnumerable<string> cityNames, IEnumerable<string> townNames)
        {
            string cityNamesId = nationName + "CityNames";
            string cityNamesGroupName = nationName + " cities";

            string townNamesId = nationName + "TownNames";
            string townNamesGroupName = nationName + " towns";

            CityNames = new(cityNamesId, cityNamesGroupName, CityTableType.NTT_City, cityNames);
            TownNames = new(townNamesId, townNamesGroupName, CityTableType.NTT_Town, townNames);
        }

        public CityAndTownNames(CityNames cityNames, CityNames townNames)
        {
            CityNames = cityNames;
            TownNames = townNames;
        }
    }
}
