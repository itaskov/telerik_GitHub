using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    public class Hand : IHand
    {
        public const int HandCardsCount = 5;

        private IList<ICard> cards;
        
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
            this.Cards = this.Cards.OrderByDescending(c => c.Face).ToList();
        }

        public IList<ICard> Cards 
        {
            get { return this.cards; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("cards");
                }

                foreach (var card in value)
                {
                    if (card == null)
                    {
                        throw new NullReferenceException("cards[card]");
                    }
                }

                if (value.Count() != Hand.HandCardsCount)
                {
                    throw new ArgumentException("Invalid count!", "cards");
                }
                
                this.cards = value;
            }
        }

        public override string ToString()
        {
            StringBuilder hand = new StringBuilder();
            foreach (var card in this.Cards)
            {
                hand.Append(card.ToString());
            }
            return hand.ToString();
        }
    }
}
