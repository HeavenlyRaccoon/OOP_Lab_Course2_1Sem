using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Menu : Control
    {
        int countButton;
        int menuWidth;
        int menuHeight;
        int nesting;
        Button button;

        public Menu()
        {
            this.countButton = 0;
            this.menuWidth = 100;
            this.menuHeight = 20;
            this.button = new Button();
            this.nesting = 1;
        }

        public Menu(int button, int w, int h, string backColor, string buttonText, string textColor, int nes)
        {
            this.countButton = button;
            this.menuWidth = w;
            this.menuHeight = h;
            this.button = new Button(w, h / button, backColor, buttonText, textColor);
            this.nesting = nes;
        }

        public int CountButton
        {
            get { return countButton; }
            set { countButton = value; }
        }

        public int MenuWidth
        {
            get { return menuWidth; }
            set { menuWidth = value; }
        }

        public int MenuHeight
        {
            get { return menuHeight; }
            set { menuHeight = value; }
        }

        public int Nesting
        {
            get { return nesting; }
            set { nesting = value; }
        }

        public Button Button
        {
            get { return button; }
        }

        public override void type()
        {
            Console.WriteLine("Меню");
        }

        public override string ToString()
        {
            string str = "Размер меню: " + MenuWidth + "x" + MenuHeight + "\tКоличество кнопок: " + CountButton;
            return str;
        }
    }
}
