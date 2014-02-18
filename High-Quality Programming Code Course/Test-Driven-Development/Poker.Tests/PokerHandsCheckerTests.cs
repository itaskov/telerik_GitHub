using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void TestPokerHandsCheckerIsValidHand()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();

            bool expected = true;
            bool actual = handChecker.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsFlush()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsFlush(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsFlushWeel()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsFlush(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotFlush()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsFlush(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsFourOfAKind()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotFourOfAKind()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsHighCard()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsHighCard(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsHighCardFlush()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsHighCard(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsHighCardStraight()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsHighCard(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsOnePair()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsOnePair(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotOnePair()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsOnePair(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsTwoPair()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsTwoPair(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotTwoPair()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsTwoPair(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsThreeOfAKind()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsThreeOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotThreeOfAKind()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsFullHouse()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsFullHouse(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotFullHouse()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsFullHouse(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsStraight()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsStraight(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsStraightWeel()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsStraight(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotStraight()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsStraight(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotStraightWeel()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsStraight(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsStraightFlush()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsStraightFlushWeel()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = true;
            bool actual = handChecker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotStraightFlush()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerIsNotStraightFlushWeel()
        {
            List<ICard> cardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };

            IHand hand = new Hand(cardsList);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool expected = false;
            bool actual = handChecker.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsStraightFlushEquality()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsStraightFlushWeel()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsStraightFlushWeelLowerDifference()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsStraightFlushWeelBiggerDifference()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFourOfAKindEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFourOfAKindBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFourOfAKindLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFullHouseEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFullHouseBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFullHouseLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFlushEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFlushBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsFlushLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsStraightEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsStraightBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsStraightLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight , CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsThreeOfAKindEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsThreeOfAKindBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsThreeOfAKindLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        public void TestPokerHandsCheckerCompareHandsTwoPairEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsTwoPairBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsTwoPairLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        public void TestPokerHandsCheckerCompareHandsOnePairEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsOnePairBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsOnePairLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsHighCardEqual()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsHighCardBigger()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPokerHandsCheckerCompareHandsHighCardLower()
        {
            List<ICard> firstCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            IHand firstHand = new Hand(firstCardsList);

            List<ICard> secondCardsList = new List<ICard>
            {
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            IHand secondHand = new Hand(secondCardsList);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handChecker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
    }
}
