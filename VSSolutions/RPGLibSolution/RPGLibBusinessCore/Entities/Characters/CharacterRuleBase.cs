using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Characters
{
    /// <summary>
    /// CharacterRuleBase
    /// To implement some Rules when action is done on character (like Add for example), 
    /// inherit from CharacterRuleBase and implement Business check in CheckIfValid method.
    /// Please don't change this abstract class, don't add Business rules here !
    /// </summary>    
    /// <example>See CharacterRuleNameNotNullOrEmpty for a quick and easy implementation</example>
    internal abstract class CharacterRuleBase
    {

        public bool IsValid { get; set; }
        public CharacterBase Character { get; set; }

        public CharacterRuleBase(CharacterBase character)
        {
            this.Character = character;
        }

        public abstract void CheckIfValid();

    }
}
