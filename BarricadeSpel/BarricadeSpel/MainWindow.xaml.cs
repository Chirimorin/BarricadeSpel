﻿using System;
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
            //TODO veld tekenen.
        }

        public void MakeGrid(object sender, EventArgs e)
        {
            MyEventArgs.MakeGridArgs makeGridArgs = (MyEventArgs.MakeGridArgs)e;
            int x = makeGridArgs.X;
            int y = makeGridArgs.Y;

            Debug.WriteLine("Make Grid main, X: " + x + ", Y: " + y + ".");
            //TODO grid aanmaken.
        }
    }
}
