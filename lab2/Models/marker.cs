using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    class marker
    {
        private int level;

        public int Level
        {
            get { return level; }
            set {
                if(value >=0 && value <=3)
                level = value;
                }
        }
        public string convert_marker()
        {
            if (level == 0)
            {
                return "non confidential";
            }
            else if (level == 1)
            {
                return "confidential";
            }
            else if (level == 2)
            {
                return "secret";
            }
            else
            {
                return "top secret";
            }
        }
        public static marker convert_marker(string s)
        {
            if (s == "non confidential")
            {
                return new marker(0);
            }
            else if (s == "confidential")
            {
                return new marker(1);
            }
            else if (s == "secret")
            {
                return new marker(2);
            }
            else
            {
                return new marker(3);
            }
        }
        public marker(int r)
        {
            level = r;
        }
        public static bool operator <=(marker m1, marker m2)
        {
            if (m1.level <= m2.level)
                return true;
            else
                return false;
        }
        public static bool operator >=(marker m1, marker m2)
        {
            if (m1.level >= m2.level)
                return true;
            else
                return false;
        }
    }
}
