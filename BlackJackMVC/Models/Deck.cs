﻿using System;
using System.Collections.Generic;
using BlackJackMVC.Extensions;
using Newtonsoft.Json;

namespace BlackJackMVC.Models {
    [JsonObject(MemberSerialization.OptIn)]
    public class Deck {
        #region Fields
        private Random _random;
        [JsonProperty]
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

            _cards = _cards.Shuffle();
        }

        [JsonConstructor]
        public Deck(bool test) {

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

        #endregion
    }
}
