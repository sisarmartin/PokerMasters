using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

public class GameScreen
{
    public struct Positions
    {
        public int X;
        public int Y;
    }

    public List<Player> Players { get; set; }
    private Hand Hand { get; set; }
    private int currentPlayer;
    private Card Card;
    private CardsDeck Deck { get; set; }
    private int round;
    public int pot;
    public int Index { get; set; }

    public GameScreen()
    {
        Players = new List<Player>();
        Index = 0;
    }

    // Created the structure to choose the movements
    public void Movements()
    {
        Console.SetCursorPosition(0,30);
        Console.WriteLine("1.FOLD / 2.CHECK / 3.CALL / 4.RAISE");
        Console.Write(Players[Index].UserName+", enter a option: ");
        string move = Console.ReadLine();
        bool exit = false;

        do
        {
            switch (move.ToLower())
            {
                case "1":
                    Players[Index].Fold();
                    Console.SetCursorPosition(0, 31);
                    Console.WriteLine(new string(' ', 100));
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine(new string(' ', 100));
                    break;
                case "2":
                    Players[Index].Check();
                    Console.SetCursorPosition(0, 31);
                    Console.WriteLine(new string(' ', 100));
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine(new string(' ', 100));
                    break;
                case "3":
                    Players[Index].Call();
                    Console.SetCursorPosition(0, 31);
                    Console.WriteLine(new string(' ', 100));
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine(new string(' ', 100));
                    break;
                case "4":
                    pot += Players[Index].Raise();
                    Console.SetCursorPosition(0, 31);
                    Console.WriteLine(new string(' ', 100));
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine(new string(' ', 100));
                    break;
                default:
                    Console.SetCursorPosition(0, 33);
                    Console.WriteLine(new string(' ', 100));
                    Console.SetCursorPosition(0, 0);
                    ShowMenu();
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine("Enter a correct option!");
                    move = Console.ReadLine();
                    break;
            }
        } while (exit);
    }
    
    public void Flop(CardsDeck deck)
    {
        // Burn
        deck.Burn(deck);

        Random r = new Random();

        int number = r.Next(0, deck.Count);
        Card card1 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        Console.SetCursorPosition(51, 15);
        Console.Write(card1.Rank);
        Console.SetCursorPosition(51, 16);
        Console.Write(card1.Suit);

        number = r.Next(0, deck.Count);
        Card card2 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        Console.SetCursorPosition(56, 15);
        Console.Write(card2.Rank);
        Console.SetCursorPosition(56, 16);
        Console.Write(card2.Suit);

        number = r.Next(0, deck.Count);
        Card card3 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        Console.SetCursorPosition(61, 15);
        Console.Write(card3.Rank);
        Console.SetCursorPosition(61, 16);
        Console.Write(card3.Suit);
    }

    public void Turn(CardsDeck deck)
    {
        // Burn
        deck.Burn(deck);

        Random r = new Random();

        int number = r.Next(0, deck.Count);
        Card card1 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        Console.SetCursorPosition(66, 15);
        Console.Write(card1.Rank);
        Console.SetCursorPosition(66, 16);
        Console.Write(card1.Suit);
    }

    public void River(CardsDeck deck)
    {
        // Burn
        deck.Burn(deck);

        Random r = new Random();

        int number = r.Next(0, deck.Count);
        Card card1 = deck.Cards[number];
        deck.Cards.RemoveAt(number);

        Console.SetCursorPosition(71, 15);
        Console.Write(card1.Rank);
        Console.SetCursorPosition(71, 16);
        Console.Write(card1.Suit);
    }

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine(" ---------- Play Local ----------");
        Console.WriteLine();
    }
    
    public void Run(string[] names)
    {
        Deck = new CardsDeck();

        ShowMenu();
        // Position for username #1 with name in game and chips
        Positions[] positions = new Positions[6];
        positions[0].X = 20;
        positions[0].Y = 8;
        positions[1].X = 60;
        positions[1].Y = 8;
        positions[2].X = 100;
        positions[2].Y = 8;
        positions[3].X = 20;
        positions[3].Y = 27;
        positions[4].X = 60;
        positions[4].Y = 27;
        positions[5].X = 100;
        positions[5].Y = 27;

        for (int i = 0; i < names.Length; i++)
        {
            Player player = new Player(names[i]);

            player.UserName = names[i];
            Players.Add(player);
        }

        DrawCard.Draw(Players, Deck);
        DrawCard.DrawTable(Deck, pot);
        
        GameLoop();
    }

    public void GameLoop()
    {
        do
        {
            for (int i = 0; i < Players.Count; i++)
            {
                //1 Check user input
                Movements();
                
                //2 Movements
                if (Index < Players.Count)
                {
                    Index++;
                    // Sound to inform about the turn of another player
                    Console.Beep(600, 1000);
                    //Update Pot
                    DrawCard.DrawTable(Deck, pot);
                }
                else
                {
                    Index = 0;
                }
                // 3 firsts cards of the middle
                if (Index == Players.Count)
                {
                    Flop(Deck);
                    Index = 0;
                    i = 0;
                }
            }

            for (int timesToShuffle = 0; timesToShuffle < 10; timesToShuffle++)
            {
                Deck.Shuffle();
            }

            // Update cards after the turn
            DrawCard.Draw(Players, Deck);
            DrawCard.DrawResult(Players);

        } while (true);
    }
}