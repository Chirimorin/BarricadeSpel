using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BarricadeSpel
{
    /// <summary>
    /// Interaction logic for TextView.xaml
    /// </summary>
    public partial class TextView : Window
    {
        private Controller.ViewController ViewController { get; set; }

        //Constructor
        public TextView(Controller.ViewController viewController)
        {
            ViewController = viewController;
            InitializeComponent();
            this.Show();
        }

        //Input handling


        //Output functions
        public void DiceRolled(object sender, EventArgs e)
        {
            
        }

        public void DoneLoading(object sender, EventArgs e)
        {

        }

        public void DrawField(object sender, EventArgs e)
        {
            MyEventArgs.DrawFieldArgs drawFieldArgs = (MyEventArgs.DrawFieldArgs)e;
            string type = drawFieldArgs.Type;
            int x = drawFieldArgs.XPos;
            int y = drawFieldArgs.YPos;

            Debug.WriteLine("Draw field text, Type: " + type + ", X: " + x + ", Y: " + y + ".");
            //TODO draw field.
        }

        public void DrawMovable(object sender, EventArgs e)
        {
            MyEventArgs.DrawMovableArgs drawMovableArgs = (MyEventArgs.DrawMovableArgs)e;

            string type = drawMovableArgs.Type;
            string color = drawMovableArgs.Color;
            int xPos = drawMovableArgs.XPos;
            int yPos = drawMovableArgs.YPos;

            //TODO draw the movable
        }

        public void MakeGrid(object sender, EventArgs e)
        {
            MyEventArgs.MakeGridArgs makeGridArgs = (MyEventArgs.MakeGridArgs)e;
            int x = makeGridArgs.X;
            int y = makeGridArgs.Y;

            Debug.WriteLine("Make Grid text, X: " + x + ", Y: " + y + ".");
            //TODO Make grid.
        }

        public void MovePawn(object sender, EventArgs e)
        {

        }

        public void NewTurn(object sender, EventArgs e)
        {

        }

        public void OpenInput(object sender, EventArgs e)
        {

        }

        public void ResetInputs(object sender, EventArgs e)
        {

        }

        public void StartLoading(object sender, EventArgs e)
        {

        }

        //Other functions
    }
}
