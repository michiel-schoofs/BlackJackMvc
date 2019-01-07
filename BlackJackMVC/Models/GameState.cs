using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackMVC.Models {
    public enum GameState {
        #region Enum Values
        GameOver = 1,
        PlayerPlays = 2,
        DealerPlays = 3 
        #endregion
    }
}
