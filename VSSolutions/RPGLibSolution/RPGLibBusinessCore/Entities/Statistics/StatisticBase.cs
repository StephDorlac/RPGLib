using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Statistics
{
    /// <summary>
    /// StatisticBase entity is used to help for item or character statistic
    /// </summary>
    /// <remarks>
    /// Accuracy, Strenght, Mana, etc. ... are used as Statistic
    /// Set a min and max for this
    /// </remarks>
    public class StatisticBase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public int? CurrentValue { get; set; }   

        public StatisticBase(int id, string name, string description, int min, int max, int? value)
        {
            Id = id;
            Name = name;
            Description = description;
            Min = min;
            Max = max;
            CurrentValue = value;
        }
    }
}
