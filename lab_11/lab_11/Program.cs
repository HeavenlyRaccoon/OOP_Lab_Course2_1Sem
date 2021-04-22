using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] month = { "June", "July", "May", "December", "January", "February", "March", "April", "August", "September", "October", "November" };
            string[] WS = { "June", "July", "December", "January", "February", "August" };
            var monthFour = from t in month
                            where t.Length == 4
                            select t;
            Show(monthFour, "Месяца с из 4 букв: ");

            var WinterAndSummer = from t in month
                                  where WS.Contains(t)
                                  select t;
            Show(WinterAndSummer, "Летние и зимние месяца: ");

            var sortMonth = from t in month
                            orderby t
                            select t;
            Show(sortMonth, "Отсортированный список: ");


            var last = (from t in month where (t.Length >= 4 && t.Contains("u")) select t).Count();
            Console.WriteLine($"Кол-во: {last}");

            void Show(IEnumerable<string> arr, string message)
            {
                Console.WriteLine(message);
                foreach (string s in arr)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }

            ////////////////////////////Второе задание//////////////////
            List<Time> times = new List<Time>();
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                times.Add(new Time(rand.Next(0, 24), rand.Next(0, 60), rand.Next(0, 60)));
                times[i].ShowTime();
            }

            var timesHour = times.Where(t => t.Hours == 13).Select(t => t);
            Console.WriteLine();
            foreach (var s in timesHour)
            {
                s.ShowTime();
            }
            Console.WriteLine();


            var timesGroup = from t in times
                             group t by t.Type;
            foreach (IGrouping<string, Time> g in timesGroup)
            {
                Console.WriteLine(g.Key);
                foreach (var i in g)
                {
                    i.ShowTime();
                }
                Console.WriteLine();
            }

            var min = times.OrderBy(t => t.Hours);
            min.First().ShowTime();
            Console.WriteLine();
            var adad = times.Where(t => t.Hours == t.Minutes).First();
            adad.ShowTime();

            Console.WriteLine();
            var sortTime = times.OrderBy(t=>t.Hours).ThenBy(t=>t.Minutes).ThenBy(t=>t.Seconds);
            foreach(var s in sortTime)
            {
                s.ShowTime();
            }
            Console.WriteLine();

            var task4 = times.Where(t => t.Minutes > 30).OrderBy(t => t.Hours).ThenBy(t => t.Minutes).GroupBy(t => t.Type).Reverse().Select(t => t);
            foreach (IGrouping<string, Time> g in task4)
            {
                Console.WriteLine(g.Key);
                foreach (var i in g)
                {
                    i.ShowTime();
                }
                Console.WriteLine();
            }

            List<Event> events = new List<Event>();
            events.Add(new Event(20, "Ужин"));
            events.Add(new Event(10, "Завтрак"));
            events.Add(new Event(15, "Обед"));

            var result = times.Join(events, t => t.Hours, p => p.Hours, (p, t) => new { Hours = p.Hours, Minutes = p.Minutes, Events = t.Events });
            foreach(var s in result)
            {
                Console.WriteLine($"Время: {s.Hours}:{s.Minutes}   Событие: {s.Events}");
            }
        }
    }
}
