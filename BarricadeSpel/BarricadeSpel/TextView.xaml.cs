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

        public TextView(Controller.ViewController viewController)
        {
            ViewController = viewController;
            InitializeComponent();
            this.Show();
        }

        public void DrawField(object sender, EventArgs e)
        {
            MyEventArgs.DrawFieldArgs drawFieldArgs = (MyEventArgs.DrawFieldArgs)e;
            string type = drawFieldArgs.Type;
            int x = drawFieldArgs.X;
            int y = drawFieldArgs.Y;

            Debug.WriteLine("Draw field text, Type: " + type + ", X: " + x + ", Y: " + y + ".");
            //TODO veld tekenen.
        }

        public void MakeGrid(object sender, EventArgs e)
        {
            MyEventArgs.MakeGridArgs makeGridArgs = (MyEventArgs.MakeGridArgs)e;
            int x = makeGridArgs.X;
            int y = makeGridArgs.Y;

            Debug.WriteLine("Make Grid text, X: " + x + ", Y: " + y + ".");
            //TODO grid aanmaken.
        }
    }
}
