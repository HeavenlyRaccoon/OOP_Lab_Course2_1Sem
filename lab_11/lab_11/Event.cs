using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11
{
    class Event
    {

        public Event()
        {
            Hours = 0;
            Events = "";
        }
        public Event(int h, string mes)
        {
            Hours = h;
            Events = mes;
        }

        public int Hours { get; set; }
        public string Events { get; set; }
    }
}
