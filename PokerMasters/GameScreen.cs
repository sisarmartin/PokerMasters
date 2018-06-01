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

            //1 Royal flush
            /*if (royalFlush())
                Players[i].HandValue = 1;
            //2 Straight flush
            else if (straightFlush())
                Players[i].HandValue = 2
            //3 Four of a kind
            else */if (fourOfAKind(check))
                Players[i].HandValue = 3;
            //4 Full House
            else if (fullHouse(check))
                Players[i].HandValue = 4;
            //5 Flush
            else if (flush(check))
                Players[i].HandValue = 5;
            //6 Straight
           /* else if (straight(check))
                Players[i].HandValue = 6;*/
            //7 Three of a kind
            else if (threeOfAKind(check))
                Players[i].HandValue = 7;
            //8 Two pair
            else if (twoPair(check))
                Players[i].HandValue = 8;
            //9 One pair
            else if (onePair(check))
                Players[i].HandValue = 9;
            //10 High card
            else
                Players[i].HandValue = 10;

            if (Players[0].HandValue < Players[1].HandValue)
            {
                Players[0].Chips += pot;
                Console.SetCursorPosition(110, 13);
                Console.WriteLine(Players[0].UserName + " wins!");
            }
            else if (Players[1].HandValue < Players[0].HandValue)
            {
                Players[1].Chips += pot;
                Console.SetCursorPosition(110, 13);
                Console.WriteLine(Players[1].UserName + " wins!");
            }
            else
            {
                int newPot = pot / 2;
                Players[0].Chips = pot;
                Players[1].Chips = newPot;
                Console.SetCursorPosition(110, 13);
                Console.WriteLine("Deuce!");
            }
        }
    }

    public void CheckCardsEsp(List<Player> Players, CardsDeck deck)
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

            //1 Royal flush
            /*if (royalFlush())
                Players[i].HandValue = 1;
            //2 Straight flush
            else if (straightFlush())
                Players[i].HandValue = 2
            //3 Four of a kind
            else */
            if (fourOfAKind(check))
                Players[i].HandValue = 3;
            //4 Full House
            else if (fullHouse(check))
                Players[i].HandValue = 4;
            //5 Flush
            else if (flush(check))
                Players[i].HandValue = 5;
            //6 Straight
            /* else if (straight(check))
                 Players[i].HandValue = 6;*/
            //7 Three of a kind
            else if (threeOfAKind(check))
                Players[i].HandValue = 7;
            //8 Two pair
            else if (twoPair(check))
                Players[i].HandValue = 8;
            //9 One pair
            else if (onePair(check))
                Players[i].HandValue = 9;
            //10 High card
            else
                Players[i].HandValue = 10;

            if (Players[0].HandValue < Players[1].HandValue)
            {
                Players[0].Chips += pot;
                Console.SetCursorPosition(110, 13);
                Console.WriteLine(Players[0].UserName + " gana!");
            }
            else if (Players[1].HandValue < Players[0].HandValue)
            {
                Players[1].Chips += pot;
                Console.SetCursorPosition(110, 13);
                Console.WriteLine(Players[1].UserName + " gana!");
            }
            else
            {
                int newPot = pot / 2;
                Players[0].Chips = pot;
                Players[1].Chips = newPot;
                Console.SetCursorPosition(110, 13);
                Console.WriteLine("Empate!");
            }
        }
    }

    //fourOfAKind
    private static bool fourOfAKind(List<Card> check)
    {
        for (int i = 0; i < 4; i++)
        {
            int cont = 0;

            for (int j = 0; j < check.Count; j++)
            {
                if (check[i].Rank == check[j].Rank)
                    cont++;
                if (cont == 4)
                    return true;
            }
        }
        return false;
    }

    //fullHouse
    private static bool fullHouse(List<Card> check)
    {
        for (int i = 0; i < 4; i++)
        {
            int cont = 0;

            for (int j = 0; j < check.Count; j++)
            {
                if (check[i].Rank == check[j].Rank)
                    cont++;
                if (cont == 3)
                    return true;
            }
        }
        return false;
    }

    //flush
    private static bool flush(List<Card> check)
    {
        for (int i = 0; i < 4; i++)
        {
            int cont = 0;

            for (int j = 0; j < check.Count; j++)
            {
                if (check[i].Suit == check[j].Suit)
                    cont++;
                if (cont == 5)
                    return true;
            }
        }
        return false;
    }

    //threeOfAKind
    private static bool threeOfAKind(List<Card> check)
    {
        for (int i = 0; i < 4; i++)
        {
            int cont = 0;

            for (int j = 0; j < check.Count; j++)
            {
                if (check[i].Rank == check[j].Rank)
                    cont++;
                if (cont == 3)
                    return true;
            }
        }
        return false;
    }

    //twoPair
    private static bool twoPair(List<Card> check)
    {
        for (int i = 0; i < 4; i++)
        {
            int cont = 0;

            for (int j = 0; j < check.Count; j++)
            {
                if (check[i].Rank == check[j].Rank)
                    cont++;
                if (cont == 2)
                    return true;
            }
        }
        return false;
    }

    //onePair
    private static bool onePair(List<Card> check)
    {
        for (int i = 0; i < 4; i++)
        {
            int cont = 0;

            for (int j = 0; j < check.Count; j++)
            {
                if (check[i].Rank == check[j].Rank)
                    cont++;
                if (cont == 1)
                    return true;
            }
        }
        return false;
    }

    public void ShowMovements()
    {
        Console.SetCursorPosition(0, 30);
        Console.WriteLine("1.FOLD / 2.CHECK / 3.CALL / 4.RAISE");
        Console.WriteLine("Press Z for Absent mode");
        Console.Write(Players[Index].UserName + ", enter a option: ");
    }

    public void ShowMovementsEsp()
    {
        Console.SetCursorPosition(0, 30);
        Console.WriteLine("1.RETIRARSE / 2.PASAR / 3.IGUALAR / 4.SUBIR");
        Console.WriteLine("Pulsa Z para el modo Ausente");
        Console.Write(Players[Index].UserName + ", introduce una opcion: ");
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

    // Created the structure to choose the movements
    public void Movements()
    {
        string move;
        
        ShowMovements();

        move = Console.ReadLine();
        switch (move.ToUpper())
        {
            case "1":
                Players[Index].Fold();
                break;
            case "2":
                Players[Index].Check();
                break;
            case "3":
                Players[Index].Call();
                Players[Index].Chips -= Players[Index - 1].Pot;
                pot += Players[Index - 1].Pot;
                break;
            case "4":
                pot += Players[Index].Raise();
                break;
            case "Z":
                isAbsent = Players[Index].Absent();
                break;
            case "Q":
                Console.Clear();
                Welcome.Display();
                break;
            default:
                ClearText();
                Movements();
                break;
        }
        
        for (int i = 0; i < Players.Count - 1; i++)
        {
            if (move != "1")
            {
                allIsPlay = true;
            }
        }
    }

    public void MovementsEsp()
    {
        string move;
        
        ShowMovementsEsp();

        move = Console.ReadLine();
        switch (move.ToUpper())
        {
            case "1":
                Players[Index].Fold();
                break;
            case "2":
                Players[Index].Check();
                break;
            case "3":
                Players[Index].Call();
                Players[Index].Chips -= Players[Index - 1].Pot;
                pot += Players[Index - 1].Pot;
                break;
            case "4":
                pot += Players[Index].RaiseEsp();
                break;
            case "Z":
                isAbsent = Players[Index].Absent();
                break;
            case "Q":
                Console.Clear();
                Welcome.DisplayEsp();
                break;
            default:
                ClearText();
                MovementsEsp();
                break;
        }

        for (int i = 0; i < Players.Count - 1; i++)
        {
            if (move != "1")
            {
                allIsPlay = true;
            }
        }
    }

    public void ShowExit()
    {
        Console.SetCursorPosition(119, 32);
        Console.WriteLine("Press Q to go back...");
    }

    public void ShowExitEsp()
    {
        Console.SetCursorPosition(119, 32);
        Console.WriteLine("Pulsa Q para volver...");
    }

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine(" ---------- Play Local ----------");
        Console.WriteLine();
    }

    public void ShowMenuEsp()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("------------ PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine(" ---------- Jugar en local ----------");
        Console.WriteLine();
    }

    public void Run(string[] names)
    {
        Deck = new CardsDeck();

        Console.Clear();
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
        DrawCard.Draw(Players, Deck);
        DrawCard.UpdateChips(Players);
        DrawCard.DrawTable(Deck);

        // Create logs of players
        CreateConfig(Players);

        // Loop of game
        GameLoop();
    }

    public void RunEsp(string[] names)
    {
        Deck = new CardsDeck();

        Console.Clear();
        ShowMenuEsp();
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
        DrawCard.DrawEsp(Players, Deck);
        DrawCard.UpdateChipsEsp(Players);
        DrawCard.DrawTableEsp(Deck);

        // Create logs of players
        CreateConfigEsp(Players);

        // Loop of game
        GameLoopEsp();
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
                        Players[i].Chips -= big;
                        pot += big;
                    }

                    if (Players[i].smallBlind)
                    {
                        int small = 100;
                        Players[i].Chips -= small;
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

            } while (!allIsPlay);

            for (int timesToShuffle = 0; timesToShuffle < 10; timesToShuffle++)
            {
                Deck.Shuffle();
            }

            // Update cards after the turn
            CheckCards(Players, Deck);
            DrawCard.UpdateChips(Players);
            DrawCard.DrawTable(Deck);
            DrawCard.Draw(Players, Deck);
            //DrawCard.DrawResult(Players);
            pot = 0;
            Index = 0;
            Deck.Reset();
            round++;
        } while (!exit);
    }

    public void GameLoopEsp()
    {
        bool exit = false;
        int nIsAbsent;
        do
        {
            do
            {
                ShowExitEsp();
                for (int i = 0; i < Players.Count - 1; i++)
                {
                    //1 Check user input
                    MovementsEsp();

                    // Payment of blinds
                    if (Players[i].bigBlind)
                    {
                        int big = 200;
                        Players[i].Chips -= big;
                        pot += big;
                    }

                    if (Players[i].smallBlind)
                    {
                        int small = 100;
                        Players[i].Chips -= small;
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
                            DrawCard.UpdateChipsEsp(Players);
                        }
                        else
                        {
                            Index = 0;
                            Console.Beep(600, 1000);
                            //Update Pot
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChipsEsp(Players);
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
                    DrawCard.UpdateChipsEsp(Players);
                }

                // 3 firsts cards of the middle
                if (allIsPlay)
                {
                    Flop(Deck);
                    allIsPlay = false;
                    for (int i = 0; i < Players.Count; i++)
                    {
                        MovementsEsp();

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
                                DrawCard.UpdateChipsEsp(Players);
                            }
                            else
                            {
                                Index = 0;
                                Console.Beep(600, 1000);
                                //Update Pot
                                DrawCard.DrawPot(pot);
                                DrawCard.UpdateChipsEsp(Players);
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
                        MovementsEsp();

                        if (Index < Players.Count - 1)
                        {
                            Index++;
                            Console.Beep(600, 1000);
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChipsEsp(Players);
                        }
                        else
                        {
                            Index = 0;
                            Console.Beep(600, 1000);
                            //Update Pot
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChipsEsp(Players);
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
                        MovementsEsp();

                        if (Index < Players.Count - 1)
                        {
                            Index++;
                            Console.Beep(600, 1000);
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChipsEsp(Players);
                        }
                        else
                        {
                            Index = 0;
                            Console.Beep(600, 1000);
                            //Update Pot
                            DrawCard.DrawPot(pot);
                            DrawCard.UpdateChipsEsp(Players);
                        }
                    }
                }
                else
                {
                    allIsPlay = false;
                }
            } while (!allIsPlay);

            for (int timesToShuffle = 0; timesToShuffle < 10; timesToShuffle++)
            {
                Deck.Shuffle();
            }

            // Update cards after the turn
            CheckCardsEsp(Players, Deck);
            DrawCard.UpdateChipsEsp(Players);
            DrawCard.DrawTableEsp(Deck);
            DrawCard.DrawEsp(Players, Deck);
            //DrawCard.DrawResult(Players);
            pot = 0;
            Index = 0;
            Deck.Reset();
            round++;
        } while (!exit);
    }
}