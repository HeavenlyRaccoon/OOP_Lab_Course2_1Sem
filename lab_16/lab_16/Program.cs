using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;

namespace lab_16
{
    class Program
    {
        static void Main(string[] args)
        {
            //First task
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task firstTask = new Task(Functions.PrimeNum);
            firstTask.Start();
            Console.WriteLine($"CurrentId: {firstTask.Id};  Task work: {firstTask.Status}");
            firstTask.Wait();
            stopwatch.Stop();
            Console.WriteLine($"First task time: {stopwatch.Elapsed}");
            Console.ReadLine();


            //Second task
            Console.WriteLine();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            Task secondTask = new Task(()=>Functions.PrimeNum(tokenSource.Token));
            secondTask.Start();
            Console.WriteLine($"CurrentId: {secondTask.Id};  Task work: {secondTask.Status}");
            Thread.Sleep(4000);
            tokenSource.Cancel();
            secondTask.Wait();
            Console.ReadLine();


            //Third and fourth task
            Task<int> task1 = new Task<int>(Functions.Rand);
            task1.Start();
            int x = task1.Result;

            Task<int> task2 = task1.ContinueWith<int>(t => Functions.Sum(x, 19));
            int y = task2.Result;

            Task<int> task3 = task2.ContinueWith<int>(t => Functions.Factorial(4));
            var awaiter = task3.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int z = awaiter.GetResult();

                Task<int> task4 = new Task<int>(() => Functions.Mul(x,y,z));
                task4.Start();
                task4.Wait();
                Console.WriteLine($"MUL({x}, {y}, {z}) = {task4.Result}");
            });
            Console.ReadLine();


            //fifth task
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Parallel.For(1, 10, Functions.generationArr);
            stopwatch2.Stop();
            Console.WriteLine($"Fifth task time: {stopwatch2.Elapsed}");
            Console.ReadLine();


            //sixth task
            Parallel.Invoke(Functions.Display, () => { Console.WriteLine($"Выполняется задача {Task.CurrentId}"); });
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();


            //seventh task
            int count = 0;
            BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            for (int producer = 0; producer < 5; producer++)
            {
                Task.Factory.StartNew(() =>
                {
                    count++;
                    int id = count;
                    Console.WriteLine($"Produser {Task.CurrentId} add product {id}");
                    blockcoll.Add(id);
                });
            }

            for (int buyer = 0; buyer < 10; buyer++)
            {
                Task.Factory.StartNew(() =>
                {
                    int a;
                    if(blockcoll.TryTake(out a))
                    {
                        Console.WriteLine($"Buyer {Task.CurrentId} take product {a}");
                    }
                    else
                    {
                        Console.WriteLine($"Buyer {Task.CurrentId} leaves");
                    }
                });
            }
            Console.ReadLine();


            //task 8
            Functions.VFactorialAsync();
            Console.WriteLine("main");

            Console.ReadLine();
        }
    }
}
