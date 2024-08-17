using ExtendedNationBuilder.Entities;
using ExtendedNationBuilder.Managers.XmlEntities;
using System.Xml.Serialization;

namespace ExtendedNationBuilder.Managers.Readers
{
    public class CityAndTownNamesReader : Reader<CityAndTownNames>
    {
        public CityAndTownNamesReader(string nationId) : base(nationId) { }

        private CityNames ConvertToCityNames(AEntityNameTableState tableState, GameStrings gameStrings)
        {
            string id = tableState.ID!;
            string name = gameStrings.GetValue("UI-MainMenu-NationBuilder", id);
            CityTableType tableType = CityTypeManager.ConvertFromStr(tableState.TableType!);
            List<CityName> nameCollection = new();

            foreach (var uglyCityId in tableState.Names!)
            {
                string cityId = uglyCityId.Replace("$", null);
                string cityName = gameStrings.GetValue(id, cityId)!;
                nameCollection.Add(new CityName(cityId, cityName));
            }

            return new CityNames(id, name, tableType, nameCollection);
        }

        private CityNames? GetTypedNamesFromList(List<CityNames> list, CityTableType type)
        {
            foreach (var cityName in list)
            {
                if (cityName.TableType == type) return cityName;
            }

            throw new Exception("Not found");
        }

        public override CityAndTownNames Get()
        {
            AEntityNameTableState[] tableStates = ReadEntities<AEntityNameTableState[]>(Directories.Names);
            GameStrings gameStrings = ReadEntity<GameStrings>(Directories.Strings);

            List<CityNames> listOfCityNames = new();

            foreach (var tableState in tableStates)
            {
                listOfCityNames.Add(ConvertToCityNames(tableState, gameStrings));
            }

            CityNames cityNames = GetTypedNamesFromList(listOfCityNames, CityTableType.NTT_City)!;
            CityNames townNames = GetTypedNamesFromList(listOfCityNames, CityTableType.NTT_Town)!;

            return new CityAndTownNames(cityNames, townNames);
        }
    }
}
