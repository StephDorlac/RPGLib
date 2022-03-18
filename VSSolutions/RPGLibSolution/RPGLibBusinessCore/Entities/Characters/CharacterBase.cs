using RPGLibBusinessCore.Entities.Abilities;
using RPGLibBusinessCore.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Characters
{
    /// <summary>
    /// CharacterBase is the entity to define character    
    /// </summary>
    /// <remarks>
    /// It expose properties like Statistics, Abilities as IEnumerable of these entities
    /// Abilities are provided by : CharacterBase + CharacterClass + Species
    /// </remarks>
    public class CharacterBase
    {

        #region Properties

        public int ID { get; set; }

        public List<Ability> Abilities { get; set; }
        public List<StatisticBase> Statistics { get; set; }
        public String Name { get; set; }

        public Species Species { get; set; }
        public CharacterClass CharacterClass { get; set; }


        #endregion

        #region Constructors


        public CharacterBase(int id, List<Ability> abilities, List<StatisticBase> statistics, string name, Species species, CharacterClass characterClass)
        {
            ID = id;
            Abilities = abilities;            
            Species = species;
            Name = name;
            Statistics = statistics;
            CharacterClass = characterClass;
        }


        #endregion
    }
}
