using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    class Player
    {
        public bool IsPlayer { get; set; } //true = speler, false = AI
        public List<Model.Pawn> Pawns { get; set; }

        public Player(bool isPlayer)
        {
            this.IsPlayer = isPlayer;
            Pawns = new List<Pawn>();
        }

        public void AddPawn(Field position)
        {
            Pawns.Add(new Pawn(position));
        }

    }
}
