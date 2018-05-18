using System;
using System.Collections.Generic;

public class Hand
{
    public int xHand;
    public int yHand;

    // A list of cards has been made in the hand class and the AddCard method
    // has been created to add cards to the hand
    protected List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    // Established position where stay the hand of player #1
    public void Position()
    {
        xHand = 0;
        yHand = 15;
    }
}
