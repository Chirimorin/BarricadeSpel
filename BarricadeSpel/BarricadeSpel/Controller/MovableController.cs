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

        public MovableController(MainController mainController)
        {
            this.MainController = mainController;

            PlayerR = new Model.Player(true); //TODO Choose AI players
            PlayerG = new Model.Player(true);
            PlayerY = new Model.Player(true);
            PlayerB = new Model.Player(true);
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

        public void MakeBarricade(Model.Field position)
        {
            Barricades.Add(new Model.Barricade(position));
        }


    }
}
