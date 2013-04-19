using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Controller
{
    public class MainController
    {
        private ViewController ViewController { get; set; }
        private GameController GameController { get; set; }


        //Constructor
        public MainController()
        {
            ViewController = new ViewController(this);
            GameController = new GameController(this);
        }

        //Functions
        public void BroadcastMove(object sender, EventArgs e)
        {
            Debug.WriteLine("Received possible field");

            MyEventArgs.BroadcastMoveArgs broadcastMoveArgs = (MyEventArgs.BroadcastMoveArgs)e;
            int xPos = broadcastMoveArgs.XPos;
            int yPos = broadcastMoveArgs.YPos;
            Model.Field field = broadcastMoveArgs.Field;

            GameController.RegisterSelectableField(field);
            OpenInput(xPos, yPos);
        }

        public void FinishGame(string color)
        {
            ViewController.FinishGame(color);
        }

        public void FinishGame(object sender, EventArgs e)
        {
            Model.GoalField goalField = (Model.GoalField)sender;

            GameController.FinishGame(goalField);
        }

        public void LoadFile()
        {
            System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            string path = thisExe.Location;
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            path = dirinfo.Parent.FullName + "\\Levels\\";

            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Barricadespel levels|*.txt";
            dialog.InitialDirectory = path;

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                ViewController.StartLoading();
                ResetGame();
                Controller.FileReader.Read(dialog.FileName, this);
                ViewController.DoneLoading();
                GameController.StartGame();
            }
        }

        public void ResetGame()
        {
            GameController.ResetGame();
            ViewController.ResetGame();
        }

        //Rerouting Functions
        public void Cheats_Dice(int number)
        {
            GameController.Cheats_Dice(number);
        }

        public void Cheats_Turn(string color)
        {
            GameController.Cheats_Turn(color);
        }

        public void DiceRolled(int value)
        {
            ViewController.DiceRolled(value);
        }

        public void DrawAllMovables()
        {
            GameController.DrawAllMovables();
        }

        public void DrawField(string type, int x, int y)
        {
            ViewController.DrawField(type, x, y);
        }

        public void DrawMovable(string type, string color, int xPos, int yPos)
        {
            ViewController.DrawMovable(type, color, xPos, yPos);
        }

        public void InputSelected(int index)
        {
            GameController.InputSelected(index);
        }

        public void MakeBarricade(Model.Field position)
        {
            GameController.MakeBarricade(position);
        }

        public void MakeGrid(int x, int y)
        {
            ViewController.MakeGrid(x, y);
        }

        public void MakePawn(string color, Model.Field position)
        {
            GameController.MakePawn(color, position);
        }

        public void MoveBarricade(int index, int newX, int newY)
        {
            ViewController.MoveBarricade(index, newX, newY);
        }

        public void MovePawn(int index, int newX, int newY)
        {
            ViewController.MovePawn(index, newX, newY);
        }

        public void NewPawn()
        {
            GameController.NewPawn();
        }

        public void NewPawnEnabled(bool value)
        {
            ViewController.NewPawnEnabled(value);
        }

        public void NewTurn(string color)
        {
            ViewController.NewTurn(color);
        }

        public void OpenInput(int xPos, int yPos)
        {
            ViewController.OpenInput(xPos, yPos);
        }

        public void RegisterForest(Model.Forest forest)
        {
            GameController.RegisterForest(forest);
        }

        public void RegisterStartField(Model.StartField field)
        {
            GameController.RegisterStartField(field);
        }

        public void ResetInputs()
        {
            ViewController.ResetInputs();
        }

        public void RollDice()
        {
            GameController.RollDice();
        }

        public void SkipTurn()
        {
            GameController.NextTurn();
        }

        public void SkipTurnEnabled(bool value)
        {
            ViewController.SkipTurnEnabled(value);
        }

    }
}
