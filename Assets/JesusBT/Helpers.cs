using System;
using System.Collections.Generic;

namespace JHFBehaviorTree
{
    public class Helpers
    {
        public static void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = 0; i < n; i++)
            {
                // Randomly pick an index from 0 to n-1
                int r = i + random.Next(n - i);

                // Swap the element at i with the element at the random index
                T temp = list[i];
                list[i] = list[r];
                list[r] = temp;
            }
        }
    }
}
