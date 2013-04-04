using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class GoalField : Field
    {
        public new Movable Contains
        {
            set
            {
                _contains = value;
                FinishGame();
            }
        }

        //Constructor
        public GoalField(Field exitN, Field exitE, Field exitS, Field exitW, int xPos, int yPos)
            : base(exitN, exitE, exitS, exitW, false, 0, xPos, yPos)
        {
            
        }


        //Functions
        public new bool CanMoveOver()
        {
            return false;
        }

        public new bool CanMoveTo(string type)
        {
            if (type == "barricade")
                return false;
            return true;
        }

        private void FinishGame() //TODO make whole function
        {
            //finish game logic
        }


    }
}
