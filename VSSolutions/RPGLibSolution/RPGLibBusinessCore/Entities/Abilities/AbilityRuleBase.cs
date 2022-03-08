using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Abilities
{
    /// <summary>
    /// AbilityRuleBase
    /// To implement some Rules when action is done on Ability (like Add for example), 
    /// inherit from AbilityRuleBase and implement Business check in CheckIfValid method.
    /// Please don't change this abstract class, don't add Business rules here !
    /// </summary>    
    /// <example>See AbilityRuleBaseNotNullOrEmpty for a quick and easy implementation</example>
    internal abstract class AbilityRuleBase
    {
        public bool IsValid { get; set; }
        public Ability Ability { get; set; }

        public AbilityRuleBase(Ability ability)
        {
           this.Ability = ability;
        }

        public abstract void CheckIfValid();
    }
}
