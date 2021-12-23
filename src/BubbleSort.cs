using System.Collections.Generic;
using src.dynamicArray;

namespace src
{
    public class BubbleSort
    {
        public static void Sort<T>(DynamicArray<T> arr, IComparer<T> comparer)
        {
            var n = arr.Count;
            
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (comparer.Compare(arr[j], arr[j+1]) > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }
    }
}