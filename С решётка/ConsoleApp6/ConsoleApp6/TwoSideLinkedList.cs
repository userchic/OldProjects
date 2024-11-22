using ClassLibrary1;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp6
{
    public class TwoSideLinkedList<T>
    {
        TwoSideLinkedPoint<T> beg = null;

        public int Length
        {
            get
            {
                if (beg == null) return 0;
                int len = 0;
                TwoSideLinkedPoint<T> p = beg;
                while (p != null)
                {
                    p = p.next;
                    len++;
                }
                return len;
            }
        }
        public TwoSideLinkedList() { }
        public TwoSideLinkedList(int size)
        {
            beg = new TwoSideLinkedPoint<T>();
            TwoSideLinkedPoint<T> p = beg;
            for (int i = 1; i < size; i++)
            {
                TwoSideLinkedPoint<T> temp = new TwoSideLinkedPoint<T>();
                p.next = temp;
                p = temp;
            }
        }
        public TwoSideLinkedList(params T[] mas)
        {
            beg = new TwoSideLinkedPoint<T>();
            TwoSideLinkedPoint<T> p = beg;
            beg.data = mas[0];
            for (int i = 1; i < mas.Length; i++)
            {
                TwoSideLinkedPoint<T> temp = new TwoSideLinkedPoint<T>(mas[i]);
                p.next = temp;
                temp.prev = p;
                p = temp;
            }
        }
        public void PrintList()
        {
            if (beg == null)
            {
                Console.WriteLine("Пустой список!");
                return;
            }
            TwoSideLinkedPoint<T> p = beg;
            while (p != null)
            {
                if (p!=null)
                Console.WriteLine(p.ToString());
                if (p == null)
                    Console.WriteLine("Пустой объект!");
                p = p.next;
            }
            Console.WriteLine(); 
        }
        public void Addnot2cutableEls(params T[] mas)
        {
            if (beg == null)
            {
                Console.WriteLine("Коллекция пуста, добавлять нечего");
                return;
            }
            TwoSideLinkedPoint<T>p=beg; 
            TwoSideLinkedPoint<T> pnew = new TwoSideLinkedPoint<T>(mas[0]);
            pnew.next = p;
            beg.prev = pnew;
            beg = pnew;
            for (int i=1; i<mas.Length;i+=1)
            {
                pnew = new TwoSideLinkedPoint<T>(mas[i]);
                pnew.next = p.next;
                p.next.prev = pnew;
                p.next = pnew;
                pnew.prev = p;
                p = pnew.next;
            }
        }
        public void Destructor()
        {
            TwoSideLinkedPoint<T> p = beg;
            for (int i = Length; i > 0; i--)
            {
                p.prev = null;
                if ((p.next != null) && (p.next.data != null))
                {
                    p = p.next;
                    p.prev.next = null;
                    beg = p;
                }
                else
                    beg = null;
            }
        }
    }
}
