using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeakFindindUnitTests
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
            var index = ((last-start) / 2) + start; // Start in the middle

            if(IsPeakElement(list, index))
                return index;

            // if we found a greater number on right, we expect to find one Peak element on the right side
            if(list[index] < list[index+1])
                return FindPeakElement(list, index+1, last);
            // if we found a greater number on the left, we expect to find one Peak element on the left side
            else if(list[index] < list[index-1])
                return FindPeakElement(list, 0, index-1);

            throw new ArgumentException();
        }
    }

    [TestClass]
    public class UnitTePeakFinderUnitTests
    {
        List<int> TestList0 = new List<int>() { 1, 3, 4, 3, 5, 1, 3 };

         [TestMethod]
        public void FindPeakElement_IsPeakElementAtIndex()
        {
            var l = new List<int> { 1, 3, 2 }; // Peak is 3[1]
            Assert.AreEqual(1, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 3, 2 }; // Peak is 3[0]
            Assert.AreEqual(0, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 2, 3 }; // Peak is 3[0]
            Assert.AreEqual(1, PeakFinder.FindPeakElement(l, 1, l.Count-1));
        }

        [TestMethod]
        public void FindPeakElement_OnTheLeft()
        {
            var l = new List<int> { 1, 4, 3, 2, 1 };// Peak is 4[1]
            Assert.AreEqual(1, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 1, 5, 4, 3, 2, 1 };// Peak is 5[1]
            Assert.AreEqual(1, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 5, 4, 3, 2, 1 };// Peak is 5[0]
            Assert.AreEqual(0, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 1, 6, 5, 4, 3, 2, 1 };// Peak is 6[1]
            Assert.AreEqual(1, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 6, 5, 4, 3, 2, 1 };// Peak is 6[0]
            Assert.AreEqual(0, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 1, 7, 6, 5, 4, 3, 2, 1 };// Peak is 7[1]
            Assert.AreEqual(1, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 7, 6, 5, 4, 3, 2, 1 };// Peak is 7[0]
            Assert.AreEqual(0, PeakFinder.FindPeakElement(l, 0, l.Count-1));
        }

         [TestMethod]
        public void FindPeakElement_OnTheRight()
        {
            var l = new List<int> { 1, 2, 3, 4, 1 };// Peak is 4[3]
            Assert.AreEqual(3, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 1, 2, 3, 4, 5, 1 };// Peak is 5[4]
            Assert.AreEqual(4, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 1, 2, 3, 4, 5, 6, 1 };// Peak is 6[5]
            Assert.AreEqual(5, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> { 1, 2, 3, 4, 5, 6, 7 };// Peak is 7[6]
            Assert.AreEqual(6, PeakFinder.FindPeakElement(l, 0, l.Count-1));

            l = new List<int> {1, 2, 6, 5, 3, 7, 4};// Peak is 2[6]
            Assert.AreEqual(2, PeakFinder.FindPeakElement(l, 0, l.Count-1));
        }

        [TestMethod]
        public void IsPeakElement_WithinBoundary()
        {
            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 1, 3, 2 }, 1));
            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 1, 1, 3, 2, 2 }, 2));

            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 3, 3, 3 }, 1));
            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 1, 3, 3, 3, 2 }, 2));

            Assert.IsFalse(PeakFinder.IsPeakElement(new List<int> { 1, 0, 2 }, 1));
            Assert.IsFalse(PeakFinder.IsPeakElement(new List<int> { 1, 1, 0, 2, 2 }, 2));
        }
        [TestMethod]
        public void IsPeakElement_AtBoundaryLimitOnLeft()
        {
            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 3, 2 }, 0));
            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 3, 2, 1, 0 }, 0));

            Assert.IsFalse(PeakFinder.IsPeakElement(new List<int> { 1, 2 }, 0));
            Assert.IsFalse(PeakFinder.IsPeakElement(new List<int> { 1, 2, 1, 0 }, 0));
        }
        [TestMethod]
        public void IsPeakElement_AtBoundaryLimitOnRight()
        {
            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 3, 2, 3}, 2));
            Assert.IsTrue(PeakFinder.IsPeakElement(new List<int> { 2, 3 }, 1));

            Assert.IsFalse(PeakFinder.IsPeakElement(new List<int> { 3, 2, 1}, 2));
            Assert.IsFalse(PeakFinder.IsPeakElement(new List<int> { 2, 1 }, 1));
        }      
    }
}
