using ExtendedNationBuilder.Entities;
using ExtendedNationBuilder.Managers.XmlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Managers.Savers
{
    public class NationSaver : Saver<Nation>
    {
        public string FlagPath { get; set; }
        public string SplinterFlagPath { get; set; }
        public NationSaver(string flagPath, string splinterFlagPath) : base(string.Empty) 
        { 
            FlagPath = flagPath;
            SplinterFlagPath = splinterFlagPath;            
        }

        private void SaveCustomNation(Nation nation)
        {
            CityNames cityNames = nation.CityAndTownNames.CityNames;
            CityNames townNames = nation.CityAndTownNames.TownNames;

            APlayerSetupState state = new()
            {
                ConfigID = nation.Id,
                PlayerType = nation.PlayerType.Id,
                NationName = nation.Name,
                CityNameCollection = cityNames.Id,
                TownNameCollection = townNames.Id,
                Flag = nation.Flag.Id,
                Personality = nation.Personality.Id,
                StartupBonuses = [nation.StartingBonus.Id],
                AIDifficulty = nation.Difficulty,
                ColorProfileIndex = nation.ColorProfileIndex,
                IsSplinterNation = nation.IsRevolutionary,
            };

            SaveEntity(state, Directories.CustomNations);
        }

        private void SaveStrings(Nation nation)
        {
            CityNames cityNames = nation.CityAndTownNames.CityNames;
            CityNames townNames = nation.CityAndTownNames.TownNames;

            List<Entry> entries = new()
            {
                new Entry("NationName", nation.Id, nation.Name),
                new Entry("NationNameSplinter", nation.Id, nation.SplinterName),
                new Entry("UI-MainMenu-NationBuilder", cityNames.Id, cityNames.Name),
                new Entry("UI-MainMenu-NationBuilder", townNames.Id, townNames.Name),
            };

            foreach (var name in cityNames)
            {
                entries.Add(new Entry(cityNames.Id, name.Id, name.Name));
            }

            foreach (var name in townNames)
            {
                entries.Add(new Entry(townNames.Id, name.Id, name.Name));
            }

            SaveEntity(new GameStrings() { Entries = entries.ToArray() }, Directories.Strings);
        }

        public override void Save(Nation nation)
        {
            NationId = nation.Id;

            Directory.CreateDirectory(Directories.CustomNations);
            Directory.CreateDirectory(Directories.Strings);

            new FlagSaver(nation.Id, FlagPath, SplinterFlagPath).Save(nation.Flag);
            new CityAndTownNamesSaver(nation.Id).Save(nation.CityAndTownNames);

            SaveCustomNation(nation);
            SaveStrings(nation);
        }
    }
}
