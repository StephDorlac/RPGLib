using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// ItemBase entity define all specific items in world (ex: sword, legendary book, ...)
    /// </summary>
    public class ItemBase : IBaseEntity
    {      
        public string Name { get; set; }    
        public Guid ItemTypeId { get; set; }
        public Guid Id { get; set; }
        public float Weigth { get; set; } 
    }
}
