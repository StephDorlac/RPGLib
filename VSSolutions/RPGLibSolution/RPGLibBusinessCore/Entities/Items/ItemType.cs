using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Items
{
    public class ItemType
    {
        public int Id { get; set; } 
        public String Name { get; set; }

        public ItemType(int id, String name)
        {
            Id = id;
            Name = name;
        }

    }
}
