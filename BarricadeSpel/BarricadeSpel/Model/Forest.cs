using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Forest : Field
    {
        public int NumForest { get; set; }
        private List<Movable> _container;

        public override Movable Contains //TODO fix setter
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    _container.Add(value);
                }
            }
        }

        //Constructor
        public Forest(Field exitN, Field exitE, Field exitS, Field exitW, int numForest, int xPos, int yPos)
            : base(exitN, exitE, exitS, exitW, false, 0, xPos, yPos)
        {
            NumForest = numForest;
            _container = new List<Movable>();
        }


        //Functions
        public override void BroadcastMove(int numSteps, Field comesFrom)
        {
            if (numSteps <= 0) //Pawn is trying to stop on this field. Allow if possible
            {
                return; //Can't walk to forests
            }
            else //This is needed for moving off the forest. 
            {
                numSteps--;
                if (comesFrom == null) //Call is originating from the pawn and not an exit
                {
                    if (_exitN != null)
                    {
                        _exitN.BroadcastMove(numSteps, this);
                    }
                    if (_exitE != null)
                    {
                        _exitE.BroadcastMove(numSteps, this);
                    }
                    if (_exitS != null)
                    {
                        _exitS.BroadcastMove(numSteps, this);
                    }
                    if (_exitW != null)
                    {
                        _exitW.BroadcastMove(numSteps, this);
                    }
                }
            }
        }

        public override void RemoveMovable(Movable movable)
        {
            _container.Remove(movable);
        }
    }
}
