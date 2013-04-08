using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class OpenInputArgs : EventArgs
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        //Constructor
        public OpenInputArgs(int xPos, int yPos) 
        {
            XPos = xPos;
            YPos = yPos;
        }
    }
}
