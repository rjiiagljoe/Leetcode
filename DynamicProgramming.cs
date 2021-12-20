using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Add Leetcode 329 2021.12.20

namespace Leetcode
{

    class DynamicProgramming
    {

    }

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
                    longest = Math.Max(longest, LongestIncreasingPathOne(matrix, i, j));
                }
            }
            return longest;
        }

        private int LongestIncreasingPathOne(int[][] matrix, int i, int j)
        {
            if (_cache[i] != null && _cache[i][j] > 0) return _cache[i][j];

            var longest = 0;
            if (i - 1 >= 0 && matrix[i][j] < matrix[i - 1][j])
                longest = Math.Max(longest, LongestIncreasingPathOne(matrix, i - 1, j));
            if (i + 1 < matrix.Length && matrix[i][j] < matrix[i + 1][j])
                longest = Math.Max(longest, LongestIncreasingPathOne(matrix, i + 1, j));
            if (j - 1 >= 0 && matrix[i][j] < matrix[i][j - 1])
                longest = Math.Max(longest, LongestIncreasingPathOne(matrix, i, j - 1));
            if (j + 1 < matrix[i].Length && matrix[i][j] < matrix[i][j + 1])
                longest = Math.Max(longest, LongestIncreasingPathOne(matrix, i, j + 1));

            longest++;
            if (_cache[i] == null) _cache[i] = new int[matrix[i].Length];
            _cache[i][j] = longest;
            return longest;
        }
    }

    
}
