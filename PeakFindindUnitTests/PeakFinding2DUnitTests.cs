using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeakFinding;

namespace PeakFindindUnitTests
{
    [TestClass]
    public class UnitTePeakFinder2DUnitTests
    {
        private List<List<int>> GetMatrix2()
        {
            var l = new List<List<int>>();
            // 2D Peak is 21[3,3]
                             //   0    1   2   3
            l.Add(new List<int> { 10, 08, 10, 10 }); // 0
            l.Add(new List<int> { 14, 13, 12, 11 }); // 1
            l.Add(new List<int> { 15, 09, 11, 21 }); // 2
            l.Add(new List<int> { 16, 17, 19, 20 }); // 3
            return l;
        }

        private List<List<int>> GetMatrix0()
        {
            var l = new List<List<int>>();
                              //  0  1  2  3  4  5  6
            l.Add(new List<int> { 9, 3, 5, 2, 4, 9, 8 }); // 0
            l.Add(new List<int> { 7, 2, 5, 1, 4, 0, 3 }); // 1
            l.Add(new List<int> { 9, 8, 9, 3, 2, 4, 8 }); // 2
            l.Add(new List<int> { 7, 6, 3 ,1, 3, 2, 3 }); // 3
            l.Add(new List<int> { 9, 0, 6, 0, 4, 6, 4 }); // 4
            l.Add(new List<int> { 8, 9, 8, 0, 5, 3, 0 }); // 5
            l.Add(new List<int> { 2, 1, 2, 1, 1, 1, 1 }); // 6
            return l;
        }

        private List<List<int>> GetMatrix1()
        {
            var l = new List<List<int>>();
                             //  0  1  2  3  4  5  6
            l.Add(new List<int> { 0, 0, 9, 0, 0, 0, 0 }); // 0
            l.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0 }); // 1
            l.Add(new List<int> { 0, 1, 0, 0, 0, 0, 0 }); // 2
            l.Add(new List<int> { 0, 2, 0, 0, 0, 0, 0 }); // 3
            l.Add(new List<int> { 0, 3, 0, 0, 0, 0, 0 }); // 4
            l.Add(new List<int> { 0, 5, 0, 0, 0, 0, 0 }); // 5
            l.Add(new List<int> { 0, 4, 7, 0, 0, 0, 0 }); // 6
            return l;
        }

        /*        
            14 13 12 11
            15 09 11 17
            16 17 19 20
        */

        [TestMethod]
        public void IsPeakElement_BoundaryCases()
        {
            var matrix = GetMatrix0();
            // The value 9 in position [0,0] is a peak
            Assert.AreEqual(true, PeakFinder2D.IsPeakElement(matrix, 0, 0));
        }

        [TestMethod]
        public void IsPeakElement_NoBoundaryCases()
        {
            var matrix = GetMatrix0();
            // The value 9 in position [2,2] is a peak
            Assert.AreEqual(true, PeakFinder2D.IsPeakElement(matrix, 2, 2));

            // The value 6 in position [5,4] is a peak
            Assert.AreEqual(true, PeakFinder2D.IsPeakElement(matrix, 5, 4));

            // The value 9 in position [1, 5] is a peak
            Assert.AreEqual(true, PeakFinder2D.IsPeakElement(matrix, 1, 5));
        }

        [TestMethod]
        public void FindGlobalMaxIndex()
        {
            var matrix = GetMatrix1();

            Assert.AreEqual(0, PeakFinder2D.FindGlobalColumnMaxIndex(matrix, 0).value);
            Assert.AreEqual(5, PeakFinder2D.FindGlobalColumnMaxIndex(matrix, 1).value);
            Assert.AreEqual(9, PeakFinder2D.FindGlobalColumnMaxIndex(matrix, 2).value);
            Assert.AreEqual(0, PeakFinder2D.FindGlobalColumnMaxIndex(matrix, 3).value);
            Assert.AreEqual(0, PeakFinder2D.FindGlobalColumnMaxIndex(matrix, 4).value);
            Assert.AreEqual(0, PeakFinder2D.FindGlobalColumnMaxIndex(matrix, 5).value);
            Assert.AreEqual(0, PeakFinder2D.FindGlobalColumnMaxIndex(matrix, 6).value);
        }
        [TestMethod]
        public void FindPeakElement()
        {
            var matrix = GetMatrix2();
            Assert.AreEqual(21, PeakFinder2D.FindPeakElement(matrix, 0, matrix.Count - 1));
        }
    }
}
