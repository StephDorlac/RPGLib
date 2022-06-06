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
    public class ItemTypeBase : IBaseEntity
    {        
        public String Name { get; set; }
        public Guid Id { get ; set; }

    }
}
