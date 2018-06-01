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

    private string textEsp = "Poker es una familia de juegos de cartas que " +
        "combina juegos de azar, estrategia y habilidad. Todas las " +
        "variantes de póquer implican apuestas como una parte intrínseca " +
        "del juego, y determinan el ganador de cada mano según las " +
        "combinaciones de cartas de los jugadores, al menos algunas de las " +
        "cuales permanecen ocultas hasta el final de la mano. Los juegos " +
        "de póker varían en la cantidad de cartas repartidas, la cantidad " +
        "de cartas compartidas o \"comunitarias\", el número de cartas que " +
        "permanecen ocultas y los procedimientos de apuestas." +
        "En la mayoría de los juegos de póquer modernos, la primera ronda " +
        "de apuestas comienza con uno o más de los jugadores que realizan " +
        "alguna forma de apuesta forzada(ciego o ante). En el poker " +
        "estándar, cada jugador apuesta de acuerdo con el rango que cree " +
        "que vale su mano en comparación con los otros jugadores.La acción " +
        "luego continúa en el sentido de las manecillas del reloj ya que " +
        "cada jugador a su vez debe igualar(o \"llamar\") la apuesta " +
        "anterior máxima, o retirarse, perdiendo la cantidad apostada " +
        "hasta el momento y toda participación adicional en la mano.Un " +
        "jugador que iguala una apuesta también puede \"subir\" (aumentar) " +
        "la apuesta.La ronda de apuestas finaliza cuando todos los " +
        "jugadores han igualado la última apuesta o se han retirado.Si " +
        "todos los jugadores menos uno se retiran en cualquier ronda, el " +
        "jugador restante recoge el bote sin que se le exija revelar su " +
        "mano. Si más de un jugador permanece en contención después de la " +
        "última ronda de apuestas, se produce un enfrentamiento donde se " +
        "revelan las manos, y el jugador con la mano ganadora toma el bote.";

    private string[] listOfHands = {
        "1.- Royal Flush",
        "2.- Straight Flush",
        "3.- Four of a kind",
        "4.- Full House",
        "5.- Flush",
        "6.- Straight",
        "7.- Three of a kind",
        "8.- Two pair",
        "9.- One pair",
        "10.- High card",
    };

    private string[] listOfHandsEsp = {
        "1.- Escalera Real",
        "2.- Escalera de Color",
        "3.- Póker",
        "4.- Full",
        "5.- Color",
        "6.- Escalera",
        "7.- Trío",
        "8.- Doble pareja",
        "9.- Pareja",
        "10.- Carta alta",
    };

    public void ShowMenu()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  ---------- Rules ----------");
        Console.WriteLine();
    }

    public void ShowMenuEsp()
    {
        Console.SetCursorPosition(53, 0);
        Console.WriteLine("---------- PokerMasters ----------");
        Console.SetCursorPosition(53, 1);
        Console.WriteLine("  ---------- Reglas ----------");
        Console.WriteLine();
    }

    public void ShowNext()
    {
        Console.SetCursorPosition(114, 32);
        Console.WriteLine("Press Enter to continue...");
    }

    public void ShowNextEsp()
    {
        Console.SetCursorPosition(114, 32);
        Console.WriteLine("Pulsa Intro para continuar...");
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

    public void Display()
    {
        ShowMenu();
        Console.SetCursorPosition(0, 17 / 2);
        Console.WriteLine(text);
        ShowNext();
        string press = Console.ReadLine();
        do
        {
            ShowExit();
            if (press == "")
            {
                Console.Clear();
                byte j = 12;
                for (int i = 0; i < listOfHands.Length; i++)
                {
                    Console.SetCursorPosition(62, j);
                    Console.WriteLine(listOfHands[i]);
                    j++;
                }
                ShowExit();
            }
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
    }

    public void DisplayEsp()
    {
        ShowMenuEsp();
        Console.SetCursorPosition(70 / 2, 17 / 2);
        Console.WriteLine(textEsp);
        ShowNextEsp();
        string press = Console.ReadLine();
        do
        {
            ShowExit();
            if (press == "")
            {
                Console.Clear();
                byte j = 12;
                for (int i = 0; i < listOfHandsEsp.Length; i++)
                {
                    Console.SetCursorPosition(62, j);
                    Console.WriteLine(listOfHandsEsp[i]);
                    j++;
                }
                ShowExitEsp();
            }
            press = Console.ReadLine().ToUpper();
        } while (press != "Q");
    }
}