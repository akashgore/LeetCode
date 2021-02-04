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
    }
}