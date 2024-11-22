using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace ConsoleApp6
{
    class Program
    {
        static Random rond = new Random();
        static void Main(string[] args)
        {
            //try
            //{
                Console.Clear();
                #region
                //            List<int> list1 = new List<int>(5);
                //            List<int> list2 = new List<int>(1, 2, 3, 4, 5);
                //            List<int> list3 = new List<int>();
                //            list1.PrintList();
                //            list2.PrintList();
                //            list3.PrintList();
                //            list1.AddPointToBeg(100);
                //            list2.AddPointToBeg(200);
                //            list3.AddPointToBeg(300);
                //            list1.PrintList();
                //            list2.PrintList();
                //            list3.PrintList();
                //            list1.RemovePoint(1);
                //            list2.RemovePoint(3);
                //            list3.RemovePoint(5);
                //            list1.PrintList();
                //            list2.PrintList();
                //            list3.PrintList();
                //            Console.Write(@"        Меню
                //1 Однонаправленный список
                //2 Двунаправленный список    
                //3 Бинарное дерево
                //Выбор:");// в 2 нап списке добавлять элементы 1,3,5 перед соответствующими объектами до применения функции
                //            Person p1 = new Person("Вася", 1);
                //            Person p2 = new Person("Ииосиф", 1);
                //            Person p3 = new Person("Дурдынев", 2);
                //            Person p4 = new Person("Чипполино", 2);
                //            List<Person> PList1 = new List<Person>(p1, p2, p3, p4);
                //            PList1.PrintList();
                //            PList1.Remove2Cutable();
                //            PList1.PrintList();
                //            TwoSideLinkedList<Person> PLList1 = new TwoSideLinkedList<Person>(p1, p2, p3, p4);
                //            PLList1.PrintList();
                //            PLList1.Addnot2cutableEls();
                //            PLList1.PrintList();
                //            string InputLine;
                //            Console.Write(@"Выберите лабораторную работу:
                //            1  10 лабораторная работа
                //            2  11 лабораторная работа
                //            Выбор:");
                //            int choice1;
                //            Check(out choice1);
                //            Console.Clear();
                //            if (choice1 == 1)
                //            {
                //                Person p1 = new Person("Вася", 1);
                //                Person p2 = new Person("Ииосиф", 1);
                //                Person p3 = new Person("Дурдынев", 2);
                //                Person p4 = new Person("Чипполино", 2);
                //                Worker E1 = new Worker("Василий", 1, "Рыть траншеи");
                //                Worker E2 = new Worker("Николай", 2, "Рыть траншеи");
                //                Worker E3 = new Worker("Александр", 3, "Переводчик");
                //                Worker E4 = new Worker("Петя", 4, "Ремонт инфраструктуры");
                //                Engineer EN1 = new Engineer("Васёк", 1, "Ремонт техники");
                //                Engineer EN2 = new Engineer("Иннокентий", 2, "Ремонт техники");
                //                Engineer EN3 = new Engineer("Филипп", 3, "Ремонт техники");
                //                Engineer EN4 = new Engineer("Карл", 4, "Ремонт техники");
                //                ArmyMan AM1 = new ArmyMan("А.П.Пушкин", 1, 25);
                //                ArmyMan AM2 = new ArmyMan("Л.Н.Толстой", 2, 75);
                //                ArmyMan AM3 = new ArmyMan("А.С.Миронов", 4, 15);
                ////                ArmyMan AM4 = new ArmyMan("С.А.Трунин", 3, 5);
                //                Person[] people = { p1, p2, p3, p4, E1, E2, E3, E4, EN1, EN2, EN3, EN4, AM1, AM2, AM3, AM4 };
                #endregion
                string InputLine = "3214r32ewd";
            #region кусок бывшей лр 9 или 10
            //                Console.Clear();
            //                Console.Write
            //(@"                       Меню демонстрации
            //        Выберите часть программы, которую необходимо продемонстрировать:
            //        1 Часть I
            //        2 Часть II
            //        3 Часть III
            //        00 Для завершения демонстрации
            //        Выбор:");
            //                InputLine = Console.ReadLine();
            //                while ((InputLine != "00") && (InputLine != "1") && (InputLine != "2") && (InputLine != "3"))
            //                {
            //                    Console.WriteLine("Введено не число из промежутка от 0 до 3, введите ещё раз:");
            //                    InputLine = Console.ReadLine();
            //                }
            //                while ((InputLine != "0") && (InputLine != "00"))
            //                {
            //            switch (InputLine)
            //            {
            //                case "1":
            //                    {
            //                        foreach (Person p in people)
            //                            p.Show();
            //                    }
            //                    break;
            //                case "2":
            //                    {
            //                        while ((InputLine == "1") || (InputLine == "2") || (InputLine == "3") || (InputLine == ""))
            //                        {
            //                            Console.Clear();
            //                            Console.Write
            //                (@"                  Меню демонстрации часть ||
            //1 Имена служащих со стажем не менее заданного
            //2 Имена рабочих, заданной профессии
            //3 Количество инженеров в заданном подразделении
            //любое другое - выход в гл. меню
            //Выбор:");
            //                            InputLine = Console.ReadLine();
            //                            if ((InputLine == "1") || (InputLine == "2") || (InputLine == "3"))
            //                            {
            //                                switch (InputLine)
            //                                {
            //                                    case "1":
            //                                        {
            //                                            Console.WriteLine("Введите стаж, в соответствии с которым необходимо отфильтровать служащих, имеющих меньший стаж");
            //                                            int staj;
            //                                            Console.Write("Ввод:");
            //                                            InputLine = Console.ReadLine();
            //                                            staj = -1;
            //                                            while (staj < 0)
            //                                            {
            //                                                staj = int.Parse(InputLine);
            //                                            }
            //                                            Console.WriteLine();
            //                                            foreach (Person p in people)
            //                                                if (p is ArmyMan)
            //                                                {
            //                                                    if ((((ArmyMan)p).WorkExperience) >= staj)
            //                                                        p.Show();
            //                                                }
            //                                        }
            //                                        break;
            //                                    case "2":
            //                                        {
            //                                            Console.WriteLine("Введите профессию, рабочие которой вам нужны");
            //                                            Console.Write("Ввод:");
            //                                            InputLine = Console.ReadLine();
            //                                            foreach (Person p in people)
            //                                                if (p is Worker)
            //                                                {
            //                                                    if ((((Worker)p).Profession) == InputLine)
            //                                                        p.Show();
            //                                                }
            //                                        }
            //                                        break;
            //                                    case "3":
            //                                        {
            //                                            Console.WriteLine("Введите подразделение, инженеров которого необходимо вывести");
            //                                            Console.Write("Ввод:");
            //                                            int Eng, numEng;
            //                                            numEng = 0;
            //                                            InputLine = Console.ReadLine();
            //                                            Eng = int.Parse(InputLine);
            //                                            foreach (Person p in people)
            //                                                if (p is Engineer)
            //                                                {
            //                                                    if (((Engineer)p).Division == Eng)
            //                                                    {
            //                                                        p.Show();
            //                                                        numEng++;
            //                                                    }
            //                                                }
            //                                            Console.WriteLine($"кол-во инженеров подразделения {Eng} равно {numEng}");
            //                                        }
            //                                        break;
            //                                }
            //                            }
            //                            Console.WriteLine(@"Возвращение в меню...


            //");
            //                            Console.WriteLine("Нажмите Enter для продолжения...");
            //                            InputLine = Console.ReadLine();
            //                        }
            //                    }
            //                    break;
            //                case "3":
            //                    {
            #endregion
            List<int> list = new List<int>(1, 2, 3, 4, 5);
            foreach (int x in list)
                Console.WriteLine(x);
                while (InputLine != "end.")
                {
                    Console.WriteLine("          Демонстрационная программа работы с классами-коллекциями, создаваемыми пользователем");
                    IInit[] divizes = null;
                    if (divizes == null)
                    {
                        Console.WriteLine(@"Перед началом работы с коллекциями необходимо создать массив, элементами которого коллекции будут заполняться");
                        Console.Write("Длина создаваемого массива:");
                        int x;
                        Check(out x);
                        Console.WriteLine("Массив будет заполняться случайно сгенерированными объектами");
                        divizes = new IInit[x];
                        Console.WriteLine("Созданный массив:");
                        for (int i = 0; i < divizes.Length; i++)
                        {
                            int randonum;
                            randonum = rond.Next(4);
                            switch (randonum)
                            {
                                case 0:
                                    {
                                        Person p = new Person();
                                        p = (Person)p.Init();
                                        p.Show();
                                        divizes[i] = p;
                                    }
                                    break;
                                case 1:
                                    {
                                        Engineer p = new Engineer();
                                        p = (Engineer)p.Init();
                                        divizes[i] = p;
                                        p.Show();
                                    }
                                    break;
                                case 2:
                                    {
                                        Worker p = new Worker();
                                        p = (Worker)p.Init();
                                        divizes[i] = p;
                                        p.Show();
                                    }
                                    break;
                                case 3:
                                    {
                                        ArmyMan p = new ArmyMan();
                                        p = (ArmyMan)p.Init();
                                        divizes[i] = p;
                                        p.Show();
                                    }
                                    break;
                            }
                        }
                        Console.WriteLine("Enter для начала работы с коллекциями...");
                        Console.ReadLine();
                    }
                    if (divizes != null)
                    {
                        while (InputLine != "end.")
                        {
                            Console.Clear();
                            Console.Write(@"              Меню работы с коллекциями
1 Создать новый массив
2 Работа с однонаправленным списком
3 Работа с двунаправленным списком
4 Работа с бинарным деревом
<end.> для завершения работы программы
Выбор:");
                            InputLine = Console.ReadLine();
                            switch (InputLine)
                            {
                                case "1":
                                    {
                                        Console.Write("Длина создаваемого массива:");
                                        int x;
                                        Check(out x);
                                        Console.WriteLine("Массив будет заполняться случайно сгенерированными объектами");
                                        divizes = new IInit[x];
                                        for (int i = 0; i < divizes.Length; i++)
                                        {
                                            Console.WriteLine("Созданный массив:");
                                            int randonum;
                                            randonum = rond.Next(4);
                                            switch (randonum)
                                            {
                                                case 0:
                                                    {
                                                        Person p = new Person();
                                                        p = (Person)p.Init();
                                                        p.Show();
                                                        divizes[i] = p;
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        Engineer p = new Engineer();
                                                        p = (Engineer)p.Init();
                                                        divizes[i] = p;
                                                        p.Show();
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        Worker p = new Worker();
                                                        p = (Worker)p.Init();
                                                        divizes[i] = p;
                                                        p.Show();
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        ArmyMan p = new ArmyMan();
                                                        p = (ArmyMan)p.Init();
                                                        divizes[i] = p;
                                                        p.Show();
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                case "2":
                                    {
                                        List<IInit> PList1 = new List<IInit>(divizes);
                                        while ((InputLine != "end") && (InputLine != "3"))
                                        {
                                            Console.Clear();
                                            Console.Write(@"              Меню работы с однонаправленным списком
1 Вывести список на экран
2 Удалить элементы с четным номером из коллекции
3 Удалить коллекцию(после этого вы будеет возвращены в главное меню)
<end> возвращение в Меню работы с коллекциями
Выбор:");
                                            InputLine = Console.ReadLine();
                                            switch (InputLine)
                                            {
                                                case "1":
                                                    {
                                                        PList1.PrintList();
                                                        Console.WriteLine("Enter для возврата в меню работы со списком...");
                                                        Console.ReadLine();
                                                    }
                                                    break;
                                                case "2":
                                                    {
                                                        PList1.Remove2Cutable();
                                                        Console.WriteLine("Полученный список имеет вид:");
                                                        PList1.PrintList();
                                                        Console.WriteLine("Enter для возврата в меню работы со списком...");
                                                        Console.ReadLine();
                                                    }
                                                    break;
                                                case "3":
                                                    {
                                                        PList1.Destructor();
                                                        PList1.PrintList();
                                                        Console.Write("Enter для продолжения...");
                                                        Console.ReadLine();
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                case "3":
                                    {
                                        TwoSideLinkedList<IInit> PPList1 = new TwoSideLinkedList<IInit>(divizes);
                                        IInit[] helpdivizes;
                                        while (InputLine != "end")
                                        {
                                            Console.Clear();
                                            Console.Write(@"              Меню работы с двунаправленным списком
1 Вывести список на экран
2 Добавить элементы в список перед элементами с чётными номерами
3 Удалить коллекцию(после этого вы будеет возвращены в главное меню)
<end> возвращение в Меню работы с коллекциями
Выбор:");
                                            InputLine = Console.ReadLine();
                                            switch (InputLine)
                                            {
                                                case "1":
                                                    {
                                                        PPList1.PrintList();
                                                        Console.WriteLine("Enter для возврата в меню работы со списком...");
                                                        Console.ReadLine();
                                                    }
                                                    break;
                                                case "2":
                                                    {
                                                        Console.WriteLine("Добавленные элементы:");
                                                        int x;
                                                        x = PPList1.Length;
                                                        helpdivizes = new IInit[x];
                                                        for (int i = 0; i < helpdivizes.Length; i++)
                                                        {
                                                            int randonum;
                                                            randonum = rond.Next(4);
                                                            switch (randonum)
                                                            {
                                                                case 0:
                                                                    {
                                                                        Person p = new Person();
                                                                        p = (Person)p.Init();
                                                                        p.Show();
                                                                        helpdivizes[i] = p;
                                                                    }
                                                                    break;
                                                                case 1:
                                                                    {
                                                                        Engineer p = new Engineer();
                                                                        p = (Engineer)p.Init();
                                                                        helpdivizes[i] = p;
                                                                        p.Show();
                                                                    }
                                                                    break;
                                                                case 2:
                                                                    {
                                                                        Worker p = new Worker();
                                                                        p = (Worker)p.Init();
                                                                        helpdivizes[i] = p;
                                                                        p.Show();
                                                                    }
                                                                    break;
                                                                case 3:
                                                                    {
                                                                        ArmyMan p = new ArmyMan();
                                                                        p = (ArmyMan)p.Init();
                                                                        helpdivizes[i] = p;
                                                                        p.Show();
                                                                    }
                                                                    break;
                                                            }
                                                        }
                                                        PPList1.Addnot2cutableEls(helpdivizes);
                                                        Console.WriteLine("Полученный список имеет вид:");
                                                        PPList1.PrintList();
                                                        Console.WriteLine("Enter для возврата в меню работы со списком...");
                                                        Console.ReadLine();
                                                    }
                                                    break;
                                                case "3":
                                                {
                                                    PPList1.Destructor();
                                                    PPList1.PrintList();
                                                    Console.Write("Enter для продолжения...");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case "4":
                                    {
                                        while ((InputLine != "end") && (InputLine != "3"))
                                        {
                                            BTree<IInit> BTree1  = new BTree<IInit>(divizes);
                                            Console.Clear();
                                            Console.Write(@"              Меню работы с бинарным деревом
1 Вывести дерево на экран
2 Найти самый большой объект в дереве
3 Удалить коллекцию(после этого вы будеет возвращены в главное меню)
<end> возвращение в Меню работы с коллекциями
Выбор:");
                                            InputLine = Console.ReadLine();
                                            switch (InputLine)
                                            {
                                                case "1":
                                                    {
                                                        BTree1.PrintList();
                                                        Console.WriteLine("Enter для возврата в меню работы со списком...");
                                                        Console.ReadLine();
                                                    }
                                                    break;
                                                case "2":
                                                    {
                                                        //BTree1.Remove2Cutable();
                                                        //Console.WriteLine("Полученный список имеет вид:");
                                                        //BTree1.PrintList();
                                                        //Console.WriteLine("Enter для возврата в меню работы со списком...");
                                                        //Console.ReadLine();
                                                    }
                                                    break;
                                                case "3":
                                                {
                                                    //BTree1.Destructor();
                                                    //BTree1.PrintList();
                                                    //Console.Write("Enter для продолжения...");
                                                    //Console.ReadLine();
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    #region
                    //case "2":
                    //    {
                    //        Console.WriteLine("Сортировка по имени:");
                    //        Array.Sort(divizes);
                    //        Console.WriteLine("Вектор отсортированный");
                    //        foreach (Person p in divizes)
                    //            p.Show();
                    //    }
                    //    break;
                    //case "3":
                    //    {
                    //        Console.WriteLine("Сортировка по подразделениям");
                    //        Array.Sort(divizes, new SortByName());
                    //        Console.WriteLine("Вектор отсортированный");
                    //        foreach (Person p in divizes)
                    //            p.Show();
                    //    }
                    //    break;
                    //case "4":
                    //    {
                    //        string nam, extracharstr, hostility;
                    //        int diviz, extrachar, k;
                    //        k = 0;
                    //        Console.WriteLine("Введите подразделение объекта");
                    //        nam = Console.ReadLine();
                    //        diviz = int.Parse(nam);
                    //        Console.WriteLine("Введите имя нужного объекта:");
                    //        nam = Console.ReadLine();
                    //        Console.WriteLine("Введите значение 3 характеристики нужного объекта(0 для персон без ролей)");
                    //        extracharstr = Console.ReadLine();
                    //        Console.WriteLine("Является ли нужный объект враждебным?");
                    //        hostility = Console.ReadLine();
                    //        if (hostility == "да")
                    //        {
                    //            EnemyArmyMan ea = new EnemyArmyMan(nam, diviz);
                    //            for (int i = 0; i < divizes.Length; i++)
                    //            {
                    //                if ((typeof(EnemyArmyMan) == divizes[i].GetType()) && ((EnemyArmyMan)divizes[i]).Equals(ea))
                    //                {
                    //                    Console.WriteLine("Найденный объект:");
                    //                    ea.Show();
                    //                    k += 1;
                    //                }
                    //            }
                    //        }
                    //    else
                    //    {
                    //        if (int.TryParse(extracharstr, out extrachar) == false)
                    //        {
                    //            Engineer e = new Engineer(nam, diviz, extracharstr);
                    //            Worker w = new Worker(nam, diviz, extracharstr);
                    //            for (int i = 0; i < divizes.Length; i++)
                    //            {
                    //                if ((typeof(Engineer) == divizes[i].GetType()) && ((Engineer)divizes[i]).Equals(e))
                    //                {
                    //                    Console.WriteLine("Найденный объект:");
                    //                    e.Show();
                    //                    k += 1;
                    //                }
                    //                if ((typeof(Worker) == divizes[i].GetType()) && ((Worker)divizes[i]).Equals(w))
                    //                {
                    //                    Console.WriteLine("Найден объект:");
                    //                    w.Show();
                    //                    k += 1;
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            extrachar = int.Parse(extracharstr);
                    //            ArmyMan a = new ArmyMan(nam, diviz, extrachar);

                    //            if (extrachar == 0)
                    //            {
                    //                Person p = new Person(nam, diviz);
                    //                for (int i = 0; i < divizes.Length; i++)
                    //                {
                    //                    if ((typeof(Person) == divizes[i].GetType()) && ((Person)divizes[i]).Equals(p))
                    //                    {
                    //                        Console.WriteLine("Найден объект:");
                    //                        p.Show();
                    //                        k += 1;
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                for (int i = 0; i < divizes.Length; i++)
                    //                {
                    //                    if ((typeof(ArmyMan) == divizes[i].GetType()) && ((ArmyMan)divizes[i]).Equals(a))
                    //                    {
                    //                        Console.WriteLine("Найден объект:");
                    //                        a.Show();
                    //                        k += 1;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //    if (k == 0)
                    //        Console.WriteLine("Объектов с такими полями не найдено ):");
                    //}
                    //break;
                    //case "5":
                    //    {
                    //        Person p10 = new Person("Алексей", 100);
                    //        Person p11 = (Person)p10.Clone();
                    //        p11.Show();
                    //    }
                    //    break;
                    //case "6":
                    //    {
                    //        Person p12 = new Person("Алексей", 100);
                    //        Person p13 = p12.ShallowCopy();
                    //        p13.Show();
                    //    }
                    //    break;
                    #endregion
                }
                Console.WriteLine("Завершение работы программы...");
            //}
            //catch 
            //{
            //    Console.WriteLine("Ошибка,аварийное завершение работы программы, программа перезапускается...");
            //    Console.WriteLine("Enter для начала работы с программой заново...");
            //    Console.ReadLine();
            //    Main(args);
            //}
        }
                #region
                //                    Console.WriteLine("Нажмите Enter для продолжения...");
                //                    InputLine = Console.ReadLine();
                //                    Console.Clear();
                //                    Console.Write
                //(@"                       Меню демонстрации
                //        Выберите часть программы, которую необходимо продемонстрировать:
                //        1 Часть I
                //        2 Часть II
                //        3 Часть III
                //        00 Для завершения демонстрации
                //        Выбор:");
                //                    InputLine = Console.ReadLine();
                //                    }
                //}
                //            }
                //        }

                //    if (choice1 == 2)
                //    {
                //        int choice3;
                //        choice3 = -1000;
                //        while (choice3 != 0)
                //        {
                //            Console.WriteLine(@"Выберите часть работы, которую необходимо продемонстрировать:
                //    1 Часть I
                //    2 Часть II
                //    3 Часть III
                //    0-Завершение работы программы...");
                //            InputLine = Console.ReadLine();
                //            choice3 = int.Parse(InputLine);
                //            switch (choice3)
                //            {
                //                case 1:
                //                    {
                //                        ArrayList al = new ArrayList(100);
                //                        Console.WriteLine("Созданный массив(люди и инженеры):");
                //                        int randonum;
                //                        for (int ii = 0; ii < al.Capacity; ii++)
                //                        {
                //                            randonum = rond.Next(2);
                //                            switch (randonum)
                //                            {
                //                                case 0:
                //                                    {
                //                                        Person p = new Person();
                //                                        p = (Person)p.Init();
                //                                        p.Show();
                //                                        al.Add(p);
                //                                    }
                //                                    break;
                //                                case 1:
                //                                    {
                //                                        Engineer p = new Engineer();
                //                                        p = (Engineer)p.Init();
                //                                        al.Add(p);
                //                                        p.Show();
                //                                    }
                //                                    break;
                //                            }
                //                        }
                //                        string name, special;
                //                        int division;
                //                        while (InputLine != "end")
                //                        {
                //                            Console.WriteLine
                //        (@"                Меню I части
                //    0 Вывод коллекции на экран
                //    1 Добавление объекта в конец коллекции
                //    2 Удаление первого вхождения заданного объекта
                //    3 Вывод всех инженеров
                //    4 Вывод кол-ва персон
                //    5 Вывод номера самого последнего(нового)подразделения к которому принадлежат объекты
                //    6 Перебор по foreach
                //    7 Клонирование коллекции
                //    8 Сортировка коллекции
                //    9 Поиск элемента в коллекции
                //    end для возврата в меню выбора части");
                //                            InputLine = Console.ReadLine();
                //                            int choice2 = int.Parse(InputLine);
                //                            switch (choice2)
                //                            {
                //                                case 0:
                //                                    {
                //                                        Engineer helpEn;
                //                                        Person helpPe;
                //                                        foreach (object a in al)
                //                                        {
                //                                            if (a.GetType() == typeof(Engineer))
                //                                            {
                //                                                helpEn = (Engineer)a;
                //                                                helpEn.Show();
                //                                            }
                //                                            if (a.GetType() == typeof(Person))
                //                                            {
                //                                                helpPe = (Person)a;
                //                                                helpPe.Show();
                //                                            }
                //                                        }
                //                                        Console.WriteLine(al.Count);
                //                                    }
                //                                    break;
                //                                case 1:
                //                                    {
                //                                        Console.WriteLine(@"Выберите класс объекта, который нужно добавить:
                //    1 Person
                //    2 Engineer");
                //                                        InputLine = Console.ReadLine();
                //                                        if (InputLine == "1")
                //                                        {
                //                                            Console.WriteLine("Введите имя и подразделение персоны:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            Person p1 = new Person(name, division);
                //                                            al.Add(p1);
                //                                        }
                //                                        if (InputLine == "2")
                //                                        {
                //                                            Console.WriteLine("Введите имя, подразделение и специализацию удаляемого инженера:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            special = Console.ReadLine();
                //                                            Engineer e1 = new Engineer(name, division, special);
                //                                            al.Add(e1);
                //                                        }
                //                                    }
                //                                    break;
                //                                case 2:
                //                                    {
                //                                        Console.WriteLine(@"Выберите класс объекта, который нужно удалить:
                //    1 Person
                //    2 Engineer");
                //                                        InputLine = Console.ReadLine();
                //                                        if (InputLine == "1")
                //                                        {
                //                                            Console.WriteLine("Введите имя и подразделение персоны:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            Person p1 = new Person(name, division);
                //                                            if (al.Contains(p1))
                //                                            {
                //                                                al.Remove(p1);
                //                                                Console.WriteLine("Объект удалён");
                //                                            }
                //                                            else
                //                                                Console.WriteLine("Этот объект не найден в коллекции");
                //                                        }
                //                                        if (InputLine == "2")
                //                                        {
                //                                            Console.WriteLine("Введите имя, подразделение и специализацию удаляемого инженера:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            special = Console.ReadLine();
                //                                            Engineer e1 = new Engineer(name, division, special);
                //                                            if (al.Contains(e1))
                //                                            {
                //                                                al.Remove(e1);
                //                                                Console.WriteLine("Объект удалён");
                //                                            }
                //                                            else
                //                                                Console.WriteLine("Этот объект не найден в коллекции");
                //                                        }
                //                                    }
                //                                    break;
                //                                case 3:
                //                                    {
                //                                        Engineer helpEn;
                //                                        foreach (object a in al)
                //                                        {
                //                                            if (a.GetType() == typeof(Engineer))
                //                                            {
                //                                                helpEn = (Engineer)a;
                //                                                helpEn.Show();
                //                                            }
                //                                        }
                //                                    }
                //                                    break;

                //                                case 4:
                //                                    {
                //                                        int k;
                //                                        k = 0;
                //                                        foreach (object a in al)
                //                                        {
                //                                            if (a.GetType() == typeof(Person))
                //                                            {
                //                                                k++;
                //                                            }
                //                                        }
                //                                        Console.WriteLine($"Найдено {k} персон");
                //                                    }
                //                                    break;
                //                                case 5:
                //                                    {
                //                                        int divi = 0;
                //                                        Engineer helpEn;
                //                                        Person helpPe;
                //                                        foreach (object a in al)
                //                                        {
                //                                            if (a.GetType() == typeof(Engineer))
                //                                            {
                //                                                helpEn = (Engineer)a;
                //                                                if (helpEn.Division > divi)
                //                                                {
                //                                                    divi = helpEn.Division;
                //                                                }
                //                                            }
                //                                            if (a.GetType() == typeof(Person))
                //                                            {
                //                                                helpPe = (Person)a;
                //                                                if (helpPe.Division > divi)
                //                                                {
                //                                                    divi = helpPe.Division;
                //                                                }
                //                                            }
                //                                        }
                //                                        Console.WriteLine($"Самый большой номер дивизий{divi}");
                //                                    }
                //                                    break;
                //                                case 6:
                //                                    {
                //                                        Console.WriteLine("Цикл фор ыч итак использовался для перебора элементов в запросах");
                //                                    }
                //                                    break;
                //                                case 7:
                //                                    {
                //                                        Console.WriteLine("Созданный клон имеет следующие объекты");
                //                                        ArrayList alc = (ArrayList)al.Clone();
                //                                        Engineer helpEn;
                //                                        Person helpPe;
                //                                        foreach (object a in alc)
                //                                        {
                //                                            if (a.GetType() == typeof(Engineer))
                //                                            {
                //                                                helpEn = (Engineer)a;
                //                                                helpEn.Show();
                //                                            }
                //                                            if (a.GetType() == typeof(Person))
                //                                            {
                //                                                helpPe = (Person)a;
                //                                                helpPe.Show();
                //                                            }
                //                                        }
                //                                    }
                //                                    break;
                //                                case 8:
                //                                    {
                //                                        Console.WriteLine("Сортировка по имени(A-Я):");
                //                                        al.Sort();
                //                                        Console.WriteLine("коллекция отсортированная");
                //                                        foreach (Person p in al)
                //                                            p.Show();
                //                                    }
                //                                    break;
                //                                case 9:
                //                                    {
                //                                        Console.WriteLine(@"Выберите класс объекта, который нужно вывести на экран:
                //    1 Person
                //    2 Engineer");
                //                                        InputLine = Console.ReadLine();
                //                                        if (InputLine == "1")
                //                                        {
                //                                            int n;
                //                                            n = -1;
                //                                            Console.WriteLine("Введите имя и подразделение персоны:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            Person p1 = new Person(name, division);
                //                                            n = al.IndexOf(p1);
                //                                            if (n != -1)
                //                                                Console.WriteLine("Этот объект есть в коллекции");
                //                                            else
                //                                                Console.WriteLine("Этот объект не найден в коллекции");
                //                                        }
                //                                        if (InputLine == "2")
                //                                        {
                //                                            int n;
                //                                            n = -1;
                //                                            Console.WriteLine("Введите имя, подразделение и специализацию удаляемого инженера:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            special = Console.ReadLine();
                //                                            Engineer e1 = new Engineer(name, division, special);
                //                                            n = al.IndexOf(e1);
                //                                            if (n != -1)
                //                                                Console.WriteLine("Этот объект есть в коллекции");
                //                                            else
                //                                                Console.WriteLine("Этот объект не найден в коллекции");
                //                                        }
                //                                    }
                //                                    break;
                //                            }
                //                            Console.WriteLine("Действие выполнено, нажмите Enter для возврата в меню...");
                //                            Console.ReadLine();
                //                            Console.Clear();
                //                        }
                //                    }
                //                    break;
                //                case 2:
                //                    {
                //                        Stack<object> st = new Stack<object>(10);
                //                        Console.WriteLine("Созданный массив(люди и инженеры):");
                //                        int randonum;
                //                        for (int ii = 0; ii < 10; ii++)
                //                        {
                //                            randonum = rond.Next(2);
                //                            switch (randonum)
                //                            {
                //                                case 0:
                //                                    {
                //                                        Person p = new Person();
                //                                        p = (Person)p.Init();
                //                                        p.Show();
                //                                        st.Push(p);
                //                                    }
                //                                    break;
                //                                case 1:
                //                                    {
                //                                        Engineer p = new Engineer();
                //                                        p = (Engineer)p.Init();
                //                                        st.Push(p);
                //                                        p.Show();
                //                                    }
                //                                    break;
                //                            }
                //                        }
                //                        string name, special;
                //                        int division;
                //                        while (InputLine != "end")
                //                        {
                //                            Console.WriteLine
                //            (@"                Меню II части
                //    0 Вывод коллекции на экран
                //    1 Добавление объекта в конец коллекции
                //    2 Удаление первого вхождения заданного объекта
                //    3 Вывод всех инженеров
                //    4 Вывод кол-ва персон
                //    5 Вывод номера самого последнего(нового)подразделения к которому принадлежат объекты
                //    6 Перебор по foreach
                //    7 Клонирование коллекции
                //    8 Сортировка коллекции
                //    9 Поиск элемента в коллекции
                //    end для возврата в меню выбора части");
                //                            InputLine = Console.ReadLine();
                //                            int choice2 = int.Parse(InputLine);
                //                            switch (choice2)
                //                            {
                //                                case 0:
                //                                    {
                //                                        Engineer helpEn;
                //                                        Person helpPe;
                //                                        foreach (object a in st)
                //                                        {
                //                                            if (a.GetType() == typeof(Engineer))
                //                                            {
                //                                                helpEn = (Engineer)a;
                //                                                helpEn.Show();
                //                                            }
                //                                            if (a.GetType() == typeof(Person))
                //                                            {
                //                                                helpPe = (Person)a;
                //                                                helpPe.Show();
                //                                            }
                //                                        }
                //                                        Console.WriteLine($"Количество объектов {st.Count}");
                //                                    }
                //                                    break;
                //                                case 1:
                //                                    {
                //                                        Console.WriteLine(@"Выберите класс объекта, который нужно добавить:
                //    1 Person
                //    2 Engineer");
                //                                        InputLine = Console.ReadLine();
                //                                        if (InputLine == "1")
                //                                        {
                //                                            Console.WriteLine("Введите имя и подразделение персоны:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            Person p1 = new Person(name, division);
                //                                            try
                //                                            {
                //                                                st.Push(p1);
                //                                            }
                //                                            catch
                //                                            {
                //                                                Console.WriteLine("Этот объект не найден в коллекции");
                //                                            }
                //                                        }
                //                                        if (InputLine == "2")
                //                                        {
                //                                            Console.WriteLine("Введите имя, подразделение и специализацию удаляемого инженера:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            special = Console.ReadLine();
                //                                            Engineer e1 = new Engineer(name, division, special);
                //                                            st.Push(e1);
                //                                        }
                //                                    }
                //                                    break;
                //                                case 2:
                //                                    {
                //                                        if (st.Count > 0)
                //                                        {
                //                                            st.Pop();
                //                                            Console.WriteLine("Удалён объект расположенный в вершине стека");
                //                                        }
                //                                        else
                //                                            Console.WriteLine("В стеке нет объектов");
                //                                    }
                //                                    break;
                //                                case 3:
                //                                    {
                //                                        Engineer helpEn;
                //                                        foreach (object a in st)
                //                                        {
                //                                            if (a.GetType() == typeof(Engineer))
                //                                            {
                //                                                helpEn = (Engineer)a;
                //                                                helpEn.Show();
                //                                            }
                //                                        }
                //                                    }
                //                                    break;

                //                                case 4:
                //                                    {
                //                                        int k;
                //                                        k = 0;
                //                                        foreach (object a in st)
                //                                        {
                //                                            if (a.GetType() == typeof(Person))
                //                                            {
                //                                                k++;
                //                                            }
                //                                        }
                //                                        Console.WriteLine($"Найдено {k} персон");
                //                                    }
                //                                    break;
                //                                case 5:
                //                                    {
                //                                        int divi = 0;
                //                                        Engineer helpEn;
                //                                        Person helpPe;
                //                                        foreach (object a in st)
                //                                        {
                //                                            if (a.GetType() == typeof(Engineer))
                //                                            {
                //                                                helpEn = (Engineer)a;
                //                                                if (helpEn.Division > divi)
                //                                                {
                //                                                    divi = helpEn.Division;
                //                                                }
                //                                            }
                //                                            if (a.GetType() == typeof(Person))
                //                                            {
                //                                                helpPe = (Person)a;
                //                                                if (helpPe.Division > divi)
                //                                                {
                //                                                    divi = helpPe.Division;
                //                                                }
                //                                            }
                //                                        }
                //                                        Console.WriteLine($"Максимальный номер дивизии равен {divi}");
                //                                    }
                //                                    break;
                //                                case 6:
                //                                    {
                //                                        Console.WriteLine("Цикл фор ыч итак использовался для перебора элементов в запросах");
                //                                    }
                //                                    break;
                //                                case 7:
                //                                    {
                //                                        Console.WriteLine("Стек не клонируется!!!");
                //                                    }
                //                                    break;
                //                                case 8:
                //                                    {
                //                                        Console.WriteLine("Стек не сортируется!!!");
                //                                    }
                //                                    break;
                //                                case 9:
                //                                    {
                //                                        Console.WriteLine(@"Выберите класс объекта, который нужно вывести на экран:
                //    1 Person
                //    2 Engineer");
                //                                        InputLine = Console.ReadLine();
                //                                        if (InputLine == "1")
                //                                        {
                //                                            bool n;
                //                                            n = false;
                //                                            Console.WriteLine("Введите имя и подразделение персоны:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            Person p1 = new Person(name, division);
                //                                            n = st.Contains(p1);
                //                                            if (n)
                //                                                Console.WriteLine("Этот объект есть в коллекции");
                //                                            else
                //                                                Console.WriteLine("Этот объект не найден в коллекции");
                //                                        }
                //                                        if (InputLine == "2")
                //                                        {
                //                                            bool n;
                //                                            n = false;
                //                                            Console.WriteLine("Введите имя, подразделение и специализацию удаляемого инженера:");
                //                                            name = Console.ReadLine();
                //                                            InputLine = Console.ReadLine();
                //                                            division = int.Parse(InputLine);
                //                                            special = Console.ReadLine();
                //                                            Engineer e1 = new Engineer(name, division, special);
                //                                            n = st.Contains(e1);
                //                                            if (n)
                //                                                Console.WriteLine("Этот объект есть в коллекции");
                //                                            else
                //                                                Console.WriteLine("Этот объект не найден в коллекции");
                //                                        }
                //                                    }
                //                                    break;
                //                            }
                //                            Console.WriteLine("Действие выполнено, нажмите Enter для возврата в меню...");
                //                            Console.ReadLine();
                //                            Console.Clear();
                //                        }
                //                    }
                //                    break;
                //                case 3:
                //                    {
                //                        TestCollections TC1 = new TestCollections(1000);
                //                        Console.WriteLine("Ура, программа работает");
                //                        while (InputLine != "Stop")
                //                        {
                //                            Console.Write(@"         Меню функций программы
                //    1 Добавление элемента
                //    2 Удаление элемента
                //    3 Вывод коллекций
                //    4 Поиск элемента
                //    Stop для остановки работы программы
                //    Выбор:");
                //                            InputLine = Console.ReadLine();
                //                            switch (InputLine)
                //                            {
                //                                case "1":
                //                                    {
                //                                        Console.WriteLine("Введите информацию необходимую для создания объекта-инженера");
                //                                        Inpute(out Engineer e);
                //                                        TestCollections.Addd(TC1, e);
                //                                    }
                //                                    break;
                //                                case "2":
                //                                    {
                //                                        Console.WriteLine("Введите информацию об объекте инженере, который надо удалить");
                //                                        Inpute(out Engineer e);
                //                                        TestCollections.Deleteo(TC1, e);
                //                                    }
                //                                    break;
                //                                case "3":
                //                                    {
                //                                        TC1.ShowCollections();
                //                                    }
                //                                    break;
                //                                case "4":
                //                                    {
                //                                        while (InputLine != "end.")
                //                                        {
                //                                            Console.Write
                //(@"             Выберите какие именно объекты нужно найти объекты
                //    1 Первый
                //    2 Средний
                //    3 Последний
                //    4 не существующий 
                //    end. Для возврата в меню демонстрации части III
                //    Выбор:");
                //                                            InputLine = Console.ReadLine();
                //                                            switch (InputLine)
                //                                            {
                //                                                case "1":
                //                                                    TC1.FindFirst();
                //                                                    break;
                //                                                case "2":
                //                                                    TC1.Findmid();
                //                                                    break;
                //                                                case "3":
                //                                                    TC1.Findlast();
                //                                                    break;
                //                                                case "4":
                //                                                    TC1.FindNonContained();
                //                                                    break;
                //                                            }
                //                                        }
                //                                    }
                //                                    break;
                //                            }

                //                        }
                //                    }
                //                    break;
                //            }
                //            Console.WriteLine("Завершение работы программы...");
                //        }
                //    }
                //}
                #endregion
                static void Check(out int num)
                {
                    try
                    {
                        string InputLine = Console.ReadLine();
                        num = int.Parse(InputLine);
                    }
                    catch
                    {
                        Console.WriteLine("Введён симбол, введите ещё раз");
                        Check(out num);
                    }
                }
                //static void Inpute(out Engineer e)
                //{
                //    string name, spec;
                //    int div;
                //    Console.Write("Имя:");
                //    name = Console.ReadLine();
                //    Console.Write("Подразделение:");
                //    Check(out div);
                //    Console.Write("Специализация:");
                //    spec = Console.ReadLine();
                //    e = new Engineer(name, div, spec);
                //}
    }
}