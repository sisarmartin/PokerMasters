using System;
using System.Collections.Generic;

public class DrawCard
{
    public int Pot { get; set; }
    public struct Positions
    {
        public int X;
        public int Y;
    }

    public static void Draw(List<Player> Players, CardsDeck deck)
    {
        Positions[] positions = new Positions[6];
        positions[0].X = 10;
        positions[0].Y = 5;
        positions[1].X = 55;
        positions[1].Y = 5;
        positions[2].X = 95;
        positions[2].Y = 5;
        positions[3].X = 10;
        positions[3].Y = 30;
        positions[4].X = 55;
        positions[4].Y = 30;
        positions[5].X = 95;
        positions[5].Y = 30;

        //Generator for random numbers
        Random r = new Random();

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
                Console.SetCursorPosition(positions[i].X, positions[i].Y + i);
                //Console.SetCursorPosition(Players[i].X,Players[i].Y + j);
                Console.WriteLine(cards[j]);
            }

        }
    }

    public static void DrawTable(CardsDeck deck, int Pot)
    {
        Random r = new Random();

        int number = r.Next(0, deck.Count);
        Card card1 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        number = r.Next(0, deck.Count);
        Card card2 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        number = r.Next(0, deck.Count);
        Card card3 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        //burn
        number = r.Next(0, deck.Count);
        deck.Cards.RemoveAt(number);

        string[] table =
        {
            "  --------------------------------------------   ",
            " /                                            \\  ",
            "|    ---  ---  ---  ---  ---                   |",
            "|   | "+card1.Rank+" || "+card2.Rank+" || "+card3.Rank+" ||   " +
                "||   |       POT:       |",
            "|   | "+card1.Suit+" || "+card1.Suit+" || "+card1.Suit+" ||   " +
                "||   |     "+Pot.ToString("000000")+"       |",
            "|   |   ||   ||   ||   ||   |                  |",
            "|    ---  ---  ---  ---  ---                   |",
            " \\                                            / ",
            "  --------------------------------------------   ",
        };

        for (int i = 0; i < table.Length; i++)
        {
            Console.SetCursorPosition(40, 12+i);
            Console.WriteLine(table[i]);
        }
    }
}