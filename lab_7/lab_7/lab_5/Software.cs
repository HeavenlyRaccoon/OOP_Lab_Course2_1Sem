using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Software
    {
        public Software()
        {
            list = new List<object>();
        }
        List<object> list;

        public object this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(object obj)
        {
            list.Add(obj);
        }

        public void Remove(object obj)
        {
            list.Remove(obj);
        }

        public void ShowInfo()
        {
            foreach(var i in list)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
