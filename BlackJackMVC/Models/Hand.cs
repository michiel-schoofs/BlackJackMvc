using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlackJackMVC.Models {
    [JsonObject(MemberSerialization.OptIn)]
    public class Hand {
        #region Field
        [JsonProperty]
        private IList<BlackJackCard> _cards;
        #endregion

        #region Properties

        public IEnumerable<BlackJackCard> Cards { get { return _cards; }}
        public int NrOfCards { get => _cards.Count; }
        public int Value { get => CalculateValue(); }
        #endregion

        #region Constructor
        public Hand() {
            _cards = new List<BlackJackCard>();

        }
        #endregion

        #region Methods
        public void AddCard(BlackJackCard blackJackCard) {
            _cards.Add(blackJackCard);
        }

        public void TurnAllCardsFaceUp() {
            foreach (BlackJackCard bjc in Cards) {
                if (!bjc.FaceUp)
                    bjc.TurnCard();
            }
        }

        private int CalculateValue() {
            int val = 0;
            bool ace = false;

            foreach (BlackJackCard bjc in Cards) {
                if (bjc.FaceUp) {
                    val += bjc.Value;
                    if (bjc.FaceValue == FaceValue.Ace)
                        ace = true;
                }
            }

            if (ace && (val + 10) <= 21)
                val += 10;

            return val;
        } 
        #endregion
    }
}
