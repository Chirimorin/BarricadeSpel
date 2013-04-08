﻿using System;
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
        private MovableController MovableController { get; set; }
        private GameController GameController { get; set; }


        //Constructor
        public MainController()
        {
            ViewController = new ViewController(this);
            MovableController = new MovableController(this);
            GameController = new GameController(this);
        }

        //Functions
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
                MovableController.ClearMovables();
                Controller.FileReader.Read(dialog.FileName, this);
                ViewController.DoneLoading();
                GameController.StartGame();
            }
        }

        public void Test()
        {
            
        }

        //Rerouting Functions
        public void DiceRolled(int value)
        {
            ViewController.DiceRolled(value);
        }

        public void DrawAllMovables()
        {
            MovableController.DrawAllMovables();
        }

        public void DrawField(string type, int x, int y)
        {
            ViewController.DrawField(type, x, y);
        }

        public void DrawMovable(string type, string color, int xPos, int yPos)
        {
            ViewController.DrawMovable(type, color, xPos, yPos);
        }

        public void MakeBarricade(Model.Field position)
        {
            MovableController.MakeBarricade(position);
        }

        public void MakeGrid(int x, int y)
        {
            ViewController.MakeGrid(x, y);
        }

        public void MakePawn(string color, Model.Field position)
        {
            MovableController.MakePawn(color, position);
        }

        public void NewTurn(string color)
        {
            ViewController.NewTurn(color);
        }

        public void OpenInput(int xPos, int yPos)
        {
            ViewController.OpenInput(xPos, yPos);
        }

        public void PawnSelector(string color)
        {
            MovableController.PawnSelector(color);
        }

        public void ResetInputs()
        {
            ViewController.ResetInputs();
        }

        public void RollDice()
        {
            GameController.RollDice();
        }

    }
}
