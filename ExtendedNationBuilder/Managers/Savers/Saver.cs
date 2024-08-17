using ExtendedNationBuilder.Managers.XmlEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtendedNationBuilder.Managers.Savers
{
    public abstract class Saver<ObjT>
    {
        protected Saver(string nationId)
        {
            NationId = nationId;
        }

        public string NationId { get; set; }

        private void CreateFile<T>(T entity, string directory)
        {
            Directory.CreateDirectory(directory);
            string path = directory + NationId + ".xml";

            if (!File.Exists(path))
                File.Create(path).Dispose();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(StreamWriter writer = new(path, false))
            {
                serializer.Serialize(writer, entity);
            }
        }

        protected void SaveEntity<T>(T entity, string directory) where T : IXmlEntity =>
            CreateFile(entity, directory);

        protected void SaveEntities<T>(T entities, string directory) where T : IEnumerable<IXmlEntity> =>
            CreateFile(entities, directory);

        public abstract void Save(ObjT obj);
    }
}
