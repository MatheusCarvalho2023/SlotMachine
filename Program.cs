using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class Program
    {
        //global variables
        static Random randGen = new Random();
        static int reel1, reel2, reel3;
        static int coins = 10;
        static int betAmount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Sec2 Casino");

            // The game loop that repeats until a 0 is entered
            do
            {
                try
                {
                    Console.WriteLine($"You have {coins} coins");
                    Console.Write("Please enter a bet between 1-3, or 0 to exit: ");
                    betAmount = Convert.ToInt16(Console.ReadLine());

                    // throw an exception if a value other than 0-3 is entered
                    if (betAmount < 0 || betAmount > 3)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    // run game if inputs and coin amounts are ok, otherwise
                    // show error message
                    if (betAmount != 0 && betAmount <= coins)
                    {
                        DisplayReels();
                        DetermineResults();
                    }
                    else if (betAmount > coins)
                    {
                        Console.WriteLine("You can't bet more than you have");
                    }

                    // end the game when out of money
                    if (coins == 0)
                    {
                        Console.WriteLine("You have run out of money");
                        betAmount = 0;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("You can only bet 1-3");
                }
                catch (Exception ex)
                {
                    //shows a general exception message
                    Console.WriteLine(ex.Message);
                }
            } while (betAmount != 0); //repeats loop as long as a 0 is not entered


            Console.WriteLine("Thank you for playing. Come back soon.");
            Console.ReadKey();
        }

        /// <summary>
        /// Picks 3 random values, (1 for each reel), and displays them
        /// </summary>
        static void DisplayReels()
        {
            reel1 = randGen.Next(1, 4);
            reel2 = randGen.Next(1, 4);
            reel3 = randGen.Next(1, 4);

            switch (reel1)
            {
                case 1:
                    Console.Write(" @ ");
                    break;
                case 2:
                    Console.Write(" & ");
                    break;
                case 3:
                    Console.Write(" # ");
                    break;
            }

            switch (reel2)
            {
                case 1:
                    Console.Write(" @ ");
                    break;
                case 2:
                    Console.Write(" & ");
                    break;
                case 3:
                    Console.Write(" # ");
                    break;
            }

            switch (reel3)
            {
                case 1:
                    Console.Write(" @ ");
                    break;
                case 2:
                    Console.Write(" & ");
                    break;
                case 3:
                    Console.Write(" # ");
                    break;
            }
        }

        /// <summary>
        /// Checks if you won or lost and either gives you money,
        /// (2x your bet), or you lose your betAmount
        /// </summary>
        static void DetermineResults()
        {
            if (reel1 == reel2 && reel1 == reel3)
            {
                Console.WriteLine("You win");
                coins += betAmount * 2;
            }
            else if (reel1 == reel2 || reel1 == reel3 || reel2 == reel3)
            {
                Console.WriteLine("\nSo close. Try again");
                coins -= betAmount;
            }
            else
            {
                Console.WriteLine("\nBetter luck next time");
                coins -= betAmount;
            }
        }
    }
}