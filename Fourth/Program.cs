using System;

namespace Fourth
{
    class MainClass
    {
        //Данная функция
        static double Function(double x) => Math.Pow(x, 3) - 0.2 * Math.Pow(x, 2) - 0.2 * x - 1.2;
        public static void Main()
        {
            //Границы отрезка
            double a = 1d;
            double b = 1.5d;
            double c;

            Console.WriteLine("Введите необходимую точность");
            double epsilon = Convert.ToDouble(Console.ReadLine());
            double result;

            double fa = Function(a);
            double fc;

            do
            {
                c = (a + b) / 2;
                fc = Function(c);
                if (fa * fc < 0.0)
                    b = c;
                else
                {
                    a = c;
                    fa = fc;
                }
            } while (Math.Abs(a-b) >= epsilon);
            result = (a + b) / 2;

            Console.WriteLine($"Полученный корень: {result} с точностью равной {epsilon}");
        }
    }
}
