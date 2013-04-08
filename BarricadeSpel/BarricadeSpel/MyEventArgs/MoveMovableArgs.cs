using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class MovePawnArgs : EventArgs
    {
        public int Index { get; set; }
        public int NewX { get; set; }
        public int NewY { get; set; }

        //Constructor
        public MovePawnArgs(int index, int newX, int newY)
        {
            Index = index;
            NewX = newX;
            NewY = newY;
        }
    }
}
