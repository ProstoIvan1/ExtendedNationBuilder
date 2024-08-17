using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Entities
{
    public record PlayerType : IEntity
    {
        private string id;
        public string Id
        {
            get => "PT_" + id;
        }
        public string Name { get; }

        public PlayerType(string id, string name)
        {
            this.id = id.ClearId();
            Name = name;
        }

    }

    public class AllPlayerTypes
    {
        public static PlayerType[] Get { get; } =
        [
            new PlayerType("Human", "Human"),
        ];

        public static PlayerType Default => Get[0];
    }
}
