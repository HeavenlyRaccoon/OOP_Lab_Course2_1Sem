using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace lab_15
{
    public static class PrimeNumbers
    {
        public static void Prime()
        {
            StreamWriter writer = new StreamWriter("result.txt");
            Console.WriteLine("Enter number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            bool check = false;
            for(int i = 0; i < n + 1; i++)
            {
                for(int j = 2; j < i; j++)
                {
                    if (i % j == 0) check = true;
                }

                if (!check) {
                    Console.Write(i + " ");
                    writer.Write(i + " ");
                }
                else check = false;
                Thread.Sleep(100);
            }
            writer.Close();
        }

        public static void Even(object p)
        {
            Parm parm = (Parm)p;
            for(int i = 1; i <= parm.n; i++)
            {
                if (i % 2 == 0)
                {
                    parm.writer.WriteLine(i);
                    Console.WriteLine(i);
                }
                Thread.Sleep(50);
            }
        }

        public static void Odd (object p)
        {
            Parm parm = (Parm)p;
            for (int i = 1; i <= parm.n; i++)
            {
                if (i % 2 != 0)
                {
                    parm.writer.WriteLine(i);
                    Console.WriteLine(i);
                }
                Thread.Sleep(50);
            }
        }

        public static void ShowTime(object obj)
        {
            Console.WriteLine($"Время на данный момент: {DateTime.Now}");
        }
    }
}
