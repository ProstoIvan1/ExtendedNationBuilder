using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtendedNationBuilder.Managers.XmlEntities
{
    public class APlayerSetupState : IXmlEntity
    {
        public string? ConfigID { get; set; }
        public string? PlayerType { get; set; }
        public string? NationName { get; set; }
        public string? CityNameCollection { get; set; }
        public string? TownNameCollection { get; set; }
        public string? Flag { get; set; }
        public string? Personality { get; set; }

        [XmlArrayItem("StartupBonus")]
        public string[]? StartupBonuses { get; set; }

        public int? AIDifficulty { get; set; }
        public int? ColorProfileIndex { get; set; }
        public bool? IsSplinterNation { get; set; }
    }
}
