using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class SafeField : Field
    {
        public override event EventHandler broadcastMove;

        //Constructor
        public SafeField(Field exitN, Field exitE, Field exitS, Field exitW, bool barricadeAllowed, int returnTo, int xPos, int yPos)
            : base(exitN, exitE, exitS, exitW, barricadeAllowed, returnTo, xPos, yPos)
        {
            
        }


        //Functions
        public override void BroadcastMove(int numSteps, Field comesFrom)
        {
            if (numSteps <= 0) //Pawn is trying to stop on this field. Allow if no pawn is on it.
            {
                if (this.Contains == null)
                {
                    EventHandler handler = broadcastMove;
                    if (handler != null)
                    {
                        handler(this, new MyEventArgs.BroadcastMoveArgs(XPos, YPos, this));
                    }
                }
            }
            else
            {
                numSteps--;
                if (_contains == null || _contains.Type != "barricade")
                {
                    if (comesFrom != _exitN && _exitN != null)
                    {
                        _exitN.BroadcastMove(numSteps, this);
                    }
                    if (comesFrom != _exitE && _exitE != null)
                    {
                        _exitE.BroadcastMove(numSteps, this);
                    }
                    if (comesFrom != _exitS && _exitS != null)
                    {
                        _exitS.BroadcastMove(numSteps, this);
                    }
                    if (comesFrom != _exitW && _exitW != null)
                    {
                        _exitW.BroadcastMove(numSteps, this);
                    }
                }
            }
        }
    }
}
