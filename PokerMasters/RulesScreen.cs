using System;

class RulesScreen
{
    private string text;

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  ---------- Rules ----------");
        Console.WriteLine();
    }

    public void Display()
    {
        string press;

        do
        {
            ShowMenu();
            // To do

            Console.WriteLine();
            Console.WriteLine("Press Q to return...");
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
        Console.Clear();
        WelcomeScreen welcome = new WelcomeScreen();
        welcome.Display();
    }
}