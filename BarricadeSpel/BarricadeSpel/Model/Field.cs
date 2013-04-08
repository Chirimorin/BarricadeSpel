using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    public class Field
    {
        public virtual event EventHandler broadcastMove;

        protected Movable _contains;

        public virtual Movable Contains //Updated by movable! Controllers don't need to touch this. 
        { 
            get 
            { 
                return _contains; 
            }
            set 
            {
                _contains = value;
            }
        } 

        protected Field _exitN;
        protected Field _exitE;
        protected Field _exitS;
        protected Field _exitW;

        public int XPos { get; protected set; }
        public int YPos { get; protected set; }


        //Logic for updating exits, automatically changes the number of exits as needed. 
        //Also updates the exits of other fields as needed. 
        public Field ExitN
        {
            get { return _exitN; }
            set
            {
                if (_exitN != null)
                    _exitN.ExitS2 = null;
                this.ExitN2 = value;
                if (_exitN != null)
                    _exitN.ExitS2 = this;
            }
        }
        public Field ExitE
        {
            get { return _exitE; }
            set
            {
                if (_exitE != null)
                    _exitE.ExitW2 = null;
                this.ExitE2 = value;
                if (_exitE != null)
                    _exitE.ExitW2 = this;
            }
        }
        public Field ExitS
        {
            get { return _exitS; }
            set
            {
                if (_exitS != null)
                    _exitS.ExitN2 = null;
                this.ExitS2 = value;
                if (_exitS != null)
                    _exitS.ExitN2 = this;
            }
        }
        public Field ExitW
        {
            get { return _exitW; }
            set
            {
                if (_exitW != null)
                    _exitW.ExitE2 = null;
                this.ExitW2 = value;
                if (_exitW != null)
                    _exitW.ExitE2 = this;
            }
        }

        //Actual logic for updating exits, called by the above fields. 
        //Separate for auto updating other objects exits too. 
        public Field ExitN2
        {
            set
            {
                if (value == null && _exitN == null) //no need to change anything
                    return;
                if (value == null && _exitN != null) //exit removed
                    NumExits--;
                if (value != null && _exitN == null) //exit added
                    NumExits++;
                _exitN = value; //update exit
            }
        }
        public Field ExitE2
        {
            set
            {
                if (value == null && _exitE == null) //no need to change anything
                    return;
                if (value == null && _exitE != null) //exit removed
                    NumExits--;
                if (value != null && _exitE == null) //exit added
                    NumExits++;
                _exitE = value; //update exit
            }
        }
        public Field ExitS2
        {
            set
            {
                if (value == null && _exitS == null) //no need to change anything
                    return;
                if (value == null && _exitS != null) //exit removed
                    NumExits--;
                if (value != null && _exitS == null) //exit added
                    NumExits++;
                _exitS = value; //update exit
            }
        }
        public Field ExitW2
        {
            set
            {
                if (value == null && _exitW == null) //no need to change anything
                    return;
                if (value == null && _exitW != null) //exit removed
                    NumExits--;
                if (value != null && _exitW == null) //exit added
                    NumExits++;
                _exitW = value; //update exit
            }
        }

        public int NumExits { get; private set; }
        public bool BarricareAllowed { get; private set; }
        public int ReturnTo { get; private set; } //index of the forest to return to, 0 for start

        //Constructor
        public Field(Field exitN, Field exitE, Field exitS, Field exitW, bool barricadeAllowed, int returnTo, int xPos, int yPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.ExitN = exitN;
            this.ExitE = exitE;
            this.ExitS = exitS;
            this.ExitW = exitW;
            this.BarricareAllowed = barricadeAllowed;
            this.ReturnTo = returnTo;
            Debug.Write("Field made. ");
            if (exitN != null)
                Debug.Write("ExitN given ");
            if (exitW != null)
                Debug.Write("ExitW given ");
            Debug.WriteLine("");
            Debug.WriteLine("");
        }

        
        //Functions
        public virtual void BroadcastMove(int numSteps, Field comesFrom)
        {
            if (numSteps <= 0) //Pawn is trying to stop on this field. Allow if possible
            {
                EventHandler handler = broadcastMove;
                if (handler != null)
                {
                    handler(this, new MyEventArgs.BroadcastMoveArgs(XPos, YPos, this));
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

        public virtual void RemoveMovable(Movable movable)
        {
            //Only needed by forest. 
        }

    }
}
