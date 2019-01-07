using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackMVC.Models {
    public class BlackJack {
        #region Fields
        public const bool FaceDown = false;
        public const bool FaceUp = true;
        private Deck _deck;
        #endregion

        #region Properties
        public Hand DealerHand { get; set; } = new Hand();
        public Hand PlayerHand { get; set; } = new Hand();
        public GameState GameState { get; private set; } = GameState.PlayerPlays;
        #endregion

        #region Constructors
        public BlackJack() : this(new Deck()) { }

        public BlackJack(Deck deck) {
            _deck = deck;
            Deal();
            AdjustGameState(GameState);
        }
        #endregion

        #region Methods
        private void Deal() {
            for (int i = 0; i < 4; i++) {
                AddCardToHand((i < 2 ? DealerHand : PlayerHand), (i != 1));
            }
        }

        public string GameSummary() {
            if (GameState != GameState.GameOver)
                return null;
            else {
                if (PlayerHand.Value > 21)
                    return "Player burned, dealer wins";
                if (DealerHand.Value > 21)
                    return "Dealer burned, player wins";
                if (PlayerHand.Value == DealerHand.Value)
                    return "Equal, dealer wins";
                if (PlayerHand.Value == 21 || DealerHand.Value == 21)
                    return "BLACKJACK";
                if (PlayerHand.Value < DealerHand.Value)
                    return "Dealer wins";
                return "Player Wins";
            }
        }

        public void GivePlayerAnotherCard() {
            if (GameState != GameState.PlayerPlays)
                throw new InvalidOperationException();
            AddCardToHand(PlayerHand, true);
            AdjustGameState();
        }

        private void LetDealerFinalize() {
            while (GameState != GameState.GameOver) {
                AddCardToHand(DealerHand, true);
                AdjustGameState();
            }
        }

        public void PassToDealer() {
            GameState = GameState.DealerPlays;
            DealerHand.TurnAllCardsFaceUp();
            AdjustGameState();
            LetDealerFinalize();
        }

        private void AddCardToHand(Hand hand, bool faceUp) {
            BlackJackCard bjc = _deck.Draw();
            if (faceUp)
                bjc.TurnCard();
            hand.AddCard(bjc);
        }

        private void AdjustGameState(GameState? gamestate = null) {
            if (PlayerHand.Value == 21 || DealerHand.Value == 21)
                GameState = GameState.GameOver;
            if (GameState == GameState.DealerPlays && DealerHand.Value >= PlayerHand.Value)
                GameState = GameState.GameOver;
            if (PlayerHand.Value > 21 || DealerHand.Value > 21)
                GameState = GameState.GameOver;
        } 
        #endregion
    }
}
