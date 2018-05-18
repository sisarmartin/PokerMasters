using System;

public class GameScreen
{
    public Player player { get; set; }
    private Hand Hand { get; set; }
    private int currentPlayer;
    private Card Card;
    private CardsDeck Deck { get; set; }
    private int round;
    private int pot;

    public GameScreen(Player player)
    {
        this.player = player;
    }

    // Created the structure to choose the movements
    public void Movements()
    {
        Console.SetCursorPosition(0,20);
        Console.Write("Movements: ");
        string move = Console.ReadLine();
        bool exit = false;

        do
        {
            switch (move.ToLower())
            {
                case "fold":
                    //Console.Clear();
                    player.Fold();
                    //Console.Clear();
                    break;
                case "check":
                    Console.Clear();
                    player.Check();
                    Console.Clear();
                    break;
                case "call":
                    Console.Clear();
                    player.Call();
                    Console.Clear();
                    break;
                case "bet":
                    Console.Clear();
                    player.Bet+=50;
                    Console.Clear();
                    break;
                case "raise":
                    Console.Clear();
                    player.Raise(50);
                    Console.Clear();
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

    public void Run(string name)
    {
        Deck = new CardsDeck();

        ShowMenu();
        // Position for username #1 with name in game and chips
        Hand hand = new Hand();
        hand.Position();

        
        Player player1 = new Player(name);
        player1.X = 0;
        player1.Y = 15;
        player1.UserName = name;

        Console.SetCursorPosition(player1.X, player1.Y-2);
        Console.WriteLine("Name: "+player1.UserName);
        Console.SetCursorPosition(player1.X, player1.Y - 1);
        Console.WriteLine("Chips: "+player1.Chips);
        DrawCard.Draw(player1,Deck);

        DrawCard.DrawTable(Deck);


        GameLoop();

        // To do
    }

    public void GameLoop()
    {
        do
        {
            //1-Check user input
            Movements();

            //2-Check collision

            //3-Draw
            DrawCard.DrawTable(Deck);

        } while (true);
    }
}