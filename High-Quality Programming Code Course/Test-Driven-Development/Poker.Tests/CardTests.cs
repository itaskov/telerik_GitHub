using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestCardToStringAceSpade()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCardToStringTwoClub()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "2♣";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCardToStringTenDiamond()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♦";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCardToStringJackDiamond()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);
            string expected = "J♦";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
