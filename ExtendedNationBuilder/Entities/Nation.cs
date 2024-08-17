using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Entities
{
    public class Nation : IEntity
    {
        public string Id { get; }
        public string Name { get; set; }
        public string SplinterName { get; set; }
        public CityAndTownNames CityAndTownNames { get; set; }
        public Flag Flag { get; set; }
        public List<StartingBonus> StartingBonuses { get; } = new();
        public StartingBonus StartingBonus => StartingBonuses[0];
        public Personality Personality { get; set; } = AllPersonalities.Default;
        public PlayerType PlayerType { get; set; } = AllPlayerTypes.Default;
        public int Difficulty { get; set; } = 0;
        public int ColorProfileIndex { get; set; } = -1;
        public bool IsRevolutionary { get; set; } = false;


        public Nation(string id, string name, string splinterName, CityAndTownNames cityAndTownNames, Flag flag, StartingBonus startingBonus)
        {
            Id = id.ClearId();
            SplinterName = splinterName.ClearName();
            Name = name.ClearName();
            CityAndTownNames = cityAndTownNames;
            Flag = flag;
            StartingBonuses.Add(startingBonus);
        }

        public Nation(string name, string splinterName, CityAndTownNames cityAndTownNames, Flag flag, StartingBonus startingBonus) :
            this(name + "Nation", name, splinterName, cityAndTownNames, flag, startingBonus)
        { }

        public override string ToString() => Name;
    }
}
