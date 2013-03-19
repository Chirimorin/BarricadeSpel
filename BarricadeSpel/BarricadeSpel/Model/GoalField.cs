using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class GoalField : Field
    {
        public GoalField(Field exitN, Field exitE, Field exitS, Field exitW, bool barricadeAllowed, int returnTo)
            : base(exitN, exitE, exitS, exitW, barricadeAllowed, returnTo)
        {
            
        }

        public new Movable Contains
        {
            set 
            {
                _contains = value;
                FinishGame(); 
            }
        }

        private void FinishGame() //TODO make whole function
        {
            //finish game logic
        }

        public new bool CanMoveTo(string type)
        {
            if (type == "barricade")
                return false;
            return true;
        }

        public new bool CanMoveOver()
        {
            return false;
        }
    }
}
