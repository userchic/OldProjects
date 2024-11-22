using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class SortByName :IComparer
    {
        public int Compare(object obj1,object obj2)
        {
            Person p1 = (Person)obj1;
            Person p2 = (Person)obj2;
            if (p1.Division==p2.Division)
                return 0;
            if (p1.Division > p2.Division)
                return 1;
            else
                return -1;
        }
    }
}
