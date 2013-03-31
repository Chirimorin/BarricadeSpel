using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarricadeSpel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller.ViewController ViewController { get; set; }

        public MainWindow(Controller.ViewController viewController)
        {
            ViewController = viewController;
            InitializeComponent();
            this.Show();
        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            ViewController.LoadFile();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            ViewController.MakeGrid(1, 2);
            ViewController.DrawField("Type", 1, 2);
        }

        public void DrawField(object sender, EventArgs e)
        {
            MyEventArgs.DrawFieldArgs drawFieldArgs = (MyEventArgs.DrawFieldArgs)e;
            string type = drawFieldArgs.Type;
            int x = drawFieldArgs.X;
            int y = drawFieldArgs.Y;

            Debug.WriteLine("Draw field main, Type: " + type + ", X: " + x + ", Y: " + y + ".");
            switch (type)
            {
                case "Field":
                    // TODO laad of teken plaatje
                    
                    break;

                case "StartField":
                    // TODO laad of teken plaatje
                    break;

                case "SafeField":
                    // TODO laad of teken plaatje
                    break;

                case "GoalField":
                    // TODO laad of teken plaatje
                    break;

                case "LinkField":
                    // TODO laad of teken plaatje
                    break;

                case "BarricadeField":
                    // TODO laad of teken plaatje
                    break;

                case "Forest":
                    // TODO laad of teken plaatje
                    break;
            }
            
        }

        public void MakeGrid(object sender, EventArgs e)
        {
            MyEventArgs.MakeGridArgs makeGridArgs = (MyEventArgs.MakeGridArgs)e;

            //X en Y zijn aantal vakjes, size wordt bepaald door het scherm. 
            int x = makeGridArgs.X;
            int y = makeGridArgs.Y;

            Debug.WriteLine("Make Grid main, X: " + x + ", Y: " + y + ".");

            int CellSize = getCellSize(y, x);

            for (int i = 0; i < x; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(CellSize);
                SpelGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < y; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(CellSize);
                SpelGrid.RowDefinitions.Add(row);
            }

            SpelGrid.ShowGridLines = false;
        }

        private int getCellSize(int nRows, int nCols)
        {
            double w = MainGrid.ActualWidth;
            double h = MainGrid.ActualHeight - 76;

            Debug.WriteLine("Found window size (" + w + "," + h + ")");

            int hCellSize = (int)(h / nRows);
            int wCellSize = (int)(w / nCols);

            Debug.WriteLine("hCellSize: " + hCellSize);
            Debug.WriteLine("wCellSize: " + wCellSize);

            if (hCellSize < wCellSize)
            {
                Debug.WriteLine("Chosen hCellSize as CellSize");
                return hCellSize;
            }
            else
            {
                Debug.WriteLine("Chosen wCellSize as CellSize");
                return wCellSize;
            }
        }
    }
}
