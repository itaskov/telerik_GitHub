using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool isValid = true;
            CardSameFaceAndSuit cardComparator = new CardSameFaceAndSuit();
            var distinctCards = (from card in hand.Cards
                                 select card).Distinct(cardComparator);

            if (distinctCards.Count() != Hand.HandCardsCount)
            {
                isValid = false;
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool equalSuit = IsHandSuitEqual(hand);
            bool consecutiveFace = AreHandCardsFaceConsecutive(hand);
            return equalSuit && consecutiveFace;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int expectedCount = 4;
            int actualCount = GetMaxCardsCountOfAKind(hand);
            return actualCount == expectedCount;
        }

        private static int GetMaxCardsCountOfAKind(IHand hand)
        {
            var maxCardsCountOfAKind = hand.Cards.GroupBy(card => card.Face).Select(group => group.Count()).Max();
            return maxCardsCountOfAKind;
        }

        /// <summary>
        /// Get list of cards according their count.
        /// </summary>
        /// <param name="hand">hand</param>
        /// <param name="cardsCount">Number of cards of the same kind.</param>
        /// <returns></returns>
        private static List<CardFace> GetCardsFaces(IHand hand, int cardsCount)
        {
            List<CardFace> cardsList = new List<CardFace>();
            var cards = hand.Cards.GroupBy(card => card.Face).Where(group => group.Count() == cardsCount);
            foreach (var card in cards)
            {
                cardsList.Add(card.Key);
            }
            return cardsList;
        }

        public bool IsFullHouse(IHand hand)
        {
            bool result = this.IsTwoPair(hand) && this.IsThreeOfAKind(hand);
            return result;
        }

        public bool IsFlush(IHand hand)
        {
            bool equalSuit = IsHandSuitEqual(hand);
            bool consecutiveFace = AreHandCardsFaceConsecutive(hand);
            return equalSuit && !consecutiveFace;
        }

        private static bool AreHandCardsFaceConsecutive(IHand hand)
        {
            bool areCardsConsecutive = true;
            int firstCardFaseNumber = (int)hand.Cards[0].Face;


            for (int i = 1; i < hand.Cards.Count; i++)
            {
                int nextCard = (int)hand.Cards[i].Face;
                if (firstCardFaseNumber - nextCard != 1)
                {
                    areCardsConsecutive = false;
                    break;
                }
                firstCardFaseNumber = nextCard;
            }

            if (!areCardsConsecutive)
            {
                areCardsConsecutive = IsWeel(hand);
            }

            return areCardsConsecutive;
        }

        /// <summary>
        /// Check for straight known as weel.
        /// </summary>
        /// <param name="hand">Hand value</param>
        /// <returns>bool</returns>
        private static bool IsWeel(IHand hand)
        {
            bool isWeel = true;
            bool isFirstCardAce = hand.Cards[0].Face == CardFace.Ace;

            if (!isFirstCardAce)
            {
                isWeel = false;
                return isWeel;
            }

            int secondCardFaseNumber = (int)hand.Cards[1].Face;
            for (int i = 2; i < hand.Cards.Count; i++)
            {
                int nextCard = (int)hand.Cards[i].Face;
                if (secondCardFaseNumber - nextCard != 1)
                {
                    // For clearance.
                    isWeel = false;
                    return isWeel;
                }
                secondCardFaseNumber = nextCard;
            }

            // If the last card fase is 2.
            isWeel = hand.Cards[hand.Cards.Count - 1].Face == CardFace.Two;
            return isWeel;
        }

        private static bool IsHandSuitEqual(IHand hand)
        {
            bool result = true;
            CardSuit firstCardSuit = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (firstCardSuit != hand.Cards[i].Suit)
                {
                    result = false;
                }
            }
            return result;
        }

        public bool IsStraight(IHand hand)
        {
            bool equalSuit = IsHandSuitEqual(hand);
            bool consecutiveFace = AreHandCardsFaceConsecutive(hand);
            bool result = !equalSuit && consecutiveFace;
            return result;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            int expectedCount = 3;
            int actualCount = GetMaxCardsCountOfAKind(hand);
            return actualCount == expectedCount;
        }

        public bool IsTwoPair(IHand hand)
        {
            int expectedPair = 2;
            int actualPair = GetNumberOfPairs(hand);
            return expectedPair == actualPair;
        }

        public bool IsOnePair(IHand hand)
        {
            int expectedPair = 1;
            int actualPair = GetNumberOfPairs(hand);
            return expectedPair == actualPair;
        }

        private static int GetNumberOfPairs(IHand hand)
        {
            var numberOfPairs = hand.Cards.GroupBy(card => card.Face).Where(group => group.Count() > 1);
            return numberOfPairs.Count();
        }

        public bool IsHighCard(IHand hand)
        {
            int maxCount = 1;
            int cardsCount = GetMaxCardsCountOfAKind(hand);
            bool equalSuit = IsHandSuitEqual(hand);
            bool consecutiveFace = AreHandCardsFaceConsecutive(hand);
            return cardsCount == maxCount && !equalSuit && !consecutiveFace;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            int result = 0;

            bool firstHandResult = this.IsStraightFlush(firstHand) || this.IsFourOfAKind(firstHand) || this.IsFullHouse(firstHand) || this.IsFlush(firstHand) ||
                                    this.IsStraight(firstHand) || this.IsThreeOfAKind(firstHand) || this.IsTwoPair(firstHand) || this.IsOnePair(firstHand) || this.IsHighCard(firstHand);
            bool secondHandResult = this.IsStraightFlush(secondHand) || this.IsFourOfAKind(secondHand) || this.IsFullHouse(secondHand) || this.IsFlush(secondHand) ||
                                    this.IsStraight(secondHand) || this.IsThreeOfAKind(secondHand) || this.IsTwoPair(secondHand) || this.IsOnePair(secondHand) || this.IsHighCard(secondHand);

            // Compare both sides of the operator | always.
            if ((firstHandResult = this.IsStraightFlush(firstHand)) | (secondHandResult = this.IsStraightFlush(secondHand)))
            {
                result = CompareStraightFlush(firstHand, secondHand, firstHandResult, secondHandResult);
                return result;
            }
            else if ((firstHandResult = this.IsFourOfAKind(firstHand)) | (secondHandResult = this.IsFourOfAKind(secondHand)))
            {
                // Four of a kind.
                result = CompareNumberOfCardsOfAKind(firstHand, secondHand, firstHandResult, secondHandResult, 4);
                return result;
            }
            else if ((firstHandResult = this.IsFullHouse(firstHand)) | (secondHandResult = this.IsFullHouse(secondHand)))
            {
                result = CompareFullHouse(firstHand, secondHand, firstHandResult, secondHandResult);
                return result;
            }
            else if ((firstHandResult = this.IsFlush(firstHand)) | (secondHandResult = this.IsFlush(secondHand)))
            {
                // Flush.
                result = CompareFlush(firstHand, secondHand, firstHandResult, secondHandResult);
                return result;
            }
            else if ((firstHandResult = this.IsStraight(firstHand)) | (secondHandResult = this.IsStraight(secondHand)))
            {
                // Straight.
                result = CompareStraightFlush(firstHand, secondHand, firstHandResult, secondHandResult);
                return result;
            }
            else if ((firstHandResult = this.IsThreeOfAKind(firstHand)) | (secondHandResult = this.IsThreeOfAKind(secondHand)))
            {
                // Three of a kind.
                result = CompareNumberOfCardsOfAKind(firstHand, secondHand, firstHandResult, secondHandResult, 3);
                return result;
            }
            else if ((firstHandResult = this.IsTwoPair(firstHand)) | (secondHandResult = this.IsTwoPair(secondHand)))
            {
                result = CompareTwoPair(firstHand, secondHand, firstHandResult, secondHandResult);
                return result;
            }
            else if ((firstHandResult = this.IsOnePair(firstHand)) | (secondHandResult = this.IsOnePair(secondHand)))
            {
                // One pair.
                result = CompareNumberOfCardsOfAKind(firstHand, secondHand, firstHandResult, secondHandResult, 2);
                return result;
            }
            else if ((firstHandResult = this.IsHighCard(firstHand)) | (secondHandResult = this.IsHighCard(secondHand)))
            {
                // High card.
                result = CompareFlush(firstHand, secondHand, firstHandResult, secondHandResult);
                return result;
            }
            else
            {
                throw new NotImplementedException("Unknown poker hand!");
            }
        }

        private int CompareTwoPair(IHand firstHand, IHand secondHand, bool firstHandResult, bool secondHandResult)
        {
            int result = 0;

            if (firstHandResult && secondHandResult)
            {
                int cardsCount = 2;

                List<CardFace> firstHandCardsList = GetCardsFaces(firstHand, cardsCount);
                List<CardFace> secondHandCardsList = GetCardsFaces(secondHand, cardsCount);
                for (int index = 0; index < firstHandCardsList.Count; index++)
                {
                    result = firstHandCardsList[index].CompareTo(secondHandCardsList[index]);
                    if (result != 0)
                    {
                        return result;
                    }
                }


                result = CompareHandsCards(firstHand, secondHand);
                return result;
            }
            else if (firstHandResult)
            {
                result = 1;
                return result;
            }
            else
            {
                result = -1;
                return result;
            }
        }

        private int CompareFlush(IHand firstHand, IHand secondHand, bool firstHandResult, bool secondHandResult)
        {
            int result = 0;

            if (firstHandResult && secondHandResult)
            {
                result = CompareHandsCards(firstHand, secondHand);
                return result;
            }
            else if (firstHandResult)
            {
                result = 1;
                return result;
            }
            else
            {
                result = -1;
                return result;
            }
        }

        private int CompareFullHouse(IHand firstHand, IHand secondHand, bool firstHandResult, bool secondHandResult)
        {
            int result = 0;

            if (firstHandResult && secondHandResult)
            {
                int cardsCount = 3;
                int pairsCount = 2;

                // Compare the pairs in the Full house.
                for (int count = 0; count < pairsCount; count++)
                {
                    List<CardFace> firstHandCardsList = GetCardsFaces(firstHand, cardsCount);
                    List<CardFace> secondHandCardsList = GetCardsFaces(secondHand, cardsCount);
                    for (int index = 0; index < firstHandCardsList.Count; index++)
                    {
                        result = firstHandCardsList[index].CompareTo(secondHandCardsList[index]);
                        if (result != 0)
                        {
                            return result;
                        }
                    }
                    cardsCount--;
                }

                result = CompareHandsCards(firstHand, secondHand);
                return result;
            }
            else if (firstHandResult)
            {
                result = 1;
                return result;
            }
            else
            {
                result = -1;
                return result;
            }
        }

        private int CompareNumberOfCardsOfAKind(IHand firstHand, IHand secondHand, bool firstHandResult, bool secondHandResult, int cardsNumber)
        {
            int result = 0;

            if (firstHandResult && secondHandResult)
            {
                List<CardFace> firstHandCardsList = GetCardsFaces(firstHand, cardsNumber);
                List<CardFace> secondHandCardsList = GetCardsFaces(secondHand, cardsNumber);
                for (int i = 0; i < firstHandCardsList.Count; i++)
                {
                    result = firstHandCardsList[i].CompareTo(secondHandCardsList[i]);
                    if (result != 0)
                    {
                        return result;
                    }
                }

                result = CompareHandsCards(firstHand, secondHand);
                return result;
            }
            else if (firstHandResult)
            {
                result = 1;
                return result;
            }
            else
            {
                result = -1;
                return result;
            }
        }

        private int CompareStraightFlush(IHand firstHand, IHand secondHand, bool firstHandResult, bool secondHandResult)
        {
            int result = 0;

            if (firstHandResult && secondHandResult)
            {
                bool isFirstHandWeel = IsWeel(firstHand);
                bool isSecondHandWeel = IsWeel(secondHand);
                if (isFirstHandWeel || isSecondHandWeel)
                {
                    result = CompareWeel(isFirstHandWeel, isSecondHandWeel);
                    return result;
                }

                result = CompareHandsCards(firstHand, secondHand);
                return result;
            }
            else if (firstHandResult)
            {
                result = 1;
                return result;
            }
            else
            {
                result = -1;
                return result;
            }
        }

        private static int CompareHandsCards(IHand firstHand, IHand secondHand)
        {
            int result = 0;
            for (int cardIndex = 0; cardIndex < firstHand.Cards.Count; cardIndex++)
            {

                int comparison = firstHand.Cards[cardIndex].CompareTo(secondHand.Cards[cardIndex]);
                if (comparison != 0)
                {
                    result = comparison;
                    return result;
                }
            }
            return result;
        }

        private static int CompareWeel(bool isFirstHandWeel, bool isSecondHandWeel)
        {
            int result = 0;
            if (isFirstHandWeel && isSecondHandWeel)
            {
                return result;
            }
            else if (isFirstHandWeel)
            {
                result = -1;
            }
            else
            {
                result = 1;
            }
            return result;
        }
    }
}
