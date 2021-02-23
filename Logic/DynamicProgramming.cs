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

        /**
        * ? 63. Unique Paths 2
        *! Algorithm: 
            1. A grid can be reached from top and from left
            2. Column 0 and Row 0 elements can only be reached in one way each.
            3. All other elements can be reached in total of paths from top and paths from left. 
        **/
        public int UniquePaths2(int[][]obstacleGrid) 
        {
            //If starting element is obstacle, no path can exist to the finish
            if(obstacleGrid[0][0] == 1) 
            {
            return 0;
            }

            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            int [,]arr = new int[m, n];

            // If no obstacle set starting path to 1
            arr[0,0] = 1;

            // For column 0, if element is an obstacle then its path value = 0; else path is same as previous row element path. 
            // If previous row element is 0, then this element value is also 0.
            for (int i = 0;i < m; i++)
            {
                arr[i,0]=obstacleGrid[i][0]==1?0:arr[i-1,0];
            }

            // For column 0, if element is an obstacle then its path value = 0; else path is same as previous row element path. 
            // If previous row element is 0, then this element value is also 0.
            for (int i = 0; i < n; i++)
            {
                arr[0,i]=obstacleGrid[0][i]==1?0:arr[0,i-1];
            }

            // Fill out the rest of the matrix
            for (int i = 1; i < m; i++)
            {
                for(int j = 1; j < n; j++)
                {   
                    // For obstacle, arr[i][j] will remain 0 (no paths exist for an obstacle)
                    if(obstacleGrid[i][j]==1)
                        continue;

                    arr[i,j] = arr[i-1,j] + arr[i,j-1];
                }
            }
            return arr[m-1,n-1];
        }
    }
}