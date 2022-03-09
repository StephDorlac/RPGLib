using RPGLibBusinessCore.Entities.Characters;
using RPGLibBusinessCore.Entities.Common;
using RPGLibBusinessCore.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Spell
{
    public interface ISpellAction
    {
        public CommonResult ProcessAction();        
        public List<CharacterBase> AffectedCharacters { get; set; }
    }
}
