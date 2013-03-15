using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class SafeField : Field
    {

        public bool CanMoveTo(string type)
        {
            if (Contains == null)
                return true;
            return false;
        }
    }
}
