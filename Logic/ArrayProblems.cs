using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Logic
{
    public class ArrayProblems
    {
        /**
        * ? 122: Best Time to Buy & Sell Stock 2
        * ! Algorithm:
            1. If today is higher; buy yesterday and sell today. 
            2. If today is not higher, no need to buy yesterday (wait for local minima to buy).   
        * ! Notes:
            1. If graph is trending upwards, you buy and sell at every point, thereby accumulating profits.
            2. If graph is trending downwards, you never buy until you see #1 from Algorithm.
        **/
        public int MaxProfit(int[] prices)
        {
            //no profit if can't sell
            if (prices.Length <=1)
            {
                return 0;
            }

            int profit = 0;
            for (int i = 1; i <= prices.Length-1; i++)
            {
                if (prices[i] > prices[i-1])
                {
                    profit += prices[i]- prices[i-1];
                }
            }
            return profit;
        }

        /**
        * ? 56: Merge Intervals
        * ! Algorithm: 
            We need to check each interval with every other interval for overlap O(n2). Instead, sort intervals by starting point. 
            Once we have the sorted intervals, we can combine all intervals in a linear traversal. 
            The idea is, in sorted array of intervals, if interval[i] doesn’t overlap with interval[i-1], 
            then interval[i+1] cannot overlap with interval[i-1] because 
            starting time of interval[i+1] must be greater than or equal to interval[i].
            Example: [1,3], [4,5], [5,7], [6,8] -> If [4,5] doesnt overlap with [1,3], the rest also won't overlap.
        
        * ! Steps
            1. Sort the intervals based on increasing order of starting time.
            2. Push the first interval on to a stack.
            3. For each interval do the following
                a. If the current interval does not overlap with the stack top, push it.
                b. If the current interval overlaps with stack top and ending time of current interval is more than that of stack top, 
               update stack top with the ending  time of current interval.
            4. At the end stack contains the merged intervals.
        **/
        public int[][] MergeIntervals(int[][] intervals) 
        {
            Stack<int[]> result_stack = new Stack<int[]>();
            if (intervals.Length==0){
                return intervals;
            }

            //sort intervals based on start time
            int[][] sortedIntervals =  intervals.OrderBy(element => element[0]).ToArray();

            //add first interval to stack
            result_stack.Push(sortedIntervals[0]);

            //Interate through the array (of arrays)
            for(int i=1; i<sortedIntervals.Length; i++)
            {
                // No overlap with interval at stack top
                if(sortedIntervals[i][0]> result_stack.Peek()[1]){
                    result_stack.Push(sortedIntervals[i]);
                }

                // Overlap exists and current interval has greater end than stack top interval end
                else if(sortedIntervals[i][1]>result_stack.Peek()[1])
                {
                    int[] new_interval = new int[] {result_stack.Pop()[0], sortedIntervals[i][1]};
                    result_stack.Push(new_interval);
                }
            }
            
            int[][] result = result_stack.ToArray();
            return result;
        }

        /**
        * ? 3:  Longest Substring Without Repeating Characters
        * ! Algorithm: Sliding Window: 2 pointer approach
        1. Left Pointer (l) at 0; Right Pointer (r) used to traverse the string s
        2. Use a set to keep track of uniqueness of a substring. 
        3. Use variable "result" to keep track of max length of the substring
        4. While s[r] is present in the set; slide the window from the left by doing the following: 
                a. Remove s[l] from set
                b. Increment Left Pointer (l)
        5. If its not, it means s[r] maintains uniqueness of the substring so: 
                a. Add character: s[r] to the set & 
                b. Update "result" variable as Math.max((r-l+1), result)

        Reference Source: https://www.youtube.com/watch?v=wiGpQwVHdE0&feature=emb_logo 
        **/
        public int LengthOfLongestSubstring(string s) 
        {
            HashSet<char> unique = new HashSet<char>();
            int l=0;
            int maxSubstringLength = 0;
            for (int r = 0; r <= s.Length; r++)
            {
                // Remove from set & increment left pointer to slide the window from the left
                while(unique.Contains(s[r]))
                {
                    unique.Remove(s[l]);
                    l=l+1;
                }
                unique.Add(s[r]);
                maxSubstringLength=Math.Max(maxSubstringLength, r-l+1);
            } 
            return maxSubstringLength;
        }

        /**
        * ? 88:  Merge Sorted Array
        * ! Algorithm: 
        1. Merge in reverse, ie: Fill nums1 from the end with the larger number.
        2. While merging:  
                a. nums2 ends before nums1: Then the remaining elements of nums1 stay where they are.
                b. nums1 ends before nums2 (Edge Case): Add all remaining elements of nums[2] to nums1[last]
        3. Note: m & n are number of elements, when using them as pointer variables ensure to use m - 1 & n - 1
        **/
        public void Merge(int[] nums1, int m, int[] nums2, int n) 
        {
            int last = m + n - 1;
            while (m > 0 && n > 0)
            {
                //Merge in reverse order
                if(nums1[m - 1] > nums2[n - 1])
                {
                    nums1[last] = nums1[m-1];
                    m = m - 1; 
                    last = last - 1; 
                }
                else
                {
                    nums1[last] = nums2[n-1];
                    n = n - 1;
                    last = last - 1;
                }
            }

            //Edge Case 2.b
            while (n > 0)
            {
                nums1[last] = nums2[n - 1];
                n -=1;
                last -=1;
            }
        }


        /**
        * ? 11. Container with Most Water
        * ! Algorithm: 
            1. Keep Max breadth and calculate Area (l=0; r=height.length-1)
            2. Whichever length is smaller (height[l] or height[r]), move that pointer ahead.  
                    If we move from the smaller side, there is a chance that we might increase the area.
                    If we move from the bigger side, there is no chance in all possible cases:
                        we find smaller wall next
                        we find bigger wall next (still height will remain the smaller of left and right, breadth will decrease by 1)
                        we find equal wall next
            3. Calculate all areas, maintain the max area.
            4. Repeat till l < r
        **/
        public int MaxArea(int[] height) 
        {
            int result = 0;
            int l = 0, r = height.Length-1;
            while (l < r)
            {
                int currentArea= Math.Min(height[l], height[r]) * (r - l);
                result= Math.Max(result, currentArea);

                if (height[l] < height[r])
                {
                    l+=1;
                }
			    else
                {
                    r-=1;
                }
            }
            return result;
        }
        

        /**
        * ? 55. Jump Games
        * ! Algorithm:
        I was thinking of a car. It needs to get parked in the garage. 
        In case the array has a length of one we are really lucky as the car is already in the garage. 
        Otherwise we need to get to the garage somehow. To get to the garage we pick up fuel along the way. 
        If we ever run out of gas then it's game over.

        We start by filling up the car at index = 0. 
        If we are already out of gas we won't be able to pick up any more gas so game over. 
        To get to the next array index it costs one fuel. 
        At the next index we can choose to stick with the fuel tank we already have (which now contains fuel - 1 amount of fuel), or pick up a new tank at the next index. 
        Some indices (nums[i] == 0) don't have any fuel so we will need to stick with what we got on those indices. 
        Hopefully we will make it back to the garage.
        **/
        public bool CanJump(int[] nums) 
        {
            int fuel = 0;
            for (int i=0; i< nums.Length-1; i++)
            {
                fuel = Math.Max(fuel-1, nums[i]);
                if (fuel==0)
                    return false;
            }
            return true;
        }

        /**
        * ? 53. Maximum Subarray
        * ! Algorithm:
                currSum = Math.Max(currSum + nums[i], nums[i]); 
                maxSum = Math.Max(maxSum, currSum);
        **/
        public int MaxSubArray(int[] nums) 
        {
            int maxSum = nums[0];
            int currSum = nums[0];
            for (int i=1; i<nums.Length; i++)
            {
                currSum = Math.Max(currSum + nums[i], nums[i]); 
                maxSum = Math.Max(maxSum, currSum);
            }
            return maxSum;
        }    
    }
}