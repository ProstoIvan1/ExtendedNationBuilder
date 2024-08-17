using ExtendedNationBuilder.Entities;
using ExtendedNationBuilder.Managers.XmlEntities;
using System.Xml.Serialization;

namespace ExtendedNationBuilder.Managers.Readers
{
    public abstract class Reader<ObjT>
    {
        protected Reader(string nationId)
        {
            NationId = nationId;
        }

        protected string NationId { get; set; }

        private T Read<T>(string directory)
        {
            XmlSerializer serializer = new(typeof(T));
            T entity;

            using (StreamReader reader = new(directory + NationId + ".xml"))
            {
                var obj = serializer.Deserialize(reader);
                if (obj is T)
                    entity = (T)obj;
                else throw new Exception("Types error");
            }

            return entity;
        }

        protected T ReadEntity<T>(string directory) where T : IXmlEntity => Read<T>(directory);

        protected T ReadEntities<T>(string directory) where T : IEnumerable<IXmlEntity> => Read<T>(directory);

        public abstract ObjT Get();
    }
}
