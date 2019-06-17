using System;
using System.IO;

namespace Second
{
    class MainClass
    {
        static int getInt(string s)
        {
            return Convert.ToInt32(s);
        }
        public static void Main()
        {
            var reader = new StreamReader("INPUT.TXT");
            var writer = new StreamWriter("OUTPUT.TXT");
            var daysInMonths = new int[] { 0, 31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            var input = reader.ReadLine().Split(' ');
            int bday = getInt(input[0]);
            int bmonth = getInt(input[1].Trim('0'));
            input = reader.ReadLine().Split(' ');
            reader.Close();
            int day = getInt(input[0]);
            int month = getInt(input[1].Trim('0'));
            int year = getInt(input[2]);
            int estimatedDays = 0;
            while (!(day == bday && month == bmonth))
            {
                int df;
                if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    df = 29;
                else
                    df = 28;
                int dm = 0;
                if (month == 2)

                    dm = df;
                else

                    dm = daysInMonths[month];

                if (day == 31 && month == 12)
                {
                    day = 1;
                    month = 1;
                    year++;
                }
                else if (day == dm)
                {
                    day = 1;
                    month++;
                }
                else

                    day++;

                estimatedDays++;
            }
            writer.Write(estimatedDays);
            writer.Close();
        }
    }
}
