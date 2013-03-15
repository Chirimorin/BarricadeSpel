using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Forest : Field
    {
        private List<Movable> _contains;
        public Movable Contains //TODO fix setter
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

        public bool CanMoveTo(string type)
        {
            return false;
        }

        public bool CanMoveOver()
        {
            return false;
        }
    }
}
