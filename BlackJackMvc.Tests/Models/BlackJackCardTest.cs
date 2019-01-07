using BlackJackMVC.Models;
using Xunit;


namespace BlackJackMvc.Tests.Models {

    public class BlackJackCardTest {

        [Fact]
        public void NewBlackJackCard_CreatedCorrectly() {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            Assert.Equal(Suit.Hearts, card.Suit);
            Assert.Equal(FaceValue.Ace, card.FaceValue);
            Assert.False(card.FaceUp);
        }

        [Fact]
        public void TurnCard_CardFaceDown_TurnsCardToFaceUp() {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            Assert.True(card.FaceUp);
        }

        [Fact]
        public void TurnCard_CardFaceUp_TurnsCardToFaceDown() {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            card.TurnCard();
            Assert.False(card.FaceUp);
        }

        [Fact]
        public void Value_CardFaceUp_GivesCorrectValue() {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.King);
            card.TurnCard();
            Assert.True(card.Value == 10);
        }

        [Fact]
        public void Value_CardFaceDown_IsZero() {
           BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
           int val = card.Value;
           Assert.Equal(0, val);
        }
    }
}
