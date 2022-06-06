using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// CharacterClass is the entity to define a specific class for a character
    /// </summary>
    /// <remarks> 
    /// A CharacterClass can inherit from CharacterClass to expose some complexity subsystem
    /// ex : Blood Sorcerer can inherit from Sorcerer (and get Sorcerer abilities + blood)
    /// </remarks>
    public class CharacterClass
    {     

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ability>? Abilities { get; set; }

        public CharacterClass(int iD, string name, string description, List<Ability>? abilities)
        {
            ID = iD;
            Name = name;
            Description = description;
            Abilities = abilities;
        }
    }
}
