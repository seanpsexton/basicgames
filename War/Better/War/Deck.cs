using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public class Deck
    {
        public static Deck CreateDeck()
        {
            return new Deck();
        }

        public List<Card> Cards { get; private set; }
    }
}
