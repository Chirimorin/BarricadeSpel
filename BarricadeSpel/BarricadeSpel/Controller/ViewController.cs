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
        //TODO aantal windows bijhouden en sluiten van het programma daarop samen laten werken. --> Thomas


        private Controller.MainController MainController;

        public event EventHandler drawField;
        public event EventHandler makeGrid;
        //TODO eventhandlers maken voor andere events (zoals verplaats pion/barricade)

        public ViewController(Controller.MainController mainController)
        {
            MainController = mainController;

            OpenView("main");
            OpenView("text");
        }

        public void OpenView(string type)
        {
            if (type == "text")
            {
                TextView textView = new TextView(this);

                drawField += textView.DrawField;
                makeGrid += textView.MakeGrid;
                //TODO extra eventhandlers linken
            }

            else if (type == "main")
            {
                MainWindow mainWindow = new MainWindow(this);

                drawField += mainWindow.DrawField;
                makeGrid += mainWindow.MakeGrid;
                //TODO extra eventhandlers linken
            }

        }

        public void LoadFile()
        {
            MainController.LoadFile();
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

        //TODO extra events firen bij andere events. 


    }
}
