using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix.Test
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestMatrixBeforeRefactore()
        {
            //int actual = WalkInMatrix.TestMatrixMain();
            //int expected = 36;
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMatrixMinMaxNumber()
        {
            //int[,] matrix = WalkInMatrix.TestMatrixMainArrayResult();
            //int maxValue = matrix.GetLength(0) * matrix.GetLength(1);
            //Array.Sort(matrix);
            //int max = Array.IndexOf(matrix, maxValue);
            //int min = Array.IndexOf(matrix, 1);
            //Assert.AreEqual(max >= 0, max);
            //Assert.AreEqual(max >= 0, max);
        }

        [TestMethod]
        public void TestAreMatrixEqual()
        {
            int[,] matrix1 = 
            {
                {1, 2, 4}, 
                {1, 2, 4} 
            };

            int[,] matrix2 = 
            {
                {1, 2, 4}, 
                {1, 2, 4} 
            };
            CollectionAssert.AreEqual(matrix1, matrix2);
        }
    }
}
