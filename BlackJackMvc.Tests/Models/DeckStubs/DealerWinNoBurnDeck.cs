using System.Collections.Generic;
using BlackJackMVC.Models;

namespace BlackJackMvc.Tests.Models.DeckStubs {
    public class DealerWinNoBurnDeck : Deck {

        public DealerWinNoBurnDeck() {
            _cards = new List<BlackJackCard>
            {
                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Five),
            
                //player
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),

                //dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Three),
            };
        }
    }
}
