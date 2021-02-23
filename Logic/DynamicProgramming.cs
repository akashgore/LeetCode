using System;

namespace LeetCode.Logic
{
    public class DynamicProgramming
    {   
        /**
        * ? 62. Unique Paths
        *! Algorithm: 
            1. A grid can be reached from top and from left
            2. Column 0 and Row 0 elements can only be reached in one way each.
            3. All other elements can be reached in total of paths from top and paths from left. 
        **/
        public int UniquePaths(int m, int n) 
        {
            int [,]arr = new int[m, n];

            for (int i = 0;i < m; i++)
            {
                arr[i,0]=1;
            }
            for (int i = 0; i < n; i++)
            {
                arr[0,i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    arr[i,j] = arr[i-1,j] + arr[i,j-1];
                }
            }
            return arr[m-1,n-1];
        }
    }
}