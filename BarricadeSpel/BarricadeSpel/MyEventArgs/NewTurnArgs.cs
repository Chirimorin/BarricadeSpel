using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class NewTurnArgs : EventArgs
    {
        public string Color { get; set; }

        //Constructor
        public NewTurnArgs(string color) 
        {
            Color = color;
        }
    }
}
