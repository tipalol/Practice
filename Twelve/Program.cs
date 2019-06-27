using System;
using System.Linq;

namespace Twelve
{
    class MainClass
    {
        static int[] CountSort(int[] inputArray)
        {
            int refChangeCount = 0;
            int comparingCount = 0;

            int[] countArray = new int[inputArray.Max() + 1];
            for (int i = 0; i < inputArray.Length; i++)
            {
                countArray[inputArray[i]]++;
                refChangeCount++;
            }
            int[] sortedArray = new int[inputArray.Length];
            int sortedArrayIndex = 0;
            for (int i = countArray.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < countArray[i]; j++)
                {
                    sortedArray[sortedArrayIndex++] = i;
                    refChangeCount++;
                }
            }
            
            Console.WriteLine($"Кол-во присваиваний: {refChangeCount}");
            Console.WriteLine($"Кол-во сравнений: {comparingCount}");
            return sortedArray;
        }
        static int add2pyramid(int[] array, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (array[2 * i + 1] < array[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (array[i] < array[imax])
            {
                buf = array[i];
                array[i] = array[imax];
                array[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }
        static int[] PyramidSort(int[] array, int size)
        {
            int refChangeCount = 0;
            int comparingCount = 0;

            //Строим пирамиду
            for (int i = size / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                refChangeCount++;
                i = add2pyramid(array, i, size);
                comparingCount += 4;
                refChangeCount += 5;
                if (prev_i != i) ++i;
                comparingCount++;
            }

            //Сортируем
            int buf;
            for (int k = size - 1; k > 0; --k)
            {
                buf = array[0];
                array[0] = array[k];
                array[k] = buf;
                int i = 0, prev_i = -1;
                refChangeCount += 5;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(array, i, k);
                    refChangeCount += 2;
                    comparingCount += 4;
                    refChangeCount += 5;
                }
            }

            Console.WriteLine($"Кол-во присваиваний: {refChangeCount}");
            Console.WriteLine($"Кол-во сравнений: {comparingCount}");
            return null;
        }
        public static void Main(string[] args)
        {
            var random = new Random();
            string[] menuElements = {
                "Отсортировать методом подсчета",
                "Отсортировать пирамидальным методом"
            };
            var menu = new Menu(menuElements);
            const int size = 10;
            int[] first = { 0,1,2,3,4,7,7,7,7,7 },
                  second = { 9,8,7,6,5,4,3,2,1,0 },
                  third = new int[size];
            for (int i = 0; i < size; i++)
                third[i] = random.Next(0,11);

            Console.WriteLine("Упорядоченный по возрастанию массив:");
            foreach (int element in first)
                Console.Write($"{element} ");
            Console.WriteLine();
            Console.WriteLine("Упорядоченный по убыванию массив:");
            foreach (int element in second)
                Console.Write($"{element} ");
            Console.WriteLine();
            Console.WriteLine("Неупорядоченный массив:");
            foreach (int element in third)
                Console.Write($"{element} ");
            Console.WriteLine();

            int input = menu.GetChoose();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        int[] tmpCount = CountSort(first);
                        Console.WriteLine("Отсортированный упорядочненный по возрастанию массив:");
                        foreach (int element in tmpCount)
                            Console.Write($"{element} ");
                        Console.WriteLine();
                        tmpCount = CountSort(second);
                        Console.WriteLine("Отсортированный упорядочненный по убыванию массив:");
                        foreach (int element in tmpCount)
                            Console.Write($"{element} ");
                        Console.WriteLine();
                        tmpCount = CountSort(third);
                        Console.WriteLine("Отсортированный неупорядочненный:");
                        foreach (int element in tmpCount)
                            Console.Write($"{element} ");
                        Console.WriteLine();

                        break;
                    case 2:
                        int[] tmpPyramid = first;
                        PyramidSort(tmpPyramid, size);
                        Console.WriteLine("Отсортированный упорядочненный по возврастанию массив:");
                        foreach (int element in tmpPyramid)
                            Console.Write($"{element} ");
                        Console.WriteLine();
                        PyramidSort(tmpPyramid, size);
                        Console.WriteLine("Отсортированный упорядочненный по убыванию массив:");
                        foreach (int element in tmpPyramid)
                            Console.Write($"{element} ");
                        Console.WriteLine();
                        PyramidSort(tmpPyramid, size);
                        Console.WriteLine("Отсортированный неупорядочненный:");
                        foreach (int element in tmpPyramid)
                            Console.Write($"{element} ");
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();
                input = menu.GetChoose();
            }
        }
    }
}
