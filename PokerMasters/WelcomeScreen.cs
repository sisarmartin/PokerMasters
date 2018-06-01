using System;
using System.Collections.Generic;

public class WelcomeScreen
{
    private List<Player> Players { get; set; }

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
        Console.WriteLine("6.- Change Language");
        Console.WriteLine("Q.- Exit");
        Console.WriteLine();
    }

    static void ShowMenuEsp()
    {
        Console.WriteLine("-------- Elige una: --------");
        Console.WriteLine("1.- Jugar en local");
        Console.WriteLine("2.- Jugar en red");
        Console.WriteLine("3.- Reglas del juego");
        Console.WriteLine("4.- Creditos");
        Console.WriteLine("5.- Puntuaciones");
        Console.WriteLine("6.- Cambiar idioma");
        Console.WriteLine("Q.- Salir");
        Console.WriteLine();
    }

    // We asked the user his name of the game
    public string[] UserName()
    {
        string nPlayers;

        do
        {
            Console.Write("Enter a number of players 2-6: ");
            nPlayers = Console.ReadLine();    
        } while (nPlayers != "2" && nPlayers != "3" && nPlayers != "4" &&
            nPlayers != "5" && nPlayers != "6");

        int nPlayer = Convert.ToInt32(nPlayers);
        string[] name = new string[nPlayer];
        for (int i = 0; i < nPlayer; i++)
        {
            do
            {
                Console.WriteLine("Enter your user name #" + (i + 1) + ": ");
                name[i] = Console.ReadLine();
            } while (name[i] == "");
            Console.WriteLine("Welcome to PokerMasters {0}!", name[i]);
        }
        return name;
    }

    public string[] UserNameEsp()
    {
        string nPlayers;

        do
        {
            Console.Write("Introduce un numero de jugadores 2-6: ");
            nPlayers = Console.ReadLine();
        } while (nPlayers != "2" && nPlayers != "3" && nPlayers != "4" &&
            nPlayers != "5" && nPlayers != "6");

        int nPlayer = Convert.ToInt32(nPlayers);
        string[] name = new string[nPlayer];
        for (int i = 0; i < nPlayer; i++)
        {
            do
            {
                Console.WriteLine("Introduce tu nombre de usuario #" + (i + 1) + ": ");
                name[i] = Console.ReadLine();
            } while (name[i] == "");
            Console.WriteLine("Bienvenido a PokerMasters {0}!", name[i]);
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
        
        string option;
        bool exit = false;

        do
        {
            Console.Clear();
            Title();
            ShowMenu();

            option = Console.ReadLine();
            switch (option.ToUpper())
            {
                case "1":
                    Console.Clear();
                    Game = new GameScreen();
                    string[] name = UserName();
                    Game.Run(name);
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Not available yet...");
                    Console.Clear();
                    Display();
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
                case "6":
                    DisplayEsp();
                    break;
                case "Q":
                    exit = true;
                    Console.WriteLine("See you soon!");
                    Console.WriteLine();
                    break;
                default:
                    Console.Clear();
                    Title();
                    ShowMenu();
                    Console.WriteLine();
                    Console.WriteLine("Enter a correct option!");
                    option = Console.ReadLine();
                    break;
            }
        } while (!exit);
    }

    public void DisplayEsp()
    {
        GameScreen Game;
        CreditsScreen Credits;
        HiScoreScreen HiScore;
        RulesScreen Rules;

        string option;
        bool exit = false;

        do
        {
            Console.Clear();
            Title();
            ShowMenuEsp();

            option = Console.ReadLine();
            switch (option.ToUpper())
            {
                case "1":
                    Console.Clear();
                    Game = new GameScreen();
                    string[] name = UserNameEsp();
                    Game.RunEsp(name);
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("No disponible todavía...");
                    Console.Clear();
                    DisplayEsp();
                    break;
                case "3":
                    Console.Clear();
                    Rules = new RulesScreen();
                    Rules.DisplayEsp();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Credits = new CreditsScreen();
                    Credits.RunEsp();
                    Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    HiScore = new HiScoreScreen();
                    HiScore.RunEsp();
                    Console.Clear();
                    break;
                case "6":
                    Display();
                    break;
                case "Q":
                    exit = true;
                    Console.WriteLine("Hasta pronto!");
                    Console.WriteLine();
                    break;
                default:
                    Console.Clear();
                    Title();
                    ShowMenu();
                    Console.WriteLine();
                    Console.WriteLine("Introduce una opcion correcta!");
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
        Welcome.Display();
    }
}