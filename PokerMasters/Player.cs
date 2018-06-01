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
    public bool bigBlind;
    public bool smallBlind;
    public byte HandValue;
    public bool dealer;
    
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

    public void ClearText()
    {
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 32);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 33);
        Console.WriteLine(new string(' ', 100));
    }

    public int Raise()
    {
        int amount;
        string nAmount;
        bool correct = false;
        do
        {
            Console.Write("Chips to raise: ");
            nAmount = Console.ReadLine();
            // Introduced the tryparse so that it does not crash when
            //it is converted from string to int
            correct = int.TryParse(nAmount, out amount);
            if (correct)
            {
                amount = Convert.ToInt32(nAmount);
                Chips = Chips - amount;
                Pot = amount;
            }
            else
            {
                correct = false;
            }
        } while ((!(amount <= Chips)) || (!correct));
        ClearText();
        return amount;
    }

    public int RaiseEsp()
    {
        int amount;
        string nAmount;
        bool correct = false;
        do
        {
            Console.Write("Chips to raise: ");
            nAmount = Console.ReadLine();
            correct = int.TryParse(nAmount, out amount);
            if (correct)
            {
                amount = Convert.ToInt32(nAmount);
                Chips = Chips - amount;
                Pot = amount;
            }
            else
            {
                correct = false;
            }
        } while ((!(amount <= Chips)) || (!correct));
        ClearText();
        return amount;
    }

    public int Call()
    {
        Console.WriteLine("You called.");
        ClearText();
        return Pot;
    }

    public void Check()
    {
        Console.WriteLine("You checked.");
        ClearText();
    }

    public void Fold()
    {
        Console.WriteLine("You folded.");
        ClearText();
    }

    public bool Absent()
    {
        Console.WriteLine("You are absent.");
        ClearText();
        return true;
    }
}