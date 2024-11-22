using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Task14._17
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = IntNumberInput("Введите количество первых натуральных чисел", 1, 100);            
            List<int> A = new List<int>(n);
            GenerateMas(n, out A);
            List<int> mas = new List<int> (n);
            //while (SortIterration(ref A, n))
            //    Show(1, A);
            SortThough(A, mas);
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

        public static List<int>  DecMas(List<int>  Mas,int m)
        {
            int n = Mas.Count();
            int i, j;
            List<int> Matr2 = new List <int>(n-1);
            for (i = 0; i < m; i++)
            {
                Matr2.Add(Mas[i]);
            }
            for (i=m+1;i<n;i++)
            {
                Matr2.Add(Mas[i]);
            }
            return Matr2;
        }
        static void swap(List <int> a, int i, int j)
        {
            int s = a[i];
            a[i] = a[j];
            a[j] = s;
        }
        static bool SortIterration(ref List<int>a,int n)
        {
            int j = n - 2;
            while (j != -1 && a[j] >= a[j + 1]) j--;
            if (j == -1)
                return false; // больше перестановок нет
            int k = n - 1;
            while (a[j] >= a[k]) k--;
            swap(a, j, k);
            int l = j + 1, r = n - 1; // сортируем оставшуюся часть последовательности
            while (l < r)
                swap(a, l++, r--);
            return true;
        }
        public static int SortThough(List<int> A,List<int>  resmas)
        {
            int result = 0;
            int i;
            int n = A.Count();
            List<int> B;
            if (n > 0)
            {
                if (n == 1)
                {
                    for (i = 0; i < resmas.Count; i++)
                        Console.Write($"{resmas[i]} ");
                    Console.WriteLine(A[0]);
                }
                else
                {
                    for (i = 0; i < n; i++)
                    {
                        List < int >resmas2= new List<int>(resmas);
                        resmas2.Add(A[i]);
                        B=DecMas(A,i);
                        SortThough(B,resmas2); 
                    }
                }
            }
            return result;
        }

        public static void GenerateMas(int n, out List<int> C)
        {
            // Задание матрицы
            List<int> Array = new List<int>(n);
            {
                Random rnd = new Random();
                // Заполнение матрицы случайными числами
                for (int i = n; i > 0 ; i--)
                        Array.Add(i);
                for (int i = 0; i < n; i++)
                        Console.Write("{0} ", Array[i]);
                C = Array;
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public static void Show(int n, List<int> C)
        {
            int a = 0;
            for (int i = 0; i < C.Count; i++)
                    Console.Write("{0} ", C[i]);
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Ввод целого числа с проверкой
        /// </summary>
        /// <param name="text">Комментарий</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns>Число</returns>
        public static int IntNumberInput(string text, int min, int max)
        {
            int number;
            Console.WriteLine(text);
            while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max)
            {
                Console.WriteLine("Не правильно введено число! Число должно быть больше или равно {0} и меньше или равно {1}", min, max);
            }
            return number;
        }
    }
}

