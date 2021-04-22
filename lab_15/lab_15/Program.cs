using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
namespace lab_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process: ");
            foreach(Process process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}, Priority:{process.BasePriority}, Start time: {process.StartTime}, Time process: {process.TotalProcessorTime}");
                }
                catch (Exception)
                {

                    Console.WriteLine($"{process.ProcessName} access is denied");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("Domain: ");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}, Base Directory: {domain.BaseDirectory}\n");
            Console.WriteLine("Loaded assemblies: ");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach(Assembly assembly in assemblies)
            {
                Console.WriteLine(assembly.GetName().Name);
            }


            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            newDomain.Load("lab_15");
            Console.WriteLine($"\nUploaded assemblies of the second domain: ");
            Assembly[] assemblies2 = newDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies2)
            {
                Console.WriteLine(assembly.GetName().Name);
            }
            AppDomain.Unload(newDomain);

            Console.ReadLine();
            Thread th2 = new Thread(PrimeNumbers.Prime) {Name="TH2" };
            th2.Start();
            Thread.Sleep(3000);
            th2.Suspend();
            Console.Write($"||Name: {th2.Name}, Status: {th2.ThreadState}, Priority: {th2.Priority}|| ");
            Thread.Sleep(4000);
            th2.Resume();
            th2.Join();

            Console.ReadLine();
            //Task 4
            Console.WriteLine("\nEnter number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            StreamWriter writer = new StreamWriter("res.txt");
            Parm parm = new Parm(n, writer);
            Thread thEven = new Thread(new ParameterizedThreadStart(PrimeNumbers.Even)) { Priority=ThreadPriority.Highest };
            Thread thOdd = new Thread(new ParameterizedThreadStart(PrimeNumbers.Odd)) { Priority = ThreadPriority.Highest };
            thEven.Start(parm);
            thOdd.Start(parm);
            thEven.Join();
            thOdd.Join();
            writer.Close();

            Console.ReadLine();
            TimerCallback tm = new TimerCallback(PrimeNumbers.ShowTime);
            Timer timer = new Timer(tm, 0, 0, 1000);
            Console.ReadLine();
        }
    }

    class Parm
    {
        public int n;
        public StreamWriter writer;
        public Parm(int pn, StreamWriter pwriter)
        {
            n = pn;
            writer = pwriter;
        }
    }
}
