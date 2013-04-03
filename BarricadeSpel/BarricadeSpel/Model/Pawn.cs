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
        public Pawn(Field position)
        {
            this.Position = position;

            this.Type = "pawn";
        }

        // Returns the pawn to its designated position, if it were to be removed.
        private void returnPawn()
        {
            //if (Position.ReturnTo == 0)
            //    Position = 0;//beginning
            //if (Position.ReturnTo == 1)
            //    Position = 10;//forest
        }

        // Finishes the game
        private void finishGame() //Done by GoalField?
        {
            //if (Position == 100)//finish
            //    Console.WriteLine("Gefeliciteerd " + Color + "! Je hebt gewonnen!");
        }
    }
}