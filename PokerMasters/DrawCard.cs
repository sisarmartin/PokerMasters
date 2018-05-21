using System;

public class DrawCard
{
    public static void Draw(Player player, CardsDeck deck)
    {
        //Generator for random numbers
        Random r = new Random();

        int number = r.Next(0, deck.Count);
        player.cards[0] = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        number = r.Next(0, deck.Count);
        player.cards[1] = deck.Cards[number];
        deck.Cards.RemoveAt(number);



        string[] cards = { " ---  --- ",
                           "| "+player.cards[0].Rank+" || "
                                +player.cards[1].Rank+" |",
                           "| "+player.cards[0].Suit+" || "
                                +player.cards[1].Suit+" |",
                           "|   ||   |",
                           " ---  --- "};

        
        for (int i = 0; i < cards.Length; i++)
        {
            Console.SetCursorPosition(player.X,player.Y + i);
            Console.WriteLine(cards[i]);
        }
    }

    public static void DrawTable(CardsDeck deck, int pot)
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
                "||   |     "+pot.ToString("000000")+"       |",
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