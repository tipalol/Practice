using System;

namespace Third
{
    class MainClass
    {
        public static void Main()
        {
            double x = 0;
            double y = 0;
            const int radius = 2;
            double result;
            try
            {
                Console.WriteLine("Введите координату х");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите координату y");
                y = Convert.ToDouble(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("Произошла ошибка при попытке распознать число.");
            }

            //Лежит ли точка в области с радиусом 2
            if ((Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= radius) && (y >= 0))
            {
                //Лежит ли точка в области круга с радусом 1
                if ((Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= 0.3))
                {
                    result = x;
                }
                else
                //Точка находится в заштрихованной области
                {
                    result = 0;
                }
            }
            else
            //Точка лежит вне круга с радиусом 2
            {
                result = x;
            }

            Console.WriteLine(result);
        }
    }
}
