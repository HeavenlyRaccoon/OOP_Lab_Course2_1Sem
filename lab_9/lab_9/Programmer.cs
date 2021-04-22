using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    class Programmer
    {
        public delegate void Handler(ref List<string> c);
        public event Handler Del;
        public event Handler Mode;

        List<string> code;
        
        public Programmer(List<string> c)
        {
            code = new List<string>();
            code = c;
        }


        public void delete() => Del?.Invoke(ref this.code);

        public void mode() => Mode?.Invoke(ref this.code);
    }
}
