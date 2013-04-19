using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class FinishGameArgs : EventArgs
    {
        public string Color { get; set; }

        //Constructor
        public FinishGameArgs(string color)
        {
            Color = color;
        }
    }
}
