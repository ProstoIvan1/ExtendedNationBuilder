using System.Xml;

namespace ExtendedNationBuilder.Entities
{
    public class Flag
    {
        //rev - revolutionary

        public string Id { get; }
        public string RevId { get; }

        public Flag(string nationName)
        {
            Id = (nationName + "Flag").ClearId();
            RevId = Id + "_SPLINTER";
        }

        public Flag(string flagId, string revFlagId)
        {
            Id = flagId.ClearId();
            RevId = revFlagId.ClearId();
        }
    }
}
