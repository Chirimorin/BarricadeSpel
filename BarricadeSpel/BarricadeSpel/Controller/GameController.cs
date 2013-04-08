using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Controller
{
    //This class contains logic for routing the game. 
    //Examples are rolling the dice and determining who'se turn it is. 
    //This will also control the AI where needed
    class GameController
    {
        public string Turn { get; set; }
        public Model.Dice Dice { get; set; }

        private MainController MainController { get; set; }

        //Constructor
        public GameController(MainController mainController)
        {
            MainController = mainController;
            Dice = new Model.Dice();
        }


        //Functions

        public void StartGame()
        {
            Turn = "R";
            MainController.NewTurn(Turn);
        }

        //Rerouting functions
        public void RollDice()
        {
            MainController.DiceRolled(Dice.Roll());
            MainController.PawnSelector(Turn);
        }

    }
}
