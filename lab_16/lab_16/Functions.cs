using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace lab_16
{
    public static class Functions
    {
        public static void PrimeNum()
        {
            Console.WriteLine("-----------Search prime numbers-----------");
            Console.WriteLine("Enter number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> vs = new List<int>();
            for(int i = 2; i <= n; i++)
            {
                vs.Add(i);
            }

            for(int i = 0; i < vs.Count; i++)
            {
                int p = vs[i];
                for(int j = i+1; j < vs.Count; j++)
                {
                    if (vs[j] % p == 0)
                    {
                        vs.Remove(vs[j]);
                    }
                }
            }

            Console.WriteLine("Prime numbers: ");
            foreach(int i in vs)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }

        public static void PrimeNum(CancellationToken token)
        {
            Console.WriteLine("-----------Search prime numbers-----------");
            Console.WriteLine("Enter number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> vs = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                vs.Add(i);
            }

            for (int i = 0; i < vs.Count; i++)
            {
                int p = vs[i];
                for (int j = i + 1; j < vs.Count; j++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation break.");
                        return;
                    }
                    if (vs[j] % p == 0)
                    {
                        vs.Remove(vs[j]);
                    }
                }
            }

            Console.WriteLine("Prime numbers: ");
            foreach (int i in vs)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static int Rand()
        {
            Random random = new Random();
            int x = random.Next(0, 1000);
            return x;
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }

        public static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        public static void VFactorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {x} равен {result}");
        }

        public static async void VFactorialAsync()
        {
            Console.WriteLine("Начало метода VFactorialAsync");
            await Task.Run(() => VFactorial(4));
            Console.WriteLine("Конец метода VFactorialAsync");
        }

        public static int Mul(int x, int y, int z)
        {
            return x * y * z;
        }

        public static void generationArr(int x)
        {
            int[] arr = new int[100000];
            Random random = new Random();
            for (int i = 0; i < 100000; i++)
            {
                arr[i] = random.Next(0, 10000);
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}, Заполнился массив arr{x}");
            Console.WriteLine();
        }

        public static void Display()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        }
    }
}
