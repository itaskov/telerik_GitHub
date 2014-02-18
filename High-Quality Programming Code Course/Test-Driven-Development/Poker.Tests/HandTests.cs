using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestHandCreateNullHand()
        {
            List<ICard> cardsList = null;
            Hand hand = new Hand(cardsList);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestHandCreateNullHandCard()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                null,
                new Card(CardFace.King, CardSuit.Spades)
            };
            Hand hand = new Hand(cardsList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandCreateZeroHand()
        {
            List<ICard> cardsList = new List<ICard>();
            Hand hand = new Hand(cardsList);
        }
        
        [TestMethod]
        public void TestHandToString()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades)
            };

            Hand hand = new Hand(cardsList);

            string expected = "A♠K♠J♣10♦2♥";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
