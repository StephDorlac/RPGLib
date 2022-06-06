using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// Ability entity define an ability for a character (ex: walking, two hands fighting,...)
    /// </summary>
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AbilityType Type { get; set; }

        public Ability(int id, string name, string description, AbilityType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

    }
}
