using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Figure : Decoration
    {
        int angles;
        bool stroke;

        public Figure()
        {
            this.angles = 0;
            this.stroke = false;
        }

        public Figure(int ang, bool str)
        {
            this.angles = ang;
            this.stroke = str;
        }

        public int Angles
        {
            get { return angles; }
            set { angles = value; }
        }

        public bool Stroke
        {
            get { return stroke; }
            set { stroke = value; }
        }

        public override string ToString()
        {
            string str = "Количество углов: " + Angles + "\tЕсть ли обводка: " + Stroke;
            return str;
        }
    }
}
