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
            int player1Score = 0;
            int player2Score = 0;
            string master;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string guess;
            bool tie = false;
            bool done = false;
            while (!done)
            {

                {
                    Console.WriteLine("Player " + wordPlayer + ", pick a word or phrase. Make sure that player " + guessPlayer + " isn't looking!");
                    master = Console.ReadLine().ToLower();
                    for (int i = 0; i != 1000; i++)
                    {
                        Console.WriteLine(" ");
                    }
                    guess = master;
                    for (int i = 0; i != master.Length; i++)
                    {
                        if (alphabet.Contains(master[i]))
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
                    Console.WriteLine("Alright player " + guessPlayer + ". The secret phrase you need to guess has " + characters + " letters in it that you must guess!.");
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
                            bool solveAttempt = false;
                            bool typo = false;
                            if (!badLetters.Contains(letter) || letter.Length == master.Length)
                            {
                                if (letter.Length == master.Length)
                                {
                                    solveAttempt = true;
                                }
                                if (solveAttempt == false)
                                {
                                    if (letter.Length == 1)
                                    {
                                        badLetters += (" " + letter);
                                        Console.WriteLine("NOPE!");
                                        miss--;
                                    }
                                    else
                                    {
                                        typo = true;
                                    }
                                }
                                if (!typo)
                                {
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
                        Console.WriteLine("Yep! The phrase was " + master + ".");
                        if (guessPlayer == 1)
                        {
                            player1Score++;
                        }
                        else
                        {
                            player2Score++;
                        }
                        Console.WriteLine("Score: ");
                        Console.WriteLine("Player 1:  " + player1Score);
                        Console.WriteLine("Player 2:  " + player2Score);
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
                        if (wordPlayer == 1)
                        {
                            player1Score++;
                        }
                        else
                        {
                            player2Score++;
                        }
                        Console.WriteLine("Score: ");
                        Console.WriteLine("Player 1:  " + player1Score);
                        Console.WriteLine("Player 2:  " + player2Score);
                    }
                    bool good = false;
                    if (tie)
                    {
                        if (player1Score > player2Score)
                        {
                            Console.WriteLine("Player 1 wins!");
                            done = true;
                        }
                        else if (player2Score > player1Score)
                        {
                            Console.WriteLine("Player 2 wins!");
                            done = true;
                        }
                    }
                    else
                    {
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

                                good = true;
                                if (player1Score > player2Score)
                                {
                                    Console.WriteLine("Player 1 wins!");
                                    done = true;
                                }
                                else if (player2Score > player1Score)
                                {
                                    Console.WriteLine("Player 2 wins!");
                                    done = true;
                                }
                                else
                                {
                                    Console.WriteLine("We have a tie!");
                                    Console.WriteLine("We are going to have to settle this....");
                                    tie = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}