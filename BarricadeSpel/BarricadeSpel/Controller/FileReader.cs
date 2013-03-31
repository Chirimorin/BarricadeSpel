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
        public static void Read(string domain, ViewController viewController)
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

            Debug.WriteLine("");

            Model.Field[,] fields = new Model.Field[(numLines + 1) / 2, (numChars / 4) - 1];

            viewController.MakeGrid((numLines + 1) / 2, (numChars / 4) - 1);

            for (int i = 0; i < numLines; i++)
            {
                if (i % 2 == 0) //only parse even lines, uneven lines are all connector lines.
                {
                    int returnTo = 0;
                    int.TryParse(characters[0, i], out returnTo);

                    bool barricadeAllowed = false;
                    if (characters[1, i] == "B")
                    {
                        barricadeAllowed = true;
                    }

                    for (int j = 1; j < numChars / 4; j++)
                    {
                        Model.Field exitN = null;
                        Model.Field exitW = null;

                        if (i != 0)
                        {
                            if (characters[(j * 4) + 1, i - 1] == "|")
                            {
                                Debug.WriteLine("ExitN found");

                                exitN = fields[j - 1, (i/2) - 1];
                            }
                        }

                        if (j != 1)
                        {
                            if (characters[(j * 4) - 1, i] == "-")
                            {
                                Debug.WriteLine("ExitW found");
                                exitW = fields[j - 2, (i/2)];
                            }
                        }

                        switch (characters[(j * 4), i]) //vakjes aanmaken. 
                        {
                            case "<":
                                if (characters[(j * 4) + 1, i] == " ") //goal
                                {
                                    fields[j - 1, (i/2)] = new Model.GoalField(exitN, null, null, exitW);
                                    viewController.DrawField("GoalField", j - 1, (i / 2));
                                    break;
                                }
                                int numForest;
                                if (int.TryParse(characters[(j * 4) + 1, i], out numForest)) //forest
                                {
                                    fields[j - 1, (i/2)] = new Model.Forest(exitN, null, null, exitW, numForest);
                                    viewController.DrawField("Forest", j - 1, (i / 2));
                                    break;
                                }
                                //else startfield
                                fields[j - 1, (i / 2)] = new Model.StartField(exitN, null, null, exitW, characters[(j * 4) + 2, i]);
                                viewController.DrawField("StartField", j - 1, (i / 2));
                                break;
                            case "(":
                                fields[j - 1, (i / 2)] = new Model.Field(exitN, null, null, exitW, barricadeAllowed, returnTo);
                                viewController.DrawField("Field", j - 1, (i / 2));
                                break;
                            case "[":
                                fields[j - 1, (i / 2)] = new Model.BarricadeField(exitN, null, null, exitW, barricadeAllowed, returnTo);
                                viewController.DrawField("BarricadeField", j - 1, (i / 2));
                                break;
                            case "{":
                                fields[j - 1, (i / 2)] = new Model.SafeField(exitN, null, null, exitW, barricadeAllowed, returnTo);
                                viewController.DrawField("SafeField", j - 1, (i / 2));
                                break;
                            case " ":
                                if (characters[(j * 4) + 1, i] == "|")
                                {
                                    fields[j - 1, (i / 2)] = new Model.LinkField(exitN, null, null, exitW);
                                    viewController.DrawField("LinkField", j - 1, (i / 2));
                                }
                                break;
                        }

                        switch (characters[(j * 4) + 1, i])
                        {
                            case "*":
                                new Model.Barricade(fields[j - 1, (i / 2)]);
                                break;
                            case "R":
                            case "Y":
                            case "G":
                            case "B":
                                new Model.Pawn(fields[j - 1, (i / 2)], characters[(j * 4) + 1, i]);
                                break;
                        }

                        //TODO pionnen aan spelers linken IPV alleen velden

                    }
                }
            }
        
        }


    }
}
