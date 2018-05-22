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
        Console.WriteLine("FOLD / CHECK / CALL / RAISE");
        Console.Write(Players[Index].UserName+", enter a option: ");
        string move = Console.ReadLine();
        bool exit = false;

        do
        {
            switch (move.ToLower())
            {
                case "fold":
                    Players[Index].Fold();
                    break;
                case "check":
                    Players[Index].Check();
                    break;
                case "call":
                    Players[Index].Call();
                    break;
                case "raise":
                    pot += Players[Index].Raise();
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
    
    public void Flop()
    {
        // To do
    }

    public void Turn()
    {
        // To do
    }

    public void River()
    {
        // To do
    }

    public void ShowMenu()
    {
        Console.SetCursorPosition(55, 0);
        Console.WriteLine("-------- Play Local --------");
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
                    DrawCard.Draw(Players, Deck);
                }
                else
                {
                    Index = 0;
                }
            }
            // Update cards after the turn
            //DrawCard.Draw(Players, Deck);

        } while (true);
    }
}