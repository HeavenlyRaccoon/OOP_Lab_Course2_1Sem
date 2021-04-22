using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Control
    {
        static int countControl = 0;
        public Control()
        {
            countControl++;
        }

        public virtual void type()
        {
            Console.WriteLine("Элементы управления");
        }
    }
}
