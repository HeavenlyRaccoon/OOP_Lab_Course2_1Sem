using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_14
{
    [Serializable]
    public abstract class Config
    {
       public bool visible = true;
       public void increase(ref int w, ref int h)
        {
            w = w * 2;
            h = h * 2;
        }
        public abstract void info();
        public abstract void type();
    }
}
