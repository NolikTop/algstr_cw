using System;
using System.Collections.Generic;

namespace src.graph
{
    public class LexicographicOrderComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;

            var minLen = Math.Min(x.Length, y.Length);
            
            for (var i = 0; i < minLen; ++i)
            {
                var xChar = x[i];
                var yChar = y[i];

                if (xChar > yChar)
                {
                    return 1;
                }
                
                if (xChar < yChar)
                {
                    return -1;
                }
            }

            return x.Length.CompareTo(y.Length); // x.Length > y.Length => x > y
        }
    }
}