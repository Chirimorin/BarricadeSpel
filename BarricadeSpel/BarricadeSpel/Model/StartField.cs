using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    public class StartField : Field
    {
        public string Color { get; set; } //Letter representation of the color.


        //Constructor
        public StartField(Field exitN, Field exitE, Field exitS, Field exitW, string color, int xPos, int yPos)
            : base(exitN, exitE, exitS, exitW, false, 0, xPos, yPos)
        {
            Color = color.ToUpper();
        }

        //Functions
        public override void BroadcastMove(int numSteps, Field comesFrom)
        {
            if (comesFrom == null || (comesFrom is Model.StartField))
            {
                if (_contains == null || _contains.Type != "barricade")
                {
                    //Only push through for 1 more, should always end up outside the start and not cause endless loops. 
                    //Note: odd Maps that have the exit of the start fields south or west might be problematic. 

                    if (comesFrom == null) //Moving off the starting fields is always only 1 step. 
                        numSteps--;

                    if (comesFrom != _exitN && _exitN != null)
                    {
                        _exitN.BroadcastMove(numSteps, this);
                    }
                    else if (comesFrom != _exitE && _exitE != null)
                    {
                        _exitE.BroadcastMove(numSteps, this);
                    }
                    else if (comesFrom != _exitW && _exitW != null)
                    {
                        _exitW.BroadcastMove(numSteps, this);
                    }
                    else if (comesFrom != _exitS && _exitS != null)
                    {
                        _exitS.BroadcastMove(numSteps, this);
                    }
                }
            }
        }

    }
}
