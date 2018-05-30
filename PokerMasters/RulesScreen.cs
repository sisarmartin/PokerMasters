using System;

class RulesScreen
{
    private string text = "Poker is a family of card games that combines " +
        "gambling, strategy, and skill. All poker variants involve betting " +
        "as an intrinsic part of play, and determine the winner of each hand" +
        "according to the combinations of players' cards, at least some of " +
        "which remain hidden until the end of the hand. Poker games vary in " +
        "the number of cards dealt, the number of shared or \"community\" " +
        "cards, the number of cards that remain hidden, and the betting " +
        "procedures." +
        "In most modern poker games, the first round of betting begins with " +
        "one or more of the players making some form of a forced bet " +
        "(the blind or ante). In standard poker, each player bets according " +
        "to the rank they believe their hand is worth as compared to the " +
        "other players. The action then proceeds clockwise as each player " +
        "in turn must either match (or \"call\") the maximum previous bet, " +
        "or fold, losing the amount bet so far and all further involvement " + 
        "in the hand. A player who matches a bet may also \"raise\" " + 
        "(increase) the bet. The betting round ends when all players have " + 
        "either called the last bet or folded. If all but one player folds " + 
        "on any round, the remaining player collects the pot without being " + 
        "required to reveal their hand. If more than one player remains in " + 
        "contention after the final betting round, a showdown takes place " +
        "where the hands are revealed, and the player with the winning " + 
        "hand takes the pot.";

    private string[] listOfHands = {
        "Royal Flush",
        "Straight Flush",
        "Four of a kind",
        "Full House",
        "Flush",
        "Straight",
        "Three of a kind",
        "Two pair",
        "One pair",
        "High card",
    };

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  ---------- Rules ----------");
        Console.WriteLine();
    }

    public void ShowNext()
    {
        Console.SetCursorPosition(114, 32);
        Console.WriteLine("Press Enter to continue...");
    }

    public void ShowExit()
    {
        Console.SetCursorPosition(119, 32);
        Console.WriteLine("Press Q to go back...");
    }

    public void Display()
    {
        ShowMenu();
        Console.SetCursorPosition(70 / 2, 17 / 2);
        Console.WriteLine(text);
        ShowNext();
        string press = Console.ReadLine();
        do
        {
            ShowExit();
            if (press == "")
            {
                Console.Clear();
                for (int i = 0; i < listOfHands.Length; i++)
                {    
                    Console.WriteLine(listOfHands[i]);
                }
                ShowExit();
            }
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
        Console.Clear();
        WelcomeScreen welcome = new WelcomeScreen();
        welcome.Display();
    }
}