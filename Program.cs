using System;
using System.CodeDom.Compiler;

namespace Lab5._2RockPaperScissors
{
    enum Roshambo
    {
        Scissors,
        Paper,
        Rock,


    }

    class RockPaperScissors
    {

        public static void PlayRPS(Player player1, Player player2, Roshambo played1, Roshambo played2)
        {
            int play1 = (int)played1;
            int play2 = (int)played2;

            Console.WriteLine($"\n\n{ player1.Name} played {played1}");

            Console.WriteLine($"{ player2.Name} played { played2}");

            if (play2 == play1)
            {
                Console.WriteLine("tie!");
            }
            else if ((play1 == 0 && play2 == 1) || (play1 == 1 && play2 == 2) || (play1 == 2 && play2 == 0))
            {
                Console.WriteLine($"{player1.Name} wins!");
            }
            else
            {
                Console.WriteLine($"{player2.Name} wins!");
            }

        }
    }

    abstract class Player
    {
        public string Name { get; set; }
        Roshambo RoPaSc { get; set; }


        public virtual Roshambo GenerateRoshambo()
        {
            return Roshambo.Rock;
        }
    }

    class RockPlayer : Player
    {

        public RockPlayer()
        {
            Name = "Rock player";

        }
    }


    class RandPlayer : Player
    {

        private static Random rand = new Random();
        public override Roshambo GenerateRoshambo()
        {
            int random_num = rand.Next(3);
            Roshambo roshambo = (Roshambo)random_num;
            return roshambo;
        }


        public RandPlayer()
        {
            Name = "Rando";
        }
    }

    class UserPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            bool isValid = true;
            string userInput;
            do
            {
                Console.WriteLine("Choose Rock Paper or Scissors(r/p/s)");
                userInput = Console.ReadLine().ToLower();
                if (userInput != "r" & userInput != "p" & userInput != "s")
                {
                    Console.WriteLine("Not a valid option, try again");
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

            } while (isValid == false);

            if (userInput == "r")
            {
                return Roshambo.Rock;
            }
            if (userInput == "p")
            {
                return Roshambo.Paper;
            }
            else
            {
                return Roshambo.Scissors;
            }
        }
        public UserPlayer(string name)
        {
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string userName = "";
            string userinput = "";
            Console.WriteLine("Enter your name:");
            userName = Console.ReadLine();
            UserPlayer player1 = new UserPlayer(userName);
            string cont = "y";
            do
            {
                Console.Clear();
                Console.WriteLine("Who do you want to play? rock or random?");
                userinput = Console.ReadLine().ToLower();


                if (userinput == "rock")
                {

                    RockPlayer player2 = new RockPlayer();
                    RockPaperScissors.PlayRPS(player1, player2, player1.GenerateRoshambo(), player2.GenerateRoshambo());
                    Console.WriteLine("Do you want to go again?");
                    cont = Console.ReadLine();
                }
                else if (userinput == "random")
                {
                    RandPlayer player2 = new RandPlayer();
                    RockPaperScissors.PlayRPS(player1, player2, player1.GenerateRoshambo(), player2.GenerateRoshambo());
                    Console.WriteLine($"\nDo you want to go again?(y/n)");
                    cont = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Not a valid choice, try again.");
                }

            } while (cont != "n");

        }
    }
}

