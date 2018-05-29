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
            "procedures.";

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

    public void ShowExit()
    {
        Console.SetCursorPosition(119, 32);
        Console.WriteLine("Press Q to go back...");
    }

    public void Display()
    {
        string press = Console.ReadLine();
        do
        {
            ShowMenu();
            Console.SetCursorPosition(140 / 2, 35 / 2);
            Console.WriteLine(text);

            ShowExit();
            if (press == "")
            {
                for (int i = 0; i < listOfHands.Length; i++)
                {
                    Console.WriteLine(listOfHands[i]);
                }
            }
            
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
        Console.Clear();
        WelcomeScreen welcome = new WelcomeScreen();
        
        welcome.Display();
    }
}