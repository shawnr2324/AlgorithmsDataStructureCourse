using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Models
{
    public class Pokemon
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; } = 0;

        public Pokemon(string name, int level) 
        {
            Name = name;
            Level = level;
        }

        public bool isPokemon()
        {
            return true;
        }
    }
}
