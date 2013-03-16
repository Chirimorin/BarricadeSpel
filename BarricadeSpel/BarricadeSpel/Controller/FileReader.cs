using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Controller
{
    class FileReader
    {
        /**
         * Reads all lines in a file.
         * @param domain: The domain name of the file.
         */
        public static void Read(string domain)
        {
            string[] lines = System.IO.File.ReadAllLines(domain);
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
                Console.WriteLine("\n" + line);
        
        }
    }
}
