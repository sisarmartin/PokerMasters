using System;

class CreditsScreen
{
    private string name;

    public void ShowMenu()
    {
        Console.WriteLine("-------- Credits --------");
        Console.WriteLine();
    }

    public void Run()
    {
        ShowMenu();
        Console.WriteLine("Press to return...");
        string press = Console.ReadLine();
        // To do
    }
}