using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Decoration
    {
        bool haveDecor;
        string backColor;

        public Decoration()
        {
            this.haveDecor = false;
            this.backColor = "white";
        }

        public Decoration(bool dec, string color)
        {
            this.haveDecor = dec;
            this.backColor = color;
        }

        public bool Decor
        {
            get { return haveDecor; }
            set { haveDecor = value; }
        }

        public string Color
        {
            get { return backColor; }
            set { backColor = value; }
        }

        public override string ToString()
        {
            string str = "Есть ли декор: " + Decor + "\tЗадний фон: " + Color;
            return str;
        }
    }
}
