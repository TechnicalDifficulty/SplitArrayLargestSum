using SplitArrayLargest_Sum;
using System;
using Xunit;

namespace SplitArrayLargestSumTest
{
    public class SplitArrayLargestSumTest
    {
        [Fact]
        public void Is_Constrains_Match_Test()
        {
            //Arrange
            int[] nums = { 1, 4, 4 };
            int m = 3;
            var largestSumObj = new SplitArrayLargestSum();
            //Act
            var result = largestSumObj.IsConstraintsMatch(nums, m);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void Is_Contains_Negative_Test()
        {
            //Arrange
            int[] nums = { -1, -4, 4 };
            int m = 3;
            var largestSumObj = new SplitArrayLargestSum();
            //Act
            var result = largestSumObj.IsContainsNegatives(nums);
            //Assert
            Assert.True(result);
        }
    }
}
