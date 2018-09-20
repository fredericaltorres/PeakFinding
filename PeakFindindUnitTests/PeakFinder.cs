using System;
using System.Collections.Generic;
using System.Linq;

namespace PeakFinding
{
    public class PeakFinder {
        public static bool IsPeakElement(List<int> list, int index)
        {
            if(index == 0) // No left boundary
                return (list[index] >= list[index+1]);
            else if(index == list.Count-1) // No right boundary
                return (list[index] >= list[index-1]);
            else
                return (list[index] >= list[index-1]) && (list[index] >= list[index+1]);
        }
        public static int FindPeakElement(List<int> list, int start, int last)
        {
            var index = ((last - start) / 2) + start; // Start in the middle

            if(IsPeakElement(list, index))
                return index;

            // if we found a greater number on right, we expect to find one Peak element on the right side
            if(list[index] < list[index + 1])
                return FindPeakElement(list, index + 1, last);
            // if we found a greater number on the left, we expect to find one Peak element on the left side
            else if(list[index] < list[index - 1])
                return FindPeakElement(list, 0, index - 1);

            throw new ArgumentException();
        }
    }

}