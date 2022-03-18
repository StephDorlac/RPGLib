using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Abilities
{
    /// <summary>
    /// AbilityType is the entity to define a specific type of ability (ex : Movement)
    /// </summary>
    public class AbilityType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AbilityType(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
