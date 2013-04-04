using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class DrawMovableArgs : EventArgs
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }


        //Constructor
        public DrawMovableArgs(string type, string color, int xPos, int yPos)
        {
            Type = type;
            Color = color;
            XPos = xPos;
            YPos = yPos;
        }
    }
}
