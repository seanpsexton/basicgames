using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public enum SuitType { Spade, Diamond, Club, Heart};
    public enum RankType { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace};

    public class Card
    {
        public Card(SuitType suit, RankType rank)
        {
            Suit = suit;
            Rank = rank;
            NumericRank = (int)rank + 2;
        }

        public SuitType Suit { get; }
        public RankType Rank { get; }
        public int NumericRank { get; }
    }
}
