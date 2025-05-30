using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Higher_or_lower
{
    public class Card
    {
        // Allow the construction of a null Card in order to populate 'empty' decks
        private Suit? CardSuit {  get; set; }
        private CardValue? Value { get; set; }

        public Card (Suit? cardSuit = null, CardValue? value = null)
        {
            CardSuit = cardSuit;
            Value = value;
        }

        public Card(int i, int j)
        {
            this.CardSuit = (Suit)i;
            this.Value = (CardValue)j;
        }

        public string ReadCardValue()
        {
            return $"The {Value} of {CardSuit}";
        }

        public Suit? GetCardSuit ()
        {
            return CardSuit;
        }

        public CardValue? GetCardValue()
        {
            return Value;
        }
    }
}
