using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    class Calculator
    {
        public void Sum(string a, string b)
        {
            Console.WriteLine(Convert.ToInt32(a) + Convert.ToInt32(b));
        }

        public void Div(string a, string b)
        {
            Console.WriteLine(Convert.ToInt32(a) / Convert.ToInt32(b));
        }
    }
}
