using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    partial class Rectangle : Figure, Type
    {
        string color;
        int transparency;

        public Rectangle()
        {
            this.color = "white";
            this.transparency = 100;
        }

        public Rectangle(string col, int trans)
        {
            this.color = col;
            this.transparency = trans;
        }

        public string rectColor
        {
            get { return color; }
            set { color = value; }
        }

        public int Transparency
        {
            get { return transparency; }
            set { transparency = value; }
        }

        public void type()
        {
            Console.WriteLine("Прямоуголник");
        }
    }
}
