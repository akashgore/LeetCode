using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Logic
{
    public class ArrayProblems
    {
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
                b. Update "result" variable as (r-l+1)

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
        * ? 20:  Valid Parentheses
        **/
        public bool IsValid(string s) {
                
        }
    }
}