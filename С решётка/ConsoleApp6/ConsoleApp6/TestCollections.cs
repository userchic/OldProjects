using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp6
{
    class TestCollections
    {
        public LinkedList<Engineer> ll;
        public LinkedList<string> llstring;
        public SortedDictionary<Person, Engineer> sd;
        public SortedDictionary<string, Engineer> sdstring;
        Stopwatch time;

        static  Engineer first, middle, last, empty;

        public TestCollections(int n)
        {
            llstring = new LinkedList<string>();
            ll = new LinkedList<Engineer>();
            sd = new SortedDictionary<Person, Engineer>();
            sdstring = new SortedDictionary<string, Engineer>();
            time = new Stopwatch();
            for (int i=0;i<n;i++)
            {
                Engineer e = new Engineer();
                e = (Engineer)e.Init();
                Person p = e.BasePerson;
                if (sd.ContainsKey(p)) //sd.ContainsKey(p)
                {
                    i--;
                }
                else
                {
                    LinkedListNode<Engineer> node1 = new LinkedListNode<Engineer>(e);
                    ll.AddLast(node1);
                    LinkedListNode<string> node2 = new LinkedListNode<string>(e.ToString());
                    llstring.AddLast(node2);
                    //Engineer e1 = new Engineer();
                    //e = (Engineer)e.Init();
                    //p = (Person)p.Init();
                    sd.Add(p, e);
                    sdstring.Add(p.ToString(), e);
                    if (i == 0) first =(Engineer)e.Clone();
                }
            }
        }
        public static void Addd(TestCollections TC1, Engineer e)
        {
            if (TC1.ll.Contains(e)) //sd.ContainsKey(p)
            {
                Console.WriteLine("");
            }
            else
            {
                Person p = e.BasePerson;
                LinkedListNode<Engineer> node1 = new LinkedListNode<Engineer>(e);
                TC1.ll.AddLast(node1);
                LinkedListNode<string> node2 = new LinkedListNode<string>(e.ToString());
                TC1.llstring.AddLast(node2);
                TC1.sd.Add(p, e);
                TC1.sdstring.Add(p.ToString(), e);
            }
        }
        public static void Deleteo(TestCollections TC1, Engineer e)
        {
            Person p = e.BasePerson;
            LinkedListNode<Engineer> node1 = new LinkedListNode<Engineer>(e);
            TC1.ll.Remove(node1.Value);
            LinkedListNode<string> node2 = new LinkedListNode<string>(e.ToString());
            TC1.llstring.Remove(node2.Value);
            TC1.sd.Remove(p);
            TC1.sdstring.Remove(p.ToString());
        }
        public void ShowCollections()
        {
            Console.WriteLine("Печать списка элементов Engineer, нажмите enter для печати");
            Console.ReadLine();
            foreach(var item in ll)
            {
                item.Show();
            }

            Console.WriteLine("Печать списка элементов string, нажмите enter для печати");
            Console.ReadLine();
            foreach (var item in llstring)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Печать SortedDictionary для элементов Engineer, нажмите enter для печати");
            Console.ReadLine();
            foreach (var item in sd)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.WriteLine("Печать SortedDictionary для элементов Engineer и string ключа, нажмите enter для печати");
            Console.ReadLine();
            foreach (var item in sdstring)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

        }
        public  void FindFirst()
        {
            Person p = first.BasePerson;
            time.Reset();
            bool ok;
            //double TimeWithO;
            //long aver = 0;
            //for (int i = 0; i < ll.Count; i++)
            //{
            time.Restart();
            ok = ll.Contains(first);
            time.Stop();
            // aver += time.ElapsedTicks;
            //  }
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<Engineer> {time.ElapsedTicks}");
          //  TimeWithO = aver / ll.Count;
         //   Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            time.Restart();
            ok = llstring.Contains(first.ToString());
            time.Stop();
            //Console.WriteLine($"Время поиска{time.ElapsedTicks}");
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<string> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            ok = sd.ContainsKey(p);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sd.ContainsValue(first);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска значения для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sdstring.ContainsKey(p.ToString());
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sdstring.ContainsValue(first);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска значения для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            time.Reset();
        }
        public void Findmid()
        {
            LinkedListNode < Engineer > midnode = ll.First;
            for (int i=1;i<ll.Count/2;i++)
            {
                midnode=midnode.Next;
            }
            //double TimeWithO;
            middle = (Engineer)midnode.Value.Clone();
            bool ok;
            Person p = middle.BasePerson;
            time.Reset();
            time.Start();
            //for(int i=0;i< ll.Count; i++)
            ok = ll.Contains(middle);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<Engineer> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = llstring.Contains(middle.ToString());
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<string> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sd.ContainsKey(p);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sd.ContainsValue(middle);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска значения для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sdstring.ContainsKey(p.ToString());
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            time.Restart();
            ok = sdstring.ContainsValue(middle);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска значения для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            time.Reset();
        }
        public void Findlast()
        {
            LinkedListNode<Engineer> lastnode = ll.Last;
            last = (Engineer)lastnode.Value.Clone();
            Person p = last.BasePerson;
            time.Reset();
            bool ok;
            time.Start();
            //double TimeWithO;
            //for (int i = 0; i < ll.Count; i++)
                ok = ll.Contains(last);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<Engineer> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
                ok = llstring.Contains(last.ToString());
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<string> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
                ok = sd.ContainsKey(p);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sd.ContainsValue(last);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска значения для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
                ok = sdstring.ContainsKey(p.ToString());
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sdstring.ContainsValue(last);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска значения для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            time.Reset();
        }
        public void FindNonContained()
        {
            empty = new Engineer("ыкса", 100000100,"Плохой инженер");
            Person p = empty.BasePerson;
            time.Reset();
            time.Start();
            bool ok;
            //double TimeWithO;
            //for (int i = 0; i < ll.Count; i++)
                ok = ll.Contains(empty);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<Engineer> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
                ok = llstring.Contains(empty.ToString());
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции LinkedList<string> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
                ok = sd.ContainsKey(p);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sd.ContainsValue(empty);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска значения для коллекции SortedDictionary<Engineer,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            //time.Reset();
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sdstring.ContainsKey(p.ToString());
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            time.Restart();
            //for (int i = 0; i < ll.Count; i++)
            ok = sdstring.ContainsValue(empty);
            time.Stop();
            if (ok) Console.WriteLine("Элемент найден");
            else Console.WriteLine("Элемент не найден");
            Console.WriteLine($"Время поиска для коллекции SortedDictionary<string,Person> {time.ElapsedTicks}");
            //TimeWithO = time.ElapsedTicks / ll.Count;
            //Console.WriteLine($"Среднее время поиска за {ll.Count} попыток {TimeWithO}");
            time.Reset();
        }
    }
}
