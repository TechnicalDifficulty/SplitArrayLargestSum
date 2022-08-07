using System;
using System.Linq;

namespace SplitArrayLargest_Sum
{
    public class SplitArrayLargestSum
    {
        public static int output = 10000;
        static void Main(string[] args)
        {
            int[] nums = { 7, 2, 5, 10, 8 };
            int m = 2;
            SplitArrayLargestSum splObj = new SplitArrayLargestSum();
            //CalculateMaxSum(nums,m,0,0,0);
            bool constraintStatus = splObj.IsConstraintsMatch(nums, m);
            bool containsNegatives = splObj.IsContainsNegatives(nums);
            var output = constraintStatus && !containsNegatives ? CalculateMinSumBySpliting(nums, m) : -1;
            Console.WriteLine("Output "+output);

        }

        public bool IsContainsNegatives(int[] nums)
        {
            return nums.Any(n => n < 0);
        }

        public bool IsConstraintsMatch(int[] nums, int m)
        {
            return m >= 1 && nums.Length <= 1000 && m <= Math.Min(50, nums.Length) ? true : false;
        }

        public static int CalculateMinSumBySpliting(int[] nums, int m)
        {
            int L = nums.Length;
            int[] S = new int[L + 1];
            S[0] = 0;
            for (int i = 0; i < L; i++)
            {
                S[i + 1] = S[i] + nums[i];
            }

            int[] dp = new int[L];
            for (int i = 0; i < L; i++)
            {
                dp[i] = S[L] - S[i];
            }

            for (int s = 1; s < m; s++)
            {
                for (int i = 0; i < L - s; i++)
                {
                    dp[i] = Int32.MaxValue;
                    for (int j = i + 1; j <= L - s; j++)
                    {
                        int t = Math.Max(dp[j], S[j] - S[i]);
                        if (t <= dp[i])
                        {
                            dp[i] = t;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return dp[0];
        }

        public static void CalculateMaxSum(int []nums,int m,int pointer, int sum, int maxSum)
        {
            // when m =1 should get the maximum sum of the array
            if (m == 1)
            {
                sum = 0;
                for (int i = pointer; i < nums.Length; i++)
                {
                    sum += nums[i];
                }
                maxSum = Math.Max(maxSum, sum);
                output = Math.Min(output, maxSum);
                return;

            }

            sum = 0;

                for (int i = pointer; i < nums.Length; i++)
                {
                    sum += nums[i];
                    maxSum = Math.Max(maxSum, sum);
                    CalculateMaxSum(nums, m-1, i+1, sum, maxSum);
            }
        }
    }
}
