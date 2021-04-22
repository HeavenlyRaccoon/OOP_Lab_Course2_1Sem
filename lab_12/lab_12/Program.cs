using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    class Program:IEnumerable
    {
        public Program()
        {
            Console.WriteLine("Лол");
        }
        public Program(string AAAA)
        {

        }
        int nums;
        public string names;
        public int Nums { get; set; }
        public string Names { get; set; }
        private Program(int num) { }
        public void GetNums(int numss)
        {
            Console.WriteLine("What?");
        }
        public void GetString(string str)
        {
            Console.WriteLine("What?");
        }

        private void privateGetNums()
        {
            Console.WriteLine("Private What?");
        }

        static void Main(string[] args)
        {
            Reflector.GetAssemblyName(typeof(Program));
            Reflector.GetPublicCtor(typeof(Program));

            IEnumerable<string> methods = Reflector.getPublicMethod(typeof(Program));
            Console.WriteLine("Методы: ");
            foreach(string i in methods)
            {
                Console.WriteLine(i);
            }

            IEnumerable<string> props = Reflector.getProp(typeof(Program));
            Console.WriteLine("\nПоля и Свойства");
            foreach (string i in props)
            {
                Console.WriteLine(i);
            }

            IEnumerable<string> inter = Reflector.getI(typeof(Program));
            Console.WriteLine("\nРеализуемые интерфейсы: ");
            foreach (string i in inter)
            {
                Console.WriteLine(i);
            }

            Reflector.getMethodsByType(typeof(Program));

            Reflector.GetClassInvoke("lab_12.Calculator", "Sum", "in.txt");
            Reflector.GetClassInvoke("lab_12.Calculator", "Div", "in.txt");
            Car obj = (Car)Reflector.CreateType("lab_12.Car");
            
        }
    }

    internal interface IEnumerable
    {
    }

    class Car
    {
        string name;
        public Car()
        {
            name = "CAR";
        }
        public Car(string n)
        {
            name = n;
        }
    }
}
