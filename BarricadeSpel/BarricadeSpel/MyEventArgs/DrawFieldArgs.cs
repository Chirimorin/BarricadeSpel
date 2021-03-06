﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    public class DrawFieldArgs : EventArgs
    {
        public string Type { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }


        //Constructor
        public DrawFieldArgs(string type, int xPos, int yPos) 
        {
            Type = type;
            XPos = xPos;
            YPos = yPos;
        }
    }
}
