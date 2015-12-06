using System;
using System.Collections.Generic;
using CustomExtensions;


namespace PlayingCardLibrary
{
    public abstract class Game
    {
        public List<PlayingCard> GameDeck { get; set; }
        public List<List<PlayingCard>> Hands { get; set; }
        public Game(GameOverrides gameOverrides, DeckOverrides deckOverrides)
        {
            //Game with overrides
            GameDeck = new List<PlayingCard>();
            for (int i = 0; i < gameOverrides.DeckCount; i++)
            {
                GameDeck.AddRange(new Deck(deckOverrides).PlayingCards);
            }
            Hands = new List<List<PlayingCard>>();
        }

        public Game()
        {
            //Default Game
            GameDeck = (new Deck().PlayingCards);
            Hands = new List<List<PlayingCard>>();
        }

        public void Shuffle()
        {
            GameDeck.Shuffle();
        }

        public abstract void Deal(int playerCount);
    }
}
