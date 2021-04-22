using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = new List<string>() {"Main","{","reTurn 0;","}"};
            Programmer programmer = new Programmer(arr);
            programmer.Del += Show;
            programmer.Del += delete;
            programmer.Del += Show;
            programmer.delete();
            programmer.Mode += low;
            programmer.Mode += reverse;
            programmer.Mode += Show;
            programmer.mode();

            Func<string,string> op;
            op = Up;
            string test = "te!st";
            test = op(test);
            Console.WriteLine(test);
            op = DelDot;
            test = op(test);
            Console.WriteLine(test);
        }

        public static void Show(ref List<string> Code)
        {
            Console.WriteLine("Код программиста: ");
            foreach (string i in Code)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        public static void delete(ref List<string> c)=> c.Remove(c.Last());
        public static void low (ref List<string> c)
        {
            for(int i = 0; i < c.Count; i++)
            {
                c[i] = c[i].ToLower();
            }
        }

        public static void reverse(ref List<string> c) => c.Reverse();
        static string Up(string str)
        {
            return str.ToUpper();
        }

        static string Low(string str)
        {
            return str.ToLower();
        }

        static string DelDot(string str)
        {
            string symbols = ".,!?";
            string str2="";
            foreach(char i in str)
            {
                if (!symbols.Contains(i))
                {
                    str2 += i;                }
                }
            return str2;
        }

    }
}
