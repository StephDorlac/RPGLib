using System;

namespace RPGLibEntityCore.Entities
{
    /// <summary>
    /// DiceBase is a class base tool to represent a simple Dice
    /// </summary>
    /// <remarks>You can choose dice implementation (20 sides, 6 sides, ... with min an max values </remarks>
    public class DiceBase : IBaseEntity   
    {    

        public int MinValue { get; set; }
        public int MaxValue { get; set; }   
        public int? CurrentValue { get; set; }
        public Guid Id { get; set; }
    }
}
