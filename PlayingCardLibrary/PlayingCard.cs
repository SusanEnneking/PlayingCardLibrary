using System;

namespace PlayingCardLibrary
{
    /*
        Class Notes:
        Playing card has a main value which is the normal value of the card and an alternate value for games
        such as 21 that allow aces to be 11 and 1 or Pitch where all of the cards are worth zero or 1 except
        the three, which is worth three points.

        CardOrder is in games like poker to help determine "straight" hands.  I am not sure this makes it
        that much easier to check for a straight, but it seemed like it would make that type of thing easier and it's not too
        hard to set as the card is being created.

        CardPower (maybe this should be named cardRank) is a double so that jokers can be inserted wherever they need to be.  
        For example, in pitch, Jokers are between the 10 and the Jack.  So, they can be given powers of 10.01 and 10.02 to 
        accomodate this situation.

        CardValue is the usual value of the card.  In 21, Jacks, Queens and Kings are worth 10 points.  In pitch, though,
        they are sometimes worth just 1 point and the three is worth three points.

        AlternateCardValue is the alternate value of the card.  In 21, the Ace can be worth 1 or 11.

    */

    public class PlayingCard
    {
        //Constants
        private const int MAXCARDPOWER = 16;
        private const int MAXCARDORDER = 54; 

        //Private properties
        private int cardOrder;
        private double cardPower;

        //Public properties
        public CardTypeEnum CardType { get; set; }
        public int CardValue { get; set; }


        public double CardPower
        {
            get
            {
                return this.cardPower;
            }
            set
            {
                if (value > 0 && value <= MAXCARDPOWER)
                {
                    this.cardPower = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid value. Value must be between 0 and " + MAXCARDPOWER.ToString());
                }
            }
        }
        public int AlternateCardValue { get; set; }
        public SuitEnum CardSuit { get; set; }
        public int CardOrder
        {
            get
            {
                return this.cardOrder;
            }
        }

        public PlayingCard(CardTypeEnum cardType, SuitEnum suit)
        {
            this.CardSuit = suit;
            this.CardType = cardType;
            if (suit == SuitEnum.None)
            {
                SetJokerDetails(cardType);
            }
            else
            {
                SetCardDetails(cardType, suit);
            }

        }

        private void SetJokerDetails(CardTypeEnum cardType)
        {
            if (cardType == CardTypeEnum.LowJoker)
            {
                this.cardOrder = 53;
                this.cardPower = 15.0;
            }
            else
            {
                this.cardOrder = 54;
                this.cardPower = 16.0;
            }
        }

        private void SetCardDetails(CardTypeEnum cardType, SuitEnum suit)
        {
            //All face cards get a value of 10, otherwise the card gets its numerical value
            this.CardValue = (int)cardType > 10? 10: (int)cardType;
            this.AlternateCardValue = this.CardValue;

            //Aces default to taking everything except Jokers
            this.cardPower = (int)cardType == 1? 14 : (int) cardType;

            //CardOrder is computed based on card type and suit
            this.cardOrder = (int)cardType + ((int)suit - 1) * 13;
        }
    }
}
