using System;
using System.Collections.Generic;

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
    public void Movements(int amount)
    {
        Console.SetCursorPosition(0,32);
        Console.Write("Movement: ");
        string move = Console.ReadLine();
        bool exit = false;

        do
        {
            switch (move.ToLower())
            {
                case "fold":
                    //Console.Clear();
                    Players[Index].Fold();
                    //Console.Clear();
                    break;
                case "check":
                    Console.Clear();
                    Players[Index].Check();
                    Console.Clear();
                    break;
                case "call":
                    Console.Clear();
                    Players[Index].Call();
                    Console.Clear();
                    break;
                case "raise":
                    //Console.Clear();
                    Players[Index].Raise();
                    Console.Clear();
                    DrawCard.DrawTable(Deck, pot);
                    DrawCard.Draw(Players, Deck);
                    break;
                default:
                    Console.Clear();
                    ShowMenu();
                    Console.WriteLine();
                    Console.WriteLine("Enter a correct option!");
                    move = Console.ReadLine();
                    break;
            }
        } while (!exit);
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
        Console.WriteLine("-------- Play Local --------");
        Console.WriteLine();
    }

    public void Run(string[] names)
    {
        Deck = new CardsDeck();

        ShowMenu();
        // Position for username #1 with name in game and chips
        /*Hand hand = new Hand();
        hand.Position();*/
        Positions[] positions = new Positions[6];
        positions[0].X = 10;
        positions[0].Y = 10;
        positions[1].X = 55;
        positions[1].Y = 10;
        positions[2].X = 95;
        positions[2].Y = 10;
        positions[3].X = 10;
        positions[3].Y = 35;
        positions[4].X = 55;
        positions[4].Y = 35;
        positions[5].X = 95;
        positions[5].Y = 35;

        for (int i = 0; i < names.Length; i++)
        {
            Player player = new Player(names[i]);
            //player.X = 0;
            //player.Y = 15;

            player.UserName = names[i];
            Players.Add(player);
        }

        for (int i = 0; i < Players.Count; i++)
        {
            //Players[i].X
            Console.SetCursorPosition(positions[i].X, positions[i].Y );
            Console.WriteLine("Name: " + Players[i].UserName);
            Console.SetCursorPosition(positions[i].X, positions[i].Y );
            Console.WriteLine("Chips: " + Players[i].Chips);
            DrawCard.Draw(Players, Deck);
        }

        DrawCard.DrawTable(Deck, pot);

        GameLoop();
    }

    public void GameLoop()
    {
        do
        {
            //1 Check user input
            Movements(50);

            //2 Movements
            if (Index < Players.Count)
            {
                Index++;
            }
            else
            {
                Index = 0;
            }

            //3 Check collision

            //4 Draw
            DrawCard.DrawTable(Deck, pot);

        } while (true);
    }
}