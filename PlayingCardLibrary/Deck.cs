using System.Collections.Generic;
using System.Linq;
using System;

namespace PlayingCardLibrary
{
    public class Deck
    {
        public bool UseJokers { get; set; }
        public List<PlayingCard> PlayingCards { get; set; }

        public Deck(DeckOverrides deckOverrides)
        {

            //Defaults for overrideable properties
            if (deckOverrides == null)
            {
                UseJokers = true;
                PlayingCards = CreatePlayingCards(null);
            }
            else
            {
                UseJokers = deckOverrides.UseJokers;
                PlayingCards = CreatePlayingCards(deckOverrides.OverrideCards);
            }
        }

        public Deck()
        {
            UseJokers = true;
            PlayingCards = CreatePlayingCards(null);
        }

        private List<PlayingCard> CreatePlayingCards(List<PlayingCard> playingCardOverrides)
        {
            List<PlayingCard> returnPlayingCards = new List<PlayingCard>();
            foreach (var suit in Enum.GetValues(typeof(SuitEnum)).Cast<SuitEnum>())
            {
                //just use actual suits
                if (!(suit == SuitEnum.None))
                {
                    foreach (var cardType in Enum.GetValues(typeof(CardTypeEnum)).Cast<CardTypeEnum>())
                    {
                        //jokers should not be built here
                        if (!(cardType == CardTypeEnum.HighJoker || cardType == CardTypeEnum.LowJoker))
                        {
                            var thisPlayingCard = playingCardOverrides == null ? null : playingCardOverrides.Where(p => p.CardSuit == suit && p.CardType == cardType).FirstOrDefault();
                            if (thisPlayingCard == null)
                            {
                                //create it
                                returnPlayingCards.Add(new PlayingCard(cardType, suit));
                            }
                            else
                            {
                                //use the override card
                                returnPlayingCards.Add(thisPlayingCard);
                            }
                        }
                    }
                }
            }
            if (UseJokers)
            {
                var lowJoker = playingCardOverrides == null ? null : playingCardOverrides.Where(p => p.CardSuit == SuitEnum.None && p.CardType == CardTypeEnum.LowJoker).FirstOrDefault();
                var highJoker = playingCardOverrides == null ? null : playingCardOverrides.Where(p => p.CardSuit == SuitEnum.None && p.CardType == CardTypeEnum.HighJoker).FirstOrDefault();

                returnPlayingCards.Add(lowJoker == null? new PlayingCard(CardTypeEnum.LowJoker, SuitEnum.None):lowJoker);
                returnPlayingCards.Add(highJoker == null ? new PlayingCard(CardTypeEnum.HighJoker, SuitEnum.None) : highJoker);
            }

            return returnPlayingCards;
        }
    }
}
