using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanMain
    {
        static void Main(string[] args)
        {
            HangmanMain hm = new HangmanMain();
            hm.PlayGame();
        }

        public string SelectRandomWord(List<string> words)
        {
            Random random = new Random();
            return words[random.Next(0, words.Count())];
        }

        public string GenerateWordString(string word, List<string> guesses)
        {
            string newWord = ""; 
            foreach (char letter in word)
            {
                if (guesses.Contains(letter.ToString()))
                    newWord += letter;
                else
                    newWord += "_";
            }
            return newWord;
        }

        public List<string> AddStringToList(List<string> guesses, string guess)
        {
            guesses.Add(guess);
            return guesses;
        }

        public bool RemoveLife(string word, string guess)
        {
            return (!word.Contains(guess));
        }

        public bool OutOfLives(int lives)
        {
            return (lives == 0);
        }

        public bool WordGuessed(string word, List<string> guesses)
        {
            return (GenerateWordString(word, guesses) == word);
        }

        public bool RoundNotFinished(string word, List<string> guesses, int lives)
        {
            return (!WordGuessed(word, guesses) && !OutOfLives(lives));
        }

        public string FormatGuessesForPrinting(List<string> guesses)
        {
            string formattedString = "";
            foreach (var guess in guesses)
                formattedString += guess;
            return formattedString;
        }

        public string EndMessage(string word, List<string>guesses, int lives)
        {
            string output = "";
            if (OutOfLives(lives))
                output += "You lose";
            else
                output += string.Format("Well done! You have guessed the word {0}", GenerateWordString(word, guesses));
            return output;
        }

        public bool DuplicateGuess(List<string> guesses, string guess)
        {
            return (guesses.Contains(guess));
        }

        public string OutputGuessRequest()
        {
            Console.WriteLine("Please enter a guess: ");
            return Console.ReadLine();
        }

        public void PlayGame()
        {
            bool cont = true;
            while (cont == true)
            {
                int lives = 3;
                List<string> guesses = new List<string>();
                List<string> words = new List<string> { "elephant", "cheese", "rhythm", "temperature" };
                string word = SelectRandomWord(words);
                while (RoundNotFinished(word, guesses, lives))
                {
                    Console.WriteLine(GenerateWordString(word, guesses));
                    Console.WriteLine(string.Format("Current guesses: {0}", FormatGuessesForPrinting(guesses)));
                    string guess = OutputGuessRequest();
                    while (DuplicateGuess(guesses, guess))
                    {
                        Console.WriteLine("Duplicate");
                        guess = OutputGuessRequest();
                    }
                    AddStringToList(guesses, guess);
                    if (RemoveLife(word, guess))
                        lives -= 1;
                }
                Console.WriteLine(EndMessage(word, guesses, lives));
                Console.WriteLine("");
                Console.WriteLine("Play again? Y/N");
                if (Console.ReadLine().ToLower() == "n")
                    cont = false;
            }
        }
    }
}
