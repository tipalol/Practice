using System;

namespace Sixth
{
    class MainClass
    {
        static int a1, a2, a3;
        static int smth(int n)
        {
            if (n == 1) return a1;
            if (n == 2) return a2;
            if (n == 3) return a3;
            return 13 * smth(n - 1) - 10 * smth(n - 2) + smth(n - 3);

        }
        public static void Main(string[] args)
        {
            a1 = 0; a2 = 0; a3 = 0; int N = 0;
            try
            {
                Console.WriteLine("Введите а1");
                a1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите а2");
                a2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите а3");
                a3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите N");
                N = Convert.ToInt32(Console.ReadLine());
            } catch (Exception)
            {
                Console.WriteLine("Произошла ошибка при попытке считать число");
            }

            int[] a = new int[N+3];
            a[0] = a1; a[1] = a2; a[2] = a3;
            Console.Write($"{a1} {a2} {a3} ");
            bool isThereSubIcreasingArray = true;

            for (int i = 3; i < N; i++)
            {
                //Вычисляем следующий элемент последовательности
                a[i] = smth(i);
                //Выводим его
                Console.Write($"{a[i]} ");
                //Проверяем был ли этот элемент больше, чем предыдущий четный
                if (i % 2 != 0 && a[i] > a[i - 2])
                    isThereSubIcreasingArray = false;
            }
            if (!isThereSubIcreasingArray)
                Console.WriteLine("Четные элементы представляют собой возрастающую подпоследовательность");
            else
                Console.WriteLine("Четные элементы не представляют собой возрастающую подпоследовательность");
        }
    }
}
