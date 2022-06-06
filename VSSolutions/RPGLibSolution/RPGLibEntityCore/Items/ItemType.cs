using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// ItemType entity define the type of an item (ex: furniture, food, weapon...) 
    /// </summary>
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
