using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public enum SuitType { Spade, Diamond, Club, Heart};

    public class Card
    {
        public Card(SuitType suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public SuitType Suit { get; }
        public Rank Rank { get; }
    }
}
