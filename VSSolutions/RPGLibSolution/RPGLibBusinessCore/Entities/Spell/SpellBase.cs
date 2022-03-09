﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Entities.Spell
{
    public class SpellBase
    {  

        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }

        public ISpellAction Action { get; set; }

        /// <summary>
        /// SpellBase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="action"></param>
        public SpellBase(int id, string name, string description, ISpellAction action)
        {
            Id = id;
            Name = name;
            Description = description;
            Action = action;
        }

    }
}
