using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class DiceRolledArgs : EventArgs
    {
        public int Value { get; set; }

        //Constructor
        public DiceRolledArgs(int value)
        {
            Value = value;
        }
    }
}
