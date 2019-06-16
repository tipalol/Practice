using System;
using Eleven;

namespace Eighth
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu(null);
            Random random = new Random();
            int n = menu.GetInt("кол-во вершин");
            int[,] a_ = new int[n, n], b_ = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    a_[i, j] = random.Next(0, 10);
                    b_[i, j] = random.Next(0, 10);
                }
            Matrice a = new Matrice(a_);
            Matrice b = new Matrice(b_);

            Matrice c = b;

            Console.WriteLine("Генерация первой матрицы..");
            a.Print();
            Console.WriteLine("Генерация второй матрицы..");
            b.Print();
            Console.WriteLine("Генерация третьей матрицы, изоморфной к первой..");
            c.Print();

            Console.Write("Первая матрица изоморфна ко второй: ");
            Console.WriteLine(Matrice.isIsomorph(a, b));
            Console.Write("Первая матрица изоморфна к третьей: ");
            Console.WriteLine(Matrice.isIsomorph(b, c));

        }
    }
}
