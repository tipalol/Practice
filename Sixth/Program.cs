using System;

namespace Sixth
{
    class MainClass
    {
        /// <summary>
        /// Вычисляет следующий элемент последовательности
        /// </summary>
        /// <param name="a1">Предыдущий элемент последовательности</param>
        /// <param name="a2">Элемент, стоящий перед предыдущим</param>
        /// <param name="a3">Элемент перед <paramref name="a3"/></param>
        /// <returns></returns>
        static int Function(int a1, int a2, int a3) => 13 * a1 - 10 * a2 + a3;
        public static void Main(string[] args)
        {
            int a1 = 0, a2 = 0, a3 = 0, N = 0;
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
            } catch (FormatException)
            {
                Console.WriteLine("Произошла ошибка при попытке считать число");
            }

            int[] a = new int[N];
            a[0] = a1; a[1] = a2; a[2] = a3;
            Console.Write($"{a1} {a2} {a3}");
            bool isThereSubIcreasingArray = true;

            for (int i = 3; i < N; i++)
            {
                //Вычисляем следующий элемент последовательности
                a[i] = Function(a[i - 1], a[i - 2], a[i - 3]);
                //Выводим его
                Console.Write($"{a[i]} ");
                //Проверяем был ли этот элемент больше, чем предыдущий четный
                if (i % 2 == 0 && a[i] > a[i - 2])
                    isThereSubIcreasingArray = false;
            }


        }
    }
}
