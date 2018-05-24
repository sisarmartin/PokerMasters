using System;

public class CreditsScreen
{
    private string name;

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  ---------- Credits ----------");
        Console.WriteLine();
    }

    protected string[] names = { "Directed: César Martín", "Cesar" };

    public void Run()
    {
        string press;

        do
        {
            ShowMenu();
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Press Q to return...");
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
        Console.Clear();
        WelcomeScreen welcome = new WelcomeScreen();
        welcome.Display();
    }
}