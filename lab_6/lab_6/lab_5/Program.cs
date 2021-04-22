using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window(1024, 720, true, "pink");
            Figure figure = new Figure(4, true);
            Rectangle rectangle = new Rectangle("yellow", 45);
            Menu menu = new Menu(5, 120, 100, "Black", "Buttons", "gold",2);
            menu.Button.type();
            menu.Button.info();
            window.Control.type();
            rectangle.type();

            Software software = new Software();
            software.Add(window);
            software.Add(figure);
            software.Add(rectangle);
            software.ShowInfo();
            Console.WriteLine();
            software.Add(menu);
            software.Remove(figure);
            software.ShowInfo();


            Console.WriteLine((int)ErrorCode.ConnectionLost);
        }
    }

    public interface Type
    {
        void type();
    }

    public abstract class Config
    {
        bool visible = true;
        void increase(ref int w, ref int h)
        {
            w = w * 2;
            h = h * 2;
        }
        public abstract void info();
        public abstract void type();
    }

    class Printer
    {
        public void IAmPrinting(Type obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
            Console.WriteLine();
        }
    }

    enum ErrorCode
    {
        None = 0,
        Unknown = 1,
        ConnectionLost = 100,
        NotFound = 404
    }

    struct Admin 
    {
        string adminName;
        int password;

        public void addElement()
        {
            Console.WriteLine("Выберете элемент: ");
            Console.WriteLine("1. Окно\n2. Меню\n3. Кнопка");
            int n = Convert.ToInt32(Console.ReadLine());
        }
    }
}
