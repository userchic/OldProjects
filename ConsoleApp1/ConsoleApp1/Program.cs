using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество задач:");
            string InputLine = Console.ReadLine();
            int numberOfTasks = int.Parse(InputLine);
            List<List<int>> LinksTo = new List<List<int>>();
            for (int i = 0; i < numberOfTasks; i++)
                LinksTo.Add(new List<int>());
            List<List<int>> LinksFrom = new List<List<int>>();
            char[] space = new char[1];
            space[0] = ' ';
            Console.Write("Введите количество исполнителей:");
            InputLine = Console.ReadLine();
            int NumOfWorkers=int.Parse(InputLine);
            List<List<int>> WorkersWork = new List<List<int>>();
            for (int i = 0; i < NumOfWorkers; i++)
                WorkersWork.Add(new List<int>());
            for (int i = 0; i < numberOfTasks; i++)
            {
                LinksFrom.Add(new List<int>());
                Console.Write($"Введите ссылки идущие от {i+1} вершины:");
                InputLine=Console.ReadLine();
                if (InputLine != "")
                {
                    string[] InputedLinks = InputLine.Split(space);
                    for (int j = 0; j < InputedLinks.Length; j++)
                    {
                        LinksFrom[i].Add(int.Parse(InputedLinks[j])-1);
                        LinksTo[LinksFrom[i][LinksFrom[i].Count-1]].Add(i);
                    }
                }
            }
            List<int> NotAvailableTasks = new List<int>();
            for (int i = 0; i < numberOfTasks; i++)
                if (LinksTo[i].Count > 0)
                    NotAvailableTasks.Add(i);
            List<int> DoneTasks = new List<int>();
            List<int> AvailableTasks = new List<int>();
            for (int i = 0; i < numberOfTasks; i++)
                if (LinksTo[i].Count == 0)
                    AvailableTasks.Add(i);
            List<int> Priorities = new List<int>();
            for (int i = 0; i < numberOfTasks; i++)
                Priorities.Add(0);
            int Priority = 1;
            for (int i = 0; i < NotAvailableTasks.Count; i++)
            {
                Priorities[NotAvailableTasks[i]] = Priority;
                Priority++;
            }
            List<int> EndTasks = new List<int>();
            for (int i = 0; i < numberOfTasks; i++)
            {
                if (LinksFrom[i].Count == 0)
                    EndTasks.Add(i);
            }
            MakePriorities(ref Priorities, LinksTo,LinksFrom, EndTasks, ref Priority);
            if (NumOfWorkers > 1)
            {
                while (DoneTasks.Count != numberOfTasks)
                {
                    if (AvailableTasks.Count >= NumOfWorkers)
                    {
                        int numofWorker = 1;
                        for (int i = 0; i < NumOfWorkers; i++)
                        {
                            int minPriority = int.MaxValue;
                            for (int j = 0; j < AvailableTasks.Count; j++)
                            {
                                if (Priorities[AvailableTasks[j]] < minPriority)            //находим из доступных заданий задачу с максимальным приоритетом
                                    minPriority = j;
                            }
                            WorkersWork[numofWorker - 1].Add(AvailableTasks[minPriority]);    //делаем эту задачу работой очередного работника и признаём эту задачу выполненой
                            numofWorker++;
                            DoneTasks.Add(AvailableTasks[minPriority]);
                            for (int j = 0; j < LinksFrom[AvailableTasks[minPriority]].Count; j++)
                            {
                                //ссылки на точку(LinksTo) у тех точек, на которые идут ссылки у найденной точки с макс приоритетом удаляем
                                LinksTo[LinksFrom[AvailableTasks[minPriority]][j]].Remove(AvailableTasks[minPriority]);
                            }
                            //Наконец удаляем задачу из AvailableTasks
                            AvailableTasks.RemoveAt(minPriority);
                        }
                        for (int i=0;i<NotAvailableTasks.Count;i++)
                        {
                            if (LinksTo[NotAvailableTasks[i]].Count == 0)
                            {
                                AvailableTasks.Add(NotAvailableTasks[i]);
                                NotAvailableTasks.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    else
                    {
                        int numofWorker = 1;
                        for (int i = 0; i < AvailableTasks.Count; i++)
                        {
                            int minPriority = int.MaxValue;
                            for (int j = 0; j < AvailableTasks.Count; j++)
                            {
                                if (Priorities[AvailableTasks[j]] < minPriority)            //находим из доступных заданий задачу с максимальным приоритетом
                                    minPriority = j;
                            }
                            WorkersWork[numofWorker-1].Add(AvailableTasks[minPriority]);    //делаем эту задачу работой очередного работника и признаём эту задачу выполненой
                            numofWorker++;
                            DoneTasks.Add(AvailableTasks[minPriority]);
                            for (int j = 0; j < LinksFrom[AvailableTasks[minPriority]].Count; j++)
                            {
                                //ссылки на точку(LinksTo) у тех точек, на которые идут ссылки у найденной точки с макс приоритетом удаляем
                                LinksTo[LinksFrom[AvailableTasks[minPriority]][j]].Remove(AvailableTasks[minPriority]);
                            }
                            //Наконец удаляем задачу из AvailableTasks
                            AvailableTasks.RemoveAt(minPriority);
                            i--;
                        }
                        for (int i = numofWorker-1; i < NumOfWorkers; i++)
                            WorkersWork[i].Add(-1);
                        for (int i = 0; i < NotAvailableTasks.Count; i++)
                        {
                            if (LinksTo[NotAvailableTasks[i]].Count == 0)
                            {
                                AvailableTasks.Add(NotAvailableTasks[i]);
                                NotAvailableTasks.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                for (int i = 0; i < WorkersWork.Count; i++)
                {
                    Console.Write($"Работник {i+1}:");
                    for (int j = 0; j < WorkersWork[i].Count; j++)
                    {
                        Console.Write($"{WorkersWork[i][j]+1} ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.Write("Работник 1:");
                for (int i = 0; i < numberOfTasks; i++)
                {
                    WorkersWork[0].Add(Priorities.IndexOf(Priorities.Max()));
                    Console.Write($"{WorkersWork[0][WorkersWork.Count]+1} ");
                    Priorities.RemoveAt(WorkersWork[0][WorkersWork.Count]);
                }
            }
        }
        static void MakePriorities(ref List<int>Priorities,List<List<int>>LinksTo,List<List<int>> LinksFrom,List<int>EndTasks,ref int Priority)
        {
            if (EndTasks.Count > 0)
            {
                List<int> NextEndTasks = new List<int>();
                for (int i = 0; i < EndTasks.Count; i++)
                {
                    for (int j = 0; j < LinksTo[EndTasks[i]].Count; j++)
                    {
                        if (!NextEndTasks.Contains(LinksTo[EndTasks[i]][j]))
                            NextEndTasks.Add(LinksTo[EndTasks[i]][j]);
                    }
                }
                int minpriority = int.MaxValue;
                for (int i = 0; i < NextEndTasks.Count; i++)
                {
                    int minpriorityChanged = int.MaxValue;
                    int numofmin = 0;
                    for (int j=0;j<EndTasks.Count;j++)
                    {
                        if (Priorities[EndTasks[j]] < minpriorityChanged & minpriority < Priorities[EndTasks[j]])
                        {
                            minpriorityChanged = Priorities[EndTasks[j]];
                            numofmin=
                        }
                    }
                    minpriority = minpriorityChanged;
                    Priorities[NextEndTasks[i]] = Priority;
                    Priority++;
                }
                MakePriorities(ref Priorities, LinksTo,LinksFrom, NextEndTasks, ref Priority);
            }
        }
    }
}
