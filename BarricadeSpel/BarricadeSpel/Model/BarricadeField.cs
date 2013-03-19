using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class BarricadeField : Field
    {
        public BarricadeField(Field exitN, Field exitE, Field exitS, Field exitW, bool barricadeAllowed, int returnTo)
            : base(exitN, exitE, exitS, exitW, barricadeAllowed, returnTo)
        {
            
        }

        //Acts as a normal field, only difference is looks. 
        //No need to change this. 
    }
}
