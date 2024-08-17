using ExtendedNationBuilder.Entities;
using ExtendedNationBuilder.Managers.XmlEntities;

namespace ExtendedNationBuilder.Managers.Savers
{
    public class CityAndTownNamesSaver : Saver<CityAndTownNames>
    {
        public CityAndTownNamesSaver(string nationId) : base(nationId) { }

        private string[] GetAllIdsWithDollars(CityNames cityNames)
        {
            List<string> result = new List<string>();

            foreach (var cityName in cityNames)
            {
                result.Add("$$" + cityName.Id + "$$");
            }

            return result.ToArray();
        }

        private AEntityNameTableState ToTableState(CityNames cityNames)
        {
            return new AEntityNameTableState()
            {
                ID = cityNames.Id,
                TableType = cityNames.TableType.ToString(),
                Names = GetAllIdsWithDollars(cityNames),
            };
        }

        public override void Save(CityAndTownNames cityAndTownNames)
        {
            Directory.CreateDirectory(Directories.Names);

            AEntityNameTableState[] tableStates =
            [
                ToTableState(cityAndTownNames.CityNames),
                ToTableState(cityAndTownNames.TownNames),
            ];

            SaveEntities(tableStates, Directories.Names);
        }
    }
}
