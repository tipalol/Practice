using System;

namespace Third
{
    class MainClass
    {
        public static void Main()
        {
            double x = 0;
            double y = 0;
            const int radius = 1;
            double result;
            try
            {
                Console.WriteLine("Введите координату х");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите координату y");
                y = Convert.ToDouble(Console.ReadLine());
                
            } catch (FormatException)
            {
                Console.WriteLine("Произошла ошибка при попытке распознать число.");
            }

            //Лежит ли точка в области с радиусом 1
            if ((Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y,2) ) <= radius) && (y >= 0))
            {
                //Лежит ли точка в области круга с радусом 0.3
                if ((Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= 0.3) && x >= 0)
                {
                    result = Math.Sqrt(Math.Abs(x - 1));
                } else
                //Точка находится в заштрихованной области
                {
                    result = Math.Pow(x, 2) - 1;
                }
            } else
            //Точка лежит вне круга с радиусом 1
            {
                result = Math.Sqrt( Math.Abs(x - 1));
            }

            Console.WriteLine(result);
        }
    }
}
