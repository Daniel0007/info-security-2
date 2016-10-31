using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    class file
    {
        private string name;
        private marker level;

        public string Name { get { return name; } }
        public marker Level { get { return level; } }

        public file(string n, marker m)
        {
            name = n;
            level = m;
        }
    }
}
