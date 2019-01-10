using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System.Collections.Generic;

namespace HangmanTests
{
    [TestClass]
    public class HangmanTest
    {
        [TestMethod]
        public void GenerateWord_returns_string()
        {
            List<string> words = new List<string> { "big" , "car" , "lorry" };
            Assert.IsNotNull(HangmanMain.SelectRandomWord(words));
        }

        [TestMethod]
        public void GetWord_returns_correct_format()
        {
            string word = "abc" ;
            List<string> guesses = new List<string> { "d" };

            Assert.AreEqual(HangmanMain.GenerateWordString(word, guesses), "___");
        }

        [TestMethod]
        public void GetWord_returns_correct_format_with_1_guess()
        {
            string word = "abc";
            List<string> guesses = new List<string> { "a" };

            Assert.AreEqual(HangmanMain.GenerateWordString(word, guesses), "a__");
        }

        [TestMethod]
        public void GetWord_returns_correct_format_with_2_guess()
        {
            string word = "abc";
            List<string> guesses = new List<string> { "a" , "c" };

            Assert.AreEqual(HangmanMain.GenerateWordString(word, guesses), "a_c");
        }

        [TestMethod]
        public void GetWord_returns_correct_format_with_incorrect_guess()
        {
            string word = "abc";
            List<string> guesses = new List<string> { "d" , "a" };

            Assert.AreEqual(HangmanMain.GenerateWordString(word, guesses), "a__");
        }

        [TestMethod]
        public void AddToGuesses_increases_list_items()
        {
            List<string> guesses = new List<string> { };
            string guess = "a";

            guesses = HangmanMain.AddToGuesses(guesses, guess);

            Assert.AreEqual(guesses.Count, 1);
        }
    }
}
