using System;

public class WelcomeScreen
{
    Player Player;

    static void Title()
    {
        Console.WriteLine(" =====  =====  =   =  =====  ===== ");
        Console.WriteLine(" =   =  =   =  = =    =      =   = ");
        Console.WriteLine(" =====  =   =  =      =====  ====  ");
        Console.WriteLine(" =      =   =  = =    =      =  =  ");
        Console.WriteLine(" =      =====  =   =  =====  =   = ");
        Console.WriteLine();
    }

    // Show menu with the differents options
    static void ShowMenu()
    {
        Console.WriteLine("-------- Choose one: --------");
        Console.WriteLine("1.- Play in local");
        Console.WriteLine("2.- Play in network");
        Console.WriteLine("3.- Game rules");
        Console.WriteLine("4.- Credits");
        Console.WriteLine("5.- High Scores");
        Console.WriteLine("Q.- Exit");
        Console.WriteLine();
    }
    
    // We asked the user his name of the game
    public string[] UserName()
    {
        int nPlayers;
        do
        {
            Console.Write("Enter a number of players 1-6: ");
            nPlayers = Convert.ToInt32(Console.ReadLine());

        } while (!(nPlayers >= 1 && nPlayers <= 6));
        
        string[] name = new string[nPlayers];
        for (int i = 0; i < nPlayers; i++)
        {
            do
            {
                Console.WriteLine("Enter your user name #" + (i + 1) + ": ");
                name[i] = Console.ReadLine();
            } while (name[i] == "");
            Console.Clear();
            Console.WriteLine("Welcome to PokerMasters {0}!", name[i]);
        }
        return name;
    }

    // The user enter the name player with will be play
    public void Display()
    {
        GameScreen Game;
        CreditsScreen Credits;
        HiScoreScreen HiScore;
        RulesScreen Rules;
        ConsoleUpgrade console = new ConsoleUpgrade();

        console.CreateConfig();

        string[] name = UserName();
        ShowMenu();

        string option = Console.ReadLine();
        bool exit = false;
        
        do
        {
            switch (option.ToUpper())
            {
                case "1":
                    Console.Clear();
                    Game = new GameScreen();
                    Game.Run(name);
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Game = new GameScreen();
                    Game.Run(name);
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Rules = new RulesScreen();
                    Rules.Display();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Credits = new CreditsScreen();
                    Credits.Run();
                    Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    HiScore = new HiScoreScreen();
                    HiScore.Run();
                    Console.Clear();
                    break;
                case "Q":
                    exit = true;
                    Console.WriteLine("See you soon!");
                    Console.WriteLine();
                    break;
                default:
                    Console.Clear();
                    ShowMenu();
                    Console.WriteLine();
                    Console.WriteLine("Enter a correct option!");
                    option = Console.ReadLine();
                    break;
            }
        } while (!exit);
    }

    // Main loop of the welcome screen
    public static void Main()
    {
	// Established Windows Size
        Console.SetWindowSize(140, 35);
        WelcomeScreen Welcome = new WelcomeScreen();
        Title();
        Welcome.Display();
    }
}