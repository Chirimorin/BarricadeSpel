﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BarricadeSpel.Controller
{
    public class ViewController
    {
        //TODO aantal windows bijhouden en sluiten van het programma daarop samen laten werken.


        private Controller.MainController MainController;

        public event EventHandler diceRolled;
        public event EventHandler doneLoading;
        public event EventHandler drawField;
        public event EventHandler drawMovable;
        public event EventHandler makeGrid;
        public event EventHandler moveBarricade;
        public event EventHandler movePawn;
        public event EventHandler newPawnEnabled;
        public event EventHandler newTurn;
        public event EventHandler openInput;
        public event EventHandler resetGame;
        public event EventHandler resetInputs;
        public event EventHandler skipTurnEnabled;
        public event EventHandler startLoading;
        //TODO eventhandlers maken voor andere events (zoals verplaats pion/barricade)


        //Constructor
        public ViewController(Controller.MainController mainController)
        {
            MainController = mainController;

            OpenView("main");
            //OpenView("text");
        }


        //Functions
        public void OpenView(string type)
        {
            if (type == "text")
            {
                TextView textView = new TextView(this);

                diceRolled      += textView.DiceRolled;
                doneLoading     += textView.DoneLoading;
                drawField       += textView.DrawField;
                drawMovable     += textView.DrawMovable;
                makeGrid        += textView.MakeGrid;
                moveBarricade   += textView.MoveBarricade;
                movePawn        += textView.MovePawn;
                newPawnEnabled  += textView.NewPawnEnabled;
                newTurn         += textView.NewTurn;
                openInput       += textView.OpenInput;
                resetGame       += textView.ResetGame;
                resetInputs     += textView.ResetInputs;
                skipTurnEnabled += textView.SkipTurnEnabled;
                startLoading    += textView.StartLoading;
                
                //TODO extra eventhandlers linken
            }

            else if (type == "main")
            {
                MainWindow mainWindow = new MainWindow(this);

                diceRolled      += mainWindow.DiceRolled;
                doneLoading     += mainWindow.DoneLoading;
                drawField       += mainWindow.DrawField;
                drawMovable     += mainWindow.DrawMovable;
                makeGrid        += mainWindow.MakeGrid;
                moveBarricade   += mainWindow.MoveBarricade;
                movePawn        += mainWindow.MovePawn;
                newPawnEnabled  += mainWindow.NewPawnEnabled;
                newTurn         += mainWindow.NewTurn;
                openInput       += mainWindow.OpenInput;
                resetGame       += mainWindow.ResetGame;
                resetInputs     += mainWindow.ResetInputs;
                skipTurnEnabled += mainWindow.SkipTurnEnabled;
                startLoading    += mainWindow.StartLoading;

                //TODO extra eventhandlers linken
            }

        }


        //Output functions
        public void DiceRolled(int value)
        {
            EventHandler handler = diceRolled;
            if (handler != null)
            {
                handler(this, new MyEventArgs.DiceRolledArgs(value));
            }
        }

        public void DoneLoading()
        {
            EventHandler handler = doneLoading;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void DrawField(string type, int x, int y)
        {
            EventHandler handler = drawField;
            if (handler != null)
            {
                handler(this, new MyEventArgs.DrawFieldArgs(type, x, y));
            }
        }

        public void DrawMovable(string type, string color, int xPos, int yPos)
        {
            EventHandler handler = drawMovable;
            if (handler != null)
            {
                handler(this, new MyEventArgs.DrawMovableArgs(type, color, xPos, yPos));
            }
        }

        public void MakeGrid(int x, int y)
        {
            EventHandler handler = makeGrid;
            if (handler != null)
            {
                handler(this, new MyEventArgs.MakeGridArgs(x, y));
            }
        }

        public void MoveBarricade(int index, int newX, int newY)
        {
            EventHandler handler = moveBarricade;
            if (handler != null)
            {
                handler(this, new MyEventArgs.MovePawnArgs(index, newX, newY));
            }
        }

        public void MovePawn(int index, int newX, int newY)
        {
            EventHandler handler = movePawn;
            if (handler != null)
            {
                handler(this, new MyEventArgs.MovePawnArgs(index, newX, newY));
            }
        }

        public void NewTurn(string color)
        {
            EventHandler handler = newTurn;
            if (handler != null)
            {
                handler(this, new MyEventArgs.NewTurnArgs(color));
            }
        }

        public void OpenInput(int xPos, int yPos)
        {
            EventHandler handler = openInput;
            if (handler != null)
            {
                handler(this, new MyEventArgs.OpenInputArgs(xPos, yPos));
            }
        }

        public void NewPawnEnabled(bool value)
        {
            EventHandler handler = newPawnEnabled;
            if (handler != null)
            {
                handler(this, new MyEventArgs.BoolEventArgs(value));
            }
        }

        public void ResetGame()
        {
            EventHandler handler = resetGame;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void ResetInputs()
        {
            EventHandler handler = resetInputs;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void SkipTurnEnabled(bool value)
        {
            EventHandler handler = skipTurnEnabled;
            if (handler != null)
            {
                handler(this, new MyEventArgs.BoolEventArgs(value));
            }
        }

        public void StartLoading()
        {
            EventHandler handler = startLoading;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }


        //Input functions
        public void Cheats_Turn(string color)
        {
            NewTurn(color);
            MainController.Cheats_Turn(color);
        }

        public void Cheats_Dice(int number)
        {
            DiceRolled(number);
            MainController.Cheats_Dice(number);
        }

        public void InputSelected(int index)
        {
            MainController.InputSelected(index);
        }

        public void LoadFile()
        {
            MainController.LoadFile();
        }

        public void NewPawn()
        {
            MainController.NewPawn();
        }

        public void RollDice()
        {
            MainController.RollDice();
        }

        public void SkipTurn()
        {
            MainController.SkipTurn();
            NewPawnEnabled(false);
            ResetInputs();
        }
    }
}
