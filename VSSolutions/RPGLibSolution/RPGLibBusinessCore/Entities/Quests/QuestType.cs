using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Quests
{
    /// <summary>
    /// QuestType define the entity of a quest type
    /// </summary>
    public class QuestType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public QuestType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
