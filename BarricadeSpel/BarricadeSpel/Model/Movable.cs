using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Movable
    {
        private Field _position;
        public Field Position 
        { 
            get { return _position; }
            set 
            {
                if (value != null)
                {
                    _position.Contains = null;
                    _position = value;
                    _position.Contains = this;
                }
            } 
        }



    }
}
