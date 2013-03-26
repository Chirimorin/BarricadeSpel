using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.MyEventArgs
{
    public class MakeGridArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XCells { get; set; }
        public int YCells { get; set; }
        public int CellSize { get; set; }


        public MakeGridArgs(int x, int y) 
        {
            X = x;
            Y = y;
        }
    }
}
