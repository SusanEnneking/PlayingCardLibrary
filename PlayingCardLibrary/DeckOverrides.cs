using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardLibrary
{
    public class DeckOverrides
    {
        public bool UseJokers { get; set; }
        public List<PlayingCard> OverrideCards { get; set; }

        public DeckOverrides()
        {
            UseJokers = true;
            OverrideCards = new List<PlayingCard>();
        }

        //seemed like a convenient "other" constructor, but maybe not
        public DeckOverrides(bool useJokers)
        {
            UseJokers = useJokers;
            OverrideCards = new List<PlayingCard>();
        }
    }
}
