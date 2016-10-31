using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    class user
    {
        private string name;
        private marker level;
        public int Number { get; set; }

        public marker Initial_level { get; }

        public string Name { get {return name; } }
        public marker Level { get { return level; } set { level = value; } }
        public user (string n, marker m,int num)
        {
            name = n;
            level = m;
            Initial_level = level;
            Number = num;
        }

    }
}
