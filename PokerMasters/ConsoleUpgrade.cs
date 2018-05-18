using System;
using System.IO;

public class ConsoleUpgrade : Hand
{
    public ConsoleUpgrade()
    {
    }

    // You should assign a different position for each player.
    public void Position()
    {
        xHand = xHand + 10;
        yHand = yHand + 10;
    }

    //Write the player's characteristics to the right of the welcome screen.
    public static void WriteNames(int x, int y, Player player)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(player.UserName+ ", you have "+ player.Chips
            +" chips");
    }

    //Created this method for when we use configuration file
    public void CreateConfig()
    {
        StreamReader inFile;
        StreamWriter outFile;
        string line;

        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();

        if (!File.Exists("config.txt"))
        {
            Console.WriteLine("File not found!");
            return;
        }

        try
        {
            inFile = File.OpenText("config.txt");
            outFile = File.CreateText("config.txt");
            do
            {
                line = inFile.ReadLine();
                if (line != null)
                {
                    // TO DO
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
}