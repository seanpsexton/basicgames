using System;

namespace War
{
    class Program
    {
        /// <summary>
        /// BASIC Computer Games
        /// David H. Ahl, ed
        /// Published 1978
        /// 
        /// C# version of War (pg 178)
        ///  - Ported from original program in book (MITS Altair BASIC)
        ///  - Output and algorithms are identical to original
        ///  - Basic C# constructs used, e.g. array rather than list
        ///  - No LINQ used
        ///  - Comments show original variable names (where useful)
        ///  
        /// C# version created by Sean Sexton, 18 Sep 2017
        /// </summary>
        static void Main(string[] args)
        {
            var c = new Card(SuitType.Club, RankType.Ten);

            PrintIntro();
            ShowDirections();

            int[] deck = ShuffleDeck();   // L()

            Play(deck);

            Console.ReadLine();
        }

        static string[] cardData = {      // A$()
            "S-2", "H-2", "C-2", "D-2",
            "S-3", "H-3", "C-3", "D-3",
            "S-4", "H-4", "C-4", "D-4",
            "S-5", "H-5", "C-5", "D-5",
            "S-6", "H-6", "C-6", "D-6",
            "S-7", "H-7", "C-7", "D-7",
            "S-8", "H-8", "C-8", "D-8",
            "S-9", "H-9", "C-9", "D-9",
            "S-10", "H-10", "C-10", "D-10",
            "S-J", "H-J", "C-J", "D-J",
            "S-Q", "H-Q", "C-Q", "D-Q",
            "S-K", "H-K", "C-K", "D-K",
            "S-A", "H-A", "C-A", "D-A"
        };

        static void PrintIntro()
        {
            Console.WriteLine($"{" ",33}WAR");
            Console.WriteLine($"{" ",15}CREATIVE COMPUTING  MORRISTONW, NEW JERSEY");
            Console.Write("\n\n\n");
            Console.WriteLine("THIS IS THE CARD GAME OF WAR.  EACH CARD IS GIVEN BY SUIT-#");
            Console.Write("AS S-7 FOR SPADE 7.  ");
        }

        static void ShowDirections()
        {
            string directions;
            do
            {
                Console.Write("DO YOU WANT DIRECTIONS? ");
                directions = Console.ReadLine().ToLower();

                if (directions == "yes")
                {
                    Console.WriteLine("THE COMPUTER GIVES YOU AND IT A 'CARD'.  THE HIGHER CARD");
                    Console.WriteLine("(NUMERICALLY) WINS.  THE GAME ENDS WHEN YOU CHOOSE NOT TO");
                    Console.WriteLine("CONTINUE OR WHEN YOU HAVE FINISHED THE PACK.");
                }
                else if (directions != "no")
                {
                    Console.Write("YES OR NO, PLEASE.  ");
                }
            } while ((directions != "yes") && (directions != "no"));

            Console.Write("\n\n");
        }

        /// <summary>
        /// Shuffle the deck by creating a random list of integers, each of 
        /// which is from 0-51 and represents a card in cardData[]
        /// </summary>
        static int[] ShuffleDeck()
        {
            Random rnd = new Random();
            int[] deck = new int[52];

            for (int i = 0; i < 52; i++)
            {
                int nextCard;
                bool cardAlreadyPicked;
                do
                {
                    // At each spot in deck, pick card at that spot
                    // (random # between 0 - 51)
                    cardAlreadyPicked = false;
                    nextCard = rnd.Next(52);

                    // Then check to see if that card has already been picked
                    for (int j = 0; j < i; j++)
                    {
                        if (deck[j] == nextCard)
                            cardAlreadyPicked = true;
                    }
                } while (cardAlreadyPicked);

                deck[i] = nextCard;
            }

            return deck;
        }

        /// <summary>
        /// Play war, working once through a shuffled deck
        /// </summary>
        /// <param name="deck">Shuffled deck</param>
        static void Play(int[] deck)
        {
            int nextCard = 0;   // P
            int compScore = 0;  // A1
            int plyrScore = 0;  // B1

            bool keepPlaying = true;

            while (keepPlaying)
            {
                keepPlaying = TakeTurn(deck, ref nextCard, ref compScore, ref plyrScore);
            }

            if (nextCard > 50)
            {
                Console.Write("\n\n");
                Console.WriteLine($"YOU HAVE RUN OUT OF CARDS.  FINAL SCORE:  YOU-- {plyrScore} ; COMPUTER-- {compScore}");
            }

            Console.WriteLine("THANKS FOR PLAYING.  IT WAS FUN.");
        }

        static bool TakeTurn(int[] deck, ref int nextCard, ref int compScore, ref int plyrScore)
        {
            int plyrCard = deck[nextCard++];     // M1
            int compCard = deck[nextCard++];     // M2

            Console.WriteLine($"\nYOU: {cardData[plyrCard],-9}COMPUTER: {cardData[compCard]}");

            int plyrValue =  (int) (((float)plyrCard + 0.5F) / 4.0F);   // M1
            int compValue = (int) (((float)compCard + 0.5F) / 4.0F);    // M2

            if (compValue > plyrValue)
            {
                compScore++;
                Console.WriteLine($"COMPUTER WINS!!! YOU HAVE {plyrScore}  COMPUTER HAS {compScore}");
            }
            else if (compValue < plyrValue)
            {
                plyrScore++;
                Console.WriteLine($"YOU WIN.  YOU HAVE {plyrScore}  COMPUTER HAS {compScore}");
            }
            else
            {
                Console.WriteLine($"TIE.  NO SCORE CHANGE.");
            }

            bool keepPlaying = false;
            if (nextCard <= 50)
            {
                string cont;
                do
                {
                    Console.Write("DO YOU WANT TO CONTINUE? ");
                    cont = Console.ReadLine().ToLower();

                    if (cont == "yes")
                    {
                        keepPlaying = true;
                    }
                    else if (cont != "no")
                    {
                        Console.Write("YES OR NO, PLEASE.  ");
                    }
                } while ((cont != "yes") && (cont != "no"));
             }

            return keepPlaying;
        }

        //-------------------------------------
        //--- Utility methods for debugging
        //-------------------------------------
        static void DumpDeck(int[] deck)
        {
            foreach (int i in deck)
                Console.Write($"{cardData[i]}, ");
            Console.WriteLine();
        }
    }
}
