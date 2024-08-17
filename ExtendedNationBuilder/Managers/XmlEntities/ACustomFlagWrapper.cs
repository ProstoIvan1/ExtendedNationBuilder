using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtendedNationBuilder.Managers.XmlEntities
{
    public class ACustomFlagWrapper : IXmlEntity
    {
        [XmlArrayItem("Flag")]
        public string[]? FlagNames { get; set; }
    }
}
