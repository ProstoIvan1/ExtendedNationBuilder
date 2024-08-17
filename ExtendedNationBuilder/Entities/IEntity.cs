using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Entities
{
    public interface IEntity
    {
        public string Id { get; }
        public string Name { get; }
    }
}
