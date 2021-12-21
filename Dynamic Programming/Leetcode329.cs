using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Add Leetcode 329 2021.12.20
/*
Given an m x n integers matrix, return the length of the longest increasing path in matrix.
 
From each cell, you can either move in four directions: left, right, up, or down. 
You may not move diagonally or move outside the boundary (i.e., wrap-around is not allowed).

Input: matrix = [[9,9,4],[6,6,8],[2,1,1]]
Output: 4
Explanation: The longest increasing path is [1, 2, 6, 9].

Input: matrix = [[3,4,5],[3,2,6],[2,2,1]]
Output: 4
Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.

Input: matrix = [[1]]
Output: 1

m == matrix.length
n == matrix[i].length
1 <= m, n <= 200
0 <= matrix[i][j] <= 2^31 - 1
 */
namespace Leetcode.Dynamic_Programming
{

    class Leetcode329
    {
        int[][] _cache;

        public int LongestIncreasingPath(int[][] matrix)
        {
            var longest = 0;
            _cache = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    longest = Math.Max(longest, DFS(matrix, i, j));
                }
            }
            return longest;
        }

        private int DFS(int[][] matrix, int i, int j)
        {
            if (_cache[i] != null && _cache[i][j] > 0) return _cache[i][j];

            var longest = 0;
            if (i - 1 >= 0 && matrix[i][j] < matrix[i - 1][j])
                longest = Math.Max(longest, DFS(matrix, i - 1, j));
            if (i + 1 < matrix.Length && matrix[i][j] < matrix[i + 1][j])
                longest = Math.Max(longest, DFS(matrix, i + 1, j));
            if (j - 1 >= 0 && matrix[i][j] < matrix[i][j - 1])
                longest = Math.Max(longest, DFS(matrix, i, j - 1));
            if (j + 1 < matrix[i].Length && matrix[i][j] < matrix[i][j + 1])
                longest = Math.Max(longest, DFS(matrix, i, j + 1));

            longest++;
            if (_cache[i] == null) _cache[i] = new int[matrix[i].Length];
            _cache[i][j] = longest;
            return longest;
        }


    }

    
}
