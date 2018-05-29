using System;

public class Card
{
    public Suit Suit { get; set; }
    public char Rank { get; set; }

    public Card(Suit suit, char rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public void Flip()
    {
        // To do
    }
}