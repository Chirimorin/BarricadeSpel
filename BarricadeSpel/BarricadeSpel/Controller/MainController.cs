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

        public MainController()
        {
            viewController = new ViewController(this);
        }

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
                Controller.FileReader.Read(dialog.FileName, viewController);
            }
        }
    }
}
