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
        public void GenerateWord_ReturnsString()
        {
            HangmanMain hm = MakeHangman();
            List<string> words = new List<string> { "big" , "car" , "lorry" };

            Assert.IsNotNull(hm.SelectRandomWord(words));
        }

        [TestMethod]
        public void GenerateWordString_ReturnsCorrectFormat()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc" ;
            List<string> guesses = new List<string> { "" };

            Assert.AreEqual("___", hm.GenerateWordString(word, guesses));
        }

        [TestMethod]
        public void GenerateWordString_OneGuess_ReturnsCorrectFormat()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "a" };

            Assert.AreEqual("a__", hm.GenerateWordString(word, guesses));
        }

        [TestMethod]
        public void GenerateWordString_CorrectGuesses_ReturnsCorrectFormat()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "a" , "c" };

            Assert.AreEqual("a_c", hm.GenerateWordString(word, guesses));
        }

        [TestMethod]
        public void GenerateWordString_IncorrectGuesses_ReturnsCorrectFormat()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "d" , "a" };

            Assert.AreEqual("a__", hm.GenerateWordString(word, guesses));
        }

        [TestMethod]
        public void AddToGuesses_IncreasesListItems()
        {
            HangmanMain hm = MakeHangman();
            List<string> guesses = new List<string> { };
            string guess = "a";

            guesses = hm.AddToGuesses(guesses, guess);

            Assert.AreEqual(1, guesses.Count);
        }

        [TestMethod]
        public void CalcLives_AllCorrectGuesses_ReturnsAllLivesRemaing()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "a" };
            int lives = 3;

            Assert.AreEqual(3, hm.CalcLives(word, guesses, lives));
        }

        [TestMethod]
        public void CalcLives_WrongGuesses_ReturnsCorrectLivesRemaing()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "d" , "f" };
            int lives = 3;

            Assert.AreEqual(1, hm.CalcLives(word, guesses, lives));
        }

        [TestMethod]
        public void CalcLives_MixedGuesses_ReturnsCorrectLivesRemaing()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            List<string> guesses = new List<string> { "a" , "d" };
            int lives = 3;

            Assert.AreEqual(2, hm.CalcLives(word, guesses, lives));
        }
    }
}
