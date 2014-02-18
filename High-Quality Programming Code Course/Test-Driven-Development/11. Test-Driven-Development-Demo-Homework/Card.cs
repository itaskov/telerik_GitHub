using System;
using System.Collections.Generic;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string cardFace = GetCardFaseSymbol(this);
            string cardSuit = GetCardSuitSymbol(this);
            return cardFace + cardSuit;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        
        private static string GetCardSuitSymbol(Card card)
        {
            string cardSuit;
            switch (card.Suit)
            {
                case CardSuit.Clubs:
                    cardSuit = "♣";
                    break;
                case CardSuit.Diamonds:
                    cardSuit = "♦";
                    break;
                case CardSuit.Hearts:
                    cardSuit = "♥";
                    break;
                case CardSuit.Spades:
                    cardSuit = "♠";
                    break;
                default:
                    throw new NotImplementedException("Unknown suit " + card.Suit);
            }
            return cardSuit;
        }

        private static string GetCardFaseSymbol(Card card)
        {
            string cardFace;
            if ((int)card.Face <= 10)
            {
                cardFace = ((int)card.Face).ToString();
            }
            else
            {
                cardFace = card.Face.ToString()[0].ToString();
            }

            return cardFace;
        }

        public int CompareTo(ICard other)
        {
            int result = 0;
            if (this.Face < other.Face)
            {
                result = -1;
            }
            else if (this.Face > other.Face)
            {
                result = 1;
            }

            return result;
        }
    }

    class CardSameFaceAndSuit : EqualityComparer<ICard>
    {
        public override bool Equals(ICard c1, ICard c2)
        {
            if (c1.Face == c2.Face && c1.Suit == c2.Suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(ICard card)
        {
            int hCode = (int)card.Face ^ (int)card.Suit;
            return hCode.GetHashCode();
        }
    }

    class CardSameFace : EqualityComparer<ICard>
    {
        public override bool Equals(ICard c1, ICard c2)
        {
            if (c1.Face == c2.Face)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(ICard card)
        {
            int hCode = (int)card.Face;
            return hCode.GetHashCode();
        }
    }
}