using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class List<T>
    {
        Point<T> beg = null;

        public int Length
        {
            get
            {
                if (beg == null) return 0;
                int len = 0;
                Point<T> p = beg;
                while (p != null)
                {
                    p = p.next;
                    len++;
                }
                return len;
            }
        }
        public List(){}
        public List(int size)
        {
            beg = new Point<T>();
            Point<T> p = beg;
            for(int i=1; i<size;i++)
            {
                Point<T> temp = new Point<T>();
                p.next = temp;
                p = temp;
            }
        }
        public List(params T[]mas)
        {
            beg = new Point<T>();
            Point<T> p = beg;
            beg.data = mas[0];
            for(int i = 1;i<mas.Length;i++)
            {
                Point<T> temp = new Point<T>(mas[i]);
                p.next = temp;
                p = temp;

            }
        }
        public void PrintList()
        {
            if(beg==null)
            {
                Console.WriteLine("Пустой список!");
                return;
            }
            Point<T> p = beg;
            while(p!=null)
            {
                Console.Write(p);
                p = p.next;
            }
            Console.WriteLine();
        }
        public void AddPointToBeg(T d)
        {
            Point<T> temp = new Point<T>(d);
            if (beg==null)
            {
                beg = temp;
                return;
            }
            temp.next = beg;
            beg = temp;
        }
        public void RemovePoint(int nom)
        {
            if (beg == null)
            {
                return;
            }
            if(nom>Length)
            {
                Console.WriteLine("Error!");
                return;
            }
            if(beg.next==null)
            {
                beg = null;
                return;
            }
            if(nom==1)
            {
                beg = beg.next;
                return;
            }
            Point<T> p = beg;
            for (int i = 1; i < nom - 1; i++)
                p = p.next;
            //Point<T> t = p.next;
            //p.next = t.next;
            p.next = p.next.next;

        }
    }
}
