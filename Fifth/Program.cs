using System;

namespace Fifth
{
    class MainClass
    {
        public static void Main()
        {
            var random = new Random();
            const int rang = 9;
            int[,] matrice = new int[rang,rang], result = new int[rang, rang];


            Console.WriteLine("Исходная матрица:");
            //Генерируем матрицу с помощью генератора случайных чисел
            //и выводим матрицу на экран
            for (int i = 0; i < rang; i++)
            {
                for (int j = 0; j < rang; j++)
                {
                    matrice[i, j] = random.Next(0,10);
                    Console.Write(matrice[i,j] + " ");
                }
                Console.WriteLine();
            }

            //Формируем требуемую матрицу
            for (int i = 0; i < rang; i++)
            {
                for (int j = 0; j < rang; j++)
                    if (matrice[i, j] > matrice[i, i])
                        result[i, j] = 1;
                    else
                        result[i, j] = 0;
            }

            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < rang; i++)
            {
                for (int j = 0; j < rang; j++)
                    Console.Write($"{result[i,j]} ");
                Console.WriteLine();
            }
        }
    }
}
