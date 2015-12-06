using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingCardLibrary;
using System.Linq;

namespace PlayingCardLibraryTests
{
    [TestClass]
    public class PlayingCardLibraryTests
    {
        [TestMethod]
        public void CreatePlayingCard()
        {
            PlayingCard playingCard = new PlayingCard(CardTypeEnum.Ace, SuitEnum.Diamond);
            Assert.AreEqual(1, playingCard.CardValue);
            Assert.AreEqual(14, playingCard.CardOrder);
            Assert.AreEqual(14, playingCard.CardPower);
        }

        [TestMethod]
        public void CreateDefaultDeck()
        {
            Deck deck = new Deck();
            Assert.AreEqual(54, deck.PlayingCards.Count);
            Assert.IsTrue(deck.UseJokers);
        }

        [TestMethod]
        public void CreateNoJokerDeck()
        {
            DeckOverrides deckOverrides = new DeckOverrides(false);
            Deck deck = new Deck(deckOverrides);
            Assert.AreEqual(52, deck.PlayingCards.Count);
            Assert.IsTrue(!deck.UseJokers);
        }

        [TestMethod]
        public void CreateGameWithDeckOverrides()
        {
            PlayingCard overrideCard = new PlayingCard(CardTypeEnum.Three, SuitEnum.Spade);
            overrideCard.CardValue = overrideCard.AlternateCardValue = 20;
            DeckOverrides deckOverrides = new DeckOverrides();
            deckOverrides.OverrideCards.Add(overrideCard);
            Deck deck = new Deck(deckOverrides);
            Assert.AreEqual(20, deck.PlayingCards.Where(p => p.CardSuit == SuitEnum.Spade && p.CardType == CardTypeEnum.Three).FirstOrDefault().CardValue);
            Assert.IsTrue(deck.UseJokers);
        }
    }
}
