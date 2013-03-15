using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Pawn : Movable
    {
        public String Color { get; set; }

        // Returns the pawn to its designated position, if it were to be removed.
        private void returnPawn()
        {
            //if (Position.ReturnTo == 0)
            //    Position = 0;//beginning
            //if (Position.ReturnTo == 1)
            //    Position = 10;//forest
        }

        public Pawn(Field position, String color)
        {
            this.Position = position;
            this.Color = color;
            this.Type = "pawn";
        }

        // Finishes the game
        private void finishGame()
        {
            //if (Position == 100)//finish
            //    Console.WriteLine("Gefeliciteerd " + Color + "! Je hebt gewonnen!");
        }
    }
}