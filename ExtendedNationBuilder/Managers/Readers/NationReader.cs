using ExtendedNationBuilder.Entities;
using ExtendedNationBuilder.Managers.XmlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Managers.Readers
{
    public class NationReader : Reader<Nation>
    {
        public NationReader(string nationId) : base(nationId) { }

        public override Nation Get()
        {
            APlayerSetupState state = ReadEntity<APlayerSetupState>(Directories.CustomNations);
            GameStrings gameStrings = ReadEntity<GameStrings>(Directories.Strings);

            string id = NationId;
            string name = gameStrings.GetValue("NationName", id);
            string splinterName = gameStrings.GetValue("NationNameSplinter", id);
            StartingBonus startingBonus = AllStartingBonuses.GetValue(state.StartupBonuses![0]);
            Flag flag = new(state.Flag!, state.Flag! + "_SPLINTER");
            CityAndTownNames cityAndTownNames = new CityAndTownNamesReader(NationId).Get();

            return new Nation(id, name, splinterName, cityAndTownNames, flag, startingBonus);
        }

        public static List<Nation> GetAll()
        {
            List<Nation> result = new();

            DirectoryInfo customNations = new DirectoryInfo(Directories.CustomNations);
            if (customNations.Exists)
            {
                foreach(var file in customNations.GetFiles())
                {
                    if(file.Extension == ".xml")
                    {
                        string nationId = file.Name.Replace(".xml", null);
                        NationReader reader = new(nationId);
                        result.Add(reader.Get());
                    }
                }
            }


            return result;
        }
    }
}
