using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Items
{
    public class ItemBase
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public ItemType Type { get; set; }

        public ItemBase(int id, string name, ItemType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

    }
}
