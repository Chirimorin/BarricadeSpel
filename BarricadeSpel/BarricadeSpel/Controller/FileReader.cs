using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string[,] characters = new string[lines[0].Length, lines.Length];

            int numLines = lines.Length;
            int numChars = 0;

            for (int i = 0; i < numLines; i++) //making a 2 dimensional array of characters
            {
                Debug.WriteLine("");
                string[] line = lines[i].ToCharArray().Select( c => c.ToString()).ToArray(); //string array van losse characters
                if (numChars == 0)
                    numChars = line.Length;
                for (int j = 0; j < numChars; j++)
                {
                    characters[j, i] = line[j];
                    Debug.Write(line[j]);
                }
            }

            Model.Field[,] fields = new Model.Field[(numLines + 1) / 2, (numChars / 4) - 1];

            for (int i = 0; i < numLines; i++)
            {
                if (i % 2 != 0) //only parse uneven lines, even lines are all connector lines.
                {
                    //check for returnto
                    

                    bool barricadeAllowed = false;
                    if (characters[2, i] == "B")
                    {
                        barricadeAllowed = true;
                    }

                    for (int j = 1; j < numChars / 4; j++)
                    {
                        switch (characters[(j * 4) + 1, i]) //vakjes aanmaken. 
                        {
                            case "<":

                                break;
                            case "(":

                                break;
                            case "[":

                                break;
                            case "{":

                                break;
                        }
                    }
                }
            }
        
        }


    }
}
