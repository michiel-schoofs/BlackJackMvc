using System;
using BlackJackMVC.Models;
using Xunit;

namespace BlackJackMvc.Tests.Models {
    public class DeckTest {
        private Deck _deck;

        public DeckTest() {
            _deck = new Deck();
        }

        [Fact]
        public void Method_Draw_Gives_BlackJackCard() {
            Assert.IsType<BlackJackCard>(_deck.Draw());
        }
        
        [Fact]
        public void New_Deck_Has_52_Cards() {
            for(int i = 0; i < 52; i++) {
                BlackJackCard bjc = _deck.Draw();
                Assert.False(bjc.FaceUp);
            }
            Assert.Throws<InvalidOperationException>(() => _deck.Draw());
        }
    }
}
