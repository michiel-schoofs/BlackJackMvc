using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackMVC.Models {
    public class BlackJackCard:Card {
        #region Properties
        public bool FaceUp { get; set; } = false;
        public int Value {
            get {
                if (FaceUp) {
                    int val = (int)base.FaceValue;
                    return (val > 10 ? 10 : val);
                }
                return 0;
            }
        } 
        #endregion

        #region Constructor
        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue) { } 
        #endregion

        #region Methods
        public void TurnCard() {
            FaceUp = !FaceUp;
        }

        public override string ToString() {
            return $"{Suit}-{FaceValue}";
        } 
        #endregion
    }
}
