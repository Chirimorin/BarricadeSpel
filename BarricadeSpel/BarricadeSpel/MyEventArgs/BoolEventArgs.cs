using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class BoolEventArgs : EventArgs
    {
        public bool Value { get; set; }

        //Constructor
        public BoolEventArgs(bool value)
        {
            Value = value;
        }
    }
}
