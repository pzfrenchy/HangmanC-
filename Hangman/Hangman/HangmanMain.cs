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
            List<string> words = new List<string> { "big", "car", "lorry" };
            string word = hm.SelectRandomWord(words);
        }

        /// <summary>
        /// Selects a random word from a list of words
        /// </summary>
        /// <param name="words">List of words</param>
        /// <returns>string</returns>
        public string SelectRandomWord(List<string> words)
        {
            Random random = new Random();
            return words[random.Next(0, words.Count())];
        }

        /// <summary>
        /// Generates a word string with correct guesses added
        /// </summary>
        /// <param name="word">the hidden word</param>
        /// <param name="guesses">list of guesses made</param>
        /// <returns>string</returns>
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

        /// <summary>
        /// Adds a guess(string) to a list of guesses
        /// </summary>
        /// <param name="guesses">List of guesses</param>
        /// <param name="guess">New guess</param>
        /// <returns></returns>
        public List<string> AddToGuesses(List<string> guesses, string guess)
        {
            guesses.Add(guess);
            return guesses;
        }
    }
}
