using Newtonsoft.Json;

namespace BlackJackMVC.Models {
    [JsonObject(MemberSerialization.OptIn)]
    public class Card {
        #region Properties
        [JsonProperty]
        public FaceValue FaceValue { get; private set; }
        [JsonProperty]
        public Suit Suit { get; private set; } 
        #endregion

        #region Constructor
        public Card(Suit suit, FaceValue faceValue) {
            FaceValue = faceValue;
            Suit = suit;
        } 
        #endregion
    }
}
