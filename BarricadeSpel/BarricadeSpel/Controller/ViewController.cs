using System;
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

        public event EventHandler drawField;
        public event EventHandler makeGrid;
        public event EventHandler drawMovable;
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

                drawField += textView.DrawField;
                makeGrid += textView.MakeGrid;
                drawMovable += textView.DrawMovable;
                //TODO extra eventhandlers linken
            }

            else if (type == "main")
            {
                MainWindow mainWindow = new MainWindow(this);

                drawField += mainWindow.DrawField;
                makeGrid += mainWindow.MakeGrid;
                drawMovable += mainWindow.DrawMovable;
                //TODO extra eventhandlers linken
            }

        }


        //Output functions
        public void DoneLoading()
        {

        }

        public void DrawField(string type, int x, int y)
        {
            EventHandler handler = drawField;
            if (handler != null)
            {
                handler(this, new MyEventArgs.DrawFieldArgs(type, x, y));
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


        //Input functions
        public void LoadFile()
        {
            MainController.LoadFile();
        }
    }
}
