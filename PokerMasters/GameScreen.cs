using System;
using System.Collections.Generic;

public class GameScreen
{
    WelcomeScreen Welcome = new WelcomeScreen();

    public struct Positions
    {
        public int X;
        public int Y;
    }

    public List<Player> Players { get; set; }
    private Hand Hand { get; set; }
    private Card Card;
    private CardsDeck Deck { get; set; }
    private int round = 0;
    public int pot;
    public int Index { get; set; }
    private bool allIsPlay = false;
    public Card[] Cards = new Card[5];

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
            switch (move.ToUpper())
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
                case "Q":
                    exit = true;
                        Console.Clear();
                        Welcome.Display();
                    break;
                default:
                    Console.SetCursorPosition(0, 31);
                    Console.WriteLine(new string(' ', 100));
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine(new string(' ', 100));
                    Movements();
                    break;
            }

        for (int i = 0; i < Players.Count - 1; i++)
            {
                if ((Index == Players.Count - 1) && (move != "1"))
                {
                    allIsPlay = true;
                }
            }
        } while (exit);
    }

    public void ShowExit()
    {
        Console.SetCursorPosition(119, 32);
        Console.WriteLine("Press Q to go back...");
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

        Cards[0] = card1;
        Cards[1] = card2;
        Cards[2] = card3;
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
        
        Cards[3] = card1;
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

        Cards[4] = card1;
    }

    // Check of cards to know who is the winner of each round
    public void CheckCards(List<Player> Players, CardsDeck deck)
    {
        List<Card> check = new List<Card>();
        for (int i = 0; i < Players.Count; i++)
        {
            check.Add(Players[i].cards[0]);
            check.Add(Players[i].cards[1]);
            check.Add(deck.Cards[0]);
            check.Add(deck.Cards[1]);
            check.Add(deck.Cards[2]);
            check.Add(deck.Cards[3]);
            check.Add(deck.Cards[4]);

            //Royal Flush #1
            /*if (check.Contains())
            {

            }*/
        }
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

        Console.Clear();
        DrawCard.Draw(Players, Deck);
        DrawCard.DrawTable(Deck);
        
        GameLoop();
    }

    public void GameLoop()
    {
        bool exit = false;
        do
        {
            do
            {
                ShowExit();
                for (int i = 0; i < Players.Count - 1; i++)
                {
                    //1 Check user input
                    Movements();

                    //2 Movements
                    if (Index < Players.Count - 1)
                    {
                        Index++;
                        // Sound to inform about the turn of another player
                        Console.Beep(600, 1000);
                        //Update Pot
                        DrawCard.DrawPot(pot);
                    }
                    else
                    {
                        Index = 0;
                    }
                    DrawCard.UpdateChips(Players);
                    // 3 firsts cards of the middle
                    if (allIsPlay)
                    {
                        Flop(Deck);
                        Movements();

                        if (Index < Players.Count - 1)
                        {
                            Index++;
                            Console.Beep(600, 1000);
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChips(Players);
                        }
                        else
                        {
                            Index = 0;
                        }
                    }
                    else
                    {
                        allIsPlay = false;
                    }

                    // 1 card of the middle
                    if (allIsPlay)
                    {
                        Turn(Deck);
                        Movements();

                        if (Index < Players.Count - 1)
                        {
                            Index++;
                            Console.Beep(600, 1000);
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChips(Players);
                        }
                        else
                        {
                            Index = 0;
                        }
                    }
                    else
                    {
                        allIsPlay = false;
                    }

                    // The last card of the middle
                    if (allIsPlay)
                    {
                        River(Deck);
                        Movements();

                        if (Index < Players.Count - 1)
                        {
                            Index++;
                            Console.Beep(600, 1000);
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChips(Players);
                        }
                        else
                        {
                            Index = 0;
                        }
                    }
                    else
                    {
                        allIsPlay = false;
                    }
                }
            } while (!allIsPlay);

            for (int timesToShuffle = 0; timesToShuffle < 10; timesToShuffle++)
            {
                Deck.Shuffle();
            }

            // Update cards after the turn
            DrawCard.Draw(Players, Deck);
            DrawCard.DrawResult(Players);
            round++;

        } while (!exit);
    }
}