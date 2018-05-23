using System;
using System.Collections.Generic;

public class CardsDeck
{
    public List<Card> Cards { get; set; }
    public int Count { get { return Cards.Count; } }
    // Generate List to save the cards
    public CardsDeck()
    {
        Cards = new List<Card>();
        Create();
    }

    // Generate the create method to set each card in the deck 
    // and assign each of the suits and numbers.
    public void Create()
    {
        Suit[] Suits = new Suit[4];
        Suits[0] = Suit.C;
        Suits[1] = Suit.D;
        Suits[2] = Suit.H;
        Suits[3] = Suit.S;

        // Assign each letter a suit and a rank
        for (int suitIndex = 0; suitIndex < 4; suitIndex++)
        {
            for (int rankIndex = 1; rankIndex <= 13; rankIndex++)
            {
                switch (rankIndex)
                {
                    case 10:
                        Cards.Add(new Card(Suits[suitIndex], 'X'));
                        break;
                    case 11:
                        Cards.Add(new Card(Suits[suitIndex], 'J'));
                        break;
                    case 12:
                        Cards.Add(new Card(Suits[suitIndex], 'Q'));
                        break;
                    case 13:
                        Cards.Add(new Card(Suits[suitIndex], 'K'));
                        break;
                    default:
                        Cards.Add(new Card(Suits[suitIndex],
                            Convert.ToChar(rankIndex.ToString())));
                        break;
                }
            }
        }
    }

    public void Deal()
    {
        // To do
    }

    // Reset list of cards (deck of cards)
    public void Shuffle()
    {
        Random r = new Random();

        for (int i = Cards.Count - 1; i > 0; i--)
        {
            int n = r.Next(i + 1);
            Card temp = Cards[i];
            Cards[i] = Cards[n];
            Cards[n] = temp;
        }
    }

    public void Reset()
    {
        // To do
    }

    public void TopCard()
    {
        // To do
    }

    public void Burn(CardsDeck deck)
    {
        Random r = new Random();

        int number = r.Next(0, deck.Count);
        deck.Cards.RemoveAt(number);
    }
}