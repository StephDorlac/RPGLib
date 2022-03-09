using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Statistics
{
    public class StatisticBase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }

        public int? CurrentValue { get; set; }   

        public StatisticBase(int id, string name, int? min, int? max, int? value)
        {
            Id = id;
            Name = name;
            Min = min;
            Max = max;
            CurrentValue = value;
        }
    }
}
