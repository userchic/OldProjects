using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
@"                 Считатель чисел Фиббоначи
1. Рекурсивный вариант
2. Итерационный вариант
Ввод:");
            int choice=0;
            while ((choice != 1) && (choice != 2))
            {
                Check(out choice);
                if ((choice != 1) && (choice != 2))
                    Console.WriteLine("Неправильный выбор. Введите 1 или 2");
            }
            int number1 = 1;
            int number2 = 1;
            Console.WriteLine("Введите количество чисел Фиббоначи, которые нужно вычислить выбранным способом\nВвод:");
            int num=0;
            Check(out num);
            while (num <= 0)
            {
                Console.WriteLine("Введено отрицательное число или 0. Введите ещё раз положительное число\n Ввод:");
                Check(out num);
            }
            if (num == 1)
                Console.WriteLine("1");
            if (num == 2)
            {
                Console.WriteLine("1");
                Console.WriteLine("1");
            }
            if (num > 2)
            {
                if (choice == 1)
                    Recursion(number1, number2, num - 2);
                if (choice == 2)
                {
                    for (int i = 0; i < num - 2; i++)
                    {
                        Itteration(ref number1, ref number2);
                    }
                }
            }
        }
        static void Check(out int num)
        {
            string str = Console.ReadLine();
            bool buf = int.TryParse(str, out num);
            while (buf == false)
            {
                Console.WriteLine("Неверный формат входных данных.Введите ещё раз\n Ввод");
                str = Console.ReadLine();
            }
            num = int.Parse(str);
        }
        static void Recursion(int num1,int num2,int num)
        {
            CountNewNumber(ref num1, ref num2);
            Console.WriteLine(num2);
            num--;
            if (num > 0)
                Recursion(num1, num2, num);
        }
        static void Itteration(ref int num1,ref int num2)
        {
            CountNewNumber(ref num1, ref num2);
            Console.WriteLine(num2);
        }
        static void CountNewNumber(ref int num1,ref int num2)
        {
            int x = num2;
            num2 = num1 + num2;
            num1 = x;
        }
    }
}
