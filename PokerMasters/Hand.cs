using System;
using System.Collections.Generic;

public class Hand
{
    // A list of cards has been made in the hand class and the AddCard method
    // has been created to add cards to the hand
    protected List<Card> cards = new List<Card>();
    public bool isPair = false;
    public bool isTwoPair = false;
    public bool isThreeKind = false;
    public bool isStraight = false;
    public bool isFlush = false;
    public bool isFullHouse = false;
    public bool isFourKind = false;
    public bool isStraightFlush = false;
    public bool isRoyalFlush = false;

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    // Established position where stay the hand of player #1
    public void HighCard()
    {
        
    }

    public void Pair()
    {

    }

    public void TwoPair()
    {

    }

    public void ThreeKind()
    {

    }

    public void Straight()
    {

    }

    public void Flush()
    {

    }

    public void FullHouse()
    {

    }

    public void FourKind()
    {

    }

    public void StraightFlush()
    {

    }

    public void RoyalFlush()
    {

    }
}
