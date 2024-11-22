using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class List<T>:IEnumerable
    {
        class MyNumerator<T>:IEnumerator<T>
        {
            Point<T> beg;
            Point<T> current;
            public MyNumerator(List<T>collection)
            {
                beg = collection.beg;
                current = null;
            }
            public T Current
            {
                get { return current.data; }
            }
            object IEnumerator.Current
            {
                get
                {
                    return current;
                }
            }
            public void Dispose(){ }
            public bool MoveNext()
            {
                if (current == null)
                    current = beg;
                else
                    current = current.next;
                return current != null;
            }
            public void Reset()
            {
                current = this.beg;
            }
        }
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
        public List() { }
        public List(int size)
        {
            beg = new Point<T>();
            Point<T> p = beg;
            for (int i = 1; i < size; i++)
            {
                Point<T> temp = new Point<T>();
                p.next = temp;
                p = temp;
            }
        }
        public List(params T[] mas)
        {
            beg = new Point<T>();
            Point<T> p = beg;
            beg.data = mas[0];
            for (int i = 1; i < mas.Length; i++)
            {
                Point<T> temp = new Point<T>(mas[i]);
                p.next = temp;
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
            Point<T> p = beg;
            while (p != null)
            {
                Console.WriteLine(p.ToString());
                p = p.next;
            }
            Console.WriteLine();
        }
        public void AddPointToBeg(T d)
        {
            Point<T> temp = new Point<T>(d);
            if (beg == null)
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
            if (nom > Length)
            {
                Console.WriteLine("Error!");
                return;
            }
            if (beg.next == null)
            {
                beg = null;
                return;
            }
            if (nom == 1)
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
        public void Remove2Cutable()
        {
            if (Length > 1)
            {
                Point<T> p = beg;
                for (int i = 1; i < Length; i++)
                {
                    p.next = p.next.next;
                    p = p.next;
                }
            }
            if (Length == 1)
                Console.WriteLine("Четных объектов в этой коллекции нет");
            if (Length == 0)
                Console.WriteLine("Объектов в этой коллекции ещё нет");
        }
        public void Destructor()
        {
            Point<T> p = beg;
            while (beg != null)
            {
                beg = beg.next;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Point<T> current = beg;
            while (current!=null)
            {
                yield return current.data;
                current = current.next;
            }
        }
        //здесь был нумератор
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new MyNumerator<T>(this);
        //}
        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return GetEnumerator();
        }
    }
}
