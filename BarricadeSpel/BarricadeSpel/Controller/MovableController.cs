using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Controller
{
    class MovableController
    {
        private MainController MainController { get; set; }

        public Model.Player PlayerR { get; set; }
        public Model.Player PlayerG { get; set; }
        public Model.Player PlayerY { get; set; }
        public Model.Player PlayerB { get; set; }

        public List<Model.Barricade> Barricades { get; set; }


        //Constructor
        public MovableController(MainController mainController)
        {
            this.MainController = mainController;

            ClearMovables();
        }


        //Functions
        public void ClearMovables()
        {
            PlayerR = new Model.Player(true); //TODO Choose AI players
            PlayerG = new Model.Player(true);
            PlayerY = new Model.Player(true);
            PlayerB = new Model.Player(true);

            Barricades = new List<Model.Barricade>();
        }

        public void DrawAllMovables()
        {
            foreach (Model.Pawn pawn in PlayerR.Pawns)
            {
                MainController.DrawMovable("pawn", "R", pawn.Position.XPos, pawn.Position.YPos);
            }
            foreach (Model.Pawn pawn in PlayerG.Pawns)
            {
                MainController.DrawMovable("pawn", "G", pawn.Position.XPos, pawn.Position.YPos);
            }
            foreach (Model.Pawn pawn in PlayerY.Pawns)
            {
                MainController.DrawMovable("pawn", "Y", pawn.Position.XPos, pawn.Position.YPos);
            }
            foreach (Model.Pawn pawn in PlayerB.Pawns)
            {
                MainController.DrawMovable("pawn", "B", pawn.Position.XPos, pawn.Position.YPos);
            }

            foreach(Model.Barricade barricade in Barricades)
            {
                MainController.DrawMovable("barricade", "", barricade.Position.XPos, barricade.Position.YPos);
            }

        }

        public void MakeBarricade(Model.Field position)
        {
            Barricades.Add(new Model.Barricade(position));
        }

        public void MakePawn(string color, Model.Field position)
        {
            switch (color)
            {
                case "R":
                    PlayerR.AddPawn(position);
                    break;
                case "G":
                    PlayerG.AddPawn(position);
                    break;
                case "Y":
                    PlayerY.AddPawn(position);
                    break;
                case "B":
                    PlayerB.AddPawn(position);
                    break;
            }
        }
    }
}
