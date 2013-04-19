using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Controller
{
    class AIController
    {
        private int NumSelections { get; set; }
        private bool AITurn { get; set; }
        private Random RNG { get; set; }

        private GameController GameController { get; set; }

        public AIController(GameController gameController)
        {
            GameController = gameController;
            RNG = new Random();
        }

        //Controller functions
        public void AddSelection()
        {
            NumSelections++;
        }

        public void NewTurn(string color)
        {
            switch (color)
            {
                case "R":
                    StartTurn(GameController.PlayerR);
                    break;
                case "G":
                    StartTurn(GameController.PlayerG);
                    break;
                case "Y":
                    StartTurn(GameController.PlayerY);
                    break;
                case "B":
                    StartTurn(GameController.PlayerB);
                    break; 
            }
        }

        public void ResetInputs()
        {
            NumSelections = 0;
        }

        public void SelectInput()
        {
            if (AITurn)
            {
                if (NumSelections == 0)
                {
                    SkipTurn();
                }

                InputSelected(RNG.Next(0, NumSelections));
            }
        }

        private void StartTurn (Model.Player player)
        {
            AITurn = !player.IsPlayer;
            if (AITurn)
            {
                GameController.RollDice();
            }
        }

        //Fake input functions
        public void InputSelected(int index)
        {
            GameController.InputSelected(index);
        }

        public void NewPawn()
        {
            GameController.NewPawn();
        }

        public void RollDice()
        {
            GameController.RollDice();
        }

        public void SkipTurn()
        {
            GameController.NextTurn();
            GameController.NewPawnEnabled(false);
            GameController.ResetInputs();
        }

    }
}
