using System.Collections.Generic;
using PlayingCardLibrary;

namespace Games
{
    public class DefaultGame : Game
    {
        private const int CARDSPERPLAYER = 7;
        public override void Deal(int playerCount)
        {
            for (int i = 0; i < playerCount; i++)
            {
                List<PlayingCard> hand = new List<PlayingCard>();
                hand = GameDeck.GetRange(0, 7);
                Hands.Add(hand);
                GameDeck.RemoveRange(0, 7);
            }
        }
    }
}
