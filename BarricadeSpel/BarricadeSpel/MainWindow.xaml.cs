using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private int CellSize { get; set; }


        //Constructor
        public MainWindow(Controller.ViewController viewController)
        {
            ViewController = viewController;
            InitializeComponent();
            this.Show();
        }


        //Input handling
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            ViewController.LoadFile();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            ViewController.MakeGrid(1, 2);
            ViewController.DrawField("Field", 1, 2);
        }


        //Output functions
        public void ClearGrid()
        {
            SpelGrid.Children.Clear();
            SpelGrid.ColumnDefinitions.Clear();
            SpelGrid.RowDefinitions.Clear();
        }
        
        public void DrawField(object sender, EventArgs e)
        {
            MyEventArgs.DrawFieldArgs drawFieldArgs = (MyEventArgs.DrawFieldArgs)e;
            string type = drawFieldArgs.Type;
            int x = drawFieldArgs.XPos;
            int y = drawFieldArgs.YPos;

            Debug.WriteLine("Draw field main, Type: " + type + ", X: " + x + ", Y: " + y + ".");

            switch (type)
            {
                case "Field":
                case "StartField":
                case "SafeField":
                case "GoalField":
                case "BarricadeField":
                    Ellipse myCircle = new Ellipse();
                    myCircle.StrokeThickness = CellSize/5;
                    myCircle.Stroke = Brushes.Transparent;
                    myCircle.HorizontalAlignment = HorizontalAlignment.Stretch;
                    myCircle.VerticalAlignment = VerticalAlignment.Stretch;
                    myCircle.SetValue(Grid.ColumnProperty, x);
                    myCircle.SetValue(Grid.RowProperty, y);

                    switch (type)
                    {
                        case "Field":
                            myCircle.Fill = Brushes.Black;
                            break;

                        case "StartField":
                            myCircle.Fill = Brushes.White;
                            break;

                        case "SafeField":
                            myCircle.Fill = Brushes.Cyan;
                            break;

                        case "GoalField":
                            myCircle.Fill = Brushes.LightGreen;
                            break;
                        case "BarricadeField":
                            myCircle.Fill = System.Windows.Media.Brushes.Red;
                            break;
                    }
                    SpelGrid.Children.Add(myCircle);
                    break;
                case "LinkField":
                case "LinkLeft":
                case "LinkUp":
                    Line myLine = new Line();
                    myLine.StrokeThickness = 5;
                    myLine.Stroke = Brushes.Black;
                    myLine.SetValue(Grid.ColumnProperty, x);
                    myLine.SetValue(Grid.RowProperty, y);
                    switch (type)
                    {
                        case "LinkField":
                            myLine.HorizontalAlignment = HorizontalAlignment.Center;
                            myLine.VerticalAlignment = VerticalAlignment.Top;
                            myLine.X1 = 2;
                            myLine.X2 = 2;
                            myLine.Y1 = 0;
                            myLine.Y2 = CellSize;
                            break;
                        case "LinkLeft":
                            myLine.HorizontalAlignment = HorizontalAlignment.Left;
                            myLine.VerticalAlignment = VerticalAlignment.Center;
                            myLine.X1 = -(CellSize / 5)+3;
                            myLine.X2 = (CellSize / 5)-3;
                            myLine.Y1 = 2;
                            myLine.Y2 = 2;
                            break;
                        case "LinkUp":
                            myLine.HorizontalAlignment = HorizontalAlignment.Center;
                            myLine.VerticalAlignment = VerticalAlignment.Top;
                            myLine.X1 = 2;
                            myLine.X2 = 2;
                            myLine.Y1 = -(CellSize / 5)+3;
                            myLine.Y2 = (CellSize / 5)-3;
                            break;
                    }
                    SpelGrid.Children.Add(myLine);
                    break;

                case "Forest":
                    //TODO teken forest
                    break;
            }
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
            ClearGrid();
            MyEventArgs.MakeGridArgs makeGridArgs = (MyEventArgs.MakeGridArgs)e;
            
            //X en Y zijn aantal vakjes, size wordt bepaald door het scherm. 
            int x = makeGridArgs.X;
            int y = makeGridArgs.Y;

            Debug.WriteLine("Make Grid main, X: " + x + ", Y: " + y + ".");

            FindCellSize(y, x);

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


        //Other functions
        private void FindCellSize(int nRows, int nCols)
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
                CellSize = hCellSize;
            }
            else
            {
                Debug.WriteLine("Chosen wCellSize as CellSize");
                CellSize = wCellSize;
            }
        }


    }
}
