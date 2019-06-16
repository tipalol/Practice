using System;
using Eleven;
namespace Eighth
{
    public class Matrice
    {
        Menu menu = new Menu(null);
        int[,] Elements { get; set; }
        int Size {
            get
            {
                return (int)Math.Sqrt(Elements.Length);
            }
        }
        public int this[int index, int index2]
        {
            get
            {
                return Elements[index, index2];
            }
            set
            {
                Elements[index, index2] = value;
            }
        }
        public void interchange(int i, int j)
        {
            for (int k = 0; k < Size; k++)
            {
                int temp = Elements[i - 1, k];
                Elements[i - 1, k] = Elements[j - 1, k];
                Elements[j - 1, k] = temp;
            }
        }
        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine($"Строка номер {i+1}");
                for (int j = 0; j < Size; j++)
                    Console.Write($"{Elements[i,j]} ");
                Console.WriteLine();
            }
        }
        static bool IsIt(Matrice a, Matrice b)
        {
            bool result = true;
            for (int i = 0; i < a.Size; i++)
                for (int j = 0; j < a.Size; j++)
                    if (a[i, j] != b[i, j])
                        result = false;
            return result;
        }
        
        public static bool isIsomorph(Matrice a, Matrice b)
        {
            bool result = false;
            int size = a.Size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (IsIt(a,b))
                    {
                        result = true;
                        return result;
                    }
                    a.interchange(i+1, j+1);
                }
                if (IsIt(a, b))
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }
        public Matrice(int rang)
        {
            Elements = new int[rang, rang];
            for (int i = 0; i < rang; i++)
            {
                for (int j = 0; j < rang; j++)
                {
                    Elements[i, j] = menu.GetInt($"элемент матрицы смежности в {i} строке, в {j} столбце");
                }
            }
        }
        public Matrice(int[,] matrice)
        {
            Elements = matrice;
            
        }
    }
}
