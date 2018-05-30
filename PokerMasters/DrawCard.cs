using System;
using System.Collections.Generic;

public class DrawCard : ConsoleUpgrade
{
    private GameScreen Game { get; set; }

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
        // Big Blind

        Random rand = new Random();
        int bigBlind;/* = rand.Next(0, Players.Count - 1);
        Console.SetCursorPosition(positions[bigBlind].X + 14,
            positions[bigBlind].Y + 2);
        Console.WriteLine("B");

        Players[bigBlind].bigBlind = true;*/

        if (Players.Count == 2)
        {
            bigBlind = rand.Next(0, Players.Count - 1);
            Console.SetCursorPosition(positions[bigBlind].X + 14,
                positions[bigBlind].Y + 2);
            Console.WriteLine("B");
            Players[bigBlind].bigBlind = true;
        }
        else if (Players.Count == 3)
        {
            bigBlind = rand.Next(0, Players.Count - 1);
            Console.SetCursorPosition(positions[bigBlind + 1].X + 14,
                positions[bigBlind + 1].Y + 2);
            Console.WriteLine("B");
            Players[bigBlind + 1].bigBlind = true;
        }
        else if(Players.Count == 4)
        {
            bigBlind = rand.Next(0, Players.Count - 1);
            Console.SetCursorPosition(positions[bigBlind].X + 14,
                positions[bigBlind].Y + 2);
            Console.WriteLine("B");
            Players[bigBlind].bigBlind = true;
        }
        else if (Players.Count == 5)
        {
            bigBlind = rand.Next(0, Players.Count - 1);
            Console.SetCursorPosition(positions[bigBlind + 2].X + 14,
                positions[bigBlind + 2].Y + 2);
            Console.WriteLine("B");
            Players[bigBlind + 2].bigBlind = true;
        }
        // Small blind
        bigBlind = rand.Next(0, Players.Count - 1);
        Console.SetCursorPosition(positions[bigBlind + 1].X + 14,
            positions[bigBlind].Y + 2);
        Console.WriteLine("S");
        Players[bigBlind + 1].smallBlind = true;
    }

    public static void UpdateChips(List<Player> Players)
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
        for (int i = 0; i < Players.Count; i++)
        {
            Console.SetCursorPosition(positions[i].X, positions[i].Y - 1);
            Console.WriteLine("Chips: " + Players[i].Chips);
        }
    }

    // Draw a table game with cards.
    public static void DrawTable(CardsDeck deck)
    {
        string[] table =
        {
            "  --------------------------------------------   ",
            " /                                            \\  ",
            "|    ---  ---  ---  ---  ---                   |",
            "|   |   ||   ||   ||   ||   |       POT:       |",
            "|   |   ||   ||   ||   ||   |                  |",
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
    
    public static void DrawPot(int pot)
    {
        Console.SetCursorPosition(80, 16);
        Console.WriteLine(pot.ToString("000000"));
    }

    public static void DrawResult(List<Player> Players)
    {
        if (Players.Count == 2)
        {
            Console.SetCursorPosition(110, 13);
            Console.WriteLine(Players[0].UserName + " wins!");
        }
    }
}