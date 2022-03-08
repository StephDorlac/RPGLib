using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Characters
{
    public class Species
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public Species(int id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
