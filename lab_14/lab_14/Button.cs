using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_14
{
    [Serializable]
    public sealed class Button : Config
    {
        public int buttonWidth;
        public int buttonHeight;
        public string backColor;
        public string text;
        public string textColor;

        public Button()
        {
            this.buttonWidth = 100;
            this.buttonHeight = 20;
            this.backColor = "white";
            this.text = "button";
            this.textColor = "black";
        }

        public Button(int w, int h, string back, string txt, string tcolor)
        {
            this.buttonWidth = w;
            this.buttonHeight = h;
            this.backColor = back;
            this.text = txt;
            this.textColor = tcolor;
        }

        public int ButtonWidth
        {
            get { return buttonWidth; }
            set { buttonWidth = value; }
        }

        public int ButtonHeight
        {
            get { return buttonHeight; }
            set { buttonHeight = value; }
        }

        public string BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        public override void type()
        {
            Console.WriteLine("Кнопка()");
        }




        public override void info()
        {
            Console.WriteLine("Размер кнопки: " + ButtonWidth + "x" + ButtonHeight + "\tТекст: " + Text);
        }

        public override string ToString()
        {
            string str = "Размер кнопки: " + ButtonWidth + "x" + ButtonHeight + "\tТекст: " + Text + "\tЦвет фона: " + BackColor + "\tЦвет текста: " + TextColor;
            return str;
        }
    }
}
