using RPGLibEntityCore;
using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGLibBusinessCore.Common
{
    public class DiceResult : CommonResult
    {
        public int TotalScore { get; set; }
        public List<DiceBase> PlayedDices { get; set; }

    }
}
