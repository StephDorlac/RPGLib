using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Abilities
{
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
