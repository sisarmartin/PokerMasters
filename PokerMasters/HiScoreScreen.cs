﻿using System;
using System.Collections.Generic;

class HiScoreScreen
{
    public List<Player> Players { get; set; }
    private string userName;
    private int chips;

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  -------- High Scores --------");
        Console.WriteLine();
    }

    public void Run()
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