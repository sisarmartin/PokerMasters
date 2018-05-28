﻿using System;
using System.Collections.Generic;
using System.IO;

public class ConsoleUpgrade
{
    public List<Player> Players { get; set; }
    public ConsoleUpgrade()
    {
        Players = new List<Player>();
    }

    // You should assign a different position for each player.
    public void Position()
    {
        // To do
    }

    //Write the player's characteristics to the right of the welcome screen.
    public static void WriteNames(int x, int y, Player player)
    {
        Console.SetCursorPosition(x, y);
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
    }

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
            inFile.Close();
            outFile.Close();
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
    }

    public static void Extract(string line, StreamWriter file)
    {
        int position = line.IndexOf('@', 0);

        line = line.Substring(position);
        file.WriteLine(line);
        file.WriteLine();
    }
}