using System.Xml.Serialization;
using System.Xml;

namespace ExtendedNationBuilder.Managers.XmlEntities
{
    public class Entry : IXmlEntity
    {
        public Entry() { }

        public Entry(string prefix, string key, string value)
        {
            Key = prefix + "-" + key;
            Value = value;
        }

        public string? Key { get; set; }

        [XmlIgnore]
        public string? Value
        {
            get => ValueCData?.Value;
            set => ValueCData!.Value = value;
        }

        [XmlElement("Value")]
        public XmlCDataSection? ValueCData { get; set; } = new XmlDocument().CreateCDataSection(null);
    }
}
