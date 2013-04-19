﻿using System;
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
        public Model.Player PlayerR { get; set; }
        public Model.Player PlayerG { get; set; }
        public Model.Player PlayerY { get; set; }
        public Model.Player PlayerB { get; set; }

        public List<Model.Forest> Forests { get; set; } //for returning

        public List<Model.Barricade> Barricades { get; set; }
        public Model.Barricade SelectedBarricade { get; set; }

        public List<Model.Pawn> SelectablePawns { get; set; } //A list of pawns to be chosen from by the player
        public Model.Pawn SelectedPawn { get; set; } //The actual pawn that was chosen

        public List<Model.Field> SelectableFields { get; set; }

        public string Turn { get; set; }
        public string SubTurn { get; set; }

        public Model.Dice Dice { get; set; }

        private MainController MainController { get; set; }
        private AIController AIController { get; set; }

        //Constructor
        public GameController(MainController mainController)
        {
            MainController = mainController;
            AIController = new AIController(this);
            ResetGame();
        }


        //Functions
        public void AddSelectablePawn(Model.Pawn pawn)
        {
            SelectablePawns.Add(pawn);
            MainController.OpenInput(pawn.Position.XPos, pawn.Position.YPos);
            AIController.AddSelection();
        }

        public void Cheats_Dice(int number)
        {
            SubTurn = "PawnSelect";
            Dice.Value = number;
            PawnSelector(Turn);
        }

        public void Cheats_Turn(string color)
        {
            Turn = color;
            SubTurn = "DiceRoll";
        }

        public void ClearMovables()
        {
            PlayerR = new Model.Player(true); //TODO Choose AI players
            PlayerG = new Model.Player(false);
            PlayerY = new Model.Player(false);
            PlayerB = new Model.Player(false);

            Forests = new List<Model.Forest>();
            Barricades = new List<Model.Barricade>();
            SelectableFields = new List<Model.Field>();
            SelectablePawns = new List<Model.Pawn>();
            
            SelectedBarricade = null;
            SelectedPawn = null;
        }

        public void DrawAllMovables()
        {
            int i = 0;
            foreach (Model.Pawn pawn in PlayerR.Pawns)
            {
                pawn.DrawIndex = i;
                MainController.DrawMovable("pawn", "R", pawn.Position.XPos, pawn.Position.YPos);
                i++;
            }
            foreach (Model.Pawn pawn in PlayerG.Pawns)
            {
                pawn.DrawIndex = i;
                MainController.DrawMovable("pawn", "G", pawn.Position.XPos, pawn.Position.YPos);
                i++;
            }
            foreach (Model.Pawn pawn in PlayerY.Pawns)
            {
                pawn.DrawIndex = i;
                MainController.DrawMovable("pawn", "Y", pawn.Position.XPos, pawn.Position.YPos);
                i++;
            }
            foreach (Model.Pawn pawn in PlayerB.Pawns)
            {
                pawn.DrawIndex = i;
                MainController.DrawMovable("pawn", "B", pawn.Position.XPos, pawn.Position.YPos);
                i++;
            }

            i = 0;
            foreach (Model.Barricade barricade in Barricades)
            {
                barricade.DrawIndex = i;
                MainController.DrawMovable("barricade", "", barricade.Position.XPos, barricade.Position.YPos);
                i++;
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
                    PlayerR.Pawns.Add(new Model.Pawn(position));
                    break;
                case "G":
                    PlayerG.Pawns.Add(new Model.Pawn(position));
                    break;
                case "Y":
                    PlayerY.Pawns.Add(new Model.Pawn(position));
                    break;
                case "B":
                    PlayerB.Pawns.Add(new Model.Pawn(position));
                    break;
            }
        }

        public void MovePawn(Model.Field selectedField)
        {
            SelectedPawn.Position = selectedField;
            MainController.MovePawn(SelectedPawn.DrawIndex, selectedField.XPos, selectedField.YPos);
        }

        public void NewPawn()
        {
            SubTurn = "PawnSelect";
            PawnSelector(Turn);
        }

        public void NewPawnEnabled(bool value)
        {
            MainController.NewPawnEnabled(value);
        }

        public void NextTurn()
        {
            switch(Turn)
            {
                case "R":
                    Turn = "G";
                    break;
                case "G":
                    Turn = "Y";
                    break;
                case "Y":
                    Turn = "B";
                    break;
                case "B":
                    Turn = "R";
                    break;
                default:
                    Turn = "R";
                    break;
            }
            SubTurn = "DiceRoll";
            MainController.SkipTurnEnabled(true);
            MainController.NewTurn(Turn);
            AIController.NewTurn(Turn);

        }

        public void InputSelected(int index)
        {
            Debug.WriteLine("Selected input: " + index);
            if (SubTurn == "PawnSelect")
            {
                SelectedPawn = SelectablePawns.ElementAt(index);
                SelectablePawns = null;

                ResetInputs();
                SelectableFields = new List<Model.Field>();

                SelectedPawn.Position.BroadcastMove(Dice.Value, null);
                Debug.WriteLine("Done broadcasting moves");
                SubTurn = "MoveSelect";
                MainController.NewPawnEnabled(true);
                AIController.SelectInput();
                return;
            }

            if (SubTurn == "MoveSelect")
            {
                MainController.NewPawnEnabled(false);
                ResetInputs();
                Model.Field selectedField = SelectableFields.ElementAt(index);
                bool barricade = false;
                if (selectedField.Contains != null)
                {
                    if (selectedField.Contains.Type == "pawn")
                    {
                        Debug.WriteLine("Pawn hit!");
                        Model.Pawn hitPawn = (Model.Pawn)selectedField.Contains;

                        ReturnPawn(hitPawn, PlayerR, selectedField.ReturnTo);
                        ReturnPawn(hitPawn, PlayerG, selectedField.ReturnTo);
                        ReturnPawn(hitPawn, PlayerY, selectedField.ReturnTo);
                        ReturnPawn(hitPawn, PlayerB, selectedField.ReturnTo);

                        MovePawn(selectedField);
                    }
                    else if (selectedField.Contains.Type == "barricade")
                    {
                        Debug.WriteLine("Barricade hit!");
                        MainController.SkipTurnEnabled(false);
                        SelectedBarricade = (Model.Barricade)selectedField.Contains;
                        MovePawn(selectedField);
                        SelectableFields = new List<Model.Field>();
                        barricade = true;
                        ResetInputs();
                        SelectedPawn.Position.BroadcastBarricades(null);
                        
                        SubTurn = "BarricadeMove";
                        AIController.SelectInput();
                    }
                }
                else
                {
                    MovePawn(selectedField);
                }

                SelectedPawn = null;
                if (!barricade)
                {
                    NextTurn();
                }
                return;
            }
            if (SubTurn == "BarricadeMove")
            {
                SelectedBarricade.Position.ResetBroadcastedBarricades(null);
                ResetInputs();
                Model.Field selectedField = SelectableFields.ElementAt(index);
                SelectedBarricade.Position = selectedField;
                MainController.MoveBarricade(SelectedBarricade.DrawIndex, selectedField.XPos, selectedField.YPos);
                SelectedBarricade = null;
                NextTurn();
            }
        }

        public void PawnSelector(string color) //Makes all pawns of said color available to be chosen.
        {
            ResetInputs();
            SelectablePawns = new List<Model.Pawn>();

            switch (color)
            {
                case "R":
                    foreach (Model.Pawn pawn in PlayerR.Pawns)
                    {
                        AddSelectablePawn(pawn);
                    }
                    break;
                case "G":
                    foreach (Model.Pawn pawn in PlayerG.Pawns)
                    {
                        AddSelectablePawn(pawn);
                    }
                    break;
                case "Y":
                    foreach (Model.Pawn pawn in PlayerY.Pawns)
                    {
                        AddSelectablePawn(pawn);
                    }
                    break;
                case "B":
                    foreach (Model.Pawn pawn in PlayerB.Pawns)
                    {
                        AddSelectablePawn(pawn);
                    }
                    break;
            }

            AIController.SelectInput();
        }

        public void ResetGame()
        {
            ClearMovables();
            Dice = new Model.Dice();
            Turn = null;
        }

        public void ResetInputs()
        {
            MainController.ResetInputs();
            AIController.ResetInputs();
        }

        public void ReturnPawn(Model.Pawn hitPawn, Model.Player player, int returnTo)
        {
            if (returnTo == 0)
            {
                foreach (Model.Pawn pawn in player.Pawns)
                {
                    if (pawn == hitPawn)
                    {
                        bool found = false;
                        int i = 0;
                        while (!found)
                        {
                            Debug.WriteLine("looking for empty spot at " + i);
                            if (player.StartFields.ElementAt(i).Contains == null)
                            {
                                found = true;
                                hitPawn.Position = player.StartFields.ElementAt(i);
                                MainController.MovePawn(hitPawn.DrawIndex, player.StartFields.ElementAt(i).XPos, player.StartFields.ElementAt(i).YPos);
                            }
                            i++;
                        }
                    }
                }
            }
            else //return to a forest
            {
                hitPawn.Position = Forests.ElementAt(returnTo - 1);
                MainController.MovePawn(hitPawn.DrawIndex, Forests.ElementAt(returnTo - 1).XPos, Forests.ElementAt(returnTo - 1).YPos);
            }
        }

        public void RegisterForest(Model.Forest forest)
        {
            Forests.Add(forest);
        }

        public void RegisterSelectableField(Model.Field field)
        {
            SelectableFields.Add(field);
            AIController.AddSelection();
        }

        public void RegisterStartField(Model.StartField field)
        {
            Debug.WriteLine("Registering startfield with color " + field.Color);
            switch(field.Color)
            {
                case"R":
                    PlayerR.StartFields.Add(field);
                    break;
                case"G":
                    PlayerG.StartFields.Add(field);
                    break;
                case"Y":
                    PlayerY.StartFields.Add(field);
                    break;
                case"B":
                    PlayerB.StartFields.Add(field);
                    break;
            }
        }

        public void RollDice()
        {
            SubTurn = "PawnSelect";
            MainController.DiceRolled(Dice.Roll());
            PawnSelector(Turn);
        }

        public void StartGame()
        {
            NextTurn();
        }

    }
}
