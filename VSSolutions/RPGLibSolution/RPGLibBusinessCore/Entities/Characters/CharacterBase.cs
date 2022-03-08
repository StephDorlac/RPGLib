using RPGLibBusinessCore.Entities.Abilities;
using RPGLibBusinessCore.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Characters
{
    public class CharacterBase
    {

        #region Properties

        public int Id { get; set; }

        public List<Ability> Abilities { get; set; }
        public List<StatisticBase> Statistics { get; set; }
        public String Name { get; set; }

        public Species Species { get; set; }


        #endregion

        #region Constructors


        public CharacterBase(int id, List<Ability> abilities, List<StatisticBase> statistics, string name, Species species)
        {
            Id = id;
            Abilities = abilities;            
            Species = species;
            Name = name;
            Statistics = statistics;
        }


        #endregion
    }
}
