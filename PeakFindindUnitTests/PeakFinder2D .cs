using System;
using System.Collections.Generic;
using System.Linq;

namespace PeakFinding
{
    /// <summary>
    /// https://courses.csail.mit.edu/6.006/spring11/lectures/lec02.pdf
    /// </summary>
    public class PeakFinder2D {

        public static int FindGlobalMaxIndex(List<List<int>> list, int column)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (max < list[i][column])
                {
                    max = list[i][column];
                    index = i;
                }
            }
            return index;
        }

        public static bool IsPeakElement(List<List<int>> list, int xIndex, int yIndex)
        {
            var row = list[yIndex];
            var cell = row[xIndex];
            var isHorizontalPeakElement = PeakFinder.IsPeakElement(row, xIndex);
            if(isHorizontalPeakElement)
            {
                if (yIndex - 1 < 0) // No above value
                {
                    var belowValue = list[yIndex + 1][xIndex];
                    return (cell >= belowValue);
                }
                else if(yIndex + 1 >= list.Count) // No above value
                {
                    var aboveValue = list[yIndex - 1][xIndex];
                    return (cell >= aboveValue);
                }
                else
                {
                    var aboveValue = list[yIndex - 1][xIndex];
                    var belowValue = list[yIndex + 1][xIndex];
                    return (cell >= aboveValue) && (cell >= belowValue);
                }
            }
            else return false;
        }
        public static int FindPeakElement(List<List<int>> list, int xIndex, int yIndex)
        {
            // Pick a middle column j = m/2
            // Find global max on column j at (i,j)
            // Compare (i, j-1), (i, j), (i, j+1)
            // Pick left column if (i, j-1) >= (i, j)
            // Pick right column if (i, j+1) >= (i, j)
            // If (i, j)>=(i, j-1) && (i, j)>=(i, j+1) the done (i, j) is 2D Peak

            // Solve the new problem with half the number columns.
            // When you have a single col, find the global max

            // T(n, m) = T(n, m/2) + Teta(n)
            return 0;
        }
    }
}
