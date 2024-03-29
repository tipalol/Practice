﻿using System;
using System.IO;

namespace First
{
    class MainClass
    {
        public static void Main()
        {
            int n = 0;
            int m = 0;
            int[,] a = new int[0,0];
            try
            {
                var input = new StreamReader("INPUT.TXT");
                string temp = input.ReadLine();
                n = Convert.ToInt32(temp.Split(' ')[0]);
                m = Convert.ToInt32(temp.Split(' ')[1]);
                a = new int[n, m];

                for (int i = 0; i < n; i++)
                {
                    temp = input.ReadLine();
                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = Convert.ToInt32( temp.Split(' ')[j] );
                    }
                }
                input.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при считывании данных с файла");
            }

            int[,] b = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (i == 0 && j == 0)
                        b[i, j] = a[i, j];
                    else if (i == 0) b[i, j] = a[i, j] + b[i, j - 1];
                    else if (j == 0) b[i, j] = a[i, j] + b[i - 1, j];
                    else b[i, j] = Math.Min(b[i-1,j], b[i,j-1]) + a[i,j];

            var output = new StreamWriter("OUTPUT.TXT");
            output.WriteLine(b[n-1,m-1]);
            Console.WriteLine(b[n - 1, m - 1]);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    output.Write($"{b[i, j]} ");
                    Console.Write($"{b[i, j]} ");
                }
                output.WriteLine();
                Console.WriteLine();
            }
            output.Close();
        }
    }
}
