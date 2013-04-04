using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class StartField : Field
    {
        public string Color { get; set; } //Letter representation of the color.


        //Constructor
        public StartField(Field exitN, Field exitE, Field exitS, Field exitW, string color, int xPos, int yPos)
            : base(exitN, exitE, exitS, exitW, false, 0, xPos, yPos)
        {
            Color = color.ToUpper();
        }

        //Functions
        public new bool CanMoveOver()
        {
            return false;
        }

        public new bool CanMoveTo(string type)
        {
            return false;
        }

    }
}
