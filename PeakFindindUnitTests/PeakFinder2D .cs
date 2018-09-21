using System;
using System.Collections.Generic;
using System.Linq;

namespace PeakFinding
{
    /// <summary>
    /// https://courses.csail.mit.edu/6.006/spring11/lectures/lec02.pdf
    /// https://medium.com/@rabin_gaire/algorithmic-thinking-peak-finding-ad6f7415d154
    /// https://medium.com/@rabin_gaire/algorithmic-thinking-peak-finding-ad6f7415d154
    /// </summary>
    public class PeakFinder2D {

        public static (int index, int value) FindGlobalColumnMaxIndex(List<List<int>> list, int column)
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
            return (index, list[index][column]);
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
        public static int FindPeakElement(List<List<int>> problem, int left, int right)
        {
            var j = (left + right) / 2;
            var globalMaxInfo = FindGlobalColumnMaxIndex(problem, j);
            var globalMax = globalMaxInfo.index; // The max number is in the column always give you a 1D peak

            if(IsPeakElement(problem, globalMax, j)) {
                return problem[globalMax][j];
            }
            else if (j > 0 && problem[globalMax][j - 1] > problem[globalMax][j])
            {
                right = j;
                return FindPeakElement(problem, left, right);
            }
            else if (j + 1 < problem[globalMax].Count && problem[globalMax][j + 1] > problem[globalMax][j])
            {
                left = j;
                return FindPeakElement(problem, left, right);
            }

            return problem[globalMax][j];

            //if (
            //    (globalMax - 1 > 0                && problem[globalMax][j] >= problem[globalMax - 1][j]) &&
            //    (globalMax + 1 < problem.Count    && problem[globalMax][j] >= problem[globalMax + 1][j]) &&
            //    (j - 1 > 0                        && problem[globalMax][j] >= problem[globalMax][j - 1])  &&
            //    (j + 1 < problem[globalMax].Count && problem[globalMax][j] >= problem[globalMax][j + 1])
            //    )
            //{
            //    return problem[globalMax][j];
            //}



            // Pick a middle column j = m/2
            // Find global max on column j at (i,j)
            //   - The max number is in the column always give you a 1D peak
            // Compare (i, j-1), (i, j), (i, j+1)
            // Pick left column if (i, j-1) >= (i, j)
            // Pick right column if (i, j+1) >= (i, j)
            // If (i, j)>=(i, j-1) && (i, j)>=(i, j+1) the done (i, j) is 2D Peak

            // Solve the new problem with half the number columns.
            // When you have a single col, find the global max

            // T(n, m) = T(n, m/2) + Teta(n)
        }
    }
}
