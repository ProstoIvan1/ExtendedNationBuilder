using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Entities
{
    public enum CityTableType
    {
        NTT_City, NTT_Town
    }

    public static class CityTypeManager
    {
        public static CityTableType ConvertFromStr(string str)
        {
            switch (str)
            {
                case "NTT_City": return CityTableType.NTT_City;
                case "NTT_Town": return CityTableType.NTT_Town;
            }

            throw new NotImplementedException();
        }
    }
}
