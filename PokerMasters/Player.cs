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

    public int Raise()
    {
        Console.Write("Chips to raise: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        Chips = Chips - amount;
        Pot = amount;
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 32);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 33);
        Console.WriteLine(new string(' ', 100));
        return amount;
    }

    public int RaiseEsp()
    {
        Console.Write("Fichas a subir: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        Chips = Chips - amount;
        Pot = amount;
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 32);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 33);
        Console.WriteLine(new string(' ', 100));
        return amount;
    }

    public int Call()
    {
        Console.WriteLine("You called.");
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 32);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 33);
        Console.WriteLine(new string(' ', 100));
        return Pot;
    }

    public void Check()
    {
        Console.WriteLine("You checked.");
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 32);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 33);
        Console.WriteLine(new string(' ', 100));
    }

    public void Fold()
    {
        Console.WriteLine("You folded.");
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 32);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 33);
        Console.WriteLine(new string(' ', 100));
    }

    public bool Absent()
    {
        Console.WriteLine("You are absent.");
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 32);
        Console.WriteLine(new string(' ', 100));
        Console.SetCursorPosition(0, 33);
        Console.WriteLine(new string(' ', 100));
        return true;
    }
}