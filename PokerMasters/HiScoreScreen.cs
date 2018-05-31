using System;
using System.IO;
using System.Collections.Generic;

class HiScoreScreen
{
    public List<Player> Players { get; set; }

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  -------- High Scores --------");
        Console.WriteLine();
    }

    public void ShowMenuEsp()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  -------- Puntuaciones --------");
        Console.WriteLine();
    }

    public void Run()
    {
        string press;

        do
        {
            ShowMenu();
            // To do

            ConsoleUpgrade.ShowScores();

            try
            {
                StreamReader input =
                new StreamReader(@"..\..\..\configs\hiScores.txt");
                string line;

                do
                {
                    line = input.ReadLine();
                    if (line != null)
                    {
                        Console.WriteLine(line);
                    }
                } while (line != null);
                input.Close();
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Entered path was too long.");
                return;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                return;
            }
            catch (IOException exp)
            {
                Console.WriteLine("Input/output error: {0}", exp.Message);
                return;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Unexpected error: {0}", exp.Message);
                return;
            }
            Console.WriteLine("Extraction finished");

            Console.WriteLine();
            Console.WriteLine("Press Q to return...");
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
        Console.Clear();
        WelcomeScreen welcome = new WelcomeScreen();
        welcome.Display();
    }

    public void RunEsp()
    {
        string press;

        do
        {
            ShowMenuEsp();
            // To do

            ConsoleUpgrade.ShowScores();

            try
            {
                StreamReader input =
                new StreamReader(@"..\..\..\configs\hiScores.txt");
                string line;

                do
                {
                    line = input.ReadLine();
                    if (line != null)
                    {
                        Console.WriteLine(line);
                    }
                } while (line != null);
                input.Close();
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Entered path was too long.");
                return;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                return;
            }
            catch (IOException exp)
            {
                Console.WriteLine("Input/output error: {0}", exp.Message);
                return;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Unexpected error: {0}", exp.Message);
                return;
            }
            Console.WriteLine("Extraction finished");

            Console.WriteLine();
            Console.WriteLine("Pulsa Q para volver...");
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
        Console.Clear();
        WelcomeScreen welcome = new WelcomeScreen();
        welcome.DisplayEsp();
    }
}