using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    class Controller
    {
        public void findButtons(List<object> list)
        {
            Console.WriteLine("Найденные кнопки: ");
            foreach(var i in list)
            {
                if (i.GetType() == typeof(Button))
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }

        public void findMenu(List<object> list,  int nest)
        {
            Console.WriteLine("Найденное меню: ");
            foreach(var i in list)
            {
                if (i.GetType() == typeof(Menu)){
                    Menu ii = (Menu)i;
                    if (ii.Nesting == nest)
                    {
                        Console.WriteLine(i.ToString());
                    }
                }
            }
        }

        public void spaceOfWindow(List<object> list)
        {
            int area=0;
            foreach(var i in list)
            {
                if (i.GetType() == typeof(Window))
                {
                    Window ii = (Window)i;
                    area = ii.Height * ii.Width;
                }
            }

            foreach(var i in list)
            {
                if (i.GetType() == typeof(Menu))
                {
                    Menu ii = (Menu)i;
                    area = area - ii.MenuHeight * ii.MenuWidth;
                }
                else if (i.GetType() == typeof(Button))
                {
                    Button ii = (Button)i;
                    area = area - (ii.ButtonWidth*ii.ButtonHeight);
                }
            }
            Console.WriteLine("Свободная площадь окна: " + area);
        }
    }
}
