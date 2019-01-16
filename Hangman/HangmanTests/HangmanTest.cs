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
        public void SelectRandomWord_ReturnsString()
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
        public void AddStringToList_IncreasesListItems()
        {
            HangmanMain hm = MakeHangman();
            List<string> guesses = new List<string> { };
            string guess = "a";

            guesses = hm.AddStringToList(guesses, guess);

            Assert.AreEqual(1, guesses.Count);
        }

        [TestMethod]
        public void RemoveLife_CorrectGuess_ReturnsFalse()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            string guess = "a";

            Assert.IsFalse(hm.RemoveLife(word, guess));
        }

        [TestMethod]
        public void RemoveLife_InCorrectGuess_ReturnsTrue()
        {
            HangmanMain hm = MakeHangman();
            string word = "abc";
            string guess = "d";

            Assert.IsTrue(hm.RemoveLife(word, guess));
        }

        [TestMethod]
        public void OutOfLives_PositiveLives_ReturnsFalse()
        {
            HangmanMain hm = MakeHangman();
            int lives = 3;

            Assert.IsFalse(hm.OutOfLives(lives));
        }

        [TestMethod]
        public void OutOfLives_ZeroLives_ReturnsTrue()
        {
            HangmanMain hm = MakeHangman();
            int lives = 0;

            Assert.IsTrue(hm.OutOfLives(lives));
        }

        [TestMethod]
        public void WordGuessed_AllCorrect_ReturnsTrue()
        {
            HangmanMain hm = MakeHangman();

            string word = "abc";
            List<string> guesses = new List<string> { "a", "b", "c" };

            Assert.IsTrue(hm.WordGuessed(word, guesses));
        }

        [TestMethod]
        public void WordGuessed_NotAllCorrect_ReturnsFalse()
        {
            HangmanMain hm = MakeHangman();

            string word = "abc";
            List<string> guesses = new List<string> { "a", "b", "d" };

            Assert.IsFalse(hm.WordGuessed(word, guesses));
        }

        [TestMethod]
        public void FormatGuessesForPrinting_ReturnsCorrectString()
        {
            HangmanMain hm = MakeHangman();

            List<string> guesses = new List<string> { "a", "b", "c" };

            Assert.AreEqual("abc", hm.FormatGuessesForPrinting(guesses));
        }

        [TestMethod]
        public void RoundNotFinished_WordGuessedAndLivesPositive_ReturnsFalse()
        {
            HangmanMain hm = MakeHangman();

            int lives = 3;
            string word = "abc";
            List<string> guesses = new List<string> { "a", "b", "c" };

            Assert.IsFalse(hm.RoundNotFinished(word, guesses, lives));
        }

        [TestMethod]
        public void RoundNotFinished_WordNotGuessedAndLivesPositive_ReturnsTrue()
        {
            HangmanMain hm = MakeHangman();

            int lives = 3;
            string word = "abc";
            List<string> guesses = new List<string> { "a", "b" };

            Assert.IsTrue(hm.RoundNotFinished(word, guesses, lives));
        }

        [TestMethod]
        public void RoundNotFinished_WordGuessedAndLivesZero_ReturnsFalse()
        {
            HangmanMain hm = MakeHangman();

            int lives = 0;
            string word = "abc";
            List<string> guesses = new List<string> { "a", "b", "c" };

            Assert.IsFalse(hm.RoundNotFinished(word, guesses, lives));
        }

        [TestMethod]
        public void RoundNotFinished_WordNotGuessedAndLivesZero_ReturnsFalse()
        {
            HangmanMain hm = MakeHangman();

            int lives = 0;
            string word = "abc";
            List<string> guesses = new List<string> { "a", "b" };

            Assert.IsFalse(hm.RoundNotFinished(word, guesses, lives));
        }

        [TestMethod]
        public void DuplicateGuess_NotDuplicate_ReturnsFalse()
        {
            HangmanMain hm = MakeHangman();

            List<string> guesses = new List<string> { "a", "b" };
            string guess = "c";

            Assert.IsFalse(hm.DuplicateGuess(guesses, guess));
        }

        [TestMethod]
        public void DuplicateGuess_Duplicate_ReturnsTrue()
        {
            HangmanMain hm = MakeHangman();

            List<string> guesses = new List<string> { "a", "b" };
            string guess = "a";

            Assert.IsTrue(hm.DuplicateGuess(guesses, guess));
        }
    }
}
