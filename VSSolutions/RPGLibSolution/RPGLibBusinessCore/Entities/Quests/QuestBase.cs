using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Quests
{
    /// <summary>
    /// QuestBase define the entity of a quest
    /// </summary>
    public class QuestBase
    {
        public int Id { get; set; }
        public QuestType QuestType { get; set; }    
        public String Name { get; set; }   
        public String Description { get; set; }

        public QuestBase(int id, QuestType questType, string name, string description)
        {
            Id = id;
            QuestType = questType;
            Name = name;
            Description = description;
        }
    }
}
