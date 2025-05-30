using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Higher_or_lower
{
    public class Deck
    {
        private const int DECK_LENGTH = 52;
        public List<Card> GameDeck {  get; set; }
        public Card? FaceUp { get; set; }

        // For simplicity purposes, we'll assume a 'deck' is face down on 
        // the table, therefore [0] will be the face down value on the top
        // [1] the card beneath it etc
        public Deck()
        {
            GameDeck = new List<Card>();
            GenerateDeck();
        }

        // TO DO: Make this dynamic - can't be built on assumptions it's a 52 card deck
        public void GenerateDeck()
        {
            // Go through each suit and card value and create one of each
            // Then add it to the deck array
            while (GameDeck.Count  < DECK_LENGTH)
            {
                // Loop for each suit
                for (int i = 0; i < 4; i++)
                {
                    // Loop for each value for each suit
                    for (int j = 2; j <= 14; j++)
                    {
                        Card newCard = new Card(i, j);
                        GameDeck.Add(newCard);
                    }
                }
            }
        }

        public void PrintDeck()
        {
            Console.WriteLine("Printing Game Deck...");
            foreach (Card card in GameDeck)
            {
                Console.WriteLine(card.ReadCardValue());
            }
            Console.WriteLine($"The total number of cards in the deck is: {GameDeck.Count}");
        }

        // Attempt at a more simplistic/realistic shuffle?
        // Essentially just randomly switch around cards a thousand times
        // Kind of like a mega human shuffle but just one by one
        // Achieves the desired effect pretty well
        public void Shuffle()
        {
            for (int i = 0; i < 1000; i++)
            {
                int rnd1 = new Random().Next(0, 51);
                int rnd2 = new Random().Next(0, 51);

                // Check it's not the same index
                while (rnd1 == rnd2)
                {
                    rnd1 = new Random().Next(0, 51);
                    rnd2 = new Random().Next(0, 51);
                }

                SwitchIndexes(rnd1, rnd2);
            }
        }

        public void CardFlip()
        {
            // We want to pop off the top card of the deck
            // Thus updating what is 'face up' on the table
            // And reducing the size of the game deck
            Console.WriteLine("Flipping card over...");
            FaceUp = GameDeck[0];
            GameDeck.Remove(FaceUp);

            Console.WriteLine($"The card face up on the table is now: {FaceUp.ReadCardValue()}");
        }

        public int GetCardCount()
        {
            return GameDeck.Count;
        }

        // Helper method for switching cards around the deck during shuffling
        private void SwitchIndexes(int index1, int index2)
        {
            Card Card1 = GameDeck[index1];
            Card Card2 = GameDeck[index2];

            GameDeck[index1] = Card2;
            GameDeck[index2] = Card1;
        }

    }
}
