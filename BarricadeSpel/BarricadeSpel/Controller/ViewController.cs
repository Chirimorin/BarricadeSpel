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

        public event EventHandler doneLoading;
        public event EventHandler drawField;
        public event EventHandler makeGrid;
        public event EventHandler drawMovable;
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

                doneLoading += textView.DoneLoading;
                drawField += textView.DrawField;
                drawMovable += textView.DrawMovable;
                makeGrid += textView.MakeGrid;
                startLoading += textView.StartLoading;
                
                //TODO extra eventhandlers linken
            }

            else if (type == "main")
            {
                MainWindow mainWindow = new MainWindow(this);

                doneLoading += mainWindow.DoneLoading;
                drawField += mainWindow.DrawField;
                drawMovable += mainWindow.DrawMovable;
                makeGrid += mainWindow.MakeGrid;
                startLoading += mainWindow.StartLoading;

                //TODO extra eventhandlers linken
            }

        }


        //Output functions
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

        public void MakeGrid(int x, int y)
        {
            EventHandler handler = makeGrid;
            if (handler != null)
            {
                handler(this, new MyEventArgs.MakeGridArgs(x, y));
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

        public void StartLoading()
        {
            EventHandler handler = startLoading;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }


        //Input functions
        public void LoadFile()
        {
            MainController.LoadFile();
        }
    }
}
