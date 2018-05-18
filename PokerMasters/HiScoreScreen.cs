using System;

class HiScoreScreen
{
    private string userName;
    private int chips;

    public void ShowMenu()
    {
        Console.WriteLine("-------- High Scores --------");
        Console.WriteLine();
    }

    public void Run()
    {
        ShowMenu();
        Console.WriteLine("Press to return...");
        string press = Console.ReadLine();
        do
        {
            Console.Clear();
            WelcomeScreen welcome = new WelcomeScreen();
            welcome.Display();

        } while (press != "");
        // To do
    }
}