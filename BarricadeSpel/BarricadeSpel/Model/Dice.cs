using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Dice
    {
        public int Value { get; set; }

        private Random Rng { get; set; }

        //Constructor
        public Dice()
        {
            Rng = new Random(System.DateTime.Now.Millisecond);
        }


        //Functions
        public int Roll()
        {
            Value = Rng.Next(1, 7);
            return Value;
        }
    }
}
