using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public class Deck
    {
        public static Deck CreateDeck()
        {
            var deck = new Deck();
            //foreach (SuitType s in SuitType)
            //{
            //    foreach (RankType r in RankType)
            //    {

            //    }
            //}

            return deck;
        }

        public List<Card> Cards { get; private set; }
    }
}
