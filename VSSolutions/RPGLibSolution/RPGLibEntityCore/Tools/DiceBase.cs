using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// DiceBase is a class base tool to represent a simple Dice
    /// </summary>
    /// <remarks>You can choose dice implementation (20 sides, 6 sides, ... with min an max values </remarks>
    public class DiceBase
    {
        public DiceBase(int iD, string? name, string? description, int minValue, int maxValue, int? currentValue)
        {
            ID = iD;
            Name = name;
            Description = description;
            MinValue = minValue;
            MaxValue = maxValue;
            CurrentValue = currentValue;
        }

        public int ID { get; set; } 
        public string? Name { get; set; }    
        public string? Description { get; set; } 
        public int MinValue { get; set; }
        public int MaxValue { get; set; }   
        public int? CurrentValue { get; set; }  

    }
}
