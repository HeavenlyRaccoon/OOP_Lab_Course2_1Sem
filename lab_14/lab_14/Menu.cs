using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_14
{
    [Serializable]
   public class Menu : Control
    {
        public int countButton;
        public int menuWidth;
        public int menuHeight;
        public Button button;

        public Menu()
        {
            this.countButton = 0;
            this.menuWidth = 100;
            this.menuHeight = 20;
            this.button = new Button();
        }

        public Menu(int button, int w, int h, string backColor, string buttonText, string textColor)
        {
            this.countButton = button;
            this.menuWidth = w;
            this.menuHeight = h;
            this.button = new Button(w, h / button, backColor, buttonText, textColor);
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

        public Button Button
        {
            get { return button; }
            set { button = value; }
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
