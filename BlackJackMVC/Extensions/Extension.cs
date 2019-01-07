using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJackMVC.Extensions {
    public static class Extension {


        public static IList<T> Shuffle<T>(this IList<T> myList) {
            Random _r = new Random();
            IList<T> lijst = new List<T>();

            while (!(myList.Count() == 0)) {
                int rand = _r.Next(0, myList.Count());
                lijst.Add(myList[rand]);
                myList.RemoveAt(rand);
            }

            return lijst;
        }

    }
}
