using RPGLibBusinessCore.Entities.Characters;
using RPGLibBusinessCore.Entities.Common;
using RPGLibBusinessCore.Entities.Items;
using RPGLibBusinessCore.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Spell
{
    /// <summary>
    /// ISpellAction is the Interface devoted to an Action implementation of a Spell
    /// Class who implements ISpellAction need to provide the action with ProcessAction method
    /// and define characters and Itemps affected by ProcessAction
    /// </summary>
    public interface ISpellAction
    {
        public CommonResult ProcessAction();        
        public List<CharacterBase> AffectedCharacters { get; set; }
        public List<ItemBase> AffectedItems { get; set; }  
    }
}
