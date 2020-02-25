using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    enum HandRank : int
    {
        HighCard = 1,
        OnePair = 2,
        TwoPairs = 3,
        ThreeOfAKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfAKind = 8,
        StraightFlush = 9,
        RoyalFlush = 10
    }

    class Program
    {
        static void Main(string[] args)
        {
            int player1WinCount = 0;
            string deal;

            System.IO.StreamReader file = new System.IO.StreamReader(@"poker.txt");  

            while((deal = file.ReadLine()) != null)  
            {   
                Hand player1Hand = new Hand(deal.Substring(0,15));
                Hand player2Hand = new Hand(deal.Substring(14, 15));
                if (player1Hand > player2Hand)
                {
                    Console.WriteLine("Player 1 wins hand: P1 {0} {1} beats P2 {2} {3}", player1Hand.GetHandRanking(), player1Hand.ToString(), player2Hand.GetHandRanking(), player2Hand.ToString());
                    player1WinCount++;
                }
                else
                {
                    Console.WriteLine("Player 2 wins hand: P1 {0} {1} loses to P2 {2} {3}", player1Hand.GetHandRanking(), player1Hand.ToString(), player2Hand.GetHandRanking(), player2Hand.ToString());
                }
                    
            }  
  
            file.Close();

            Console.WriteLine("Player 1 Win Count: {0}", player1WinCount);
        }
    }

    class Card : IComparable
    {
        public char Suit;
        public int Value;

        public Card(int val, char suit)
        {
            this.Value = val;
            this.Suit = suit;
        }

        public int CompareTo(object obj)
        {
            Card c = (Card)obj;
            
            if (this.Value > c.Value)
                return 1;

            if (this.Value < c.Value)
                return -1;

            else
                return 0;
        }

        public static bool operator >  (Card operand1, Card operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }
        
        // Define the is less than operator.
        public static bool operator <  (Card operand1, Card operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        public static int GetCardValue(string str)
        {
            switch(str)
            {
                case "A": 
                    return 14;
                case "K":
                    return 13;
                case "Q":
                    return 12;
                case "J": 
                    return 11;
                case "T":
                    return 10;
                default:
                    return int.Parse(str);
            }
        }
    }

    class Hand  : IComparable
    {
        public List<Card> cards;

        public Hand(string strs)
        {
            cards = new List<Card>();
            
            foreach (string str in strs.Split(" "))
            {                
                if (!string.IsNullOrWhiteSpace(str))
                {
                    int val = Card.GetCardValue(str.Substring(0,1));
                    char suit = str.Substring(1,1).First();
                    cards.Add(new Card(val, suit));
                }
            }
        }

        public string ToString()
        {
            string handString = "Hand: ";
            foreach (Card c in cards)
            {
                handString += c.Value.ToString() + c.Suit + " ";
            }
            return handString;
        }

        public int CompareTo(object obj)
        {
            Hand h = (Hand)obj;

            var thisRank = this.GetHandRanking();
            var thatRank = h.GetHandRanking();
            
            if (thisRank > thatRank)
            {
                return 1;
            }
            else if (thisRank < thatRank)
            {
                return -1;
            }
            else
            {
                switch (thisRank)
                {
                    case HandRank.FourOfAKind:
                    {
                        return CompareFullHand(h, 4);
                    }
                    case HandRank.FullHouse:
                    {
                        return CompareFullHand(h, 3);
                    }
                    case HandRank.Flush:
                    {
                        return CompareFlush(h);
                    }
                    case HandRank.Straight:
                    {
                        return CompareStraight(h);
                    }
                    case HandRank.ThreeOfAKind:
                    {
                        return CompareThreeOfAKind(h);
                    }
                    case HandRank.TwoPairs:
                    {
                        return CompareTwoPairs(h);
                    }
                    case HandRank.OnePair:
                    {
                        return CompareOnePair(h);
                    }
                    case HandRank.HighCard:
                    {
                        return CompareHighCard(h);
                    }
                    default:
                    {
                        throw new Exception("Huh?");
                    }
                }
            }

        }

        // Define the is greater than operator.
        public static bool operator >  (Hand operand1, Hand operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }
        
        // Define the is less than operator.
        public static bool operator <  (Hand operand1, Hand operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=  (Hand operand1, Hand operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=  (Hand operand1, Hand operand2)
        {
        return operand1.CompareTo(operand2) <= 0;
        }

        private int CompareFlush(Hand h)
        {
            int[] thisVals = cards.OrderByDescending(c => c).Select(x => x.Value).ToArray();
            int[] thatVals = h.cards.OrderByDescending(c => c).Select(x => x.Value).ToArray();

            for (int i = 0; i < 5; i++)
            {
                if (thisVals[i] > thatVals[i])
                {
                    return 1;
                }
                else if (thisVals[i] < thatVals[i])
                {
                    return -1;
                }
            }

            return 0;
        }

        private int CompareStraight(Hand h)
        {
            if (cards.Select(x => x.Value).Max() > h.cards.Select(x => x.Value).Max())
            {
                return 1;
            }
            else if (cards.Select(x => x.Value).Max() < h.cards.Select(x => x.Value).Max())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareTwoPairs(Hand h)
        {
            int thisPair1Val = 0;
            int thisPair2Val = 0;
            int thisOtherVal = 0;

            int thatPair1Val = 0;
            int thatPair2Val = 0;
            int thatOtherVal = 0;


            foreach (Card card in cards)
            {
                if (cards.Where(x => x.Value == card.Value).Count() == 2)
                {
                    thisPair1Val = card.Value;
                    var remaining = cards.Where(x => x.Value != card.Value);
                    foreach (Card rem in remaining)
                    {
                        if (remaining.Where(x => x.Value == rem.Value).Count() == 2)
                        {
                            thisPair2Val = rem.Value;
                            thisOtherVal = remaining.Select(x => x.Value).Where(x => x != rem.Value).First();
                        }
                    }
                }
            }

            foreach (Card card in h.cards)
            {
                if (h.cards.Where(x => x.Value == card.Value).Count() == 2)
                {
                    thatPair1Val = card.Value;
                    var remaining = h.cards.Where(x => x.Value != card.Value);
                    foreach (Card rem in remaining)
                    {
                        if (remaining.Where(x => x.Value == rem.Value).Count() == 2)
                        {
                            thatPair2Val = rem.Value;
                            thatOtherVal = remaining.Select(x => x.Value).Where(x => x != rem.Value).First();
                        }
                    }
                }
            }
            
            if (Math.Max(thisPair1Val, thisPair2Val) > Math.Max(thatPair1Val, thatPair2Val))
            {
                return 1;
            }
            else if (Math.Max(thisPair1Val, thisPair2Val) < Math.Max(thatPair1Val, thatPair2Val))
            {
                return -1;
            }
            else if (Math.Min(thisPair1Val, thisPair2Val) > Math.Min(thatPair1Val, thatPair2Val))
            {
                return 1;
            }
            else if (Math.Min(thisPair1Val, thisPair2Val) < Math.Min(thatPair1Val, thatPair2Val))
            {
                return -1;
            }
            else if (thisOtherVal > thatOtherVal)
            {
                return 1;
            }
            else if (thisOtherVal < thatOtherVal)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        private int CompareHighCard(Hand h)
        {
            var thisCardsArr = cards.OrderByDescending(x => x.Value).ToArray();
            var thatCardsArr = h.cards.OrderByDescending(x => x.Value).ToArray();

            for (int i = 0; i < 5; i++)
            {
                if (thisCardsArr[i].Value > thatCardsArr[i].Value)
                {
                    return 1;
                }

                else if (thisCardsArr[i].Value < thatCardsArr[i].Value)
                {
                    return -1;
                }
            }
            return 0;
        }
        
        private int CompareOnePair(Hand h)
        {
            int thisPairVal = 0;
            int thisHighVal = 0;
            int thisMidVal = 0;
            int thisLowVal = 0;

            int thatPairVal = 0;
            int thatHighVal = 0;
            int thatMidVal = 0;
            int thatLowVal = 0;


            foreach (Card card in cards)
            {
                if (cards.Where(x => x.Value == card.Value).Count() == 2)
                {
                    thisPairVal = card.Value;
                    var remaining = cards.Where(x => x.Value != card.Value).Select(x => x.Value);

                    thisHighVal = remaining.Max();
                    thisLowVal = remaining.Min();
                    thisMidVal = remaining.First(x => x != thisHighVal && x != thisLowVal);
                }
            }

            foreach (Card card in h.cards)
            {
                if (h.cards.Where(x => x.Value == card.Value).Count() == 2)
                {
                    thatPairVal = card.Value;
                    var remaining = h.cards.Where(x => x.Value != card.Value).Select(x => x.Value);

                    thatHighVal = remaining.Max();
                    thatLowVal = remaining.Min();
                    thatMidVal = remaining.First(x => x != thisHighVal && x != thisLowVal);
                }
            }

            if (thisPairVal > thatPairVal)
            {
                return 1;
            }
            else if (thisPairVal < thatPairVal)
            {
                return -1;
            }
            else if (thisHighVal > thatHighVal)
            {
                return 1;
            }
            else if (thisHighVal < thatHighVal)
            {
                return -1;
            }
            else if (thisMidVal > thatMidVal)
            {
                return 1;
            }
            else if (thisMidVal < thatMidVal)
            {
                return -1;
            }
            else if (thisLowVal > thatLowVal)
            {
                return 1;
            }
            else if (thisLowVal < thatLowVal)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareThreeOfAKind(Hand h)
        {
            int thisMajorVal = 0;
            int thisHighVal = 0;
            int thisLowVal = 0;

            int thatMajorVal = 0;
            int thatHighVal = 0;
            int thatLowVal = 0;

            foreach (Card card in cards)
            {
                if (cards.Where(x => x.Value == card.Value).Count() == 3)
                {
                    thisMajorVal = card.Value;
                    var remaining = cards.Where(x => x.Value != card.Value).Select(x => x.Value);
                    thisHighVal = remaining.Max();
                    thisLowVal = remaining.Min();
                }
            }

            foreach (Card card in h.cards)
            {
                if (h.cards.Where(x => x.Value == card.Value).Count() == 3)
                {
                    thatMajorVal = card.Value;
                    var remaining = h.cards.Where(x => x.Value != card.Value).Select(x => x.Value);
                    thatHighVal = remaining.Max();
                    thatLowVal = remaining.Min();
                }
            }

            if (thisMajorVal > thatMajorVal)
            {
                return 1;
            }
            else if (thisMajorVal < thatMajorVal)
            {
                return -1;
            }
            else if (thisHighVal > thatHighVal)
            {
                return 1;
            }
            else if (thisHighVal < thatHighVal)
            {
                return -1;
            }
            else if (thisLowVal > thatLowVal)
            {
                return 1;
            }
            else if (thisLowVal < thatLowVal)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareFullHand(Hand h, int majorCount)
        {
            int thisMajorVal = 0;
            int thisMinorVal = 0;

            int thatMajorVal = 0;
            int thatMinorVal = 0;

            foreach (Card card in cards)
            {
                if (cards.Where(x => x.Value == card.Value).Count() != majorCount)
                {
                    thisMinorVal = card.Value;
                }

                if (cards.Where(x => x.Value == card.Value).Count() == majorCount)
                {
                    thisMajorVal = card.Value;
                }
            }

            foreach (Card card in h.cards)
            {
                if (h.cards.Where(x => x.Value == card.Value).Count() != majorCount)
                {
                    thatMinorVal = card.Value;
                }

                if (h.cards.Where(x => x.Value == card.Value).Count() == majorCount)
                {
                    thatMajorVal = card.Value;
                }
            }

            if (thisMajorVal > thatMajorVal)
            {
                return 1;
            }
            else if (thisMajorVal < thatMajorVal)
            {
                return -1;
            }
            else if (thisMinorVal > thatMinorVal)
            {
                return 1;
            }
            else if (thisMinorVal < thatMinorVal)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public HandRank GetHandRanking()
        {
            for (int i = 2; i < 11; i++) 
            {
                var isStraightVal = IsStraight(cards);
                if (isStraightVal != -1 && IsFlush(cards))
                {
                    if (isStraightVal == 10)
                        return HandRank.RoyalFlush; //Royal Flush
                    else
                        return HandRank.StraightFlush; //Straight Flush
                }
            }

            foreach (Card card in cards)
            {
                if (cards.Where(x => x.Value == card.Value).Count() == 4)
                {
                    return HandRank.FourOfAKind; //4 of a kind
                }

                if (cards.Where(x => x.Value == card.Value).Count() == 3)
                {
                    var remaining = cards.Where(x => x.Value != card.Value).Select(x => x.Value);
                    if (remaining.First() == remaining.Last())
                    {
                        return HandRank.FullHouse; //Full house
                    }
                }
            }

            if (IsFlush(cards))
            {
                return HandRank.Flush; //flush
            }

            if (IsStraight(cards) != -1)
            {
                return HandRank.Straight; //straight
            }

            foreach (Card card in cards)
            {
                if (cards.Where(x => x.Value == card.Value).Count() == 3)
                {
                    return HandRank.ThreeOfAKind; //3 of a kind
                }
            }

            foreach (Card card in cards)
            {
                if (cards.Where(x => x.Value == card.Value).Count() == 2)
                {
                    var remaining = cards.Where(x => x.Value != card.Value);
                    foreach (Card rem in remaining)
                    {
                        if (remaining.Where(x => x.Value == rem.Value).Count() == 2)
                        {
                            return HandRank.TwoPairs; //2 pair
                        }
                    }

                    return HandRank.OnePair;
                }
            }    

            return HandRank.HighCard;
        }

        static bool IsFlush(List<Card> cards)
        {
            return cards.Where(x => x.Suit == cards.First().Suit).Count() == 5;
        }

        static int IsStraight(List<Card> cards)
        {
            var vals = cards.Select(x=>x.Value);
        
            for (int i = 2; i < 11; i++) 
            {
                var range = Enumerable.Range(i,5);

                if (!vals.Except(range).Any() && !range.Except(vals).Any())
                {
                    return i;
                }
                
            }
            return -1;
        }

    }



    
}
