using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// ISpellAction is the Interface devoted to an Action implementation of a Spell
    /// Class who implements ISpellAction need to provide the action with ProcessAction method
    /// and define characters and Itemps affected by ProcessAction
    /// </summary>
    public interface ISpellAction
    {       
        public List<CharacterBase> AffectedCharacters { get; set; }
        public List<ItemBase> AffectedItems { get; set; }  
    }
}
