using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackMVC.Models {
    public class Card {
        #region Properties
        public FaceValue FaceValue { get; private set; }
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
