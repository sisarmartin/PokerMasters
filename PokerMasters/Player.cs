using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public string UserName { get; set; }
    public int Bet { get; set; }
    public int Chips { get; set; }
    public Card[] cards;
    public int X { get; set; }
    public int Y { get; set; }
    public int Pot { get; set; }
    // Atributes to asign
    private bool isInPlay;
    private bool isAbsent;
    private bool bigBlind;
    private bool smallBlind;
    private bool dealer;
    
    public Player()
    {
        cards = new Card[2];
        Chips = 20000;
    }

    public Player(string userName)
    {
        UserName = userName;
        cards = new Card[2];
        Chips = 20000;
    }

    public int Raise()
    {
        Console.Write("Chips to raise: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        Chips = Chips - amount;
        Pot = amount;
        return amount;
    }

    public int Call()
    {
        Console.WriteLine("You called.");
        return Pot;
    }

    public void Check()
    {
        Console.WriteLine("You checked.");
    }

    public void Fold()
    {
        Console.WriteLine("You folded");
    }
}