using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class GoalField : Field
    {
        public override event EventHandler broadcastMove;

        public event EventHandler finishGame;

        public override Movable Contains
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
        private void FinishGame() //TODO make whole function
        {
            Debug.WriteLine("GAME FINISHED!");
            
            Pawn pawn = (Model.Pawn)_contains;

            EventHandler handler = finishGame;
            if (handler != null)
            {
                handler(this, new MyEventArgs.FinishGameArgs(null));
            }
        }

        public override void BroadcastMove(int numSteps, Field comesFrom)
        {
            if (numSteps <= 0) //Pawn is trying to stop on this field. Allow always
            {
                EventHandler handler = broadcastMove;
                if (handler != null)
                {
                    handler(this, new MyEventArgs.BroadcastMoveArgs(XPos, YPos, this));
                }
            }
        }

    }
}
