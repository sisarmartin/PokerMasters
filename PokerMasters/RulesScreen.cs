using System;

class RulesScreen
{
    private string text;
    
    public void ShowMenu()
    {
        Console.WriteLine("-------- Rules of Game --------");
        Console.WriteLine();
    }

    public void Display()
    {
        ShowMenu();
        Console.WriteLine("Press to return...");
        string press = Console.ReadLine();
        // To do
    }
}