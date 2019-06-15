using System;
using System.IO;

namespace Second
{
    class MainClass
    {
        static int c(string s)
        {
            return Convert.ToInt32(s);
        }
        public static void Main()
        {
            var r = new StreamReader("INPUT.TXT");
            var w = new StreamWriter("OUTPUT.TXT");
            var ms = new int[] { 0, 31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            var inp = r.ReadLine().Split(' ');
            int bd = c(inp[0]);
            int bm = c(inp[1].Trim('0'));
            inp = r.ReadLine().Split(' ');
            r.Close();
            int d = c(inp[0]);
            int m = c(inp[1].Trim('0'));
            int y = c(inp[2]);
            int ds = 0;
            while (!(d == bd && m == bm))
            {
                int df;
                if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
                    df = 29;
                else
                    df = 28;
                int dm = 0;
                if (m == 2)

                    dm = df;
                else

                    dm = ms[m];

                if (d == 31 && m == 12)
                {
                    d = 1;
                    m = 1;
                    y++;
                }
                else if (d == dm)
                {
                    d = 1;
                    m++;
                }
                else

                    d++;

                ds++;
            }
            w.Write(ds);
            w.Close();
        }
    }
}
