using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    partial class Rectangle
    {
        public override string ToString()
        {
            string str = "Цвет прямоугольника: " + Color + "\tПрозрачность: " + Transparency + '%';
            return str;
        }
    }
}
