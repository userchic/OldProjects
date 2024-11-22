using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = choice();
            int n=NumberofNeededFibonNum();
            if (i == 1) 
            CountFibonNumbersWithRecursion(n);
            if (i == 2)
                CountFibonNumbersWithIterration(n);
        }
        static int choice()
        {
            Console.Write(@"Выберите способ расчёта чисел Фиббоначчи 
1. Рекурсивный расчёт
2. Итеративный расчёт
Ввод:");
            int i=0;
            while ((i != 1) & (i != 2))
            {
                Check(out i);
                if ((i != 1) & (i != 2))
                    Console.WriteLine("Ошибка, введите 1 или 2. \nВвод:");
            }
            return i;
        }
        static int NumberofNeededFibonNum()
        {
            int num;
            num = 0;
            Console.Write("Введите количество чисел Фиббоначи, которое нужно расчитатть\nВвод:");
            while (num <= 0)
            {
                Check(out num);
                if (num <= 0)
                    Console.WriteLine("Введено отрицательное число. Номер нужного числа Фиббоначи должен быть натуральным числом");
            }
            return num;
        }
        static void Check(out int num)
        {
            string InputLine=Console.ReadLine();
            bool buf=int.TryParse(InputLine,out num);
            while (!buf)
            {
                Console.WriteLine("Введено не число. Введите ещё раз \nВвод:");
                InputLine=Console.ReadLine();
                buf = int.TryParse(InputLine, out num);
            }
        }
        static void CountFibonNumbersWithRecursion(int num)
        {
            for (int i=1;i<=num;i++)
            Console.WriteLine(FibonNumber(i));
        }
        static int FibonNumber(int num)
        {
            if ((num == 1)||(num==2))
                return 1;
            return (FibonNumber(num - 1)+FibonNumber(num-2));
        }
        static void CountFibonNumbersWithIterration(int num)
        {
            if (num == 1)
                Console.WriteLine("1");
            if (num >= 2)
            {
                Console.WriteLine("1");
                Console.WriteLine("1");
            }
            if (num > 2)
            {
                Int64 num1 = 1;
                Int64 num2 = 1;
                for (int i= 2;i<num;i++)
                {
                    Int64 x = num1 + num2;
                    num1 = num2;
                    num2 = x;

                    Console.WriteLine(num2);
                }
            }
        }
    }
}
