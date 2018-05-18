﻿using System;

public class Player
{
    public string UserName { get; set; }
    public int Bet { get; set; }
    public int Chips { get; set; }
    public Card[] cards;
    public int X { get; set; }
    public int Y { get; set; }
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

    public void Raise(int amount)
    {
        // To do
    }

    public void Check()
    {
        // To do
    }

    public void Call()
    {
        // To do
    }

    public void Fold()
    {
        // To do
    }
}