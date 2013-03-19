using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class SafeField : Field
    {
        public SafeField(Field exitN, Field exitE, Field exitS, Field exitW, bool barricadeAllowed, int returnTo)
            : base(exitN, exitE, exitS, exitW, barricadeAllowed, returnTo)
        {
            
        }

        public new bool CanMoveTo(string type)
        {
            if (Contains == null && type == "pion")
                return true;
            return false;
        }
    }
}
