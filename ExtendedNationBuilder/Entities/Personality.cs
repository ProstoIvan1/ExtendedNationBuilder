using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Entities
{
    public record Personality : IEntity
    {
        private string id;
        public string Id
        {
            get => "AIP_" + id;
        }

        public string Name { get; }

        public Personality(string id, string name)
        {
            this.id = id.ClearId();
            Name = name;
        }
    };

    public static class AllPersonalities
    {
        public static Personality[] Get { get; } =
        [
            new Personality("Bully", "Default"),
        ];

        public static Personality Default => Get[0];
    }

}
