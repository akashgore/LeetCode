using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Logic
{
    public class StringProblems
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
        * ! Algorithm: 
        1. Create a dictionary of close-open bracket pairs
        2. Iterate over the string
                a. Add every open bracket to stack
                b. Every close bracket should have its corresponding open bracket at stack top (pop); if not return false
        3. At the end of string, if stack is not empty, it means there is an open bracket whose close bracket never came. So return false
        **/
        public bool IsValid(string s) 
        {
            Stack<char> paran = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>();
            pairs.Add(')', '(');
            pairs.Add('}', '{');
            pairs.Add(']', '[');

            for (int i=0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    paran.Push(s[i]);
                }
                else
                {
                    if (paran.Count == 0 || pairs[s[i]] != paran.Pop())
                    {
                        return false;
                    }
                }
            }
            return paran.Count == 0;       
        }

        /**
        * ? 49:  Group Anagrams
        * ! Algorithm: 
                1. Create a dictionary of <sorted word, list of original words>
                2. Iterate through the array and for every word, add to its appropriate entry in the dictionary.
                3. At the end of the array retrieve dictionary values and convert to List and return.
        **/
        public IList<IList<string>> GroupAnagrams(string[] strs) 
        {
            Dictionary<string, IList<string>> anagrams = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                string word = String.Concat(strs[i].OrderBy(c => c));
                if(anagrams.ContainsKey(word))
                {
                    anagrams[word].Add(strs[i]);
                }
                else
                {
                    anagrams.Add(word, new List<string>());
                    anagrams[word].Add(strs[i]);
                }
            }
            return anagrams.Values.ToList();
        }
    }
}