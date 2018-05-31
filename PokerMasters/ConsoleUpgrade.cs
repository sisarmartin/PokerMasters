using System;
using System.Collections.Generic;
using System.IO;

public class ConsoleUpgrade
{
    public struct Positions
    {
        public int X;
        public int Y;
    }

    public List<Player> Players { get; set; }
    public ConsoleUpgrade()
    {
        Players = new List<Player>();
    }

    //Write the player's characteristics to the right of the welcome screen.
    public static void WriteNames(Player player)
    {
        Console.SetCursorPosition(50, 2);
        Console.WriteLine(player.UserName+ ", you have "+ player.Chips
            +" chips");
    }

    //Created this method for when we use configuration file
    public static void CreateConfig(List<Player> Players)
    {
        StreamWriter outFile;
        DateTime now = DateTime.Now;
        
        try
        {
            outFile = File.AppendText(@"..\..\..\configs\logs.txt");

            outFile.WriteLine("/Logs PokerMasters/");

            for (int i = 0; i < Players.Count; i++)
            {
                outFile.WriteLine(Players[i].UserName + "@" + 
                    Players[i].Chips + "@" + now + "@" + Players[i].X
                    + "@" + Players[i].Y);
            }
            
            outFile.Close();
        }
        catch (PathTooLongException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Entered path was too long.");
            return;
        }
        catch (FileNotFoundException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("File not found.");
            return;
        }
        catch (IOException exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Input/output error: {0}", exp.Message);
            return;
        }
        catch (Exception exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Unexpected error: {0}", exp.Message);
            return;
        }
        Console.SetCursorPosition(119, 33);
        Console.WriteLine("Extraction finished");
    }

    public static void CreateConfigEsp(List<Player> Players)
    {
        StreamWriter outFile;
        DateTime now = DateTime.Now;

        try
        {
            outFile = File.AppendText(@"..\..\..\configs\logs.txt");

            outFile.WriteLine("/Logs PokerMasters/");

            for (int i = 0; i < Players.Count; i++)
            {
                outFile.WriteLine(Players[i].UserName + "@" +
                    Players[i].Chips + "@" + now + "@" + Players[i].X
                    + "@" + Players[i].Y);
            }

            outFile.Close();
        }
        catch (PathTooLongException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("La ruta introducida era demasiado larga.");
            return;
        }
        catch (FileNotFoundException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Fichero no encontrado.");
            return;
        }
        catch (IOException exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Error salida/entrada: {0}", exp.Message);
            return;
        }
        catch (Exception exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Error inesperado: {0}", exp.Message);
            return;
        }
        Console.SetCursorPosition(119, 33);
        Console.WriteLine("Extraído correctamente");
    }

    //Created this method for when use Hi Scores in HiScoresSreen.cs
    public static void ShowScores()
    {
        StreamReader inFile;
        StreamWriter outFile;
        string line;

        try
        {
            inFile = File.OpenText(@"..\..\..\configs\logs.txt");
            outFile = File.CreateText(@"..\..\..\configs\hiScores.txt");

            do
            {
                line = inFile.ReadLine();
                if (line != null)
                {
                    Extract(line, outFile);
                }
            } while (line != null);
            outFile.Close();
            inFile.Close();
        }
        catch (PathTooLongException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Entered path was too long.");
            return;
        }
        catch (FileNotFoundException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("File not found.");
            return;
        }
        catch (IOException exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Input/output error: {0}", exp.Message);
            return;
        }
        catch (Exception exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Unexpected error: {0}", exp.Message);
            return;
        }
        Console.SetCursorPosition(119, 33);
        Console.WriteLine("Extraction finished");
    }

    public static void ShowScoresEsp()
    {
        StreamReader inFile;
        StreamWriter outFile;
        string line;

        try
        {
            inFile = File.OpenText(@"..\..\..\configs\logs.txt");
            outFile = File.CreateText(@"..\..\..\configs\hiScores.txt");

            do
            {
                line = inFile.ReadLine();
                if (line != null)
                {
                    ExtractEsp(line, outFile);
                }
            } while (line != null);
            outFile.Close();
            inFile.Close();
        }
        catch (PathTooLongException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("La ruta introducida era demasiado larga.");
            return;
        }
        catch (FileNotFoundException)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Fichero no encontrado.");
            return;
        }
        catch (IOException exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Error salida/entrada: {0}", exp.Message);
            return;
        }
        catch (Exception exp)
        {
            Console.SetCursorPosition(119, 33);
            Console.WriteLine("Error inesperado: {0}", exp.Message);
            return;
        }
        Console.SetCursorPosition(119, 33);
        Console.WriteLine("Extraído correctamente");
    }

    public static void Extract(string line, StreamWriter file)
    {
        if (line.Contains("/Logs PokerMasters/"))
        {
            line = line.Replace("/Logs PokerMasters/", "New High Scores");
        }

        int positionUsername = line.IndexOf('@');
        string[] usernames = line.Split('@');
        string chips = line.Substring(positionUsername + 1, 5);
        line = line.Replace("@", " ");
        foreach (string player in usernames)
        {
            file.WriteLine(player);
            file.WriteLine();
        }
    }

    public static void ExtractEsp(string line, StreamWriter file)
    {
        if (line.Contains("/Logs PokerMasters/"))
        {
            line = line.Replace("/Logs PokerMasters/", "Nuevas Puntuaciones");
        }

        int positionUsername = line.IndexOf('@');
        string[] usernames = line.Split('@');
        string chips = line.Substring(positionUsername + 1, 5);
        line = line.Replace("@", " ");
        foreach (string player in usernames)
        {
            file.WriteLine(player);
            file.WriteLine();
        }
    }
}