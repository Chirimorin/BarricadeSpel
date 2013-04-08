using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    class BroadcastMoveArgs : EventArgs
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Model.Field Field { get; set; }

        //Constructor
        public BroadcastMoveArgs(int xPos, int yPos, Model.Field field)
        {
            XPos = xPos;
            YPos = yPos;
            Field = field;
        }
    }
}
