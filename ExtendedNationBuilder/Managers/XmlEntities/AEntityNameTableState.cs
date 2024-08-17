using System.Xml.Serialization;

namespace ExtendedNationBuilder.Managers.XmlEntities
{
    public class AEntityNameTableState : IXmlEntity
    {
        public string? ID { get; set; }
        public string? TableType { get; set; }

        [XmlArrayItem("Name")]
        public string[]? Names { get; set; }
    }
}
