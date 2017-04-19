using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Problems.Problems50To99
{
    public enum Suit
    {
        None = 0,
        Clubs = 1,
        Hearts = 2,
        Diamonds = 3,
        Spades = 4
    }

    public enum Rank
    {
        None = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    public class Card
    {
        public Rank Rank { get; set; }

        public Suit Suit { get; set; }

        public override bool Equals(object that)
        {
            var thatCard = (Card)that;
            return
            Suit.Equals(thatCard.Suit) &&
            Rank.Equals(thatCard.Rank);
        }
    }
    public enum Ranking
    {
        None = 0,
        HighCard = 3,
        Pair = 5,
        TwoPair = 10,
        ThreeOfAKind = 15,
        Straight = 20,
        Flush = 25,
        FullHouse = 40,
        FourOfAKind = 125,
        StraightFlush = 250,
        RoyalFlush = 2000
    }
    public class Hand
    {
        private readonly List<Card> cards = new List<Card>();

        public IReadOnlyList<Card> Cards
        {
            get { return new ReadOnlyCollection<Card>(cards); }
        }

        public Ranking BestRanking { get; private set; }

        public void AddCard(string cardInfo)
        {
            var suit = cardInfo.Substring(1, 1);
            var rank = cardInfo.Substring(0, 1);

            var card = new Card();

            switch (rank)
            {
                case "A":
                    card.Rank = Rank.Ace;
                    break;
                case "T":
                    card.Rank = Rank.Ten;
                    break;
                case "K":
                    card.Rank = Rank.King;
                    break;
                case "Q":
                    card.Rank = Rank.Queen;
                    break;
                case "J":
                    card.Rank = Rank.Jack;
                    break;
                default:
                    card.Rank = (Rank)int.Parse(rank);
                    break;
            }

            switch (suit)
            {
                case "D":
                    card.Suit = Suit.Diamonds;
                    break;
                case "S":
                    card.Suit = Suit.Spades;
                    break;
                case "C":
                    card.Suit = Suit.Clubs;
                    break;
                case "H":
                    card.Suit = Suit.Hearts;
                    break;
            }

            AddCard(card);
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetScore()
        {
            CalculateBestRanking();
            return 1;
        }

        private void CalculateBestRanking()
        {
            var sc = cards.OrderBy(e => e.Rank).ToList();
            if (IsFlush(sc) && IsStraight(sc))
                if (sc[4].Rank == Rank.Ace) BestRanking = Ranking.RoyalFlush;
                else BestRanking = Ranking.StraightFlush;
            else if (IsThreeOfAKind(sc, 1, 2, 3) && (IsPair(sc, 0, 1) || IsPair(sc, 3, 4)))
                BestRanking = Ranking.FourOfAKind;
            else if (IsPair(sc, 0, 1) && IsThreeOfAKind(sc, 2, 3, 4) || IsPair(sc, 3, 4) && IsThreeOfAKind(sc, 0, 1, 2))
                BestRanking = Ranking.FullHouse;
            else if (IsFlush(sc)) BestRanking = Ranking.Flush;
            else if (IsStraight(sc)) BestRanking = Ranking.Straight;
            else if (IsThreeOfAKind(sc, 0, 1, 2) || IsThreeOfAKind(sc, 1, 2, 3) || IsThreeOfAKind(sc, 2, 3, 4))
                BestRanking = Ranking.ThreeOfAKind;
            else if (IsPair(sc, 0, 1) && IsPair(sc, 2, 3) || IsPair(sc, 0, 1) && IsPair(sc, 3, 4) ||
                     IsPair(sc, 1, 2) && IsPair(sc, 3, 4)) BestRanking = Ranking.TwoPair;
            else if (IsPair(sc, 0, 1) || IsPair(sc, 1, 2) || IsPair(sc, 2, 3) || IsPair(sc, 3, 4))
                BestRanking = Ranking.Pair;
            else
            {
                BestRanking = Ranking.HighCard;
                CalculateHighCard();
            }
        }

        public int CardScore { get; set; }
        public int HighCardSuit { get; set; }

        private void CalculateHighCard()
        {
            var highest = 0;
            Card highCard = null;

            foreach (var c in cards)
            {
                if ((int)c.Rank > highest)
                {
                    highCard = c;
                    highest = (int)c.Rank;
                }
            }
            HighCardSuit = (int)highCard.Suit;
            CardScore = highest;
        }

        private static bool IsThreeOfAKind(IList<Card> c, int index1, int index2, int index3)
        {
            return IsPair(c, index1, index2) && IsPair(c, index2, index3);
        }

        private static bool IsPair(IList<Card> c, int index1, int index2)
        {
            return c[index1].Rank == c[index2].Rank;
        }

        private static bool IsFlush(IList<Card> c)
        {
            return
                c[0].Suit == c[1].Suit &&
                c[1].Suit == c[2].Suit &&
                c[2].Suit == c[3].Suit &&
                c[3].Suit == c[4].Suit;
        }

        private static bool IsStraight(IList<Card> c)
        {
            //var previousCard = (Card) null;
            //If Ace involved look at other cards to determine if High or Low Ace

            if (!HasAce(c))
            {
                return c[0].Rank == c[1].Rank - 1 &&
                                c[1].Rank == c[2].Rank - 1 &&
                                c[2].Rank == c[3].Rank - 1 &&
                                c[3].Rank == c[4].Rank - 1;
            }
            else
            {
                return c[0].Rank == c[1].Rank - 1 &&
                c[1].Rank == c[2].Rank - 1 &&
                c[2].Rank == c[3].Rank - 1 &&
                c[3].Rank == c[4].Rank - 1;

            }

        }

        private static bool HasAce(IList<Card> c)
        {
            foreach (var card in c)
            {
                if (card.Rank == Rank.Ace) return true;
            }
            return false;
        }

        public bool HasAce()
        {
            return HasAce(cards);
        }
    }

    class Problem54 : IProblem
    {
        public int Number => 54;

        public string Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p54.txt";

            var player1Wins = 0;
            var player2Wins = 0;
            var rowOutput = new StringBuilder();



            var data = string.Empty;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (true)
                {
                    var currentLine = reader.ReadLine();
                    if (string.IsNullOrEmpty(currentLine)) break;
                    var cards = currentLine.Split(' ');

                    var player1Hand = new Hand();
                    var player2Hand = new Hand();

                    for (var i = 0; i < cards.Length; i++)
                    {
                        Hand activeHand;
                        activeHand = (i < 5) ? player1Hand : player2Hand;

                        activeHand.AddCard(cards[i]);
                    }
                    player1Hand.GetScore();
                    player2Hand.GetScore();


                    if (player1Hand.BestRanking == player2Hand.BestRanking)
                    {
                        if (player1Hand.CardScore == player2Hand.CardScore)
                        {
                            if (player1Hand.HighCardSuit > player2Hand.HighCardSuit)
                            {
                                player1Wins++;
                            }
                            else
                            {
                                player2Wins++;
                            }
                        }
                        else
                        {

                            foreach(var c in player1Hand.Cards)
                            {

                            }
                            if (player1Hand.CardScore > player2Hand.CardScore)
                            {
                                player1Wins++;
                            }
                            else
                            {
                                player2Wins++;
                            }
                        }
                    }
                    else
                    {
                        if (player1Hand.BestRanking > player2Hand.BestRanking)
                        {
                            player1Wins++;
                        }
                        else
                        {
                            player2Wins++;
                        }
                    }
                }

                return player1Wins.ToString();

            }
        }
    }
}
