using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>(5);
            List<int> list2 = new List<int>(1, 2, 3, 4, 5);
            List<int> list3 = new List<int>();
            list1.PrintList();
            list2.PrintList();
            list3.PrintList();
            list1.AddPointToBeg(100);
            list2.AddPointToBeg(200);
            list3.AddPointToBeg(300);
            list1.PrintList();
            list2.PrintList();
            list3.PrintList();
            list1.RemovePoint(1);
            list2.RemovePoint(3);
            list3.RemovePoint(5);
            list1.PrintList();
            list2.PrintList();
            list3.PrintList();
        }
    }
}
