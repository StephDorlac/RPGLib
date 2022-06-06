using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// A simple exemple of a Spell implementation
    /// THIS ACTION WILL BE IMPLEMENTED IN BusinessCore, not in EntityCore !
    /// </summary>
    //public class SpellActionSample : ISpellAction
    //{        
    //    public List<CharacterBase> AffectedCharacters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public List<ItemBase> AffectedItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public CommonResult ProcessAction()
    //    {
    //        CommonResult result = new CommonResult() { ResultStatus= CommonResult.ResultStatusAction.Pending};
    //        AffectedCharacters.ForEach(c =>
    //        {
    //            c.Statistics.ForEach(s => {
    //                if(s.CurrentValue.HasValue && s.CurrentValue > 0 && s.CurrentValue > (s.Max/2))
    //                {
    //                    s.CurrentValue = s.CurrentValue/2;
    //                }
    //            });
    //        });
    //        result.ResultStatus = CommonResult.ResultStatusAction.Success;
    //        return result;
    //    }
    //}
}
