using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    public class DrawFieldArgs : EventArgs
    {
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public DrawFieldArgs(string type, int x, int y) 
        {
            Type = type;
            X = x;
            Y = y;
        }
    }
}
