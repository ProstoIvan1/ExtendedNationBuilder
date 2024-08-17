using System.Xml.Serialization;

namespace ExtendedNationBuilder.Managers.XmlEntities
{
    public class GameStrings : IXmlEntity
    {
        [XmlElement("Entry")]
        public Entry[]? Entries { get; set; }

        public string GetValue(string prefix, string key)
        {
            string? value = null;

            if (Entries != null)
            {
                foreach(var entry in Entries)
                    if (entry.Key == prefix + "-" + key) value = entry.Value!;
            }

            if (value == null)
                throw new Exception("Not found");

            return value;
        }
    }
}
