using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class LinkField : Field
    {
        //A link to make fields link together with more distance. 
        //Moving to it is impossible since it's not a real field. 
        //Moving over it is free. 

        public new Movable Contains { get { Debug.WriteLine("Attempt to call get contains on LinkField"); return null; } set { Debug.WriteLine("Attempt to call set contains on LinkField"); } }

        public LinkField(Field exitN, Field exitE, Field exitS, Field exitW, int xPos, int yPos)
            : base(exitN, exitE, exitS, exitW, false, 0, xPos, yPos)
        {
            Debug.WriteLine("LINKFIELD MADE!");
        }

        public new bool CanMoveTo(string type) //TODO update logic to pass through to next object. 
        {
            return false;
        }

        public new bool CanMoveOver() //TODO update logic to pass through to next object. 
        {
            return false;
        }
    }
}
