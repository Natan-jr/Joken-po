using System;

public enum Hand
{
    Pedra,
    Papel,
    Tesoura
}

public class Player
{
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public Hand ChooseHand()
    {
        Console.WriteLine(Name + ", choose your hand (0: Rock, 1: Paper, 2: Scissors): ");
        int choice = int.Parse(Console.ReadLine());
        return (Hand)choice;
    }
}

public class Game
{
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }

    public Game(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
    }

    public void Play()
    {
        Console.WriteLine("Let's play Jokenpo!");
        Console.WriteLine("Player 1: " + Player1.Name);
        Console.WriteLine("Player 2: " + Player2.Name);

        Hand player1Hand = Player1.ChooseHand();
        Hand player2Hand = Player2.ChooseHand();

        Console.WriteLine("Player 1 chose: " + player1Hand);
        Console.WriteLine("Player 2 chose: " + player2Hand);

        if (player1Hand == player2Hand)
        {
            Console.WriteLine("It's a tie!");
        }
        else if (IsWinner(player1Hand, player2Hand))
        {
            Console.WriteLine(Player1.Name + " wins!");
        }
        else
        {
            Console.WriteLine(Player2.Name + " wins!");
        }
    }

    private bool IsWinner(Hand player1Hand, Hand player2Hand)
    {
        if (player1Hand == Hand.Pedra && player2Hand == Hand.Tesoura) return true;
        if (player1Hand == Hand.Papel && player2Hand == Hand.Pedra) return true;
        if (player1Hand == Hand.Tesoura && player2Hand == Hand.Papel) return true;
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player player1 = new Player("Alice");
        Player player2 = new Player("Bob");
        Game game = new Game(player1, player2);
        game.Play();
    }
}