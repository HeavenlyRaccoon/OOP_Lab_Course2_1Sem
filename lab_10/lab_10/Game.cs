using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lab_10
{
    class Game<T>:IEnumerable<T>
    {
        List<T> names;
        int version;
        string type;

        public Game()
        {
            names = new List<T>();
            version = 1;
            type = "default";
        }

        public Game(List<T> pname, int pversion=1, string ptype="default")
        {
            names = pname;
            version = pversion;
            type = ptype;
        }


        public void ShowInfo()
        {
            Console.Write("Названия:");
            foreach(T i in names)
            {
                Console.Write(" "+i);
            }
            Console.WriteLine($"; Версия: {version}; Жанр игры: {type}");
        }

        public IEnumerator GetEnumerator()
        {
            return names.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)names).GetEnumerator();
        }

        public void Add(T parm)
        {
            names.Add(parm);
        }

        public void Remove(T parm)
        {
            names.Remove(parm);
        }

        public void RemoveAt(int i)
        {
            names.RemoveAt(i);
        }
    }
}
