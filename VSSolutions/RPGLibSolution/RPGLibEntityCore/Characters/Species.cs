using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// Species is the entity to define the species of characters (ex: humain, elve, ...)
    /// </summary>
    public class Species
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Ability>? Abilities { get; set; }

        public Species(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
