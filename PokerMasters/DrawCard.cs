﻿using System;
using System.Collections.Generic;

public class DrawCard
{
    private GameScreen Game { get; set; }
    public struct Positions
    {
        public int X;
        public int Y;
    }

    public static void Draw(List<Player> Players, CardsDeck deck)
    {
        Positions[] positions = new Positions[6];
        positions[0].X = 20;
        positions[0].Y = 5;
        positions[1].X = 60;
        positions[1].Y = 5;
        positions[2].X = 100;
        positions[2].Y = 5;
        positions[3].X = 20;
        positions[3].Y = 25;
        positions[4].X = 60;
        positions[4].Y = 25;
        positions[5].X = 100;
        positions[5].Y = 25;

        //Generator for random numbers
        Random r = new Random();

        // Positions for players, with username and chips, and cards
        for (int i = 0; i < Players.Count; i++)
        {
            int number = r.Next(0, deck.Count);
            Players[i].cards[0] = deck.Cards[number];
            deck.Cards.RemoveAt(number);

            number = r.Next(0, deck.Count);
            Players[i].cards[1] = deck.Cards[number];
            deck.Cards.RemoveAt(number);

            string[] cards = { " ---  --- ",
                           "| "+Players[i].cards[0].Rank+" || "
                                +Players[i].cards[1].Rank+" |",
                           "| "+Players[i].cards[0].Suit+" || "
                                +Players[i].cards[1].Suit+" |",
                           "|   ||   |",
                           " ---  --- "};
        
            for (int j = 0; j < cards.Length; j++)
            {
                Console.SetCursorPosition(positions[i].X, positions[i].Y + j);
                Console.WriteLine(cards[j]);
            }

            Console.SetCursorPosition(positions[i].X, positions[i].Y - 2);
            Console.WriteLine("Name: " + Players[i].UserName);
            Console.SetCursorPosition(positions[i].X, positions[i].Y - 1);
            Console.WriteLine("Chips: " + Players[i].Chips);
        }
    }

    // Draw a table game with cards.
    public static void DrawTable(CardsDeck deck, int pot)
    {
        string[] table =
        {
            "  --------------------------------------------   ",
            " /                                            \\  ",
            "|    ---  ---  ---  ---  ---                   |",
            "|   |   ||   ||   ||   ||   |       POT:       |",
            "|   |   ||   ||   ||   ||   |     "+pot.ToString("000000")+
            "       |",
            "|   |   ||   ||   ||   ||   |                  |",
            "|    ---  ---  ---  ---  ---                   |",
            " \\                                            / ",
            "  --------------------------------------------   ",
        };
        
        for (int i = 0; i < table.Length; i++)
        {
            Console.SetCursorPosition(45, 12+i);
            Console.WriteLine(table[i]);
        }
    }

    public static void DrawResult(List<Player> Players)
    {
        Console.SetCursorPosition(110, 13);
        Console.WriteLine(Players[0].UserName+" wins!");
    }
}