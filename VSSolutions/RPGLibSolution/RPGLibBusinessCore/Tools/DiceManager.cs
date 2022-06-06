using RPGLibBusinessCore.Common;
using RPGLibEntityCore;
using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;

namespace RPGLibBusinessCore.Tools
{
    public class DiceManager    {

        private List<DiceBase> _dices;

        public int ResultValue { get; set; }

        /// <summary>
        /// DiceManager
        /// </summary>
        /// <param name="dice"></param>
        public DiceManager(List<DiceBase> dices)
        {
            this._dices = dices;
        }
              

        public DiceResult Roll()
        {
            var result = new DiceResult() { Message="Computing",ResultStatus= CommonResult.ResultStatusAction.Pending};
            int totalValue = 0;

            this._dices.ForEach(d =>
            {
                Random rnd = new Random();
                d.CurrentValue = rnd.Next(d.MinValue,d.MaxValue);
                totalValue += d.CurrentValue.Value;
            });
                        
            result.ResultStatus = CommonResult.ResultStatusAction.Success;
            result.Message = CommonResult.ResultStatusAction.Success.ToString();
            result.TotalScore = totalValue;
            result.PlayedDices = _dices;

            return result;
        }
        
    }
}
