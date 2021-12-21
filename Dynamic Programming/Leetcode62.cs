using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. 
The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?

Input: m = 3, n = 7
Output: 28

Input: m = 3, n = 2
Output: 3
Explanation:
From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
1. Right -> Down -> Down
2. Down -> Down -> Right
3. Down -> Right -> Down

Input: m = 7, n = 3
Output: 28

Input: m = 3, n = 3
Output: 6

1 <= m, n <= 100
It's guaranteed that the answer will be less than or equal to 2 * 10^9.
 */

//Add 2021.12.21

namespace Leetcode.Dynamic_Programming
{
    class Leetcode62
    {

        int[,] visited;
        int[,] memo;

        public int UniquePaths(int m, int n)
        {
            visited = new int[m, n];
            memo = new int[m, n];
            return dfs(m, n, 0, 0);
        }

        public int dfs(int m, int n, int i, int j)
        {
            if (i == m - 1 && j == n - 1) return 1;
            int sum = 0;
            // Let (i, j) be visited for current dfs recursion state
            visited[i, j] = 1;
            // Console.WriteLine(i + ", " + j);

            if (i + 1 < m && j < n && visited[i + 1, j] != 1)
            {
                sum += memo[i + 1, j] != 0 ? memo[i + 1, j] : dfs(m, n, i + 1, j);
            }
            if (i < m && j + 1 < n && visited[i, j + 1] != 1)
            {
                sum += memo[i, j + 1] != 0 ? memo[i, j + 1] : dfs(m, n, i, j + 1);
            }

            // Set (i, j) back to un-visited for former dfs recursion state
            visited[i, j] = 0;
            return memo[i, j] = sum;
        }

      
    }
}
