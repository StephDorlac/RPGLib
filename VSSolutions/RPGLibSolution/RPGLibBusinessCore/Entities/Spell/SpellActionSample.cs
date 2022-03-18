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
    /// A simple exemple of a Spell implementation
    /// </summary>
    public class SpellActionSample : ISpellAction
    {        
        public List<CharacterBase> AffectedCharacters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ItemBase> AffectedItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CommonResult ProcessAction()
        {
            CommonResult result = new CommonResult() { ResultStatus= CommonResult.ResultStatusAction.Pending};
            AffectedCharacters.ForEach(c =>
            {
                c.Statistics.ForEach(s => {
                    if(s.CurrentValue.HasValue && s.CurrentValue > 0 && s.CurrentValue > (s.Max/2))
                    {
                        s.CurrentValue = s.CurrentValue/2;
                    }
                });
            });
            result.ResultStatus = CommonResult.ResultStatusAction.Success;
            return result;
        }
    }
}
