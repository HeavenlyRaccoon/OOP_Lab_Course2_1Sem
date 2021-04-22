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
            Menu menu = new Menu(5, 120, 100, "Black", "Buttons", "gold");
            menu.Button.type();
            menu.Button.info();
            window.Control.type();
            rectangle.type();
            Type obj = rectangle as Type;
            Config obj4 = new Button();
            if (obj != null)
            {
                Console.WriteLine("Объект rectangle реализует интерфейс Type");
                obj.type();
                Console.WriteLine();
            }
            else Console.WriteLine("Объект не реализует интерфейс Type\n");
            obj = window as Type;
            if (obj != null)
            {
                Console.WriteLine("Объект rectangle реализует интерфейс Type\n");
            }
            else Console.WriteLine("Объект не реализует интерфейс Type\n");

            if(menu.Button is Config)
            {
                Console.WriteLine("Объект button наследует абстрактный класс Config");
                Console.WriteLine(menu.Button.ToString());
                Console.WriteLine();
            }
            else Console.WriteLine("Объект не наследует абстрактный класс Config\n");

            if (figure is Config)
            {
                Console.WriteLine("Объект button наследует абстрактный класс Config\n");
            }
            else Console.WriteLine("Объект не наследует абстрактный класс Config\n");

            object[] objects = { window, figure, rectangle, menu, menu.Button };
            Printer printer = new Printer();
            foreach(var i in objects)
            {
                Type obj3 = i as Type;
                if (obj3 != null)
                {
                    printer.IAmPrinting(obj3);

                }
                else
                {
                    Console.WriteLine("Объект не реализует интерфейс Type");
                    Console.WriteLine();
                }
                
            }
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
}
