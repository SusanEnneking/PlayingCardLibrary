using System.Collections.Generic;
using System;

namespace CustomExtensions
{
    public static class ListExtension
    {
        //following shuffle code taken From http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}