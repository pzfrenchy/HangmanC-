using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System.Collections.Generic;
using System;

namespace HangmanTests
{
    [TestClass]
    public class HangmanTest
    {
        private HangmanMain MakeHangman()
        {
            return new HangmanMain();
        }

        [TestMethod]
        public void GenerateWord_returns_string()
        {
            HangmanMain hm = MakeHangman();
            List<string> words = new List<string> { "big" , "car" , "lorry" };

            Assert.IsNotNull(hm.SelectRandomWord(words));
        }

        [TestMethod]
        public void GetWord_returns_correct_format()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc" ;
            List<string> guesses = new List<string> { "d" };

            Assert.AreEqual(hm.GenerateWordString(word, guesses), "___");
        }

        [TestMethod]
        public void GetWord_returns_correct_format_with_1_guess()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "a" };

            Assert.AreEqual(hm.GenerateWordString(word, guesses), "a__");
        }

        [TestMethod]
        public void GetWord_returns_correct_format_with_2_guess()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "a" , "c" };

            Assert.AreEqual(hm.GenerateWordString(word, guesses), "a_c");
        }

        [TestMethod]
        public void GetWord_returns_correct_format_with_incorrect_guess()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "d" , "a" };

            Assert.AreEqual(hm.GenerateWordString(word, guesses), "a__");
        }

        [TestMethod]
        public void AddToGuesses_increases_list_items()
        {
            HangmanMain hm = MakeHangman();
            List<string> guesses = new List<string> { };
            string guess = "a";

            guesses = hm.AddToGuesses(guesses, guess);

            Assert.AreEqual(guesses.Count, 1);
        }
    }
}
