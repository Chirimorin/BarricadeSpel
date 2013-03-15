using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class GoalField : Field
    {
        public Movable Contains
        {
            set 
            {
                _contains = value;
                FinishGame(); 
            }
        }

        private void FinishGame()
        {
            //finish game logic
        }

        public bool CanMoveTo(string type)
        {
            if (type == "barricade")
                return false;
            return true;
        }
    }
}
