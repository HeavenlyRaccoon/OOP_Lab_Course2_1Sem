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
            if (trans < 0 || trans >100 )
            {
                throw new RectangleExeption("Неверный диапазон прозрачности! (от 0 до 100)");
            }
            else{
                this.transparency = trans;
            }
            this.color = col;
            
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

    class RectangleExeption : ArgumentException
    {
        public RectangleExeption(string message):base(message)
        {

        }
    }
}
