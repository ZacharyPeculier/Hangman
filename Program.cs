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
            int guessPlayer = 1;
            int wordPlayer = 2;
            string master;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string guess;
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Player " + wordPlayer + ", pick a word. Make sure that player " + guessPlayer + " isn't looking!");
                master = Console.ReadLine().ToLower();
                for (int i = 0; i != 1000; i++)
                {
                    Console.WriteLine(" ");
                }
                guess = master;
                for (int i = 0; i != master.Length; i++)
                {
                     if(alphabet.Contains(master[i]))
                    {
                        guess = guess.Replace(master[i], '*');
                    }
                }
                int characters = 0;
                for (int i = 0; i != guess.Length; i++)
                {
                    if (guess[i] == '*')
                    {
                        characters++;
                    }
                }
                Console.WriteLine("Alright player " + guessPlayer + ". The word you need to guess has " + characters + " letters in it.");
                bool gameEnd = false;
                bool win = false;
                string badLetters = "";
                int miss = 6;
                string letter;
                StringBuilder sb = new StringBuilder(guess);
                while (!gameEnd)
                {
                    Console.WriteLine(guess);
                    Console.WriteLine("Guess a letter!");
                    Console.WriteLine("Wrong letters: " + badLetters);
                    letter = Console.ReadLine().ToLower();
                    if (letter.Length == 1 && master.Contains(letter))
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        for (int i = 0; i != master.Length; i++)
                        {
                            if (master[i] == letter.ToCharArray()[0])
                            {
                                sb[i] = letter.ToCharArray()[0];
                                guess = sb.ToString();
                            }
                        }
                        if (!guess.Contains("*"))
                        {
                            gameEnd = true;
                            win = true;
                        }
                    }
                    else if (letter == master)
                    {
                        win = true;
                        gameEnd = true;
                    }
                    else
                    {
                        if (!badLetters.Contains(letter))
                        {
                            Console.WriteLine("NOPE!");
                            miss--;
                            badLetters += (" " + letter);
                            switch (miss)
                            {
                                case 5:
                                    Console.WriteLine("   O");
                                    break;
                                case 4:
                                    Console.WriteLine("   O");
                                    Console.WriteLine("   |");
                                    Console.WriteLine("   |");
                                    break;
                                case 3:
                                    Console.WriteLine("   O");
                                    Console.WriteLine("   |");
                                    Console.WriteLine("   |");
                                    Console.WriteLine("  /");
                                    break;
                                case 2:
                                    Console.WriteLine("   O");
                                    Console.WriteLine("   |");
                                    Console.WriteLine("   |");
                                    Console.WriteLine("  / \\");
                                    break;
                                case 1:
                                    Console.WriteLine("   O");
                                    Console.WriteLine("  \\|");
                                    Console.WriteLine("   |");
                                    Console.WriteLine("  / \\");
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (miss != 0)
                        {
                            Console.WriteLine("You have " + miss + " wrong guesses left!");
                        }
                        else
                        {
                            gameEnd = true;
                        }
                    }
                }
                if (win)
                {
                    Console.WriteLine("Yep! The word was " + master + ".");
                    Console.WriteLine("Player " + guessPlayer + " wins!");
                }
                else
                {
                    Console.WriteLine("   O");
                    Console.WriteLine("  \\|/");
                    Console.WriteLine("   |");
                    Console.WriteLine("  / \\");
                    Console.WriteLine("oof");
                    Console.WriteLine("The guy died.");
                    Console.WriteLine("Press F to pay respects");
                    Console.Beep(349, 750);
                    Console.Beep(349, 250);
                    Console.Beep(466, 1000);
                    Console.Beep(349, 750);
                    Console.Beep(466, 250);
                    Console.Beep(587, 1500);
                    Console.Beep(349, 750);
                    Console.Beep(466, 250);
                    Console.Beep(587, 1000);
                    Console.Beep(349, 750);
                    Console.Beep(466, 250);
                    Console.Beep(587, 1000);
                    Console.Beep(349, 750);
                    Console.Beep(466, 250);
                    Console.Beep(587, 1000);
                    Console.Beep(466, 750);
                    Console.Beep(587, 250);
                    Console.Beep(698, 1500);
                    Console.Beep(587, 250);
                    Console.Beep(466, 250);
                    Console.Beep(349, 1000);
                    Console.Beep(349, 750);
                    Console.Beep(349, 500);
                    Console.Beep(466, 2000);
                    Console.WriteLine("The word was " + master + ".");
                    Console.WriteLine("Player " + wordPlayer + " wins!");
                }
                bool good = false;
                while (!good)
                {
                    Console.WriteLine("Would you like to play again? [y/n]");
                    string again = Console.ReadLine().ToLower();
                    if (again == "y")
                    {
                        done = false;
                        good = true;
                        if (guessPlayer == 1)
                        {
                            guessPlayer = 2;
                            wordPlayer = 1;
                        }
                        else
                        {
                            guessPlayer = 1;
                            wordPlayer = 2;
                        }
                    }
                    else if (again == "n")
                    {
                        done = true;
                        good = true;
                    }
                }
            }
        }
    }
}
