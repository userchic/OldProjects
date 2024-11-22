using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace ConsoleApp6
{
    class BTree<T>
    {
        BTreeElem<T> beg = null;
        public int levels { get; set; }
        public int Length
        {
            get
            {
                int i = 0;
                int level = 0;
                BTreeElem<T> p = beg;
                GoForwIsElemExists(ref p, ref i, level);
                return i;
            }
        }
        public BTree() { }
        public BTree(int size)
        {
            beg = new BTreeElem<T>();
            BTreeElem<T> p = beg;
            levels = 0;
            while (size > 1)
            {
                size = size / 2;
                levels++;
            }
            int i = 0;
            int level = 0;
            if (size > 0)
            {
                GoForwInputNull(ref p.next, ref i, level);
                i = 0;
                GoForwInputNull(ref p.prev, ref i, level);
            }
        }
        public BTree(params T[] mas)
        {
            beg = new BTreeElem<T>();
            BTreeElem<T> p = beg;
            levels = 0;
            int lenga = mas.Length;
            int helpnum = 1;
            while (lenga >= helpnum-1)
            { 
                helpnum=helpnum*2;
                levels++;
            }
            int i = 0;
            int level=0;
            GoForwInputMas(ref p.next,ref i,level,mas);
            i = 0;
            GoForwInputMas(ref p.prev,ref i,level,mas);
        }
        public void GoForwInputMas(ref BTreeElem<T> p, ref int i,int level,params T[]mas)
        {
            level++;
            if ((level < levels)&&(i<Length))
            {
                i++;
                p.data = mas[i];
                GoForwInputMas(ref p.prev, ref i, level, mas);
                GoForwInputMas(ref p.next, ref i, level, mas);
            }
        }
        public void GoForwIsElemExists(ref BTreeElem<T> p, ref int i, int level)
        {
            level++;
            if ((level < levels) && (i < Length))
            {
                i++;
                GoForwIsElemExists(ref p.prev, ref i, level);
                GoForwIsElemExists(ref p.next, ref i, level);
            }
        }
        public void GoForwPrintElem(ref BTreeElem<T> p, ref int i, int level)
        {
            level++;
            if ((level < levels) && (i < Length))
            {
                i++;
                Console.WriteLine(p.data.ToString());
                GoForwPrintElem(ref p.prev, ref i, level);
                GoForwPrintElem(ref p.next, ref i, level);
            }
        }
        public void GoForwInputNull(ref BTreeElem<T> p, ref int i, int level)
        {
            level++;
            if ((level < levels) && (i < Length))
            {
                i++;
                p = new BTreeElem<T>();
                GoForwInputNull(ref p.prev, ref i, level);
                GoForwInputNull(ref p.next, ref i, level);
            }
        }
        public void PrintList()
        {
            if (beg == null)
            {
                Console.WriteLine("Пустой список!");
                return;
            }
            BTreeElem<T> p = beg;
            int i = 0;
            int level = 0;
            GoForwPrintElem(ref p, ref i, level);
            Console.WriteLine();
        }
    }
}
