using System;

class Program
{
    static void Main(string[] args)
    {
        // For Parts 1 and 2, where the user specified the number...
        //Console.Write("What is the magic number? ");
        //int magicNumber = int.Parse(Console.ReadLine());
        

        // For Part 3, where we use a random number
        string game_again = "";
    do
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int attempts = 1;
        int guess = 1;
        // We could also use a do-while loop here...

        while(guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
                attempts = attempts +1;
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
                attempts = attempts +1;
            }
            else
            {
                Console.WriteLine("You guessed it! ");
                Console.WriteLine($"You guessed after {attempts} attempts");
            }
        }
        Console.WriteLine("Do you wanna play again? Write Yes or No");
        game_again = Console.ReadLine();
    } while (game_again.ToLower() == "yes");
        
        
    }
}