using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> { "NoManSky", "Ksp", "RimWorld" };
            Game<string> game = new Game<string>(names, 5, "space");
            game.ShowInfo();
            names = new List<string> { "Cs", "CoD", "TF" };
            Game<string> game1 = new Game<string>(names, 3, "shooter");
            game1.ShowInfo();
            BlockingCollection<Game<string>> bc = new BlockingCollection<Game<string>>(2);
            bc.Add(game);
            Console.WriteLine(bc.Count);
            bc.Add(game1);
            Console.WriteLine(bc.Count);
            bc.TryTake(out game1);
            Console.WriteLine(bc.Count);

            //Вывод коллекции
            foreach (string i in game)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            game.Add("asdad");
            game.Add("bobo");
            game.Remove("bobo");
            game.RemoveAt(1);
            foreach (string i in game)
            {
                Console.WriteLine(i);
            }

            ObservableCollection<Game<string>> observ = new ObservableCollection<Game<string>>
            {
                game
            };
            observ.CollectionChanged += ObsChange;
            observ.Add(game1);
            observ.Remove(game1);
        }

        public static void ObsChange(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Объект {obj.GetType()} вызвал событие при добавлении");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Объект {obj.GetType()} вызвал событие при удалении");
                    break;
                default:
                    break;
            }
        }
    }
}
