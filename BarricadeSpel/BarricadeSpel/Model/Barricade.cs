using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Barricade : Movable
    {
        public override Field Position
        {
            get { return _position; }
            set
            {
                if (value != null)
                {
                    _position = value;
                    _position.Contains = this;
                }
            }
        }

        //Constructor
        public Barricade(Field position)
        {
            Position = position;
            this.Type = "barricade";
            Debug.WriteLine("Barricade made");
        }
    }
}
