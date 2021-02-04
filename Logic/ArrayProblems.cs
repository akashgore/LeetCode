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

        
              



    }
}