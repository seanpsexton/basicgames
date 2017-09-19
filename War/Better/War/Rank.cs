using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public enum RankType { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

    public class Rank
    {
        public Rank (RankType type, int value, string abbrev)
        {
            Type = type;
            Value = value;
            Abbrev = abbrev;
        }

        public static readonly string[] RankAbbrevs = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

        public static int RankValue(RankType rank)
        {
            return (int)rank + 2;
        }
    
        public RankType Type { get; }
        public int Value { get; }
        public string Abbrev { get; }
    }
}
