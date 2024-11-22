using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp6;
namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListLength0()
        {
            List<int> L = new List<int>();
            Assert.AreEqual(0, L.Length);
        }
        [TestMethod]
        public void TestListLengthMas()
        {
            List<int> L = new List<int>(1,2,3,4,5);
            Assert.AreEqual(5, L.Length);
        }
        [TestMethod]
        public void TestListLength()
        {
            List<int> L = new List<int>(5);
            Assert.AreEqual(5, L.Length);
        }
        [TestMethod]
        public void TestRemove2Cutable()
        {
            List<int> L = new List<int>(1, 2, 3, 4, 5);
            L.Remove2Cutable();
            Assert.AreEqual(L.Length,3);
        }
        [TestMethod]
        public void TestTwoSideLinkedListLength0()
        {
            TwoSideLinkedList<int> L = new TwoSideLinkedList<int>();
            Assert.AreEqual(0, L.Length);
        }
        [TestMethod]
        public void TestTwoSideLinkedListLengthMas()
        {
            TwoSideLinkedList<int> L = new TwoSideLinkedList<int>(1, 2, 3, 4, 5);
            Assert.AreEqual(5, L.Length);
        }
        [TestMethod]
        public void TestTwoSideLinkedListLength()
        {
            TwoSideLinkedList<int> L = new TwoSideLinkedList<int>(5);
            Assert.AreEqual(5, L.Length);
        }
        [TestMethod]
        public void TestTwoSideLinkedRemove2Cutable()
        {
            TwoSideLinkedList<int> L = new TwoSideLinkedList<int>(2, 4, 6, 8, 10);
            int[] mas = new int[5];
            mas[0] = 1;
            mas[1] = 3;
            mas[2] = 5;
            mas[3] = 7;
            mas[4] = 9;
            L.Addnot2cutableEls(mas);
            Assert.AreEqual(L.Length, 10);
        }
    }
}
