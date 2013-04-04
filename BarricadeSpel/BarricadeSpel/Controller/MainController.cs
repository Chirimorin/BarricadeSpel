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
        private ViewController viewController { get; set; }
        private MovableController movableController { get; set; }


        //Constructor
        public MainController()
        {
            viewController = new ViewController(this);
            movableController = new MovableController(this);
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
                viewController.StartLoading();
                movableController.ClearMovables();
                Controller.FileReader.Read(dialog.FileName, this);
                viewController.DoneLoading();
            }
        }


        //Rerouting Functions
        public void DrawAllMovables()
        {
            movableController.DrawAllMovables();
        }

        public void DrawField(string type, int x, int y)
        {
            viewController.DrawField(type, x, y);
        }

        public void DrawMovable(string type, string color, int xPos, int yPos)
        {
            viewController.DrawMovable(type, color, xPos, yPos);
        }

        public void MakeBarricade(Model.Field position)
        {
            movableController.MakeBarricade(position);
        }

        public void MakeGrid(int x, int y)
        {
            viewController.MakeGrid(x, y);
        }

        public void MakePawn(string color, Model.Field position)
        {
            movableController.MakePawn(color, position);
        }

    }
}
