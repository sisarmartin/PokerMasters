using System;
using System.Threading;

public class CreditsScreen : WelcomeScreen
{
    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  ---------- Credits ----------");
        Console.WriteLine();
    }

    protected string[] names = {
        "Producer and Project Director: César Martín",
        "Lead Programmer and Assistant Director: César Martín",
        "Programmers: César Martín",
        "Designer: César Martín",
        "Interface: César Martín",
        "Textures: César Martín" };

    public void Run()
    {
        ShowMenu();
        for (int i = 0; i < names.Length; i++)
        {
            Console.Clear();
            int x = 140;
            int y = 35;
            Console.SetCursorPosition((x / 2) - (names[i].Length / 2),
                y / 2);
            Console.WriteLine(names[i]);
            Thread.Sleep(2000);
        }
        
        Display();
    }
}