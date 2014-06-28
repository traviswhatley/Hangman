using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your name traveler? ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " I am Gandalf Grey Circuits, I am going on an adventure.");
            Console.WriteLine("For this adventure you will have to speak the letters of the word I choose, you shall only have 10 chances.");
            Console.WriteLine("Would you like to try and outwit a wizard?");
            string confirm = Console.ReadLine().ToLower();
            while (confirm != "yes" && confirm != "no")
            {
                Console.WriteLine();
                Console.WriteLine("I do not know of this.");
                Console.Write("Shall we embark?");
                confirm = Console.ReadLine().ToLower();
            }
            if (confirm == "no")
            {
                Console.WriteLine();
                Console.WriteLine("The world is not here in this game it's outside.");
            }
            else if (confirm == "yes")
            {
                HangMan();
            }
            //keep console open
            Console.ReadKey();
        }

        static void HangMan()
        {  
            Random random = new Random();
            string [] wordBank = {"ainur", "men", "elves", "dwarves", "eagles", "hobbits"};
            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            string wordToGuessUpperCase = wordToGuess.ToUpper();
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                displayToPlayer.Append("_");
            }
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();
            int lives = 10;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.Write("I have thought of a word. What is your guess? ");
                input = Console.ReadLine().ToUpper();
                if (input.Length > 1)
                {
                    if (input == wordToGuessUpperCase)
                    {
                        won = true;
                    }
                    else
                    {
                        won = false;
                        Console.WriteLine("Your guess was incorrect my friend, please try again");
                        lives--;
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guesses left my friend.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    guess = input[0];
                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You have already spoken " + guess);
                        Console.WriteLine();
                        Console.Write("You have spoken these letters: ");
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guesses left my friend");
                        Console.WriteLine();
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("I'm sorry but " + guess + " was already spoken, and it was wrong.");
                        Console.WriteLine();
                        Console.Write("You have spoken these letters: ");
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guesses left my friend");
                        Console.WriteLine();
                        continue;
                    }
                    if (wordToGuessUpperCase.Contains(guess))
                    {
                        correctGuesses.Add(guess);
                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUpperCase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                                Console.WriteLine();
                                Console.Write("You have spoken these letters: ");
                                loop(correctGuesses);
                                loop(incorrectGuesses);
                                Console.WriteLine();
                                Console.WriteLine("You have " + lives + " guesses left my friend");
                                Console.WriteLine();
                            }
                        }
                        if (lettersRevealed == wordToGuess.Length)
                        {
                            won = true;
                        }
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);
                        Console.WriteLine("I'm sorry but " + guess + " was already spoken, and it was wrong.");
                        lives--;
                        Console.WriteLine();
                        Console.Write("You have spoken these letters: ");
                        loop(correctGuesses);
                        loop(incorrectGuesses);
                        Console.WriteLine();
                        Console.WriteLine("You have " + lives + " guesses left my friend");
                        Console.WriteLine();
                    }
                    Console.WriteLine(string.Join(" ", displayToPlayer.ToString().ToList()));
                }
             }
             if (won)
             {
                Console.WriteLine();
                Console.WriteLine("You have completed my challenge. Let the adventure begin.");
             }
             else
             {
                Console.WriteLine();
                Console.WriteLine("You have failed I'm afraid Middle Earth is in peril the word was " + wordToGuess);
             }
             Console.WriteLine("[Press 'Enter' to exit]");
        }
        static void loop(List<char> a)
        {
            foreach (char b in a)
            {
                Console.Write(b + " ");
            }
        }
    }
}
