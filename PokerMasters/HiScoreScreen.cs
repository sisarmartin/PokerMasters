using System;
using System.IO;
using System.Collections.Generic;

class HiScoreScreen
{
    public List<Player> Players { get; set; }

    public void ShowMenu()
    {
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

    public void ShowExit()
    {
        Console.WriteLine("Press Q to go back...");
    }

    public void ShowExitEsp()
    {
        Console.WriteLine("Pulsa Q para volver...");
    }

    public void ShowNext()
    {
        Console.WriteLine("Press Enter to continue...");
    }

    public void ShowNextEsp()
    {
        Console.WriteLine("Pulsa Enter para continuar...");
    }

    public void Run()
    {
        string press;

        do
        {
            ShowMenu();
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
                        if (line.Length % 5 == 4)
                        {
                            Console.CursorVisible = false;
                            Console.ReadLine();
                            Console.Clear();
                            ShowMenu();
                        }
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
            ShowExit();

            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
    }

    public void RunEsp()
    {
        string press;

        do
        {
            ShowMenuEsp();
            ShowNextEsp();

            ConsoleUpgrade.ShowScoresEsp();

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
                        if (line.Length % 5 == 4)
                        {
                            Console.CursorVisible = false;
                            Console.ReadLine();
                            Console.Clear();
                            ShowMenuEsp();
                            ShowNextEsp();
                        }
                    }
                } while (line != null);
                input.Close();
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("La ruta introducida era demasiado larga.");
                return;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichero no encontrado.");
                return;
            }
            catch (IOException exp)
            {
                Console.WriteLine("Error salida/entrada: {0}", exp.Message);
                return;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error inesperado: {0}", exp.Message);
                return;
            }
            Console.WriteLine("Extraído correctamente");
            ShowExitEsp();

            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
    }
}