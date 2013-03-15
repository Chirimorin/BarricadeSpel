using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Pawn : Movable
    {
        private Field position;
        private String color;

        public Field Position
        {
            get { return position; }
            set { position = value; }
        }

        public String Color
        {
            get { return color; }
            set { color = value; }
        }

        // Returns the pawn to its designated position, if it were to be removed.
        private void returnPawn()
        {
            if (position.ReturnTo == 0)
                position = 0;//beginning
            if (position.ReturnTo == 1)
                position = 10;//forest
        }

        // Finishes the game
        private void finishGame()
        {
            if(position == 100)//finish
                Console.WriteLine("Gefeliciteerd "+color+"! Je hebt gewonnen!");
        }

        public Pawn(Field position, String color)
        {
            this.position = position;
            this.color = color;
        }
    }
}