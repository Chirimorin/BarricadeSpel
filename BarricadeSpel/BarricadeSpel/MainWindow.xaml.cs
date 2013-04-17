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

        private List<PawnDrawing> Pawns { get; set; }
        private List<BarricadeDrawing> Barricades { get; set; }
        private List<InputDrawing> Inputs { get; set; }

        //Constructor
        public MainWindow(Controller.ViewController viewController)
        {
            ViewController = viewController;
            InitializeComponent();
            this.Show();
            Pawns = new List<PawnDrawing>();
            Barricades = new List<BarricadeDrawing>();
            Inputs = new List<InputDrawing>();
        }


        //Input handling
        private void Cheats_R(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Turn("R");
        }

        private void Cheats_G(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Turn("G");
        }

        private void Cheats_Y(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Turn("Y");
        }

        private void Cheats_B(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Turn("B");
        }

        private void Cheats_1(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Dice(1);
        }

        private void Cheats_2(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Dice(2);
        }

        private void Cheats_3(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Dice(3);
        }

        private void Cheats_4(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Dice(4);
        }

        private void Cheats_5(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Dice(5);
        }

        private void Cheats_6(object sender, RoutedEventArgs e)
        {
            ViewController.Cheats_Dice(6);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Input_Click(object sender, EventArgs e)
        {
            int i = 0;

            while (i < Inputs.Count)
            {
                if (Inputs.ElementAt(i).Circle == sender)
                {
                    ViewController.InputSelected(i);
                }
                i++;
            }
        }

        private void NewPawn_Click(object sender, RoutedEventArgs e)
        {
            ViewController.NewPawn();
        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            ViewController.LoadFile();
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            ViewController.RollDice();
        }

        private void SkipTurn_Click(object sender, RoutedEventArgs e)
        {
            ViewController.SkipTurn();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            ViewController.Test();
        }


        //Output functions
        private void ClearGrid()
        {
            SpelGrid.Children.Clear();
            SpelGrid.ColumnDefinitions.Clear();
            SpelGrid.RowDefinitions.Clear();
        }

        public void DiceRolled(object sender, EventArgs e)
        {
            MyEventArgs.DiceRolledArgs diceRolledArgs = (MyEventArgs.DiceRolledArgs)e;
            int value = diceRolledArgs.Value;

            switch (value)
            {
                case 4:
                case 5:
                case 6:
                    DiceDot1.Visibility = Visibility.Visible;
                    DiceDot7.Visibility = Visibility.Visible;
                    break;
                default:
                    DiceDot1.Visibility = Visibility.Hidden;
                    DiceDot7.Visibility = Visibility.Hidden;
                    break;
            }
            switch (value)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    DiceDot2.Visibility = Visibility.Visible;
                    DiceDot6.Visibility = Visibility.Visible;
                    break;
                default:
                    DiceDot2.Visibility = Visibility.Hidden;
                    DiceDot6.Visibility = Visibility.Hidden;
                    break;
            } 
            switch (value)
            {
                case 6:
                    DiceDot3.Visibility = Visibility.Visible;
                    DiceDot5.Visibility = Visibility.Visible;
                    break;
                default:
                    DiceDot3.Visibility = Visibility.Hidden;
                    DiceDot5.Visibility = Visibility.Hidden;
                    break;
            } 
            switch (value)
            {
                case 1:
                case 3:
                case 5:
                    DiceDot4.Visibility = Visibility.Visible;
                    break;
                default:
                    DiceDot4.Visibility = Visibility.Hidden;
                    break;
            }

            RollDice.IsEnabled = false;
        }

        public void DoneLoading(object sender, EventArgs e)
        {
            LabelMessage.Content = "Done";
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

            Debug.WriteLine("Draw Movable, type: " + type + " Color: " + color);

            if (type == "pawn")
            {
                PawnDrawing newPawn = new PawnDrawing(color, CellSize);
                newPawn.XPos = xPos;
                newPawn.YPos = yPos;
                Pawns.Add(newPawn);
                SpelGrid.Children.Add(newPawn.MyCanvas);
            }

            if (type == "barricade")
            {
                BarricadeDrawing newBarricade = new BarricadeDrawing(CellSize);
                newBarricade.XPos = xPos;
                newBarricade.YPos = yPos;
                Barricades.Add(newBarricade);
                SpelGrid.Children.Add(newBarricade.MyCanvas);
            }
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

        public void MoveBarricade(object sender, EventArgs e)
        {
            MyEventArgs.MovePawnArgs movePawnArgs = (MyEventArgs.MovePawnArgs)e;
            int index = movePawnArgs.Index;
            int newX = movePawnArgs.NewX;
            int newY = movePawnArgs.NewY;

            Barricades.ElementAt(index).XPos = newX;
            Barricades.ElementAt(index).YPos = newY;

        }

        public void MovePawn(object sender, EventArgs e)
        {
            MyEventArgs.MovePawnArgs movePawnArgs = (MyEventArgs.MovePawnArgs)e;
            int index = movePawnArgs.Index;
            int newX = movePawnArgs.NewX;
            int newY = movePawnArgs.NewY;

            Pawns.ElementAt(index).XPos = newX;
            Pawns.ElementAt(index).YPos = newY;

        }

        public void NewPawnEnabled(object sender, EventArgs e)
        {
            MyEventArgs.BoolEventArgs boolEventArgs = (MyEventArgs.BoolEventArgs)e;
            bool value = boolEventArgs.Value;

            NewPawn.IsEnabled = value;
        }

        public void NewTurn(object sender, EventArgs e)
        {

            MyEventArgs.NewTurnArgs newTurnArgs = (MyEventArgs.NewTurnArgs)e;

            string color = newTurnArgs.Color;

            RollDice.IsEnabled = true;

            switch(color)
            {
                case "R":
                    TurnColor.Fill = Brushes.Red;
                    break;
                case "G":
                    TurnColor.Fill = Brushes.Green;
                    break;
                case "Y":
                    TurnColor.Fill = Brushes.Yellow;
                    break;
                case "B":
                    TurnColor.Fill = Brushes.Blue;
                    break;
            }
            
        }

        public void OpenInput(object sender, EventArgs e)
        {
            MyEventArgs.OpenInputArgs openInputArgs = (MyEventArgs.OpenInputArgs)e;

            int xPos = openInputArgs.XPos;
            int yPos = openInputArgs.YPos;

            InputDrawing newInput = new InputDrawing(CellSize);
            newInput.XPos = xPos;
            newInput.YPos = yPos;
            Inputs.Add(newInput);
            SpelGrid.Children.Add(newInput.MyCanvas);

            newInput.Circle.MouseDown += Input_Click;
        }

        public void ResetGame(object sender, EventArgs e)
        {
            Pawns = new List<PawnDrawing>();
            Barricades = new List<BarricadeDrawing>();
            Inputs = new List<InputDrawing>();

        }

        public void ResetInputs(object sender, EventArgs e)
        {
            foreach (InputDrawing input in Inputs)
            {
                SpelGrid.Children.Remove(input.MyCanvas);
            }
            Inputs = new List<InputDrawing>();
        }

        public void SkipTurnEnabled(object sender, EventArgs e)
        {
            MyEventArgs.BoolEventArgs boolEventArgs = (MyEventArgs.BoolEventArgs)e;
            bool value = boolEventArgs.Value;

            SkipTurn.IsEnabled = value;
        }

        public void StartLoading(object sender, EventArgs e)
        {
            LabelMessage.Content = "Loading...";
        }

        //Other functions
        private void FindCellSize(int nRows, int nCols)
        {
            double w = MainGrid.ActualWidth -200;
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

    public class PawnDrawing //Extra class for easy pawn management. 
    {
        public Ellipse Circle1 { get; set; }
        public Ellipse Circle2 { get; set; }

        public Canvas MyCanvas { get; set; }

        public string Color { get; set; }

        public int XPos
        {
            set
            {
                MyCanvas.SetValue(Grid.ColumnProperty, value);
            }
        }
        public int YPos
        {
            set
            {
                MyCanvas.SetValue(Grid.RowProperty, value);
            }
        }

        //Constructor
        public PawnDrawing(string color, int cellSize)
        {
            Color = color;

            MyCanvas = new Canvas();

            Circle1 = new Ellipse();
            Circle1.StrokeThickness = 2;
            Circle1.Stroke = Brushes.Black;
            Circle1.HorizontalAlignment = HorizontalAlignment.Left;
            Circle1.VerticalAlignment = VerticalAlignment.Top;
            Circle1.Width = cellSize - ((cellSize / 5) * 2);
            Circle1.Height = cellSize - ((cellSize / 5) * 2);
            MyCanvas.Children.Add(Circle1);
            Canvas.SetLeft(Circle1, (cellSize / 5));
            Canvas.SetTop(Circle1, (cellSize / 5));

            Circle2 = new Ellipse();
            Circle2.StrokeThickness = 2;
            Circle2.Stroke = Brushes.Black;
            Circle2.HorizontalAlignment = HorizontalAlignment.Left;
            Circle2.VerticalAlignment = VerticalAlignment.Top;
            Circle2.Width = Circle1.Width / 1.5;
            Circle2.Height = Circle1.Height / 1.5;
            MyCanvas.Children.Add(Circle2);
            Canvas.SetLeft(Circle2, (cellSize / 5));
            Canvas.SetTop(Circle2, (cellSize / 5));

            switch (color)
            {
                case "R":
                    Circle1.Fill = Brushes.Red;
                    Circle2.Fill = Brushes.Red;
                    break;
                case "G":
                    Circle1.Fill = Brushes.Green;
                    Circle2.Fill = Brushes.Green;
                    break;
                case "Y":
                    Circle1.Fill = Brushes.Yellow;
                    Circle2.Fill = Brushes.Yellow;
                    break;
                case "B":
                    Circle1.Fill = Brushes.Blue;
                    Circle2.Fill = Brushes.Blue;
                    break;
            }
        }
    }

    public class BarricadeDrawing //Extra class for easy barricade management. 
    {
        public Ellipse Circle { get; set; }

        public Canvas MyCanvas { get; set; }

        public int XPos
        {
            set
            {
                MyCanvas.SetValue(Grid.ColumnProperty, value);
            }
        }
        public int YPos
        {
            set
            {
                MyCanvas.SetValue(Grid.RowProperty, value);
            }
        }

        //Constructor
        public BarricadeDrawing(int cellSize)
        {
            MyCanvas = new Canvas();

            Circle = new Ellipse();
            Circle.StrokeThickness = 2;
            Circle.Stroke = Brushes.Black;
            Circle.HorizontalAlignment = HorizontalAlignment.Left;
            Circle.VerticalAlignment = VerticalAlignment.Top;
            Circle.Fill = Brushes.White;
            Circle.Width = cellSize - ((cellSize / 7) * 2);
            Circle.Height = cellSize - ((cellSize / 7) * 2);
            MyCanvas.Children.Add(Circle);
            Canvas.SetLeft(Circle, (cellSize / 7));
            Canvas.SetTop(Circle, (cellSize / 7));
        }
    }

    public class InputDrawing //Extra class for easy input management.
    {
        public Ellipse Circle { get; set; }
        public Canvas MyCanvas { get; set; }

        public int XPos
        {
            set
            {
                MyCanvas.SetValue(Grid.ColumnProperty, value);
            }
        }
        public int YPos
        {
            set
            {
                MyCanvas.SetValue(Grid.RowProperty, value);
            }
        }


        //Constructor
        public InputDrawing(int cellSize)
        {
            MyCanvas = new Canvas();

            Circle = new Ellipse();
            Circle.StrokeThickness = 4;
            Circle.Stroke = Brushes.LimeGreen;
            Circle.HorizontalAlignment = HorizontalAlignment.Stretch;
            Circle.VerticalAlignment = VerticalAlignment.Stretch;
            Circle.Fill = Brushes.Transparent;
            Circle.Width = cellSize - ((cellSize / 10) * 2);
            Circle.Height = cellSize - ((cellSize / 10) * 2);
            MyCanvas.Children.Add(Circle);
            Canvas.SetLeft(Circle, (cellSize / 10));
            Canvas.SetTop(Circle, (cellSize / 10));
        }
    }
}
