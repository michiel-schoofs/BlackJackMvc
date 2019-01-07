using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackMVC.Models {
    public class Deck {
        #region Fields
        private Random _random;
        protected IList<BlackJackCard> _cards;
        #endregion

        #region Constructor
        public Deck() {
            _cards = new List<BlackJackCard>();
            _random = new Random();

            foreach (Suit s in Enum.GetValues(typeof(Suit))) {
                foreach (FaceValue f in Enum.GetValues(typeof(FaceValue))) {
                    _cards.Add(new BlackJackCard(s, f));
                }
            }

            Shuffle();
        }
        #endregion

        #region Methods
        public BlackJackCard Draw() {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Deck is empty");

            BlackJackCard card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        private void Shuffle() {
            List<BlackJackCard> shuffled = new List<BlackJackCard>();
            int rand;

            while (_cards.Count != 0) {
                rand = _random.Next(0, _cards.Count);
                shuffled.Add(_cards[rand]);
                _cards.RemoveAt(rand);
            }

            _cards = shuffled;
        } 
        #endregion
    }
}
