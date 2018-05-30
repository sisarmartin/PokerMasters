using System;
using System.Collections.Generic;

public class GameScreen : ConsoleUpgrade
{
    WelcomeScreen Welcome = new WelcomeScreen();

    public Player Player { get; set; }
    private Hand Hand { get; set; }
    private CardsDeck Deck { get; set; }
    private int round = 0;
    public int pot;
    public int Index { get; set; }
    public Card[] Cards = new Card[5];
    public bool isAbsent;
    public bool allIsPlay;
    public bool isFold;
    public bool winner;

    public GameScreen()
    {
        Players = new List<Player>();
        Index = 0;
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
        }

        // Looking four and three of a kind, two and one pair.
        if (Players.Count == 2)
        {
            int playerOneTimes = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 2; j < 7; j++)
                {
                    if (check[i].Rank == check[j].Rank)
                        playerOneTimes++;
                }
            }

            int playerTwoTimes = 0;

            for (int i = 7; i < 9; i++)
            {
                for (int j = 9; j < 14; j++)
                {
                    if (check[i].Rank == check[j].Rank)
                        playerTwoTimes++;
                }
            }

            if (playerOneTimes > playerTwoTimes)
            {
                if (playerOneTimes == 4)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[0].UserName + "Four of a kind");
                }
                else if (playerOneTimes == 3)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[0].UserName + "Three of a kind");
                }
                else if (playerOneTimes == 2)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[0].UserName + "Two pair");
                }
                else if (playerOneTimes == 1)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[0].UserName + "One pair");
                }
                else if ((check[0].Rank == check[1].Rank))
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[0].UserName + "One pair");
                }
                else
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[0].UserName + "No one");
                }
            }

            if (playerOneTimes < playerTwoTimes)
            {
                if (playerOneTimes == 4)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[1].UserName + "Four of a kind");
                }
                else if (playerOneTimes == 3)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[1].UserName + "Three of a kind");
                }
                else if (playerOneTimes == 2)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[1].UserName + "Two pair");
                }
                else if (playerOneTimes == 1)
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[1].UserName + "One pair");
                }
                else if ((check[0].Rank == check[1].Rank))
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[1].UserName + "One pair");
                }
                else
                {
                    Console.SetCursorPosition(110, 13);
                    Console.WriteLine(Players[1].UserName + "No one");
                }
            }

            if (playerOneTimes == playerTwoTimes)
                Console.WriteLine("Deuce");
        }
    }

    // Created the structure to choose the movements
    public void Movements()
    {
        Console.SetCursorPosition(0,30);
        Console.WriteLine("1.FOLD / 2.CHECK / 3.CALL / 4.RAISE");
        Console.WriteLine("Press Z for Absent mode");
        Console.Write(Players[Index].UserName+", enter a option: ");

        string move;
        bool exit = false;

        do
        {
            move = Console.ReadLine();
            switch (move.ToUpper())
            {
                case "1":
                    Players[Index].Fold();
                    isFold = true;
                    break;
                case "2":
                    Players[Index].Check();
                    break;
                case "3":
                    Players[Index].Call();
                    pot += Players[Index - 1].Pot;
                    break;
                case "4":
                    pot += Players[Index].Raise();
                    break;
                case "Z":
                    isAbsent = Players[Index].Absent();
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
                    Console.SetCursorPosition(0, 33);
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

        // Draw Game table and cards
        Console.Clear();
        DrawCard.Draw(Players, Deck);
        DrawCard.DrawTable(Deck);

        // Create logs of players
        CreateConfig(Players);

        // Loop of game
        GameLoop();
    }

    public void GameLoop()
    {
        bool exit = false;
        int nIsAbsent;
        do
        {
            do
            {
                ShowExit();
                for (int i = 0; i < Players.Count - 1; i++)
                {
                    //1 Check user input
                    Movements();

                    // Payment of blinds
                    if (Players[i].bigBlind)
                    {
                        int big = 200;
                        Players[i].Chips = Players[i].Chips - big;
                        pot = big;
                        pot += big;
                    }

                    if (Players[i].smallBlind)
                    {
                        int small = 100;
                        Players[i].Chips = Players[i].Chips - small;
                        pot = small;
                        pot += small;
                    }

                    if (!isAbsent)
                    {
                        //2 Movements
                        if (Index < Players.Count - 1)
                        {
                            Index++;
                            // Sound to inform about the turn of another player
                            Console.Beep(600, 1000);
                            //Update Pot
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChips(Players);
                        }
                        else
                        {
                            Index = 0;
                            Console.Beep(600, 1000);
                            //Update Pot
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChips(Players);
                        }
                    }
                    else
                    {
                        nIsAbsent = Index;
                        if (Index < Players.Count - 1)
                            Index++;
                        else
                            Index = 0;
                    }

                    DrawCard.UpdateChips(Players);
                }

                // 3 firsts cards of the middle
                
                    if (allIsPlay)
                    {
                        Flop(Deck);
                        allIsPlay = false;
                        for (int i = 0; i < Players.Count; i++)
                        {
                            Movements();

                            if (!isAbsent)
                            {
                                //2 Movements
                                if (Index < Players.Count - 1)
                                {
                                    Index++;
                                    // Sound to inform about the turn of another player
                                    Console.Beep(600, 1000);
                                    //Update Pot
                                    DrawCard.DrawPot(pot);
                                    DrawCard.UpdateChips(Players);
                                }
                                else
                                {
                                    Index = 0;
                                    Console.Beep(600, 1000);
                                    //Update Pot
                                    DrawCard.DrawPot(pot);
                                    DrawCard.UpdateChips(Players);
                                }
                            }
                            else
                            {
                                nIsAbsent = Index;
                                if (Index < Players.Count - 1)
                                    Index++;
                                else
                                    Index = 0;
                            }
                        }
                    }
                    else
                    {
                        allIsPlay = false;
                    }

            
                    if (allIsPlay)
                    {
                        Turn(Deck);
                        for (int i = 0; i < Players.Count; i++)
                        {
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
                                Console.Beep(600, 1000);
                                //Update Pot
                                DrawCard.DrawPot(pot);
                                DrawCard.UpdateChips(Players);
                            }
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
                        for (int i = 0; i < Players.Count; i++)
                        {
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
                                Console.Beep(600, 1000);
                                //Update Pot
                                DrawCard.DrawPot(pot);
                                DrawCard.UpdateChips(Players);
                            }
                        }
                    }
                    else
                    {
                        allIsPlay = false;
                    }
                if (Players.Count != 2)
                {
                    isFold = false;
                }

            } while ((!isFold) && (!allIsPlay));

            for (int timesToShuffle = 0; timesToShuffle < 10; timesToShuffle++)
            {
                Deck.Shuffle();
            }

            // Update cards after the turn
            DrawCard.Draw(Players, Deck);
            //DrawCard.DrawResult(Players);
            CheckCards(Players, Deck);
            Players[0].Chips = Players[0].Chips + pot;
            pot = 0;
            Index = 0;
            DrawCard.DrawTable(Deck);
            Deck.Reset();
            round++;

        } while (!exit);
    }
}