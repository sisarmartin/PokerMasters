using System;
using System.Collections.Generic;
using System.IO;

public class ConsoleUpgrade : Hand
{
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
    public void CreateConfig(List<Player> Players)
    {
        StreamWriter outFile;
        DateTime now = DateTime.Now;
        
        try
        {
            outFile = File.AppendText(@"..\..\..\configs\config.txt");
            
                    for (int i = 0; i < Players.Count; i++)
                    {
                        outFile.WriteLine(now + Players[i].UserName +
                            " " + Players[i].Chips);
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
}