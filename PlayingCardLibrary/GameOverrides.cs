using System.Collections.Generic;

namespace PlayingCardLibrary
{
    /*
    Class Notes:
    Each Deck (which means cards in play and can actually be more than one deck) can be created with override parameters that allow the game to specify value and joker rules
    that are specific to the game.

    */

    public class GameOverrides
    {
        public int DeckCount { get; set; }
    }
}
