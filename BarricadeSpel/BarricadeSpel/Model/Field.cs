using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Field
    {
        protected Movable _contains;

        public Movable Contains { get { return _contains; } set { _contains = value; } } //Updated by movable! Controller doesn't need to touch this outside loading the game. 

        protected Field _exitN;
        protected Field _exitE;
        protected Field _exitS;
        protected Field _exitW;


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

        public Field(Field exitN, Field exitE, Field exitS, Field exitW, bool barricadeAllowed, int returnTo)
        {
            this.ExitN = exitN;
            this.ExitE = exitE;
            this.ExitS = exitS;
            this.ExitW = exitW;
            this.BarricareAllowed = barricadeAllowed;
            this.ReturnTo = returnTo;
        }

        public bool CanMoveTo(string type)
        {
            return true;
        }

        public bool CanMoveOver()
        {
            if (Contains != null)
                if (Contains.Type == "barricade")
                    return false;

            return true;
        }

    }
}
