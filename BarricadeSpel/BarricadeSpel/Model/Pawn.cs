using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Pawn : Movable
    {
        //Constructor
        public Pawn(Field position)
        {
            this.Position = position;

            this.Type = "pawn";
        }

        //Functions
        private void returnPawn() //Returns the pawn to appropriate position when it's hit. 
        {
            //if (Position.ReturnTo == 0)
            //    Position = 0;//beginning
            //if (Position.ReturnTo == 1)
            //    Position = 10;//forest
        }
    }
}