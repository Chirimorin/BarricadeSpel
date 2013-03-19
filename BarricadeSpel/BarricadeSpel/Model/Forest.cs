using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Forest : Field
    {
        public Forest(Field exitN, Field exitE, Field exitS, Field exitW, bool barricadeAllowed, int returnTo)
            : base(exitN, exitE, exitS, exitW, barricadeAllowed, returnTo)
        {
            _contains = new List<Movable>();
        }

        private new List<Movable> _contains;
        public new Movable Contains //TODO fix setter
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    _contains.Add(value);
                }
                else
                {
                    //Remove source of setter? possible?
                    //otherwise custom check for forest in movable/pawn needed
                }
            }
        }

        public new bool CanMoveTo(string type)
        {
            return false;
        }

        public new bool CanMoveOver()
        {
            return false;
        }
    }
}
