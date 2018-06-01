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

    public void ShowMenuEsp()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  ---------- Creditos ----------");
        Console.WriteLine();
    }

    protected string[] names = {
        "Producer and Project Director: César Martín",
        "Lead Programmer and Assistant Director: César Martín",
        "Programmers: César Martín",
        "Designer: César Martín",
        "Interface: César Martín",
        "Textures: César Martín"
    };

    protected string[] namesEsp = {
        "Producido y Director del proyecto: César Martín",
        "Líder programador y asistente director: César Martín",
        "Programador: César Martín",
        "Diseñador: César Martín",
        "Interfaz: César Martín",
        "Texturas: César Martín"
    };

    public void Run()
    {
        ShowMenu();
        for (int i = 0; i < names.Length; i++)
        {
            Console.Clear();
            int x = 140;
            int y = 35;
            Console.CursorVisible = false;
            Console.SetCursorPosition((x / 2) - (names[i].Length / 2),
                y / 2);
            Console.WriteLine(names[i]);
            Thread.Sleep(2000);
        }
    }

    public void RunEsp()
    {
        ShowMenu();
        for (int i = 0; i < namesEsp.Length; i++)
        {
            Console.Clear();
            int x = 140;
            int y = 35;
            Console.CursorVisible = false;
            Console.SetCursorPosition((x / 2) - (namesEsp[i].Length / 2),
                y / 2);
            Console.WriteLine(namesEsp[i]);
            Thread.Sleep(2000);
        }
    }
}